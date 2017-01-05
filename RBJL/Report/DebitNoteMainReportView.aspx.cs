using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using GeneralUtilities;
using LanguageUtilities;

public partial class Report_DebitNoteMainReportView : CultureEnabledPage
{
    MaterItem masterI = new MaterItem();
    ReportInfo rI = new ReportInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //rI.mustShow=Request["mustShow"]=="true";
            LanguageHandler.SetLanguage(Context, Languages.English);

            string getDate = Request[QueryStringConst.date];
            string getDateTo = Request[QueryStringConst.dateTo];
            string getFee = Request[QueryStringConst.feeEarner];
            string getId = Request[QueryStringConst.matter];
            string dType = Request[QueryStringConst.dType];

            string getSubject = Request[QueryStringConst.subject];
            string getStatus = Request[QueryStringConst.status];

            string debitNoteId = Request[QueryStringConst.debitNoteId];

            var result = rI.reportMainEntry(debitNoteId, getDate, getDateTo, getFee, getId, getSubject, getStatus, dType);

            ReportDataSource re = new ReportDataSource("DataSet1", ListToDataTableHelper.ConvertToDataTable(result));
            ReportViewerDebitNote.LocalReport.DataSources.Clear();
            ReportViewerDebitNote.LocalReport.DataSources.Add(re);
            ReportViewerDebitNote.LocalReport.EnableExternalImages = true;
            //var templateImage = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/images/watermarkBg.jpg");
            //ReportViewerDebitNote.LocalReport.SetParameters(new ReportParameter("ImageName", templateImage));

            ReportViewerDebitNote.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);

            ReportViewerDebitNote.LocalReport.Refresh();
        }
    }

    void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
    {
        if (e.ReportPath == "DebitNoteContentReport")
        {
            // get empID from the parameters
            string debitNoteId = (e.Parameters[0].Values[0]);
            List<ReportNewDebitNote> result = rI.setDebitNoteCont(debitNoteId);

            ReportDataSource re = new ReportDataSource("DataSet1", ListToDataTableHelper.ConvertToDataTable(result));
            e.DataSources.Clear();
            e.DataSources.Add(re);
        }
        else if (e.ReportPath == "DebitNoteContentSubReport")
        {
            string debitNoteId = (e.Parameters[0].Values[0]);

            List<DebitNoteSubReportDto> result = rI.setDebitNoteSubject(debitNoteId);

            ReportDataSource re = new ReportDataSource("DataSet1", ListToDataTableHelper.ConvertToDataTable(result));
            e.DataSources.Clear();
            e.DataSources.Add(re);
        }

        else if (e.ReportPath == "DebitNoteMainContentReport")
        {
            string debitNoteId = (e.Parameters[0].Values[0]);

            string getDate = Request[QueryStringConst.date];
            string getDateTo = Request[QueryStringConst.dateTo];
            string getFee = Request[QueryStringConst.feeEarner];
            string getId = Request[QueryStringConst.matter];
            string dType = Request[QueryStringConst.dType];

            string getSubject = Request[QueryStringConst.subject];
            string getStatus = Request[QueryStringConst.status];

            var temp = rI.reportMainEntry(debitNoteId, getDate, getDateTo, getFee, getId, getSubject, getStatus, dType);

            List<ReportNewDeebitNoteHr> result = new List<ReportNewDeebitNoteHr>();
            result.Add(temp[0]);

            getAddressValue(temp[0].address, temp[0].attnTo);

            ReportDataSource re = new ReportDataSource("DataSet1", ListToDataTableHelper.ConvertToDataTable(result));
            e.DataSources.Clear();
            e.DataSources.Add(re);

            List<ReportDebitNoteMainContent> result1 = rI.setDebitNoteMainCont(debitNoteId);

            ReportDataSource re1 = new ReportDataSource("DataSet2", ListToDataTableHelper.ConvertToDataTable(result1));
            e.DataSources.Add(re1);
        }
    }


    public string getAddressValue(string address, string att)
    {
        string result = string.Empty;

        if (!String.IsNullOrEmpty(address))
        {
            var addressArray = address.Split(new string[] { ", " }, StringSplitOptions.None);

            int countDot = 0;
            int checkStringLength1 = 0;
            int checkStringLength2 = 0;
            for (int i = 0; i < addressArray.Length; i++)
            {
                checkStringLength1 = addressArray[i].Length;
                var lineTotal = (checkStringLength1 + checkStringLength2);
                if ((lineTotal > 40 && checkStringLength2 != 0) || countDot == 2)
                {
                    checkStringLength2 = 0;
                    countDot = 0;
                    result += "<br />";
                }
                else
                {
                    checkStringLength2 = checkStringLength1;
                }

                result += addressArray[i];
                if (addressArray.Length - 1 != i)
                {
                    result += ", ";
                }

                //if (setBr % 2 != 0)
                //{
                //    result += "<br />";
                //}


                countDot++;
            }
        }

        if (!String.IsNullOrEmpty(att))
        {
            result += "<br /><b><u>" + att + "</u></b>";
        }

        result = result.Replace("<br /><br />", "<br />");

        return result;
    }
}
