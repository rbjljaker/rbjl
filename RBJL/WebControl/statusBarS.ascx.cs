using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_statusBarS : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        StatusBarHelper sBH = new StatusBarHelper();
        if (sBH.userLevel == EnumUserLevel.GeneralUser || sBH.userLevel == EnumUserLevel.account)
        {
            Page.Master.FindControl("StatusHr1").Visible = false;
            Page.Master.FindControl("StatusHr2").Visible = false;
        }
        else
        {

            //string callFunction = String.Format("setStatusBar({0});", sBH.getStatusBar());
            //ScriptManager.RegisterStartupScript(this, GetType(), "setStatusBar", callFunction, true);

            var getSValue = sBH.getStatusBar();
            string callFunction = String.Format("progressBarS({0},{1}, $('#progressBar'));", getSValue[0], getSValue[1]);
            //string callFunction = String.Format("progressBarS(40,60, $('#progressBar'));");
            ScriptManager.RegisterStartupScript(this, GetType(), "setStatusBar", callFunction, true);

            //string callFunctionBillable = String.Format("progressBar({0}, $('#progressBarBillable'));", sBH.getBillableOrNonBillable());
            //ScriptManager.RegisterStartupScript(this, GetType(), "setStatusBarBillable", callFunctionBillable, true);

            var getBNValue = sBH.getBillableOrNonBillable();
            //string callFunctionBillableByMonth = String.Format("progressBarB(10,90, $('#progressBarBillableByMonth'));");
            string callFunctionBillableByMonth = String.Format("progressBarB({0},{1}, $('#progressBarBillableByMonth'));", getBNValue[0], getBNValue[1]);
            ScriptManager.RegisterStartupScript(this, GetType(), "setStatusBarBillableByMonth", callFunctionBillableByMonth, true);

            //string callFunctionBilled = String.Format("progressBar({0}, $('#progressBarBillable'));", sBH.getBilledByMonth());
            //ScriptManager.RegisterStartupScript(this, GetType(), "setStatusBarBillable", callFunctionBilled, true);

            var callFunctionBilled = sBH.getBilledByMonth();
            LabelValue.Text = callFunctionBilled;
        }

    }


    //public int widthValue { get; set; }



    //public string findWidthValue()
    //{
    //    string result = String.Format("{0}%", widthValue);
    //    return result;
    //}
}