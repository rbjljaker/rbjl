<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DDLMasterKeywordUpdate.ascx.cs"
    Inherits="WebControl_DDLMasterKeywordUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="EntityDataSource1"
    DataTextField="name" DataValueField="id" AppendDataBoundItems="true">
</asp:DropDownList>
<asp:Label ID="TextBox1" runat="server" Text='<%# setTxtValue()%>'></asp:Label>
<br />
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="Keyworks">
</asp:EntityDataSource>
