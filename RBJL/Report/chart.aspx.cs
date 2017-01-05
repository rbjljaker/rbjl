using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using GeneralUtilities;
using System.Web.Security;

public partial class Report_chart : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            string getDate = Request[QueryStringConst.date];
            string getDateTo = Request[QueryStringConst.dateTo];
            string getFeeEarner = Request[QueryStringConst.feeEarner];
            string reportTitle = "All Period";

            TimeEntryInfo tEI = new TimeEntryInfo();

            var findTar = tEI.getTimeEntry;
            var findDebiitNote = tEI.getDebitNoteCores;

            List<Guid> feeEarnerGuidList;

            if (getDate != null)
            {
                tEI.getMatterDetailByDataRange(ref findTar, getDate, getDateTo);
                tEI.getDebitNoteCoresByDataRange(ref findDebiitNote, getDate, getDateTo);

                reportTitle = String.Format("Period {0} - {1}", getDate, getDateTo);
            }

            if (getFeeEarner != null)
            {
                feeEarnerGuidList = getFeeEarner.Split(',').Select(s => Guid.Parse(s)).ToList();
            }
            else
            {
                feeEarnerGuidList = tEI.getUserIdInRole(EnumFeeEarnerAndHandlingColleague.FeeEarner);
            }

            int i = 1;
            List<AmountChart> resultList = new List<AmountChart>();
            UserInfo uI = new UserInfo();


            foreach (var item in feeEarnerGuidList)
            {
                var user = Membership.GetUser(item);
                if (user != null)
                {
                    Guid userId = new Guid(user.ProviderUserKey.ToString());
                    var amountTotal = tEI.getReportTarAmount(findTar, userId);
                    var amountD = tEI.getReportTarBillbleOrNonValue(findTar, userId, findDebiitNote);

                    //tEI = new TimeEntryInfo(user.UserName);
                    var userNickName = uI.getIntroducer(userId.ToString());
                    resultList.Add(new AmountChart { id = i.ToString(), feeEarnerName = userNickName, amount = amountTotal, tempValue1 = amountD.billable, tempValue2 = amountD.nonBillable, billed = amountD.billed, unbilled = amountD.unbilled, writtenOff = amountD.writtenOff });
                }
                i++;
            }

            if (resultList.Count != 0)
            {
                resultList = resultList.OrderBy(q => q.feeEarnerName).ToList();
            }

            ReportDataSource re = new ReportDataSource("FeeEarnerChartDataset", ListToDataTableHelper.ConvertToDataTable(resultList));
            ReportViewerFeeEarner.LocalReport.DataSources.Clear();
            ReportViewerFeeEarner.LocalReport.DataSources.Add(re);

            ReportViewerFeeEarner.LocalReport.SetParameters(new ReportParameter("ReportTitile", reportTitle));

            int chartHValue = resultList.Count * 70 + 20;
            string chartH = String.Format("{0}pt", chartHValue > 180 ? chartHValue : 180);
            ReportViewerFeeEarner.LocalReport.SetParameters(new ReportParameter("chartHeight", chartH));

            ReportViewerFeeEarner.LocalReport.Refresh();
        }
    }
}