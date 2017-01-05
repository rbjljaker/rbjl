<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="css/login/base.css" rel="stylesheet" type="text/css" />
    <link href="css/login/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/login/jquery-ui-1.8.23.custom.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .warning
        {
            color: Red;
            font-size: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainLogin">
        <asp:Login ID="LoginMyLogin" runat="server" OnAuthenticate="LoginMyLogin_Authenticate"
            DestinationPageUrl="~/roleRedirector.ashx" OnLoginError="LoginMyLogin_LoginError"
            CssClass="LoginP" OnLoggingIn="LoginMyLogin_LoggingIn">
            <LayoutTemplate>
                <div class="main_logonPage">
                    <div class="divLoginContainer">
                        <div class="comp_logo">
                            <img src="images/logo-header.gif" />
                        </div>
                        <h1>
                            Time Billing System
                        </h1>
                        <div id="divHighlightContainer">
                        </div>
                        <div class="logon_form">
                            <span class="warning">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </span>
                            <table border="0" cellspacing="0" cellpadding="0">
                                </tr>
                                <tr>
                                    <th>
                                        <h5>
                                            Username<br />
                                            用戶名稱</h5>
                                    </th>
                                    <td colspan="2">
                                        <%--<input name="tbxUsername" type="text" class="textbox" id="tbxUsername" />--%>
                                        <asp:TextBox ID="UserName" runat="server" CssClass="textbox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="LoginMyLogin">*</asp:RequiredFieldValidator>
                                    </td>
                                    <tr>
                                        <th>
                                            <h5>
                                                Password<br />
                                                密碼</h5>
                                        </th>
                                        <td colspan="2">
                                            <%--<input name="tbxPassword" type="password" class="textbox" id="tbxPassword" />--%>
                                            <asp:TextBox ID="Password" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LoginMyLogin">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <h5>
                                                Key<br />
                                                驗証碼</h5>
                                        </th>
                                        <td style="width: 80px">
                                            <asp:TextBox ID="Captcha" runat="server" MaxLength="4" Width="50px"></asp:TextBox>
                                            <%--<input id="captcha" name="tbxKey" type="text" size="5" maxlength="5" class="inputkey" runat="server" />--%>
                                        </td>
                                        <td>
                                            <asp:Image ID="ImageCaptcha" ImageUrl="~/CaptchaCreator.ashx" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            &nbsp;
                                        </th>
                                        <td colspan="2">
                                            <%--                                        <input style="float: left;" name="btnSubmit" type="submit" class="button submit"
                                            id="btnSubmit" value="Submit 傳送" />--%>
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" CssClass="button submit"
                                                OnClick="LoginButton_Click" Text="Submit 傳送" ValidationGroup="LoginMyLogin" />
                                            <%--<a href="" style="float: right; margin-top: 8px;">Back to home 回主頁</a>--%>
                                            <br class="clsFloat" />
                                        </td>
                                    </tr>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="divFooterBar">
                    </div>
                </div>
            </LayoutTemplate>
        </asp:Login>
    </div>
    </form>
</body>
</html>
