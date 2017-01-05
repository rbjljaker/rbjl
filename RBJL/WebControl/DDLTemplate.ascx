<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DDLTemplate.ascx.cs" Inherits="WebControl_DDLTemplate" %>
<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="EntityDataSource1"
    DataTextField="detailsDescription" DataValueField="id">
</asp:DropDownList>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="TemplateDetails">
</asp:EntityDataSource>
