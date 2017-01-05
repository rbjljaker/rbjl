<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="New.aspx.cs" Inherits="DebitNote_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteNewlblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Label ID="LabelMatterNum" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteNewMatterNum %>"></asp:Label>
    <asp:TextBox ID="TextBoxMatterNum" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" />
    <br />
    <br />
    Examples:
    <br />
    30000
    <br />
    30000,30001
    <br />
</asp:Content>
