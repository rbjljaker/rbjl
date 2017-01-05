<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="JobType.aspx.cs" Inherits="Master_JobType" %>

<%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<%@ Register Src="~/WebControl/LBLDoworkTitle.ascx" TagName="WebUserControlLBLDoworkTitle"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, JobTypelblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:GridView OnDataBound="GridViewJobType_OnDataBound" RowStyle-CssClass="lineGridviewMaster"
        HeaderStyle-CssClass="lineGridviewMaster" ID="GridViewJobType" runat="server"
        AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSourceJobType"
        PageSize="<%$ appSettings:GridViewPageSize %>" OnRowUpdated="GridViewJobType_RowUpdated"
        OnRowUpdating="GridViewJobType_RowUpdating" CssClass="MasterWidth" ShowHeaderWhenEmpty="True"
        EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>" 
        OnSelectedIndexChanged="GridViewJobType_SelectedIndexChanged" 
        onrowdeleted="GridViewJobType_RowDeleted">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <asp:DynamicField DataField="num" HeaderText="<%$Resources:master,type_num %>" ReadOnly="true"
                ItemStyle-CssClass="tableDC" />
            <asp:DynamicField DataField="name" HeaderText="<%$Resources:master,type_name %>" />
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:Button ID="LinkButtonUpdate" runat="server" CausesValidation="True" CommandName="Update"
                        Text="<%$ Resources:LanguagePack, lblUpdate %>"></asp:Button>
                    &nbsp;<asp:Button ID="LinkButtonCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="<%$ Resources:LanguagePack, lblCancel %>"></asp:Button>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="LinkButtonEditPopup" runat="server" OnClick="LinkButtonEditPopup_Click"
                        CausesValidation="False" Text="<%$ Resources:LanguagePack, lblEdit %>" CommandName="Select" />
                    <%-- <asp:Button ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="<%$ Resources:LanguagePack, lblEdit %>"></asp:Button>--%>
                    &nbsp;<asp:Button ID="LinkButtonDelete" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="<%$ Resources:LanguagePack, lblDelete %>" OnClientClick="<%$ Resources:LanguagePack, DeleteConfirm %>">
                    </asp:Button>
                </ItemTemplate>
                <HeaderTemplate>
                    <asp:Button ID="LinkButtonAdd" runat="server" OnClick="LinkButtonAdd_Click" CausesValidation="False"
                        CssClass="MasterAdd" Text="<%$ Resources:LanguagePack, lblAdd %>" />
                </HeaderTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <uc:ucPaging ID="ucPaging" runat="server" />
        </PagerTemplate>
    </asp:GridView>
    <br />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderInsert" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panAdd" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtenderInsert" runat="server" Title="<%$ Resources:LanguagePack, JobTypeADDItem %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeM %>">
        <Content>--%>
    <asp:Panel ID="panAdd" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDrag" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitle" runat="server" Text="<%$ Resources:LanguagePack, JobTypeADDItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/close.png" CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewCurrency" runat="server" CssClass="masterDe" AutoGenerateRows="False"
            DataKeyNames="id" DataSourceID="EntityDataSourceJobType" DefaultMode="Insert"
            Visible="false" OnItemInserted="DetailsViewCurrency_ItemInserted" OnItemInserting="DetailsViewCurrency_ItemInserting">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="num" HeaderText="<%$Resources:master,type_num %>" />
                <asp:DynamicField DataField="name" HeaderText="<%$Resources:master,type_name %>" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <a id="lnkPopup" runat="server"></a>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEdit" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panEdit" BackgroundCssClass="modalBackground" CancelControlID="btnCancelEdit"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="panEdit" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragEdit" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleEdit" runat="server" Text="<%$ Resources:LanguagePack, JobTypeEditItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancelEdit" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewCurrencyEdit" runat="server" CssClass="masterDe"
            AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourceJobType"
            Visible="false" DefaultMode="Edit" OnItemUpdated="DetailsViewCurrencyEdit_ItemUpdated"
            OnItemUpdating="DetailsViewCurrencyEdit_ItemUpdating">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="num" HeaderText="<%$Resources:master,type_num %>" />
                <asp:DynamicField DataField="name" HeaderText="<%$Resources:master,type_name %>" />
                <asp:CommandField ButtonType="Button" ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <asp:EntityDataSource ID="EntityDataSourceJobType" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="JobTypes">
    </asp:EntityDataSource>
</asp:Content>
