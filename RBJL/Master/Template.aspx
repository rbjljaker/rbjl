<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="Template.aspx.cs" Inherits="Master_Template" %>

<%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<%@ Register Src="~/WebControl/LBLDoworkTitle.ascx" TagName="WebUserControlLBLDoworkTitle"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, TemplatelblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <div class="Tab">
        <ajaxToolkit:TabContainer ID="TabContainerTemplate" runat="server" ActiveTabIndex="0">
            <ajaxToolkit:TabPanel ID="TabPanelTemplateType" runat="server" HeaderText="<%$ Resources:LanguagePack, TemplateTabT %>">
                <ContentTemplate>
                    <asp:GridView OnRowUpdated="GridViewTemplateType_OnRowUpdated" OnDataBound="GridViewTemplateType_OnDataBound"
                        ID="GridViewTemplateType" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                        DataSourceID="EntityDataSourceTemplateType" AllowPaging="True" PageSize="<%$ appSettings:GridViewPageSize %>"
                        OnRowUpdating="GridViewTemplateType_OnRowUpdating" CssClass="MasterWidth" ShowHeaderWhenEmpty="True"
                        EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>" OnRowCommand="GridViewTemplateType_RowCommand" onrowdeleted="GridViewTemplateType_RowDeleted">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                Visible="False" />
                            <asp:DynamicField DataField="typeName" HeaderText="<%$ Resources:LanguagePack, TemplateTpyeCore %>"
                                ItemStyle-CssClass="nameWidth" />
                            <asp:DynamicField DataField="typeDescription" HeaderText="<%$ Resources:LanguagePack, TemplateTpyeDesc %>" />
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
                                    <%--    <asp:Button ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandName="Edit"
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
                        <HeaderStyle CssClass="lineGridviewMaster" />
                        <PagerTemplate>
                            <uc:ucPaging ID="ucPaging" runat="server" />
                        </PagerTemplate>
                        <RowStyle CssClass="lineGridviewMaster" />
                    </asp:GridView>
                    <br />
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelTemplateDetails" runat="server" HeaderText="<%$ Resources:LanguagePack, TemplateTabD %>">
                <ContentTemplate>
                    <asp:GridView OnRowUpdated="GridViewTemplateDetails_OnRowUpdated" OnDataBound="GridViewTemplateDetails_OnDataBound"
                        RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster"
                        ID="GridViewTemplateDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="id" DataSourceID="EntityDataSourceTemplateDetails" PageSize="<%$ appSettings:GridViewPageSize %>"
                        OnRowUpdating="GridViewTemplateDetails_OnRowUpdating" CssClass="MasterWidth"
                        ShowHeaderWhenEmpty="True" EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>"
                        OnRowCommand="GridViewTemplateDetails_RowCommand" onrowdeleted="GridViewTemplateDetails_RowDeleted">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                Visible="False" />
                            <asp:DynamicField DataField="TemplateType" HeaderText="<%$ Resources:LanguagePack, TemplateTabT %>"
                                ItemStyle-CssClass="nameWidth" />
                            <asp:DynamicField DataField="detailsDescription" HeaderText="<%$ Resources:LanguagePack, TemplateTpyeDesc %>" />
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:Button ID="LinkButtonUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="<%$ Resources:LanguagePack, lblUpdate %>"></asp:Button>
                                    &nbsp;<asp:Button ID="LinkButtonCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="<%$ Resources:LanguagePack, lblCancel %>"></asp:Button>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="LinkButtonEditPopupDeta" runat="server" OnClick="LinkButtonEditPopupDeta_Click"
                                        CausesValidation="False" Text="<%$ Resources:LanguagePack, lblEdit %>" CommandName="Select" />
                                    <%--  <asp:Button ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="<%$ Resources:LanguagePack, lblEdit %>"></asp:Button>--%>
                                    &nbsp;<asp:Button ID="LinkButtonDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="<%$ Resources:LanguagePack, lblDelete %>" OnClientClick="<%$ Resources:LanguagePack, DeleteConfirm %>">
                                    </asp:Button>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <asp:Button ID="LinkButtonAddDetails" runat="server" OnClick="LinkButtonAddDetails_Click"
                                        CssClass="MasterAdd" Text="<%$ Resources:LanguagePack, lblAdd %>" />
                                </HeaderTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <uc:ucPaging ID="ucPaging" runat="server" />
                        </PagerTemplate>
                    </asp:GridView>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panAdd" BackgroundCssClass="modalBackground" CancelControlID="ImageButtonAdd"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtender1" runat="server" Title="<%$ Resources:LanguagePack, TemplateADDItem %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeM %>">
        <Content>--%>
    <asp:Panel ID="panAdd" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragAdd" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleAdd" runat="server" Text="<%$ Resources:LanguagePack, TemplateADDItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="ImageButtonAdd" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewTemplate" runat="server" CssClass="masterDe" AutoGenerateRows="False"
            DataKeyNames="id" DataSourceID="EntityDataSourceTemplateType" DefaultMode="Insert"
            OnItemInserted="DetailsViewTemplate_ItemInserted" Visible="False" OnItemCommand="DetailsViewTemplate_ItemCommand"
            OnItemInserting="DetailsViewTemplate_OnItemInserting">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="typeName" HeaderText="<%$ Resources:LanguagePack, TemplateTpyeCore %>" />
                <asp:DynamicField DataField="typeDescription" HeaderText="<%$ Resources:LanguagePack, TemplateTpyeDesc %>" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" InsertText="<%$ Resources:LanguagePack, GvDeSaveBtn %>" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panAddDetails" BackgroundCssClass="modalBackground" CancelControlID="ImageButtonDetailsDrag"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtender2" runat="server" Title="<%$ Resources:LanguagePack, TemplateADDItemTemplateDetails %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeM %>">
        <Content>--%>
    <asp:Panel ID="panAddDetails" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panAddDetailsDrag" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleDetailsDrag" runat="server" Text="<%$ Resources:LanguagePack, TemplateADDItemTemplateDetails %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="ImageButtonDetailsDrag" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewTemplateDetails" runat="server" CssClass="masterDe"
            AutoGenerateRows="False" DataSourceID="EntityDataSourceTemplateDetails" DefaultMode="Insert"
            OnItemInserted="DetailsViewTemplateDetails_ItemInserted" OnItemCommand="DetailsViewTemplateDetails_ItemCommand"
            Visible="False" OnItemInserting="DetailsViewTemplateDetails_OnItemInserting">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="TemplateType" HeaderText="Type" />
                <asp:DynamicField DataField="detailsDescription" HeaderText="<%$ Resources:LanguagePack, TemplateTpyeDesc %>" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" InsertText="<%$ Resources:LanguagePack, GvDeSaveBtn %>" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderTypeEdit" runat="server" TargetControlID="lnkPopup"
        PopupControlID="PanelTypeEdit" BackgroundCssClass="modalBackground" CancelControlID="ImageButtonTypeEdit"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PanelTypeEdit" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragTypeEdit" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleTypeEdit" runat="server" Text="<%$ Resources:LanguagePack, TemplateTypeEditItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="ImageButtonTypeEdit" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewTypeEdit" runat="server" CssClass="masterDe" AutoGenerateRows="False"
            DataKeyNames="id" DataSourceID="EntityDataSourceTemplateTypeEdit" DefaultMode="Edit"
            Visible="False" OnItemUpdated="DetailsViewTypeEdit_ItemUpdated" OnItemUpdating="DetailsViewTypeEdit_ItemUpdating">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="typeName" HeaderText="Type" />
                <asp:DynamicField DataField="typeDescription" HeaderText="<%$ Resources:LanguagePack, TemplateTpyeDesc %>" />
                <asp:CommandField ButtonType="Button" ShowEditButton="True" ShowCancelButton="true" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDeEdit" runat="server" TargetControlID="lnkPopup"
        PopupControlID="PanelDeEdit" BackgroundCssClass="modalBackground" CancelControlID="ImageButtonDeEdit"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PanelDeEdit" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragDeEdit" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleDeEdit" runat="server" Text="<%$ Resources:LanguagePack, TemplateADDItemTemplateDetailsEdit %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="ImageButtonDeEdit" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewDeEdit" runat="server" CssClass="masterDe" AutoGenerateRows="False"
            DataKeyNames="id" DataSourceID="EntityDataSourceTemplateDetailsEdit" DefaultMode="Edit"
            Visible="False" OnItemUpdated="DetailsViewDeEdit_ItemUpdated" OnItemUpdating="DetailsViewDeEdit_ItemUpdating">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="TemplateType" HeaderText="Type" />
                <asp:DynamicField DataField="detailsDescription" HeaderText="<%$ Resources:LanguagePack, TemplateTpyeDesc %>" />
                <asp:CommandField ButtonType="Button" ShowEditButton="True" ShowCancelButton="true" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <a id="lnkPopup" runat="server"></a>
    <asp:EntityDataSource ID="EntityDataSourceTemplateType" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableUpdate="True"
        EntitySetName="TemplateTypes" EnableDelete="True" EnableInsert="True">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceTemplateTypeEdit" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableUpdate="True"
        EntitySetName="TemplateTypes" EnableDelete="True" EnableInsert="True">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceTemplateDetails" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="TemplateDetails">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceTemplateDetailsEdit" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="TemplateDetails">
    </asp:EntityDataSource>
</asp:Content>
