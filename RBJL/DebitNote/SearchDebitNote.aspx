<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true" CodeFile="SearchDebitNote.aspx.cs" Inherits="DebitNote_SearchDebitNote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" Runat="Server">

    <asp:GridView ID="GridViewDebitnote" runat="server" AutoGenerateColumns="False" 
        CaptionAlign="Right" DataKeyNames="id" 
        DataSourceID="EntityDataSourceDebitnotecore" 
        onrowcommand="GridViewDebitnote_RowCommand"
        RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                SortExpression="id"  Visible="false"/>
            <asp:BoundField DataField="debitNoteNum" HeaderText="debitNoteNum" 
                SortExpression="debitNoteNum" />
            <asp:BoundField DataField="matterNumId" HeaderText="matterNumId" 
                SortExpression="matterNumId" />
            <asp:BoundField DataField="debitNoteOther" HeaderText="debitNoteOther" 
                SortExpression="debitNoteOther"    Visible="false"/>
            <asp:BoundField DataField="debitNoteType" HeaderText="debitNoteType" 
                SortExpression="debitNoteType"    Visible="false"/>
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price"    Visible="false"/>
            <asp:CheckBoxField DataField="isDiscount" HeaderText="isDiscount" 
                SortExpression="isDiscount"   Visible="false"/>
            <asp:CheckBoxField DataField="isEnable" HeaderText="isEnable" 
                SortExpression="isEnable"   Visible="false"/>
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="View"
                 />

        </Columns>
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSourceDebitnotecore" runat="server" 
        ConnectionString="name=RBJLLawFirmDBEntities" 
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" 
        EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
        EntitySetName="DebitNoteCores">
    </asp:EntityDataSource>
</asp:Content>

