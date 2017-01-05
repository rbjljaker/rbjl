<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="systemUser.aspx.cs" Inherits="Admin_systemUser" %>

<%@ Register Src="~/WebControl/LBLDoworkTitle.ascx" TagName="WebUserControlLBLDoworkTitle"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, CreateNewUserlblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <%--    <asp:HyperLink ID="HyperLinkLoginUser" runat="server" NavigateUrl="~/Setting/LoginManagement.aspx">LoginUser</asp:HyperLink>--%>
    <div>
        <table border="0" cellpadding="0" cellspacing="3" width="100%">
            <asp:ObjectDataSource ID="odsRoles" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetRoles" TypeName="MembershipUtilities.RoleODS"></asp:ObjectDataSource>
            <tr>
                <td>
                    <table style="width: 400px">
                        <tr>
                            <td style="width: 11px">
                                &nbsp;
                            </td>
                            <td style="width: 311px">
                                <asp:Label ID="lblSelectRole" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_lblSelectRole %>"></asp:Label>
                            </td>
                            <td style="width: 730px">
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" DataSourceID="odsRoles"
                                    DataTextField="RoleName" DataValueField="RoleName" OnDataBound="DropDownList1_DataBound">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 11px">
                                &nbsp;
                            </td>
                            <td style="width: 311px">
                                <asp:Label ID="lblUsername" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_lblUsername %>"></asp:Label>
                            </td>
                            <td style="width: 730px">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                <asp:Button ID="btnSearch" OnClick="btnSearch_OnClick" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_btnSearch %>" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsUsers" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetMembers" TypeName="MembershipUtilities.MembershipUserODS"
                        UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="UserName" Type="String" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="userName" Type="String" />
                            <asp:Parameter Name="isApproved" Type="Boolean" />
                            <asp:Parameter Name="comment" Type="String" />
                            <asp:Parameter Name="lastLockoutDate" Type="DateTime" />
                            <asp:Parameter Name="creationDate" Type="DateTime" />
                            <asp:Parameter Name="email" Type="String" />
                            <asp:Parameter Name="lastActivityDate" Type="DateTime" />
                            <asp:Parameter Name="providerName" Type="String" />
                            <asp:Parameter Name="isLockedOut" Type="Boolean" />
                            <asp:Parameter Name="lastLoginDate" Type="DateTime" />
                            <asp:Parameter Name="isOnline" Type="Boolean" />
                            <asp:Parameter Name="passwordQuestion" Type="String" />
                            <asp:Parameter Name="lastPasswordChangedDate" Type="DateTime" />
                            <asp:Parameter Name="password" Type="String" />
                            <asp:Parameter Name="passwordAnswer" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:Parameter Name="returnAllApprovedUsers" Type="Boolean" />
                            <asp:ControlParameter ControlID="TextBox1" Name="usernameToFind" PropertyName="Text"
                                Type="String" />
                            <asp:Parameter Name="sortData" Type="String" />
                            <asp:ControlParameter ControlID="DropDownList1" Name="roleName" PropertyName="SelectedValue"
                                Type="String" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="UserName" Type="String" />
                            <asp:Parameter Name="email" Type="String" />
                            <asp:Parameter Name="isApproved" Type="Boolean" />
                            <asp:Parameter Name="isLockedOut" Type="Boolean" />
                            <asp:Parameter Name="comment" Type="String" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="UserName,Role"
                        DataSourceID="odsUsers" Width="100%" AllowPaging="True" OnRowEditing="GridView1_RowEditing"
                        OnRowDataBound="GridView1_RowDataBound" CssClass="gvClass" RowStyle-CssClass="lineGridviewMaster"
                        HeaderStyle-CssClass="lineGridviewMaster" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, systemUserpopup_UserName %>"
                                SortExpression="UserName">
                                <EditItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Role" HeaderText="<%$ Resources:LanguagePack, systemUserpopup_lblGvRole %>"
                                ReadOnly="True" SortExpression="Role" />
                            <asp:BoundField DataField="Email" HeaderText="<%$ Resources:LanguagePack, systemUserpopup_lblGvEmail %>"
                                SortExpression="Email" />
                            <asp:CheckBoxField DataField="IsApproved" HeaderText="<%$ Resources:LanguagePack, systemUserpopup_lblGvApproved %>"
                                SortExpression="IsApproved" />
                            <asp:CheckBoxField DataField="IsLockedOut" HeaderText="<%$ Resources:LanguagePack, systemUserpopup_lblGvLockedOut %>"
                                ReadOnly="True" SortExpression="IsLockedOut" />
                            <asp:BoundField DataField="LastLoginDate" HeaderText="<%$ Resources:LanguagePack, systemUserpopup_lblGvLastLoginDate %>"
                                SortExpression="LastLoginDate" HeaderStyle-Width="80px" />
                            <%--<asp:CheckBoxField DataField="IsOnline" HeaderText="<%$ Resources:LanguagePack, systemUserpopup_IsOnline %>" ReadOnly="True" SortExpression="IsOnline" />--%>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Edit"
                                        Text="Edit" />
                                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="Delete" OnClientClick="<%$ Resources:LanguagePack, DeleteConfirm %>" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CausesValidation="True" CommandName="Update"
                                        Text="Update" />
                                    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="Cancel" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="LinkButtonLoginUser" runat="server" OnClick="LinkButtonLoginUser_OnClick"
                        Text="<%$ Resources:LanguagePack, systemUserLabelAddUser%>"></asp:Button>
                </td>
            </tr>
        </table>
    </div>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderSearch" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panAdd" BackgroundCssClass="modalBackground" CancelControlID="btnCancelAdd"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtenderSearch" runat="server" Title="<%$ Resources:LanguagePack, SettingAddUserTitle %>"
        Icon="Application" Maximizable="true" AutoScroll="true" Modal="true" Hidden="true"
        Width="<%$ appSettings:windWidthSize %>" Height="<%$ appSettings:windHeightSizeL %>">
        <Content>--%>
    <asp:Panel ID="panAdd" runat="server" CssClass="newpopM radiusClass">
        <asp:Panel ID="panDragAdd" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleAdd" runat="server" Text="<%$ Resources:LanguagePack, SettingAddUserTitle %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancelAdd" runat="server" ImageUrl="~/images/close.png" CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:CreateUserWizard ID="CreateUserWizardLinkReit" runat="server" LoginCreatedUser="False"
            OnCreatedUser="CreateUserWizardLinkReit_CreatedUser" DuplicateEmailErrorMessage="<%$ Resources:LanguagePack, wrnPleaseEnterADiffernetEmailAddress%>"
            DuplicateUserNameErrorMessage="<%$ Resources:LanguagePack, wrnPleaseEnterADirrerentUserName %>"
            InvalidPasswordErrorMessage="<%$ Resources:LanguagePack, wrnPasswordRequirement %>"
            UnknownErrorMessage="<%$ Resources:LanguagePack, wrnCreateUserUnknowErrorMessage%>"
            InvalidEmailErrorMessage="<%$ Resources:LanguagePack, lblEmailInvalid %>">
            <FinishNavigationTemplate>
                <asp:Button ID="FinishPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                    Text="<%$ Resources:LanguagePack, FinishPreviousButtonCreateNewUser %>" />
                <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete" Text="<%$ Resources:LanguagePack, FinishButtonCreateNewUser %>" />
            </FinishNavigationTemplate>
            <StepNavigationTemplate>
                <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                    Text="<%$ Resources:LanguagePack, FinishPreviousButtonCreateNewUser %>" />
                <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="<%$ Resources:LanguagePack, StepNextButtonCreateNewUser %>" />
            </StepNavigationTemplate>
            <StartNavigationTemplate>
                <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" Text="<%$ Resources:LanguagePack, StepNextButtonCreateNewUser %>" />
            </StartNavigationTemplate>
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                    <ContentTemplate>
                        <table border="0" class="SystemUserGV lineHeight">
                            <%--                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="lblSignUp" runat="server" Text="<%$ Resources:LanguagePack, lblSignUpCreateNewUser %>"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="alignRight HRWidth">
                                    <asp:Label ID="LabelUserNum" runat="server" Text="<%$ Resources:LanguagePack, UserNumLabelCreateNewUser %>" />
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxUserNum" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="alignRight">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">
                                        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:LanguagePack, UserNameLabelCreateNewUser %>"></asp:Label></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="<%$ Resources:LanguagePack, lblUserNameIsRequired %>" ToolTip="<%$ Resources:LanguagePack, lblUserNameIsRequired %>"
                                        ValidationGroup="CreateUserWizard1" CssClass="warning">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="alignRight ">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">
                                        <asp:Label ID="Label3" runat="server" Text="<%$ Resources:LanguagePack, PasswordLabelCreateNewUser %>"></asp:Label></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="<%$ Resources:LanguagePack, lblNewPasswordRequired %>" ToolTip="<%$ Resources:LanguagePack, lblNewPasswordRequired %>"
                                        ValidationGroup="CreateUserWizard1" CssClass="warning">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="alignRight">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">
                                        <asp:Label ID="Label4" runat="server" Text="<%$ Resources:LanguagePack, ConfirmPasswordLabelCreateNewUser %>"></asp:Label></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                        ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                        ValidationGroup="CreateUserWizard1" CssClass="warning">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="alignRight">
                                    <asp:Label ID="LabelFirstName" runat="server" Text="<%$ Resources:LanguagePack, CreateNewUserFirstName %>" />
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
                                    <asp:Label ID="LabelLastName" runat="server" Text="<%$ Resources:LanguagePack, CreateNewUserLastName %>" />
                                    <asp:TextBox ID="TextLastName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="alignRight">
                                    <asp:Label ID="LabelNickName" runat="server" Text="<%$ Resources:LanguagePack, CreateNewUserNickName %>" />
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxNickName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="alignRight">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">
                                        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:LanguagePack, EmailLabelCreateNewUser %>"></asp:Label></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        ErrorMessage="E-mail is required." CssClass="warning" ToolTip="E-mail is required."
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="ValidateEmail" runat="server" ErrorMessage="<%$ Resources:LanguagePack, lblEmailInvalid %>"
                                        ControlToValidate="Email" CssClass="warning" ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <%--                            <tr>
                                <td class="alignRight">
                                    <asp:Label ID="LabelUnitRate" runat="server" Text="<%$ Resources:LanguagePack, UnitRateLabelCreateNewUser %>" />
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxUnitRate" runat="server"></asp:TextBox>
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="alignRight">
                                    <asp:Label ID="lblSelectRoles" runat="server" Text="<%$ Resources:LanguagePack, lblSelectRolesCreateNewUser %>"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="RoleList" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="<%$ Resources:LanguagePack, lblPasswordAndConfirmationPasswordMustMatch %>"
                                        ValidationGroup="CreateUserWizard1" CssClass="warning"></asp:CompareValidator>
                                    <br />
                                    <asp:Label ID="ErrMes" CssClass="Warning" runat="server" EnableViewState="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" class="warning">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <CustomNavigationTemplate>
                        <table border="0" cellspacing="5" style="width: 100%; height: 100%;">
                            <tr align="right">
                                <td align="right" colspan="0">
                                    <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="<%$ Resources:LanguagePack, StepNextButtonCreateNewUser %>"
                                        ValidationGroup="CreateUserWizard1" />
                                </td>
                            </tr>
                        </table>
                    </CustomNavigationTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep2" runat="server">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="lblComplete" runat="server" Text="<%$ Resources:LanguagePack, lblCompleteCreateNewUser %>"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSuccess" runat="server" Text="<%$ Resources:LanguagePack, lblSuccessCreateNewUser %>"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" style="height: 27px">
                                    <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                        OnClick="ContinueButton_Click" Text="<%$ Resources:LanguagePack, ContinueButtonCreateNewUser %>"
                                        ValidationGroup="CreateUserWizard1" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Setting/systemUser.aspx"
            Text="<%$ Resources:LanguagePack, systemUserpopup_lblBackTosystemUser %>"></asp:HyperLink>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEdit" runat="server" TargetControlID="lnkPopup"
        PopupControlID="panAddEdit" BackgroundCssClass="modalBackground" CancelControlID="btnCancelEdit"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtenderEdit" runat="server" Title="<%$ Resources:LanguagePack, SettingEditUserTitle %>"
        Icon="Application" Maximizable="true" AutoScroll="true" Modal="true" Hidden="true"
        Width="<%$ appSettings:windWidthSize %>" Height="<%$ appSettings:windHeightSizeL %>">
        <Content>--%>
    <asp:Panel ID="panAddEdit" runat="server" CssClass="newpopM radiusClass">
        <asp:Panel ID="panDrag" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitle" runat="server" Text="<%$ Resources:LanguagePack, SettingEditUserTitle %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancelEdit" runat="server" ImageUrl="~/images/close.png"
                    CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <table style="width: 100%; text-align: left;" class="masterDe lineHeight">
            <tr>
                <td style="width: 26px; height: 18px">
                </td>
                <td style="height: 18px; width: 159px">
                </td>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 26px">
                    &nbsp;
                </td>
                <td style="width: 159px">
                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_lblUserName_edit %>"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblShowUsername" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 26px">
                    &nbsp;
                </td>
                <td style="width: 159px">
                    <asp:Label ID="lblEmail" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_lblEmail %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail"
                        ErrorMessage="Please enter a valid e-mail address." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:UpdatePanel ID="updatePanelChangePassword" runat="server" UpdateMode="Conditional"
                        ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <table cellpadding="0" style="width: 500px; text-align: left;">
                                <tr>
                                    <td style="width: 26px">
                                    </td>
                                    <td style="width: 159px">
                                        <asp:Label ID="lblLockUser" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_lblLockUser %>"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxLockUser" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxLockUser_CheckedChanged" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 26px">
                                    </td>
                                    <td style="width: 159px" valign="top">
                                        <asp:Label ID="lblChangePassword" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_lblChangePassword %>"></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <asp:CheckBox ID="CheckBoxChangePassword" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxChangePassword_CheckedChanged" />
                                        <br />
                                        <asp:Panel ID="PanelPasswordChange" runat="server" Visible="False">
                                            <table>
                                                <tr>
                                                    <td style="width: 137px">
                                                        <asp:Label ID="lblNewPassword" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_lblNewPassword %>"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NewPassword"
                                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 137px">
                                                        <asp:Label ID="lblConfirmPassword" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_lblConfirmNewPassword %>"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ConfirmNewPassword"
                                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="NewPassword"
                                                            Display="Dynamic" ControlToValidate="ConfirmNewPassword" ErrorMessage="<%$ Resources:LanguagePack, lblConfirmPasswordCompareErrorMessage %>"></asp:CompareValidator>
                                                        <asp:Label ID="lblUserPasswordWarning" runat="server" CssClass="Warning" EnableViewState="False"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="CheckBoxChangePassword" />
                            <asp:AsyncPostBackTrigger ControlID="CheckBoxLockUser" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="width: 26px">
                    &nbsp;
                </td>
                <td style="width: 159px">
                    <asp:Label ID="LabelEditUserNum" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_lblUserName_UserNo %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEditUserNum" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 26px">
                    &nbsp;
                </td>
                <td style="width: 159px">
                    <asp:Label ID="LabelEditFirstName" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopupLabelEditFirstName %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEditFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 26px">
                    &nbsp;
                </td>
                <td style="width: 159px">
                    <asp:Label ID="LabelEditLastName" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopupLabelEditLastName %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEditLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 26px">
                    &nbsp;
                </td>
                <td style="width: 159px">
                    <asp:Label ID="LabelEditNickName" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_LabelEditNickName %>"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEditNickName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 26px">
                    &nbsp;
                </td>
                <td style="width: 159px">
                    <asp:Label ID="LabelEditUserRole" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_LabelEditUserRole %>"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListEditUserRole" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 26px">
                    &nbsp;
                </td>
                <td style="width: 159px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="Label1" runat="server" CssClass="Warning"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 26px">
                    &nbsp;
                </td>
                <td style="width: 159px">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="ButtonUpdate" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_lblUpdate %>"
                        OnClick="ButtonUpdate_Click" />
                    &nbsp; &nbsp;
                    <asp:Button ID="ButtonUnlockUser" runat="server" Text="<%$ Resources:LanguagePack, systemUserpopup_LabelLockedOut %>"
                        OnClick="ButtonUnlockUser_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <%--                <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="~/Setting/loginManagement.aspx"
                    Text="<%$ Resources:LanguagePack, systemUserpopup_lblBackToLoginManagement %>"></asp:HyperLink>
                    --%>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Setting/systemUser.aspx"
                        Text="<%$ Resources:LanguagePack, systemUserpopup_lblBackToLoginManagement %>"></asp:HyperLink>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <a id="lnkPopup" runat="server"></a>
</asp:Content>
