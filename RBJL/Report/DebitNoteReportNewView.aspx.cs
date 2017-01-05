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

public partial class Report_DebitNoteReportNewView : CultureEnabledPage
{
    MaterItem masterI = new MaterItem();
    ReportInfo rI = new ReportInfo();


    protected void Page_Load(object sender, EventArgs e)
    {
        LanguageHandler.SetLanguage(Context, Languages.English);
        string getQ = Request.Url.ToString();
        var replacedUrl = getQ.Replace(@"Report/DebitNoteReportNewView.aspx", @"Report/DebitNoteMainReportView.aspx");
        Response.Redirect(replacedUrl);
    }
    /*
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


            //var bgList = getBgImg();
            var completeBgList = getCompleteBgImg();


            int count = 1;

            List<ReportNewDeebitNoteHr> result = new List<ReportNewDeebitNoteHr>();

            foreach (var item in findDebitNote)
            {
                var DebitNoteHr = getDebitNoteHr(item.startDate.Value, item.debitNoteNum, item.category);
                foreach (var debitNoteHr in DebitNoteHr)
                {
                    if (dType == "C")
                    {
                        foreach (var bg in completeBgList)
                        {
                            //var findClient = masterI.getClient(item.clientId.Value);
                            ReportNewDeebitNoteHr temp = new ReportNewDeebitNoteHr();

                            temp.id = Convert.ToString(count);
                            temp.dNNum = debitNoteHr;
                            if (item.reportDate.HasValue)
                            {
                                temp.date = DateTimeHelper.convertDateTimeToString(item.reportDate.Value);
                            }
                            temp.refValue = item.@ref;
                            temp.yourRefValue = item.yourRef;

                            temp.billToName = item.billTo;
                            temp.address = item.address;

                            try
                            {
                                if (!String.IsNullOrEmpty(item.contactPersonList))
                                {
                                    var getAttToArr = item.contactPersonList.Split('◎');
                                    List<string> getAttToList = new List<string>();

                                    foreach (var tar in getAttToArr)
                                    {
                                        getAttToList.Add(tar.Split('●')[0]);
                                    }
                                    if (getAttToList.Count() != 0 && !String.IsNullOrEmpty(item.subRef))
                                    {
                                        temp.attnTo = String.Format("Attn.:{0} ({1})", String.Join(",", getAttToList.ToArray()), item.subRef);
                                    }
                                    else if (getAttToList.Count() != 0 && String.IsNullOrEmpty(item.subRef))
                                    {
                                        temp.attnTo = String.Format("Attn.:{0}", String.Join(",", getAttToList.ToArray()));
                                    }
                                    else if (getAttToList.Count() == 0 && !String.IsNullOrEmpty(item.subRef))
                                    {
                                        temp.attnTo = String.Format("Attn.:({0})", item.subRef);
                                    }
                                }
                            }
                            catch
                            {

                            }
                            temp.debitNoteid = item.id.ToString();
                            //temp.subject = item.subject;
                            //temp.subject = rI.setDebitNoteSubject(item);
                            if (!String.IsNullOrEmpty(item.ioNum))
                            {
                                temp.ioNum = item.ioNum;
                            }
                            temp.bgValue = bg;

                            //if (!String.IsNullOrEmpty(item.TrademarkLogo))
                            //{
                            //    string tempPath = item.TrademarkLogo.Substring(1, item.TrademarkLogo.Length - 1);
                            //    var url = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, tempPath);
                            //    temp.TLogo = url;
                            //}

                            count++;
                            result.Add(temp);
                        }
                    }
                    else
                    {
                        ReportNewDeebitNoteHr temp = new ReportNewDeebitNoteHr();

                        temp.id = Convert.ToString(count);
                        temp.dNNum = debitNoteHr;
                        if (item.reportDate.HasValue)
                        {
                            temp.date = DateTimeHelper.convertDateTimeToString(item.reportDate.Value);
                        }
                        temp.refValue = item.@ref;
                        temp.yourRefValue = item.yourRef;

                        temp.billToName = item.billTo;
                        temp.address = item.address;

                        try
                        {
                            if (!String.IsNullOrEmpty(item.contactPersonList))
                            {
                                var getAttToArr = item.contactPersonList.Split('◎');
                                List<string> getAttToList = new List<string>();

                                foreach (var tar in getAttToArr)
                                {
                                    getAttToList.Add(tar.Split('●')[0]);
                                }
                                if (getAttToList.Count() != 0 && !String.IsNullOrEmpty(item.subRef))
                                {
                                    temp.attnTo = String.Format("Attn.:{0} ({1})", String.Join(",", getAttToList.ToArray()), item.subRef);
                                }
                                else if (getAttToList.Count() != 0 && String.IsNullOrEmpty(item.subRef))
                                {
                                    temp.attnTo = String.Format("Attn.:{0}", String.Join(",", getAttToList.ToArray()));
                                }
                                else if (getAttToList.Count() == 0 && !String.IsNullOrEmpty(item.subRef))
                                {
                                    temp.attnTo = String.Format("Attn.:({0})", item.subRef);
                                }
                            }
                        }
                        catch
                        {

                        }

                        temp.debitNoteid = item.id.ToString();
                        //temp.subject = item.subject;
                        //temp.subject = rI.setDebitNoteSubject(item);
                        if (!String.IsNullOrEmpty(item.ioNum))
                        {
                            temp.ioNum = item.ioNum;
                        }
                        //if (!String.IsNullOrEmpty(item.TrademarkLogo))
                        //{
                        //    string tempPath = item.TrademarkLogo.Substring(1, item.TrademarkLogo.Length - 1);
                        //    var url = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, tempPath);
                        //    temp.TLogo = url;
                        //}
                        count++;

                        result.Add(temp);
                    }
                }
            }
            //ReportDataSource re = new ReportDataSource("DataSet1", dt);
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

     */

