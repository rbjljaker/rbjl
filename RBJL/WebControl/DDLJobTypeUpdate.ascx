<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DDLJobTypeUpdate.ascx.cs"
    Inherits="WebControl_DDLJobTypeUpdate" %>
<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="EntityDataSource1"
    DataTextField="name" DataValueField="num">
</asp:DropDownList>
<asp:Label ID="TextBox1" runat="server" Text='<%# setTxtValue()%>'></asp:Label>
<br />
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="JobTypes"
    Select="it.[name], it.[num]">
</asp:EntityDataSource>
