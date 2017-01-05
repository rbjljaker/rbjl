<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MultiselectDropdownWithHourlyRate.ascx.cs"
    Inherits="WebControl_MultiselectDropdownWithHourlyRate" %>
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
        <br />
        <asp:Repeater ID="RepeaterHourlyRate" runat="server">
            <HeaderTemplate>
                <span class="addMatter">
                    <table class="repTH">
            </HeaderTemplate>
            <ItemTemplate>
                <asp:UpdatePanel ID="up2" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <tr>
                            <td class="repT">
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("userId") %>' />
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("userName") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxHourlyRate" runat="server" OnTextChanged="TextBoxHourlyRate_TextChanged"
                                    AutoPostBack="true" Text='<%# Eval("hourRate") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxHourlyRate" runat="server"
                                    ErrorMessage="*" CssClass="warning" ControlToValidate="TextBoxHourlyRate"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TextBoxHourlyRate" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </ItemTemplate>
            <FooterTemplate>
                </table> </span>
            </FooterTemplate>
        </asp:Repeater>
        <asp:HiddenField ID="HiddenFieldSaveValue" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="LFUsers"
    EntityTypeFilter="" OrderBy="it.nickName Asc" Select="" OnSelecting="EntityDataSource1_Selecting">
</asp:EntityDataSource>
