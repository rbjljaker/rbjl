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

public partial class Report_DebitNoteReportView : CultureEnabledPage
{
    ReportInfo rI = new ReportInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string header = DebitBitNoteReport.setHr();
            DataTable dt = DataTableHelper.CreateDataTable(header);

            IQueryable<RBJLLawFirmDBModel.View_ReportDebitNote> findDebitNote;

            string getDate = Request[QueryStringConst.date];
            string getDateTo = Request[QueryStringConst.dateTo];
            string getFee = Request[QueryStringConst.feeEarner];
            string getId = Request[QueryStringConst.matter];
            string dType = Request[QueryStringConst.dType];

            string getSubject = Request[QueryStringConst.subject];
            string getStatus = Request[QueryStringConst.status];

            string debitNoteId = Request[QueryStringConst.debitNoteId];

            if (debitNoteId != null)
            {
                findDebitNote = rI.findDebitNoteReportAll();
            }
            else
            {
                findDebitNote = rI.findDebitNoteReport();
            }

            if (getDate != null)
            {
                rI.findDebitNoteReportByDate(ref findDebitNote, getDate, getDateTo);
            }
            if (getFee != null)
            {
                rI.findDebitNoteReportByFeeEarner(ref findDebitNote, getFee);
            }
            if (getId != null)
            {
                rI.findDebitNoteReportByMatterNumId(ref findDebitNote, getId);
            }

            if (getSubject != null)
            {
                rI.findDebitNoteReportBySubject(ref findDebitNote, getSubject);
            }

            if (getStatus != null)
            {
                rI.findDebitNoteReportByStatus(ref findDebitNote, getStatus);
            }

            if (debitNoteId != null)
            {
                rI.findDebitNoteReportById(ref findDebitNote, debitNoteId);
            }


            var bgList = getBgImg();
            var completeBgList = getCompleteBgImg();


            int count = 1;

            foreach (var item in findDebitNote)
            {
                var DebitNoteHr = getDebitNoteHr(item.startDate.Value, item.debitNoteNum);
                foreach (var debitNoteHr in DebitNoteHr)
                {
                    if (dType == "C")
                    {
                        foreach (var bg in completeBgList)
                        {
                            string[] strList = new string[dt.Columns.Count];
                            strList[0] = Convert.ToString(count);
                            strList[1] = debitNoteHr;
                            strList[2] = DateTimeHelper.convertDateTimeToString(item.CreateDate.Value);
                            strList[3] = item.@ref;
                            strList[4] = item.address;
                            strList[5] = String.Format("{0}", item.yourRef);
                            strList[6] = rI.getDebitNoteReportContent(item);
                            strList[7] = bg;
                            string dTableValue = DataTableHelper.joinArrayToString(strList);
                            DataTableHelper.CreateDataRow(ref dt, dTableValue);
                            count++;
                        }
                    }
                    else
                    {
                        string[] strList = new string[dt.Columns.Count];
                        strList[0] = Convert.ToString(count);
                        strList[1] = debitNoteHr;
                        strList[2] = DateTimeHelper.convertDateTimeToString(item.CreateDate.Value);
                        strList[3] = item.@ref;
                        strList[4] = item.address;
                        strList[5] = String.Format("{0}", item.yourRef);
                        strList[6] = rI.getDebitNoteReportContent(item);
                        strList[7] = "";
                        string dTableValue = DataTableHelper.joinArrayToString(strList);
                        DataTableHelper.CreateDataRow(ref dt, dTableValue);
                        count++;
                    }
                }
            }
            ReportDataSource re = new ReportDataSource("DataSetDebitNoteHr", dt);
            ReportViewerDebitNote.LocalReport.DataSources.Clear();
            ReportViewerDebitNote.LocalReport.DataSources.Add(re);
            ReportViewerDebitNote.LocalReport.EnableExternalImages = true;
            //var templateImage = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/images/watermarkBg.jpg");
            //ReportViewerDebitNote.LocalReport.SetParameters(new ReportParameter("ImageName", templateImage));
            ReportViewerDebitNote.LocalReport.Refresh();
        }
    }

    //private string getReportContent(Guid id)
    //{
    //    return dNI.getDebitNoteReportContent(id);
    //}


    private List<string> getBgImg()
    {
        List<string> result = new List<string>();
        //result.Add(" ");
        var tempImage = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/images/reportImg/{0}.jpg");
        string getType = Request[QueryStringConst.type];
        if (getType != null)
        {
            var tempArr = getType.Split(',');
            foreach (var item in tempArr)
            {
                if (item.Equals("Draft"))
                {
                    result.Add(string.Format(tempImage, "Draft"));
                }

                else if (item.Equals("Trademark"))
                {
                    result.Add(string.Format(tempImage, "Trademark"));
                }

                else if (item.Equals("General"))
                {
                    result.Add(string.Format(tempImage, "General"));
                }

                else if (item.Equals("Patent"))
                {
                    result.Add(string.Format(tempImage, "Patent"));
                }

                else if (item.Equals("NotanyPublic"))
                {
                    result.Add(string.Format(tempImage, "NotanyPublic"));
                }

                else if (item.Equals("CompletSet"))
                {
                    result.Add(string.Format(tempImage, "CompletSet"));
                }

                else if (item.Equals("Language"))
                {
                    result.Add(string.Format(tempImage, "Language"));
                }

            }
        }
        return result;
    }


    private List<string> getCompleteBgImg()
    {
        List<string> result = new List<string>();
        var tempImage = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/images/reportImg/{0}.jpg");

        result.Add(string.Format(tempImage, "account"));
        result.Add(string.Format(tempImage, "file"));
        result.Add(string.Format(tempImage, "empty"));
        result.Add(string.Format(tempImage, "receipt"));


        return result;
    }


    private List<string> getDebitNoteHr(DateTime createTIme, string debitNoteNum)
    {
        List<string> result = new List<string>();

        string tarYear = String.Format("{0:yy}", createTIme);
        string getType = Request[QueryStringConst.type];
        if (getType != null)
        {
            var tempArr = getType.Split(',');
            foreach (var item in tempArr)
            {
                var tarString = item.Substring(0, 1);
                if (item.Equals("Trademark"))
                {
                    result.Add(String.Format("TM{1}-{2}", tarString, tarYear, debitNoteNum));
                }

                else if (item.Equals("General"))
                {
                    result.Add(String.Format("{0}{1}-{2}", tarString, tarYear, debitNoteNum));
                }

                else if (item.Equals("Patent"))
                {
                    result.Add(String.Format("{0}{1}-{2}", tarString, tarYear, debitNoteNum));
                }

                else if (item.Equals("NotanyPublic"))
                {
                    result.Add(String.Format("{0}{1}-{2}", tarString, tarYear, debitNoteNum));
                }
            }
        }
        else
        {
            result.Add(String.Format("{0}", debitNoteNum));
        }
        return result;

    }
}