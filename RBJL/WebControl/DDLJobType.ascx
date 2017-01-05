<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DDLJobType.ascx.cs" Inherits="WebControl_DDLJobType" %>


<asp:DropDownList ID="DropDownList1" runat="server" 
    DataSourceID="EntityDataSource1" DataTextField="name" DataValueField="num">
</asp:DropDownList>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" 
    ConnectionString="name=RBJLLawFirmDBEntities" 
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" 
    EntitySetName="JobTypes" Select="it.[name], it.[num]">
</asp:EntityDataSource>
