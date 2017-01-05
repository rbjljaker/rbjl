using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using RBJLLawFirmDBModel;

public partial class PutAway_PutAway : CultureEnabledPage
{
    MatterInfo mI = new MatterInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(0);", true);
        if (!IsPostBack)
        {
            GridViewMatter.Columns[1].Visible = false;

            string isTimeEntry = Request.QueryString["timeEntry"];
            if (isTimeEntry != null)
            {
                GridViewMatter.Columns[1].Visible = true;
                GridViewMatter.Columns[6].Visible = false;
            }

            if (mI.userLevel != EnumUserLevel.administrator)
            {
                searchPanel.Visible = false;
            }
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceMatter.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }

    protected void GridViewMatter_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //SessionClass.MatterId = Convert.ToString(GridViewMatter.DataKeys[rowIndex].Value);
            Response.Redirect(String.Format("MatterCore.aspx?matter={0}", Convert.ToString(GridViewMatter.DataKeys[rowIndex].Value)));
        }
    }
    protected void EntityDataSourceMatter_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = "(it.status = '3' || it.status = '4') and it.matterNum is not null";

        //if (mI.userLevel == EnumUserLevel.administrator || mI.userLevel == EnumUserLevel.account)
        //{
        //    e.DataSource.Where = "(it.status = '3' || it.status = '4') and it.matterNum is not null";
        //}
        //else
        //{
        //    e.DataSource.Where = mI.findCurrPutAway();
        //}
    }
    protected void EntityDataSourceMatter_QueryCreated(object sender, QueryCreatedEventArgs e)
    {
        if (mI.userLevel == EnumUserLevel.administrator || mI.userLevel == EnumUserLevel.account)
        {
            if (!String.IsNullOrEmpty(TextBoxPutAwayNum.Text))
            {
                IQueryable<View_FindMatter> vF = e.Query.Cast<View_FindMatter>() as IQueryable<View_FindMatter>;
                var result = from q in vF
                             where q.putAwayBoxNum.Contains(TextBoxPutAwayNum.Text)
                             select q;
                e.Query = result;
            }
        }
        else
        {
            var tarList = mI.findMatterTarUserList();
            IQueryable<View_FindMatter> vF = e.Query.Cast<View_FindMatter>() as IQueryable<View_FindMatter>;
            var result = from q in vF
                         where tarList.Contains(q.id) || q.releaseToPublic == true
                         select q;
            if (!String.IsNullOrEmpty(TextBoxPutAwayNum.Text))
            {
                result = from q in result
                         where q.putAwayBoxNum.Contains(TextBoxPutAwayNum.Text)
                         select q;
            }
            e.Query = result;
        }
    }
    protected void GridViewMatter_RowCreated(object sender, GridViewRowEventArgs e)
    {
    }
    protected void Button_search_Click(object sender, EventArgs e)
    {
        dataBind();
    }
    private void dataBind()
    {
        EntityDataSourceMatter.DataBind();
        GridViewMatter.DataBind();
    }
}