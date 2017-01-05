<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="MatterCore.cs" Inherits="PutAway_MatterCore" %>

<%@ Register Src="~/WebControl/ShowLogo.ascx" TagName="WebUserControlImgShowLogo"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/getPutawayStatus.ascx" TagName="WebUserControlGetStatus"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLFeeEarner.ascx" TagName="WebUserControlLBLFeeEarner"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/uploadLogo.ascx" TagName="WebUserControlFUUploadLogo"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLUserName.ascx" TagName="WebUserControlLBLUserName"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, PutAwayCoreTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:DetailsView ID="DetailsViewMatter" runat="server" CssClass="masterDe" AutoGenerateRows="False"
        DataKeyNames="id" DataSourceID="EntityDataSourceMatter" OnItemUpdating="DetailsViewMatter_ItemUpdating"
        OnItemUpdated="DetailsViewMatter_ItemUpdated" OnItemCommand="DetailsViewMatter_ItemCommand">
        <EditRowStyle CssClass="detailsViewHrCss" />
        <Fields>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <asp:DynamicField DataField="matterNum" HeaderText="<%$ Resources:LanguagePack, Mattercore_matterNum %>" />
            <asp:DynamicField DataField="matterSubject" HeaderText="<%$ Resources:LanguagePack, Mattercore_matterSubject %>" />
            <asp:DynamicField DataField="Client" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_Client %>" />
            <asp:DynamicField DataField="Referer" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_Referer %>" />
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_FeeEarner %>">
                <ItemTemplate>
                    <uc1:WebUserControlLBLFeeEarner ID="uc1FeeEarner" runat="server" initGuidId='<%# Guid.Parse((Request[QueryStringConst.matter]).ToString()) %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_HandlingColleague %>">
                <ItemTemplate>
                    <uc1:WebUserControlLBLFeeEarner ID="uc1HandlingColleague" runat="server" initGuidId='<%# Guid.Parse((Request[QueryStringConst.matter]).ToString()) %>'
                        type="HandlingColleague" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--                             <asp:DynamicField DataField="fileOpenDate" HeaderText="<%$ Resources:LanguagePack, Mattercore_fileOpenDate %>" />
                            <asp:DynamicField DataField="discount" HeaderText="<%$ Resources:LanguagePack, Mattercore_discount %>" />--%>
            <asp:DynamicField DataField="jobTypeName" HeaderText="<%$ Resources:LanguagePack, Mattercore_jobTypeName %>" />
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_fileOpenDate %>"
                SortExpression="fileOpenDate">
                <ItemTemplate>
                    <asp:Label ID="LabeFileOpenDate" runat="server" Text='<%# String.Format("{0:yyyy/MM/dd}",DateTime.Now) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_logo %>">
                <EditItemTemplate>
                    <uc1:WebUserControlFUUploadLogo ID="FUUploadLogo" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <uc1:WebUserControlImgShowLogo ID="uc1ImgLogo" runat="server" logoPath='<%# Eval("logo") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="putAwayDate" HeaderText="<%$ Resources:LanguagePack,PutAwayPutAwayDate %>"
                ReadOnly="true" />
            <asp:DynamicField DataField="putAwayBoxNum" HeaderText="<%$ Resources:LanguagePack,PutAwayPutAwayBoxNum %>" />
            <asp:DynamicField DataField="putAwayContent" HeaderText="<%$ Resources:LanguagePack,PutAwayPutAwayContent %>" />
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_Status %>"
                SortExpression="status">
                <EditItemTemplate>
                    <% if (mI.userLevel == EnumUserLevel.administrator)
                       { %>
                    <asp:DropDownList runat="server" ID="DropDownListMatterstatus" Visible="true">
                        <asp:ListItem Text="Closed" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Domount" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Reopen" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                    <% }
                       else
                       {%>
                    <uc1:WebUserControlGetStatus ID="ucGetStatus" runat="server" statudId='<%# Eval("status")%>' />
                    <% }%>
                </EditItemTemplate>
                <%--                                    <asp:LinkButton ID="LinkButtonUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="<%$ Resources:LanguagePack, lblUpdate %>"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButtonCancel" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="<%$ Resources:LanguagePack, lblCancel %>"></asp:LinkButton>--%>
                <ItemTemplate>
                    <uc1:WebUserControlGetStatus ID="ucGetStatus" runat="server" statudId='<%# Eval("status")%>' />
                    <%--                                    <asp:LinkButton ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="<%$ Resources:LanguagePack, lblEdit %>"></asp:LinkButton>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Created By">
                <ItemTemplate>
                    <uc1:WebUserControlLBLUserName ID="ucLBLUserName" runat="server" userGuid='<%# Bind("CreateByUserId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amended By">
                <ItemTemplate>
                    <uc1:WebUserControlLBLUserName ID="ucLBLUserName2" runat="server" userGuid='<%# Bind("UpdateByUserId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <%--                            <asp:DynamicField DataField="masterKeywordName" HeaderText="<%$ Resources:LanguagePack, Mattercore_masterKeywordName %>" />
                            <asp:DynamicField DataField="customKeywordFirst" HeaderText="<%$ Resources:LanguagePack, Mattercore_customKeywordFirst %>" />
                            <asp:DynamicField DataField="customKeywordSecond" HeaderText="<%$ Resources:LanguagePack, Mattercore_customKeywordSecond %>" />
                            <asp:DynamicField DataField="customKeywordThird" HeaderText="<%$ Resources:LanguagePack, Mattercore_customKeywordThird %>" />
                            <asp:DynamicField DataField="releaseToPublic" HeaderText="<%$ Resources:LanguagePack, Mattercore_releaseToPublic %>" />
                            <asp:DynamicField DataField="isReopen" HeaderText="<%$ Resources:LanguagePack, Mattercore_isReopen %>" />
                            <asp:DynamicField DataField="remarks" HeaderText="<%$ Resources:LanguagePack, Mattercore_remarks %>" />--%>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="Edit" CommandArgument='<%# Eval("status")%>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="ButtonUpdate" runat="server" CausesValidation="False" CommandName="Update"
                        Text="Update" />
                    &nbsp;<asp:Button ID="ButtonCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="Cancel" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Fields>
        <HeaderStyle CssClass="detailsViewHrCss" />
    </asp:DetailsView>
    <asp:EntityDataSource ID="EntityDataSourceMatter" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="MatterCores"
        Where="" OnSelecting="EntityDataSourceMatter_Selecting" EnableUpdate="True">
    </asp:EntityDataSource>
    <asp:HiddenField ID="HiddenFieldStatusid" runat="server" />
</asp:Content>
