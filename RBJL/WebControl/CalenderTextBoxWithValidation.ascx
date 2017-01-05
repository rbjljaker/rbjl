<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalenderTextBoxWithValidation.ascx.cs"
    Inherits="WebControl_CalenderTextBoxWithValidation_" %>
<asp:TextBox ID="TextBoxDate" runat="server"></asp:TextBox>
<ajaxToolkit:CalendarExtender ID="CalendarExtenderDate" runat="server" TargetControlID="TextBoxDate"
    Format="dd-MMM-yyyy">
</ajaxToolkit:CalendarExtender>
<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderDate" runat="server"
    TargetControlID="TextBoxDate" WatermarkText="dd-Jan-YYYY">
</ajaxToolkit:TextBoxWatermarkExtender>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
    ControlToValidate="TextBoxDate" CssClass="warning"></asp:RequiredFieldValidator>