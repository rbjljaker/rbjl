<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="Referer.aspx.cs" Inherits="Master_Referer" %>

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
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, RefererlblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Panel ID="searchPanel" runat="server">
        <div class="searchBox newpopM radiusClass">
            <asp:Label ID="LabelName" runat="server" Text="<%$ Resources:LanguagePack, SearchRefererName %>"></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonSearchName" runat="server" Text="<%$ Resources:LanguagePack, ButtonSearch %>"
                OnClick="ButtonSearchName_Click" CausesValidation="false" />
            <br />
            <br />
        </div>
    </asp:Panel>
    <asp:GridView OnDataBound="GridViewReferer_OnDataBound" RowStyle-CssClass="lineGridviewMaster"
        HeaderStyle-CssClass="lineGridviewMaster" ID="GridViewReferer" runat="server"
        AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSourceReferer"
        PageSize="<%$ appSettings:GridViewPageSize %>" OnSelectedIndexChanged="GridViewReferer_SelectedIndexChanged"
        ShowHeaderWhenEmpty="True" EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>"
        AllowSorting="true" OnRowCommand="GridViewReferer_RowCommand" 
        onrowdeleted="GridViewReferer_RowDeleted">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <asp:DynamicField DataField="refererNum" HeaderText="<%$ Resources:master, refer_refererNum %>" />
            <%--<asp:DynamicField DataField="refererName" HeaderText="<%$ Resources:master, refer_refererName %>" />--%>
            <asp:TemplateField ConvertEmptyStringToNull="False">
                <ItemStyle CssClass="nameWidth" />
                <ItemTemplate>
                    <asp:DynamicControl ID="DynamicControl1" runat="server" DataField="refererName" Mode="ReadOnly" />
                </ItemTemplate>
                <HeaderTemplate>
                    <div class="callSearch">
                        <asp:LinkButton ID="NameHeaderLinkButton" runat="server" Text="<%$ Resources:master, refer_refererName  %>"
                            CommandName="Sort" CommandArgument="refererName" CausesValidation="false" />
                    </div>
                </HeaderTemplate>
            </asp:TemplateField>
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
            <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, refer_contactPerson %>" />
            <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, refer_tel %>" />
            <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, refer_fax %>" />
            <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, refer_email %>" />
            <asp:DynamicField DataField="OutgoingAgent" HeaderText="<%$ Resources:master, refer_OutgoingAgent %>" />
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:Button ID="LinkButtonUpdate" runat="server" CausesValidation="false" CommandName="Update"
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
    <%--    <ext:Window ID="ModalPopupExtenderInsert" runat="server" Title="<%$ Resources:LanguagePack, RefererADDItem %>"
        Icon="Application" Maximizable="true" AutoScroll="true" Modal="true" Hidden="true"
        Width="<%$ appSettings:windWidthSize %>" Height="<%$ appSettings:windHeightSizeL %>">
        <Content>--%>
    <asp:Panel ID="panAdd" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragAdd" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleAdd" runat="server" Text="<%$ Resources:LanguagePack, RefererADDItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="ImageButtonAdd" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <div class="popupH">
            <table class="">
                <tr>
                    <td>
                        <asp:DetailsView ID="DetailsViewReferer" runat="server" CssClass="masterDe" DataSourceID="EntityDataSourceReferer"
                            AutoGenerateRows="False" DataKeyNames="id" DefaultMode="Insert" OnItemInserted="DetailsViewReferer_ItemInserted"
                            AllowPaging="True" OnDataBound="DetailsViewReferer_DataBound" OnItemInserting="DetailsViewReferer_OnItemInserting">
                            <Fields>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                    Visible="False" />
                                <asp:DynamicField DataField="refererNum" HeaderText="<%$ Resources:master, refer_refererNum %>" />
                                <asp:DynamicField DataField="refererName" HeaderText="<%$ Resources:master, refer_refererName %>" />
                                <asp:DynamicField DataField="islegalAid" HeaderText="<%$ Resources:master, refer_islegalAid %>"
                                    Visible="false" />
                                <asp:DynamicField DataField="billingAddressFirst" HeaderText="<%$ Resources:master, refer_billingAddressFirst %>" />
                                <asp:DynamicField DataField="billingAddressSecond" HeaderText="<%$ Resources:master, refer_billingAddressSecond %>" />
                                <asp:DynamicField DataField="correspondingAddress1First" HeaderText="<%$ Resources:master, refer_correspondingAddress1First %>" />
                                <asp:DynamicField DataField="correspondingAddress1Second" HeaderText="<%$ Resources:master, refer_correspondingAddress1Second %>" />
                                <asp:DynamicField DataField="correspondingAddress2First" HeaderText="<%$ Resources:master, refer_correspondingAddress2First %>" />
                                <asp:DynamicField DataField="correspondingAddress2Second" HeaderText="<%$ Resources:master, refer_correspondingAddress2Second %>" />
                                <asp:DynamicField DataField="Country" HeaderText="<%$ Resources:LanguagePack, CountryName  %>" />
                                <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, refer_contactPerson %>" />
                                <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, refer_tel %>" />
                                <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, refer_email %>" />
                                <asp:DynamicField DataField="contactPerson02" HeaderText="<%$ Resources:master, client_contactPerson02  %>" />
                                <asp:DynamicField DataField="tel02" HeaderText="<%$ Resources:master, client_tel02  %>" />
                                <asp:DynamicField DataField="email02" HeaderText="<%$ Resources:master, client_email02  %>" />
                                <asp:DynamicField DataField="contactPerson03" HeaderText="<%$ Resources:master, client_contactPerson03  %>" />
                                <asp:DynamicField DataField="tel03" HeaderText="<%$ Resources:master, client_tel03  %>" />
                                <asp:DynamicField DataField="email03" HeaderText="<%$ Resources:master, client_email03  %>" />
                                <asp:DynamicField DataField="contactPerson04" HeaderText="<%$ Resources:master, client_contactPerson04  %>" />
                                <asp:DynamicField DataField="tel04" HeaderText="<%$ Resources:master, client_tel04  %>" />
                                <asp:DynamicField DataField="email04" HeaderText="<%$ Resources:master, client_email04  %>" />
                                <asp:DynamicField DataField="contactPerson05" HeaderText="<%$ Resources:master, client_contactPerson05  %>" />
                                <asp:DynamicField DataField="tel05" HeaderText="<%$ Resources:master, client_tel05  %>" />
                                <asp:DynamicField DataField="email05" HeaderText="<%$ Resources:master, client_email05  %>" />
                                <asp:DynamicField DataField="contactPerson06" HeaderText="<%$ Resources:master, client_contactPerson06  %>" />
                                <asp:DynamicField DataField="tel06" HeaderText="<%$ Resources:master, client_tel06  %>" />
                                <asp:DynamicField DataField="email06" HeaderText="<%$ Resources:master, client_email06  %>" />
                                <asp:DynamicField DataField="contactPerson07" HeaderText="<%$ Resources:master, client_contactPerson07  %>" />
                                <asp:DynamicField DataField="tel07" HeaderText="<%$ Resources:master, client_tel07  %>" />
                                <asp:DynamicField DataField="email07" HeaderText="<%$ Resources:master, client_email07  %>" />
                                <asp:DynamicField DataField="contactPerson08" HeaderText="<%$ Resources:master, client_contactPerson08  %>" />
                                <asp:DynamicField DataField="tel08" HeaderText="<%$ Resources:master, client_tel08  %>" />
                                <asp:DynamicField DataField="email08" HeaderText="<%$ Resources:master, client_email08  %>" />
                                <asp:DynamicField DataField="contactPerson09" HeaderText="<%$ Resources:master, client_contactPerson09  %>" />
                                <asp:DynamicField DataField="tel09" HeaderText="<%$ Resources:master, client_tel09  %>" />
                                <asp:DynamicField DataField="email09" HeaderText="<%$ Resources:master, client_email09  %>" />
                                <asp:DynamicField DataField="contactPerson10" HeaderText="<%$ Resources:master, client_contactPerson10  %>" />
                                <asp:DynamicField DataField="tel10" HeaderText="<%$ Resources:master, client_tel10  %>" />
                                <asp:DynamicField DataField="email10" HeaderText="<%$ Resources:master, client_email10  %>" />
                                <asp:DynamicField DataField="contactPerson11" HeaderText="<%$ Resources:master, client_contactPerson11  %>" />
                                <asp:DynamicField DataField="tel11" HeaderText="<%$ Resources:master, client_tel11  %>" />
                                <asp:DynamicField DataField="email11" HeaderText="<%$ Resources:master, client_email11  %>" />
                                <asp:DynamicField DataField="contactPerson12" HeaderText="<%$ Resources:master, client_contactPerson12  %>" />
                                <asp:DynamicField DataField="tel12" HeaderText="<%$ Resources:master, client_tel12  %>" />
                                <asp:DynamicField DataField="email12" HeaderText="<%$ Resources:master, client_email12  %>" />
                                <asp:DynamicField DataField="contactPerson13" HeaderText="<%$ Resources:master, client_contactPerson13  %>" />
                                <asp:DynamicField DataField="tel13" HeaderText="<%$ Resources:master, client_tel13  %>" />
                                <asp:DynamicField DataField="email13" HeaderText="<%$ Resources:master, client_email13  %>" />
                                <asp:DynamicField DataField="contactPerson14" HeaderText="<%$ Resources:master, client_contactPerson14  %>" />
                                <asp:DynamicField DataField="tel14" HeaderText="<%$ Resources:master, client_tel14  %>" />
                                <asp:DynamicField DataField="email14" HeaderText="<%$ Resources:master, client_email14  %>" />
                                <asp:DynamicField DataField="contactPerson15" HeaderText="<%$ Resources:master, client_contactPerson15  %>" />
                                <asp:DynamicField DataField="tel15" HeaderText="<%$ Resources:master, client_tel15  %>" />
                                <asp:DynamicField DataField="email15" HeaderText="<%$ Resources:master, client_email15  %>" />
                                <asp:DynamicField DataField="contactPerson16" HeaderText="<%$ Resources:master, client_contactPerson16  %>" />
                                <asp:DynamicField DataField="tel16" HeaderText="<%$ Resources:master, client_tel16  %>" />
                                <asp:DynamicField DataField="email16" HeaderText="<%$ Resources:master, client_email16  %>" />
                                <asp:DynamicField DataField="contactPerson17" HeaderText="<%$ Resources:master, client_contactPerson17  %>" />
                                <asp:DynamicField DataField="tel17" HeaderText="<%$ Resources:master, client_tel17  %>" />
                                <asp:DynamicField DataField="email17" HeaderText="<%$ Resources:master, client_email17  %>" />
                                <asp:DynamicField DataField="contactPerson18" HeaderText="<%$ Resources:master, client_contactPerson18  %>" />
                                <asp:DynamicField DataField="tel18" HeaderText="<%$ Resources:master, client_tel18  %>" />
                                <asp:DynamicField DataField="email18" HeaderText="<%$ Resources:master, client_email18  %>" />
                                <asp:DynamicField DataField="contactPerson19" HeaderText="<%$ Resources:master, client_contactPerson19  %>" />
                                <asp:DynamicField DataField="tel19" HeaderText="<%$ Resources:master, client_tel19  %>" />
                                <asp:DynamicField DataField="email19" HeaderText="<%$ Resources:master, client_email19 %>" />
                                <asp:DynamicField DataField="contactPerson20" HeaderText="<%$ Resources:master, client_contactPerson20  %>" />
                                <asp:DynamicField DataField="tel20" HeaderText="<%$ Resources:master, client_tel20  %>" />
                                <asp:DynamicField DataField="email20" HeaderText="<%$ Resources:master, client_email20  %>" />
                                <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, refer_fax %>" />
                                <asp:DynamicField DataField="OutgoingAgent" HeaderText="<%$ Resources:master, refer_OutgoingAgent %>" />
                                <asp:DynamicField DataField="remark" HeaderText="<%$ Resources:LanguagePack, refer_Remark %>" />
                                <asp:CommandField ButtonType="Button" ShowInsertButton="True" ShowDeleteButton="True" />
                            </Fields>
                        </asp:DetailsView>
                    </td>
                    <td>
                        <asp:Button ID="LinkButtonCopyFrompop" runat="server" Text="<%$ Resources:LanguagePack, lblCopyFromClient %>"
                            OnClick="LinkButtonCopyFrompop_onclick" CausesValidation="false" />
                        <br />
                        <br />
                        <asp:Button ID="ButtonOutgoingAgentCopyForm" runat="server" Text="<%$ Resources:master, clientCopyFormOutgoingAgent %>"
                            CausesValidation="false" OnClick="ButtonOutgoingAgentCopyForm_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <a id="lnkPopup" runat="server"></a>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEdit" runat="server" TargetControlID="lnkPopupEdit"
        PopupControlID="panAddEdit" BackgroundCssClass="modalBackground" CancelControlID="btnCancelAddEdit"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtenderEdit" runat="server" Title="<%$ Resources:LanguagePack, RefererEditItem %>"
        Icon="Application" Maximizable="true" AutoScroll="true" Modal="true" Hidden="true"
        Width="<%$ appSettings:windWidthSize %>" Height="<%$ appSettings:windHeightSizeL %>">
        <Content>--%>
    <asp:Panel ID="panAddEdit" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragAddEdit" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleAddEdit" runat="server" Text="<%$ Resources:LanguagePack, RefererEditItem %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancelAddEdit" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <div class="popupH">
            <asp:DetailsView ID="DetailsViewClientUpdate" runat="server" CssClass="masterDe lineHeight"
                AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourceRefererEdit"
                DefaultMode="Edit" Visible="False" OnItemUpdated="DetailsViewClientUpdate_ItemUpdated"
                OnItemUpdating="DetailsViewClientUpdate_OnItemUpdating">
                <Fields>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                        Visible="False" />
                    <asp:DynamicField DataField="refererNum" HeaderText="<%$ Resources:master, refer_refererNum %>"
                        ReadOnly="true" />
                    <asp:DynamicField DataField="refererName" HeaderText="<%$ Resources:master, refer_refererName %>" />
                    <asp:DynamicField DataField="islegalAid" HeaderText="<%$ Resources:master, refer_islegalAid %>"
                        Visible="false" />
                    <asp:DynamicField DataField="billingAddressFirst" HeaderText="<%$ Resources:master, refer_billingAddressFirst %>" />
                    <asp:DynamicField DataField="billingAddressSecond" HeaderText="<%$ Resources:master, refer_billingAddressSecond %>" />
                    <asp:DynamicField DataField="correspondingAddress1First" HeaderText="<%$ Resources:master, refer_correspondingAddress1First %>" />
                    <asp:DynamicField DataField="correspondingAddress1Second" HeaderText="<%$ Resources:master, refer_correspondingAddress1Second %>" />
                    <asp:DynamicField DataField="correspondingAddress2First" HeaderText="<%$ Resources:master, refer_correspondingAddress2First %>" />
                    <asp:DynamicField DataField="correspondingAddress2Second" HeaderText="<%$ Resources:master, refer_correspondingAddress2Second %>" />
                    <asp:DynamicField DataField="Country" HeaderText="<%$ Resources:LanguagePack, CountryName  %>" />
                    <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, refer_contactPerson %>" />
                    <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, refer_tel %>" />
                    <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, refer_email %>" />
                    <asp:DynamicField DataField="contactPerson02" HeaderText="<%$ Resources:master, client_contactPerson02  %>" />
                    <asp:DynamicField DataField="tel02" HeaderText="<%$ Resources:master, client_tel02  %>" />
                    <asp:DynamicField DataField="email02" HeaderText="<%$ Resources:master, client_email02  %>" />
                    <asp:DynamicField DataField="contactPerson03" HeaderText="<%$ Resources:master, client_contactPerson03  %>" />
                    <asp:DynamicField DataField="tel03" HeaderText="<%$ Resources:master, client_tel03  %>" />
                    <asp:DynamicField DataField="email03" HeaderText="<%$ Resources:master, client_email03  %>" />
                    <asp:DynamicField DataField="contactPerson04" HeaderText="<%$ Resources:master, client_contactPerson04  %>" />
                    <asp:DynamicField DataField="tel04" HeaderText="<%$ Resources:master, client_tel04  %>" />
                    <asp:DynamicField DataField="email04" HeaderText="<%$ Resources:master, client_email04  %>" />
                    <asp:DynamicField DataField="contactPerson05" HeaderText="<%$ Resources:master, client_contactPerson05  %>" />
                    <asp:DynamicField DataField="tel05" HeaderText="<%$ Resources:master, client_tel05  %>" />
                    <asp:DynamicField DataField="email05" HeaderText="<%$ Resources:master, client_email05  %>" />
                    <asp:DynamicField DataField="contactPerson06" HeaderText="<%$ Resources:master, client_contactPerson06  %>" />
                    <asp:DynamicField DataField="tel06" HeaderText="<%$ Resources:master, client_tel06  %>" />
                    <asp:DynamicField DataField="email06" HeaderText="<%$ Resources:master, client_email06  %>" />
                    <asp:DynamicField DataField="contactPerson07" HeaderText="<%$ Resources:master, client_contactPerson07  %>" />
                    <asp:DynamicField DataField="tel07" HeaderText="<%$ Resources:master, client_tel07  %>" />
                    <asp:DynamicField DataField="email07" HeaderText="<%$ Resources:master, client_email07  %>" />
                    <asp:DynamicField DataField="contactPerson08" HeaderText="<%$ Resources:master, client_contactPerson08  %>" />
                    <asp:DynamicField DataField="tel08" HeaderText="<%$ Resources:master, client_tel08  %>" />
                    <asp:DynamicField DataField="email08" HeaderText="<%$ Resources:master, client_email08  %>" />
                    <asp:DynamicField DataField="contactPerson09" HeaderText="<%$ Resources:master, client_contactPerson09  %>" />
                    <asp:DynamicField DataField="tel09" HeaderText="<%$ Resources:master, client_tel09  %>" />
                    <asp:DynamicField DataField="email09" HeaderText="<%$ Resources:master, client_email09  %>" />
                    <asp:DynamicField DataField="contactPerson10" HeaderText="<%$ Resources:master, client_contactPerson10  %>" />
                    <asp:DynamicField DataField="tel10" HeaderText="<%$ Resources:master, client_tel10  %>" />
                    <asp:DynamicField DataField="email10" HeaderText="<%$ Resources:master, client_email10  %>" />
                    <asp:DynamicField DataField="contactPerson11" HeaderText="<%$ Resources:master, client_contactPerson11  %>" />
                    <asp:DynamicField DataField="tel11" HeaderText="<%$ Resources:master, client_tel11  %>" />
                    <asp:DynamicField DataField="email11" HeaderText="<%$ Resources:master, client_email11  %>" />
                    <asp:DynamicField DataField="contactPerson12" HeaderText="<%$ Resources:master, client_contactPerson12  %>" />
                    <asp:DynamicField DataField="tel12" HeaderText="<%$ Resources:master, client_tel12  %>" />
                    <asp:DynamicField DataField="email12" HeaderText="<%$ Resources:master, client_email12  %>" />
                    <asp:DynamicField DataField="contactPerson13" HeaderText="<%$ Resources:master, client_contactPerson13  %>" />
                    <asp:DynamicField DataField="tel13" HeaderText="<%$ Resources:master, client_tel13  %>" />
                    <asp:DynamicField DataField="email13" HeaderText="<%$ Resources:master, client_email13  %>" />
                    <asp:DynamicField DataField="contactPerson14" HeaderText="<%$ Resources:master, client_contactPerson14  %>" />
                    <asp:DynamicField DataField="tel14" HeaderText="<%$ Resources:master, client_tel14  %>" />
                    <asp:DynamicField DataField="email14" HeaderText="<%$ Resources:master, client_email14  %>" />
                    <asp:DynamicField DataField="contactPerson15" HeaderText="<%$ Resources:master, client_contactPerson15  %>" />
                    <asp:DynamicField DataField="tel15" HeaderText="<%$ Resources:master, client_tel15  %>" />
                    <asp:DynamicField DataField="email15" HeaderText="<%$ Resources:master, client_email15  %>" />
                    <asp:DynamicField DataField="contactPerson16" HeaderText="<%$ Resources:master, client_contactPerson16  %>" />
                    <asp:DynamicField DataField="tel16" HeaderText="<%$ Resources:master, client_tel16  %>" />
                    <asp:DynamicField DataField="email16" HeaderText="<%$ Resources:master, client_email16  %>" />
                    <asp:DynamicField DataField="contactPerson17" HeaderText="<%$ Resources:master, client_contactPerson17  %>" />
                    <asp:DynamicField DataField="tel17" HeaderText="<%$ Resources:master, client_tel17  %>" />
                    <asp:DynamicField DataField="email17" HeaderText="<%$ Resources:master, client_email17  %>" />
                    <asp:DynamicField DataField="contactPerson18" HeaderText="<%$ Resources:master, client_contactPerson18  %>" />
                    <asp:DynamicField DataField="tel18" HeaderText="<%$ Resources:master, client_tel18  %>" />
                    <asp:DynamicField DataField="email18" HeaderText="<%$ Resources:master, client_email18  %>" />
                    <asp:DynamicField DataField="contactPerson19" HeaderText="<%$ Resources:master, client_contactPerson19  %>" />
                    <asp:DynamicField DataField="tel19" HeaderText="<%$ Resources:master, client_tel19  %>" />
                    <asp:DynamicField DataField="email19" HeaderText="<%$ Resources:master, client_email19 %>" />
                    <asp:DynamicField DataField="contactPerson20" HeaderText="<%$ Resources:master, client_contactPerson20  %>" />
                    <asp:DynamicField DataField="tel20" HeaderText="<%$ Resources:master, client_tel20  %>" />
                    <asp:DynamicField DataField="email20" HeaderText="<%$ Resources:master, client_email20  %>" />
                    <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, refer_fax %>" />
                    <asp:DynamicField DataField="OutgoingAgent" HeaderText="<%$ Resources:master, refer_OutgoingAgent %>" />
                    <asp:DynamicField DataField="remark" HeaderText="<%$ Resources:LanguagePack, refer_Remark %>" />
                    <asp:CommandField ButtonType="Button" ShowInsertButton="True" ShowEditButton="True"
                        CausesValidation="False" />
                </Fields>
            </asp:DetailsView>
        </div>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <a id="lnkPopupEdit" runat="server"></a>
    <asp:EntityDataSource ID="EntityDataSourceReferer" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableInsert="True"
        EntitySetName="Referers" EnableDelete="True" EnableUpdate="True" OnSelecting="EntityDataSourceReferer_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceRefererEdit" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableInsert="True"
        EntitySetName="Referers" EnableDelete="True" EnableUpdate="True">
    </asp:EntityDataSource>
    <!--client//////////////////////////////////////////////////////////////////////////////////////////////////////////-->
    <!--client//////////////////////////////////////////////////////////////////////////////////////////////////////////-->
    <br />
    <%--    <asp:Button ID="LinkButtonCopyFrom" runat="server" Text="Copy From Client" OnClick="LinkButtonCopyFrom_onclick"
        CausesValidation="false" />
    --%><%--    <asp:GridView OnDataBound="GridViewCopy_OnDataBound" RowStyle-CssClass="lineGridviewMaster"
        HeaderStyle-CssClass="lineGridviewMaster" ID="GridViewCopy" runat="server" AutoGenerateColumns="False"
        DataKeyNames="id" DataSourceID="EntityDataSourceClientInsert" OnRowCommand="GridViewInsert_RowCommand"
        Visible="false" AllowPaging="true" PageSize="<%$ appSettings:GridViewPageSize %>">
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
    --%>
    <asp:EntityDataSource ID="EntityDataSourceClientInsert" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableInsert="True"
        EntitySetName="Clients" ContextTypeName="" EnableDelete="True" EnableUpdate="True"
        OnSelecting="EntityDataSourceClientInsert_Selecting">
    </asp:EntityDataSource>
    <%--    <asp:Button ID="LinkButtonRefresh" runat="server" CausesValidation="false" Visible="false"
        Text="Back" OnClick="LinkButtonRefresh_Click"></asp:Button>
    --%>
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
                    <%-- <asp:DynamicField DataField="isReleaseToPublic" HeaderText="<%$ Resources:master, client_isReleaseToPublic  %>" />--%>
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
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtendercopyfrompopOutgoingAgent" runat="server"
        TargetControlID="lnkPopupcopyfrompop" PopupControlID="pancopyfrompopOutgoingAgent"
        BackgroundCssClass="modalBackground" CancelControlID="btnCancelOutgoingAgent"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pancopyfrompopOutgoingAgent" runat="server" CssClass="newpopM radiusClass popupWidth"
        Style="display: none;">
        <asp:Panel ID="panDragOutgoingAgent" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleOutgoingAgent" runat="server" Text="<%$ Resources:LanguagePack, SelectOutgoingAgent %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancelOutgoingAgent" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:Label ID="LabelOutgoingAgentName" runat="server" Text="<%$ Resources:LanguagePack, LabelOutgoingAgentName %>"></asp:Label>
        <asp:TextBox ID="TextBoxOutgoingAgent" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonOutgoingAgentSearch" runat="server" Text="<%$ Resources:LanguagePack, ButtonSearch %>"
            OnClick="ButtonOutgoingAgentSearch_Click" CausesValidation="false" />
        <br />
        <br />
        <div class="popupCopy">
            <asp:GridView OnDataBound="GridViewOutgoingAgent_OnDataBound" RowStyle-CssClass="lineGridviewMaster"
                HeaderStyle-CssClass="lineGridviewMaster" ID="GridViewOutgoingAgent" runat="server"
                AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSourceOutgoingAgent"
                AllowPaging="true" PageSize="<%$ appSettings:GridViewPageSize %>" ShowHeaderWhenEmpty="True"
                EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>" OnRowCommand="GridViewOutgoingAgent_RowCommand">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                        Visible="False" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" Text="Copy"
                                CommandName="Select" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:DynamicField DataField="agentNum" HeaderText="<%$ Resources:master, outgoingagent_agentNum %>" />
                    <asp:DynamicField DataField="agentName" HeaderText="<%$ Resources:master, outgoingagent_agentName %>" />
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
                </Columns>
                <PagerTemplate>
                    <uc:ucPaging ID="ucPaging" runat="server" />
                </PagerTemplate>
            </asp:GridView>
        </div>
        <br />
        <asp:Button ID="LinkButtonRefreshOutgoingAgent" runat="server" CausesValidation="false"
            Visible="true" Text="Back" OnClick="LinkButtonRefreshOutgoingAgent_Click"></asp:Button>
    </asp:Panel>
    <asp:EntityDataSource ID="EntityDataSourceOutgoingAgent" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="OutgoingAgents" OnSelecting="EntityDataSourceOutgoingAgent_Selecting">
    </asp:EntityDataSource>
</asp:Content>
