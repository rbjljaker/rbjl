using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControl_lblDebitNoteStatus : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string statusId { get; set; }



    public string findDebitNoteStatus()
    {
        string result = "";

        if (statusId != null)
        {
            switch (statusId)
            {
                case "1": result = "Interim Debit Note"; break;
                case "2": result = "Renewal"; break;
                case "3": result = "Maintenance Debit Note"; break;
                case "4": result = "Final"; break;
                default: break;
            }
        }
        return result;
    }

}