<%@ Control Language="C#" CodeFile="MultilineText_Edit.ascx.cs" Inherits="MultilineText_EditField" %>

<asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Text='<%# FieldValueEditString %>' Columns="80" Rows="10" CssClass="textAreaCss"></asp:TextBox>

<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" CssClass="DDControl DDValidator warning" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" id="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" />

