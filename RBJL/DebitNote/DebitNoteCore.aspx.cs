using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class DebitNote_DebitNoteCore : CultureEnabledPage
{

    public MaterItem mI = new MaterItem();
    MatterInfo mII = new MatterInfo();
    DebitNoteInfo dNI = new DebitNoteInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(1);", true);
        initControl();
        if (!IsPostBack)
        {
            var debitNoteId = Request[QueryStringConst.matter];
            if (debitNoteId != null)
            {
                HiddenFieldMatterNum.Value = dNI.getMatterNumByDebitNoteId(debitNoteId);
                HiddenFieldDebitNoteType.Value = dNI.getDebitNoteCategoryByDebitNoteId(debitNoteId);
            }
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceDebitNoteAttachment.ContextType = EntityDataSourceDebitNoteNarrative.ContextType = EntityDataSourceDebitNoteDisursement.ContextType = EntityDataSourceDebitNoteMisc.ContextType = EntityDataSourceDebitNoteCost.ContextType = EntityDataSourceDebitNoteCore.ContextType = EntityDataSourceDebitNoteCore.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }



    protected void EntityDataSourceDebitNoteCore_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = SQLHelper.whereGuid(DatabaseConst.id, Request[QueryStringConst.matter]);
    }
    protected void EntityDataSourceDebitNoteCost_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        debitNoteDetailsQuery(e);
    }
    protected void EntityDataSourceDebitNoteMisc_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        debitNoteDetailsQuery(e);
    }
    protected void EntityDataSourceDebitNoteDisursement_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        debitNoteDetailsQuery(e);
    }
    protected void EntityDataSourceDebitNoteNarrative_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        debitNoteDetailsQuery(e);
    }
    protected void EntityDataSourceDebitNoteAttachment_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        debitNoteDetailsQuery(e);
    }

    private void debitNoteDetailsQuery(EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = SQLHelper.whereGuid("debitNoteId", Request[QueryStringConst.matter]);
    }

    private void initControl()
    {
        if (!IsPostBack)
        {
            var rlt = mI.getAttachmentsAll(new Guid(Request[QueryStringConst.matter]));
            int cnt = rlt.Count<string>();
            int i = 1;
            foreach (string item in rlt)
            {
                HyperLink hl = Page.Master.FindControl("contentplaceholdermaincontent").FindControl("TabContainerDebitNoteCore").FindControl("TabPanelAttachment").FindControl(String.Format("HyperLinkAttachment{0}", i)) as HyperLink;
                hl.Text = Resources.LanguagePack.DebitNoteCoreDownload;
                hl.Target = "_blank";
                hl.NavigateUrl = item;
                i++;
            }


            if (mI.userLevel == EnumUserLevel.administrator || mI.userLevel == EnumUserLevel.account)
            {
                ButtonDebitNoteDelete.Visible = true;
            }
        }
    }

    public string setDebitNoteStatus(object item)
    {
        string result = "";
        int type = Convert.ToInt16(item);
        switch (type)
        {
            case 1: result = "Interim Debit Note"; break;
            case 2: result = "Renewal"; break;
            case 3: result = "Maintenance Debit Note"; break;
            case 4: result = "Final"; break;
            default: break;
        }

        return result;
    }
    protected void ButtonDebitNoteDelete_Click(object sender, EventArgs e)
    {
        var debitNoteId = Request[QueryStringConst.matter];
        DebitNoteInfo dNI = new DebitNoteInfo();
        bool doWork = dNI.delAllDebitNoteRecords(debitNoteId);
        if (doWork)
        {
            redirectPageAndDisplayAlert("Delete Record OK!", "DebitNote.aspx");
        }
        else
        {
            redirectPageAndDisplayAlert("Delete Record Error!!!", "DebitNote.aspx");
        }
    }

    protected void DetailsViewDebitNoteCore_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        var debitNoteNum = Convert.ToString(e.NewValues[DatabaseConst.DebitNoteCore.debitNoteNum]);

        var debitNoteNumOld = Convert.ToString(e.OldValues[DatabaseConst.DebitNoteCore.debitNoteNum]);

        if (mI.userLevel == EnumUserLevel.administrator)
        {
            if (debitNoteNum != debitNoteNumOld)
            {
                string category = Convert.ToString(HiddenFieldDebitNoteType.Value);

                var checkingPass = mII.checkingCntDebitNoteNum(debitNoteNum, category);
                if (checkingPass)
                {
                    if (!String.IsNullOrEmpty(debitNoteNum))
                    {

                    }
                    else
                    {
                        e.Cancel = true;
                        displayAlert("Please Enter Debit Note No.");
                        return;
                    }
                }

                else
                {
                    e.Cancel = true;
                    displayAlert("Debit Note No. is already exists!");
                    return;
                }
            }
        }


        if (mI.userLevel != EnumUserLevel.administrator)
        {
            e.NewValues[DatabaseConst.DebitNoteCore.debitNoteNum] = e.OldValues[DatabaseConst.DebitNoteCore.debitNoteNum];
        }

        e.NewValues[DatabaseConst.DebitNoteCore.version] = (Convert.ToInt16(e.OldValues[DatabaseConst.DebitNoteCore.version]) + 1).ToString();
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
    }
    protected void DetailsViewDebitNoteCore_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        displayAlert("ok");
    }
    protected void ButtonExcel_Click(object sender, EventArgs e)
    {
        popup("../Report/exportDebitNote.aspx?debitNoteId=" + Request[QueryStringConst.matter]);
    }

    protected void ButtonViewReport_Click(object sender, EventArgs e)
    {
        popup("../Report/DebitNoteMainReportView.aspx?debitNoteId=" + Request[QueryStringConst.matter]);
    }

    protected void ButtonViewReport2_Click(object sender, EventArgs e)
    {
        popup("../Report/DebitNoteMainReportView.aspx?debitNoteId=" + Request[QueryStringConst.matter]+"&mustShow=true");
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
        }
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

    private void saveTempFile(string tarFile, byte[] tarByteArr)
    {
        if (!String.IsNullOrEmpty(tarFile))
        {
            var debitNoteId = Request[QueryStringConst.matter];
            var getMauuterNum = HiddenFieldMatterNum.Value;
            if (String.IsNullOrEmpty(getMauuterNum))
            {
                getMauuterNum = "temp";
            }

            Random rm = new Random();
            //string tempFileName = String.Format("{0:yyyyMMdd}", DateTime.Now) + "_" + (rm.Next(100000, 999999)).ToString() + "_" + System.IO.Path.GetFileName(tarFile);
            string tempFileName = System.IO.Path.GetFileName(tarFile);
            string divPathName = String.Format("~/Attachment/{0}/{1}", replaceIllegalCharacters(getMauuterNum), debitNoteId);
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
                divPathName = String.Format("~/Attachment/{0}/{1}", replaceIllegalCharacters(getMauuterNum), debitNoteId);
                filePath = String.Format("{0}/{1}", divPathName, tempFileName);
                divPath = HttpContext.Current.Server.MapPath(divPathName);
                savePath = HttpContext.Current.Server.MapPath(filePath);
            }

            System.IO.File.WriteAllBytes(savePath, tarByteArr);

            dNI.addDebitNoteAttachment(filePath, debitNoteId);
        }
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

    protected void ButtonEditAtt_Click(object sender, EventArgs e)
    {
        PanelAttEdit.Visible = true;
        PanelAttachmentview.Visible = false;

        bindAttData();

    }

    private void bindAttData()
    {
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


        var debitNoteId = Request[QueryStringConst.matter];
        var getFileList = dNI.getAttFilePath(debitNoteId);
        getFileByteArr(getFileList);
    }
    protected void ButtonAttUpdate_Click(object sender, EventArgs e)
    {
        uploadAtt();

        var debitNoteId = Request[QueryStringConst.matter];
        bool doWork = dNI.delDebitNoteAtt(debitNoteId);

        saveTempFile(SessionClass.uploadFileFileNameTemp1, SessionClass.uploadFileTemp1);
        saveTempFile(SessionClass.uploadFileFileNameTemp2, SessionClass.uploadFileTemp2);
        saveTempFile(SessionClass.uploadFileFileNameTemp3, SessionClass.uploadFileTemp3);
        saveTempFile(SessionClass.uploadFileFileNameTemp4, SessionClass.uploadFileTemp4);
        saveTempFile(SessionClass.uploadFileFileNameTemp5, SessionClass.uploadFileTemp5);

        redirectPageAndDisplayAlert("OK", Convert.ToString(Request.Url));
    }
    protected void ButtonAttBack_Click(object sender, EventArgs e)
    {
        redirectCurrentlyPage();
    }


}
