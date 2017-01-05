<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="New.aspx.cs" Inherits="Matter_New" %>

<%@ Register Src="~/WebControl/getMatterStatus.ascx" TagName="WebUserControlGetStatus"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLUserName.ascx" TagName="WebUserControlLBLUserName"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, MatterNewTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Button ID="ButtonNewMatter" runat="server" Text="New Matter" OnClick="ButtonNewMatter_Click"
        Visible="false" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="HyperLinkNewFollowUp" runat="server" OnClick="HyperLinkNewFollowUp_OnClick"
        Text="<%$ Resources:LanguagePack, MatterNewFollowUp %>"></asp:Button>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="ButtonDraftTimeEntry" runat="server" Text="<%$ Resources:LanguagePack, MatterNewPedingEntry %>"
        OnClick="ButtonDraftTimeEntry_Click" Visible="false" />
    <br />
    <br />
    <div class="welcomePartB">
        <asp:Panel ID="PanelSearch" runat="server">
            <asp:Label ID="LabelSearch" runat="server" Text=""></asp:Label>
        </asp:Panel>
        <br />
        <asp:Panel ID="PanelMoveOrCopyMatter" runat="server" Visible="false" DefaultButton="ButtonMoveOrCopyMatter">
            <asp:Label ID="LabelMoveOrCopyMatter" runat="server" Text="<%$ Resources:LanguagePack, MatterMoveOrCopyText %>"></asp:Label>
            <asp:TextBox ID="TextBoxMoveOrCopyMatter" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonMoveOrCopyMatter" runat="server" Text="Submit" OnClick="ButtonMoveOrCopyMatter_Click" />
            <br />
            <br />
        </asp:Panel>
        <asp:GridView ID="GridViewMatter" RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster"
            runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSourceMatter"
            AllowPaging="True" PageSize="<%$ appSettings:GridViewPageSize %>" AllowSorting="True"
            OnRowCommand="GridViewMatter_RowCommand" EmptyDataText="<%$ Resources:LanguagePack, MatterNotData %>"
            OnRowCreated="GridViewMatter_RowCreated" CssClass="MasterWidth" OnDataBound="GridViewMatter_DataBound">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" Text="To" CommandName="CopyTo"
                            CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:DynamicField DataField="matterNum" HeaderText="<%$ Resources:LanguagePack, MatterNew_matterNum %>" />--%>
                <asp:TemplateField HeaderText='<%$ Resources:LanguagePack, MatterNew_matterNum %>'
                    SortExpression="matterNum">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonMatterNum" runat="server" Text='<%# Bind("matterNum") %>'
                            CommandArgument='<%# Bind("id") %>' CommandName="MatterNum"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:DynamicField DataField="clientName" HeaderText="<%$ Resources:LanguagePack, MatterNew_clientName %>" />--%>
                <asp:TemplateField HeaderText='<%$ Resources:LanguagePack, MatterNew_clientName %>'
                    SortExpression="clientName">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonClientName" runat="server" Text='<%# Bind("clientName") %>'
                            CommandArgument='<%# Bind("id") %>' CommandName="Client"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:DynamicField DataField="matterSubject" HeaderText="<%$ Resources:LanguagePack, MatterNew_matterSubject %>" />--%>
                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, MatterNew_matterSubject %>"
                    SortExpression="matterSubject">
                    <ItemTemplate>
                        <asp:Label ID="LabelMatterSubject" runat="server" Text='<%# showString(Eval("matterSubject"))%>'
                            title='<%# Eval("matterSubject")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, MatterNew_status %>" SortExpression="status">
                    <ItemTemplate>
                        <uc1:WebUserControlGetStatus ID="ucGetStatus" runat="server" statudId='<%# Eval("status")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, MatterNewUpdateByName %>"
                    SortExpression="UpdateByUserId">
                    <ItemTemplate>
                        <uc1:WebUserControlLBLUserName ID="ucGetUserName" runat="server" userGuid='<%# Eval("UpdateByUserId")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:DynamicField DataField="UpdateDate" ReadOnly="true" HeaderText="<%$ Resources:LanguagePack, MatterNewUpdateDate %>"
                    DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="<%$ Resources:LanguagePack, MatterNewAddFollowUp %>"
                    HeaderText="<%$ Resources:LanguagePack, MatterNew_action %>" />
            </Columns>
            <PagerTemplate>
                <uc:ucPaging ID="ucPaging" runat="server" />
            </PagerTemplate>
        </asp:GridView>
        <br />
    </div>
    <br />
    <br />
    <%--<br />
<asp:Button ID="LinkButtonCopyFrom" runat="server" Text="Copy From" OnClick="LinkButtonCopyFrom_onclick"  CausesValidation="false"  />
    --%>
    <asp:EntityDataSource ID="EntityDataSourceMatter" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="View_FindMatter"
        OnSelecting="EntityDataSourceMatter_Selecting" OnQueryCreated="EntityDataSourceMatter_QueryCreated"
        OrderBy="it.matterNum ASC">
    </asp:EntityDataSource>
    <%--    <asp:EntityDataSource ID="EntityDataSourceMatterCopy" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="View_FindMatter"
        Where="" OnSelecting="" EntityTypeFilter="" OnQueryCreated="EntityDataSourceMatter_QueryCreated"
        Select="">
    </asp:EntityDataSource>--%>
</asp:Content>
