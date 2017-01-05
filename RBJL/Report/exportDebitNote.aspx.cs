using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LanguageUtilities;

public partial class Report_exportDebitNote : CultureEnabledPage
{
    #region constants
    const string item = "Item";
    const string date = "Date";
    const string workDone = "Work done";
    const string feeEarner = "Fee Earner";
    const string timeSpent = "Time Spent (hr)";
    const string fixedCost = "Fixed Cost";
    const string total = "Total";
    double[] feeEarnerArr;
    double[] feeEarnerHourlyRateArr;
    double[] feeEarnerHourlyRateValueArr;
    double[] feeEarnerHourlyRateValueCountTotalArr;
    double totalTimeSpent;
    double totalFixedCost;

    DebitNoteExcelHourlyRateDto[] yearAndHourlyRateArr;
    List<DebitNoteExcelHourlyRateDto>[] yearAndHourlyRateList;

    double[] nullArray = new double[0];
    #endregion

    ReportInfo rI = new ReportInfo();
    MatterInfo mI = new MatterInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            loadDynamicGrid();
        }
    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        // '處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中   
    }

    private void loadDynamicGrid()
    {
        #region Code for preparing the DataTable


        var getDebitNoteId = Request[QueryStringConst.debitNoteId];

        Guid guidResult;
        var checking = Guid.TryParse(getDebitNoteId, out guidResult);

        if (getDebitNoteId != null && checking)
        {
            var getTarEntry = rI.findDebitNoteTimeEntry(getDebitNoteId);


            if (getTarEntry.Count() > 0)
            {
                var getAllTimeEntry = rI.getTimeEntry;

                //getTarEntry = getTarEntry.OrderBy(q => mI.getUserNameBySystemId(q.feeEarner.Value)).ThenBy(q => q.date);
                getTarEntry = getTarEntry.OrderBy(q => q.date);

                var getFeeEarnerList = findFeeEarnerList(getTarEntry);

                //Create an instance of DataTable
                DataTable dt = new DataTable();

                //Create an ID column for adding to the Datatable
                DataColumn dcol = new DataColumn(item, typeof(System.Int32));
                dcol.AutoIncrement = true;
                dcol.AutoIncrementSeed = 1;
                dt.Columns.Add(dcol);

                dcol = new DataColumn(date, typeof(System.String));
                dt.Columns.Add(dcol);
                dcol = new DataColumn(workDone, typeof(System.String));
                dt.Columns.Add(dcol);
                dcol = new DataColumn(feeEarner, typeof(System.String));
                dt.Columns.Add(dcol);
                dcol = new DataColumn(timeSpent, typeof(System.Double));
                dt.Columns.Add(dcol);
                dcol = new DataColumn(fixedCost, typeof(System.Double));
                dt.Columns.Add(dcol);

                feeEarnerArr = new double[getFeeEarnerList.Count];
                feeEarnerHourlyRateArr = new double[getFeeEarnerList.Count];
                feeEarnerHourlyRateValueArr = new double[getFeeEarnerList.Count];
                feeEarnerHourlyRateValueCountTotalArr = new double[getFeeEarnerList.Count];

                yearAndHourlyRateList = new List<DebitNoteExcelHourlyRateDto>[getFeeEarnerList.Count];

                for (int i = 0; i < yearAndHourlyRateList.Length; i++)
                {
                    yearAndHourlyRateList[i] = new List<DebitNoteExcelHourlyRateDto>();
                }

                foreach (var tarFeeEarner in getFeeEarnerList)
                {
                    dcol = new DataColumn(tarFeeEarner, typeof(System.Double));
                    dt.Columns.Add(dcol);
                }

                dcol = new DataColumn(total, typeof(System.String));
                dt.Columns.Add(dcol);

                //Now add data for dynamic columns
                //As the first column is auto-increment, we do not have to add any thing.
                //Let's add some data to the second column.
                //for (int nIndex = 0; nIndex < 10; nIndex++)
                //{
                //    //Create a new row
                //    DataRow drow = dt.NewRow();

                //    //Initialize the row data.
                //    drow[date] = "Row-" + Convert.ToString((nIndex + 1));

                //    //Add the row to the datatable.
                //    dt.Rows.Add(drow);
                //}



                foreach (var dataItem in getTarEntry)
                {
                    if (!dataItem.isCountTotal.HasValue || dataItem.isCountTotal.Value == true)
                    {
                        string tarFeeEarner = rI.getUserNameBySystemId(dataItem.feeEarner.Value);
                        int feeIndex = getFeeEarnerList.FindIndex(q => q == tarFeeEarner);
                        DataRow drow = dt.NewRow();
                        drow[date] = String.Format("{0:dd-MMM-yyyy}", dataItem.date.Value);
                        drow[workDone] = dataItem.description;
                        drow[feeEarner] = tarFeeEarner;
                        if (dataItem.hourlyRateH.HasValue)
                        {
                            feeEarnerHourlyRateValueArr[feeIndex] += dataItem.hourlyRateH.Value;
                            feeEarnerHourlyRateValueCountTotalArr[feeIndex]++;

                            var getMatterDetail = rI.getMatterDetailById(getAllTimeEntry, dataItem.matterDetailsId);
                            var tarYear = getMatterDetail.UpdateDate.Value.ToString("yyyy");
                            yearAndHourlyRateList[feeIndex].Add(new DebitNoteExcelHourlyRateDto() { year = tarYear, hourlyRate = dataItem.hourlyRateH.Value });
                        }

                        if (dataItem.timespan.HasValue)
                        {
                            drow[timeSpent] = dataItem.timespan.Value;
                            drow[tarFeeEarner] = dataItem.timespan.Value;
                            feeEarnerArr[feeIndex] += dataItem.timespan.Value * dataItem.hourlyRateH.Value;
                            feeEarnerHourlyRateArr[feeIndex] += dataItem.timespan.Value;
                            totalTimeSpent += dataItem.timespan.Value;
                            drow[total] = String.Format("HK${0:#,0.##}", dataItem.timespan.Value * dataItem.hourlyRateH.Value);
                        }
                        if (dataItem.fixedCost.HasValue)
                        {
                            drow[fixedCost] = dataItem.fixedCost.Value;
                            //if (dataItem.fixedCostTimeSpan.HasValue)
                            //{
                            //    drow[tarFeeEarner] = dataItem.fixedCostTimeSpan.Value;
                            //}
                            totalFixedCost += dataItem.fixedCost.Value;
                            feeEarnerArr[feeIndex] += dataItem.fixedCost.Value;
                            drow[total] = String.Format("HK${0:#,0.##}", dataItem.fixedCost.Value);
                        }



                        dt.Rows.Add(drow);
                    }
                }
        #endregion
                if (dt.Rows.Count != 0)
                {
                    //Iterate through the columns of the datatable to set the data bound field dynamically.
                    foreach (DataColumn col in dt.Columns)
                    {
                        //Declare the bound field and allocate memory for the bound field.
                        BoundField bfield = new BoundField();

                        //Initalize the DataField value.
                        bfield.DataField = col.ColumnName;

                        //Initialize the HeaderText field value.
                        bfield.HeaderText = col.ColumnName;

                        //Add the newly created bound field to the GridView.
                        GridView1.Columns.Add(bfield);
                    }

                    //Initialize the DataSource
                    GridView1.DataSource = dt;

                    //Bind the datatable with the GridView.
                    GridView1.DataBind();

                    printExcel();
                }
            }
        }
    }



    private List<string> findFeeEarnerList(IEnumerable<RBJLLawFirmDBModel.DebitNoteNarrative> tar)
    {
        List<Guid> tempList = new List<Guid>();
        List<string> result = new List<string>();

        foreach (var item in tar)
        {
            if (item.feeEarner.HasValue)
            {
                tempList.Add(item.feeEarner.Value);
            }
        }


        foreach (var item in tempList.Distinct())
        {
            result.Add(rI.getUserNameBySystemId(item));
        }
        return result;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[2].Width = Unit.Pixel(400);
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            double totalPrice = 0;
            for (int i = 0; i < feeEarnerArr.Length; i++)
            {
                totalPrice += feeEarnerArr[i];
            }

            addMoreFooter(e, "Total number of hours:", doubleArrToStringArr(feeEarnerHourlyRateArr, false), null, true);
            addHourlyRate(e);
            addMoreFooter(e, "Costs:", doubleArrToStringArr(feeEarnerArr, true), null, true);
            addMoreFooter(e, "Total amount of costs:", null, totalPrice, false);

            /*
            e.Row.Cells[3].Text = "Amount:";
            for (int i = 0; i < feeEarnerArr.Length; i++)
            {
                //e.Row.Cells[4].Text = totalTimeSpent.ToString();
                //e.Row.Cells[5].Text = totalFixedCost.ToString();
                e.Row.Cells[6 + i].Text = String.Format("HK${0:#,0.##}", feeEarnerArr[i]);
                //e.Row.Cells[6 + i].Text = String.Format("{0:#,0.##}", feeEarnerHourlyRateArr[i]);
            }
            e.Row.Cells[6 + feeEarnerArr.Length].Text = String.Format("<b>Total no. of hourly rate {1}<br />HK${0:#,0.##}</b>", totalPrice, totalTimeSpent);
        
             */
        }
    }

    private void addHourlyRate(GridViewRowEventArgs e)
    {
        //yearAndHourlyRateList[0].Add(new DebitNoteExcelHourlyRateDto() { year = "2014", hourlyRate = 1800 });
        //yearAndHourlyRateList[0].Add(new DebitNoteExcelHourlyRateDto() { year = "2014", hourlyRate = 2000 });
        //yearAndHourlyRateList[0].Add(new DebitNoteExcelHourlyRateDto() { year = "2014", hourlyRate = 3000 });
        //yearAndHourlyRateList[1].Add(new DebitNoteExcelHourlyRateDto() { year = "2014", hourlyRate = 2000 });
        //yearAndHourlyRateList[1].Add(new DebitNoteExcelHourlyRateDto() { year = "2014", hourlyRate = 2000 });
        //List<DebitNoteExcelHourlyRateDto> distinctList = yearAndHourlyRateList[0].Distinct(new DistinctDebitNoteExcelHourlyRate()).ToList();

        bool ckeckAllSame = true;
        List<string> getYearList = new List<string>();
        foreach (var tarList in yearAndHourlyRateList)
        {
            var checkHourlyRateIsSame = tarList.Select(q => q.hourlyRate).Distinct();
            var checkYearIsSame = tarList.Select(q => q.year).Distinct();

            if (checkHourlyRateIsSame.Count() > 1 && checkYearIsSame.Count() > 1)
            {
                getYearList.AddRange(checkYearIsSame);
                ckeckAllSame = false;
                //break;
            }
            //foreach (var item in tarList)
            //{

            //}
        }
        if (ckeckAllSame)
        {
            addMoreFooter(e, "Hourly rate:", doubleArrToStringArrAverage(feeEarnerHourlyRateValueArr, feeEarnerHourlyRateValueCountTotalArr), null, true);
        }
        else
        {
            getYearList = getYearList.Distinct().OrderBy(q => q).ToList();
            foreach (var year in getYearList)
            {
                string[] tarYearValue = new string[yearAndHourlyRateList.Length];


                for (int i = 0; i < yearAndHourlyRateList.Length; i++)
                {
                    double aver = 0;
                    var tarFeeEanerYearEntry = yearAndHourlyRateList[i].Where(q => q.year == year);
                    if (tarFeeEanerYearEntry.Count() > 0)
                    {
                        aver = tarFeeEanerYearEntry.Average(a => a.hourlyRate);
                        tarYearValue[i] = String.Format("HK${0:#,0.##}", aver);
                    }
                }
                addMoreFooter(e, String.Format("Hourly rate of {0}:", year), tarYearValue, null, true);
            }
        }
    }


    private void addMoreFooter(GridViewRowEventArgs e, string title, string[] tarArray, double? totalPrice, bool isLoop)
    {
        int RowIndex = e.Row.RowIndex;
        int DataItemIndex = e.Row.DataItemIndex;
        int Columnscount = GridView1.Columns.Count;
        GridViewRow row = new GridViewRow(RowIndex, DataItemIndex, DataControlRowType.Footer, DataControlRowState.Normal);
        for (int i = 0; i < Columnscount; i++)
        {
            TableCell tablecell = new TableCell();
            if (i == 2)
            {
                tablecell.Text = setR(title);
            }
            else if (i == Columnscount - 1)
            {
                if (totalPrice.HasValue)
                {
                    tablecell.Text = setR(String.Format("<b>HK${0:#,0.##}</b>", totalPrice.Value));
                }
            }

            if (isLoop)
            {
                for (int y = 0; y < feeEarnerArr.Length; y++)
                {
                    if (i == y + 6)
                    {
                        tablecell.Text = String.Format("{0}", tarArray[y]);
                    }
                }
            }
            row.Cells.Add(tablecell);
        }
        this.GridView1.Controls[0].Controls.Add(row);
    }

    private string setR(string tar)
    {
        return String.Format("<p align=&#34;right&#34;>{0}</p>", tar);
    }

    private string[] doubleArrToStringArr(double[] tarArray, bool isHKD)
    {
        string[] result = new string[tarArray.Length];

        for (int i = 0; i < tarArray.Length; i++)
        {
            if (isHKD)
            {
                result[i] = String.Format("HK${0:#,0.##}", tarArray[i]);
            }
            else
            {
                result[i] = String.Format("{0}", tarArray[i]);
            }
        }
        return result;
    }

    private string[] doubleArrToStringArrAverage(double[] tarArray, double[] totalArr)
    {
        string[] result = new string[tarArray.Length];

        for (int i = 0; i < tarArray.Length; i++)
        {
            result[i] = String.Format("HK${0:#,0.##}", tarArray[i] / totalArr[i]);

        }
        return result;
    }

    private void printExcel()
    {
        Response.ClearContent();
        Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
        string excelFileName = String.Format("debitNote__{0:yyyyMMddHHmmss}.xls", DateTime.Now);
        Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
        Response.ContentType = "application/excel";
        GridView1.AllowPaging = false;
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {

        var getDebitNoteId = Request[QueryStringConst.debitNoteId];

        IQueryable<RBJLLawFirmDBModel.View_ReportDebitNote> tar = rI.findDebitNoteReportAll();

        rI.findDebitNoteReportById(ref tar, getDebitNoteId);
        var findTar = tar.FirstOrDefault();
        var matterInfo = mI.getMatterInfoByMatterId(findTar.matterNumId.ToString());

        string hrInfo = String.Format("Matter No.:{0}, Client:{1}, subject:{2}", matterInfo.matterNum, findTar.clientName, findTar.subject);

        int colIndex = GridView1.Columns.Count;
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        TableHeaderCell cell = new TableHeaderCell();

        cell.Text = hrInfo.ToString();
        cell.ColumnSpan = colIndex;
        cell.HorizontalAlign = HorizontalAlign.Left;
        row.Controls.Add(cell);


        //cell = new TableHeaderCell();
        //cell.ColumnSpan = 2;
        //cell.Text = "Employees";
        //row.Controls.Add(cell);
        //row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
        GridView1.HeaderRow.Parent.Controls.AddAt(0, row);

        if (!String.IsNullOrEmpty(matterInfo.logo))
        {
            Image im = new Image();
            im.ImageUrl = GetUrl(matterInfo.logo);
            GridViewRow rowI = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cellI = new TableHeaderCell();
            cellI.ColumnSpan = colIndex;
            cellI.Controls.Add(im);
            cellI.Height = Unit.Pixel(130);
            cell.HorizontalAlign = HorizontalAlign.Left;
            rowI.Controls.Add(cellI);
            GridView1.HeaderRow.Parent.Controls.AddAt(0, rowI);
        }
    }


    protected string GetUrl(string imagepath)
    {
        string tempPath = imagepath.Substring(1, imagepath.Length - 1);
        var url = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, tempPath);

        return url;

    }

}