<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="PutAway.aspx.cs" Inherits="PutAway_PutAway" %>

<%@ Register Src="~/WebControl/getPutawayStatus.ascx" TagName="WebUserControlGetStatus"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, PutAwayNewTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Panel ID="searchPanel" runat="server">
        <asp:Label ID="LabelPutAwayNum" runat="server" Text="<%$ Resources:LanguagePack, PutAwayBoxNum %>"></asp:Label>
        <asp:TextBox ID="TextBoxPutAwayNum" runat="server"></asp:TextBox>
        <asp:Button ID="Button_search" runat="server" Text="<%$ Resources:LanguagePack, ButtonSearch %>"
            OnClick="Button_search_Click" />
        <br />
        <br />
    </asp:Panel>
    <asp:GridView ID="GridViewMatter" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
        DataSourceID="EntityDataSourceMatter" AllowPaging="True" PageSize="<%$ appSettings:GridViewPageSize %>"
        AllowSorting="True" OnRowCommand="GridViewMatter_RowCommand" EmptyDataText="<%$ Resources:LanguagePack, PutAwayNotData %>"
        OnRowCreated="GridViewMatter_RowCreated" RowStyle-CssClass="lineGridviewMaster"
        HeaderStyle-CssClass="lineGridviewMaster" CssClass="MasterWidth">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Text="To"
                        CommandName="CopyTo" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="matterNum" HeaderText="<%$ Resources:LanguagePack, MatterNew_matterNum %>" />
            <asp:DynamicField DataField="clientName" HeaderText="<%$ Resources:LanguagePack, MatterNew_clientName %>" />
            <asp:DynamicField DataField="matterSubject" HeaderText="<%$ Resources:LanguagePack, MatterNew_matterSubject %>" />
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, MatterNew_status %>" SortExpression="status">
                <ItemTemplate>
                    <uc1:WebUserControlGetStatus ID="ucGetStatus" runat="server" statudId='<%# Eval("status")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowSelectButton="True" SelectText="<%$ Resources:LanguagePack, PutAwayView %>"
                HeaderText="<%$ Resources:LanguagePack, MatterNew_action %>" ButtonType="Button" />
        </Columns>
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSourceMatter" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="View_FindMatter"
        Where="" OnSelecting="EntityDataSourceMatter_Selecting" EntityTypeFilter="" OnQueryCreated="EntityDataSourceMatter_QueryCreated"
        Select="">
    </asp:EntityDataSource>
</asp:Content>
