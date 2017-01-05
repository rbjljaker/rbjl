<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="PendingListTimeEntry.aspx.cs" Inherits="Matter_PendingListTimeEntry" %>

<%@ Register Src="~/WebControl/LBLUserName.ascx" TagName="WebUserControlLBLUserName"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, PendingListTimeEntryTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:GridView ID="GridViewMatterDetails" RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster"
        runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSourceMatterDetails"
        ShowFooter="True" OnRowCommand="GridViewMatterDetails_RowCommand">
        <SelectedRowStyle BackColor="LightGoldenrodYellow" ForeColor="DarkOrange" Font-Bold="true" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <%--           <asp:DynamicField DataField="itemNum" HeaderText="<%$ Resources:LanguagePack, Mattercore_itemNum %>">
            </asp:DynamicField>--%>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_itemNum %>">
                <ItemTemplate>
                    <asp:Label ID="LabelItemNum" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="date" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="<%$ Resources:LanguagePack, Mattercore_date %>">
            </asp:DynamicField>
            <asp:DynamicField DataField="description" HeaderText="<%$ Resources:LanguagePack, Mattercore_description %>">
            </asp:DynamicField>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_FeeEarner %>">
                <ItemTemplate>
                    <uc1:WebUserControlLBLUserName ID="ucLBLUserName" runat="server" userGuid='<%# Bind("feeEarner") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="timespan" HeaderText="<%$ Resources:LanguagePack, Mattercore_timespan %>">
            </asp:DynamicField>
            <asp:DynamicField DataField="fixedCost" HeaderText="<%$ Resources:LanguagePack, Mattercore_fixedCost %>">
            </asp:DynamicField>
            <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_WittenOff %>">
                <ItemTemplate>
                    <asp:Label ID="LabelWittenOff" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="billable" HeaderText="<%$ Resources:LanguagePack, Mattercore_billable %>">
            </asp:DynamicField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="LinkButtonSelect" runat="server" CausesValidation="False" CommandName="Select"
                        Text="<%$ Resources:LanguagePack, lblMoveToMatter %>" CommandArgument='<%# Bind("id") %>'>
                    </asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSourceMatterDetails" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="MatterDetails" OnSelecting="EntityDataSourceMatterDetails_Selecting">
    </asp:EntityDataSource>
</asp:Content>
