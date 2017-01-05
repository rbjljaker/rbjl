<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MultiselectDropdown.ascx.cs"
    Inherits="WebControl_MultiselectDropdown" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel ID="updatepanel1" runat="server">
    <ContentTemplate>
        <asp:PopupControlExtender ID="TextBox1_PopupControlExtender" runat="server" Enabled="True"
            ExtenderControlID="" TargetControlID="TextBox1" PopupControlID="Panel1" OffsetY="22">
        </asp:PopupControlExtender>
        <asp:Panel ID="Panel1" runat="server" CssClass="multiDDLPanel" BorderStyle="Solid"
            BorderWidth="2px" Direction="LeftToRight" ScrollBars="Auto" BackColor="#FFFFFF"
            Style="display: none">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="EntityDataSource1"
                DataTextField="nickName" DataValueField="userid" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
            </asp:CheckBoxList>
        </asp:Panel>
        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" Text='<%# setValue() %>'
            CssClass="multiDropdownlistWidth"></asp:TextBox>
        <asp:Label ID="LabelDDL" runat="server" Text="<%$ Resources:LanguagePack, lblDDl %>"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
            ControlToValidate="TextBox1" CssClass="warning"></asp:RequiredFieldValidator>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="LFUsers"
    EntityTypeFilter="" OrderBy="it.nickName Asc" Select="" OnSelecting="EntityDataSource1_Selecting">
</asp:EntityDataSource>
