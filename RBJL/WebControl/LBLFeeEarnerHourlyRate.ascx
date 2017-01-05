<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LBLFeeEarnerHourlyRate.ascx.cs"
    Inherits="WebControl_LBLFeeEarnerHourlyRate" %>
<asp:Label ID="Label1" runat="server" Text='<%# findMatterUser() %>'></asp:Label>
<asp:Repeater ID="RepeaterHourlyRate" runat="server">
    <HeaderTemplate>
        <span class="viewdMatter">
            <table class="repTH">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td class="repTE">
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("userId") %>' />
                <asp:Label ID="LabelUserName" runat="server" Text='<%# Eval("userName") %>'></asp:Label>
            </td>
            <td>
                :
                <asp:Label ID="LabelHourRate" runat="server" Text='<%# Eval("hourRate") %>'></asp:Label>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table> </span>
    </FooterTemplate>
</asp:Repeater>
