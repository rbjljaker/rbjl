using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageUtilities;

public partial class Master_Template : CultureEnabledPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "setMenu", "setCurrMenu(3);", true);
        if (!IsPostBack)
        {
            GridViewTemplateType.DataBind();
            GridViewTemplateDetails.DataBind();
        }
        else
        {
            GridviewHelper myGridHelper = new GridviewHelper();
            myGridHelper.GridPaging(GridViewTemplateType, e);
            GridviewHelper myGridHelperTemplateDetails = new GridviewHelper();
            myGridHelperTemplateDetails.GridPaging(GridViewTemplateDetails, e);
        }
    }
    protected void GridViewTemplateType_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }

    protected void GridViewTemplateDetails_OnDataBound(object sender, EventArgs e)
    {
        GridviewHelper myGridHelper = new GridviewHelper();
        myGridHelper.GridPaging(sender, e);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        EntityDataSourceTemplateTypeEdit.ContextType = EntityDataSourceTemplateDetailsEdit.ContextType = EntityDataSourceTemplateType.ContextType = EntityDataSourceTemplateDetails.ContextType = typeof(RBJLLawFirmDBModel.RBJLLawFirmDBEntities);
    }
    protected void LinkButtonAdd_Click(object sender, EventArgs e)
    {
        DetailsViewTemplate.Visible = true;
        ModalPopupExtender1.Show();
    }

    protected void LinkButtonAddDetails_Click(object sender, EventArgs e)
    {
        DetailsViewTemplateDetails.Visible = true;
        ModalPopupExtender2.Show();
    }

    protected void DetailsViewTemplate_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }
    protected void DetailsViewTemplateDetails_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        redirectPageAndDisplayAlert("OK", Request.Url.AbsolutePath);
    }
    protected void DetailsViewTemplateDetails_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
        {
            redirectCurrentlyPage();
        }
    }
    protected void DetailsViewTemplate_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
        {
            redirectCurrentlyPage();
        }
    }

    protected void DetailsViewTemplate_OnItemInserting(object sender, DetailsViewInsertEventArgs e)
    {

        MatterInfo mI = new MatterInfo();
        e.Values[DatabaseConst.createDate] = DateTime.Now;
        e.Values[DatabaseConst.createByUserId] = mI.userGuid;

        e.Values[DatabaseConst.updateDate] = DateTime.Now;
        e.Values[DatabaseConst.updateByUserId] = mI.userGuid;

    }
    protected void DetailsViewTemplateDetails_OnItemInserting(object sender, DetailsViewInsertEventArgs e)
    {

        MatterInfo mI = new MatterInfo();
        e.Values[DatabaseConst.createDate] = DateTime.Now;
        e.Values[DatabaseConst.createByUserId] = mI.userGuid;

        e.Values[DatabaseConst.updateDate] = DateTime.Now;
        e.Values[DatabaseConst.updateByUserId] = mI.userGuid;

    }

    protected void GridViewTemplateType_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        MatterInfo mI = new MatterInfo();
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;

    }
    protected void GridViewTemplateDetails_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        MatterInfo mI = new MatterInfo();
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;

    }




    protected void GridViewTemplateType_OnRowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        displayAlert("OK");
    }
    protected void GridViewTemplateDetails_OnRowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        displayAlert("OK");
    }


    protected void LinkButtonEditPopup_Click(object sender, EventArgs e)
    {
        DetailsViewTypeEdit.Visible = true;
        ModalPopupExtenderTypeEdit.Show();

    }


    protected void LinkButtonEditPopupDeta_Click(object sender, EventArgs e)
    {
        DetailsViewDeEdit.Visible = true;
        ModalPopupExtenderDeEdit.Show();

    }
    protected void DetailsViewTypeEdit_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        MatterInfo mI = new MatterInfo();
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;
    }
    protected void DetailsViewTypeEdit_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        displayAlert("OK");
    }
    protected void DetailsViewDeEdit_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        MatterInfo mI = new MatterInfo();
        e.NewValues[DatabaseConst.updateDate] = DateTime.Now;
        e.NewValues[DatabaseConst.updateByUserId] = mI.userGuid;
    }
    protected void DetailsViewDeEdit_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        displayAlert("OK");
    }
    protected void GridViewTemplateType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Control ctl = e.CommandSource as Control;
            GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;

            string feeTpye;
            feeTpye = GridViewTemplateType.DataKeys[CurrentRow.RowIndex].Value.ToString();
            EntityDataSourceTemplateTypeEdit.Where = "it.id =" + feeTpye;
            EntityDataSourceTemplateTypeEdit.DataBind();
            DetailsViewTypeEdit.DataBind();
        }
    }

    protected void GridViewTemplateDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Control ctl = e.CommandSource as Control;
            GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;

            string feeTpye;
            feeTpye = GridViewTemplateDetails.DataKeys[CurrentRow.RowIndex].Value.ToString();
            EntityDataSourceTemplateDetailsEdit.Where = "it.id =" + feeTpye;
            EntityDataSourceTemplateDetailsEdit.DataBind();
            DetailsViewDeEdit.DataBind();
        }

    }

    protected void GridViewTemplateType_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            displayAlert("ok");
        }
        else
        {
            displayAlert("An error occurred while attempting to delete the row.");
            e.ExceptionHandled = true;
        }
    }

    protected void GridViewTemplateDetails_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            displayAlert("ok");
        }
        else
        {
            displayAlert("An error occurred while attempting to delete the row.");
            e.ExceptionHandled = true;
        }
    }
}