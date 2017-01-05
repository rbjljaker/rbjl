<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="Country.aspx.cs" Inherits="Master_Country" %>

<%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<%@ Register Src="~/WebControl/LBLDoworkTitle.ascx" TagName="WebUserControlLBLDoworkTitle"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, CountryTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:GridView OnRowUpdated="GridViewKeyword_OnRowUpdated" OnDataBound="GridViewKeyword_OnDataBound"
        RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster"
        ID="GridViewKeyword" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
        DataSourceID="EntityDataSourceCountry" AllowPaging="True" PageSize="<%$ appSettings:GridViewPageSize %>"
        OnRowCommand="GridViewKeyword_OnRowCommand" OnRowUpdating="GridViewKeyword_OnRowUpdating"
        CssClass="MasterWidth" ShowHeaderWhenEmpty="True" EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>"
        OnSelectedIndexChanged="GridViewKeyword_SelectedIndexChanged" 
        onrowdeleted="GridViewKeyword_RowDeleted">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <asp:DynamicField DataField="countryCode" HeaderText="<%$ Resources:LanguagePack, CountryCode %>"
                ItemStyle-CssClass="tableDC" />
            <asp:DynamicField DataField="countryName" HeaderText="<%$ Resources:LanguagePack, CountryName %>" />
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:Button ID="LinkButtonUpdate" runat="server" CausesValidation="True" CommandName="Update"
                        Text="<%$ Resources:LanguagePack, lblUpdate %>" OnClick="LinkButtonUpdate_OnClick"
                        CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>'></asp:Button>
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
        <HeaderStyle CssClass="lineGridviewMaster"></HeaderStyle>
        <PagerTemplate>
            <uc:ucPaging ID="ucPaging" runat="server" />
        </PagerTemplate>
        <RowStyle CssClass="lineGridviewMaster"></RowStyle>
    </asp:GridView>
    <br />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderInsert" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panAdd" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtenderInsert" runat="server" Title="<%$ Resources:LanguagePack, CountryADDItem %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeS %>">
        <Content>--%>
    <asp:Panel ID="panAdd" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDrag" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitle" runat="server" Text="<%$ Resources:LanguagePack, CountryADDItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/close.png" CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <%--<uc1:WebUserControlLBLDoworkTitle ID="ucLBLDoworkTitle" runat="server" initString="<%$ Resources:LanguagePack, CountryADDItem %>" />--%>
        <asp:DetailsView ID="DetailsViewKeyword" runat="server" CssClass="masterDe" AutoGenerateRows="False"
            DataKeyNames="id" DataSourceID="EntityDataSourceCountry" DefaultMode="Insert"
            OnItemInserted="DetailsViewKeyword_ItemInserted" Visible="False" OnItemCommand="DetailsViewKeyword_OnItemCommand"
            OnItemInserting="DetailsViewKeyword_OnItemInserting">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="countryCode" HeaderText="<%$ Resources:LanguagePack, CountryCode %>" />
                <asp:DynamicField DataField="countryName" HeaderText="<%$ Resources:LanguagePack, CountryName %>" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <a id="lnkPopup" runat="server"></a>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEdit" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panAddEdit" BackgroundCssClass="modalBackground" CancelControlID="btnCancelEdit"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="panAddEdit" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragEdit" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleEdit" runat="server" Text="<%$ Resources:LanguagePack, CountryEditItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancelEdit" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
            <asp:DetailsView ID="DetailsViewKeywordEdit" runat="server" CssClass="masterDe" AutoGenerateRows="False"
                DataKeyNames="id" DataSourceID="EntityDataSourceCountry" DefaultMode="Edit" OnItemUpdated="DetailsViewKeywordEdit_ItemUpdated"
                OnItemUpdating="DetailsViewKeywordEdit_ItemUpdating">
                <Fields>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                        Visible="False" />
                    <asp:DynamicField DataField="countryCode" HeaderText="<%$ Resources:LanguagePack, CountryCode %>" />
                    <asp:DynamicField DataField="countryName" HeaderText="<%$ Resources:LanguagePack, CountryName %>" />
                    <asp:CommandField ButtonType="Button" ShowInsertButton="True" ShowEditButton="True" />
                </Fields>
            </asp:DetailsView>
        </asp:Panel>
    </asp:Panel>
    <asp:EntityDataSource ID="EntityDataSourceCountry" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableInsert="True"
        EnableUpdate="True" EntitySetName="Countries" EnableDelete="True" EntityTypeFilter=""
        OrderBy="it.countryName" Select="">
    </asp:EntityDataSource>
</asp:Content>
