<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uploadLogo.ascx.cs" Inherits="WebControl_uploadLogo" %>
<asp:FileUpload ID="FileUploadLogo" runat="server" />
<asp:RegularExpressionValidator ID="RegularExpressionValidatorFileUploadAD" runat="server"
    ErrorMessage="<%$ Resources:LanguagePack, validMess %>" ValidationExpression="(.*\.([gG][iI][fF]|[jJ][pP][gG]|[jJ][pP][eE][gG]|[bB][mM][pP]|[pP][nN][gG]|[mM][pP][44])$)"
    ControlToValidate="FileUploadLogo" CssClass="warning"></asp:RegularExpressionValidator>