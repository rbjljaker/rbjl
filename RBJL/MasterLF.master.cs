using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using System.Web.Security;
using System.Web.UI.HtmlControls;

public partial class MasterLF : CultureEnabledMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        initUserNmae();

        //HtmlGenericControl setjQMin = new HtmlGenericControl("script");
        //setjQMin.Attributes["type"] = "text/javascript";
        //var uriSetjQMin = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Scripts/jquery-1.9.1.min.js");
        //setjQMin.Attributes["src"] = uriSetjQMin;

        //Page.Header.Controls.Add(setjQMin);

        //HtmlGenericControl setjQUi = new HtmlGenericControl("script");
        //setjQUi.Attributes["type"] = "text/javascript";
        //var uriSetjQUi = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Scripts/jquery-ui-1.10.3.js");
        //setjQUi.Attributes["src"] = uriSetjQUi;

        //Page.Header.Controls.Add(setjQUi);

        //HtmlGenericControl js = new HtmlGenericControl("script");
        //js.Attributes["type"] = "text/javascript";
        //var uri = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Scripts/Timer.js");
        //js.Attributes["src"] = uri;

        //Page.Header.Controls.Add(js);

        //HtmlGenericControl jsStatusBar = new HtmlGenericControl("script");
        //jsStatusBar.Attributes["type"] = "text/javascript";
        //var uriStatusBar = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Scripts/StatusBarS.js");
        //jsStatusBar.Attributes["src"] = uriStatusBar;

        //Page.Header.Controls.Add(jsStatusBar);

        //HtmlGenericControl submitConfirm = new HtmlGenericControl("script");
        //submitConfirm.Attributes["type"] = "text/javascript";
        //var uriSubmitConfirm = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Scripts/SubmitConfirm.js");
        //submitConfirm.Attributes["src"] = uriSubmitConfirm;

        //Page.Header.Controls.Add(submitConfirm);

        //HtmlGenericControl checkAll = new HtmlGenericControl("script");
        //checkAll.Attributes["type"] = "text/javascript";
        //var uricheckAll = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Scripts/checkBoxSelect.js");
        //checkAll.Attributes["src"] = uricheckAll;

        //Page.Header.Controls.Add(checkAll);


        //HtmlGenericControl setMenu = new HtmlGenericControl("script");
        //setMenu.Attributes["type"] = "text/javascript";
        //var uriSetMenu = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Scripts/setMenu.js");
        //setMenu.Attributes["src"] = uriSetMenu;

        //Page.Header.Controls.Add(setMenu);

        //HtmlGenericControl setMouseOver = new HtmlGenericControl("script");
        //setMouseOver.Attributes["type"] = "text/javascript";
        //var uriSetMouseOver = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Scripts/mouseOverSearch.js");
        //setMouseOver.Attributes["src"] = uriSetMouseOver;

        //Page.Header.Controls.Add(setMouseOver);

        //HtmlGenericControl setMaster = new HtmlGenericControl("script");
        //setMaster.Attributes["type"] = "text/javascript";
        //var uriSetMaster = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/Scripts/master.js");
        //setMaster.Attributes["src"] = uriSetMaster;

        //Page.Header.Controls.Add(setMaster);



        var logout = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/roleRedirector.ashx?link=logout");
        logoutControl.HRef = logout;


        if (!IsPostBack)
        {

            //SessionClass.autoCompleteColumn = null;
        }
    }


    private void initUserNmae()
    {
        DBEntity de = new DBEntity();

        if (de.currentUser != null)
        {
            lblUser.Text = String.Format("{0}", de.currentUser.UserName);
            LabelNickName.Text = String.Format("{0}", de.tarUser.nickName);
        }
    }

    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        ClearSession.clearSearch();
        for (int i = 0; i < CheckBoxListSearch.Items.Count; i++)
        {
            if (CheckBoxListSearch.Items[i].Selected)
            {
                switch (i)
                {
                    case (int)EnumSearchBy.ByMatterNum:
                        SessionClass.SearchByMatterNum = TextBoxSearch.Text;
                        break;
                    case (int)EnumSearchBy.ByKeywords:
                        SessionClass.SearchByKeywords = TextBoxSearch.Text;
                        break;
                    case (int)EnumSearchBy.ByClientName:
                        SessionClass.SearchByClientName = TextBoxSearch.Text;
                        break;
                    case (int)EnumSearchBy.ByJobType:
                        SessionClass.SearchByJobType = TextBoxSearch.Text;
                        break;
                    //case (int)EnumSearchBy.ByCountry:
                    //    SessionClass.SearchByCountry = TextBoxSearch.Text;
                    //    break;
                    //case (int)EnumSearchBy.ByClass:
                    //    SessionClass.SearchByClass = TextBoxSearch.Text;
                    //    break;
                    case (int)EnumSearchBy.ByReferer:
                        SessionClass.SearchByReferer = TextBoxSearch.Text;
                        break;
                    //case (int)EnumSearchBy.ByApplicationNum:
                    //    SessionClass.SearchByApplicationNum = TextBoxSearch.Text;
                    //    break;
                    //case (int)EnumSearchBy.ByRegistrationNum:
                    //    SessionClass.SearchByRegistrationNum = TextBoxSearch.Text;
                    //    break;
                    case (int)EnumSearchBy.BySubject:
                        SessionClass.SearchBySubject = TextBoxSearch.Text;
                        break;
                }
            }
        }

        Response.Redirect("~/Matter/New.aspx?search=T");
    }
    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/roleRedirector.ashx?link=logout");
    }
    protected void CheckBoxListSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        int numSelected = 0;
        int? tarValue = null;

        for (int i = 0; i < CheckBoxListSearch.Items.Count; i++)
        {
            if (CheckBoxListSearch.Items[i].Selected)
            {
                numSelected++;
                tarValue = i;
            }
        }

        if (numSelected == 1)
        {
            SessionClass.autoCompleteColumn = tarValue.Value;
        }
        else
        {
            SessionClass.autoCompleteColumn = null;
        }

    }
}
