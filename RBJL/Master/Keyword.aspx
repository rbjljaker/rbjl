<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="Keyword.aspx.cs" Inherits="Master_Keyword" %>

<%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<%@ Register Src="~/WebControl/LBLDoworkTitle.ascx" TagName="WebUserControlLBLDoworkTitle"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, KeywordlblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:GridView OnRowUpdated="GridViewKeyword_OnRowUpdated" OnDataBound="GridViewKeyword_OnDataBound"
        RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster"
        ID="GridViewKeyword" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
        DataSourceID="EntityDataSourceKeyword" AllowPaging="True" PageSize="<%$ appSettings:GridViewPageSize %>"
        OnRowCommand="GridViewKeyword_OnRowCommand" OnRowUpdating="GridViewKeyword_OnRowUpdating"
        CssClass="MasterWidth" ShowHeaderWhenEmpty="True" EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>"
        OnSelectedIndexChanged="GridViewKeyword_SelectedIndexChanged" 
        onrowdeleted="GridViewKeyword_RowDeleted">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <asp:DynamicField DataField="name" HeaderText="<%$ Resources:master, keyword_name %>" />
            <asp:DynamicField DataField="description" HeaderText="<%$ Resources:master, keyword_description %>" />
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
                    <%--                    <asp:Button ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandName="Edit"
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
    <%--    <ext:Window ID="ModalPopupExtenderInsert" runat="server" Title="<%$ Resources:LanguagePack, KeywordADDItem %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeM %>">
        <Content>--%>
    <asp:Panel ID="panAdd" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDrag" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitle" runat="server" Text="<%$ Resources:LanguagePack, KeywordADDItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/close.png" CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewKeyword" runat="server" CssClass="masterDe" AutoGenerateRows="False"
            DataKeyNames="id" DataSourceID="EntityDataSourceKeyword" DefaultMode="Insert"
            OnItemInserted="DetailsViewKeyword_ItemInserted" Visible="false" OnItemCommand="DetailsViewKeyword_OnItemCommand"
            OnItemInserting="DetailsViewKeyword_OnItemInserting">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="name" HeaderText="<%$ Resources:master, keyword_name %>" />
                <asp:DynamicField DataField="description" HeaderText="<%$ Resources:master, keyword_description %>" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" InsertText="<%$ Resources:LanguagePack, GvDeSaveBtn %>" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <ajaxToolkit:ModalPopupExtender ID="WindowKeywordEdit" runat="server" TargetControlID="lnkPopup"
        PopupControlID="PanelKeywordEdit" BackgroundCssClass="modalBackground" CancelControlID="ImageButtonEditDrag"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="WindowKeywordEdit" runat="server" Title="<%$ Resources:LanguagePack, KeywordEditItem %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeM %>">
        <Content>--%>
    <asp:Panel ID="PanelKeywordEdit" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="PanelEditDrag" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelEditDrag" runat="server" Text="<%$ Resources:LanguagePack, KeywordEditItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="ImageButtonEditDrag" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewKeywordEdit" runat="server" CssClass="masterDe" AutoGenerateRows="False"
            DataKeyNames="id" DataSourceID="EntityDataSourceKeyword" DefaultMode="Edit" Visible="false"
            OnItemUpdated="DetailsViewKeywordEdit_ItemUpdated" OnItemUpdating="DetailsViewKeywordEdit_ItemUpdating">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="name" HeaderText="<%$ Resources:master, keyword_name %>" />
                <asp:DynamicField DataField="description" HeaderText="<%$ Resources:master, keyword_description %>" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <a id="lnkPopup" runat="server"></a>
    <asp:EntityDataSource ID="EntityDataSourceKeyword" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="Keyworks">
    </asp:EntityDataSource>
</asp:Content>
