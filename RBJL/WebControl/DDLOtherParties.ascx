<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DDLOtherParties.ascx.cs" Inherits="WebControl_DDLOtherParties" %>


<asp:DropDownList ID="DropDownList1" runat="server" 
    DataSourceID="EntityDataSourceOtherParties" DataTextField="otherPartiesName" 
    DataValueField="id" CssClass="dropdownlistWidth" AppendDataBoundItems="true">
</asp:DropDownList>

<asp:EntityDataSource ID="EntityDataSourceOtherParties" runat="server" 
    ConnectionString="name=RBJLLawFirmDBEntities" 
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" 
    EntitySetName="OtherParties" Select="it.[id], it.[otherPartiesName]">
</asp:EntityDataSource>
