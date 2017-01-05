using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;


public class GridviewHelper
{
    public GridviewHelper()
    {
    }


    public GridView gridView = null;

    public void GridPaging(object sender, EventArgs e)
    {
        gridView = (sender as GridView);

        int nTotalCount = gridView.Rows.Count * gridView.PageCount;

        //if (gridView.DataSource != null)
        //{
        //    nTotalCount = gridView.Rows.Count*gridView.PageCount;
        //}
        //else
        //{
        //    DataView dv = (DataView)((SqlDataSource)gridView.Page.FindControl(gridView.DataSourceID)).Select(DataSourceSelectArguments.Empty);
        //    if (dv != null)
        //        nTotalCount = dv.Count;
        //}

        if (nTotalCount > 0)   
        {
            
            GridViewRow gvrPagerRow = gridView.BottomPagerRow;

 
            int intCurrentPage = gridView.PageIndex + 1;

            int intPageCount = gridView.PageCount;                     
            int intStartPage = Math.Max(intCurrentPage - 4, 1);        
            int intEndPage = Math.Min(intPageCount, intStartPage + 9);

            if (intCurrentPage == 1) 
                ((LinkButton)gvrPagerRow.Cells[0].FindControl("ucPaging$lbPreviousPage")).Visible = false;
            if (intCurrentPage == gridView.PageCount)
                ((LinkButton)gvrPagerRow.Cells[0].FindControl("ucPaging$lbNextPage")).Visible = false;

            if (intStartPage > 1)
            {
                ((LinkButton)gvrPagerRow.Cells[0].FindControl("ucPaging$lbFirstPage")).Visible = true;
            }
            else
            {
                ((LinkButton)gvrPagerRow.Cells[0].FindControl("ucPaging$lbFirstPage")).Visible = false;
                ((Literal)gvrPagerRow.Cells[0].FindControl("ucPaging$ltlPageLine1")).Visible = false;
            }

            for (int j = intStartPage; j <= intEndPage; j++)
            {
                LinkButton lbPageNo = new LinkButton();
                lbPageNo.CausesValidation = false;
                if (j != intCurrentPage)  
                {
                    lbPageNo.Text = Convert.ToString(j);
                }
                else              
                {
                    lbPageNo.Text = Convert.ToString(j);
                    lbPageNo.Font.Underline = false;
                    lbPageNo.Font.Size = 11;        
                    lbPageNo.ForeColor = System.Drawing.Color.Tomato;
                }
                lbPageNo.ID = (lbPageNo + j.ToString());
                lbPageNo.CommandArgument = (j - 1).ToString(); 
                lbPageNo.Click += new EventHandler(lbPageNo_Click);
                gvrPagerRow.Cells[0].Controls.Add(lbPageNo);
                Literal litBlank = new Literal();
                litBlank.Text = "  ";
                gvrPagerRow.Cells[0].Controls.Add(litBlank);
                ((PlaceHolder)gvrPagerRow.Cells[0].FindControl("ucPaging$phInGridView1")).Controls.Add(lbPageNo);
                ((PlaceHolder)gvrPagerRow.Cells[0].FindControl("ucPaging$phInGridView1")).Controls.Add(litBlank);
            }

            
            if (intPageCount > intEndPage)
            {
                ((LinkButton)gvrPagerRow.Cells[0].FindControl("ucPaging$lbLastPage")).Visible = true;   
            }
            else
            {
                ((LinkButton)gvrPagerRow.Cells[0].FindControl("ucPaging$lbLastPage")).Visible = false;
                ((Literal)gvrPagerRow.Cells[0].FindControl("ucPaging$ltlPageLine2")).Visible = false;       
            }

         }
        

    }

    public void lbPageNo_Click(object sender, EventArgs e)
    {
        gridView.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandArgument);
        gridView.DataBind();
    }
}