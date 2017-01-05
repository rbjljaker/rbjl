<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DDLReferer.ascx.cs" Inherits="WebControl_DDLReferer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel ID="updatepanel1" runat="server">
    <ContentTemplate>
        <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged"
            AutoPostBack="true" Visible="false" /><asp:DropDownList ID="DropDownList1" runat="server"
                DataSourceID="EntityDataSource1" DataTextField="refererName" DataValueField="id"
                CssClass="dropdownlistWidth">
            </asp:DropDownList>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="Referers"
    OnQueryCreated="EntityDataSource1_QueryCreated">
</asp:EntityDataSource>
