<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="DebitNote.aspx.cs" Inherits="DebitNote_DebitNote" %>
    <%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, DebitNotelblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="LabelSearchMatterNum" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteSearchMatterNum %>"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxSearchMatterNum" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelDebitNoteNum" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteDebitNoteNum %>"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxDebitNoteNum" runat="server"></asp:TextBox>
                <asp:Button ID="Button_search" runat="server" Text="<%$ Resources:LanguagePack, ButtonSearch %>"
                    OnClick="Button_search_Click" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="GridVieDebitNoteCore" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="id" DataSourceID="EntityDataSourceDebitNoteCore" RowStyle-CssClass="lineGridviewMaster"
        HeaderStyle-CssClass="lineGridviewMaster" OnRowCommand="GridVieDebitNoteCore_RowCommand"
        EmptyDataText="<%$ Resources:LanguagePack, DebitNoteNotData %>" 
        PageSize="<%$ appSettings:GridViewPageSize %>" 
        ondatabound="GridVieDebitNoteCore_DataBound" 
        onselectedindexchanged="GridVieDebitNoteCore_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="false" />
            <asp:DynamicField DataField="MatterCore" HeaderText="<%$ Resources:LanguagePack, DebitNoteMatterCore %>" />
            <asp:DynamicField DataField="debitNoteNum" HeaderText="<%$ Resources:LanguagePack, DebitNoteDebitNoteNumH %>" />
            <asp:DynamicField DataField="Client" HeaderText="<%$ Resources:LanguagePack, DebitNoteClient %>" />
            <asp:DynamicField DataField="OtherParty" HeaderText="<%$ Resources:LanguagePack, DebitNoteOtherParty %>" />
            <asp:DynamicField DataField="Referer" HeaderText="<%$ Resources:LanguagePack, DebitNoteReferer %>" />
            <asp:DynamicField DataField="address" HeaderText="<%$ Resources:LanguagePack, DebitNoteAddress %>" />
            <asp:DynamicField DataField="category" HeaderText="<%$ Resources:LanguagePack, DebitNoteCategory %>" />
            <asp:DynamicField DataField="price" HeaderText="<%$ Resources:LanguagePack, DebitNotePrice %>" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="LinkButtonSelect" runat="server" CausesValidation="False" CommandName="Select"
                        Text="<%$ Resources:LanguagePack, lblSelect %>" CommandArgument='<%# Bind("id") %>'>
                    </asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
                <PagerTemplate>
            <uc:ucPaging ID="ucPaging" runat="server" />
        </PagerTemplate>
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSourceDebitNoteCore" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="DebitNoteCores" EntityTypeFilter=""
        OnSelecting="EntityDataSourceDebitNoteCore_Selecting" Select="" Where="">
    </asp:EntityDataSource>
</asp:Content>
