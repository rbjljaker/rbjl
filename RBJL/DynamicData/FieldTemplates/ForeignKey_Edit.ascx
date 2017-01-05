<%@ Control Language="C#" CodeFile="ForeignKey_Edit.ascx.cs" Inherits="ForeignKey_EditField" %>

<asp:DropDownList ID="DropDownList1" runat="server" CssClass="DDDropDown dropdownlistWidth">
</asp:DropDownList>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator warning" ControlToValidate="DropDownList1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator warning" ControlToValidate="DropDownList1" Display="Static" />

