<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="MatterCore.aspx.cs" Inherits="Matter_MatterCore" %>

<%@ Register Src="~/WebControl/LBLFeeEarner.ascx" TagName="WebUserControlLBLFeeEarner"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/getMatterStatus.ascx" TagName="WebUserControlGetStatus"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/DDLTemplate.ascx" TagName="WebUserControlDDLTemplate"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/ShowLogo.ascx" TagName="WebUserControlImgShowLogo"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLUserName.ascx" TagName="WebUserControlLBLUserName"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/uploadLogo.ascx" TagName="WebUserControlFUUploadLogo"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/MultiselectDropdown.ascx" TagName="WebUserControlMultiselectDropdown"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLFeeEarnerHourlyRate.ascx" TagName="WebUserControlLBLFeeEarnerHourlyRate"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/MultiselectDropdownWithHourlyRate.ascx" TagName="WebUserControlWithHourlyRate"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/DDLMasterKeywordUpdate.ascx" TagName="WebUserControlMasterKeyword"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/DDLJobTypeUpdate.ascx" TagName="WebUserControlJobTypeUpdate"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLIntroducer.ascx" TagName="WebUserControlLBLIntroducer"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/MultiselectDropdownIntroducer.ascx" TagName="WebUserControlIntroducer"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function checkingMultiple(sender, e) {
            var roundedNumber = Math.round(e.Value * 100);
            var integerNumber = parseInt(roundedNumber);
            if (integerNumber % 5 == 0)
                e.IsValid = true;
            else
                e.IsValid = false;
        }
    </script>
    <script type="text/javascript">

        $(function () {

            $('.clientInfo .checkingTar').each(function () {
                if ($(this).find("span").text().length == 0) {
                    $(this).closest('tr').attr('class', "displayNone");
                }
            });

            $('.refererInfo .checkingTar').each(function () {
                if ($(this).find("span").text().length == 0) {
                    $(this).closest('tr').attr('class', "displayNone");
                }
            });

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, MatterMatterCoreTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <div class="Tab">
        <ajaxToolkit:TabContainer ID="TabContainerMatterCore" runat="server">
            <ajaxToolkit:TabPanel ID="TabPanelMatterGeneral" runat="server" HeaderText="<%$ Resources:LanguagePack, Mattercore_General %>">
                <ContentTemplate>
                    <asp:DetailsView ID="DetailsViewMatter" runat="server" CssClass="lineHeight" AutoGenerateRows="False"
                        DataKeyNames="id" DataSourceID="EntityDataSourceMatter" OnDataBound="DetailsViewMatter_DataBound"
                        OnItemUpdated="DetailsViewMatter_ItemUpdated" OnItemUpdating="DetailsViewMatter_ItemUpdating"
                        OnModeChanged="DetailsViewMatter_ModeChanged">
                        <Fields>
                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                Visible="False" />
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_SP %>">
                                <ItemTemplate>
                                    <uc1:WebUserControlLBLIntroducer ID="uc1I" runat="server" userGuid='<%# Eval("SPList")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <uc1:WebUserControlIntroducer ID="ucWebUserControlSP" runat="server" tarGuid='<%# Eval("SPList") %>'
                                        type="FeeEarner" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_FeeEarner %>">
                                <ItemTemplate>
                                    <uc1:WebUserControlLBLFeeEarner ID="uc1FeeEarner" runat="server" initGuidId='<%# Guid.Parse((Request[QueryStringConst.matter]).ToString()) %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <uc1:WebUserControlWithHourlyRate ID="ucWebUserControlMultiselectDropdownFeeEarner"
                                        runat="server" matterId='<%# Eval("id") %>' type="FeeEarner" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <%--<%$ Resources:LanguagePack, MattercoreHourlyRate %>--%>
                                <ItemTemplate>
                                    <uc1:WebUserControlLBLFeeEarnerHourlyRate ID="uc1HR" runat="server" initGuidId='<%# Guid.Parse((Request[QueryStringConst.matter]).ToString()) %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <% if (mI.userLevel == EnumUserLevel.administrator)
                                       { %>
                                    <% }
                                       else
                                       {%>
                                    <uc1:WebUserControlLBLFeeEarnerHourlyRate ID="uc1HR" runat="server" initGuidId='<%# Guid.Parse((Request[QueryStringConst.matter]).ToString()) %>' />
                                    <% }%>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_HandlingColleague %>">
                                <ItemTemplate>
                                    <uc1:WebUserControlLBLFeeEarner ID="uc1HandlingColleague" runat="server" initGuidId='<%# Guid.Parse((Request[QueryStringConst.matter]).ToString()) %>'
                                        type="HandlingColleague" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <uc1:WebUserControlMultiselectDropdown ID="ucWebUserControlMultiselectDropdownHandlingColleague"
                                        runat="server" matterId='<%# Eval("id") %>' type="HandlingColleague" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:DynamicField DataField="matterNum" HeaderText="<%$ Resources:LanguagePack, Mattercore_matterNum %>"
                                ReadOnly="true" />--%>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_matterNum %>">
                                <ItemTemplate>
                                    <asp:Label ID="LabelMatterNum" runat="server" Text='<%# Eval("matterNum") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <% if (mI.userLevel == EnumUserLevel.administrator)
                                       { %>
                                    <asp:TextBox ID="TextBoxMatterNum" runat="server" Text='<%# Bind("matterNum") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMatterNum" runat="server" ErrorMessage="*"
                                        CssClass="warning" ControlToValidate="TextBoxMatterNum"></asp:RequiredFieldValidator>
                                    <% }
                                       else
                                       { 
                                    %>
                                    <asp:Label ID="LabelMatterNum" runat="server" Text='<%# Eval("matterNum") %>'></asp:Label>
                                    <% }
                                    %>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:DynamicField DataField="Client" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_Client %>" />
                            <asp:DynamicField DataField="Referer" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_Referer %>" />
                            <%--<asp:DynamicField DataField="matterSubject" HeaderText="<%$ Resources:LanguagePack, Mattercore_matterSubject %>" />--%>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_matterSubject %>">
                                <ItemTemplate>
                                    <asp:Label ID="LabelMatterSubject" runat="server" Text='<%# Eval("matterSubject") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <% if (mI.userLevel == EnumUserLevel.administrator)
                                       { %>
                                    <asp:TextBox ID="TextBoxMatterSubject" runat="server" Text='<%# Bind("matterSubject") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMatterSubject" runat="server"
                                        ErrorMessage="*" CssClass="warning" ControlToValidate="TextBoxMatterSubject"></asp:RequiredFieldValidator>
                                    <% }
                                       else
                                       { 
                                    %>
                                    <asp:Label ID="LabelMatterSubject" runat="server" Text='<%# Eval("matterSubject") %>'></asp:Label>
                                    <% }
                                    %>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:DynamicField DataField="fileOpenDate" HeaderText="<%$ Resources:LanguagePack, Mattercore_fileOpenDate %>"
                                ReadOnly="true" />
                            <%--<asp:DynamicField DataField="discount" HeaderText="<%$ Resources:LanguagePack, Mattercore_discount %>" />--%>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_discount %>">
                                <ItemTemplate>
                                    <asp:Label ID="LabelDiscountView" runat="server" Text='<%# Eval("discount") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <% if (mI.userLevel == EnumUserLevel.administrator)
                                       { %>
                                    <asp:TextBox ID="TextBoxDiscountEdit" runat="server" Text='<%# Bind("discount") %>'></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorDiscount" runat="server"
                                        ErrorMessage="*Percentage" ControlToValidate="TextBoxDiscountEdit" ValidationExpression="^(100\.00|100\.0|100)|([0-9]{1,2}){0,1}(\.[0-9]{1,2}){0,1}$"
                                        CssClass="warning"></asp:RegularExpressionValidator>
                                    <% }
                                       else
                                       {%>
                                    <asp:Label ID="LabelDiscountEdit" runat="server" Text='<%# Eval("discount") %>'></asp:Label>
                                    <% }%>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <%-- 
                            <asp:DynamicField DataField="hourlyRate" HeaderText="<%$ Resources:LanguagePack, MattercoreHourlyRate %>" />
                            <asp:DynamicField DataField="jobTypeName" HeaderText="<%$ Resources:LanguagePack, Mattercore_jobTypeName %>" />
                            --%>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_jobTypeName %>">
                                <ItemTemplate>
                                    <asp:Label ID="LabelJobTypeNameView" runat="server" Text='<%# Eval("jobTypeName") %>'></asp:Label>
                                </ItemTemplate>
                                <%--                                <EditItemTemplate>
                                    <% if (mI.userLevel == EnumUserLevel.administrator)
                                       { %>
                                    <asp:TextBox ID="TextBoxJobTypeNameEdit" runat="server" Text='<%# Bind("jobTypeName") %>'></asp:TextBox>
                                    <% }
                                       else
                                       {%>
                                    <asp:Label ID="LabelJobTypeNameEdit" runat="server" Text='<%# Eval("jobTypeName") %>'></asp:Label>
                                    <% }%>
                                </EditItemTemplate>--%>
                                <EditItemTemplate>
                                    <uc1:WebUserControlJobTypeUpdate ID="ucJTUpdate" runat="server" initValue='<%# Eval("jobTypeName")%>'
                                        initId='<%# Eval("jobTypeId")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_logo %>">
                                <ItemTemplate>
                                    <uc1:WebUserControlImgShowLogo ID="uc1ImgLogo" runat="server" logoPath='<%# Eval("logo") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <uc1:WebUserControlFUUploadLogo ID="FUUploadLogo" runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:DynamicField DataField="refNumOfRefererM" HeaderText="<%$ Resources:LanguagePack, MattercoreRefNumOfReferer  %>" />
                            <asp:DynamicField DataField="ioNumOfRefererM" HeaderText="<%$ Resources:LanguagePack, MattercoreIoNumOfReferer  %>" />
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_Status %>"
                                SortExpression="status">
                                <ItemTemplate>
                                    <uc1:WebUserControlGetStatus ID="ucGetStatus" runat="server" statudId='<%# Eval("status")%>' />
                                    <%--                                    <asp:Button ID="LinkButtonEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="<%$ Resources:LanguagePack, lblEdit %>"></asp:Button>--%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList runat="server" ID="DropDownListMatterstatus" Visible="true">
                                        <asp:ListItem Text="Live" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Suspend" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Put Away" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--                                    <asp:Button ID="LinkButtonUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="<%$ Resources:LanguagePack, lblUpdate %>"></asp:Button>
                                    &nbsp;<asp:Button ID="LinkButtonCancel" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="<%$ Resources:LanguagePack, lblCancel %>"></asp:Button>

                                    --%>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:DynamicField DataField="masterKeywordName" HeaderText="<%$ Resources:LanguagePack, Mattercore_masterKeywordName %>" />--%>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_masterKeywordName %>">
                                <ItemTemplate>
                                    <asp:Label ID="LabelMasterKeywork" runat="server" Text='<%# Eval("masterKeywordName")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <uc1:WebUserControlMasterKeyword ID="uc1MKW" runat="server" initValue='<%# Eval("masterKeywordName")%>'
                                        initId='<%# Eval("masterKeywordId")%>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:DynamicField DataField="customKeywordFirst" HeaderText="<%$ Resources:LanguagePack, Mattercore_customKeywordFirst %>" />
                            <asp:DynamicField DataField="customKeywordSecond" HeaderText="<%$ Resources:LanguagePack, Mattercore_customKeywordSecond %>" />
                            <asp:DynamicField DataField="customKeywordThird" HeaderText="<%$ Resources:LanguagePack, Mattercore_customKeywordThird %>" />
                            <%--<asp:DynamicField DataField="releaseToPublic" HeaderText="<%$ Resources:LanguagePack, Mattercore_releaseToPublic %>" />--%>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_releaseToPublic %>">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBoxViewReleaseToPublic" runat="server" Checked='<%# Bind("releaseToPublic") %>'
                                        Enabled="false" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <% if (mI.userLevel == EnumUserLevel.administrator)
                                       { %>
                                    <asp:CheckBox ID="CheckBoxEditReleaseToPublic" runat="server" Checked='<%# Bind("releaseToPublic") %>' />
                                    <% }
                                       else
                                       {%>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Eval("releaseToPublic") %>'
                                        Enabled="false" />
                                    <% }%>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:DynamicField DataField="isReopen" HeaderText="<%$ Resources:LanguagePack, Mattercore_isReopen %>"
                                ReadOnly="true" />
                            <%--                            <asp:TemplateField HeaderText="Add To User">
                                <EditItemTemplate>
                                    <uc1:WebUserControlMultiselectDropdown ID="ucWebUserControlMultiselectDropdownAddToUser"
                                        runat="server" type="HandlingColleague" />
                                </EditItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:DynamicField DataField="OutgoingAgent" HeaderText="<%$ Resources:LanguagePack, NewMatterAdd_OutgoingAgent %>" />
                            <asp:DynamicField DataField="remarks" HeaderText="<%$ Resources:LanguagePack, Mattercore_remarks %>" />
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, MatterNewUpdateByName %>"
                                SortExpression="UpdateByUserId">
                                <ItemTemplate>
                                    <uc1:WebUserControlLBLUserName ID="ucGetUserName" runat="server" userGuid='<%# Eval("UpdateByUserId")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:DynamicField DataField="UpdateDate" ReadOnly="true" HeaderText="<%$ Resources:LanguagePack, MatterNewUpdateDate %>"
                                DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}" />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="ButtonUpdate" runat="server" CausesValidation="False" CommandName="Update"
                                        Text="Update" />
                                    &nbsp;<asp:Button ID="ButtonCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="Cancel" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Fields>
                    </asp:DetailsView>
                    <asp:Button ID="ButtonSendEmail" runat="server" Text="<%$ Resources:LanguagePack, PendinglistButtonSendEmail %>"
                        OnClick="ButtonSendEmail_Click" />
                    <br />
                    <br />
                    <asp:Button ID="LinkButtonCopyFrom" runat="server" Text="Copy to New Matter" OnClick="LinkButtonCopyFrom_onclick"
                        CausesValidation="false" />
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelMatterClient" runat="server" HeaderText="<%$ Resources:LanguagePack, Mattercore_Client %>">
                <ContentTemplate>
                    <asp:DetailsView ID="DetailsViewMatterClient" runat="server" CssClass="masterDe clientInfo"
                        AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourceMatterClient">
                        <Fields>
                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                Visible="False" />
                            <asp:DynamicField DataField="accountGroup" HeaderText="<%$ Resources:master, client_accountGroup %>" />
                            <asp:DynamicField DataField="clientNum" HeaderText="<%$ Resources:master, client_clientNum  %>" />
                            <asp:DynamicField DataField="clientName" HeaderText="<%$ Resources:master, client_clientName  %>" />
                            <asp:DynamicField DataField="billingAddressFirst" HeaderText="<%$ Resources:master, client_billingAddressFirst  %>" />
                            <asp:DynamicField DataField="billingAddressSecond" HeaderText="<%$ Resources:master, client_billingAddressSecond  %>" />
                            <asp:DynamicField DataField="correspondingAddress1First" HeaderText="<%$ Resources:master, client_correspondingAddress1First  %>" />
                            <asp:DynamicField DataField="correspondingAddress1Second" HeaderText="<%$ Resources:master, client_correspondingAddress1Second  %>" />
                            <asp:DynamicField DataField="correspondingAddress2First" HeaderText="<%$ Resources:master, client_correspondingAddress2First  %>" />
                            <asp:DynamicField DataField="correspondingAddress2Second" HeaderText="<%$ Resources:master, client_correspondingAddress2Second  %>" />
                            <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, client_contactPerson  %>" />
                            <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, client_tel  %>" />
                            <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, client_email  %>" />
                            <asp:DynamicField DataField="contactPerson02" HeaderText="<%$ Resources:master, client_contactPerson02  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel02" HeaderText="<%$ Resources:master, client_tel02  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email02" HeaderText="<%$ Resources:master, client_email02  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson03" HeaderText="<%$ Resources:master, client_contactPerson03  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel03" HeaderText="<%$ Resources:master, client_tel03  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email03" HeaderText="<%$ Resources:master, client_email03  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson04" HeaderText="<%$ Resources:master, client_contactPerson04  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel04" HeaderText="<%$ Resources:master, client_tel04  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email04" HeaderText="<%$ Resources:master, client_email04  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson05" HeaderText="<%$ Resources:master, client_contactPerson05  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel05" HeaderText="<%$ Resources:master, client_tel05  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email05" HeaderText="<%$ Resources:master, client_email05  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson06" HeaderText="<%$ Resources:master, client_contactPerson06  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel06" HeaderText="<%$ Resources:master, client_tel06  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email06" HeaderText="<%$ Resources:master, client_email06  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson07" HeaderText="<%$ Resources:master, client_contactPerson07  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel07" HeaderText="<%$ Resources:master, client_tel07  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email07" HeaderText="<%$ Resources:master, client_email07  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson08" HeaderText="<%$ Resources:master, client_contactPerson08  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel08" HeaderText="<%$ Resources:master, client_tel08  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email08" HeaderText="<%$ Resources:master, client_email08  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson09" HeaderText="<%$ Resources:master, client_contactPerson09  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel09" HeaderText="<%$ Resources:master, client_tel09  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email09" HeaderText="<%$ Resources:master, client_email09  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson10" HeaderText="<%$ Resources:master, client_contactPerson10  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel10" HeaderText="<%$ Resources:master, client_tel10  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email10" HeaderText="<%$ Resources:master, client_email10  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson11" HeaderText="<%$ Resources:master, client_contactPerson11  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel11" HeaderText="<%$ Resources:master, client_tel11  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email11" HeaderText="<%$ Resources:master, client_email11  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson12" HeaderText="<%$ Resources:master, client_contactPerson12  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel12" HeaderText="<%$ Resources:master, client_tel12  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email12" HeaderText="<%$ Resources:master, client_email12  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson13" HeaderText="<%$ Resources:master, client_contactPerson13  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel13" HeaderText="<%$ Resources:master, client_tel13  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email13" HeaderText="<%$ Resources:master, client_email13  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson14" HeaderText="<%$ Resources:master, client_contactPerson14  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel14" HeaderText="<%$ Resources:master, client_tel14  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email14" HeaderText="<%$ Resources:master, client_email14  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson15" HeaderText="<%$ Resources:master, client_contactPerson15  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel15" HeaderText="<%$ Resources:master, client_tel15  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email15" HeaderText="<%$ Resources:master, client_email15  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson16" HeaderText="<%$ Resources:master, client_contactPerson16  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel16" HeaderText="<%$ Resources:master, client_tel16  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email16" HeaderText="<%$ Resources:master, client_email16  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson17" HeaderText="<%$ Resources:master, client_contactPerson17  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel17" HeaderText="<%$ Resources:master, client_tel17  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email17" HeaderText="<%$ Resources:master, client_email17  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson18" HeaderText="<%$ Resources:master, client_contactPerson18  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel18" HeaderText="<%$ Resources:master, client_tel18  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email18" HeaderText="<%$ Resources:master, client_email18  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson19" HeaderText="<%$ Resources:master, client_contactPerson19  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel19" HeaderText="<%$ Resources:master, client_tel19  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email19" HeaderText="<%$ Resources:master, client_email19 %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson20" HeaderText="<%$ Resources:master, client_contactPerson20 %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel20" HeaderText="<%$ Resources:master, client_tel20  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email20" HeaderText="<%$ Resources:master, client_email20  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, client_fax  %>" />
                            <asp:DynamicField DataField="billingEmail" HeaderText="<%$ Resources:master, client_billingEmail  %>" />
                            <asp:DynamicField DataField="discount" HeaderText="<%$ Resources:master, client_discount  %>" />
                            <asp:DynamicField DataField="remarks" HeaderText="<%$ Resources:master, clientRemarks  %>" />
                        </Fields>
                    </asp:DetailsView>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelMatterReferer" runat="server" HeaderText="<%$ Resources:LanguagePack, Mattercore_Referer %>">
                <ContentTemplate>
                    <asp:DetailsView ID="DetailsViewMatterRefer" runat="server" CssClass="masterDe refererInfo"
                        AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourceMatterRefer"
                        EmptyDataText="<%$ Resources:LanguagePack, masterNoData %>">
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
                            <asp:DynamicField DataField="contactPerson" HeaderText="<%$ Resources:master, refer_contactPerson %>" />
                            <asp:DynamicField DataField="tel" HeaderText="<%$ Resources:master, refer_tel %>" />
                            <asp:DynamicField DataField="email" HeaderText="<%$ Resources:master, refer_email %>" />
                            <asp:DynamicField DataField="contactPerson02" HeaderText="<%$ Resources:master, client_contactPerson02  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel02" HeaderText="<%$ Resources:master, client_tel02  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email02" HeaderText="<%$ Resources:master, client_email02  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson03" HeaderText="<%$ Resources:master, client_contactPerson03  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel03" HeaderText="<%$ Resources:master, client_tel03  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email03" HeaderText="<%$ Resources:master, client_email03  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson04" HeaderText="<%$ Resources:master, client_contactPerson04  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel04" HeaderText="<%$ Resources:master, client_tel04  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email04" HeaderText="<%$ Resources:master, client_email04  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson05" HeaderText="<%$ Resources:master, client_contactPerson05  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel05" HeaderText="<%$ Resources:master, client_tel05  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email05" HeaderText="<%$ Resources:master, client_email05  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson06" HeaderText="<%$ Resources:master, client_contactPerson06  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel06" HeaderText="<%$ Resources:master, client_tel06  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email06" HeaderText="<%$ Resources:master, client_email06  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson07" HeaderText="<%$ Resources:master, client_contactPerson07  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel07" HeaderText="<%$ Resources:master, client_tel07  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email07" HeaderText="<%$ Resources:master, client_email07  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson08" HeaderText="<%$ Resources:master, client_contactPerson08  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel08" HeaderText="<%$ Resources:master, client_tel08  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email08" HeaderText="<%$ Resources:master, client_email08  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson09" HeaderText="<%$ Resources:master, client_contactPerson09  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel09" HeaderText="<%$ Resources:master, client_tel09  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email09" HeaderText="<%$ Resources:master, client_email09  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson10" HeaderText="<%$ Resources:master, client_contactPerson10  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel10" HeaderText="<%$ Resources:master, client_tel10  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email10" HeaderText="<%$ Resources:master, client_email10  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson11" HeaderText="<%$ Resources:master, client_contactPerson11  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel11" HeaderText="<%$ Resources:master, client_tel11  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email11" HeaderText="<%$ Resources:master, client_email11  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson12" HeaderText="<%$ Resources:master, client_contactPerson12  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel12" HeaderText="<%$ Resources:master, client_tel12  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email12" HeaderText="<%$ Resources:master, client_email12  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson13" HeaderText="<%$ Resources:master, client_contactPerson13  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel13" HeaderText="<%$ Resources:master, client_tel13  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email13" HeaderText="<%$ Resources:master, client_email13  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson14" HeaderText="<%$ Resources:master, client_contactPerson14  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel14" HeaderText="<%$ Resources:master, client_tel14  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email14" HeaderText="<%$ Resources:master, client_email14  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson15" HeaderText="<%$ Resources:master, client_contactPerson15  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel15" HeaderText="<%$ Resources:master, client_tel15  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email15" HeaderText="<%$ Resources:master, client_email15  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson16" HeaderText="<%$ Resources:master, client_contactPerson16  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel16" HeaderText="<%$ Resources:master, client_tel16  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email16" HeaderText="<%$ Resources:master, client_email16  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson17" HeaderText="<%$ Resources:master, client_contactPerson17  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel17" HeaderText="<%$ Resources:master, client_tel17  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email17" HeaderText="<%$ Resources:master, client_email17  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson18" HeaderText="<%$ Resources:master, client_contactPerson18  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel18" HeaderText="<%$ Resources:master, client_tel18  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email18" HeaderText="<%$ Resources:master, client_email18  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson19" HeaderText="<%$ Resources:master, client_contactPerson19  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel19" HeaderText="<%$ Resources:master, client_tel19  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email19" HeaderText="<%$ Resources:master, client_email19 %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="contactPerson20" HeaderText="<%$ Resources:master, client_contactPerson20  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="tel20" HeaderText="<%$ Resources:master, client_tel20  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="email20" HeaderText="<%$ Resources:master, client_email20  %>"
                                ItemStyle-CssClass="checkingTar" />
                            <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, refer_fax %>" />
                            <asp:DynamicField DataField="OutgoingAgent" HeaderText="<%$ Resources:master, refer_OutgoingAgent %>" />
                            <asp:DynamicField DataField="remark" HeaderText="<%$ Resources:LanguagePack, refer_Remark %>" />
                        </Fields>
                    </asp:DetailsView>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelMatterTimeEntry" runat="server" HeaderText="<%$ Resources:LanguagePack, Mattercore_TimeEntry %>">
                <ContentTemplate>
                    <asp:Panel ID="PanelTimeEntryInsert" runat="server">
                        <asp:UpdatePanel ID="updatepanel1" runat="server">
                            <ContentTemplate>
                                <asp:HiddenField ID="HiddenFieldTimeStart" runat="server" />
                                <asp:HiddenField ID="HiddenFieldTimeEnd" runat="server" />
                                <div class="matterMaster">
                                    <asp:Panel ID="PanelMatterDetails" runat="server" CssClass="floatL timeEntryPanel">
                                        <table class="lineHeight">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelMatterNumTitle" runat="server" Text="Matter No:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="LabelMatterNum" runat="server" Text="!!"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelItemNo" runat="server" Text="Item No:"></asp:Label>
                                                </td>
                                                </td>
                                                <td>
                                                    <%--<asp:TextBox ID="TextBoxItemNo" runat="server"></asp:TextBox>--%>
                                                    <asp:Label ID="LabelBoxItemNoValue" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelDate" runat="server" Text="Date:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxDate" runat="server"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderDate" runat="server" TargetControlID="TextBoxDate"
                                                        Format="dd-MMM-yyyy">
                                                    </ajaxToolkit:CalendarExtender>
                                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderDate" runat="server"
                                                        TargetControlID="TextBoxDate" WatermarkText="dd-Jan-YYYY">
                                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ErrorMessage="*"
                                                        CssClass="warning" ControlToValidate="TextBoxDate">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelFeeEarnerTitle" runat="server" Text="Fee Earner:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="LabelFeeEarner" runat="server" Text=""></asp:Label>
                                                    <asp:DropDownList ID="DropDownListFeeEarner" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="HiddenFieldFeeEarnerId" runat="server" />
                                                    <asp:HiddenField ID="HiddenFieldFeeEarnerHourlyRate" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelOtherFeeEarnerTitle" runat="server" Text="Other Fee Earners:"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelTimeSpent" runat="server" Text="Time Spent:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxTimeSpent" runat="server" OnTextChanged="TextBoxTimeSpent_TextChanged"
                                                        AutoPostBack="true">
                                                    </asp:TextBox>
                                                    <%--                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTimeSpent" runat="server" ErrorMessage="*"
                                                        CssClass="warning" ControlToValidate="TextBoxTimeSpent">
                                                    </asp:RequiredFieldValidator>--%>
                                                    <asp:CustomValidator ID="CustomValidatorTimeSpent" runat="server" ErrorMessage="*"
                                                        CssClass="warning" ClientValidationFunction="checkingMultiple" ControlToValidate="TextBoxTimeSpent"></asp:CustomValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelFixedCost" runat="server" Text="Fixed Cost:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxFixedCost" runat="server" OnTextChanged="TextBoxFixedCost_TextChanged"
                                                        AutoPostBack="true">
                                                    </asp:TextBox>
                                                    <%--                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorFixedCost" runat="server" ErrorMessage="*"
                                                        CssClass="warning" ControlToValidate="TextBoxFixedCost">
                                                    </asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelFixedCostTimeSpent" runat="server" Text="Fixed Cost Time Spent:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxFixedCostTimeSpent" runat="server" OnTextChanged="TextBoxFixedCostTimeSpent_TextChanged"
                                                        AutoPostBack="true">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="setBillable" class="displayNone" runat="server">
                                                <td>
                                                    <asp:Label ID="LabelBillable" runat="server" Text="Billable:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxBillable" runat="server">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelStatus" runat="server" Text="Status:"></asp:Label>
                                                </td>
                                                <td>
                                                    <uc1:WebUserControlGetStatus ID="ucGetStatus1" runat="server" />
                                                    <%--            <br />
            <asp:CheckBox ID="CheckBoxCopyTo" runat="server" Text="CopyTo" />
            <br />
            <asp:CheckBox ID="CheckBoxMoveTo" runat="server" Text="MoveTo" />
                                                    --%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelDescription" runat="server" Text="Description:"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" Rows="8">
                                                    </asp:TextBox>
                                                </td>
                                            </tr>
                                            <%--                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelTemplate" runat="server" Text="Template:"></asp:Label>
                                                </td>
                                                <td>
                                                    <uc1:WebUserControlDDLTemplate ID="ucDllTemplate" runat="server" />
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelTemplate" runat="server" Text="Template:"></asp:Label>
                                                </td>
                                                <td>
                                                    <%-- <uc1:WebUserControlDDLTemplate ID="ucDllTemplate" runat="server" />--%>
                                                    <asp:DropDownList ID="DropDownListTemplateCore" runat="server" DataSourceID="EntityDataSourceTemplateCore"
                                                        DataTextField="typeName" DataValueField="id" OnSelectedIndexChanged="DropDownListTemplateCore_SelectedIndexChanged"
                                                        AutoPostBack="true" CssClass="DDLWidth">
                                                    </asp:DropDownList>
                                                    <asp:EntityDataSource ID="EntityDataSourceTemplateCore" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
                                                        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="TemplateTypes">
                                                    </asp:EntityDataSource>
                                                    <%--                                    <asp:DropDownList ID="DropDownListTemplateCore" runat="server" CssClass="DDLWidth">
                                    </asp:DropDownList>
                                    <ajaxToolkit:CascadingDropDown ID="ajaxDDLTemplateCore" runat="server" TargetControlID="DropDownListTemplateCore"
                                        LoadingText="Loading..." ServicePath="~/ServiceDDL.asmx" ServiceMethod="GetTemplateCore"
                                        Category="id">
                                    </ajaxToolkit:CascadingDropDown>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListTemplateDetails" runat="server" CssClass="DDLWidth"
                                                                    OnSelectedIndexChanged="DropDownListTemplateDetails_SelectedIndexChanged" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <%--                                                <ajaxToolkit:CascadingDropDown ID="ajaxDDLTemplateDetails" runat="server" TargetControlID="DropDownListTemplateDetails"
                                                    ParentControlID="DropDownListTemplateCore" LoadingText="Loading..." ServicePath="~/ServiceDDL.asmx"
                                                    ServiceMethod="GetTemplateDetails" Category="id">
                                                </ajaxToolkit:CascadingDropDown>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <div class="timerMaster floatL">
                                        <div class="floatL">
                                            <asp:Label ID="LabelStartTitle" runat="server" Text="Timer Start" />
                                            <div class="timer">
                                                <span class="time" id="timeId" runat="server">00:00:00</span>
                                            </div>
                                        </div>
                                        <div class="floatR">
                                            <asp:Label ID="LabelStopTitle" runat="server" Text="Timer Stop" />
                                            <div class="timer">
                                                <span class="timeStop" id="timeStop" runat="server">00:00:00</span>
                                            </div>
                                        </div>
                                        <div class="timeControl headerRMaster">
                                            <div class="headerRB">
                                                <asp:ImageButton ID="ImageButtonStart" runat="server" ImageUrl="~/images/__btn_play.png"
                                                    OnClick="ImageButtonStart_Click" CausesValidation="false"></asp:ImageButton>
                                                <asp:ImageButton ID="ImageButtonPause" runat="server" ImageUrl="~/images/__btn_pause_hover.png"
                                                    OnClick="ImageButtonPause_Click" CausesValidation="false"></asp:ImageButton>
                                                <asp:ImageButton ID="ImageButtonStop" runat="server" ImageUrl="~/images/__btn_stop_hover.png"
                                                    OnClick="ImageButtonStop_Click" CausesValidation="false"></asp:ImageButton>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="clear">
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:Button ID="ButtonRun" runat="server" Text="Create" OnClick="ButtonRun_Click" />
                        <%-- OnClientClick='<%$ Resources:LanguagePack,AddConfirm %>'--%>
                        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click"
                            Visible="false" OnClientClick="return validateUpdate();" />
                        <asp:Button ID="ButtonCancel" runat="server" Text="<%$ Resources:LanguagePack,lblCancel %>"
                            OnClick="ButtonCancel_Click" CausesValidation="false" />
                        <br />
                        <asp:Button ID="LinkButtonCopyTo" Visible="false" OnClick="LinkButtonCopyTo_OnClick"
                            runat="server" Text="CopyTo" CausesValidation="false" />
                        <br />
                        <asp:Button ID="LinkButtonMoveTo" Visible="false" OnClick="LinkButtonMoveTo_OnClick"
                            runat="server" Text="MoveTo" CausesValidation="false" />
                        <br />
                        <br />
                    </asp:Panel>
                    <asp:Accordion ID="Accordion1" CssClass="accordion" HeaderCssClass="accordionHeader"
                        HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent"
                        SelectedIndex="-1" FadeTransitions="true" RequireOpenedPane="false" SuppressHeaderPostbacks="true"
                        AutoSize="None" runat="server">
                        <Panes>
                            <asp:AccordionPane ID="AccordionPane1" runat="server">
                                <Header>
                                    <asp:Label ID="LabelTitleOldMatterDetails" runat="server" Text="<%$ Resources:LanguagePack, MatterCoreOldDetails %>"></asp:Label>
                                </Header>
                                <Content>
                                    <asp:GridView ID="GridViewMatterDetailsOld" RowStyle-CssClass="lineGridviewMaster"
                                        HeaderStyle-CssClass="lineGridviewMaster" runat="server" AutoGenerateColumns="False"
                                        DataKeyNames="id" DataSourceID="EntityDataSourceMatterDetailsOld" ShowFooter="True"
                                        Visible="false">
                                        <Columns>
                                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                                Visible="False" />
                                            <asp:DynamicField DataField="itemNum" HeaderText="<%$ Resources:LanguagePack, Mattercore_itemNum %>">
                                            </asp:DynamicField>
                                            <asp:DynamicField DataField="date" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="<%$ Resources:LanguagePack, Mattercore_date %>">
                                            </asp:DynamicField>
                                            <%--                <asp:DynamicField DataField="description" HeaderText="<%$ Resources:LanguagePack, Mattercore_description %>">
                </asp:DynamicField>--%>
                                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_description %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelMatterDescription" runat="server" Text='<%# showString(Eval("description"))%>'
                                                        title='<%# Eval("description")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_FeeEarner %>">
                                                <ItemTemplate>
                                                    <uc1:WebUserControlLBLUserName ID="ucLBLUserName" runat="server" userGuid='<%# Bind("feeEarner") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:DynamicField DataField="timespan" HeaderText="<%$ Resources:LanguagePack, Mattercore_timespan %>">
                                            </asp:DynamicField>
                                            <asp:DynamicField DataField="fixedCost" HeaderText="<%$ Resources:LanguagePack, Mattercore_fixedCost %>">
                                            </asp:DynamicField>
                                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_WittenOff %>">
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelWittenOff" runat="server" Text=""></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:DynamicField DataField="billable" HeaderText="<%$ Resources:LanguagePack, Mattercore_billable %>">
                                            </asp:DynamicField>
                                        </Columns>
                                    </asp:GridView>
                                    <table cellspacing="0" border="0" style="border-collapse: collapse;">
                                        <tr class="lineGridviewMaster">
                                            <th scope="col">
                                                Item No
                                            </th>
                                            <th scope="col">
                                                Date
                                            </th>
                                            <th scope="col">
                                                Description
                                            </th>
                                            <th scope="col">
                                                Fee Earner
                                            </th>
                                            <th scope="col">
                                                Time
                                            </th>
                                            <th scope="col">
                                                Fixed Cost
                                            </th>
                                            <th scope="col">
                                                Written Off
                                            </th>
                                            <th scope="col">
                                                Billable
                                            </th>
                                        </tr>
                                        <asp:Repeater ID="RepeaterOldTimeEntry" runat="server" OnItemDataBound="RepeaterOldTimeEntry_ItemDataBound">
                                            <ItemTemplate>
                                                <tr class="lineGridviewMaster" id="repContect" runat="server">
                                                    <td>
                                                        <asp:Label ID="LabelItem" runat="server" Text='<%# Eval("itemNum") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LabelDate" runat="server" Text='<%# Eval("date") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LabelDescription" runat="server" Text='<%# showString(Eval("description")) %>'
                                                            title='<%# Eval("description") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LabelFeeEarner" runat="server" Text='<%# Eval("feeEarner") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LabelTime" runat="server" Text='<%# Eval("timespan") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LabelFixedCost" runat="server" Text='<%# Eval("fixedCost") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LabelWrittenOff" runat="server" Text='<%# Eval("writtenOff") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LabelBillable" runat="server" Text='<%# Eval("billable") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="lineGridviewMaster" id="repSubTotal" runat="server">
                                                    <td colspan="8">
                                                        <asp:Label ID="LabelDebitNoteInfo" runat="server" Text='<%# Eval("info") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>
                    <br />
                    <br />
                    <asp:Button ID="ButtonMultiCopy" runat="server" Text="Copy To" OnClick="ButtonMultiCopy_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="ButtonMultiMove" runat="server" Text="Move To" OnClick="ButtonMultiMove_Click" />
                    <br />
                    <br />
                    <asp:GridView ID="GridViewMatterDetails" RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster"
                        runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSourceMatterDetails"
                        OnRowDataBound="GridViewMatterDetails_RowDataBound" ShowFooter="True" OnRowCommand="GridViewMatterDetails_RowCommand"
                        AllowSorting="True" AllowPaging="True" PageSize="<%$ appSettings:GridViewPageSize %>"
                        OnDataBound="GridViewMatterDetails_DataBound">
                        <HeaderStyle CssClass="lineGridviewMaster"></HeaderStyle>
                        <RowStyle CssClass="lineGridviewMaster"></RowStyle>
                        <SelectedRowStyle BackColor="LightGoldenrodYellow" ForeColor="DarkOrange" Font-Bold="true" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                Visible="False" />
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckBoxAllCopyOrMove" runat="server" onclick="javascript: SelectAllCopyOrMove(this);"
                                        class="CheckBoxAllCopyOrMove" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBoxCopyOrMove" CssClass="CheckBoxCopyOrMove" runat="server"
                                        Text="" /></ItemTemplate>
                            </asp:TemplateField>
                            <asp:DynamicField DataField="itemNum" HeaderText="<%$ Resources:LanguagePack, Mattercore_itemNum %>"
                                SortExpression="itemNum"></asp:DynamicField>
                            <asp:DynamicField DataField="date" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="<%$ Resources:LanguagePack, Mattercore_date %>"
                                SortExpression="date"></asp:DynamicField>
                            <%--                <asp:DynamicField DataField="description" HeaderText="<%$ Resources:LanguagePack, Mattercore_description %>">
                </asp:DynamicField>--%>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_description %>"
                                SortExpression="description">
                                <ItemTemplate>
                                    <asp:Label ID="LabelMatterDescription" runat="server" Text='<%# showString(Eval("description"))%>'
                                        title='<%# Eval("description")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_FeeEarner %>"
                                SortExpression="feeEarner">
                                <ItemTemplate>
                                    <uc1:WebUserControlLBLUserName ID="ucLBLUserName" runat="server" userGuid='<%# Bind("feeEarner") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:DynamicField DataField="timespan" HeaderText="<%$ Resources:LanguagePack, Mattercore_timespan %>">
                            </asp:DynamicField>
                            <asp:DynamicField DataField="fixedCost" HeaderText="<%$ Resources:LanguagePack, Mattercore_fixedCost %>">
                            </asp:DynamicField>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_WittenOff %>">
                                <ItemTemplate>
                                    <asp:Label ID="LabelWittenOff" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:DynamicField DataField="billable" HeaderText="<%$ Resources:LanguagePack, Mattercore_billable %>">
                            </asp:DynamicField>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_CountTotal %>">
                                <ItemTemplate>
                                    <asp:Label ID="LabelCountTotal" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="LinkButtonSelect" runat="server" CausesValidation="False" CommandName="Select"
                                        Text="<%$ Resources:LanguagePack, lblEdit %>" CommandArgument='<%# Bind("id") %>'>
                                    </asp:Button>
                                    <asp:Button ID="LinkButtonDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                        CommandArgument='<%# Eval("id")%>' Text="<%$ Resources:LanguagePack, lblDelete %>"
                                        OnClientClick="<%$ Resources:LanguagePack, DeleteConfirm %>" Visible="false">
                                    </asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <uc:ucPaging ID="ucPaging" runat="server" />
                        </PagerTemplate>
                    </asp:GridView>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
    <asp:EntityDataSource ID="EntityDataSourceMatter" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="MatterCores"
        Where="" OnSelecting="EntityDataSourceMatter_Selecting" EnableUpdate="True">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceMatterClient" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="Clients"
        Where="" OnSelecting="EntityDataSourceMatterClient_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceMatterRefer" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="Referers"
        Where="" OnSelecting="EntityDataSourceMatterRefer_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceMatterDetails" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="MatterDetails" OnSelecting="EntityDataSourceMatterDetails_Selecting"
        EntityTypeFilter="" OrderBy="it.date ASC, it.itemNum ASC" Select="">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceMatterDetailsOld" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="View_OldTimeEntry"
        OnSelecting="EntityDataSourceMatterDetailsOld_Selecting" OrderBy="it.CreateDebitNoteDate ASC"
        EntityTypeFilter="" Select="">
    </asp:EntityDataSource>
    <asp:CustomValidator ID="CustomValidatorTimeSpentAndFixedCost" runat="server" ErrorMessage="*"
        CssClass="warning" OnServerValidate="CustomValidatorTimeSpentAndFixedCost_ServerValidate"></asp:CustomValidator>
</asp:Content>