    //private string getReportContent(Guid id)
    //{
    //    return dNI.getDebitNoteReportContent(id);
    //}


    //private List<string> getBgImg()
    //{
    //    List<string> result = new List<string>();
    //    //result.Add(" ");
    //    var tempImage = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/images/reportImg/{0}.jpg");
    //    string getType = Request[QueryStringConst.type];
    //    if (getType != null)
    //    {
    //        var tempArr = getType.Split(',');
    //        foreach (var item in tempArr)
    //        {
    //            if (item.Equals("Draft"))
    //            {
    //                result.Add(string.Format(tempImage, "Draft"));
    //            }

    //            else if (item.Equals("Trademark"))
    //            {
    //                result.Add(string.Format(tempImage, "Trademark"));
    //            }

    //            else if (item.Equals("General"))
    //            {
    //                result.Add(string.Format(tempImage, "General"));
    //            }

    //            else if (item.Equals("Patent"))
    //            {
    //                result.Add(string.Format(tempImage, "Patent"));
    //            }

    //            else if (item.Equals("NotanyPublic"))
    //            {
    //                result.Add(string.Format(tempImage, "NotanyPublic"));
    //            }

    //            else if (item.Equals("CompletSet"))
    //            {
    //                result.Add(string.Format(tempImage, "CompletSet"));
    //            }

    //            else if (item.Equals("Language"))
    //            {
    //                result.Add(string.Format(tempImage, "Language"));
    //            }

    //        }
    //    }
    //    return result;
    //}


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


    private List<string> getDebitNoteHr(DateTime createTIme, string debitNoteNum, string category)
    {
        List<string> result = new List<string>();

        string tarYear = String.Format("{0:yy}", createTIme);
        //string getType = Request[QueryStringConst.type];

        string getType = category;
        if (getType != null)
        {
            var tempArr = getType.Split(',');
            foreach (var item in tempArr)
            {
                var tarString = item.Substring(0, 1);
                if (item.Equals("Trademark"))
                {
                    result.Add(String.Format("{0}{1}/{2}", tarString, tarYear, debitNoteNum));
                }

                else if (item.Equals("General"))
                {
                    result.Add(String.Format("{0}{1}/{2}", tarString, tarYear, debitNoteNum));
                }

                else if (item.Equals("Patent"))
                {
                    result.Add(String.Format("{0}{1}/{2}", tarString, tarYear, debitNoteNum));
                }

                else if (item.Equals("Notary Public"))
                {
                    result.Add(String.Format("{0}{1}/{2}", tarString, tarYear, debitNoteNum));
                }
            }
        }
        else
        {
            result.Add(String.Format("{0}", debitNoteNum));
        }
        return result;

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
    }
}