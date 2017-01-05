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
using RBJLLawFirmDBModel;

public partial class Report_NewMatterRecordReportView : CultureEnabledPage
{

    ReportInfo rI = new ReportInfo();
    MatterInfo mI = new MatterInfo();
    MaterItem masterI = new MaterItem();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string getDate = Request[QueryStringConst.date];
            string getDateTo = Request[QueryStringConst.dateTo];
            string getFee = Request[QueryStringConst.feeEarner];
            string getId = Request[QueryStringConst.matter];

            string getSubject = Request[QueryStringConst.subject];
            string getClient = Request[QueryStringConst.client];
            string matterId = Request[QueryStringConst.matterId];

            IQueryable<RBJLLawFirmDBModel.View_FindMatter> findMatter;
            if (matterId != null)
            {
                findMatter = rI.findMatterReportWithNoMatterNum();
            }
            else
            {
                findMatter = rI.findMatterReport();
            }

            if (getDate != null)
            {
                rI.findMatterReportByDate(ref findMatter, getDate, getDateTo);
            }
            if (getFee != null)
            {
                rI.findMatterReportByFeeEarner(ref findMatter, getFee);
            }

            if (getId != null)
            {
                rI.findMatterReportById(ref findMatter, getId);
            }

            if (getSubject != null)
            {
                rI.findMatterReportBySubject(ref findMatter, getSubject);
            }

            if (getClient != null)
            {
                rI.findMatterReportByClinetId(ref findMatter, getClient);
            }

            if (matterId != null)
            {
                rI.findMatterReportByMatterId(ref findMatter, matterId);
            }

            List<ReportNewMatterRecord> resultList = new List<ReportNewMatterRecord>();

