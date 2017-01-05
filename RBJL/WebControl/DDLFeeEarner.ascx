<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DDLFeeEarner.ascx.cs"
    Inherits="WebControl_DDLFeeEarner" %>

<asp:DropDownList ID="DropDownList1" runat="server" 
    DataSourceID="EntityDataSource1" DataTextField="nickName" 
    DataValueField="userid">
</asp:DropDownList>


<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="LFUsers"
    EntityTypeFilter="" OrderBy="it.nickName Asc" Select="" OnSelecting="EntityDataSource1_Selecting">
</asp:EntityDataSource>