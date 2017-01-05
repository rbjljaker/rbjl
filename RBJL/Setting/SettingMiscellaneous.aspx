<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="SettingMiscellaneous.aspx.cs" Inherits="Admin_SettingMiscellaneous" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, SettingMiscellaneouslblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Label ID="LabelNumSetup" runat="server" CssClass="underLinkText" Text="<%$ Resources:LanguagePack, SettingMiscellaneousLabelNumSetup %>" />
    <br />
    <div class="lineHeight">
        <asp:Label ID="LabelClientNoStartFrom" runat="server" CssClass="SettingMiscellaneous"
            Text="<%$ Resources:LanguagePack, SettingMiscellaneousLabelClientNoStartFrom %>" />
        <asp:TextBox ID="TextBoxClientNoStartFrom" runat="server"></asp:TextBox>
        <asp:CheckBox ID="CheckBoxClientNoStartFrom" runat="server" />
        <asp:Label ID="LabelAutoGen" runat="server" Text="<%$ Resources:LanguagePack, SettingMiscellaneousLabelAutoGen %>" />
        <br />
        <asp:Label ID="LabelMatterNoStartFrom" runat="server" CssClass="SettingMiscellaneous"
            Text="<%$ Resources:LanguagePack, SettingMiscellaneousLabelMatterNoStartFrom %>" />
        <asp:TextBox ID="TextBoxMatterNoStartFrom" runat="server"></asp:TextBox>
        <asp:CheckBox ID="CheckBoxMatterNoStartFrom" runat="server" />
        <asp:Label ID="LabelAutoGen2" runat="server" Text="<%$ Resources:LanguagePack, SettingMiscellaneousLabelAutoGen %>" />
        <br />
        <asp:Label ID="LabelDebitNoteNoStartFrom" runat="server" CssClass="SettingMiscellaneous"
            Text="<%$ Resources:LanguagePack, SettingMiscellaneousLabelDebitNoteNoStartFrom %>" />
        <asp:TextBox ID="TextBoxDebitNoteNoStartFrom" runat="server"></asp:TextBox>
        <asp:CheckBox ID="CheckBoxDebitNoteNoStartFrom" runat="server" />
        <asp:Label ID="LabelAutoGen3" runat="server" Text="<%$ Resources:LanguagePack, SettingMiscellaneousLabelAutoGen %>" />
        <br />
        <br />
        <asp:Label ID="LabelAccountEmailTitle" runat="server" CssClass="underLinkText" Text="<%$ Resources:LanguagePack, SettingMiscellaneousLabelAccountEmailTitle %>" />
        <br />
        <asp:Label ID="LabelAccountEmail" runat="server" CssClass="" Text="<%$ Resources:LanguagePack, SettingMiscellaneousLabelAccountEmail %>" />
        <asp:TextBox ID="TextBoxAccountEmail" runat="server" Width="300px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LabelWhatNewsSetup" runat="server" CssClass="underLinkText" Text="<%$ Resources:LanguagePack, SettingMiscellaneousLabelWhatNewsSetup %>" />
        <asp:TextBox ID="txtComments" runat="server" Columns="60" Rows="8" TextMode="MultiLine" Height="300" />
        <asp:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="txtComments"
            EnableSanitization="false" />
        <br />
        <br />
        <div>
            <asp:Button ID="ButtonAction" runat="server" CssClass="twoBtn" Text="<%$ Resources:LanguagePack, BottomButtonAction %>"
                OnClick="ButtonAction_Click" />
            <asp:Button ID="ButtonCancel" runat="server" Width="60px" CssClass="twoBtn" Text="<%$ Resources:LanguagePack, BottomButtonCancel %>"
                OnClick="ButtonCancel_Click" />
        </div>
    </div>
</asp:Content>
