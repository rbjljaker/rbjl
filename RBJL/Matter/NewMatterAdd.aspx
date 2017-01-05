<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="NewMatterAdd.aspx.cs" Inherits="Matter_NewMatterAdd" %>

<%@ Register Src="~/WebControl/MultiselectDropdown.ascx" TagName="WebUserControl"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/DDLJobType.ascx" TagName="WebUserControlDDLJobType"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/DDLKeywork.ascx" TagName="WebUserControlDDLKeywork"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/uploadLogo.ascx" TagName="WebUserControlFUUploadLogo"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/DDLReferer.ascx" TagName="WebUserControlDDLReferer"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/MultiselectDropdownIntroducer.ascx" TagName="WebUserControlIntroducer"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/MultiselectDropdownWithHourlyRate.ascx" TagName="WebUserControlWithHourlyRate"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, MatterNewAddTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:DetailsView ID="DetailsViewMatter" runat="server" CssClass="masterDe lineHeight"
        AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourceMatter"
        DefaultMode="Insert" OnItemInserted="DetailsViewMatter_ItemInserted" OnItemInserting="DetailsViewMatter_ItemInserting"
        OnPreRender="DetailsViewMatter_PreRender" OnItemCommand="DetailsViewMatter_ItemCommand">
        <FieldHeaderStyle CssClass="alignRight" />
        <Fields>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <asp:DynamicField DataField="matterNum" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_matterNum %>" />
            <asp:DynamicField DataField="matterSubject" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_matterSubject %>" />
            <asp:DynamicField DataField="Client" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_Client %>" />
            <%--            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_Referer %>">
                <InsertItemTemplate>
                    <uc1:WebUserControlDDLReferer ID="DDLReferer" runat="server" />
                </InsertItemTemplate>
            </asp:TemplateField>--%>
            <asp:DynamicField DataField="Referer" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_Referer %>" />
            <asp:DynamicField DataField="refererFee" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_refererFee %>" />
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_SP %>">
                <InsertItemTemplate>
                    <uc1:WebUserControlIntroducer ID="MultiselectDropdownSP" runat="server" type="FeeEarner" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_FeeEarner %>">
                <InsertItemTemplate>
                    <uc1:WebUserControlWithHourlyRate ID="MultiselectDropdownFeeEarner" runat="server"
                        type="FeeEarner" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_HandlingColleague %>">
                <InsertItemTemplate>
                    <uc1:WebUserControl ID="MultiselectDropdownHandlingColleague" runat="server" type="HandlingColleague" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_jobType %>">
                <InsertItemTemplate>
                    <uc1:WebUserControlDDLJobType ID="DDLJobType" runat="server" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_fileOpenDate %>"
                SortExpression="fileOpenDate">
                <ItemTemplate>
                    <asp:Label ID="LabeFileOpenDate" runat="server" Text='<%# String.Format("{0:yyyy/MM/dd}",DateTime.Now) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:DynamicField DataField="discount" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_discount %>" />--%>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_discount %>">
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBoxDiscountEdit" runat="server" Text='<%# Bind("discount") %>'></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorDiscount" runat="server"
                        ErrorMessage="*Percentage" ControlToValidate="TextBoxDiscountEdit" ValidationExpression="^(100\.00|100\.0|100)|([0-9]{1,2}){0,1}(\.[0-9]{1,2}){0,1}$"
                        CssClass="warning"></asp:RegularExpressionValidator>
                </InsertItemTemplate>
            </asp:TemplateField>
            <%--<asp:DynamicField DataField="introducer" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_introducer %>" />--%>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_introducer %>">
                <InsertItemTemplate>
                    <%--                    <asp:TextBox ID="TextBoxIntroducer" runat="server" Text='<%# Bind("introducer") %>'></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtenderIntroducer" runat="server"
                        TargetControlID="TextBoxIntroducer" MinimumPrefixLength="0" CompletionSetCount="10"
                        EnableCaching="true" ServiceMethod="GetIntroducer" ServicePath="~/AutoComplete.asmx" />--%>
                    <uc1:WebUserControlIntroducer ID="MultiselectDropdownIntroducer" runat="server" type="FeeEarner" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_masterKeywordName %>">
                <InsertItemTemplate>
                    <uc1:WebUserControlDDLKeywork ID="DDLKeywork" runat="server" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="customKeywordFirst" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_customKeywordFirst %>" />
            <asp:DynamicField DataField="customKeywordSecond" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_customKeywordSecond %>" />
            <asp:DynamicField DataField="customKeywordThird" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_customKeywordThird %>" />
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_logo %>">
                <InsertItemTemplate>
                    <uc1:WebUserControlFUUploadLogo ID="FUUploadLogo" runat="server" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="refNumOfRefererM" HeaderText="<%$ Resources:LanguagePack, MattercoreRefNumOfReferer  %>" />
            <asp:DynamicField DataField="ioNumOfRefererM" HeaderText="<%$ Resources:LanguagePack, MattercoreIoNumOfReferer  %>" />
            <asp:DynamicField DataField="releaseToPublic" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_releaseToPublic %>" />
            <asp:DynamicField DataField="OutgoingAgent" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_OutgoingAgent %>" />
            <asp:DynamicField DataField="remarks" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_remarks %>" />
            <asp:CommandField ButtonType="Button" ShowInsertButton="True" InsertText="<%$ Resources:LanguagePack, GvDeSaveBtn %>" />
        </Fields>
    </asp:DetailsView>
    <asp:EntityDataSource ID="EntityDataSourceMatter" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="MatterCores"
        EnableInsert="True" EnableUpdate="True">
    </asp:EntityDataSource>
</asp:Content>
