<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="PendingList.aspx.cs" Inherits="DebitNote_PendingList" %>

<%@ Register Src="~/WebControl/LBLFeeEarner.ascx" TagName="WebUserControlLBLFeeEarner"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLDoworkTitle.ascx" TagName="WebUserControlLBLDoworkTitle"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLUserName.ascx" TagName="WebUserControlLBLUserName"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function setDisplayNone() {
            $(".isDisplay").each(function () {
                $(this).parent().css("display", "none");
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, pendingListDebitNoteTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:HiddenField ID="HiddenFieldDebitNote" runat="server" />
    <asp:GridView ID="GridViewDebitNote" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
        DataSourceID="EntityDataSourceDebitNote" OnRowCommand="GridViewDebitNote_RowCommand"
        EmptyDataText='<%$ Resources:LanguagePack, debitnotePendingNotData %>' RowStyle-CssClass="lineGridviewMaster"
        HeaderStyle-CssClass="lineGridviewMaster" Width="750px" AllowSorting="true" CssClass="debitNotePendingTable">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="false" />
            <%--            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    &nbsp;<asp:LinkButton ID="LinkButtonCancel" runat="server" CausesValidation="False"
                        CommandName="Cancel" Text="<%$ Resources:LanguagePack, lblCancel %>"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonEditPopup" runat="server" OnClick="LinkButtonEditPopup_Click" CausesValidation="False"
                       Text="<%$ Resources:LanguagePack, lblEdit %>" CommandName="Select" />

                    &nbsp;<asp:LinkButton ID="LinkButtonDelete" runat="server" CausesValidation="False"
                        CommandName="Delete" Text="<%$ Resources:LanguagePack, lblDelete %>" OnClientClick="<%$ Resources:LanguagePack, DeleteConfirm %>"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            --%>
            <%--            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, debitNotependinglist_item %>" SortExpression="MatterCore.matterNum">
                <ItemTemplate>
                    <asp:Label ID="LabelItemNum111" runat="server" Text='<%# Eval("MatterCore.matterNum") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, debitNotependinglist_item %>">
                <ItemTemplate>
                    <asp:Label ID="LabelItemNum" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:DynamicField DataField="endDate" HeaderText="<%$ Resources:LanguagePack, debitNotependinglist_endDate %>" />--%>
            <asp:DynamicField DataField="category" HeaderText="<%$ Resources:LanguagePack, DebitNoteCategory %>" />
            <asp:DynamicField DataField="Client" HeaderText="<%$ Resources:LanguagePack, MatterNew_clientName %>" />
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, MatterNew_matterNum %>"
                SortExpression="MatterCore.matterNum">
                <ItemTemplate>
                    <asp:Label ID="LabelMatterNum" runat="server" Text='<%# getMatterNum(Eval("matterNumIdList"),Eval("matterNumId")) %>'>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="subject" HeaderText="<%$ Resources:LanguagePack, DebitNoteSubject %>" />
            <%--   <asp:DynamicField DataField="SubjectType" HeaderText="SubjectType" />--%>
            <asp:DynamicField DataField="Referer" HeaderText="<%$ Resources:LanguagePack, debitNotependinglist_Referer %>" />
            <%--            <asp:DynamicField DataField="ref" HeaderText="<%$ Resources:LanguagePack, debitNotependinglist_ref %>"
                ItemStyle-CssClass="refWidth" />--%>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, debitNotependinglist_ref %>"
                SortExpression="ref" ItemStyle-CssClass="refWidth">
                <ItemTemplate>
                    <asp:Label ID="LabelRef" runat="server" Text='<%# getMatterRef(Eval("ref")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, MatterNewUpdateByName %>"
                SortExpression="UpdateByUserId">
                <ItemTemplate>
                    <uc1:WebUserControlLBLUserName ID="ucGetUserName" runat="server" userGuid='<%# Eval("UpdateByUserId")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                        <div onclick="$('.submenu').not($(this).next()).css('display','none'); $(this).next().toggle();" style="cursor:pointer; background-color: #ED941B;padding: 5px;margin: 5px;">Menu</div>
                        <div class="submenu" style="display: none; position: absolute;">
                            <asp:Button ID="ButtonView" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="viewReport"
                                Text="View report" />
                            <br>
                            <!--
                            <asp:Button ID="ButtonViewReport2" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="viewReport2"
                                Text="View report with header" />
                            <br />
                            -->
                            <asp:Button ID="ButtonDownloadAtt" runat="server" CommandArgument='<%# Eval("id") %>'
                                CausesValidation="False" CommandName="DownloadAtt" Text="<%$ Resources:LanguagePack, debitNoteDownloadAtt %>">
                            </asp:Button>
                            <br />
                            <asp:Button ID="LinkButtonSelect" runat="server" CommandArgument='<%# Eval("id") %>'
                                CausesValidation="False" CommandName="Select" Text="<%$ Resources:LanguagePack, debitnotependinglist_enter %>">
                            </asp:Button>
                            <br />
                            <asp:Button ID="ButtonEdit" runat="server" CommandArgument='<%# Eval("id") %>' CausesValidation="False"
                                CommandName="Edit" Text="<%$ Resources:LanguagePack, lblEdit %>"></asp:Button>
                            <br />
                            <asp:Button ID="LinkButtonDelete" runat="server" CausesValidation="False" CommandName="DeleteDebitNote"
                                CommandArgument='<%# Eval("id") %>' Text="<%$ Resources:LanguagePack, lblDelete %>"
                                OnClientClick="<%$ Resources:LanguagePack, DeleteConfirm %>"></asp:Button>
                    <div>
                </ItemTemplate>
            </asp:TemplateField>
            <%--            <asp:CommandField ShowSelectButton="True" SelectText="<%$ Resources:LanguagePack, debitnotependinglist_enter %>"
                ButtonType="Button" ShowEditButton="true" EditText="Edit" />--%>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="lineGridviewMaster"></HeaderStyle>
        <RowStyle CssClass="lineGridviewMaster"></RowStyle>
    </asp:GridView>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEdit" runat="server" TargetControlID="lnkPopupEdit"
        PopupControlID="panAddEdit" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtenderEdit" runat="server" Title="<%$ Resources:LanguagePack, PendingListDebitNoteEnterNum %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeM %>">
        <Content>--%>
    <asp:Panel ID="panAddEdit" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDrag" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitle" runat="server" Text="<%$ Resources:LanguagePack, PendingListDebitNoteEnterNum %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/close.png" CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewMatter" runat="server" CssClass="masterDe lineHeight"
            AutoGenerateRows="False" DataKeyNames="id" DefaultMode="Edit" DataSourceID="EntityDataSourceMatterEdit"
            OnItemUpdated="DetailsViewMatter_ItemUpdated" OnItemUpdating="DetailsViewMatter_ItemUpdating"
            OnItemCommand="DetailsViewMatter_ItemCommand" OnDataBound="DetailsViewMatter_DataBound">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:DynamicField ItemStyle-CssClass="isDisplay" DataField="debitNoteNum" HeaderText="<%$ Resources:LanguagePack, debitNotependinglist_debitNoteNum %>" />
                <asp:TemplateField HeaderText="Date">
                    <ItemStyle CssClass="isDisplay" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxReportDate" runat="server" Text='<%# Bind("reportDate") %>'></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderReportDate" runat="server" TargetControlID="TextBoxReportDate"
                            Format="dd-MMM-yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderReportDate" runat="server"
                            TargetControlID="TextBoxReportDate" WatermarkText="dd-Jan-YYYY">
                        </ajaxToolkit:TextBoxWatermarkExtender>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:DynamicField DataField="Client" HeaderText="<%$ Resources:LanguagePack, Pendinglist_Client %>"
                    ReadOnly="true" />
                <%--<asp:DynamicField DataField="endDate" HeaderText="<%$ Resources:LanguagePack, debitNotependinglist_endDate %>" />--%>
                <asp:DynamicField DataField="category" HeaderText="<%$ Resources:LanguagePack, DebitNoteCategory %>"
                    ReadOnly="true" />
                <asp:DynamicField DataField="subject" HeaderText="<%$ Resources:LanguagePack, DebitNoteSubject %>"
                    ReadOnly="true" />
                <asp:DynamicField DataField="Referer" HeaderText="<%$ Resources:LanguagePack, debitNotependinglist_Referer %>"
                    ReadOnly="true" />
                <asp:DynamicField DataField="ref" HeaderText="<%$ Resources:LanguagePack, debitNotependinglist_ref %>"
                    ReadOnly="true" />
                <asp:DynamicField DataField="category" HeaderText="" ItemStyle-CssClass="displayNone" />
                <%--                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Pendinglist_FeeEarner %>">
                    <ItemTemplate>
                        <uc1:WebUserControlLBLFeeEarner ID="uc1FeeEarner" runat="server" initGuidId='<%# Guid.Parse((Request[QueryStringConst.matter]).ToString()) %>' />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <%--  <asp:CommandField ShowEditButton="True" ButtonType="Button" />--%>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" />
                        &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel" />
                        <br />
                        <br />
                        <asp:Button ID="ButtonSendEmail" runat="server" Text="<%$ Resources:LanguagePack, PendinglistButtonSendEmail %>"
                            CommandName="Email" />&nbsp;
                        <asp:Button ID="Button3" runat="server" Text="View Report" CommandName="Report" Visible="false" />&nbsp;
                    </EditItemTemplate>
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDownloadAtt" runat="server"
        TargetControlID="lnkPopupEdit" PopupControlID="lnkPopupDownloadAtt" BackgroundCssClass="modalBackground"
        CancelControlID="btnCancel" PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="lnkPopupDownloadAtt" runat="server" CssClass="newpopM radiusClass"
        Style="display: none;">
        <asp:Panel ID="panDragDownloadAtt" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDownloadAtt" runat="server" Text="<%$ Resources:LanguagePack, debitNoteDownloadAtt %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="ImageButtonDownloadAtt" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:Panel ID="PanelAttachmentview" runat="server">
            <table class="lineHeight donwloadAttWidth">
                <tr>
                    <td>
                        <asp:Label ID="LabelAttachment1view" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteCoreAttachment1 %>"></asp:Label>
                        <asp:HyperLink ID="HyperLinkAttachment1" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelAttachment2view" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteCoreAttachment2 %>"></asp:Label>
                        <asp:HyperLink ID="HyperLinkAttachment2" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelAttachment3view" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteCoreAttachment3 %>"></asp:Label>
                        <asp:HyperLink ID="HyperLinkAttachment3" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelAttachment4view" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteCoreAttachment4 %>"></asp:Label>
                        <asp:HyperLink ID="HyperLinkAttachment4" runat="server"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelAttachment5view" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteCoreAttachment5 %>"></asp:Label>
                        <asp:HyperLink ID="HyperLinkAttachment5" runat="server"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <a id="lnkPopupEdit" runat="server"></a>
    <asp:EntityDataSource ID="EntityDataSourceMatterEdit" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="DebitNoteCores"
        Where="" OnSelecting="EntityDataSourceMatterEdit_Selecting" EnableUpdate="True">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceDebitNote" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableUpdate="True"
        EntitySetName="DebitNoteCores" OnSelecting="EntityDataSourceDebitNote_Selecting"
        Include="MatterCore"
        onquerycreated="EntityDataSourceDebitNote_QueryCreated">
    </asp:EntityDataSource>
</asp:Content>
