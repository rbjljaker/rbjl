<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BottomButton.ascx.cs"
    Inherits="WebControl_BottomButton" %>
<asp:Panel ID="PanelTwoButton" runat="server">
    <div class="floatR">
        <asp:Button ID="ButtonAction" runat="server" CssClass="twoBtn" Text="<%$ Resources:LanguagePack, BottomButtonAction %>"
            OnClick="ButtonAction_Click" />
        <asp:Button ID="ButtonCancel" runat="server" CssClass="twoBtn" Text="<%$ Resources:LanguagePack, BottomButtonCancel %>"
            OnClick="ButtonCancel_Click" />
    </div>
</asp:Panel>
