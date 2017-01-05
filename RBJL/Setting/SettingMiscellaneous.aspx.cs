using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Admin_SettingMiscellaneous : CultureEnabledPage, IPageInterface
{
    MiscellaneousSetting ms = new MiscellaneousSetting();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(5);", true);
        if (!IsPostBack)
        {
            setValue(TextBoxClientNoStartFrom, CheckBoxClientNoStartFrom, (int)EnumMiscellaneous.clientNum);
            setValue(TextBoxMatterNoStartFrom, CheckBoxMatterNoStartFrom, (int)EnumMiscellaneous.MatterNum);
            setValue(TextBoxDebitNoteNoStartFrom, CheckBoxDebitNoteNoStartFrom, (int)EnumMiscellaneous.DebitNoteNum);

            TextBoxAccountEmail.Text = ms.getData((int)EnumMiscellaneous.AccountEmail).numberValue;
            txtComments.Text = ms.getData((int)EnumMiscellaneous.WhatsNews).numberValue;
        }
    }

    public void DoAction()
    {
        List<SettingMiscellaneousDto> smdList = new List<SettingMiscellaneousDto>();
        smdList.Add(new SettingMiscellaneousDto() { id = (int)EnumMiscellaneous.clientNum, dataValue = TextBoxClientNoStartFrom.Text, isGen = CheckBoxClientNoStartFrom.Checked });
        smdList.Add(new SettingMiscellaneousDto() { id = (int)EnumMiscellaneous.MatterNum, dataValue = TextBoxMatterNoStartFrom.Text, isGen = CheckBoxMatterNoStartFrom.Checked });
        smdList.Add(new SettingMiscellaneousDto() { id = (int)EnumMiscellaneous.DebitNoteNum, dataValue = TextBoxDebitNoteNoStartFrom.Text, isGen = CheckBoxDebitNoteNoStartFrom.Checked });
        smdList.Add(new SettingMiscellaneousDto() { id = (int)EnumMiscellaneous.WhatsNews, dataValue = txtComments.Text, isGen = false });
        smdList.Add(new SettingMiscellaneousDto() { id = (int)EnumMiscellaneous.AccountEmail, dataValue = TextBoxAccountEmail.Text, isGen = false });
        foreach (var smd in smdList)
        {
            ms.setData(smd);
        }
    }

    public void DoCancel()
    {
        redirectPage(Request.Url.ToString());
    }

    private void setValue(TextBox tb, CheckBox cb, int id)
    {
        tb.Text = ms.getData(id).numberValue;
        cb.Checked = ms.getData(id).isAutoGen;
        string temp = genNewId(Convert.ToInt64(ms.getData(id).numberValue));
    }
    protected void ButtonAction_Click(object sender, EventArgs e)
    {
        DoAction();
        displayAlert("ok");
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        DoCancel();
    }
}