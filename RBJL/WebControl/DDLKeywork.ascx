<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DDLKeywork.ascx.cs" Inherits="WebControl_DDLKeywork" %>

<asp:DropDownList ID="DropDownList1" runat="server" 
    DataSourceID="EntityDataSource1" DataTextField="name" DataValueField="id" AppendDataBoundItems="true">
</asp:DropDownList>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" 
    ConnectionString="name=RBJLLawFirmDBEntities" 
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" 
    EntitySetName="Keyworks">
</asp:EntityDataSource>
