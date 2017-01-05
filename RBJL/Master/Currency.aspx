<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="Currency.aspx.cs" Inherits="Master_Currency" %>

<%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<%@ Register Src="~/WebControl/LBLDoworkTitle.ascx" TagName="WebUserControlLBLDoworkTitle"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, CurrencylblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:GridView ID="GridViewCurrency" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="id" DataSourceID="EntityDataSourceCurrency" PageSize="<%$ appSettings:GridViewPageSize %>"
        RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster"
        OnDataBound="GridViewCurrency_OnDataBound" OnRowUpdating="GridViewCurrency_OnRowUpdating"
        OnRowUpdated="GridViewCurrency_RowUpdated" CssClass="MasterWidth" ShowHeaderWhenEmpty="True"
        EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>" 
        OnSelectedIndexChanged="GridViewCurrency_SelectedIndexChanged" 
        onrowdeleted="GridViewCurrency_RowDeleted">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <asp:DynamicField DataField="symbol" HeaderText="<%$ Resources:master, currency_symbol  %>" />
            <asp:DynamicField DataField="currencyName" HeaderText="<%$ Resources:master, currency_currencyName  %>" />
            <asp:DynamicField DataField="rateToHK" HeaderText="<%$ Resources:master, currency_rateToHK  %>" />
            <asp:DynamicField DataField="orderBy" HeaderText="orderBy" Visible="False" />
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
                    <%--<asp:Button ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandName="Edit"
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
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panAdd" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--        <ext:Window ID="ModalPopupExtender1" runat="server" Title="<%$ Resources:LanguagePack, CurrencyADDItem %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeS %>">
        <Content>--%>
    <asp:Panel ID="panAdd" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDrag" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitle" runat="server" Text="<%$ Resources:LanguagePack, CurrencyADDItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/close.png" CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <%--<uc1:WebUserControlLBLDoworkTitle ID="ucLBLDoworkTitle" runat="server" initString="<%$ Resources:LanguagePack, CurrencyADDItem %>" />--%>
        <asp:DetailsView ID="DetailsViewCurrency" runat="server" CssClass="masterDe" AutoGenerateRows="False"
            DataKeyNames="id" DataSourceID="EntityDataSourceCurrency" DefaultMode="Insert"
            OnItemInserted="DetailsViewCurrency_ItemInserted" Visible="false" OnItemInserting="DetailsViewCurrency_OnItemInserting">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="symbol" HeaderText="<%$ Resources:master, currency_symbol  %>" />
                <asp:DynamicField DataField="currencyName" HeaderText="<%$ Resources:master, currency_currencyName  %>" />
                <asp:DynamicField DataField="rateToHK" HeaderText="<%$ Resources:master, currency_rateToHK  %>" />
                <asp:DynamicField DataField="orderBy" HeaderText="orderBy" Visible="False" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <%--    </Content>
    </ext:Window>--%>
    <a id="lnkPopup" runat="server"></a>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEdit" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panAddEdit" BackgroundCssClass="modalBackground" CancelControlID="btnCancelEdit"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="panAddEdit" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragEdit" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:LanguagePack, CurrencyEditItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancelEdit" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewCurrencyEdit" runat="server" CssClass="masterDe"
            AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourceCurrency"
            DefaultMode="Edit" Visible="false" OnItemUpdated="DetailsViewCurrencyEdit_ItemUpdated">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="symbol" HeaderText="<%$ Resources:master, currency_symbol  %>" />
                <asp:DynamicField DataField="currencyName" HeaderText="<%$ Resources:master, currency_currencyName %>" />
                <asp:DynamicField DataField="rateToHK" HeaderText="<%$ Resources:master, currency_rateToHK  %>" />
                <asp:DynamicField DataField="orderBy" HeaderText="orderBy" Visible="False" />
                <asp:CommandField ButtonType="Button" ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <asp:EntityDataSource ID="EntityDataSourceCurrency" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="CurrencyRates">
    </asp:EntityDataSource>
</asp:Content>
