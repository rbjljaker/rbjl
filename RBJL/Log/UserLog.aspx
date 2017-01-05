<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="UserLog.aspx.cs" Inherits="Log_UserLog" %>

<%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, LoglblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Label ID="LabelDate" runat="server" Text="<%$ Resources:LanguagePack, LogLabelDate %>"></asp:Label>
    <asp:TextBox ID="TextBoxDate" runat="server"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="CalendarExtenderDate" runat="server" TargetControlID="TextBoxDate"
        Format="dd-MMM-yyyy">
    </ajaxToolkit:CalendarExtender>
    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderDate" runat="server"
        TargetControlID="TextBoxDate" WatermarkText="dd-Jan-YYYY">
    </ajaxToolkit:TextBoxWatermarkExtender>
    <asp:Label ID="LabelUserName" runat="server" Text="<%$ Resources:LanguagePack, LogLabelUserName %>"></asp:Label>
    <asp:DropDownList ID="DropDownListUserName" runat="server" DataSourceID="EntityDataSourceUserName"
        DataTextField="UserName" DataValueField="UserId">
    </asp:DropDownList>
    <asp:Button ID="Button_search" runat="server" Text="<%$ Resources:LanguagePack, ButtonSearch %>" OnClick="Button_search_Click" />
    <br />
    <asp:GridView ID="GridViewLog" runat="server" AutoGenerateColumns="false" OnDataBound="GridViewLog_DataBound"
        RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster"
        Width="445px" AllowPaging="true" PageSize="<%$ appSettings:GridViewPageSize %>" OnPageIndexChanging="GridViewLog_OnPageIndexChanging"
        PagerSettings-Visible="True">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="false" />
            <asp:BoundField DataField="date" HeaderText="<%$ Resources:LanguagePack, userlog_date %>" DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}"/>
            <asp:BoundField DataField="logDescription" HeaderText="<%$ Resources:LanguagePack, userlog_logDescription %>" />
        </Columns>
        <HeaderStyle CssClass="lineGridviewMaster"></HeaderStyle>
        <RowStyle CssClass="lineGridviewMaster"></RowStyle>
        <PagerTemplate>
            <uc:ucPaging ID="ucPaging" runat="server" />
        </PagerTemplate>
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSourceUserName" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="View_UserInfo"
        EntityTypeFilter="" OnSelecting="EntityDataSourceUserName_Selecting" OnQueryCreated="EntityDataSourceUserName_QueryCreated">
    </asp:EntityDataSource>
</asp:Content>
