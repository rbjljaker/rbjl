<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="OutgoingAgent.aspx.cs" Inherits="Master_OutgoingAgent" %>

<%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<%@ Register Src="~/WebControl/LBLDoworkTitle.ascx" TagName="WebUserControlLBLDoworkTitle"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        $(function () {

            mouseOverSearchInit(".callSearch", ".searchBox", "1%");
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, OutgoingAgentlblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Panel ID="searchPanel" runat="server">
        <div class="searchBox newpopM radiusClass">
            <asp:Label ID="LabelName" runat="server" Text="<%$ Resources:LanguagePack, SearchOutgoingAgent %>"></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSearchName" runat="server" Text="<%$ Resources:LanguagePack, ButtonSearch %>"
                OnClick="ButtonSearchName_Click" CausesValidation="false" />
            <br />
            <br />
        </div>
    </asp:Panel>
    <asp:GridView OnDataBound="GridViewOutgoingAgent_OnDataBound" RowStyle-CssClass="lineGridviewMaster"
        HeaderStyle-CssClass="lineGridviewMaster" ID="GridViewOutgoingAgent" runat="server"
        AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSourceOutgoingAgent"
        OnSelectedIndexChanged="GridViewOutgoingAgent_SelectedIndexChanged" AllowPaging="true"
        PageSize="<%$ appSettings:GridViewPageSize %>" ShowHeaderWhenEmpty="True" EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>"
        AllowSorting="true" OnRowCommand="GridViewOutgoingAgent_RowCommand" 
        onrowdeleted="GridViewOutgoingAgent_RowDeleted">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <asp:DynamicField DataField="agentNum" HeaderText="<%$ Resources:master, outgoingagent_agentNum %>" />
            <%--   <asp:DynamicField DataField="agentName" HeaderText="<%$ Resources:master, outgoingagent_agentName %>" />--%>
            <asp:TemplateField ConvertEmptyStringToNull="False">
                <ItemStyle CssClass="nameWidth" />
                <ItemTemplate>
                    <asp:DynamicControl ID="DynamicControl1" runat="server" DataField="agentName" Mode="ReadOnly" />
                </ItemTemplate>
                <HeaderTemplate>
                    <div class="callSearch">
                        <asp:LinkButton ID="NameHeaderLinkButton" runat="server" Text="<%$ Resources:master, outgoingagent_agentName %>"
                            CommandName="Sort" CommandArgument="agentName" CausesValidation="false" />
                    </div>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="correspondingAddress1First" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress1First %>"
                Visible="false" />
            <asp:DynamicField DataField="correspondingAddress1Second" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress1Second %>"
                Visible="false" />
            <asp:DynamicField DataField="correspondingAddress2First" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress2First %>"
                Visible="false" />
            <asp:DynamicField DataField="correspondingAddress2Second" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress2Second %>"
                Visible="false" />
            <asp:DynamicField DataField="correspondingAddress3First" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress3First %>"
                Visible="false" />
            <asp:DynamicField DataField="correspondingAddress3Second" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress3Second %>"
                Visible="false" />
            <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, outgoingagent_contactPerson %>"
                ItemStyle-CssClass="nameWidth" />
            <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, outgoingagent_tel %>" />
            <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, outgoingagent_fax %>" />
            <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, outgoingagent_email %>" />
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
    <%--    <ext:Window ID="ModalPopupExtenderInsert" runat="server" Title="<%$ Resources:LanguagePack, OutgoingAgentADDItem %>" Icon="Application" Maximizable="true"
        AutoScroll="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeL %>">
        <Content>--%>
    <asp:Panel ID="panAdd" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragAdd" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleAdd" runat="server" Text="<%$ Resources:LanguagePack, OutgoingAgentADDItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="ImageButtonAdd" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <table>
            <tr>
                <td>
                    <asp:DetailsView ID="DetailsViewOutgoingAgent" runat="server" CssClass="masterDe"
                        AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourceOutgoingAgent"
                        DefaultMode="Insert" OnItemInserted="DetailsViewOutgoingAgent_ItemInserted" OnItemInserting="DetailsViewOutgoingAgent_OnItemInserting">
                        <Fields>
                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                Visible="False" />
                            <asp:DynamicField DataField="agentNum" HeaderText="<%$ Resources:master, outgoingagent_agentNum %>" />
                            <asp:DynamicField DataField="agentName" HeaderText="<%$ Resources:master, outgoingagent_agentName %>" />
                            <asp:DynamicField DataField="correspondingAddress1First" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress1First %>" />
                            <asp:DynamicField DataField="correspondingAddress1Second" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress1Second %>" />
                            <asp:DynamicField DataField="correspondingAddress2First" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress2First %>" />
                            <asp:DynamicField DataField="correspondingAddress2Second" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress2Second %>" />
                            <asp:DynamicField DataField="correspondingAddress3First" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress3First %>" />
                            <asp:DynamicField DataField="correspondingAddress3Second" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress3Second %>" />
                            <asp:DynamicField DataField="Country" HeaderText="<%$ Resources:LanguagePack, CountryName  %>" />
                            <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, outgoingagent_contactPerson %>" />
                            <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, outgoingagent_tel %>" />
                            <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, outgoingagent_fax %>" />
                            <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, outgoingagent_email %>" />
                            <asp:CommandField ButtonType="Button" ShowInsertButton="True" />
                        </Fields>
                    </asp:DetailsView>
                </td>
                <td>
                    <asp:Button ID="ButtonOutgoingClientCopyForm" runat="server" Text="<%$ Resources:LanguagePack, lblCopyFromClient %>"
                        CausesValidation="false" OnClick="ButtonClientCopyForm_Click" />
                    <br />
                    <br />
                    <asp:Button ID="LinkButtonCopyFrompop" runat="server" Text="<%$ Resources:LanguagePack, lblCopyFromReferer %>"
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
    <%--    <ext:Window ID="ModalPopupExtenderEdit" runat="server" Title="<%$ Resources:LanguagePack, OutgoingAgentEditItem %>" Icon="Application" Maximizable="true"
        AutoScroll="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeL %>">
        <Content>--%>
    <asp:Panel ID="panAddEdit" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragAddEdit" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleAddEdit" runat="server" Text="<%$ Resources:LanguagePack, OutgoingAgentEditItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancelAddEdit" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewClientUpdate" runat="server" CssClass="masterDe lineHeight"
            AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourceOutgoingAgentEdit"
            DefaultMode="Edit" Visible="False" OnItemUpdated="DetailsViewClientUpdate_ItemUpdated"
            OnItemUpdating="DetailsViewClientUpdate_OnItemUpdating">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField DataField="agentNum" HeaderText="<%$ Resources:master, outgoingagent_agentNum %>"
                    ReadOnly="true" />
                <asp:DynamicField DataField="agentName" HeaderText="<%$ Resources:master, outgoingagent_agentName %>" />
                <asp:DynamicField DataField="correspondingAddress1First" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress1First %>" />
                <asp:DynamicField DataField="correspondingAddress1Second" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress1Second %>" />
                <asp:DynamicField DataField="correspondingAddress2First" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress2First %>" />
                <asp:DynamicField DataField="correspondingAddress2Second" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress2Second %>" />
                <asp:DynamicField DataField="correspondingAddress3First" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress3First %>" />
                <asp:DynamicField DataField="correspondingAddress3Second" HeaderText="<%$ Resources:master, outgoingagent_correspondingAddress3Second %>" />
                <asp:DynamicField DataField="Country" HeaderText="<%$ Resources:LanguagePack, CountryName  %>" />
                <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, outgoingagent_contactPerson %>" />
                <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, outgoingagent_tel %>" />
                <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, outgoingagent_fax %>" />
                <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, outgoingagent_email %>" />
                <asp:CommandField ButtonType="Button" ShowInsertButton="True" ShowEditButton="True"
                    CausesValidation="False" />
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <a id="lnkPopup" runat="server"></a>
    <asp:EntityDataSource ID="EntityDataSourceOutgoingAgent" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="OutgoingAgents" OnSelecting="EntityDataSourceOutgoingAgent_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceOutgoingAgentEdit" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="OutgoingAgents">
    </asp:EntityDataSource>
    <%--    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtendercopyfrompop" runat="server"
        TargetControlID="lnkPopupcopyfrompop" PopupControlID="pancopyfrompop" BackgroundCssClass="modalBackground"
        CancelControlID="btnCancelcopyfrompop" PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pancopyfrompop" runat="server" CssClass="ModalWindow panAddCopyfrom">
        <asp:Label ID="LabelClientName" runat="server" Text="<%$ Resources:LanguagePack, LabelClientName %>"></asp:Label>
        <asp:TextBox ID="TextBoxClientName" runat="server"></asp:TextBox>
        <asp:Button ID="Button_search" runat="server" Text="<%$ Resources:LanguagePack, ButtonSearch %>"
            OnClick="Button_search_Click" CausesValidation="false" />
        <br />
        <br />
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
                <asp:DynamicField DataField="UpdateDate" HeaderText="<%$ Resources:master, client_UpdateDate  %>" />
            </Columns>
            <PagerTemplate>
                <uc:ucPaging ID="ucPaging" runat="server" />
            </PagerTemplate>
        </asp:GridView>
        <asp:Button ID="btnCancelcopyfrompop" runat="server" Text="Cancel" CssClass="displayNone" />
        <asp:Button ID="LinkButtonRefresh" runat="server" CausesValidation="false" Visible="true"
            Text="Back" OnClick="LinkButtonRefresh_Click"></asp:Button>
    </asp:Panel>
    <a id="lnkPopupcopyfrompop" runat="server"></a>
    <asp:EntityDataSource ID="EntityDataSourceClientInsert" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableInsert="True"
        EntitySetName="Clients" ContextTypeName="" EnableDelete="True" EnableUpdate="True"
        OnSelecting="EntityDataSourceClientInsert_Selecting">
    </asp:EntityDataSource>--%>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtendercopyfrompop" runat="server"
        TargetControlID="lnkPopupcopyfrompop" PopupControlID="pancopyfrompop" BackgroundCssClass="modalBackground"
        CancelControlID="btnCancel" PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtendercopyfrompop" runat="server" Title="" Icon="Application" Maximizable="true"
        AutoScroll="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeL %>">
        <Content>--%>
    <asp:Panel ID="pancopyfrompop" runat="server" CssClass="newpopM radiusClass popupWidth"
        Style="display: none;">
        <asp:Panel ID="panDrag" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitle" runat="server" Text="<%$ Resources:LanguagePack, SelectReferer %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/close.png" CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:Label ID="LabelReferName" runat="server" Text="<%$ Resources:LanguagePack, LabelReferName %>"></asp:Label>
        <asp:TextBox ID="TextBoxReferName" runat="server"></asp:TextBox>
        <asp:Button ID="Button_search" runat="server" Text="<%$ Resources:LanguagePack, ButtonSearch %>"
            OnClick="Button_search_Click" CausesValidation="false" />
        <br />
        <br />
        <div class="popupCopy">
            <asp:GridView RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster"
                ID="GridViewCopypop" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                DataSourceID="EntityDataSourceReferer" OnRowCommand="GridViewInsert_RowCommand"
                Visible="true" AllowPaging="true" PageSize="<%$ appSettings:GridViewPageSize %>"
                OnDataBound="GridViewCopy_OnDataBound">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" Text="Copy"
                                CommandName="Select" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                        Visible="False" />
                    <asp:DynamicField DataField="refererNum" HeaderText="<%$ Resources:master, refer_refererNum %>" />
                    <asp:DynamicField DataField="refererName" HeaderText="<%$ Resources:master, refer_refererName %>" />
                    <asp:DynamicField DataField="islegalAid" HeaderText="<%$ Resources:master, refer_islegalAid %>"
                        Visible="false" />
                    <asp:DynamicField DataField="billingAddressFirst" HeaderText="<%$ Resources:master, refer_billingAddressFirst %>"
                        Visible="false" />
                    <asp:DynamicField DataField="billingAddressSecond" HeaderText="<%$ Resources:master, refer_billingAddressSecond %>"
                        Visible="false" />
                    <asp:DynamicField DataField="correspondingAddress1First" HeaderText="<%$ Resources:master, refer_correspondingAddress1First %>"
                        Visible="false" />
                    <asp:DynamicField DataField="correspondingAddress1Second" HeaderText="<%$ Resources:master, refer_correspondingAddress1Second %>"
                        Visible="false" />
                    <asp:DynamicField DataField="correspondingAddress2First" HeaderText="<%$ Resources:master, refer_correspondingAddress2First %>"
                        Visible="false" />
                    <asp:DynamicField DataField="correspondingAddress2Second" HeaderText="<%$ Resources:master, refer_correspondingAddress2Second %>"
                        Visible="false" />
                    <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, refer_contactPerson %>"
                        Visible="false" />
                    <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, refer_tel %>" />
                    <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, refer_fax %>" />
                    <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, refer_email %>" />
                    <asp:DynamicField DataField="OutgoingAgent" HeaderText="<%$ Resources:master, refer_OutgoingAgent %>" />
                    <asp:DynamicField DataField="remark" HeaderText="<%$ Resources:master, clientRemarks  %>" />
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
    <asp:EntityDataSource ID="EntityDataSourceReferer" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableInsert="True"
        EntitySetName="Referers" EnableDelete="True" EnableUpdate="True" OnSelecting="EntityDataSourceReferer_Selecting">
    </asp:EntityDataSource>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtendercopyfrompopClient" runat="server"
        TargetControlID="lnkPopupcopyfrompop" PopupControlID="pancopyfrompopClient" BackgroundCssClass="modalBackground"
        CancelControlID="btnCancelClient" PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pancopyfrompopClient" runat="server" CssClass="newpopM radiusClass popupWidth"
        Style="display: none;">
        <asp:Panel ID="panDragClient" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleClient" runat="server" Text="<%$ Resources:LanguagePack, SelectClient %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancelClient" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:Label ID="LabelClientName" runat="server" Text="<%$ Resources:LanguagePack, LabelClientName %>"></asp:Label>
        <asp:TextBox ID="TextBoxClientName" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonClientSearchName" runat="server" Text="<%$ Resources:LanguagePack, ButtonSearch %>"
            OnClick="ButtonClientSearchName_Click" CausesValidation="false" />
        <br />
        <br />
        <div class="popupCopy">
            <asp:GridView OnDataBound="GridViewCopyClient_OnDataBound" RowStyle-CssClass="lineGridviewMaster"
                HeaderStyle-CssClass="lineGridviewMaster" ID="GridViewPopupCopyClient" runat="server"
                AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSourcePopupCopyClient"
                OnRowCommand="GridViewClientInsert_RowCommand" Visible="true" AllowPaging="true"
                PageSize="<%$ appSettings:GridViewPageSize %>">
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
                    <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, client_email  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, client_fax  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="billingEmail" HeaderText="<%$ Resources:master, client_billingEmail  %>"
                        Visible="false" />
                    <asp:DynamicField DataField="Referer" HeaderText="<%$ Resources:master, client_Referer  %>" />
                    <asp:DynamicField DataField="discount" HeaderText="<%$ Resources:master, client_discount  %>" />
                    <asp:DynamicField DataField="refNumOfReferer" HeaderText="<%$ Resources:master, client_refNumOfReferer  %>" />
                    <asp:DynamicField DataField="ioNumOfReferer" HeaderText="<%$ Resources:master, client_ioNumOfReferer  %>" />
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
        <asp:Button ID="LinkButtonRefreshClient" runat="server" CausesValidation="false"
            Visible="true" Text="Back" OnClick="LinkButtonRefreshClient_Click"></asp:Button>
    </asp:Panel>
    <asp:EntityDataSource ID="EntityDataSourcePopupCopyClient" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableInsert="True"
        EntitySetName="Clients" ContextTypeName="" EnableDelete="True" EnableUpdate="True"
        OnSelecting="EntityDataSourcePopupCopyClient_Selecting">
    </asp:EntityDataSource>
</asp:Content>
