using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;
using RBJLLawFirmDBModel;


public partial class Matter_New : CultureEnabledPage
{
    MatterInfo mI = new MatterInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(0);", true);
        if (Request["search"] == null)
        {
            ClearSession.clearSearch();
        }

        LabelSearch.Text = MatterInfo.findCurrMatterSessionText();

        GridViewMatter.Columns[1].Visible = false;


        string isTimeEntry = Request.QueryString["timeEntry"];
        string isCheckCType = Request.QueryString[QueryStringConst.mCType];
        if (isTimeEntry != null || isCheckCType != null)
        {
            GridViewMatter.Columns[1].Visible = true;
            GridViewMatter.Columns[6].Visible = false;
            HyperLinkNewFollowUp.Visible = false;
            PanelMoveOrCopyMatter.Visible = true;
        }


        //if (EnumUserLevel.GeneralUser == mI.userLevel)
        //{
        //    HyperLinkNewFollowUp.Visible = false;
        //}


        if (!IsPostBack)
        {

        }
        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridViewMatter, e);
        }

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceMatter.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }
    protected void GridViewMatter_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //SessionClass.MatterId = Convert.ToString(GridViewMatter.DataKeys[rowIndex].Value);
            popup(String.Format("MatterCore.aspx?type={0}&matter={1}", (short)MatterTab.TimeEntry, Convert.ToString(GridViewMatter.DataKeys[rowIndex].Value)));
        }

        if (e.CommandName == "MatterNum")
        {
            //SessionClass.MatterId = Convert.ToString(e.CommandArgument);
            popup(String.Format("MatterCore.aspx?type={0}&matter={1}", (short)MatterTab.General, Convert.ToString(e.CommandArgument)));
        }
        if (e.CommandName == "Client")
        {
            //SessionClass.MatterId = Convert.ToString(e.CommandArgument);
            popup(String.Format("MatterCore.aspx?type={0}&matter={1}", (short)MatterTab.Client, Convert.ToString(e.CommandArgument)));
        }


        if (e.CommandName == "Copy")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            string MatterId = Convert.ToString(GridViewMatter.DataKeys[rowIndex].Value);
            Response.Redirect("NewMatterAdd.aspx?matterid=" + MatterId);
        }
        if (e.CommandName == "CopyTo")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            string MatterId = Convert.ToString(GridViewMatter.DataKeys[rowIndex].Value);

            doMoveOrCopy(MatterId);
        }
    }
    protected void EntityDataSourceMatter_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {
        e.DataSource.Where = mI.findCurrMatterAdmin();
        //if (EnumUserLevel.administrator == mI.userLevel || EnumUserLevel.account == mI.userLevel)
        //{
        //    e.DataSource.Where = mI.findCurrMatterAdmin();
        //}
        //else
        //{
        //    e.DataSource.Where = mI.findCurrMatter();
        //}
    }
    protected void EntityDataSourceMatter_QueryCreated(object sender, QueryCreatedEventArgs e)
    {
        if (EnumUserLevel.administrator == mI.userLevel || EnumUserLevel.account == mI.userLevel)
        {
        }
        else
        {
            var tarList = mI.findMatterTarUserList();
            IQueryable<View_FindMatter> vF = e.Query.Cast<View_FindMatter>() as IQueryable<View_FindMatter>;
            var result = from q in vF
                         where tarList.Contains(q.id) || q.releaseToPublic == true
                         select q;
            e.Query = result;
        }


    }
    protected void GridViewMatter_RowCreated(object sender, GridViewRowEventArgs e)
    {
    }
    //protected void LinkButtonCopyFrom_onclick(object sender, EventArgs e)
    //{
    //    GridViewMatter.Columns[1].Visible = true;
    //    GridViewMatter.Columns[6].Visible = false;

    //}
    protected void HyperLinkNewFollowUp_OnClick(object sender, EventArgs e)
    {
        popup("NewFollowUp.aspx?matter=EE28CD2C-D1C3-45A7-B315-42BAEBF6F830");
    }

    protected void ButtonNewMatter_Click(object sender, EventArgs e)
    {
        redirectPage("NewMatterAdd.aspx");
    }
    protected void ButtonDraftTimeEntry_Click(object sender, EventArgs e)
    {
        redirectPage("PendingListTimeEntry.aspx");
    }
    protected void GridViewMatter_DataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }


    public string showString(object tar)
    {
        return StringHelper.setSubSttring(tar);
    }

    private void doMoveOrCopy(string MatterId)
    {
        TimeEntryInfo ti = new TimeEntryInfo();
        //SessionClass.MatterId = MatterId;

        //bool checkingFeeEarner = false;

        string isCheckCType = Request.QueryString[QueryStringConst.mCType];

        if (isCheckCType != null)
        {
            var getTarMatterDedtailsId = Request.QueryString[QueryStringConst.details];
            var tarArr = getTarMatterDedtailsId.Split(',');

            //var checkAllFeeEarner = true;
            var matterDetailsCore = ti.getMatterAndFeeEarner;

            foreach (string idItem in tarArr)
            {
                var tarEntry = ti.getEntityById(Convert.ToInt32(idItem));
                var tar = ti.checkUserAndMatter(MatterId, tarEntry.feeEarner.Value, matterDetailsCore);
                if (tar == null)
                {
                    //checkAllFeeEarner = false;
                    displayAlert("Without this Fee Earner");
                    return;
                }
                else
                {

                }
            }
            foreach (string idItem in tarArr)
            {
                int matterDetailsId = Convert.ToInt32(idItem);
                var tarEntry = ti.getEntityById(matterDetailsId);
                var tar = ti.checkUserAndMatter(MatterId, tarEntry.feeEarner.Value, matterDetailsCore);
                MatterDetailDto timeEntry = ti.getMatterDetailsByDetailsId(matterDetailsId);
                timeEntry.matterId = Guid.Parse(MatterId);
                timeEntry.itemNum = mI.findTimeEntryCount(timeEntry.matterId) + 1;
                timeEntry.hourlyRateH = tar.hourlyRate.Value;

                if (isCheckCType == "M")
                {
                    ti.addMatterDetailByDTE(timeEntry, matterDetailsId);
                }
                else if (isCheckCType == "C")
                {
                    mI.addMatterDetailByCopyOrMove(timeEntry);
                }
                redirectPageAndDisplayAlert("ok", "New.aspx");
            }
        }

        else
        {
            MatterDetailDto timeEntry = SessionClass.timeEntry;

            var tar = ti.checkUserAndMatter(MatterId, timeEntry.feeEarner);
            if (tar == null)
            {
                displayAlert("Without this Fee Earner");
            }
            else
            {
                string isTimeEntry = Request.QueryString["timeEntry"];

                timeEntry.matterId = Guid.Parse(MatterId);
                timeEntry.itemNum = mI.findTimeEntryCount(timeEntry.matterId) + 1;
                //if (timeEntry.hourlyRateH == null || timeEntry.hourlyRateH == 0)
                //{
                //    timeEntry.hourlyRateH = tar.hourlyRate.Value;
                //}
                timeEntry.hourlyRateH = tar.hourlyRate.Value;
                if (isTimeEntry == "moveto")
                {
                    ti.delMatterDetails(int.Parse(SessionClass.MatterDetailId));
                }
                if (isTimeEntry == "movetoDTE")
                {
                    ti.addMatterDetailByDTE(timeEntry);
                }
                else
                {
                    mI.addMatterDetailByCopyOrMove(timeEntry);
                }
                redirectPageAndDisplayAlert("ok", "New.aspx");
            }
        }


    }


    protected void ButtonMoveOrCopyMatter_Click(object sender, EventArgs e)
    {
        var mess = "Please enter matter no.";
        var getMatterNum = TextBoxMoveOrCopyMatter.Text;
        if (String.IsNullOrEmpty(getMatterNum))
        {
            displayAlert(mess);
            return;
        }

        var getMatterId = mI.getMatterIdByMatterNum(getMatterNum);
        if (!getMatterId.HasValue)
        {
            var mess1 = "Without this matter no.";
            displayAlert(mess1);
        }
        else
        {
            string matterId = getMatterId.Value.ToString();
            doMoveOrCopy(matterId);
        }
    }
}