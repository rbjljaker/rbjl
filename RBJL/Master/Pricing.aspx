<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="Pricing.aspx.cs" Inherits="Master_Pricing" %>

<%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<%@ Register Src="~/WebControl/LBLDoworkTitle.ascx" TagName="WebUserControlLBLDoworkTitle"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, PricinglblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <div class="Tab">
        <ajaxToolkit:TabContainer ID="TabContainerTemplate" runat="server" ActiveTabIndex="0">
            <ajaxToolkit:TabPanel ID="TabPanelTemplateType" runat="server" HeaderText="<%$ Resources:LanguagePack, pricingTabT %>">
                <ContentTemplate>
                    <asp:GridView OnRowUpdated="GridViewPricingType_OnRowUpdated" OnDataBound="GridViewPricingType_OnDataBound"
                        ID="GridViewPricingType" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="id" DataSourceID="EntityDataSourcePricingType" PageSize="<%$ appSettings:GridViewPageSize %>"
                        OnRowUpdating="GridViewPricingType_RowUpdating" AllowSorting="True" CssClass="MasterWidth"
                        ShowHeaderWhenEmpty="True" EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>"
                        OnRowCommand="GridViewPricingType_RowCommand" OnSelectedIndexChanged="GridViewPricingType_SelectedIndexChanged" onrowdeleted="GridViewPriceType_RowDeleted">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                Visible="False" />
                            <asp:DynamicField DataField="typeName" HeaderText="<%$ Resources:master,pricing_typeName  %>"
                                ItemStyle-CssClass="nameWidth" />
                            <asp:DynamicField DataField="typeDescription" HeaderText="<%$ Resources:master,pricing_typeDescription  %>" />
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
                                <HeaderStyle CssClass="" />
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
            <ajaxToolkit:TabPanel ID="TabPanelTemplateDetails" runat="server" HeaderText="<%$ Resources:LanguagePack, pricingTabPD %>">
                <ContentTemplate>
                    <asp:GridView OnRowUpdated="GridViewPricingDetails_OnRowUpdated" OnDataBound="GridViewPricingDetails_OnDataBound"
                        RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster"
                        ID="GridViewPricingDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="id" DataSourceID="EntityDataSourcePricingDetails" PageSize="<%$ appSettings:GridViewPageSize %>"
                        AllowSorting="True" CssClass="MasterWidth" ShowHeaderWhenEmpty="True" EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>"
                        OnSelectedIndexChanged="GridViewPricingDetails_SelectedIndexChanged" OnRowCommand="GridViewPricingDetails_RowCommand" onrowdeleted="GridViewPriceDetails_RowDeleted">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                Visible="False" />
                            <asp:DynamicField DataField="PricingType" HeaderText="<%$ Resources:master,pricing_PricingType  %>"
                                ItemStyle-CssClass="nameWidth" />
                            <asp:DynamicField DataField="detailsDescription" HeaderText="<%$ Resources:master,pricing_detailsDescription  %>" />
                            <asp:DynamicField DataField="priceValue" HeaderText="<%$ Resources:master,pricing_priceValue  %>" />
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
                                    <%--   <asp:Button ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandName="Edit"
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
    <%--    <ext:Window ID="ModalPopupExtender1" runat="server" Title="<%$ Resources:LanguagePack, PricingADDPricingType %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeM %>">
        <Content>--%>
    <asp:Panel ID="panAdd" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragAdd" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleAdd" runat="server" Text="<%$ Resources:LanguagePack, PricingADDPricingType %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="ImageButtonAdd" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewPricingType" runat="server" CssClass="masterDe lineHeight"
            AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourcePricingType"
            DefaultMode="Insert" OnItemCommand="DetailsViewPricingType_ItemCommand" Visible="False"
            OnItemInserted="DetailsViewPricingType_ItemInserted" OnItemInserting="DetailsViewPricingType_ItemInserting"
            OnItemUpdating="DetailsViewPricingType_ItemUpdating">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="typeName" HeaderText="<%$ Resources:master,pricing_typeName  %>" />
                <asp:DynamicField DataField="typeDescription" HeaderText="<%$ Resources:master,pricing_typeDescription  %>" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panAddDetails" BackgroundCssClass="modalBackground" CancelControlID="btnCanceAddDetails"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtender2" runat="server" Title="<%$ Resources:LanguagePack, PricingADDPricingDetails %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeM %>">
        <Content>--%>
    <asp:Panel ID="panAddDetails" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragAddDetails" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleAddDetails" runat="server" Text="<%$ Resources:LanguagePack, PricingADDPricingDetails %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCanceAddDetails" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewPricingDetails" runat="server" CssClass="masterDe lineHeight"
            AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourcePricingDetails"
            OnItemCommand="DetailsViewPricingDetails_ItemCommand" DefaultMode="Insert" Visible="False"
            OnItemInserted="DetailsViewPricingDetails_ItemInserted" OnItemInserting="DetailsViewPricingDetails_ItemInserting">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="PricingType" HeaderText="<%$ Resources:master,pricing_PricingType  %>" />
                <asp:DynamicField DataField="detailsDescription" HeaderText="<%$ Resources:master,pricing_detailsDescription  %>" />
                <asp:DynamicField DataField="priceValue" HeaderText="<%$ Resources:master,pricing_priceValue  %>" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <%--    <ext:Window ID="Window3" runat="server" Title="<%$ Resources:LanguagePack, PricingEditPricingType %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeM %>">
        <Content>--%>
    <ajaxToolkit:ModalPopupExtender ID="Window3" runat="server" TargetControlID="lnkPopup"
        PopupControlID="Panel3" BackgroundCssClass="modalBackground" CancelControlID="btnCancel3"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel3" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDrag3" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitle3" runat="server" Text="<%$ Resources:LanguagePack, PricingEditPricingType %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancel3" runat="server" ImageUrl="~/images/close.png" CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsView1" runat="server" CssClass="masterDe lineHeight"
            AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourcePricingTypeEdit"
            DefaultMode="Edit" Visible="False" OnItemUpdated="DetailsView1_ItemUpdated" OnItemUpdating="DetailsView1_ItemUpdating">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="typeName" HeaderText="<%$ Resources:master,pricing_typeName  %>" />
                <asp:DynamicField DataField="typeDescription" HeaderText="<%$ Resources:master,pricing_typeDescription  %>" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <%--        </Content>
   </ext:Window>--%>
    <ajaxToolkit:ModalPopupExtender ID="WindowDetailsEdit" runat="server" TargetControlID="lnkPopup"
        PopupControlID="PanelDetailsEdit" BackgroundCssClass="modalBackground" CancelControlID="btnCancelDetailsEdit"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="WindowDetailsEdit" runat="server" Title="<%$ Resources:LanguagePack, PricingEditPricingDetails %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeM %>">
        <Content>--%>
    <asp:Panel ID="PanelDetailsEdit" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragDetailsEdit" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleDetailsEdit" runat="server" Text="<%$ Resources:LanguagePack, PricingEditPricingDetails %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancelDetailsEdit" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewDetailsEdit" runat="server" CssClass="masterDe lineHeight"
            AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourcePricingDetailsEdit"
            DefaultMode="Edit" Visible="False" OnItemUpdated="DetailsViewDetailsEdit_ItemUpdated"
            OnItemUpdating="DetailsViewDetailsEdit_ItemUpdating">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="PricingType" HeaderText="<%$ Resources:master,pricing_PricingType  %>" />
                <asp:DynamicField DataField="detailsDescription" HeaderText="<%$ Resources:master,pricing_detailsDescription  %>" />
                <asp:DynamicField DataField="priceValue" HeaderText="<%$ Resources:master,pricing_priceValue  %>" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <a id="lnkPopup" runat="server"></a>
    <asp:EntityDataSource ID="EntityDataSourcePricingType" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="PricingTypes">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourcePricingTypeEdit" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="PricingTypes" Where=""
        OnSelecting="EntityDataSourcePricingTypeEdit_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourcePricingDetails" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="PricingDetails">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourcePricingDetailsEdit" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="PricingDetails">
    </asp:EntityDataSource>
</asp:Content>
