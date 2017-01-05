using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class DebitNote_DetailsDebitnote : CultureEnabledPage
{
    MatterInfo mI = new MatterInfo();
    MaterItem masterI = new MaterItem();
    DebitNoteInfo dNI = new DebitNoteInfo();
    TimeEntryInfo tEI = new TimeEntryInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(1);", true);
        string edit = Request.QueryString["edit"];
        if (edit != null && edit == "1")
        {
            divview.Visible = false;
            Buttonedit.Visible = false;

            ButtonCreate.Visible = true;
        }
        else
        {
            divedit.Visible = false;
            Buttonedit.Visible = true;
        }
        if (!IsPostBack)
        {
            initValue();
            initValueview();

            //CheckAutogen();
            //initTab(1);
        }
        //divview.Visible = false;
    }
    private void initValue()
    {
        MaterItem db = new MaterItem();
        var resultcore = db.getDebitNoteCores(new Guid(SessionClass.Debitnoteid));
        TextBoxDebitNoteNum.Text = resultcore.debitNoteNum;
        TextBoxDebitNoteNum.ReadOnly = true;

        LabelMatterNumValue.Text = mI.findMatterNum();
        LabelClientValue.Text = masterI.findClientNameByClientId(mI.findMatterClientId().Value);
        if (mI.findMatterReferId().HasValue)
        {
            LabelRefererValue.Text = masterI.findRefererNameByRefererId(mI.findMatterReferId().Value);
        }
        ucTextBoxStartDate.textBoxValue = DateTimeHelper.getNowTimeString();
        LabelVersionValue.Text = Convert.ToString(dNI.countDebitNoteVer());
        LabelAmendedByValue.Text = mI.findMatterUpdateUser();
        LabelAmendedDateValue.Text = mI.findMatterUpdateDate();
        setDDLAddress();
        setInitPriceControl();
        SessionClass.DebitNoteCostDataTable = null;
        SessionClass.DebitNoteDisbursementDataTable = null;

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

    private void initValueview()
    {
        LabelMatterNumValueview.Text = mI.findMatterNum();
        LabelClientValueview.Text = masterI.findClientNameByClientId(mI.findMatterClientId().Value);
        if (mI.findMatterReferId().HasValue)
        {
            LabelRefererValueview.Text = masterI.findRefererNameByRefererId(mI.findMatterReferId().Value);
        }
        //ucTextBoxStartDate.textBoxValue = DateTimeHelper.getNowTimeString();
        LabelVersionValueview.Text = Convert.ToString(dNI.countDebitNoteVer());
        LabelAmendedByValueview.Text = mI.findMatterUpdateUser();
        LabelAmendedDateValueview.Text = mI.findMatterUpdateDate();
        //setDDLAddress();
        //setInitPriceControl();
        SessionClass.DebitNoteCostDataTable = null;
        SessionClass.DebitNoteDisbursementDataTable = null;


        MaterItem dbconn = new MaterItem();
        var rt = dbconn.getDebitNoteCores(new Guid(SessionClass.Debitnoteid));
        LabelDebitNoteNumvalueview.Text = rt.debitNoteNum;
        LabelStartDatevalueview.Text = rt.startDate.Value.ToString();
        LabelEndDatevalueview.Text = rt.endDate.Value.ToString();
        var rtOtherparties = dbconn.getOtherParties(rt.otherPartiesId.Value);
        LabelOtherPartiesvalueview.Text = rtOtherparties.otherPartiesName;
        LabelAddressvalueview.Text = rt.address;
        LabelRefvalueview.Text = rt.@ref;
        LabelYourRefvalueview.Text = rt.yourRef;

        int type = int.Parse(rt.debitNoteType);
        switch (type)
        {
            case 1: LabelDebitNoteModevalueview.Text = "Interim Debit Note"; break;
            case 2: LabelDebitNoteModevalueview.Text = "Renewal"; break;
            case 3: LabelDebitNoteModevalueview.Text = "Maintenance Debit Note"; break;
            case 4: LabelDebitNoteModevalueview.Text = "Final"; break;

            default: break;
        }
        var rlt = dbconn.getAttachmentsAll(new Guid(SessionClass.Debitnoteid));
        int cnt = rlt.Count<string>();
        //for (int i = 0; i < cnt; i++)
        //{
        //    switch (i)
        //    {
        //        case 0: HyperLinkAttachment1.NavigateUrl = rlt.Take<string>(i).First<string>(); break;
        //        case 1: HyperLinkAttachment2.NavigateUrl = rlt.Take<string>(i).First<string>(); break;
        //        case 2: HyperLinkAttachment3.NavigateUrl = rlt.Take<string>(i).First<string>(); break;
        //        case 3: HyperLinkAttachment4.NavigateUrl = rlt.Take<string>(i).First<string>(); break;
        //        case 4: HyperLinkAttachment5.NavigateUrl = rlt.Take<string>(i).First<string>(); break;
        //        default: break;
        //    }
        //}
        int i = 0;
        foreach (string q in rlt)
        {
            switch (i)
            {
                case 0: HyperLinkAttachment1.NavigateUrl = q; HyperLinkAttachment1.Text = q; break;
                case 1: HyperLinkAttachment2.NavigateUrl = q; HyperLinkAttachment2.Text = q; break;
                case 2: HyperLinkAttachment3.NavigateUrl = q; HyperLinkAttachment3.Text = q; break;
                case 3: HyperLinkAttachment4.NavigateUrl = q; HyperLinkAttachment4.Text = q; break;
                case 4: HyperLinkAttachment5.NavigateUrl = q; HyperLinkAttachment5.Text = q; break;
                default: break;
            }
            i++;
        }
        //var rltcost = dbconn.getDebitNoteCosts(new Guid(SessionClass.Debitnoteid));
        //if (rltcost != null)
        //{
        //    var rlttype = dbconn.getPricingTypes(int.Parse(rltcost.templateType));
        //    if (rlttype != null)
        //    {
        //        LabelCostTemplatevalue.Text = rlttype.typeDescription;
        //    }
        //    LabelCostDescriptionvalue.Text = rltcost.templateDetails;
        //    LabelCostvalue.Text = rltcost.cost.Value.ToString();
        //    LabelRemarkValue.Text = rltcost.remark;
        //}
        //var rltDisbursements = dbconn.getDebitNoteDisbursements(new Guid(SessionClass.Debitnoteid));
        //if (rltDisbursements != null)
        //{
        //    var rlttype = dbconn.getPricingTypes(int.Parse(rltDisbursements.templateType));
        //    if (rlttype != null)
        //    {
        //        LabelDisbursementTemplatevalue.Text = rlttype.typeDescription;
        //    }
        //    LabelDisbursementDescriptionvalue.Text = rltDisbursements.templateDetails;
        //    LabelDisbursementCostvalue.Text = rltDisbursements.cost.Value.ToString();
        //}
    }

    protected void EntityDataSourceTimeEnrty_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(SQLHelper.whereGuid(DatabaseConst.MatterDetail.matterId, Request[QueryStringConst.matter]));
        sb.Append(DatabaseConst.and);
        sb.Append(SQLHelper.whereBoolNotEqual(DatabaseConst.isEnable, false));
        e.DataSource.Where = sb.ToString();
    }


    protected void ButtonUpload_Click(object sender, EventArgs e)
    {
        uploadAtt();
    }

    private void setDDLAddress()
    {
        var tempDDLValue = masterI.getClientAddress(mI.findMatterClientId().Value);
        foreach (var item in tempDDLValue)
        {
            DropDownListAddress.Items.Add(item);
        }
        if (mI.findMatterReferId().HasValue)
        {
            int refererId = mI.findMatterReferId().Value;
            var tempRefererAddressDDLValue = masterI.getRefererAddress(refererId);
            foreach (var item in tempRefererAddressDDLValue)
            {
                //DropDownListRefererAddress.Items.Add(item);
            }
        }
    }

    private bool checkRepeatNo()
    {
        MaterItem dbConn = new MaterItem();
        if (dbConn.cntDebitNoteNum(TextBoxDebitNoteNum.Text) > 0)
        {
            //Response.Write("<script>alert('Client No. already exists!');</script>");
            redirectPageAndDisplayAlert("Debit No. already exists!", "NewDebitNote.aspx");
            TextBoxDebitNoteNum.Text = "";

            return true;


        }
        else
            return false;
    }

    private DebitNoteDto getDebitNoteCoreDto()
    {
        Guid matterId = new Guid(Request[QueryStringConst.matter]);

        DebitNoteDto dND = new DebitNoteDto();
        dND.debitNoteNum = TextBoxDebitNoteNum.Text;

        dND.startDate = DateTimeHelper.convertStringToDateTime(ucTextBoxStartDate.textBoxValue);
        dND.EndDate = DateTimeHelper.convertStringToDateTime(ucTextBoxEndDate.textBoxValue);
        dND.clientId = mI.findMatterClientId().Value;
        dND.otherPartiesId = Convert.ToInt16(ucDDLOtherParties.DDLId);
        if (mI.findMatterReferId().HasValue)
        {
            dND.refererId = mI.findMatterReferId().Value;
        }
        dND.address = DropDownListAddress.SelectedValue;
        dND.refDebitNote = TextRef.Text;
        dND.yourRefDebitNote = TextBoxYourRef.Text;

        dND.version = dNI.countDebitNoteVer();
        //dND.matterNumId = matterId;
        dND.DebitNoteType = DropDownListDebitNoteMode.SelectedValue;

        //if (RadioButtonListPopupPrice.SelectedValue == ((int)EnumDebitNotePriceMode.ButSay).ToString())
        //{
        //    dND.price = Convert.ToDouble(this.TextBoxButSayValue.Text);
        //    dND.isDiscount = false;
        //}
        //else
        //{
        //    dND.price = Convert.ToDouble(LabelSumPrice.Text);
        //    dND.isDiscount = true;
        //}

        //if (String.IsNullOrEmpty(dND.debitNoteNum))
        //{
        //    dND.status = "1";
        //}
        //else
        //{
        //    dND.status = "2";
        //}

        //dND.isCancel = false;

        return dND;
    }



    protected void ButtonCreate_Click(object sender, EventArgs e)
    {
        //if (checkRepeatNo()) return;
        DebitNoteDto dND = getDebitNoteCoreDto();
        TimeEntryInfo core = new TimeEntryInfo();
        core.editMattercore(dND);
        //dNI.addDebitNoteCore(dND);
        //dNI.addDebitNoteCostAndDisbursement();
        //setDebitNoteNarrative();
        MaterItem db = new MaterItem();
        db.deleteDebitNoteAttachmentsAll(new Guid(SessionClass.Debitnoteid));
        uploadAtt();
        redirectPageAndDisplayAlert("ok!", "../Common/Welcome.aspx");
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
    }

    private void setInitPriceControl()
    {
        this.TextBoxButSayValue.Text = "";
        this.TextBoxButSayValue.Enabled = false;
        RadioButtonListPopupPrice.SelectedIndex = 0;
    }


    //private void setDebitNoteNarrative()
    //{
    //    int i;

    //    for (i = 0; i < this.GridViewTimeEnrty.Rows.Count; i++)
    //    {
    //        if (((CheckBox)GridViewTimeEnrty.Rows[i].FindControl("CheckBoxTarEntry")).Checked)
    //        {
    //            int matterDetailsId = Convert.ToInt16(GridViewTimeEnrty.DataKeys[i].Value);
    //            MatterDetailDto mDD = tEI.getMatterDetailsByDetailsId(matterDetailsId);
    //            dNI.addDebitNoteNarrative(mDD);
    //            tEI.editTimeEntryIsUsed(mDD);
    //        }
    //    }
    //}

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
        uploadAtt(FileUploadAttachment1);
        uploadAtt(FileUploadAttachment2);
        uploadAtt(FileUploadAttachment3);
        uploadAtt(FileUploadAttachment4);
        uploadAtt(FileUploadAttachment5);
    }

    private void uploadAtt(FileUpload myFL)
    {
        if (myFL.HasFile)
        {
            Random rm = new Random();
            string tempFileName = String.Format("{0:yyyyMMdd}", DateTime.Now) + "_" + (rm.Next(100000, 999999)).ToString() + "_" + System.IO.Path.GetFileName(myFL.FileName);
            string divPathName = String.Format("~/Attachment/{0}/{1}", mI.findMatterNum(), dNI.countDebitNoteVer());
            string filePath = String.Format("{0}/{1}", divPathName, tempFileName);
            string divPath = HttpContext.Current.Server.MapPath(divPathName);
            string savePath = HttpContext.Current.Server.MapPath(filePath);
            if (!System.IO.Directory.Exists(divPath))
            {
                System.IO.Directory.CreateDirectory(divPath);
            }
            myFL.SaveAs(savePath);
            dNI.editDebitNoteAttachment(filePath);
        }
    }

    private double getMatterDiscount()
    {
        double discount = 1;
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
        initTab(2);
        TabContainerDebitNoteCore.ActiveTabIndex = 1;
    }
    protected void ButtonCostNext_Click(object sender, EventArgs e)
    {
        initTab(3);
        TabContainerDebitNoteCore.ActiveTabIndex = 2;
    }
    protected void ButtonDisbursementNext_Click(object sender, EventArgs e)
    {
        initTab(4);
        TabContainerDebitNoteCore.ActiveTabIndex = 3;
    }
    protected void ButtonNarrativeNext_Click(object sender, EventArgs e)
    {
        initTab(5);
        TabContainerDebitNoteCore.ActiveTabIndex = 4;
        ButtonCreate.Visible = true;
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        LabelSumPrice.Text = String.Format("{0}", dNI.getDebitNoteDisplayPrice(getMatterDiscount()));
        ModalPopupExtenderPrice.Show();
    }
    protected void ButtonPriceCreate_Click(object sender, EventArgs e)
    {
        ModalPopupExtenderPrice.Hide();
        initTab(5);
        TabContainerDebitNoteCore.ActiveTabIndex = 4;
        ButtonCreate.Visible = true;
    }
    protected void ButtonPriceCannel_Click(object sender, EventArgs e)
    {
        setInitPriceControl();
        ModalPopupExtenderPrice.Hide();
    }
    public string findNarrative()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(SQLHelper.whereGuid(DatabaseConst.DebitNoteNarrative.debitNoteId, SessionClass.Debitnoteid));


        return sb.ToString();
    }
    protected void EntityDataSourceNarrative_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = findNarrative();
    }
    protected void EntityDataSourceCost_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(SQLHelper.whereGuid(DatabaseConst.DebitNoteCost.debitNoteId, SessionClass.Debitnoteid));
        e.DataSource.Where = sb.ToString();

    }
    protected void EntityDataSourceDisbursement_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(SQLHelper.whereGuid(DatabaseConst.DebitNoteDisbursement.debitNoteId, SessionClass.Debitnoteid));
        e.DataSource.Where = sb.ToString();

    }
    protected void Buttonedit_Click(object sender, EventArgs e)
    {
        redirectPage(Request.Url.AbsolutePath + "?edit=1");


    }
    protected void GridViewcostedit_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
    }
}