            foreach (var item in findMatter)
            {
                ReportNewMatterRecord temp = new ReportNewMatterRecord();
                var findClient = masterI.getClient(item.clientId);
                //var findReferer = masterI.getReferer(item.refererId.);

                temp.clientName = item.clientName;
                temp.incomimgAgent = item.refererName;
                temp.outgoingAgent = item.agentName;
                temp.subject = item.matterSubject;
                temp.address = String.Format("{0} {1}", findClient.billingAddressFirst, findClient.billingAddressSecond);
                temp.country = findClient.countryId.HasValue ? findClient.Country.countryName : "";
                temp.feeEarner = mI.getFeeEarnerAndHandlingColleagueByMatterId(item.id, EnumFeeEarnerAndHandlingColleague.FeeEarner);
                temp.handingColleague = mI.getFeeEarnerAndHandlingColleagueByMatterId(item.id, EnumFeeEarnerAndHandlingColleague.HandlingColleague);
                temp.introducer = mI.getIntroducer(item.introducer);
                //temp.legalAid = item.islegalAid.Value ? "Yes" : "No";

                temp.matterNumber = item.matterNum;
                temp.jobType = Convert.ToString(item.jobTypeId);


                List<string> clientContactPersonList = new List<string>();
                List<string> clientEmailList = new List<string>();
                List<string> clientTelephoneNumberList = new List<string>();

                clientContactPersonList.Add(findClient.contactPerson);
                clientEmailList.Add(findClient.email);
                clientTelephoneNumberList.Add(findClient.tel);

                if (!String.IsNullOrEmpty(findClient.contactPerson02))
                {
                    clientContactPersonList.Add(findClient.contactPerson02);
                    clientEmailList.Add(findClient.email02);
                    clientTelephoneNumberList.Add(findClient.tel02);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson03))
                {
                    clientContactPersonList.Add(findClient.contactPerson03);
                    clientEmailList.Add(findClient.email03);
                    clientTelephoneNumberList.Add(findClient.tel03);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson04))
                {
                    clientContactPersonList.Add(findClient.contactPerson04);
                    clientEmailList.Add(findClient.email04);
                    clientTelephoneNumberList.Add(findClient.tel04);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson05))
                {
                    clientContactPersonList.Add(findClient.contactPerson05);
                    clientEmailList.Add(findClient.email05);
                    clientTelephoneNumberList.Add(findClient.tel05);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson06))
                {
                    clientContactPersonList.Add(findClient.contactPerson06);
                    clientEmailList.Add(findClient.email06);
                    clientTelephoneNumberList.Add(findClient.tel06);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson07))
                {
                    clientContactPersonList.Add(findClient.contactPerson07);
                    clientEmailList.Add(findClient.email07);
                    clientTelephoneNumberList.Add(findClient.tel07);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson08))
                {
                    clientContactPersonList.Add(findClient.contactPerson08);
                    clientEmailList.Add(findClient.email08);
                    clientTelephoneNumberList.Add(findClient.tel08);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson09))
                {
                    clientContactPersonList.Add(findClient.contactPerson09);
                    clientEmailList.Add(findClient.email09);
                    clientTelephoneNumberList.Add(findClient.tel09);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson10))
                {
                    clientContactPersonList.Add(findClient.contactPerson10);
                    clientEmailList.Add(findClient.email10);
                    clientTelephoneNumberList.Add(findClient.tel10);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson11))
                {
                    clientContactPersonList.Add(findClient.contactPerson11);
                    clientEmailList.Add(findClient.email11);
                    clientTelephoneNumberList.Add(findClient.tel11);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson12))
                {
                    clientContactPersonList.Add(findClient.contactPerson12);
                    clientEmailList.Add(findClient.email12);
                    clientTelephoneNumberList.Add(findClient.tel12);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson13))
                {
                    clientContactPersonList.Add(findClient.contactPerson13);
                    clientEmailList.Add(findClient.email13);
                    clientTelephoneNumberList.Add(findClient.tel13);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson14))
                {
                    clientContactPersonList.Add(findClient.contactPerson14);
                    clientEmailList.Add(findClient.email14);
                    clientTelephoneNumberList.Add(findClient.tel14);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson15))
                {
                    clientContactPersonList.Add(findClient.contactPerson15);
                    clientEmailList.Add(findClient.email15);
                    clientTelephoneNumberList.Add(findClient.tel15);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson16))
                {
                    clientContactPersonList.Add(findClient.contactPerson16);
                    clientEmailList.Add(findClient.email16);
                    clientTelephoneNumberList.Add(findClient.tel16);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson17))
                {
                    clientContactPersonList.Add(findClient.contactPerson17);
                    clientEmailList.Add(findClient.email17);
                    clientTelephoneNumberList.Add(findClient.tel17);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson18))
                {
                    clientContactPersonList.Add(findClient.contactPerson18);
                    clientEmailList.Add(findClient.email18);
                    clientTelephoneNumberList.Add(findClient.tel18);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson19))
                {
                    clientContactPersonList.Add(findClient.contactPerson19);
                    clientEmailList.Add(findClient.email19);
                    clientTelephoneNumberList.Add(findClient.tel19);
                }
                if (!String.IsNullOrEmpty(findClient.contactPerson20))
                {
                    clientContactPersonList.Add(findClient.contactPerson20);
                    clientEmailList.Add(findClient.email20);
                    clientTelephoneNumberList.Add(findClient.tel20);
                }


                temp.contactPerson = String.Join(", ", clientContactPersonList.ToArray());
                temp.email = String.Join(", ", clientEmailList.ToArray());
                temp.telephoneNumber = String.Join(", ", clientTelephoneNumberList.ToArray());

                temp.faxNumber = findClient.fax;
                temp.fileOpenDay = item.fileOpenDate.HasValue ? DateTimeHelper.convertDateTimeToString(item.fileOpenDate.Value) : "";
                temp.excelRecordNum = "Record for New File (Client Sheet)";

                resultList.Add(temp);


                getReferInfo(item, ref resultList);
            }

            ReportDataSource re = new ReportDataSource("DataSetMatterView", ListToDataTableHelper.ConvertToDataTable(resultList));
            ReportViewerViewMatter.LocalReport.DataSources.Clear();
            ReportViewerViewMatter.LocalReport.DataSources.Add(re);
            ReportViewerViewMatter.LocalReport.Refresh();
        }
    }


    private void getReferInfo(View_FindMatter item, ref List<ReportNewMatterRecord> resultList)
    {
        if (item.refererId.HasValue)
        {
            ReportNewMatterRecord temp = new ReportNewMatterRecord();
            var findReferer = masterI.getReferer(item.refererId.Value);

            temp.clientName = item.clientName;
            temp.incomimgAgent = item.refererName;
            temp.outgoingAgent = item.agentName;
            temp.subject = item.matterSubject;
            temp.address = String.Format("{0} {1}", findReferer.billingAddressFirst, findReferer.billingAddressSecond);
            temp.country = findReferer.countryId.HasValue ? findReferer.Country.countryName : "";
            temp.feeEarner = mI.getFeeEarnerAndHandlingColleagueByMatterId(item.id, EnumFeeEarnerAndHandlingColleague.FeeEarner);
            temp.handingColleague = mI.getFeeEarnerAndHandlingColleagueByMatterId(item.id, EnumFeeEarnerAndHandlingColleague.HandlingColleague);
            temp.introducer = mI.getIntroducer(item.introducer);
            //temp.legalAid = item.islegalAid.Value ? "Yes" : "No";

            temp.matterNumber = item.matterNum;
            temp.jobType = Convert.ToString(item.jobTypeId);


            List<string> refererContactPersonList = new List<string>();
            List<string> refererEmailList = new List<string>();
            List<string> refererTelephoneNumberList = new List<string>();

            refererContactPersonList.Add(findReferer.contactPerson);
            refererEmailList.Add(findReferer.email);
            refererTelephoneNumberList.Add(findReferer.tel);

            if (!String.IsNullOrEmpty(findReferer.contactPerson02))
            {
                refererContactPersonList.Add(findReferer.contactPerson02);
                refererEmailList.Add(findReferer.email02);
                refererTelephoneNumberList.Add(findReferer.tel02);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson03))
            {
                refererContactPersonList.Add(findReferer.contactPerson03);
                refererEmailList.Add(findReferer.email03);
                refererTelephoneNumberList.Add(findReferer.tel03);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson04))
            {
                refererContactPersonList.Add(findReferer.contactPerson04);
                refererEmailList.Add(findReferer.email04);
                refererTelephoneNumberList.Add(findReferer.tel04);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson05))
            {
                refererContactPersonList.Add(findReferer.contactPerson05);
                refererEmailList.Add(findReferer.email05);
                refererTelephoneNumberList.Add(findReferer.tel05);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson06))
            {
                refererContactPersonList.Add(findReferer.contactPerson06);
                refererEmailList.Add(findReferer.email06);
                refererTelephoneNumberList.Add(findReferer.tel06);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson07))
            {
                refererContactPersonList.Add(findReferer.contactPerson07);
                refererEmailList.Add(findReferer.email07);
                refererTelephoneNumberList.Add(findReferer.tel07);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson08))
            {
                refererContactPersonList.Add(findReferer.contactPerson08);
                refererEmailList.Add(findReferer.email08);
                refererTelephoneNumberList.Add(findReferer.tel08);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson09))
            {
                refererContactPersonList.Add(findReferer.contactPerson09);
                refererEmailList.Add(findReferer.email09);
                refererTelephoneNumberList.Add(findReferer.tel09);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson10))
            {
                refererContactPersonList.Add(findReferer.contactPerson10);
                refererEmailList.Add(findReferer.email10);
                refererTelephoneNumberList.Add(findReferer.tel10);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson11))
            {
                refererContactPersonList.Add(findReferer.contactPerson11);
                refererEmailList.Add(findReferer.email11);
                refererTelephoneNumberList.Add(findReferer.tel11);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson12))
            {
                refererContactPersonList.Add(findReferer.contactPerson12);
                refererEmailList.Add(findReferer.email12);
                refererTelephoneNumberList.Add(findReferer.tel12);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson13))
            {
                refererContactPersonList.Add(findReferer.contactPerson13);
                refererEmailList.Add(findReferer.email13);
                refererTelephoneNumberList.Add(findReferer.tel13);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson14))
            {
                refererContactPersonList.Add(findReferer.contactPerson14);
                refererEmailList.Add(findReferer.email14);
                refererTelephoneNumberList.Add(findReferer.tel14);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson15))
            {
                refererContactPersonList.Add(findReferer.contactPerson15);
                refererEmailList.Add(findReferer.email15);
                refererTelephoneNumberList.Add(findReferer.tel15);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson16))
            {
                refererContactPersonList.Add(findReferer.contactPerson16);
                refererEmailList.Add(findReferer.email16);
                refererTelephoneNumberList.Add(findReferer.tel16);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson17))
            {
                refererContactPersonList.Add(findReferer.contactPerson17);
                refererEmailList.Add(findReferer.email17);
                refererTelephoneNumberList.Add(findReferer.tel17);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson18))
            {
                refererContactPersonList.Add(findReferer.contactPerson18);
                refererEmailList.Add(findReferer.email18);
                refererTelephoneNumberList.Add(findReferer.tel18);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson19))
            {
                refererContactPersonList.Add(findReferer.contactPerson19);
                refererEmailList.Add(findReferer.email19);
                refererTelephoneNumberList.Add(findReferer.tel19);
            }
            if (!String.IsNullOrEmpty(findReferer.contactPerson20))
            {
                refererContactPersonList.Add(findReferer.contactPerson20);
                refererEmailList.Add(findReferer.email20);
                refererTelephoneNumberList.Add(findReferer.tel20);
            }


            temp.contactPerson = String.Join(", ", refererContactPersonList.ToArray());
            temp.email = String.Join(", ", refererEmailList.ToArray());
            temp.telephoneNumber = String.Join(", ", refererTelephoneNumberList.ToArray());

            temp.faxNumber = findReferer.fax;
            temp.fileOpenDay = item.fileOpenDate.HasValue ? DateTimeHelper.convertDateTimeToString(item.fileOpenDate.Value) : "";
            temp.excelRecordNum = "Record for New File (Instructor Sheet)";

            resultList.Add(temp);
        }
    }
}