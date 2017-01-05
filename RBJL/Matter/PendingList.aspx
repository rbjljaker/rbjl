<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="PendingList.aspx.cs" Inherits="Matter_PendingList" %>

<%@ Register Src="~/WebControl/LBLFeeEarner.ascx" TagName="WebUserControlLBLFeeEarner"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLDoworkTitle.ascx" TagName="WebUserControlLBLDoworkTitle"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLIntroducer.ascx" TagName="WebUserControlLBLIntroducer"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--    <script>

        function getMatterNum() {

            var matterNum = $("#ContentPlaceHolderMainContent_DetailsViewMatter___matterNum_TextBox1").val();
            $("#ContentPlaceHolderMainContent_hdnResultValue").val(matterNum);
            //return matterNum;
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, MatterPendingListTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:HiddenField ID="HiddenFieldMatterId" runat="server" />
    <asp:GridView ID="GridViewMatter" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
        DataSourceID="EntityDataSourceMatter" AllowPaging="True" PageSize="20" RowStyle-CssClass="lineGridviewMaster"
        HeaderStyle-CssClass="lineGridviewMaster" EmptyDataText="Not Data" OnRowCommand="GridViewMatter_RowCommand"
        OnRowDataBound="GridViewMatter_RowDataBound">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Pendinglist_item %>">
                <ItemTemplate>
                    <asp:Label ID="LabelItemNum" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Pendinglist_Date %>">
                <ItemTemplate>
                    <asp:Label ID="LabelDate" runat="server" Text='<%# DateTime.Now.ToString("dd-MMM-yyyy")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="Client" HeaderText="<%$ Resources:LanguagePack, Pendinglist_Client %>" />
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Pendinglist_FeeEarner %>">
                <ItemTemplate>
                    <uc1:WebUserControlLBLFeeEarner ID="uc1FeeEarner" runat="server" initGuidId='<%# Eval("id")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="matterSubject" HeaderText="<%$ Resources:LanguagePack, Mattercore_matterSubject %>"
                ReadOnly="true" />
            <asp:DynamicField DataField="jobTypeName" HeaderText="<%$ Resources:LanguagePack, Pendinglist_jobTypeName %>" />
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, PendinglistIntroducer %>">
                <ItemTemplate>
                    <uc1:WebUserControlLBLIntroducer ID="uc1I" runat="server" userGuid='<%# Eval("introducer")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="fileOpenDate" HeaderText="<%$ Resources:LanguagePack, Pendinglist_fileOpenDate %>"
                DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}" />
            <%--            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Enter Matter No."
                ShowEditButton="true" EditText="<%$ Resources:LanguagePack, lblEdit %>" HeaderStyle-Width="200" />--%>
            <asp:TemplateField ShowHeader="False" HeaderStyle-Width="200">
                <ItemTemplate>
                    <asp:Button ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandName="Edit"
                        CommandArgument='<%# Eval("id")%>' Text="<%$ Resources:LanguagePack, lblEdit %>">
                    </asp:Button>
                    <asp:Button ID="ButtonSelect" runat="server" CausesValidation="False" CommandName="Select"
                        CommandArgument='<%# Eval("id")%>' Text="<%$ Resources:LanguagePack, lblEnterMatterNo %>">
                    </asp:Button>
                    <asp:Button ID="LinkButtonDelete" runat="server" CausesValidation="False" CommandName="DeleteMatter"
                        CommandArgument='<%# Eval("id")%>' Text="<%$ Resources:LanguagePack, lblDelete %>"
                        OnClientClick="<%$ Resources:LanguagePack, DeleteConfirm %>"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEdit" runat="server" TargetControlID="lnkPopupEdit"
        PopupControlID="panAddEdit" BackgroundCssClass="modalBackground" CancelControlID="ImageButtonDeEdit"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtenderEdit" runat="server" Title="<%$ Resources:LanguagePack, PendingListEnterNum %>"
        Icon="Application" Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeM %>">
        <Content>--%>
    <asp:Panel ID="panAddEdit" runat="server" CssClass="newpopM" Style="display: none;">
        <asp:Panel ID="panDragDeEdit" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleDeEdit" runat="server" Text="<%$ Resources:LanguagePack, PendingListEnterNum %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="ImageButtonDeEdit" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:DetailsView ID="DetailsViewMatter" runat="server" CssClass="masterDe lineHeight"
            AutoGenerateRows="False" DataKeyNames="id" DefaultMode="Edit" DataSourceID="EntityDataSourceMatterEdit"
            OnItemUpdated="DetailsViewMatter_ItemUpdated" OnItemUpdating="DetailsViewMatter_ItemUpdating"
            OnItemCommand="DetailsViewMatter_ItemCommand">
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <%--<asp:DynamicField DataField="matterNum" HeaderText="<%$ Resources:LanguagePack, Pendinglist_matterNum %>" />--%>
                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Pendinglist_matterNum %>">
                    <ItemTemplate>
                        <asp:Label ID="labelItemMatterNum" runat="server" Text='<%# Eval("matterNum")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxEditMatterNum" runat="server" Text='<%# Bind("matterNum")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:DynamicField DataField="Client" HeaderText="<%$ Resources:LanguagePack, Pendinglist_Client %>"
                    ReadOnly="true" />
                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Pendinglist_FeeEarner %>">
                    <ItemTemplate>
                        <uc1:WebUserControlLBLFeeEarner ID="uc1FeeEarner" runat="server" initGuidId='<%# Guid.Parse((HiddenFieldMatterId.Value).ToString()) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:DynamicField DataField="matterSubject" HeaderText="<%$ Resources:LanguagePack, Mattercore_matterSubject %>"
                    ReadOnly="true" />
                <asp:DynamicField DataField="jobTypeName" HeaderText="<%$ Resources:LanguagePack, Pendinglist_jobTypeName %>"
                    ReadOnly="true" />
                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, PendinglistIntroducer %>">
                    <ItemTemplate>
                        <uc1:WebUserControlLBLIntroducer ID="uc1I" runat="server" userGuid='<%# Eval("introducer")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:DynamicField DataField="fileOpenDate" HeaderText="<%$ Resources:LanguagePack, Pendinglist_fileOpenDate %>"
                    ReadOnly="true" DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}" />
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update" />
                        &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel" />
                        <br />
                        <br />
                        <asp:Button ID="ButtonSendEmail" runat="server" Text="<%$ Resources:LanguagePack, PendinglistButtonSendEmail %>"
                            CommandName="Email" />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
        <br />
    </asp:Panel>
    <asp:HiddenField ID="hdnResultValue" runat="server" />
    <%--        </Content>
    </ext:Window>--%>
    <a id="lnkPopupEdit" runat="server"></a>
    <asp:EntityDataSource ID="EntityDataSourceMatter" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="MatterCores"
        EnableInsert="True" EnableUpdate="True" EnableDelete="True" Where="it.matterNum is null"
        OrderBy="it.fileOpenDate ASC">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceMatterEdit" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="MatterCores"
        Where="" OnSelecting="EntityDataSourceMatterEdit_Selecting" EnableUpdate="True">
    </asp:EntityDataSource>
</asp:Content>
