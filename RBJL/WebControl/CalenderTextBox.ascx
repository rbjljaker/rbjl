<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalenderTextBox.ascx.cs"
    Inherits="WebControl_CalenderTextBox" %>
<asp:TextBox ID="TextBoxDate" runat="server"></asp:TextBox>
<ajaxToolkit:CalendarExtender ID="CalendarExtenderDate" runat="server" TargetControlID="TextBoxDate"
    Format="dd-MMM-yyyy">
</ajaxToolkit:CalendarExtender>
<ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderDate" runat="server"
    TargetControlID="TextBoxDate" WatermarkText="dd-Jan-YYYY">
</ajaxToolkit:TextBoxWatermarkExtender>
