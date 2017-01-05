using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

using System.Globalization;
using RBJLLawFirmDBModel;



public partial class Log_UserLog : CultureEnabledPage
{

    private void GridViewLog_bind()
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(4);", true);
        if (DropDownListUserName.SelectedValue != "")
        {
            MaterItem dbConn = new MaterItem();
            GridViewLog.DataSource = dbConn.getUserLog(TextBoxDate.Text, new Guid(DropDownListUserName.SelectedValue));
            GridViewLog.DataBind();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewLog_bind();
    }

    protected void GridViewLog_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewLog.PageIndex = e.NewPageIndex;//更改当前页
        GridViewLog_bind();
    }

    protected void Button_search_Click(object sender, EventArgs e)
    {
    }


    private void search()
    {

    }

    protected void GridViewLog_DataBound(object sender, EventArgs e)
    {
        if (DropDownListUserName.SelectedValue != "")
        {


            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(sender, e);

        }
    }

    protected void EntityDataSourceUserName_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        //LogEvent le = new LogEvent();

        //if (le.userLevel != EnumUserLevel.administrator)
        //{
        //    e.DataSource.Where = SQLHelper.whereGuid("UserId", le.userGuid);
        //}
    }
    protected void EntityDataSourceUserName_QueryCreated(object sender, QueryCreatedEventArgs e)
    {
        LogEvent le = new LogEvent();

        if (le.userLevel != EnumUserLevel.administrator)
        {
            IQueryable<View_UserInfo> ui = e.Query.Cast<View_UserInfo>();
            var checking = ui.Where(p => p.UserId == le.userGuid);
            e.Query = checking;
        }
    }
}