using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using System.Data;
using RBJLLawFirmDBModel;

public partial class Report_ExportData : CultureEnabledPage
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
    double totalTimeSpent;
    double totalFixedCost;







    #endregion

    #region client constants


    const string ClientName = "Client Name";
    const string accountGroup = "Account Group";
    const string ClientNum = "Client Num";
    //const string ClientCountryId = "Client Country";
    const string ClientbillingAddressFirst = "Client Billing Address First";
    const string ClientbillingAddressSecond = "Client Billing Address Second";
    const string ClientcorrespondingAddress1First = "Client Corresponding Address1 First";
    const string ClientcorrespondingAddress1Second = "Client Corresponding Address1 Second";
    const string ClientcorrespondingAddress2First = "Client Corresponding Address2 First";
    const string ClientcorrespondingAddress2Second = "Client Corresponding Address2 Second";
    const string ClientFax = "Client Fax";
    const string ClientcontactPerson = "Client Contact Person";
    const string Clienttel = "Client Tel";
    const string Clientemail = "Client Email";
    const string ClientcontactPerson02 = "Client Contact Person02";
    const string Clienttel02 = "Client Tel02";
    const string Clientemail02 = "Client Email02";
    const string ClientcontactPerson03 = "Client Contact Person03";
    const string Clienttel03 = "Client Tel03";
    const string Clientemail03 = "Client Email03";
    const string ClientcontactPerson04 = "Client Contact Person04";
    const string Clienttel04 = "Client Tel04";
    const string Clientemail04 = "Client Email04";
    const string ClientcontactPerson05 = "Client Contact Person05";
    const string Clienttel05 = "Client Tel05";
    const string Clientemail05 = "Client Email05";
    const string ClientcontactPerson06 = "Client Contact Person06";
    const string Clienttel06 = "Client Tel06";
    const string Clientemail06 = "Client Email06";
    const string ClientcontactPerson07 = "Client Contact Person07";
    const string Clienttel07 = "Client Tel07";
    const string Clientemail07 = "Client Email07";
    const string ClientcontactPerson08 = "Client Contact Person08";
    const string Clienttel08 = "Client Tel08";
    const string Clientemail08 = "Client Email08";
    const string ClientcontactPerson09 = "Client Contact Person09";
    const string Clienttel09 = "Client Tel09";
    const string Clientemail09 = "Client Email09";
    const string ClientcontactPerson10 = "Client Contact Person10";
    const string Clienttel10 = "Client Tel10";
    const string Clientemail10 = "Client Email10";
    const string ClientcontactPerson11 = "Client Contact Person11";
    const string Clienttel11 = "Client Tel11";
    const string Clientemail11 = "Client Email11";
    const string ClientcontactPerson12 = "Client Contact Person12";
    const string Clienttel12 = "Client Tel12";
    const string Clientemail12 = "Client Email12";
    const string ClientcontactPerson13 = "Client Contact Person13";
    const string Clienttel13 = "Client Tel13";
    const string Clientemail13 = "Client Email13";
    const string ClientcontactPerson14 = "Client Contact Person14";
    const string Clienttel14 = "Client Tel14";
    const string Clientemail14 = "Client Email14";
    const string ClientcontactPerson15 = "Client Contact Person15";
    const string Clienttel15 = "Client Tel15";
    const string Clientemail15 = "Client Email15";
    const string ClientcontactPerson16 = "Client Contact Person16";
    const string Clienttel16 = "Client Tel16";
    const string Clientemail16 = "Client Email16";
    const string ClientcontactPerson17 = "Client Contact Person17";
    const string Clienttel17 = "Client Tel17";
    const string Clientemail17 = "Client Email17";
    const string ClientcontactPerson18 = "Client Contact Person18";
    const string Clienttel18 = "Client Tel18";
    const string Clientemail18 = "Client Email18";
    const string ClientcontactPerson19 = "Client Contact Person19";
    const string ClientTel19 = "Client Tel19";
    const string ClientEmail19 = "Client Email19";
    const string ClientContactPerson20 = "Client Contact Person20";
    const string ClientTel20 = "Client Tel20";
    const string ClientEmail20 = "Client Email20";
    const string ClientBillingEmail = "Client Billing Email";
    const string ClientDiscount = "Client Discount";
    const string ClientRemarks = "Client Remarks";

    #endregion

    #region refererConstants

    const string RefererName = "Instructor Name";
    const string RefererNum = "Instructor Num";
    //const string RefererCountryId = "Instructor Country";
    const string RefererbillingAddressFirst = "Instructor Billing Address First";
    const string RefererbillingAddressSecond = "Instructor Billing Address Second";
    const string ReferercorrespondingAddress1First = "Instructor Corresponding Address1 First";
    const string ReferercorrespondingAddress1Second = "Instructor Corresponding Address1 Second";
    const string ReferercorrespondingAddress2First = "Instructor Corresponding Address2 First";
    const string ReferercorrespondingAddress2Second = "Instructor Corresponding Address2 Second";
    const string RefererFax = "Instructor Fax";
    const string ReferercontactPerson = "Instructor Contact Person";
    const string Referertel = "Instructor Tel";
    const string Refereremail = "Instructor Email";
    const string ReferercontactPerson02 = "Instructor Contact Person02";
    const string Referertel02 = "Instructor Tel02";
    const string Refereremail02 = "Instructor Email02";
    const string ReferercontactPerson03 = "Instructor Contact Person03";
    const string Referertel03 = "Instructor Tel03";
    const string Refereremail03 = "Instructor Email03";
    const string ReferercontactPerson04 = "Instructor Contact Person04";
    const string Referertel04 = "Instructor Tel04";
    const string Refereremail04 = "Instructor Email04";
    const string ReferercontactPerson05 = "Instructor Contact Person05";
    const string Referertel05 = "Instructor Tel05";
    const string Refereremail05 = "Instructor Email05";
    const string ReferercontactPerson06 = "Instructor Contact Person06";
    const string Referertel06 = "Instructor Tel06";
    const string Refereremail06 = "Instructor Email06";
    const string ReferercontactPerson07 = "Instructor Contact Person07";
    const string Referertel07 = "Instructor Tel07";
    const string Refereremail07 = "Instructor Email07";
    const string ReferercontactPerson08 = "Instructor Contact Person08";
    const string Referertel08 = "Instructor Tel08";
    const string Refereremail08 = "Instructor Email08";
    const string ReferercontactPerson09 = "Instructor Contact Person09";
    const string Referertel09 = "Instructor Tel09";
    const string Refereremail09 = "Instructor Email09";
    const string ReferercontactPerson10 = "Instructor Contact Person10";
    const string Referertel10 = "Instructor Tel10";
    const string Refereremail10 = "Instructor Email10";
    const string ReferercontactPerson11 = "Instructor Contact Person11";
    const string Referertel11 = "Instructor Tel11";
    const string Refereremail11 = "Instructor Email11";
    const string ReferercontactPerson12 = "Instructor Contact Person12";
    const string Referertel12 = "Instructor Tel12";
    const string Refereremail12 = "Instructor Email12";
    const string ReferercontactPerson13 = "Instructor Contact Person13";
    const string Referertel13 = "Instructor Tel13";
    const string Refereremail13 = "Instructor Email13";
    const string ReferercontactPerson14 = "Instructor Contact Person14";
    const string Referertel14 = "Instructor Tel14";
    const string Refereremail14 = "Instructor Email14";
    const string ReferercontactPerson15 = "Instructor Contact Person15";
    const string Referertel15 = "Instructor Tel15";
    const string Refereremail15 = "Instructor Email15";
    const string ReferercontactPerson16 = "Instructor Contact Person16";
    const string Referertel16 = "Instructor Tel16";
    const string Refereremail16 = "Instructor Email16";
    const string ReferercontactPerson17 = "Instructor Contact Person17";
    const string Referertel17 = "Instructor Tel17";
    const string Refereremail17 = "Instructor Email17";
    const string ReferercontactPerson18 = "Instructor Contact Person18";
    const string Referertel18 = "Instructor Tel18";
    const string Refereremail18 = "Instructor Email18";
    const string ReferercontactPerson19 = "Instructor Contact Person19";
    const string RefererTel19 = "Instructor Tel19";
    const string RefererEmail19 = "Instructor Email19";
    const string RefererContactPerson20 = "Instructor Contact Person20";
    const string RefererTel20 = "Instructor Tel20";
    const string RefererEmail20 = "Instructor Email20";
    const string RefererRemarks = "Instructor Remarks";

    #endregion

    #region outgoing agent

    const string outgoingAgentagentName = "Outgoing Agent Name";
    const string outgoingAgentagentNum = "Outgoing Agent Num";
    //const string outgoingAgentcountryId = "Outgoing Agent Country";
    const string outgoingAgentcorrespondingAddress1First = "Outgoing Agent Corresponding Address1 First";
    const string outgoingAgentcorrespondingAddress1Second = "Outgoing Agent Corresponding Address1 Second";
    const string outgoingAgentcorrespondingAddress2First = "Outgoing Agent Corresponding Address2 First";
    const string outgoingAgentcorrespondingAddress2Second = "Outgoing Agent Corresponding Address2 Second";
    const string outgoingAgentcorrespondingAddress3First = "Outgoing Agent Corresponding Address3 First";
    const string outgoingAgentcorrespondingAddress3Second = "Outgoing Agent Corresponding Address3 Second";
    const string outgoingAgentcontactPerson = "Outgoing Agent ContactPerson";
    const string outgoingAgenttel = "Outgoing Agent Tel";
    const string outgoingAgentfax = "Outgoing Agent Fax";
    const string outgoingAgentemail = "Outgoing Agent Email";


    #endregion

    ReportInfo rI = new ReportInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadDynamicGrid();
        }
    }


    private void loadDynamicGrid()
    {
        var getDebitNoteId = Request[QueryStringConst.debitNoteId];

        var getType = Request[QueryStringConst.dType];
        var isShow1 = Request[QueryStringConst.isShow1];
        var isShow2 = Request[QueryStringConst.isShow2];

        var date = Request[QueryStringConst.date];
        var dateTo = Request[QueryStringConst.dateTo];

        bool checking = false;


        DataTable dt = new DataTable();

        if (getType == "C")
        {
            checking = true;
            CreateClientDataTable(ref dt);
            if (!String.IsNullOrEmpty(isShow1))
            {
                CreateRefererDataTable(ref dt);
            }
            if (!String.IsNullOrEmpty(isShow2))
            {
                CreateOutgoingAgentDataTable(ref dt);
            }

            var getClinet = rI.getClientInfo;

            if (date != null && dateTo != null)
            {
                rI.clientInfoCreateDate(ref getClinet, date, dateTo);
            }

            foreach (var item in getClinet)
            {
                DataRow drow = dt.NewRow();
                addRowClinet(ref drow, item);

                if (!String.IsNullOrEmpty(isShow1))
                {
                    if (item.referertId.HasValue)
                    {
                        var getReferer = rI.findTarReferer(item.referertId.Value);
                        addRowReferer(ref drow, getReferer);
                    }
                }
                if (!String.IsNullOrEmpty(isShow2))
                {
                    if (item.referertId.HasValue)
                    {
                        var getReferer = rI.findTarReferer(item.referertId.Value);
                        if (getReferer.outgoingAgentId.HasValue)
                        {
                            var getOutGoingAgent = rI.findTarOutgoingAgent(getReferer.outgoingAgentId.Value);
                            addRowOutgoingAgent(ref drow, getOutGoingAgent);
                        }
                    }
                }
                dt.Rows.Add(drow);
            }


        }
        else if (getType == "R")
        {
            checking = true;
            CreateRefererDataTable(ref dt);
            if (!String.IsNullOrEmpty(isShow1))
            {
                CreateClientDataTable(ref dt);
            }
            if (!String.IsNullOrEmpty(isShow2))
            {
                CreateOutgoingAgentDataTable(ref dt);
            }

            var getReferer = rI.getRefererInfo;

            if (date != null && dateTo != null)
            {
                rI.refererInfoCreateDate(ref getReferer, date, dateTo);
            }


            foreach (var item in getReferer)
            {

                if (!String.IsNullOrEmpty(isShow1))
                {
                    var getClientList = item.Clients;

                    if (getClientList.Count > 0)
                    {
                        foreach (var clientTar in getClientList)
                        {
                            DataRow drow = dt.NewRow();
                            addRowReferer(ref drow, item);
                            addRowClinet(ref drow, clientTar);
                            if (!String.IsNullOrEmpty(isShow2) && item.outgoingAgentId.HasValue)
                            {
                                var getOutgoingAgentTar = rI.findTarOutgoingAgent(item.outgoingAgentId.Value);
                                addRowOutgoingAgent(ref drow, getOutgoingAgentTar);
                            }
                            dt.Rows.Add(drow);
                        }
                    }
                    else
                    {
                        DataRow drow = dt.NewRow();
                        addRowReferer(ref drow, item);
                        dt.Rows.Add(drow);
                    }

                }
                else
                {
                    DataRow drow = dt.NewRow();
                    addRowReferer(ref drow, item);
                    if (!String.IsNullOrEmpty(isShow2) && item.outgoingAgentId.HasValue)
                    {
                        var getOutgoingAgentTar = rI.findTarOutgoingAgent(item.outgoingAgentId.Value);
                        addRowOutgoingAgent(ref drow, getOutgoingAgentTar);
                    }
                    dt.Rows.Add(drow);
                }
            }

        }
        else if (getType == "O")
        {
            checking = true;
            CreateOutgoingAgentDataTable(ref dt);
            if (!String.IsNullOrEmpty(isShow1))
            {
                CreateClientDataTable(ref dt);
            }
            if (!String.IsNullOrEmpty(isShow2))
            {
                CreateRefererDataTable(ref dt);
            }

            var getGoingagent = rI.getOutgoingAgentInfo;

            if (date != null && dateTo != null)
            {
                rI.outgoingAgentInfoCreateDate(ref getGoingagent, date, dateTo);
            }

            foreach (var item in getGoingagent)
            {
                if (String.IsNullOrEmpty(isShow1) && String.IsNullOrEmpty(isShow2))
                {
                    DataRow drow = dt.NewRow();
                    addRowOutgoingAgent(ref drow, item);
                    dt.Rows.Add(drow);
                }

                else if (String.IsNullOrEmpty(isShow1) && !String.IsNullOrEmpty(isShow2))
                {
                    var getRefererList = item.Referers;

                    if (getRefererList.Count > 0)
                    {
                        foreach (var refererTar in getRefererList)
                        {
                            DataRow drow = dt.NewRow();
                            addRowOutgoingAgent(ref drow, item);
                            addRowReferer(ref drow, refererTar);
                            dt.Rows.Add(drow);
                        }
                    }
                    else
                    {
                        DataRow drow = dt.NewRow();
                        addRowOutgoingAgent(ref drow, item);
                        dt.Rows.Add(drow);
                    }
                }


                else if (!String.IsNullOrEmpty(isShow1) && String.IsNullOrEmpty(isShow2))
                {
                    var getRefererList = item.Referers;

                    if (getRefererList.Count > 0)
                    {
                        foreach (var refererTar in getRefererList)
                        {
                            var getClientList = refererTar.Clients;

                            if (getClientList.Count > 0)
                            {
                                foreach (var clientTar in getClientList)
                                {
                                    DataRow drow = dt.NewRow();
                                    addRowOutgoingAgent(ref drow, item);
                                    addRowClinet(ref drow, clientTar);
                                    dt.Rows.Add(drow);
                                }
                            }
                            else
                            {
                                DataRow drow = dt.NewRow();
                                addRowOutgoingAgent(ref drow, item);
                                dt.Rows.Add(drow);
                            }
                        }
                    }
                    else
                    {
                        DataRow drow = dt.NewRow();
                        addRowOutgoingAgent(ref drow, item);
                        dt.Rows.Add(drow);
                    }
                }

                else if (!String.IsNullOrEmpty(isShow1) && !String.IsNullOrEmpty(isShow2))
                {
                    var getRefererList = item.Referers;

                    if (getRefererList.Count > 0)
                    {
                        foreach (var refererTar in getRefererList)
                        {
                            var getClientList = refererTar.Clients;

                            if (getClientList.Count > 0)
                            {
                                foreach (var clientTar in getClientList)
                                {
                                    DataRow drow = dt.NewRow();
                                    addRowOutgoingAgent(ref drow, item);
                                    addRowClinet(ref drow, clientTar);
                                    addRowReferer(ref drow, refererTar);
                                    dt.Rows.Add(drow);
                                }
                            }
                            else
                            {
                                DataRow drow = dt.NewRow();
                                addRowOutgoingAgent(ref drow, item);
                                addRowReferer(ref drow, refererTar);
                                dt.Rows.Add(drow);
                            }
                        }
                    }
                    else
                    {
                        DataRow drow = dt.NewRow();
                        addRowOutgoingAgent(ref drow, item);
                        dt.Rows.Add(drow);
                    }
                }

            }
        }

        if (getType != null && checking)
        {
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



    private void printExcel()
    {
        Response.ClearContent();
        Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
        string excelFileName = String.Format("data__{0:yyyyMMddHHmmss}.xls", DateTime.Now);
        Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
        Response.ContentType = "application/excel";
        GridView1.AllowPaging = false;
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
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



    private void CreateClientDataTable(ref DataTable dt)
    {
        createDataTableColumn(ref dt, ClientName);
        createDataTableColumn(ref dt, accountGroup);
        createDataTableColumn(ref dt, ClientNum);
        createDataTableColumn(ref dt, ClientbillingAddressFirst);
        createDataTableColumn(ref dt, ClientbillingAddressSecond);
        createDataTableColumn(ref dt, ClientcorrespondingAddress1First);
        createDataTableColumn(ref dt, ClientcorrespondingAddress1Second);
        createDataTableColumn(ref dt, ClientcorrespondingAddress2First);
        createDataTableColumn(ref dt, ClientcorrespondingAddress2Second);
        createDataTableColumn(ref dt, ClientFax);
        createDataTableColumn(ref dt, ClientcontactPerson);
        createDataTableColumn(ref dt, Clienttel);
        createDataTableColumn(ref dt, Clientemail);
        createDataTableColumn(ref dt, ClientcontactPerson02);
        createDataTableColumn(ref dt, Clienttel02);
        createDataTableColumn(ref dt, Clientemail02);
        createDataTableColumn(ref dt, ClientcontactPerson03);
        createDataTableColumn(ref dt, Clienttel03);
        createDataTableColumn(ref dt, Clientemail03);
        createDataTableColumn(ref dt, ClientcontactPerson04);
        createDataTableColumn(ref dt, Clienttel04);
        createDataTableColumn(ref dt, Clientemail04);
        createDataTableColumn(ref dt, ClientcontactPerson05);
        createDataTableColumn(ref dt, Clienttel05);
        createDataTableColumn(ref dt, Clientemail05);
        createDataTableColumn(ref dt, ClientcontactPerson06);
        createDataTableColumn(ref dt, Clienttel06);
        createDataTableColumn(ref dt, Clientemail06);
        createDataTableColumn(ref dt, ClientcontactPerson07);
        createDataTableColumn(ref dt, Clienttel07);
        createDataTableColumn(ref dt, Clientemail07);
        createDataTableColumn(ref dt, ClientcontactPerson08);
        createDataTableColumn(ref dt, Clienttel08);
        createDataTableColumn(ref dt, Clientemail08);
        createDataTableColumn(ref dt, ClientcontactPerson09);
        createDataTableColumn(ref dt, Clienttel09);
        createDataTableColumn(ref dt, Clientemail09);
        createDataTableColumn(ref dt, ClientcontactPerson10);
        createDataTableColumn(ref dt, Clienttel10);
        createDataTableColumn(ref dt, Clientemail10);
        createDataTableColumn(ref dt, ClientcontactPerson11);
        createDataTableColumn(ref dt, Clienttel11);
        createDataTableColumn(ref dt, Clientemail11);
        createDataTableColumn(ref dt, ClientcontactPerson12);
        createDataTableColumn(ref dt, Clienttel12);
        createDataTableColumn(ref dt, Clientemail12);
        createDataTableColumn(ref dt, ClientcontactPerson13);
        createDataTableColumn(ref dt, Clienttel13);
        createDataTableColumn(ref dt, Clientemail13);
        createDataTableColumn(ref dt, ClientcontactPerson14);
        createDataTableColumn(ref dt, Clienttel14);
        createDataTableColumn(ref dt, Clientemail14);
        createDataTableColumn(ref dt, ClientcontactPerson15);
        createDataTableColumn(ref dt, Clienttel15);
        createDataTableColumn(ref dt, Clientemail15);
        createDataTableColumn(ref dt, ClientcontactPerson16);
        createDataTableColumn(ref dt, Clienttel16);
        createDataTableColumn(ref dt, Clientemail16);
        createDataTableColumn(ref dt, ClientcontactPerson17);
        createDataTableColumn(ref dt, Clienttel17);
        createDataTableColumn(ref dt, Clientemail17);
        createDataTableColumn(ref dt, ClientcontactPerson18);
        createDataTableColumn(ref dt, Clienttel18);
        createDataTableColumn(ref dt, Clientemail18);
        createDataTableColumn(ref dt, ClientcontactPerson19);
        createDataTableColumn(ref dt, ClientTel19);
        createDataTableColumn(ref dt, ClientEmail19);
        createDataTableColumn(ref dt, ClientContactPerson20);
        createDataTableColumn(ref dt, ClientTel20);
        createDataTableColumn(ref dt, ClientEmail20);
        createDataTableColumn(ref dt, ClientBillingEmail);
        createDataTableColumn(ref dt, ClientDiscount);
        createDataTableColumn(ref dt, ClientRemarks);
    }

    private void CreateRefererDataTable(ref DataTable dt)
    {
        createDataTableColumn(ref dt, RefererName);
        createDataTableColumn(ref dt, RefererNum);
        createDataTableColumn(ref dt, RefererbillingAddressFirst);
        createDataTableColumn(ref dt, RefererbillingAddressSecond);
        createDataTableColumn(ref dt, ReferercorrespondingAddress1First);
        createDataTableColumn(ref dt, ReferercorrespondingAddress1Second);
        createDataTableColumn(ref dt, ReferercorrespondingAddress2First);
        createDataTableColumn(ref dt, ReferercorrespondingAddress2Second);
        createDataTableColumn(ref dt, RefererFax);
        createDataTableColumn(ref dt, ReferercontactPerson);
        createDataTableColumn(ref dt, Referertel);
        createDataTableColumn(ref dt, Refereremail);
        createDataTableColumn(ref dt, ReferercontactPerson02);
        createDataTableColumn(ref dt, Referertel02);
        createDataTableColumn(ref dt, Refereremail02);
        createDataTableColumn(ref dt, ReferercontactPerson03);
        createDataTableColumn(ref dt, Referertel03);
        createDataTableColumn(ref dt, Refereremail03);
        createDataTableColumn(ref dt, ReferercontactPerson04);
        createDataTableColumn(ref dt, Referertel04);
        createDataTableColumn(ref dt, Refereremail04);
        createDataTableColumn(ref dt, ReferercontactPerson05);
        createDataTableColumn(ref dt, Referertel05);
        createDataTableColumn(ref dt, Refereremail05);
        createDataTableColumn(ref dt, ReferercontactPerson06);
        createDataTableColumn(ref dt, Referertel06);
        createDataTableColumn(ref dt, Refereremail06);
        createDataTableColumn(ref dt, ReferercontactPerson07);
        createDataTableColumn(ref dt, Referertel07);
        createDataTableColumn(ref dt, Refereremail07);
        createDataTableColumn(ref dt, ReferercontactPerson08);
        createDataTableColumn(ref dt, Referertel08);
        createDataTableColumn(ref dt, Refereremail08);
        createDataTableColumn(ref dt, ReferercontactPerson09);
        createDataTableColumn(ref dt, Referertel09);
        createDataTableColumn(ref dt, Refereremail09);
        createDataTableColumn(ref dt, ReferercontactPerson10);
        createDataTableColumn(ref dt, Referertel10);
        createDataTableColumn(ref dt, Refereremail10);
        createDataTableColumn(ref dt, ReferercontactPerson11);
        createDataTableColumn(ref dt, Referertel11);
        createDataTableColumn(ref dt, Refereremail11);
        createDataTableColumn(ref dt, ReferercontactPerson12);
        createDataTableColumn(ref dt, Referertel12);
        createDataTableColumn(ref dt, Refereremail12);
        createDataTableColumn(ref dt, ReferercontactPerson13);
        createDataTableColumn(ref dt, Referertel13);
        createDataTableColumn(ref dt, Refereremail13);
        createDataTableColumn(ref dt, ReferercontactPerson14);
        createDataTableColumn(ref dt, Referertel14);
        createDataTableColumn(ref dt, Refereremail14);
        createDataTableColumn(ref dt, ReferercontactPerson15);
        createDataTableColumn(ref dt, Referertel15);
        createDataTableColumn(ref dt, Refereremail15);
        createDataTableColumn(ref dt, ReferercontactPerson16);
        createDataTableColumn(ref dt, Referertel16);
        createDataTableColumn(ref dt, Refereremail16);
        createDataTableColumn(ref dt, ReferercontactPerson17);
        createDataTableColumn(ref dt, Referertel17);
        createDataTableColumn(ref dt, Refereremail17);
        createDataTableColumn(ref dt, ReferercontactPerson18);
        createDataTableColumn(ref dt, Referertel18);
        createDataTableColumn(ref dt, Refereremail18);
        createDataTableColumn(ref dt, ReferercontactPerson19);
        createDataTableColumn(ref dt, RefererTel19);
        createDataTableColumn(ref dt, RefererEmail19);
        createDataTableColumn(ref dt, RefererContactPerson20);
        createDataTableColumn(ref dt, RefererTel20);
        createDataTableColumn(ref dt, RefererEmail20);
        createDataTableColumn(ref dt, RefererRemarks);
    }

    private void CreateOutgoingAgentDataTable(ref DataTable dt)
    {
        createDataTableColumn(ref dt, outgoingAgentagentName);
        createDataTableColumn(ref dt, outgoingAgentagentNum);
        createDataTableColumn(ref dt, outgoingAgentcorrespondingAddress1First);
        createDataTableColumn(ref dt, outgoingAgentcorrespondingAddress1Second);
        createDataTableColumn(ref dt, outgoingAgentcorrespondingAddress2First);
        createDataTableColumn(ref dt, outgoingAgentcorrespondingAddress2Second);
        createDataTableColumn(ref dt, outgoingAgentcorrespondingAddress3First);
        createDataTableColumn(ref dt, outgoingAgentcorrespondingAddress3Second);
        createDataTableColumn(ref dt, outgoingAgentcontactPerson);
        createDataTableColumn(ref dt, outgoingAgenttel);
        createDataTableColumn(ref dt, outgoingAgentfax);
        createDataTableColumn(ref dt, outgoingAgentemail);
    }


    private void createDataTableColumn(ref DataTable dt, string columnName)
    {
        DataColumn dcol = new DataColumn(columnName, typeof(System.String));
        dt.Columns.Add(dcol);
    }




    private void addRowClinet(ref DataRow drow, Client item)
    {
        drow[ClientName] = item.clientName;
        drow[accountGroup] = item.accountGroup;
        drow[ClientNum] = item.clientNum;
        drow[ClientbillingAddressFirst] = item.billingAddressFirst;
        drow[ClientbillingAddressSecond] = item.billingAddressSecond;
        drow[ClientcorrespondingAddress1First] = item.correspondingAddress1First;
        drow[ClientcorrespondingAddress1Second] = item.correspondingAddress1Second;
        drow[ClientcorrespondingAddress2First] = item.correspondingAddress2First;
        drow[ClientcorrespondingAddress2Second] = item.correspondingAddress2Second;
        drow[ClientFax] = item.fax;
        drow[ClientcontactPerson] = item.contactPerson;
        drow[Clienttel] = item.tel;
        drow[Clientemail] = item.email;
        drow[ClientcontactPerson02] = item.contactPerson02;
        drow[Clienttel02] = item.tel02;
        drow[Clientemail02] = item.email02;
        drow[ClientcontactPerson03] = item.contactPerson03;
        drow[Clienttel03] = item.tel03;
        drow[Clientemail03] = item.email03;
        drow[ClientcontactPerson04] = item.contactPerson04;
        drow[Clienttel04] = item.tel04;
        drow[Clientemail04] = item.email04;
        drow[ClientcontactPerson05] = item.contactPerson05;
        drow[Clienttel05] = item.tel05;
        drow[Clientemail05] = item.email05;
        drow[ClientcontactPerson06] = item.contactPerson06;
        drow[Clienttel06] = item.tel06;
        drow[Clientemail06] = item.email06;
        drow[ClientcontactPerson07] = item.contactPerson07;
        drow[Clienttel07] = item.tel07;
        drow[Clientemail07] = item.email07;
        drow[ClientcontactPerson08] = item.contactPerson08;
        drow[Clienttel08] = item.tel08;
        drow[Clientemail08] = item.email08;
        drow[ClientcontactPerson09] = item.contactPerson09;
        drow[Clienttel09] = item.tel09;
        drow[Clientemail09] = item.email09;
        drow[ClientcontactPerson10] = item.contactPerson10;
        drow[Clienttel10] = item.tel10;
        drow[Clientemail10] = item.email10;
        drow[ClientcontactPerson11] = item.contactPerson11;
        drow[Clienttel11] = item.tel11;
        drow[Clientemail11] = item.email11;
        drow[ClientcontactPerson12] = item.contactPerson12;
        drow[Clienttel12] = item.tel12;
        drow[Clientemail12] = item.email12;
        drow[ClientcontactPerson13] = item.contactPerson13;
        drow[Clienttel13] = item.tel13;
        drow[Clientemail13] = item.email13;
        drow[ClientcontactPerson14] = item.contactPerson14;
        drow[Clienttel14] = item.tel14;
        drow[Clientemail14] = item.email14;
        drow[ClientcontactPerson15] = item.contactPerson15;
        drow[Clienttel15] = item.tel15;
        drow[Clientemail15] = item.email15;
        drow[ClientcontactPerson16] = item.contactPerson16;
        drow[Clienttel16] = item.tel16;
        drow[Clientemail16] = item.email16;
        drow[ClientcontactPerson17] = item.contactPerson17;
        drow[Clienttel17] = item.tel17;
        drow[Clientemail17] = item.email17;
        drow[ClientcontactPerson18] = item.contactPerson18;
        drow[Clienttel18] = item.tel18;
        drow[Clientemail18] = item.email18;
        drow[ClientcontactPerson19] = item.contactPerson19;
        drow[ClientTel19] = item.tel19;
        drow[ClientEmail19] = item.email19;
        drow[ClientContactPerson20] = item.contactPerson20;
        drow[ClientTel20] = item.tel20;
        drow[ClientEmail20] = item.email20;
        drow[ClientBillingEmail] = item.billingEmail;
        drow[ClientDiscount] = item.discount;
        drow[ClientRemarks] = item.remarks;

    }

    private void addRowReferer(ref DataRow drow, Referer item)
    {
        drow[RefererName] = item.refererName;
        drow[RefererNum] = item.refererNum;
        drow[RefererbillingAddressFirst] = item.billingAddressFirst;
        drow[RefererbillingAddressSecond] = item.billingAddressSecond;
        drow[ReferercorrespondingAddress1First] = item.correspondingAddress1First;
        drow[ReferercorrespondingAddress1Second] = item.correspondingAddress1Second;
        drow[ReferercorrespondingAddress2First] = item.correspondingAddress2First;
        drow[ReferercorrespondingAddress2Second] = item.correspondingAddress2Second;
        drow[RefererFax] = item.fax;
        drow[ReferercontactPerson] = item.contactPerson;
        drow[Referertel] = item.tel;
        drow[Refereremail] = item.email;
        drow[ReferercontactPerson02] = item.contactPerson02;
        drow[Referertel02] = item.tel02;
        drow[Refereremail02] = item.email02;
        drow[ReferercontactPerson03] = item.contactPerson03;
        drow[Referertel03] = item.tel03;
        drow[Refereremail03] = item.email03;
        drow[ReferercontactPerson04] = item.contactPerson04;
        drow[Referertel04] = item.tel04;
        drow[Refereremail04] = item.email04;
        drow[ReferercontactPerson05] = item.contactPerson05;
        drow[Referertel05] = item.tel05;
        drow[Refereremail05] = item.email05;
        drow[ReferercontactPerson06] = item.contactPerson06;
        drow[Referertel06] = item.tel06;
        drow[Refereremail06] = item.email06;
        drow[ReferercontactPerson07] = item.contactPerson07;
        drow[Referertel07] = item.tel07;
        drow[Refereremail07] = item.email07;
        drow[ReferercontactPerson08] = item.contactPerson08;
        drow[Referertel08] = item.tel08;
        drow[Refereremail08] = item.email08;
        drow[ReferercontactPerson09] = item.contactPerson09;
        drow[Referertel09] = item.tel09;
        drow[Refereremail09] = item.email09;
        drow[ReferercontactPerson10] = item.contactPerson10;
        drow[Referertel10] = item.tel10;
        drow[Refereremail10] = item.email10;
        drow[ReferercontactPerson11] = item.contactPerson11;
        drow[Referertel11] = item.tel11;
        drow[Refereremail11] = item.email11;
        drow[ReferercontactPerson12] = item.contactPerson12;
        drow[Referertel12] = item.tel12;
        drow[Refereremail12] = item.email12;
        drow[ReferercontactPerson13] = item.contactPerson13;
        drow[Referertel13] = item.tel13;
        drow[Refereremail13] = item.email13;
        drow[ReferercontactPerson14] = item.contactPerson14;
        drow[Referertel14] = item.tel14;
        drow[Refereremail14] = item.email14;
        drow[ReferercontactPerson15] = item.contactPerson15;
        drow[Referertel15] = item.tel15;
        drow[Refereremail15] = item.email15;
        drow[ReferercontactPerson16] = item.contactPerson16;
        drow[Referertel16] = item.tel16;
        drow[Refereremail16] = item.email16;
        drow[ReferercontactPerson17] = item.contactPerson17;
        drow[Referertel17] = item.tel17;
        drow[Refereremail17] = item.email17;
        drow[ReferercontactPerson18] = item.contactPerson18;
        drow[Referertel18] = item.tel18;
        drow[Refereremail18] = item.email18;
        drow[ReferercontactPerson19] = item.contactPerson19;
        drow[RefererTel19] = item.tel19;
        drow[RefererEmail19] = item.email19;
        drow[RefererContactPerson20] = item.contactPerson20;
        drow[RefererTel20] = item.tel20;
        drow[RefererEmail20] = item.email20;
        drow[RefererRemarks] = item.remark;

    }

    private void addRowOutgoingAgent(ref DataRow drow, OutgoingAgent item)
    {
        drow[outgoingAgentagentName] = item.agentName;
        drow[outgoingAgentagentNum] = item.agentNum;
        drow[outgoingAgentcorrespondingAddress1First] = item.correspondingAddress1First;
        drow[outgoingAgentcorrespondingAddress1Second] = item.correspondingAddress1Second;
        drow[outgoingAgentcorrespondingAddress2First] = item.correspondingAddress2First;
        drow[outgoingAgentcorrespondingAddress2Second] = item.correspondingAddress2Second;
        drow[outgoingAgentcorrespondingAddress3First] = item.correspondingAddress3First;
        drow[outgoingAgentcorrespondingAddress3Second] = item.correspondingAddress3Second;
        drow[outgoingAgentcontactPerson] = item.contactPerson;
        drow[outgoingAgenttel] = item.tel;
        drow[outgoingAgentfax] = item.fax;
        drow[outgoingAgentemail] = item.email;
    }



    public override void VerifyRenderingInServerForm(Control control)
    {
        // '處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中   
    }
}