<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="Setting_UserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
<asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, UserManagementlblTitle %>"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" Runat="Server">
 <table style="width: 100%; text-align: left;">
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
                <asp:Label ID="lblUsername" runat="server" Text="lblUserName"></asp:Label>
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
                <asp:Label ID="lblEmail" runat="server" Text="lblEmail"></asp:Label>
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
                                    <asp:Label ID="lblLockUser" runat="server" Text="lblLockUser"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBoxLockUser" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxLockUser_CheckedChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 26px">
                                </td>
                                <td style="width: 159px" valign="top">
                                    <asp:Label ID="lblChangePassword" runat="server" Text="lblChangePassword"></asp:Label>
                                </td>
                                <td valign="top">
                                    <asp:CheckBox ID="CheckBoxChangePassword" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBoxChangePassword_CheckedChanged" />
                                    <br />
                                    <asp:Panel ID="PanelPasswordChange" runat="server" Visible="False">
                                        <table>
                                            <tr>
                                                <td style="width: 137px">
                                                    <asp:Label ID="lblNewPassword" runat="server" Text="lblNewPassword"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NewPassword"
                                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 137px">
                                                    <asp:Label ID="lblConfirmPassword" runat="server" Text="lblConfirmNewPassword"></asp:Label>
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
                                                        Display="Dynamic" ControlToValidate="ConfirmNewPassword" ErrorMessage="lblConfirmPasswordCompareErrorMessage"></asp:CompareValidator>
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
                <asp:Button ID="ButtonUpdate" runat="server" Text="lblUpdate"
                    OnClick="ButtonUpdate_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="~/Setting/loginManagement.aspx"
                    Text="lblBackToLoginManagement"></asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>

