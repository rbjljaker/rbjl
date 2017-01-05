<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="OtherParties.aspx.cs" Inherits="Master_OtherParties" %>

<%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<%@ Register Src="~/WebControl/LBLDoworkTitle.ascx" TagName="WebUserControlLBLDoworkTitle"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, OtherPartieslblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:GridView OnDataBound="GridViewOtherParties_OnDataBound" RowStyle-CssClass="lineGridviewMaster"
        HeaderStyle-CssClass="lineGridviewMaster" ID="GridViewOtherParties" OnSelectedIndexChanged="GridViewOtherParties_SelectedIndexChanged"
        runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSourceOtherParties"
        AllowPaging="true" PageSize="<%$ appSettings:GridViewPageSize %>" ShowHeaderWhenEmpty="True"
        EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>" 
        onrowdeleted="GridViewOtherParties_RowDeleted">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <asp:DynamicField DataField="otherPartiesNum" HeaderText="<%$ Resources:master, otherparties_otherPartiesNum %>" />
            <asp:DynamicField DataField="otherPartiesName" HeaderText="<%$ Resources:master, otherparties_otherPartiesName %>"
                ItemStyle-CssClass="nameWidth" />
            <asp:DynamicField DataField="billingAddressFirst" HeaderText="<%$ Resources:master, otherparties_billingAddressFirst %>"
                Visible="false" />
            <asp:DynamicField DataField="billingAddressSecond" HeaderText="<%$ Resources:master, otherparties_billingAddressSecond %>"
                Visible="false" />
            <asp:DynamicField DataField="correspondingAddress1First" HeaderText="<%$ Resources:master, otherparties_correspondingAddress1First %>"
                Visible="false" />
            <asp:DynamicField DataField="correspondingAddress1Second" HeaderText="<%$ Resources:master, otherparties_correspondingAddress1Second %>"
                Visible="false" />
            <asp:DynamicField DataField="correspondingAddress2First" HeaderText="<%$ Resources:master, otherparties_correspondingAddress2First %>"
                Visible="false" />
            <asp:DynamicField DataField="correspondingAddress2Second" HeaderText="<%$ Resources:master, otherparties_correspondingAddress2Second %>"
                Visible="false" />
            <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, otherparties_contactPerson %>" />
            <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, otherparties_tel %>" />
            <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, otherparties_fax %>" />
            <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, otherparties_email %>" />
            <%--<asp:CheckBoxField DataField="isEnable" HeaderText="<%$ Resources:master, otherparties_isEnable %>" />--%>
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
                             &nbsp;<asp:Button ID="LinkButtonDelete" runat="server" CausesValidation="False"
                        CommandName="Delete" Text="<%$ Resources:LanguagePack, lblDelete %>" OnClientClick="<%$ Resources:LanguagePack, DeleteConfirm %>"></asp:Button>
                    
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
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderInsert" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panAdd" BackgroundCssClass="modalBackground" CancelControlID="ImageButtonAdd"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtenderInsert" runat="server" Title="<%$ Resources:LanguagePack, OtherPartiesADDItem %>" Icon="Application"
        Maximizable="true" AutoScroll="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeL %>">
        <Content>--%>
    <asp:Panel ID="panAdd" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragAdd" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleAdd" runat="server" Text="<%$ Resources:LanguagePack, OtherPartiesADDItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="ImageButtonAdd" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <table>
            <tr>
                <td>
                    <asp:DetailsView ID="DetailsViewOtherParties" runat="server" CssClass="masterDe"
                        AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourceOtherParties"
                        OnItemInserted="DetailsViewOtherParties_ItemInserted" DefaultMode="Insert" OnItemInserting="DetailsViewOtherParties_OnItemInserting">
                        <Fields>
                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                Visible="False" />
                            <asp:DynamicField DataField="otherPartiesNum" HeaderText="<%$ Resources:master, otherparties_otherPartiesNum %>" />
                            <asp:DynamicField DataField="otherPartiesName" HeaderText="<%$ Resources:master, otherparties_otherPartiesName %>" />
                            <asp:DynamicField DataField="billingAddressFirst" HeaderText="<%$ Resources:master, otherparties_billingAddressFirst %>" />
                            <asp:DynamicField DataField="billingAddressSecond" HeaderText="<%$ Resources:master, otherparties_billingAddressSecond %>" />
                            <asp:DynamicField DataField="correspondingAddress1First" HeaderText="<%$ Resources:master, otherparties_correspondingAddress1First %>" />
                            <asp:DynamicField DataField="correspondingAddress1Second" HeaderText="<%$ Resources:master, otherparties_correspondingAddress1Second %>" />
                            <asp:DynamicField DataField="correspondingAddress2First" HeaderText="<%$ Resources:master, otherparties_correspondingAddress2First %>" />
                            <asp:DynamicField DataField="correspondingAddress2Second" HeaderText="<%$ Resources:master, otherparties_correspondingAddress2Second %>" />
                            <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, otherparties_contactPerson %>" />
                            <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, otherparties_tel %>" />
                            <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, otherparties_fax %>" />
                            <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, otherparties_email %>" />
                            <%--<asp:CheckBoxField DataField="isEnable" HeaderText="<%$ Resources:master, otherparties_isEnable %>" />--%>
                            <asp:CommandField ButtonType="Button" ShowInsertButton="True" InsertText="<%$ Resources:LanguagePack, GvDeSaveBtn %>" />
                        </Fields>
                    </asp:DetailsView>
                </td>
                <td>
                    <asp:Button ID="LinkButtonCopyFrompop" runat="server" Text="<%$ Resources:LanguagePack, lblCopyFromClient %>"
                        OnClick="LinkButtonCopyFrompop_onclick" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEdit" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panAddEdit" BackgroundCssClass="modalBackground" CancelControlID="btnCancelAddEdit"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtenderEdit" runat="server" Title="<%$ Resources:LanguagePack, OtherPartiesEditItem %>" Icon="Application"
        Maximizable="true" AutoScroll="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeL %>">
        <Content>--%>
    <asp:Panel ID="panAddEdit" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragAddEdit" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleAddEdit" runat="server" Text="<%$ Resources:LanguagePack, OtherPartiesEditItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancelAddEdit" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewClientUpdate" runat="server" CssClass="masterDe lineHeight"
            AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourceOtherParties"
            DefaultMode="Edit" Visible="False" OnItemUpdated="DetailsViewClientUpdate_ItemUpdated"
            OnItemUpdating="DetailsViewClientUpdate_OnItemUpdating">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="otherPartiesNum" HeaderText="<%$ Resources:master, otherparties_otherPartiesNum %>"
                    ReadOnly="true" />
                <asp:DynamicField DataField="otherPartiesName" HeaderText="<%$ Resources:master, otherparties_otherPartiesName %>" />
                <asp:DynamicField DataField="billingAddressFirst" HeaderText="<%$ Resources:master, otherparties_billingAddressFirst %>" />
                <asp:DynamicField DataField="billingAddressSecond" HeaderText="<%$ Resources:master, otherparties_billingAddressSecond %>" />
                <asp:DynamicField DataField="correspondingAddress1First" HeaderText="<%$ Resources:master, otherparties_correspondingAddress1First %>" />
                <asp:DynamicField DataField="correspondingAddress1Second" HeaderText="<%$ Resources:master, otherparties_correspondingAddress1Second %>" />
                <asp:DynamicField DataField="correspondingAddress2First" HeaderText="<%$ Resources:master, otherparties_correspondingAddress2First %>" />
                <asp:DynamicField DataField="correspondingAddress2Second" HeaderText="<%$ Resources:master, otherparties_correspondingAddress2Second %>" />
                <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, otherparties_contactPerson %>" />
                <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, otherparties_tel %>" />
                <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, otherparties_fax %>" />
                <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, otherparties_email %>" />
                <%--<asp:CheckBoxField DataField="isEnable" HeaderText="<%$ Resources:master, otherparties_isEnable %>" />--%>
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" ShowEditButton="True"
                    CausesValidation="False" />
            </Fields>
        </asp:DetailsView>
        <asp:Button ID="btnCancel2" runat="server" Text="Cancel" CssClass="displayNone" />
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <a id="lnkPopup" runat="server"></a>
    <asp:EntityDataSource ID="EntityDataSourceOtherParties" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="OtherParties">
    </asp:EntityDataSource>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtendercopyfrompop" runat="server"
        TargetControlID="lnkPopupcopyfrompop" PopupControlID="pancopyfrompop" BackgroundCssClass="modalBackground"
        CancelControlID="btnCancel" PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtendercopyfrompop" runat="server" Title="" Icon="Application"
        Maximizable="true" AutoScroll="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeL %>">
        <Content>--%>
    <asp:Panel ID="pancopyfrompop" runat="server" CssClass="newpopM radiusClass popupWidth"
        Style="display: none;">
        <asp:Panel ID="panDrag" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitle" runat="server" Text="<%$ Resources:LanguagePack, SelectClient %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/close.png" CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:Label ID="LabelClientName" runat="server" Text="<%$ Resources:LanguagePack, LabelClientName %>"></asp:Label>
        <asp:TextBox ID="TextBoxClientName" runat="server"></asp:TextBox>
        <asp:Button ID="Button_search" runat="server" Text="<%$ Resources:LanguagePack, ButtonSearch %>"
            OnClick="Button_search_Click" CausesValidation="false" />
        <br />
        <br />
        <div class="popupCopy">
            <asp:GridView OnDataBound="GridViewCopy_OnDataBound" RowStyle-CssClass="lineGridviewMaster"
                HeaderStyle-CssClass="lineGridviewMaster" ID="GridViewCopypop" runat="server"
                AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSourceClientInsert"
                OnRowCommand="GridViewInsert_RowCommand" Visible="true" AllowPaging="true" PageSize="<%$ appSettings:GridViewPageSize %>">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" Text="Copy"
                                CommandName="Select" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                        Visible="false" />
                    <asp:DynamicField DataField="accountGroup" HeaderText="<%$ Resources:master, client_accountGroup %>" />
                    <asp:DynamicField DataField="clientNum" HeaderText="<%$ Resources:master, client_clientNum  %>" />
                    <asp:DynamicField DataField="clientName" HeaderText="<%$ Resources:master, client_clientName  %>" />
                    <asp:DynamicField DataField="billingAddressFirst" HeaderText="<%$ Resources:master, client_billingAddressFirst  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="billingAddressSecond" HeaderText="<%$ Resources:master, client_billingAddressSecond  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="correspondingAddress1First" HeaderText="<%$ Resources:master, client_correspondingAddress1First  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="correspondingAddress1Second" HeaderText="<%$ Resources:master, client_correspondingAddress1Second  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="correspondingAddress2First" HeaderText="<%$ Resources:master, client_correspondingAddress2First  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="correspondingAddress2Second" HeaderText="<%$ Resources:master, client_correspondingAddress2Second  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, client_contactPerson  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, client_tel  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, client_fax  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, client_email  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="billingEmail" HeaderText="<%$ Resources:master, client_billingEmail  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="Referer" HeaderText="<%$ Resources:master, client_Referer  %>" />
                    <asp:DynamicField DataField="discount" HeaderText="<%$ Resources:master, client_discount  %>" />
                    <asp:DynamicField DataField="refNumOfReferer" HeaderText="<%$ Resources:master, client_refNumOfReferer  %>" />
                    <asp:DynamicField DataField="ioNumOfReferer" HeaderText="<%$ Resources:master, client_ioNumOfReferer  %>" />
                    <asp:DynamicField DataField="isReleaseToPublic" HeaderText="<%$ Resources:master, client_isReleaseToPublic  %>" />
                    <asp:DynamicField DataField="UpdateByUserName" HeaderText="<%$ Resources:master, client_UpdateByUserName  %>" />
                    <asp:DynamicField DataField="UpdateDate" HeaderText="<%$ Resources:master, client_UpdateDate  %>"
                        DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}" />
                </Columns>
                <PagerTemplate>
                    <uc:ucPaging ID="ucPaging" runat="server" />
                </PagerTemplate>
            </asp:GridView>
        </div>
        <br />
        <asp:Button ID="LinkButtonRefresh" runat="server" CausesValidation="false" Visible="true"
            Text="Back" OnClick="LinkButtonRefresh_Click"></asp:Button>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <a id="lnkPopupcopyfrompop" runat="server"></a>
    <asp:EntityDataSource ID="EntityDataSourceClientInsert" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableInsert="True"
        EntitySetName="Clients" ContextTypeName="" EnableDelete="True" EnableUpdate="True"
        OnSelecting="EntityDataSourceClientInsert_Selecting">
    </asp:EntityDataSource>
</asp:Content>
