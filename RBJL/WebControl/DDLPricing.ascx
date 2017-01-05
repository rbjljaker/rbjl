<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DDLPricing.ascx.cs" Inherits="WebControl_DDLPricing" %>


<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="EntityDataSource1"
    DataTextField="detailsDescription" DataValueField="id">
</asp:DropDownList>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" 
    EntitySetName="PricingDetails">
</asp:EntityDataSource>