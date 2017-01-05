using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using System.Data;

public partial class DebitNote_NewDebitNote : CultureEnabledPage
{
    MatterInfo mI = new MatterInfo();
    MaterItem masterI = new MaterItem();
    DebitNoteInfo dNI = new DebitNoteInfo();
    TimeEntryInfo tEI = new TimeEntryInfo();

    protected void Page_Load(object sender, EventArgs e)
    {

        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(1);", true);
        if (!IsPostBack)
        {
            initValue();

            CheckAutogen();
            initTab(1);

            SessionClass.uploadFileFileNameTemp1 = null;
            SessionClass.uploadFileTemp1 = null;
            SessionClass.uploadFileFileNameTemp2 = null;
            SessionClass.uploadFileTemp2 = null;
            SessionClass.uploadFileFileNameTemp3 = null;
            SessionClass.uploadFileTemp3 = null;
            SessionClass.uploadFileFileNameTemp4 = null;
            SessionClass.uploadFileTemp4 = null;
            SessionClass.uploadFileFileNameTemp5 = null;
            SessionClass.uploadFileTemp5 = null;

            string getDebitNoteId = Request["debitNote"];

            if (getDebitNoteId != null)
            {
                var debitNoteInfo = mI.getDebitNoteByDebitNoteId(getDebitNoteId);

                // ucTextBoxStartDate.textBoxValue
                //ucTextBoxEndDate.textBoxValue

                TextBoxIO.Text = debitNoteInfo.ioNum;
                TextRef.Text = debitNoteInfo.@ref;
                TextBoxYourRef.Text = debitNoteInfo.yourRef;
                DropDownListDebitNoteMode.SelectedIndex = Convert.ToInt32(debitNoteInfo.debitNoteType) - 1;

                //TextBoxSubject.Text = debitNoteInfo.subject;
                DropDownListCategory.SelectedValue = debitNoteInfo.category;

                if (debitNoteInfo.startDate.HasValue)
                {
                    ucTextBoxStartDate.textBoxValue = DateTimeHelper.convertDateTimeToString(debitNoteInfo.startDate.Value);
                }

                if (debitNoteInfo.endDate.HasValue)
                {
                    ucTextBoxEndDate.textBoxValue = DateTimeHelper.convertDateTimeToString(debitNoteInfo.endDate.Value);
                }

                var billToInfo = debitNoteInfo.billTo;
                var addressInfo = debitNoteInfo.address;
                var contactPersonInfo = debitNoteInfo.contactPersonList;

                bool checkingpassAddress = true;

                if (debitNoteInfo.clientId.HasValue)
                {
                    if (DropDownListAddressClientAddress.Items.FindByText(addressInfo) != null && debitNoteInfo.clientName == billToInfo)
                    {
                        DropDownListAddressClientAddress.SelectedValue = addressInfo;
                        setAddresInit(contactPersonInfo, CheckBoxListClientContactPerson);
                        stValue(CheckBoxListClientContactPerson, TextBoxClientContactPerson);

                        int checking = TextBoxClientContactPerson.Text == "" ? 0 : 1;
                        setDDLIsEnable(EnumDebitNoteBillTo.client, checking, DropDownListAddressClientAddress.SelectedIndex);
                        //checkingpassAddress = false;
                    }
                }
                if (debitNoteInfo.otherPartiesId.HasValue && checkingpassAddress)
                {
                    DropDownListOtherParties.SelectedValue = Convert.ToString(debitNoteInfo.otherPartiesId.Value);
                    DropDownListOtherParties_SelectedIndexChanged(this, new EventArgs());
                    if (DropDownListOtherPartiesAddress.Items.FindByText(addressInfo) != null && debitNoteInfo.otherPartiesName == billToInfo)
                    {
                        DropDownListOtherPartiesAddress.SelectedValue = addressInfo;
                        DropDownListOtherPartiesContactPerson.SelectedIndex = 1;

                        setDDLIsEnable(EnumDebitNoteBillTo.otherparties, DropDownListOtherPartiesContactPerson.SelectedIndex, DropDownListOtherPartiesAddress.SelectedIndex);
                        //checkingpassAddress = false;
                    }
                }
                if (debitNoteInfo.refererId.HasValue && checkingpassAddress)
                {
                    if (DropDownListRefererAddress.Items.FindByText(addressInfo) != null && debitNoteInfo.refererName == billToInfo)
                    {
                        DropDownListRefererAddress.SelectedValue = addressInfo;
                        setAddresInit(contactPersonInfo, CheckBoxListRefererContactperson);
                        stValue(CheckBoxListRefererContactperson, TextBoxRefererContactperson);

                        int checking = TextBoxRefererContactperson.Text == "" ? 0 : 1;
                        setDDLIsEnable(EnumDebitNoteBillTo.referer, DropDownListRefererAddress.SelectedIndex, checking);

                        //checkingpassAddress = false;
                    }
                }

                string debitNoteSubjectType = debitNoteInfo.SubjectType;

                try
                {
                    DropDownListSubjectType.SelectedValue = debitNoteSubjectType;
                    DropDownListSubjectType_SelectedIndexChanged(sender, e);
                }
                catch { }

                //if (debitNoteSubjectType == "1")
                //{
                //    DropDownListTypeOfWork.SelectedValue = debitNoteInfo.TTypeOfWork;
                //    DropDownListOpponent.SelectedValue = debitNoteInfo.TIsOpponent;
                //    TextBoxOpponent.Text = debitNoteInfo.TOpponentValue;
                //    DropDownListRoleType.SelectedValue = debitNoteInfo.TRoleType;
                //    TextBoxNameOfClient.Text = debitNoteInfo.TRoleTypeValue;
                //    ImageTrademarkLogo.ImageUrl = debitNoteInfo.TrademarkLogo;
                //    HiddenFieldTrademarkLogo.Value = debitNoteInfo.TrademarkLogo;
                //    TextBoxTrademarkNum.Text = debitNoteInfo.TrademarkNum;
                //    TextBoxClass.Text = debitNoteInfo.TClass;



                //}
                //else if (debitNoteSubjectType == "2")
                //{
                //    DropDownListStage.SelectedValue = debitNoteInfo.PStageValue;
                //    DropDownListRoleProprietor.SelectedValue = debitNoteInfo.PRoleProprietorApplican;
                //    TextBoxProprietorOrApplicantValue.Text = debitNoteInfo.PRoleProprietorApplicanValue;
                //    TextBoxAssignee.Text = debitNoteInfo.PAssignee;
                //    TextBoxPNTitle.Text = debitNoteInfo.PTitle;
                //    DropDownListDesignPatentNum.SelectedValue = debitNoteInfo.PDesignOrPatentNum;
                //    TextBoxDesignPatentNum.Text = debitNoteInfo.PDesignOrPatentNumValue;

                //    DropDownListNationalPhase.SelectedValue = debitNoteInfo.PNationalPhase;
                //}

                //else
                //{
                //    TextBoxSubject.Text = debitNoteInfo.subject;
                //}

                TextBoxSubRef.Text = debitNoteInfo.subRef;

                if (debitNoteInfo.depositAccount.HasValue)
                {
                    TextBoxDeposit.Text = Convert.ToString(debitNoteInfo.depositAccount.Value);
                }

                if (debitNoteInfo.isEnable.HasValue)
                {
                    CheckBoxIsShowEmail.Checked = debitNoteInfo.isEnable.Value;
                }


                //if()
                dNI.getCostAndDisbursementSession(getDebitNoteId);


                var getFileList = dNI.getAttFilePath(getDebitNoteId);

                getFileByteArr(getFileList);



                ButtonPriceCreate.Text = "Update";

                initTab(5);
                TabContainerDebitNoteCore.ActiveTabIndex = 0;
                ButtonSubmit.Visible = true;
            }
        }
    }
    protected void Page_SaveStateComplete(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string getDebitNoteId = Request["debitNote"];
            if (getDebitNoteId != null)
            {
                var debitNoteInfo = mI.getDebitNoteByDebitNoteId(getDebitNoteId);

                string debitNoteSubjectType = debitNoteInfo.SubjectType;
                if (debitNoteSubjectType == "1")
                {
                    //if (DropDownListCountry.Items.FindByText(debitNoteInfo.Country) != null)
                    //{
                    //    DropDownListCountry.SelectedValue = debitNoteInfo.Country;
                    //}
                    setSubjectT(getDebitNoteId);

                    setSubjectTCountry(getDebitNoteId);
                }
                else if (debitNoteSubjectType == "2")
                {
                    //if (DropDownListPDCountry.Items.FindByText(debitNoteInfo.Country) != null)
                    //{
                    //    DropDownListPDCountry.SelectedValue = debitNoteInfo.Country;
                    //}
                    setSubjectP(getDebitNoteId);
                    setSubjectPCountry(getDebitNoteId);
                }
                //else
                //{
                //    TextBoxSubject.Text = debitNoteInfo.subject;
                //}

                if (!String.IsNullOrEmpty(debitNoteInfo.subject))
                {
                    TextBoxSubject.Text = debitNoteInfo.subject;
                }

                if (!String.IsNullOrEmpty(debitNoteInfo.CurrencySymbol) && DropDownListCurrency.Items.FindByText(debitNoteInfo.CurrencySymbol) != null)
                {
                    //DropDownListCurrency.SelectedItem.Text = debitNoteInfo.CurrencySymbol;
                    DropDownListCurrency.SelectedIndex = DropDownListCurrency.Items.IndexOf(DropDownListCurrency.Items.FindByText(debitNoteInfo.CurrencySymbol));
                }
            }
        }
    }


    private void initTab(int initValue)
    {
        for (int i = initValue; i <= 4; i++)
        {
            setTabIsEnable(i, false);
        }
        for (int y = initValue - 1; y >= 0; y--)
        {
            setTabIsEnable(y, true);
        }
        int countIndex = initValue - 1;
        TabContainerDebitNoteCore.ActiveTabIndex = countIndex;
        setNextBtn(countIndex);
    }

    private void setTabIsEnable(int tabIndex, bool setting)
    {
        TabContainerDebitNoteCore.Tabs[tabIndex].Enabled = setting;
    }

    private void CheckAutogen()
    {
        MiscellaneousSetting dbConnMiscellaneou = new MiscellaneousSetting();
        var result = dbConnMiscellaneou.getMiscellaneou("DebitNoteNoStartFrom");

        if (result.isAutoGen)
        {
            MaterItem dbConn = new MaterItem();
            var rltDebit = dbConn.getDebitNoAll();


            Int64 startFrom = Convert.ToInt64(result.numberValue);


            while (rltDebit.Contains<string>((startFrom++).ToString()))
            {
            }
            startFrom--;
            TextBoxDebitNoteNum.Text = startFrom.ToString();
            TextBoxDebitNoteNum.ReadOnly = true;
        }
    }


    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceTimeEnrty.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }

    private void initValue()
    {


        LabelClientValue.Text = masterI.findClientNameByClientId(mI.findMatterClientId().Value);
        if (mI.findMatterReferId().HasValue)
        {
            LabelRefererValue.Text = masterI.findRefererNameByRefererId(mI.findMatterReferId().Value);
        }
        ucTextBoxStartDate.textBoxValue = DateTimeHelper.getNowTimeString();
        LabelVersionValue.Text = "1";//Convert.ToString(dNI.countDebitNoteVer());
        //LabelAmendedByValue.Text = mI.findMatterUpdateUser();
        //LabelAmendedDateValue.Text = mI.findMatterUpdateDate();

        LabelAmendedByValue.Text = mI.getUserNameBySystemId(mI.userGuid);
        LabelAmendedDateValue.Text = DateTimeHelper.getNowTimeString();

        setDDLAddress();
        setInitPriceControl();
        SessionClass.DebitNoteCostDataTable = null;
        SessionClass.DebitNoteDisbursementDataTable = null;
        TextBoxSubject.Text = mI.findMatterSubject();
        //TextBoxPNTitle.Text = mI.findMatterSubject();
        TextBoxIO.Text = mI.findMatterIO();
        //ImageTrademarkLogo.ImageUrl = mI.findMatterLogo();
        //HiddenFieldTrademarkLogo.Value = mI.findMatterLogo();

        string getMatterListId = Request[QueryStringConst.matterList];

        string matterId = Request[QueryStringConst.matter];
        List<string> matterNumList = new List<string>();
        List<DDLValueDto> tempList = new List<DDLValueDto>();
        if (!String.IsNullOrEmpty(getMatterListId))
        {

            var tempTar = getMatterListId.Split(',');
            foreach (var tarString in tempTar)
            {
                tempList.Add(new DDLValueDto { id = tarString, value = tarString });
                matterNumList.Add(mI.findMatterNum(tarString));
            }


            setPSubject();

            LabelMatterNumValue.Text = String.Join(",", matterNumList.ToArray());
        }
        else
        {

            tempList.Add(new DDLValueDto { id = matterId, value = matterId });
            LabelMatterNumValue.Text = mI.findMatterNum();
        }
        RepeaterTType.DataSource = tempList;
        RepeaterPDTpye.DataSource = tempList;
        RepeaterTType.DataBind();
        RepeaterPDTpye.DataBind();

        setTLogo();
    }

    protected void EntityDataSourceTimeEnrty_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        string getMatterListId = Request[QueryStringConst.matterList];
        string getDebitNoteId = Request["debitNote"];

        if (!String.IsNullOrEmpty(getMatterListId))
        {
            var q = dNI.getML(getMatterListId);
            sb.Append(SQLHelper.whereBoolNotEqual(DatabaseConst.isEnable, false));
            sb.Append(DatabaseConst.and);
            sb.Append("(");
            sb.Append(q);
            sb.Append(")");
        }
        else
        {
            sb.Append(SQLHelper.whereGuid(DatabaseConst.MatterDetail.matterId, Request[QueryStringConst.matter]));
            sb.Append(DatabaseConst.and);
            sb.Append(SQLHelper.whereBoolNotEqual(DatabaseConst.isEnable, false));
        }
        if (getDebitNoteId != null)
        {
            var q = dNI.getNQ(getDebitNoteId);

            if (!String.IsNullOrEmpty(q))
            {
                sb.Append(DatabaseConst.or);
                sb.Append("(");
                sb.Append(q);
                sb.Append(")");
            }
        }
        e.DataSource.Where = sb.ToString();
    }


    protected void ButtonUpload_Click(object sender, EventArgs e)
    {
        //uploadAtt();
    }

    private void setDDLAddress()
    {
        int clinetId = mI.findMatterClientId().Value;
        var tempAddressDDLValue = masterI.getClientAddress(clinetId);
        foreach (var item in tempAddressDDLValue)
        {
            DropDownListAddressClientAddress.Items.Add(item);
        }

        var tempContactPersonDDLValue = masterI.getClientContactPerson(clinetId);

        foreach (var item in tempContactPersonDDLValue)
        {
            //DropDownListClientContactPerson.Items.Add(item);
            CheckBoxListClientContactPerson.Items.Add(item);

        }

        var tempOtherPartiesDDLValue = masterI.getOtherPartiesAllList();
        foreach (var item in tempOtherPartiesDDLValue)
        {
            DropDownListOtherParties.Items.Add(item);
        }



        if (mI.findMatterReferId().HasValue)
        {
            int refererId = mI.findMatterReferId().Value;
            var tempRefererAddressDDLValue = masterI.getRefererAddress(refererId);
            foreach (var item in tempRefererAddressDDLValue)
            {
                DropDownListRefererAddress.Items.Add(item);
            }

            var tempRefererContactpersonDDLValue = masterI.getRefererContactPerson(refererId);
            foreach (var item in tempRefererContactpersonDDLValue)
            {
                //DropDownListRefererContactperson.Items.Add(item);
                CheckBoxListRefererContactperson.Items.Add(item);

            }
        }
        else
        {
            bindNullDDL(DropDownListRefererAddress);
            PopupControlExtenderRefererContactperson.Enabled = false;
            //bindNullDDL(DropDownListRefererContactperson);
        }
        bindNullDDL(DropDownListOtherPartiesAddress);
        bindNullDDL(DropDownListOtherPartiesContactPerson);
    }

    private bool checkRepeatNo()
    {
        if (!string.IsNullOrEmpty(TextBoxDebitNoteNum.Text))
        {
            if (mI.checkingCntDebitNoteNum(TextBoxDebitNoteNum.Text))
            {
                //Response.Write("<script>alert('Client No. already exists!');</script>");
                //redirectPageAndDisplayAlert("Debit No. already exists!", "NewDebitNote.aspx");
                //TextBoxDebitNoteNum.Text = "";
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }

    private DebitNoteDto getDebitNoteCoreDto()
    {
        Guid matterId = new Guid(Request[QueryStringConst.matter]);

        DebitNoteDto dND = new DebitNoteDto();
        dND.debitNoteNum = TextBoxDebitNoteNum.Text;

        dND.startDate = DateTimeHelper.convertStringToDateTime(ucTextBoxStartDate.textBoxValue);
        dND.EndDate = DateTimeHelper.convertStringToDateTime(ucTextBoxEndDate.textBoxValue);
        dND.clientId = mI.findMatterClientId().Value;
        //var op = ucDDLOtherParties.DDLId;

        if (DropDownListOtherParties.SelectedIndex != 0)
        {
            dND.otherPartiesId = Convert.ToInt32(DropDownListOtherParties.SelectedValue);
        }
        else
        {
            dND.otherPartiesId = null;
        }

        //dND.otherPartiesId = null;
        if (mI.findMatterReferId().HasValue)
        {
            dND.refererId = mI.findMatterReferId().Value;

        }

        if (DropDownListAddressClientAddress.SelectedIndex != 0)
        {
            dND.address = DropDownListAddressClientAddress.SelectedValue;
            dND.billToName = LabelClientValue.Text;
        }
        else if (DropDownListOtherPartiesAddress.SelectedIndex != 0)
        {
            dND.billToName = DropDownListOtherParties.SelectedItem.Text;
            dND.address = DropDownListOtherPartiesAddress.SelectedValue;
        }
        else if (DropDownListRefererAddress.SelectedIndex != 0)
        {
            dND.billToName = this.LabelRefererValue.Text;
            dND.address = DropDownListRefererAddress.SelectedValue;
        }
        else
        {
            dND.address = "";
        }



        if (TextBoxClientContactPerson.Text != "")
        {
            dND.contactPersonList = String.Join("◎", getSelectedId(CheckBoxListClientContactPerson).ToArray());
        }
        else if (TextBoxRefererContactperson.Text != "")
        {
            dND.contactPersonList = String.Join("◎", getSelectedId(CheckBoxListRefererContactperson).ToArray());
        }
        else if (DropDownListOtherPartiesContactPerson.SelectedIndex != 0)
        {
            dND.contactPersonList = DropDownListOtherPartiesContactPerson.SelectedValue;
        }
        else
        {
            dND.contactPersonList = "";
        }

        dND.isShowEmail = CheckBoxIsShowEmail.Checked;

        dND.refDebitNote = TextRef.Text;
        dND.yourRefDebitNote = TextBoxYourRef.Text;
        //dND.hourlyRate = mI.findMatterHourlyRate();

        dND.version = 1;
        dND.matterNumId = matterId;
        dND.DebitNoteType = DropDownListDebitNoteMode.SelectedValue;

        dND.feeEarnerList = mI.getMatterFeeEarnerAndHandlingColleague(EnumFeeEarnerAndHandlingColleague.FeeEarner, matterId);
        dND.handlingColleagueList = mI.getMatterFeeEarnerAndHandlingColleague(EnumFeeEarnerAndHandlingColleague.HandlingColleague, matterId);


        if (RadioButtonListPopupPrice.SelectedValue == ((int)EnumDebitNotePriceMode.ButSay).ToString())
        {
            string tarDeposit1 = TextBoxDeposit.Text;
            double depositValue1 = 0;
            double SumDisbursementValue1 = 0;
            double butSayValue1 = 0;

            bool checkDisbursementValue1 = Double.TryParse(HiddenFieldSumDisbursement.Value, out SumDisbursementValue1);
            bool checkDeposit1 = Double.TryParse(tarDeposit1, out depositValue1);
            bool checkSayValue1 = Double.TryParse(this.TextBoxButSayValue.Text, out butSayValue1);
            dND.price = butSayValue1 + SumDisbursementValue1 - depositValue1;
            dND.butSay = butSayValue1;
            dND.isDiscount = false;
            dND.discountValue = 100;
        }
        else if (RadioButtonListPopupPrice.SelectedValue == ((int)EnumDebitNotePriceMode.Discount).ToString())
        {
            dND.price = Convert.ToDouble(HiddenFieldSumPrice.Value);
            dND.isDiscount = true;
            dND.discountValue = getMatterDiscount();
        }
        else
        {
            dND.price = Convert.ToDouble(HiddenFieldSumNormalPrice.Value);
            dND.isDiscount = true;
            dND.discountValue = 100;
        }

        if (String.IsNullOrEmpty(dND.debitNoteNum))
        {
            dND.status = "1";
        }
        else
        {
            dND.status = "2";
        }


        dND.category = DropDownListCategory.SelectedValue;
        dND.io = TextBoxIO.Text;
        dND.SubjectType = DropDownListSubjectType.SelectedValue;

        //if (DropDownListSubjectType.SelectedValue == "1")
        //{
        //    dND.TTypeOfWork = DropDownListTypeOfWork.SelectedValue;
        //    dND.TIsOpponent = DropDownListOpponent.SelectedValue;
        //    dND.TOpponentValue = TextBoxOpponent.Text;
        //    dND.TRoleType = DropDownListRoleType.SelectedValue;
        //    dND.TRoleTypeValue = TextBoxNameOfClient.Text;
        //    dND.TrademarkLogo = HiddenFieldTrademarkLogo.Value;
        //    dND.TrademarkNum = TextBoxTrademarkNum.Text;
        //    dND.TClass = TextBoxClass.Text;
        //    dND.Country = DropDownListCountry.SelectedValue;



        //}
        //else if (DropDownListSubjectType.SelectedValue == "2")
        //{
        //    dND.PStageValue = DropDownListStage.SelectedValue;
        //    dND.PRoleProprietorApplican = DropDownListRoleProprietor.SelectedValue;
        //    dND.PRoleProprietorApplicanValue = TextBoxProprietorOrApplicantValue.Text;
        //    dND.PAssignee = TextBoxAssignee.Text;
        //    dND.PTitle = TextBoxPNTitle.Text;
        //    dND.PDesignOrPatentNum = DropDownListDesignPatentNum.SelectedValue;
        //    dND.PDesignOrPatentNumValue = TextBoxDesignPatentNum.Text;
        //    dND.Country = DropDownListPDCountry.SelectedValue;
        //    dND.PNationalPhase = DropDownListNationalPhase.SelectedValue;


        //}
        //else
        //{
        //    dND.subject = TextBoxSubject.Text;
        //}

        //if (DropDownListSubjectType.SelectedValue == "3" || DropDownListSubjectType.SelectedValue == "4")
        //{
        //    dND.subject = TextBoxSubject.Text;
        //}

        dND.subject = TextBoxSubject.Text;

        dND.CurrencySymbol = DropDownListCurrency.SelectedItem.Text;

        dND.subRef = TextBoxSubRef.Text;

        string tarDeposit = TextBoxDeposit.Text;
        double depositValue;
        bool checkDeposit = Double.TryParse(tarDeposit, out depositValue);
        if (checkDeposit)
        {
            dND.depositAccount = depositValue;
        }

        string getMatterListId = Request[QueryStringConst.matterList];


        if (!String.IsNullOrEmpty(getMatterListId))
        {
            dND.matterList = getMatterListId;
        }

        return dND;
    }



    protected void ButtonCreate_Click(object sender, EventArgs e)
    {
        //if (checkRepeatNo()) return;
        DebitNoteDto dND = getDebitNoteCoreDto();
        dNI.addDebitNoteCore(dND);
        dNI.addDebitNoteCostAndDisbursement();
        setDebitNoteNarrative();
        //uploadAtt();

        if (DropDownListSubjectType.SelectedValue == "1")
        {
            subjectTList();
        }
        else if (DropDownListSubjectType.SelectedValue == "2")
        {
            subjectPList();
        }

        saveTempFile(SessionClass.uploadFileFileNameTemp1, SessionClass.uploadFileTemp1);
        saveTempFile(SessionClass.uploadFileFileNameTemp2, SessionClass.uploadFileTemp2);
        saveTempFile(SessionClass.uploadFileFileNameTemp3, SessionClass.uploadFileTemp3);
        saveTempFile(SessionClass.uploadFileFileNameTemp4, SessionClass.uploadFileTemp4);
        saveTempFile(SessionClass.uploadFileFileNameTemp5, SessionClass.uploadFileTemp5);

        redirectPageAndDisplayAlert("ok!", "../Common/Welcome.aspx");
    }

    private void editAll(string getDebitNoteId)
    {

        bool doWork = dNI.delAllDebitNoteRecords(getDebitNoteId);
        if (doWork)
        {
            SessionClass.Identity = getDebitNoteId;
            Guid id = new Guid(SessionClass.Identity);

            DebitNoteDto dND = getDebitNoteCoreDto();
            dNI.addDebitNoteCore(dND, id);
            dNI.addDebitNoteCostAndDisbursement();
            setDebitNoteNarrative();
            //uploadAtt();

            if (DropDownListSubjectType.SelectedValue == "1")
            {
                subjectTList();
            }
            else if (DropDownListSubjectType.SelectedValue == "2")
            {
                subjectPList();
            }

            saveTempFile(SessionClass.uploadFileFileNameTemp1, SessionClass.uploadFileTemp1);
            saveTempFile(SessionClass.uploadFileFileNameTemp2, SessionClass.uploadFileTemp2);
            saveTempFile(SessionClass.uploadFileFileNameTemp3, SessionClass.uploadFileTemp3);
            saveTempFile(SessionClass.uploadFileFileNameTemp4, SessionClass.uploadFileTemp4);
            saveTempFile(SessionClass.uploadFileFileNameTemp5, SessionClass.uploadFileTemp5);


            var reUrl = Request.Url.ToString();
            redirectPageAndDisplayAlert("ok!", reUrl);

            //redirectPageAndDisplayAlert("ok!", "PendingList.aspx");
        }
        else
        {
            redirectPageAndDisplayAlert("Error!!!", "DebitNote.aspx");
        }

    }

    protected void RadioButtonListPopupPrice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListPopupPrice.SelectedValue == ((int)EnumDebitNotePriceMode.ButSay).ToString())
        {
            TextBoxButSayValue.Enabled = true;
        }
        else
        {
            TextBoxButSayValue.Enabled = false;
            TextBoxButSayValue.Text = "";
        }

        if (RadioButtonListPopupPrice.SelectedValue == ((int)EnumDebitNotePriceMode.Discount).ToString())
        {
            LabelSumPriceTitle.Visible = true;
            LabelSumPrice.Visible = true;
        }
        else
        {
            LabelSumPriceTitle.Visible = false;
            LabelSumPrice.Visible = false;
        }
    }

    private void setInitPriceControl()
    {
        this.TextBoxButSayValue.Text = "";
        this.TextBoxButSayValue.Enabled = false;
        RadioButtonListPopupPrice.SelectedIndex = 0;
    }


    private void setDebitNoteNarrative()
    {
        int i;

        for (i = 0; i < this.GridViewTimeEnrty.Rows.Count; i++)
        {
            if (((CheckBox)GridViewTimeEnrty.Rows[i].FindControl("CheckBoxTarEntry")).Checked)
            {
                int matterDetailsId = Convert.ToInt32(GridViewTimeEnrty.DataKeys[i].Value);
                MatterDetailDto mDD = tEI.getMatterDetailsByDetailsId(matterDetailsId);
                mDD.isCountTotal = true;
                dNI.addDebitNoteNarrative(mDD);
                tEI.editTimeEntryIsUsed(mDD);
            }
            else if (((CheckBox)GridViewTimeEnrty.Rows[i].FindControl("CheckBoxTarEntryNoCount")).Checked)
            {
                int matterDetailsId = Convert.ToInt32(GridViewTimeEnrty.DataKeys[i].Value);
                MatterDetailDto mDD = tEI.getMatterDetailsByDetailsId(matterDetailsId);
                mDD.isCountTotal = false;
                dNI.addDebitNoteNarrative(mDD);
                tEI.editTimeEntryIsUsed(mDD);
            }
        }
    }

    //private void uploadAtt()
    //{
    //    for (int i = 1; i <= 5; i++)
    //    {
    //        //ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolderMainContent");
    //        FileUpload myFL = new FileUpload();
    //        //myFL = (FileUpload)cph.FindControl("FileUploadAttachment" + i);
    //        myFL = (FileUpload)this.FindControl("FileUploadAttachment" + i);

    //        if (myFL.HasFile)
    //        {

    //            Random rm = new Random();
    //            string tempFileNmae = String.Format("{0:yyyyMMdd}", DateTime.Now) + "_" + (rm.Next(100000, 999999)).ToString() + "_" + System.IO.Path.GetFileName(myFL.FileName);
    //            string divName = HttpContext.Current.Server.MapPath("~/Attachment/");
    //            string filePath = "~/Attachment/" + tempFileNmae;
    //            string savePath = HttpContext.Current.Server.MapPath(filePath);
    //            myFL.SaveAs(savePath);
    //            dNI.addDebitNoteAttachment(filePath);
    //        }
    //    }
    //}

    private void uploadAtt()
    {
        uploadAtt(FileUploadAttachment1, EnumAtt.upload1);
        uploadAtt(FileUploadAttachment2, EnumAtt.upload2);
        uploadAtt(FileUploadAttachment3, EnumAtt.upload3);
        uploadAtt(FileUploadAttachment4, EnumAtt.upload4);
        uploadAtt(FileUploadAttachment5, EnumAtt.upload5);
    }

    private void uploadAtt(FileUpload myFL, EnumAtt enumAtt)
    {
        if (myFL.HasFile)
        {
            //Random rm = new Random();
            //string tempFileName = String.Format("{0:yyyyMMdd}", DateTime.Now) + "_" + (rm.Next(100000, 999999)).ToString() + "_" + System.IO.Path.GetFileName(myFL.FileName);
            //string divPathName = String.Format("~/Attachment/{0}/{1}", mI.findMatterNum(), dNI.countDebitNoteVer());
            //string filePath = String.Format("{0}/{1}", divPathName, tempFileName);
            //string divPath = HttpContext.Current.Server.MapPath(divPathName);
            //string savePath = HttpContext.Current.Server.MapPath(filePath);
            //if (!System.IO.Directory.Exists(divPath))
            //{
            //    System.IO.Directory.CreateDirectory(divPath);
            //}
            //myFL.SaveAs(savePath);
            if (enumAtt == EnumAtt.upload1)
            {
                SessionClass.uploadFileFileNameTemp1 = myFL.FileName;
                SessionClass.uploadFileTemp1 = myFL.FileBytes;
            }
            else if (enumAtt == EnumAtt.upload2)
            {
                SessionClass.uploadFileFileNameTemp2 = myFL.FileName;
                SessionClass.uploadFileTemp2 = myFL.FileBytes;
            }
            else if (enumAtt == EnumAtt.upload3)
            {
                SessionClass.uploadFileFileNameTemp3 = myFL.FileName;
                SessionClass.uploadFileTemp3 = myFL.FileBytes;
            }
            else if (enumAtt == EnumAtt.upload4)
            {
                SessionClass.uploadFileFileNameTemp4 = myFL.FileName;
                SessionClass.uploadFileTemp4 = myFL.FileBytes;
            }
            else if (enumAtt == EnumAtt.upload5)
            {
                SessionClass.uploadFileFileNameTemp5 = myFL.FileName;
                SessionClass.uploadFileTemp5 = myFL.FileBytes;
            }
            HiddenFieldIsHasAtt.Value = "";
            //dNI.addDebitNoteAttachment(filePath);
        }
    }

    private void saveTempFile(string tarFile, byte[] tarByteArr)
    {
        if (!String.IsNullOrEmpty(tarFile))
        {
            string getMauuterNum = mI.findMatterNum();
            Random rm = new Random();
            string tempFileName = String.Format("{0:yyyyMMdd}", DateTime.Now) + "_" + (rm.Next(100000, 999999)).ToString() + "_" + System.IO.Path.GetFileName(tarFile);
            string divPathName = String.Format("~/Attachment/{0}/{1}", replaceIllegalCharacters(getMauuterNum), SessionClass.Identity);
            string filePath = String.Format("{0}/{1}", divPathName, tempFileName);
            string divPath = HttpContext.Current.Server.MapPath(divPathName);
            string savePath = HttpContext.Current.Server.MapPath(filePath);

            if (!System.IO.Directory.Exists(divPath))
            {
                System.IO.Directory.CreateDirectory(divPath);
            }

            if (System.IO.File.Exists(savePath))
            {
                tempFileName = String.Format("{0:yyyyMMdd}", DateTime.Now) + "_" + (rm.Next(100000, 999999)).ToString() + "_" + System.IO.Path.GetFileName(tarFile);
                divPathName = String.Format("~/Attachment/{0}/{1}", replaceIllegalCharacters(getMauuterNum), SessionClass.Identity);
                filePath = String.Format("{0}/{1}", divPathName, tempFileName);
                divPath = HttpContext.Current.Server.MapPath(divPathName);
                savePath = HttpContext.Current.Server.MapPath(filePath);
            }

            System.IO.File.WriteAllBytes(savePath, tarByteArr);

            dNI.addDebitNoteAttachment(filePath);
        }
    }

    private double getMatterDiscount()
    {
        double discount = 100;
        double? matterDiscount = mI.findMatterDiscount();

        double? clientDiscount = masterI.getClientDiscount(mI.findMatterClientId().Value);
        if (matterDiscount.HasValue)
        {
            discount = matterDiscount.Value;
        }
        else if (clientDiscount.HasValue)
        {
            discount = clientDiscount.Value;
        }
        return discount;
    }

    protected void ButtonGeneralSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            initTab(2);
        }
        else
        {
            displayAlert("Debit No. already exists!");
        }

    }
    protected void ButtonCostNext_Click(object sender, EventArgs e)
    {
        initTab(3);
    }
    protected void ButtonDisbursementNext_Click(object sender, EventArgs e)
    {
        //setTabIsEnable(3, true);
        //setTabIsEnable(4, true);
        //TabContainerDebitNoteCore.ActiveTabIndex = 3;
        //ButtonDisbursementNext.Enabled = false;
        //ButtonDisbursementNext.Visible = false;
        initTab(4);
        ModalPopupExtenderAtt.Show();
    }
    protected void ButtonNarrativeNext_Click(object sender, EventArgs e)
    {
        //setTabIsEnable(3, true);
        //setTabIsEnable(4, true);
        //TabContainerDebitNoteCore.ActiveTabIndex = 3;
        //ButtonDisbursementNext.Enabled = false;
        //ButtonDisbursementNext.Visible = false;

        delTarFilePath(EnumAtt.upload6);

        string checkIsAtt = HiddenFieldIsHasAtt.Value;
        if (!String.IsNullOrEmpty(checkIsAtt))
        {
            displayAlert(Resources.LanguagePack.CreateDebiteNoteAttConfirm);
            return;
        }

        initTab(5);
        ButtonSubmit.Visible = true;
        //ButtonCreate.Visible = true;
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        delTarFilePath(EnumAtt.upload6);
        setSum();
        ModalPopupExtenderPrice.Show();
    }
    protected void ButtonPriceCreate_Click(object sender, EventArgs e)
    {

        //initTab(5);
        //TabContainerDebitNoteCore.ActiveTabIndex = 4;

        //ModalPopupExtenderPrice.Hide();
        //ButtonCreate.Visible = true;
        var checking = Request["debitNote"];
        if (checking != null)
        {
            editAll(checking);
        }

        else
        {
            ButtonCreate_Click(new object(), new EventArgs());
        }
        //if (checkRepeatNo()) return;
        //DebitNoteDto dND = getDebitNoteCoreDto();
        //dNI.addDebitNoteCore(dND);
        //dNI.addDebitNoteCostAndDisbursement();
        //setDebitNoteNarrative();
        //uploadAtt();
        //redirectPageAndDisplayAlert("ok!", "../Common/Welcome.aspx");
    }
    protected void ButtonPriceCannel_Click(object sender, EventArgs e)
    {
        setInitPriceControl();
        ModalPopupExtenderPrice.Hide();
    }


    private void setNextBtn(int indexBtn)
    {
        Button[] btnArr = new Button[4] { ButtonGeneralSubmit, ButtonCostNext, ButtonDisbursementNext, ButtonNarrativeNext };
        for (int i = 0; i < 4; i++)
        {
            if (i == indexBtn)
            {
                btnArr[i].Visible = true;
            }
            else
            {
                btnArr[i].Visible = false;
            }
        }
    }
    protected void DropDownListCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
        setSum();
    }

    private void setSum()
    {
        string tarDeposit = TextBoxDeposit.Text;
        double depositValue = 0;
        bool checkDeposit = Double.TryParse(tarDeposit, out depositValue);


        var tempTimePrice = setDebitNoteNarrativePrice();
        var disc = getMatterDiscount();
        var sumTotalWithDR = dNI.getDebitNoteDisplayPrice(disc, DropDownListCurrency.SelectedValue, tempTimePrice, depositValue, true, true);
        var sumTotalWithD = dNI.getDebitNoteDisplayPrice(disc, DropDownListCurrency.SelectedValue, tempTimePrice, depositValue, true, false);
        LabelSumPrice.Text = String.Format("${0:#,0.##}", sumTotalWithDR);
        HiddenFieldSumPrice.Value = String.Format("{0}", sumTotalWithD);
        var sumTotalNR = dNI.getDebitNoteDisplayPrice(disc, DropDownListCurrency.SelectedValue, tempTimePrice, depositValue, false, true);
        var sumTotalN = dNI.getDebitNoteDisplayPrice(disc, DropDownListCurrency.SelectedValue, tempTimePrice, depositValue, false, false);
        LabelSumNormalPrice.Text = String.Format("${0:#,0.##}", sumTotalNR);
        HiddenFieldSumNormalPrice.Value = String.Format("{0}", sumTotalN);
        HiddenFieldSumDisbursement.Value = String.Format("{0}", dNI.getDebitNoteSumDisbursement());
    }


    private double setDebitNoteNarrativePrice()
    {
        double result = 0;
        int i;

        for (i = 0; i < this.GridViewTimeEnrty.Rows.Count; i++)
        {
            if (((CheckBox)GridViewTimeEnrty.Rows[i].FindControl("CheckBoxTarEntry")).Checked)
            {
                int matterDetailsId = Convert.ToInt32(GridViewTimeEnrty.DataKeys[i].Value);
                MatterDetailDto mDD = tEI.getMatterDetailsByDetailsId(matterDetailsId);

                if (mDD.timeSpan.HasValue)
                {
                    result += mDD.timeSpan.Value * mDD.hourlyRateH;
                }
                else if (mDD.fixedCost.HasValue)
                {
                    result += mDD.fixedCost.Value;
                }
            }
        }

        return result;
    }

    protected void GridViewTimeEnrty_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int? getId = DataBinder.Eval(e.Row.DataItem, DatabaseConst.id) as int?;
            double? timespan = DataBinder.Eval(e.Row.DataItem, DatabaseConst.MatterDetail.timespan) as double?;
            double? fixedCost = DataBinder.Eval(e.Row.DataItem, DatabaseConst.MatterDetail.fixedCost) as double?;
            //double? wittenOff = null;
            double? billable = DataBinder.Eval(e.Row.DataItem, DatabaseConst.MatterDetail.billable) as double?;
            double? houlyRateH = DataBinder.Eval(e.Row.DataItem, DatabaseConst.MatterDetail.hourlyRateH) as double?;
            double? sum = null;
            double DHR = houlyRateH.HasValue ? houlyRateH.Value : 1000;

            //if (timespan.HasValue && billable.HasValue)
            //{
            //    Label lblWittenOff = e.Row.FindControl("LabelWittenOff") as Label;
            //    wittenOff = timespan - billable;
            //    lblWittenOff.Text = String.Format("{0}", wittenOff);
            //}

            if (timespan.HasValue)
            {
                Label lbl = e.Row.FindControl("LabelCountTotal") as Label;
                sum = timespan.Value * DHR;
                lbl.Text = FormatHelper.CostFormatWithDollarSign(sum.Value);
            }
            else if (fixedCost.HasValue)
            {
                Label lbl = e.Row.FindControl("LabelCountTotal") as Label;
                lbl.Text = FormatHelper.CostFormatWithDollarSign(fixedCost.Value);
            }

            CheckBox cb = e.Row.FindControl("CheckBoxTarEntry") as CheckBox;
            cb.Attributes.Add(String.Format("cbcount{0}", getId.Value), "tar");
            cb.Attributes.Add("onclick", String.Format("javascript: SelectDebitNoteCount(this,{0});", getId.Value));

            CheckBox cbNoCount = e.Row.FindControl("CheckBoxTarEntryNoCount") as CheckBox;
            cbNoCount.Attributes.Add(String.Format("cbnocount{0}", getId.Value), "tar");
            cbNoCount.Attributes.Add("onclick", String.Format("javascript: SelectDebitNoteNoCount(this,{0});", getId.Value));

            string getDebitNoteId = Request["debitNote"];
            if (getDebitNoteId != null)
            {
                var getList = dNI.getNQId(getDebitNoteId);

                foreach (var item in getList)
                {
                    if (getId.Value == item.Item1)
                    {
                        if (item.Item2)
                        {
                            cb.Checked = true;
                        }
                        else
                        {
                            cbNoCount.Checked = true;
                        }
                    }
                }
            }
        }
    }
    protected void DropDownListOtherParties_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownListOtherPartiesAddress.Items.Clear();
        DropDownListOtherPartiesContactPerson.Items.Clear();
        if (DropDownListOtherParties.SelectedIndex != 0)
        {
            int otherPartiesId = Convert.ToInt32(DropDownListOtherParties.SelectedValue);
            var tempOtherPartiesAddressDDLValue = masterI.getOtherPartiesAddress(otherPartiesId);
            foreach (var item in tempOtherPartiesAddressDDLValue)
            {
                DropDownListOtherPartiesAddress.Items.Add(item);
            }
            var tempOtherPartiesContactPersonDDLValue = masterI.getOtherPartiesContactPerson(otherPartiesId);
            foreach (var item in tempOtherPartiesContactPersonDDLValue)
            {
                DropDownListOtherPartiesContactPerson.Items.Add(item);
            }
        }
        else
        {
            bindNullDDL(DropDownListOtherPartiesAddress);
            bindNullDDL(DropDownListOtherPartiesContactPerson);
            int checking = TextBoxRefererContactperson.Text == "" ? 0 : 1;
            setDDLIsEnable(EnumDebitNoteBillTo.isEnable, DropDownListRefererAddress.SelectedIndex, checking);
        }
    }

    private void bindNullDDL(DropDownList tarDDL)
    {
        tarDDL.Items.Add(new ListItem("[Not Set]", "0"));
    }


    private void setDDLIsEnable(EnumDebitNoteBillTo tar, int selectIndex, int selectIndex2)
    {
        if (tar == EnumDebitNoteBillTo.client)
        {
            if (selectIndex != 0 || selectIndex2 != 0)
            {
                DropDownListRefererAddress.Enabled = false;
                PopupControlExtenderRefererContactperson.Enabled = false;
                DropDownListOtherPartiesAddress.Enabled = false;
                DropDownListOtherPartiesContactPerson.Enabled = false;
                delAllValue(CheckBoxListRefererContactperson, TextBoxRefererContactperson);
            }
            else
            {
                DropDownListRefererAddress.Enabled = true;
                PopupControlExtenderRefererContactperson.Enabled = true;
                DropDownListOtherPartiesAddress.Enabled = true;
                DropDownListOtherPartiesContactPerson.Enabled = true;
            }

        }


        else if (tar == EnumDebitNoteBillTo.otherparties)
        {
            if (selectIndex != 0 || selectIndex2 != 0)
            {
                DropDownListRefererAddress.Enabled = false;
                PopupControlExtenderRefererContactperson.Enabled = false;
                DropDownListAddressClientAddress.Enabled = false;
                PopupControlExtendeClientContactPerson.Enabled = false;
                delAllValue(CheckBoxListRefererContactperson, TextBoxRefererContactperson);
                delAllValue(CheckBoxListClientContactPerson, TextBoxClientContactPerson);
            }
            else
            {
                DropDownListRefererAddress.Enabled = true;
                PopupControlExtenderRefererContactperson.Enabled = true;
                DropDownListAddressClientAddress.Enabled = true;
                PopupControlExtendeClientContactPerson.Enabled = true;
            }
        }

        else if (tar == EnumDebitNoteBillTo.referer)
        {
            if (selectIndex != 0 || selectIndex2 != 0)
            {
                DropDownListAddressClientAddress.Enabled = false;
                PopupControlExtendeClientContactPerson.Enabled = false;
                DropDownListOtherPartiesAddress.Enabled = false;
                DropDownListOtherPartiesContactPerson.Enabled = false;
                delAllValue(CheckBoxListClientContactPerson, TextBoxClientContactPerson);
            }
            else
            {
                DropDownListAddressClientAddress.Enabled = true;
                PopupControlExtendeClientContactPerson.Enabled = true;
                DropDownListOtherPartiesAddress.Enabled = true;
                DropDownListOtherPartiesContactPerson.Enabled = true;
            }
        }
        else
        {
            DropDownListAddressClientAddress.Enabled = true;
            PopupControlExtendeClientContactPerson.Enabled = true;
            DropDownListOtherPartiesAddress.Enabled = true;
            DropDownListRefererAddress.Enabled = true;
            PopupControlExtenderRefererContactperson.Enabled = true;
            DropDownListOtherPartiesContactPerson.Enabled = true;

        }
    }
    protected void DropDownListAddressClientAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        int checking = TextBoxClientContactPerson.Text == "" ? 0 : 1;
        setDDLIsEnable(EnumDebitNoteBillTo.client, checking, DropDownListAddressClientAddress.SelectedIndex);
    }
    //protected void DropDownListClientContactPerson_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int checking = TextBoxClientContactPerson.Text == "" ? 0 : 1;
    //    setDDLIsEnable(EnumDebitNoteBillTo.client, checking, DropDownListAddressClientAddress.SelectedIndex);
    //}
    protected void DropDownListOtherPartiesAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        setDDLIsEnable(EnumDebitNoteBillTo.otherparties, DropDownListOtherPartiesContactPerson.SelectedIndex, DropDownListOtherPartiesAddress.SelectedIndex);
    }
    protected void DropDownListOtherPartiesContactPerson_SelectedIndexChanged(object sender, EventArgs e)
    {

        setDDLIsEnable(EnumDebitNoteBillTo.otherparties, DropDownListOtherPartiesContactPerson.SelectedIndex, DropDownListOtherPartiesAddress.SelectedIndex);
    }
    protected void DropDownListRefererAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        int checking = TextBoxRefererContactperson.Text == "" ? 0 : 1;
        setDDLIsEnable(EnumDebitNoteBillTo.referer, DropDownListRefererAddress.SelectedIndex, checking);
    }
    //protected void DropDownListRefererContactperson_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int checking = TextBoxRefererContactperson.Text == "" ? 0 : 1;
    //    setDDLIsEnable(EnumDebitNoteBillTo.referer, DropDownListRefererAddress.SelectedIndex, checking);
    //}
    protected void CustomValidatorChecking_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = checkRepeatNo();
    }
    protected void ButtonUploadFile1_Click(object sender, EventArgs e)
    {
        delTarFilePath(EnumAtt.upload1);
    }
    protected void ButtonUploadFile2_Click(object sender, EventArgs e)
    {
        delTarFilePath(EnumAtt.upload2);
    }
    protected void ButtonUploadFile3_Click(object sender, EventArgs e)
    {
        delTarFilePath(EnumAtt.upload3);
    }
    protected void ButtonUploadFile4_Click(object sender, EventArgs e)
    {
        delTarFilePath(EnumAtt.upload4);
    }
    protected void ButtonUploadFile5_Click(object sender, EventArgs e)
    {
        delTarFilePath(EnumAtt.upload5);
    }

    private void delTarFilePath(EnumAtt enumAtt)
    {
        uploadAtt();



        if (enumAtt == EnumAtt.upload1)
        {
            SessionClass.uploadFileFileNameTemp1 = null;
            SessionClass.uploadFileTemp1 = null;
        }
        else if (enumAtt == EnumAtt.upload2)
        {
            SessionClass.uploadFileFileNameTemp2 = null;
            SessionClass.uploadFileTemp2 = null;
        }
        else if (enumAtt == EnumAtt.upload3)
        {
            SessionClass.uploadFileFileNameTemp3 = null;
            SessionClass.uploadFileTemp3 = null;
        }
        else if (enumAtt == EnumAtt.upload4)
        {
            SessionClass.uploadFileFileNameTemp4 = null;
            SessionClass.uploadFileTemp4 = null;
        }
        else if (enumAtt == EnumAtt.upload5)
        {
            SessionClass.uploadFileFileNameTemp5 = null;
            SessionClass.uploadFileTemp5 = null;
        }

        if (!String.IsNullOrEmpty(SessionClass.uploadFileFileNameTemp1))
        {
            LabelUploadFile1.Text = SessionClass.uploadFileFileNameTemp1;
            FileUploadAttachment1.Visible = false;
        }
        else
        {
            LabelUploadFile1.Text = "";
            FileUploadAttachment1.Visible = true;
        }
        if (!String.IsNullOrEmpty(SessionClass.uploadFileFileNameTemp2))
        {
            LabelUploadFile2.Text = SessionClass.uploadFileFileNameTemp2;
            FileUploadAttachment2.Visible = false;
        }
        else
        {
            LabelUploadFile2.Text = "";
            FileUploadAttachment2.Visible = true;
        }
        if (!String.IsNullOrEmpty(SessionClass.uploadFileFileNameTemp3))
        {
            LabelUploadFile3.Text = SessionClass.uploadFileFileNameTemp3;
            FileUploadAttachment3.Visible = false;
        }
        else
        {
            LabelUploadFile3.Text = "";
            FileUploadAttachment3.Visible = true;
        }
        if (!String.IsNullOrEmpty(SessionClass.uploadFileFileNameTemp4))
        {
            LabelUploadFile4.Text = SessionClass.uploadFileFileNameTemp4;
            FileUploadAttachment4.Visible = false;
        }
        else
        {
            LabelUploadFile4.Text = "";
            FileUploadAttachment4.Visible = true;
        }
        if (!String.IsNullOrEmpty(SessionClass.uploadFileFileNameTemp5))
        {
            LabelUploadFile5.Text = SessionClass.uploadFileFileNameTemp5;
            FileUploadAttachment5.Visible = false;
        }
        else
        {
            LabelUploadFile5.Text = "";
            FileUploadAttachment5.Visible = true;
        }
    }

    private void settingUploadisDisplay(string tar)
    {
        //  FileUpload fu = Page.Master.FindControl("ContentPlaceHolderMainContent").FindControl("FileUploadAttachment" + tar) as FileUpload;

    }


    private string replaceIllegalCharacters(string fileName)
    {
        string invalid = new string(System.IO.Path.GetInvalidFileNameChars()) + new string(System.IO.Path.GetInvalidPathChars());

        foreach (char c in invalid)
        {
            fileName = fileName.Replace(c.ToString(), "");
        }
        return fileName;
    }


    protected void CheckBoxListClientContactPerson_SelectedIndexChanged(object sender, EventArgs e)
    {
        stValue(CheckBoxListClientContactPerson, TextBoxClientContactPerson);
        int checking = TextBoxClientContactPerson.Text == "" ? 0 : 1;
        setDDLIsEnable(EnumDebitNoteBillTo.client, checking, DropDownListAddressClientAddress.SelectedIndex);

    }

    protected void CheckBoxListRefererContactperson_SelectedIndexChanged(object sender, EventArgs e)
    {
        stValue(CheckBoxListRefererContactperson, TextBoxRefererContactperson);
        int checking = TextBoxRefererContactperson.Text == "" ? 0 : 1;
        setDDLIsEnable(EnumDebitNoteBillTo.referer, DropDownListRefererAddress.SelectedIndex, checking);

    }

    private void stValue(CheckBoxList CheckBoxList1, TextBox TextBox1)
    {
        string name = "";
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                name += CheckBoxList1.Items[i].Text + ",";
            }
        }
        TextBox1.Text = name;
    }

    private void delAllValue(CheckBoxList CheckBoxList1, TextBox TextBox1)
    {
        string name = "";
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            CheckBoxList1.Items[i].Selected = false;
        }
        TextBox1.Text = name;
    }


    private List<string> getSelectedId(CheckBoxList CheckBoxList1)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                result.Add(CheckBoxList1.Items[i].Value);
            }
        }
        return result;
    }


    private void setAddresInit(string contactList, CheckBoxList CheckBoxList1)
    {

        try
        {
            var contactPersonInfoArr = contactList.Split('◎');
            foreach (var item in contactPersonInfoArr)
            {
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Value == item)
                    {
                        CheckBoxList1.Items[i].Selected = true;
                    }
                }
            }


        }

        catch
        {

        }
    }


    private void getFileByteArr(List<string> filePathLsit)
    {

        for (int i = 0; i < filePathLsit.Count; i++)
        {
            try
            {
                string savePath = HttpContext.Current.Server.MapPath(filePathLsit[i]);
                byte[] fileArr = System.IO.File.ReadAllBytes(savePath);
                string fileName = System.IO.Path.GetFileName(savePath);
                if (i == 0)
                {
                    SessionClass.uploadFileFileNameTemp1 = fileName;
                    SessionClass.uploadFileTemp1 = fileArr;
                }
                else if (i == 1)
                {
                    SessionClass.uploadFileFileNameTemp2 = fileName;
                    SessionClass.uploadFileTemp2 = fileArr;
                }
                else if (i == 2)
                {
                    SessionClass.uploadFileFileNameTemp3 = fileName;
                    SessionClass.uploadFileTemp3 = fileArr;
                }
                else if (i == 3)
                {
                    SessionClass.uploadFileFileNameTemp4 = fileName;
                    SessionClass.uploadFileTemp4 = fileArr;
                }
                else if (i == 4)
                {
                    SessionClass.uploadFileFileNameTemp5 = fileName;
                    SessionClass.uploadFileTemp5 = fileArr;
                }


                delTarFilePath(EnumAtt.upload6);
            }
            catch
            {
            }
        }

    }
    protected void DropDownListSubjectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListSubjectType.SelectedValue == "1")
        {
            RepeaterTType.Visible = true;
            RepeaterPDTpye.Visible = false;
            GOrNType.Visible = false;
        }

        else if (DropDownListSubjectType.SelectedValue == "2")
        {
            RepeaterTType.Visible = false;
            RepeaterPDTpye.Visible = true;
            GOrNType.Visible = false;
        }
        else
        {
            RepeaterTType.Visible = false;
            RepeaterPDTpye.Visible = false;
            GOrNType.Visible = true;
        }

    }

    private void setTLogo()
    {
        foreach (Control c in this.RepeaterTType.Controls)
        {
            HiddenField HiddenFieldMatterId = (HiddenField)c.FindControl("HiddenFieldMatterId");
            HiddenField HiddenFieldTrademarkLogo = (HiddenField)c.FindControl("HiddenFieldTrademarkLogo");
            Image ImageTrademarkLogo = (Image)c.FindControl("ImageTrademarkLogo");
            TextBox TextBoxNameOfClient = (TextBox)c.FindControl("TextBoxNameOfClient");
            var tempValue = mI.findMatterLogo(HiddenFieldMatterId.Value);
            ImageTrademarkLogo.ImageUrl = tempValue;
            HiddenFieldTrademarkLogo.Value = tempValue;
            TextBoxNameOfClient.Text = masterI.findClientNameByClientId(mI.findMatterClientId(HiddenFieldMatterId.Value).Value);
        }
    }

    private void setPSubject()
    {
        foreach (Control c in this.RepeaterPDTpye.Controls)
        {
            HiddenField HiddenFieldMatterId = (HiddenField)c.FindControl("HiddenFieldMatterId");
            TextBox TextBoxPNTitle = (TextBox)c.FindControl("TextBoxPNTitle");
            var tempValue = mI.findMatterSubject(HiddenFieldMatterId.Value);
            TextBoxPNTitle.Text = tempValue;
        }
    }


    private void subjectTList()
    {
        List<DebitNoteSubjectTDto> subjectTList = new List<DebitNoteSubjectTDto>();
        foreach (Control c in this.RepeaterTType.Controls)
        {

            HiddenField HiddenFieldMatterId = (HiddenField)c.FindControl("HiddenFieldMatterId");
            DropDownList DropDownListTypeOfWork = (DropDownList)c.FindControl("DropDownListTypeOfWork");
            DropDownList DropDownListOpponent = (DropDownList)c.FindControl("DropDownListOpponent");
            TextBox TextBoxOpponent = (TextBox)c.FindControl("TextBoxOpponent");
            DropDownList DropDownListRoleType = (DropDownList)c.FindControl("DropDownListRoleType");
            TextBox TextBoxNameOfClient = (TextBox)c.FindControl("TextBoxNameOfClient");
            HiddenField HiddenFieldTrademarkLogo = (HiddenField)c.FindControl("HiddenFieldTrademarkLogo");
            TextBox TextBoxTrademarkNum = (TextBox)c.FindControl("TextBoxTrademarkNum");
            TextBox TextBoxClass = (TextBox)c.FindControl("TextBoxClass");
            DropDownList DropDownListCountry = (DropDownList)c.FindControl("DropDownListCountry");


            TextBox TrademarkLogoDescription = (TextBox)c.FindControl("TextBoxTrademarkLogoDescription");

            DebitNoteSubjectTDto subjectT = new DebitNoteSubjectTDto();
            subjectT.matterId = new Guid(HiddenFieldMatterId.Value);
            subjectT.TTypeOfWork = DropDownListTypeOfWork.SelectedValue;
            subjectT.TIsOpponent = DropDownListOpponent.SelectedValue;
            subjectT.TOpponentValue = TextBoxOpponent.Text;
            subjectT.TRoleType = DropDownListRoleType.SelectedValue;
            subjectT.TRoleTypeValue = TextBoxNameOfClient.Text;
            subjectT.TrademarkLogo = HiddenFieldTrademarkLogo.Value;
            subjectT.TrademarkNum = TextBoxTrademarkNum.Text;
            subjectT.TClass = TextBoxClass.Text;
            subjectT.Country = DropDownListCountry.SelectedValue;
            subjectT.TrademarkLogoDescription = TrademarkLogoDescription.Text;
            subjectTList.Add(subjectT);
        }
        dNI.addDebitNoteSubjectT(subjectTList);
    }

    private void subjectPList()
    {
        List<DebitNoteSubjectPDto> subjectPList = new List<DebitNoteSubjectPDto>();
        foreach (Control c in this.RepeaterPDTpye.Controls)
        {
            HiddenField HiddenFieldMatterId = (HiddenField)c.FindControl("HiddenFieldMatterId");
            DropDownList DropDownListStage = (DropDownList)c.FindControl("DropDownListStage");
            DropDownList DropDownListRoleProprietor = (DropDownList)c.FindControl("DropDownListRoleProprietor");
            TextBox TextBoxProprietorOrApplicantValue = (TextBox)c.FindControl("TextBoxProprietorOrApplicantValue");
            TextBox TextBoxAssignee = (TextBox)c.FindControl("TextBoxAssignee");
            TextBox TextBoxPNTitle = (TextBox)c.FindControl("TextBoxPNTitle");
            DropDownList DropDownListDesignPatentNum = (DropDownList)c.FindControl("DropDownListDesignPatentNum");
            TextBox TextBoxDesignPatentNum = (TextBox)c.FindControl("TextBoxDesignPatentNum");
            DropDownList DropDownListPDCountry = (DropDownList)c.FindControl("DropDownListPDCountry");
            DropDownList DropDownListNationalPhase = (DropDownList)c.FindControl("DropDownListNationalPhase");
            TextBox TextBoxPriorityValue = (TextBox)c.FindControl("TextBoxPriorityValue");

            DebitNoteSubjectPDto subjectP = new DebitNoteSubjectPDto();
            subjectP.matterId = new Guid(HiddenFieldMatterId.Value);
            subjectP.PStageValue = DropDownListStage.SelectedValue;
            subjectP.PRoleProprietorApplican = DropDownListRoleProprietor.SelectedValue;
            subjectP.PRoleProprietorApplicanValue = TextBoxProprietorOrApplicantValue.Text;
            subjectP.PAssignee = TextBoxAssignee.Text;
            subjectP.PTitle = TextBoxPNTitle.Text;
            subjectP.PDesignOrPatentNum = DropDownListDesignPatentNum.SelectedValue;
            subjectP.PDesignOrPatentNumValue = TextBoxDesignPatentNum.Text;
            subjectP.Country = DropDownListPDCountry.SelectedValue;
            subjectP.PNationalPhase = DropDownListNationalPhase.SelectedValue;
            subjectP.PPriorityValue = TextBoxPriorityValue.Text;
            subjectPList.Add(subjectP);
        }
        dNI.addDebitNoteSubjectP(subjectPList);
    }

    private void setSubjectT(string debitNoteId)
    {
        var getSubjectTDto = dNI.getDebitNoteSubjectTDto(debitNoteId);
        foreach (Control c in this.RepeaterTType.Controls)
        {

            HiddenField HiddenFieldMatterId = (HiddenField)c.FindControl("HiddenFieldMatterId");
            DropDownList DropDownListTypeOfWork = (DropDownList)c.FindControl("DropDownListTypeOfWork");
            DropDownList DropDownListOpponent = (DropDownList)c.FindControl("DropDownListOpponent");
            TextBox TextBoxOpponent = (TextBox)c.FindControl("TextBoxOpponent");
            DropDownList DropDownListRoleType = (DropDownList)c.FindControl("DropDownListRoleType");
            TextBox TextBoxNameOfClient = (TextBox)c.FindControl("TextBoxNameOfClient");
            HiddenField HiddenFieldTrademarkLogo = (HiddenField)c.FindControl("HiddenFieldTrademarkLogo");
            TextBox TextBoxTrademarkNum = (TextBox)c.FindControl("TextBoxTrademarkNum");
            TextBox TextBoxClass = (TextBox)c.FindControl("TextBoxClass");
            DropDownList DropDownListCountry = (DropDownList)c.FindControl("DropDownListCountry");
            Image ImageTrademarkLogo = (Image)c.FindControl("ImageTrademarkLogo");
            TextBox TrademarkLogoDescription = (TextBox)c.FindControl("TextBoxTrademarkLogoDescription");


            foreach (var tar in getSubjectTDto)
            {
                if (tar.matterId.ToString() == HiddenFieldMatterId.Value)
                {
                    DropDownListTypeOfWork.SelectedValue = tar.TTypeOfWork;
                    DropDownListOpponent.SelectedValue = tar.TIsOpponent;
                    TextBoxOpponent.Text = tar.TOpponentValue;
                    DropDownListRoleType.SelectedValue = tar.TRoleType;
                    TextBoxNameOfClient.Text = tar.TRoleTypeValue;
                    //ImageTrademarkLogo.ImageUrl = tar.TrademarkLogo;
                    //HiddenFieldTrademarkLogo.Value = tar.TrademarkLogo;
                    TextBoxTrademarkNum.Text = tar.TrademarkNum;
                    TextBoxClass.Text = tar.TClass;
                    TrademarkLogoDescription.Text = tar.TrademarkLogoDescription;
                }
            }
        }
    }

    private void setSubjectP(string debitNoteId)
    {
        var getSubjectPDto = dNI.getDebitNoteSubjectPDto(debitNoteId);
        foreach (Control c in this.RepeaterPDTpye.Controls)
        {
            HiddenField HiddenFieldMatterId = (HiddenField)c.FindControl("HiddenFieldMatterId");
            DropDownList DropDownListStage = (DropDownList)c.FindControl("DropDownListStage");
            DropDownList DropDownListRoleProprietor = (DropDownList)c.FindControl("DropDownListRoleProprietor");
            TextBox TextBoxProprietorOrApplicantValue = (TextBox)c.FindControl("TextBoxProprietorOrApplicantValue");
            TextBox TextBoxAssignee = (TextBox)c.FindControl("TextBoxAssignee");
            TextBox TextBoxPNTitle = (TextBox)c.FindControl("TextBoxPNTitle");
            DropDownList DropDownListDesignPatentNum = (DropDownList)c.FindControl("DropDownListDesignPatentNum");
            TextBox TextBoxDesignPatentNum = (TextBox)c.FindControl("TextBoxDesignPatentNum");
            DropDownList DropDownListPDCountry = (DropDownList)c.FindControl("DropDownListPDCountry");
            DropDownList DropDownListNationalPhase = (DropDownList)c.FindControl("DropDownListNationalPhase");
            TextBox TextBoxPriorityValue = (TextBox)c.FindControl("TextBoxPriorityValue");
            foreach (var tar in getSubjectPDto)
            {
                if (tar.matterId.ToString() == HiddenFieldMatterId.Value)
                {
                    DropDownListStage.SelectedValue = tar.PStageValue;
                    DropDownListRoleProprietor.SelectedValue = tar.PRoleProprietorApplican;
                    TextBoxProprietorOrApplicantValue.Text = tar.PRoleProprietorApplicanValue;
                    TextBoxAssignee.Text = tar.PAssignee;
                    TextBoxPNTitle.Text = tar.PTitle;
                    DropDownListDesignPatentNum.SelectedValue = tar.PDesignOrPatentNum;
                    TextBoxDesignPatentNum.Text = tar.PDesignOrPatentNumValue;

                    DropDownListNationalPhase.SelectedValue = tar.PNationalPhase;
                    TextBoxPriorityValue.Text = tar.PPriorityValue;
                }
            }
        }
    }

    private void setSubjectTCountry(string debitNoteId)
    {
        var getSubjectTDto = dNI.getDebitNoteSubjectTDto(debitNoteId);
        foreach (Control c in this.RepeaterTType.Controls)
        {

            HiddenField HiddenFieldMatterId = (HiddenField)c.FindControl("HiddenFieldMatterId");
            DropDownList DropDownListTypeOfWork = (DropDownList)c.FindControl("DropDownListTypeOfWork");
            DropDownList DropDownListOpponent = (DropDownList)c.FindControl("DropDownListOpponent");
            TextBox TextBoxOpponent = (TextBox)c.FindControl("TextBoxOpponent");
            DropDownList DropDownListRoleType = (DropDownList)c.FindControl("DropDownListRoleType");
            TextBox TextBoxNameOfClient = (TextBox)c.FindControl("TextBoxNameOfClient");
            HiddenField HiddenFieldTrademarkLogo = (HiddenField)c.FindControl("HiddenFieldTrademarkLogo");
            TextBox TextBoxTrademarkNum = (TextBox)c.FindControl("TextBoxTrademarkNum");
            TextBox TextBoxClass = (TextBox)c.FindControl("TextBoxClass");
            DropDownList DropDownListCountry = (DropDownList)c.FindControl("DropDownListCountry");
            Image ImageTrademarkLogo = (Image)c.FindControl("ImageTrademarkLogo");

            foreach (var tar in getSubjectTDto)
            {
                if (tar.matterId.ToString() == HiddenFieldMatterId.Value)
                {
                    if (DropDownListCountry.Items.FindByText(tar.Country) != null)
                    {
                        DropDownListCountry.SelectedValue = tar.Country;
                    }

                }
            }
        }
    }

    private void setSubjectPCountry(string debitNoteId)
    {
        var getSubjectPDto = dNI.getDebitNoteSubjectPDto(debitNoteId);
        foreach (Control c in this.RepeaterPDTpye.Controls)
        {
            HiddenField HiddenFieldMatterId = (HiddenField)c.FindControl("HiddenFieldMatterId");
            DropDownList DropDownListStage = (DropDownList)c.FindControl("DropDownListStage");
            DropDownList DropDownListRoleProprietor = (DropDownList)c.FindControl("DropDownListRoleProprietor");
            TextBox TextBoxProprietorOrApplicantValue = (TextBox)c.FindControl("TextBoxProprietorOrApplicantValue");
            TextBox TextBoxAssignee = (TextBox)c.FindControl("TextBoxAssignee");
            TextBox TextBoxPNTitle = (TextBox)c.FindControl("TextBoxPNTitle");
            DropDownList DropDownListDesignPatentNum = (DropDownList)c.FindControl("DropDownListDesignPatentNum");
            TextBox TextBoxDesignPatentNum = (TextBox)c.FindControl("TextBoxDesignPatentNum");
            DropDownList DropDownListPDCountry = (DropDownList)c.FindControl("DropDownListPDCountry");
            DropDownList DropDownListNationalPhase = (DropDownList)c.FindControl("DropDownListNationalPhase");

            foreach (var tar in getSubjectPDto)
            {
                if (tar.matterId.ToString() == HiddenFieldMatterId.Value)
                {
                    if (DropDownListPDCountry.Items.FindByText(tar.Country) != null)
                    {
                        DropDownListPDCountry.SelectedValue = tar.Country;
                    }
                }
            }
        }
    }
    protected void ButtonAttYes_Click(object sender, EventArgs e)
    {
        HiddenFieldIsHasAtt.Value = "Y";
        ModalPopupExtenderAtt.Hide();
    }
    protected void ButtonAttNo_Click(object sender, EventArgs e)
    {
        ModalPopupExtenderAtt.Hide();
    }
}