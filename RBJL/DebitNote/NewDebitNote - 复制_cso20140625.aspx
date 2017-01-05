<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="NewDebitNote.aspx.cs" Inherits="DebitNote_NewDebitNote" EnableEventValidation="false" %>

<%@ Register Src="~/WebControl/DebitNoteCostOrDisbursement.ascx" TagName="WebUserControlCostOrDisbursement"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/CalenderTextBoxWithValidation.ascx" TagName="WebUserControlCalenderTextBox"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/DDLOtherParties.ascx" TagName="WebUserControlDDLOtherPartiesDDl"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLUserName.ascx" TagName="WebUserControlLBLUserName"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="Debit Note" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <div class="Tab">
        <ajaxToolkit:TabContainer ID="TabContainerDebitNoteCore" runat="server" ActiveTabIndex="0">
            <ajaxToolkit:TabPanel ID="TabPanelDebitNoteGeneral" runat="server" HeaderText="General">
                <ContentTemplate>
                    <asp:Panel ID="PanelGeneral" runat="server">
                        <asp:UpdatePanel ID="updatepanel1" runat="server">
                            <ContentTemplate>
                                <table class="lineHeight">
                                    <tr>
                                        <td class="MWidth">
                                            <asp:Label ID="LabelMatterNum" runat="server" Text="Matter No:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LabelMatterNumValue" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelDebitNoteNum" runat="server" Text="Debit Note No.:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxDebitNoteNum" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelStartDate" runat="server" Text="Start Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <uc1:WebUserControlCalenderTextBox ID="ucTextBoxStartDate" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelEndDate" runat="server" Text="End Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <uc1:WebUserControlCalenderTextBox ID="ucTextBoxEndDate" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelCategory" runat="server" Text="Debit Note Type:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListCategory" runat="server">
                                                <asp:ListItem Text="Trademark" Value="Trademark" />
                                                <asp:ListItem Text="General" Value="General" />
                                                <asp:ListItem Text="Patent" Value="Patent" />
                                                <asp:ListItem Text="Notary Public" Value="Notary Public" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelSubjectType" runat="server" Text="Subject Type:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListSubjectType" runat="server" CssClass="dropdownlistWidth"
                                                AutoPostBack="true" OnSelectedIndexChanged="DropDownListSubjectType_SelectedIndexChanged">
                                                <asp:ListItem Text="Trademark" Value="1" />
                                                <asp:ListItem Text="General" Value="3" />
                                                <asp:ListItem Text="Patent" Value="2" />
                                                <asp:ListItem Text="Notary Public" Value="4" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Repeater ID="RepeaterTType" runat="server">
                                                <ItemTemplate>
                                                    <table id="TType" runat="server" class="lineHeight">
                                                        <tr>
                                                            <td class="MWidth">
                                                                <asp:HiddenField ID="HiddenFieldMatterId" runat="server" Value='<%# Bind("id") %>' />
                                                                <asp:Label ID="LabelTypeOfWork" runat="server" Text="Type Of Work:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListTypeOfWork" runat="server" CssClass="dropdownlistWidth"
                                                                    AutoPostBack="false">
                                                                    <asp:ListItem Text="[Not Set]" Value="-1"></asp:ListItem>
                                                                    <asp:ListItem Text="Advice" Value="Advice"></asp:ListItem>
                                                                    <asp:ListItem Text="Appeal to Court" Value="Appeal to Court"></asp:ListItem>
                                                                    <asp:ListItem Text="Application" Value="Application"></asp:ListItem>
                                                                    <asp:ListItem Text="Cancellation" Value="Cancellation"></asp:ListItem>
                                                                    <asp:ListItem Text="Invalidation" Value="Invalidation"></asp:ListItem>
                                                                    <asp:ListItem Text="Non-use Cancellation" Value="Non-use Cancellation"></asp:ListItem>
                                                                    <asp:ListItem Text="Opposition" Value="Opposition"></asp:ListItem>
                                                                    <asp:ListItem Text="Recordal" Value="Recordal"></asp:ListItem>
                                                                    <asp:ListItem Text="Recordal of Assignment" Value="Recordal of Assignment"></asp:ListItem>
                                                                    <asp:ListItem Text="Recordal of License" Value="Recordal of License"></asp:ListItem>
                                                                    <asp:ListItem Text="Reordal of Charge" Value="Reordal of Charge"></asp:ListItem>
                                                                    <asp:ListItem Text="Renewal" Value="Renewal"></asp:ListItem>
                                                                    <asp:ListItem Text="Review to TRAB" Value="Review to TRAB"></asp:ListItem>
                                                                    <asp:ListItem Text="Revocation" Value="Revocation"></asp:ListItem>
                                                                    <asp:ListItem Text="Search" Value="Search"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelOpponent" runat="server" Text="Opponent:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListOpponent" runat="server" CssClass="dropdownlistWidth"
                                                                    AutoPostBack="false">
                                                                    <asp:ListItem Text="[Not Set]" Value="-1"></asp:ListItem>
                                                                    <asp:ListItem Text="Appliant" Value="Appliant"></asp:ListItem>
                                                                    <asp:ListItem Text="Opponent" Value="Opponent"></asp:ListItem>
                                                                    <asp:ListItem Text="Assignor" Value="Assignor"></asp:ListItem>
                                                                    <asp:ListItem Text="Assignee" Value="Assignee"></asp:ListItem>
                                                                    <asp:ListItem Text="Licensor" Value="Licensor"></asp:ListItem>
                                                                    <asp:ListItem Text="Licensee" Value="Licensee"></asp:ListItem>
                                                                    <asp:ListItem Text="Chargor" Value="Chargor"></asp:ListItem>
                                                                    <asp:ListItem Text="Chargee" Value="Chargee"></asp:ListItem>
                                                                    <asp:ListItem Text="Respondent" Value="Respondent"></asp:ListItem>
                                                                    <asp:ListItem Text="Appellant" Value="Appellant"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxOpponent" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelRoleType" runat="server" Text="Role Type:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListRoleType" runat="server" CssClass="dropdownlistWidth"
                                                                    AutoPostBack="false">
                                                                    <asp:ListItem Text="Applicant" Value="Applicant"></asp:ListItem>
                                                                    <asp:ListItem Text="Proprieter" Value="Proprieter"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelNameOfClient" runat="server" Text="Name of Client:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxNameOfClient" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelTrademarkLogoDescription" runat="server" Text="Trademark Logo Description:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxTrademarkLogoDescription" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelTrademarkLogo" runat="server" Text="Trademark Logo:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Image ID="ImageTrademarkLogo" runat="server" />
                                                                <asp:HiddenField ID="HiddenFieldTrademarkLogo" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelTrademarkNum" runat="server" Text="Trademark No.:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxTrademarkNum" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelClass" runat="server" Text="Class:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxClass" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelCountry" runat="server" Text="Country:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListCountry" runat="server" CssClass="dropdownlistWidth"
                                                                    DataSourceID="EntityDataSourceCountry" DataTextField="countryName" DataValueField="countryName">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <asp:Repeater ID="RepeaterPDTpye" runat="server" Visible="false">
                                                <ItemTemplate>
                                                    <table id="PDTpye" runat="server" class="lineHeight">
                                                        <tr>
                                                            <td class="MWidth">
                                                                <asp:HiddenField ID="HiddenFieldMatterId" runat="server" Value='<%# Bind("id") %>' />
                                                                <asp:Label ID="LabelStage" runat="server" Text="Stage:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListStage" runat="server" CssClass="dropdownlistWidth"
                                                                    AutoPostBack="false">
                                                                    <asp:ListItem Text="[Not Set]" Value="-1"></asp:ListItem>
                                                                    <asp:ListItem Text="First Stage - Request to Record" Value="First Stage - Request to Record"></asp:ListItem>
                                                                    <asp:ListItem Text="Second Stage - Request for Registration and Grant" Value="Second Stage - Request for Registration and Grant">
                                                                    </asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelRoleProprietor" runat="server" Text="Role Proprietor / Applicant:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListRoleProprietor" runat="server" CssClass="dropdownlistWidth"
                                                                    AutoPostBack="false">
                                                                    <asp:ListItem Text="Proprietor" Value="Proprietor"></asp:ListItem>
                                                                    <asp:ListItem Text="Applicant" Value="Applicant">
                                                                    </asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxProprietorOrApplicantValue" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelAssignee" runat="server" Text="Assignee:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxAssignee" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelPNTitle" runat="server" Text="Title:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxPNTitle" runat="server" CssClass="textboxWidth"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelDesignPatentNum" runat="server" Text="Design / Patent No.:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListDesignPatentNum" runat="server" CssClass="dropdownlistWidth"
                                                                    AutoPostBack="false">
                                                                    <asp:ListItem Text="Design No." Value="Design No."></asp:ListItem>
                                                                    <asp:ListItem Text="Patent No." Value="Patent No."></asp:ListItem>
                                                                    <asp:ListItem Text="Design Application No." Value="Design Application No."></asp:ListItem>
                                                                    <asp:ListItem Text="Patent Application No." Value="Patent Application No."></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxDesignPatentNum" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelPDCountry" runat="server" Text="Country:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListPDCountry" runat="server" CssClass="dropdownlistWidth"
                                                                    DataSourceID="EntityDataSourceCountry" DataTextField="countryName" DataValueField="countryName">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="LabelNationalPhase" runat="server" Text="Priority:"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListNationalPhase" runat="server" CssClass="dropdownlistWidth"
                                                                    AutoPostBack="false">
                                                                    <asp:ListItem Text="[Not Set]" Value="-1"></asp:ListItem>
                                                                    <asp:ListItem Text="National Phase of" Value="National Phase of"></asp:ListItem>
                                                                    <asp:ListItem Text="Claming prioity from" Value="Claming prioity from"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBoxPriorityValue" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <table id="GOrNType" runat="server" visible="false" class="lineHeight">
                                                <tr>
                                                    <td class="MWidth">
                                                        <asp:Label ID="LabelSubject" runat="server" Text="Subject:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TextBoxSubject" runat="server" CssClass="textboxWidth"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelClient" runat="server" Text="Client:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LabelClientValue" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelAddress" runat="server" Text="Client Address:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListAddressClientAddress" runat="server" CssClass="dropdownlistWidth"
                                                AutoPostBack="True" OnSelectedIndexChanged="DropDownListAddressClientAddress_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelClientContactPerson" runat="server" Text="Client Contact Person:"></asp:Label>
                                        </td>
                                        <td>
                                            <%--                                    <asp:DropDownList ID="DropDownListClientContactPerson" runat="server" CssClass="dropdownlistWidth"
                                        AutoPostBack="True" OnSelectedIndexChanged="DropDownListClientContactPerson_SelectedIndexChanged">
                                    </asp:DropDownList>
                                            --%>
                                            <asp:UpdatePanel ID="updatepanelClientContactPerson" runat="server">
                                                <ContentTemplate>
                                                    <asp:PopupControlExtender ID="PopupControlExtendeClientContactPerson" runat="server"
                                                        Enabled="True" ExtenderControlID="" TargetControlID="TextBoxClientContactPerson"
                                                        PopupControlID="PanelClientContactPerson" OffsetY="22">
                                                    </asp:PopupControlExtender>
                                                    <asp:Panel ID="PanelClientContactPerson" runat="server" CssClass="multiDDLPanel"
                                                        BorderStyle="Solid" BorderWidth="2px" Direction="LeftToRight" ScrollBars="Auto"
                                                        BackColor="#FFFFFF" Style="display: none">
                                                        <asp:CheckBoxList ID="CheckBoxListClientContactPerson" runat="server" AutoPostBack="True"
                                                            OnSelectedIndexChanged="CheckBoxListClientContactPerson_SelectedIndexChanged">
                                                        </asp:CheckBoxList>
                                                    </asp:Panel>
                                                    <asp:TextBox ID="TextBoxClientContactPerson" runat="server" ReadOnly="true" Text=""
                                                        CssClass="multiDropdownlistWidth"></asp:TextBox>
                                                    <asp:Label ID="LabelDDL" runat="server" Text="<%$ Resources:LanguagePack, lblDDl %>"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelOtherParties" runat="server" Text="Other Parties:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListOtherParties" runat="server" CssClass="dropdownlistWidth"
                                                AutoPostBack="True" OnSelectedIndexChanged="DropDownListOtherParties_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelOtherPartiesAddress" runat="server" Text="Other Parties Address:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListOtherPartiesAddress" runat="server" CssClass="dropdownlistWidth"
                                                AutoPostBack="True" OnSelectedIndexChanged="DropDownListOtherPartiesAddress_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelOtherPartiesContactPerson" runat="server" Text="Other Parties Contact Person:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListOtherPartiesContactPerson" runat="server" CssClass="dropdownlistWidth"
                                                AutoPostBack="True" OnSelectedIndexChanged="DropDownListOtherPartiesContactPerson_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelReferer" runat="server" Text="<%$ Resources:LanguagePack, debitNotependinglist_Referer %>"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LabelRefererValue" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelRefererAddress" runat="server" Text="<%$ Resources:LanguagePack, debitNotependinglist_RefererAddress %>"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListRefererAddress" runat="server" CssClass="dropdownlistWidth"
                                                AutoPostBack="True" OnSelectedIndexChanged="DropDownListRefererAddress_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelRefererContactPerson" runat="server" Text="<%$ Resources:LanguagePack, debitNotependinglist_RefererContactperson %>"></asp:Label>
                                        </td>
                                        <td>
                                            <%--        <asp:DropDownList ID="DropDownListRefererContactperson" runat="server" CssClass="dropdownlistWidth"
                                        AutoPostBack="True" OnSelectedIndexChanged="DropDownListRefererContactperson_SelectedIndexChanged">
                                    </asp:DropDownList>
                                            --%>
                                            <asp:UpdatePanel ID="updatepanelRefererContactperson" runat="server">
                                                <ContentTemplate>
                                                    <asp:PopupControlExtender ID="PopupControlExtenderRefererContactperson" runat="server"
                                                        Enabled="True" ExtenderControlID="" TargetControlID="TextBoxRefererContactperson"
                                                        PopupControlID="PanelRefererContactperson" OffsetY="22">
                                                    </asp:PopupControlExtender>
                                                    <asp:Panel ID="PanelRefererContactperson" runat="server" CssClass="multiDDLPanel"
                                                        BorderStyle="Solid" BorderWidth="2px" Direction="LeftToRight" ScrollBars="Auto"
                                                        BackColor="#FFFFFF" Style="display: none">
                                                        <asp:CheckBoxList ID="CheckBoxListRefererContactperson" runat="server" AutoPostBack="True"
                                                            OnSelectedIndexChanged="CheckBoxListRefererContactperson_SelectedIndexChanged">
                                                        </asp:CheckBoxList>
                                                    </asp:Panel>
                                                    <asp:TextBox ID="TextBoxRefererContactperson" runat="server" ReadOnly="true" Text=""
                                                        CssClass="multiDropdownlistWidth"></asp:TextBox>
                                                    <asp:Label ID="LabelDDRC" runat="server" Text="<%$ Resources:LanguagePack, lblDDl %>"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelIsShowEmail" runat="server" Text="Show Contact Person Email:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="CheckBoxIsShowEmail" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelRef" runat="server" Text="Ref:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextRef" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelYourRef" runat="server" Text="Your Ref:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxYourRef" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelSubRef" runat="server" Text="Sub Ref:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxSubRef" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelIO" runat="server" Text="IO:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxIO" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelDeposit" runat="server" Text="Deposit of account:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxDeposit" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelStatus" runat="server" Text="Status:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LabelStatusValue" runat="server" Text="Pending"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelVersion" runat="server" Text="Version:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LabelVersionValue" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelAmendedBy" runat="server" Text="Amend By:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LabelAmendedByValue" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelAmendedDate" runat="server" Text="Amend Date:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="LabelAmendedDateValue" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelDebitNoteMode" runat="server" Text="Debit Note:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListDebitNoteMode" runat="server">
                                                <asp:ListItem Text="Interim Debit Note" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Renewal" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Maintenance Debit Note" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Final" Value="4"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelCost" runat="server" HeaderText="Cost">
                <ContentTemplate>
                    <asp:Panel ID="PanelCost" runat="server">
                        <uc1:WebUserControlCostOrDisbursement ID="wc1Cost" runat="server" type="Cost" />
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelDisbursement" runat="server" HeaderText="Disbursement">
                <ContentTemplate>
                    <asp:Panel ID="PanelDisbursement" runat="server">
                        <uc1:WebUserControlCostOrDisbursement ID="wcDisbursement" runat="server" type="Disbursement" />
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelAttachment" runat="server" HeaderText="Attachment">
                <ContentTemplate>
                    <asp:Panel ID="PanelAttachment" runat="server">
                        <table class="lineHeight">
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment1" runat="server" Text="Attachment 1 : "></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadAttachment1" runat="server" />
                                    <asp:Label ID="LabelUploadFile1" runat="server" Text=""></asp:Label>
                                    <asp:Button ID="ButtonUploadFile1" runat="server" Text="Delete" OnClick="ButtonUploadFile1_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment2" runat="server" Text="Attachment 2 : "></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadAttachment2" runat="server" />
                                    <asp:Label ID="LabelUploadFile2" runat="server" Text=""></asp:Label>
                                    <asp:Button ID="ButtonUploadFile2" runat="server" Text="Delete" OnClick="ButtonUploadFile2_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment3" runat="server" Text="Attachment 3 : "></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadAttachment3" runat="server" />
                                    <asp:Label ID="LabelUploadFile3" runat="server" Text=""></asp:Label>
                                    <asp:Button ID="ButtonUploadFile3" runat="server" Text="Delete" OnClick="ButtonUploadFile3_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment4" runat="server" Text="Attachment 4 : "></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadAttachment4" runat="server" />
                                    <asp:Label ID="LabelUploadFile4" runat="server" Text=""></asp:Label>
                                    <asp:Button ID="ButtonUploadFile4" runat="server" Text="Delete" OnClick="ButtonUploadFile4_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment5" runat="server" Text="Attachment 5 : "></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadAttachment5" runat="server" />
                                    <asp:Label ID="LabelUploadFile5" runat="server" Text=""></asp:Label>
                                    <asp:Button ID="ButtonUploadFile5" runat="server" Text="Delete" OnClick="ButtonUploadFile5_Click" />
                                </td>
                            </tr>
                        </table>
                        <%--<asp:Button ID="ButtonUpload" runat="server" Text="Upload" OnClick="ButtonUpload_Click" />--%>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelNarrative" runat="server" HeaderText="Narrative">
                <ContentTemplate>
                    <asp:Panel ID="PanelNarrative" runat="server">
                        <asp:GridView ID="GridViewTimeEnrty" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                            DataSourceID="EntityDataSourceTimeEnrty" RowStyle-CssClass="lineGridviewMaster"
                            HeaderStyle-CssClass="lineGridviewMaster" OnRowDataBound="GridViewTimeEnrty_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                    Visible="False" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckAll" runat="server" onclick="javascript: SelectAllCheckboxes(this);"
                                            Text="" ToolTip="SelectAll" CssClass="CheckAll" /></HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxTarEntry" CssClass="chk" runat="server" Text="" /></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckAllNoCount" runat="server" onclick="javascript: SelectAllCheckboxesNoCount(this);"
                                            Text="" ToolTip="SelectAllNoCount" CssClass="CheckAllNoCount" /></HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxTarEntryNoCount" CssClass="chkNoCount" runat="server" Text="" /></ItemTemplate>
                                </asp:TemplateField>
                                <asp:DynamicField DataField="itemNum" HeaderText="<%$ Resources:LanguagePack, Mattercore_itemNum %>">
                                </asp:DynamicField>
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
                                <asp:DynamicField DataField="billable" HeaderText="<%$ Resources:LanguagePack, Mattercore_billable %>">
                                </asp:DynamicField>
                                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_CountTotal %>">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelCountTotal" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
    <br />
    <br />
    <asp:Button ID="ButtonGeneralSubmit" runat="server" Text="Next" OnClick="ButtonGeneralSubmit_Click" />
    <asp:Button ID="ButtonCostNext" runat="server" Text="Next" OnClick="ButtonCostNext_Click"
        Visible="false" />
    <asp:Button ID="ButtonDisbursementNext" runat="server" Text="Next" OnClick="ButtonDisbursementNext_Click"
        Visible="false" />
    <asp:Button ID="ButtonNarrativeNext" runat="server" Text="Next" OnClick="ButtonNarrativeNext_Click"
        Visible="false" />
    <asp:Button ID="ButtonCreate" runat="server" Text="Create Debit Note" OnClick="ButtonCreate_Click"
        Visible="false" />
    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click"
        Visible="false" />
    <asp:HiddenField ID="HiddenFieldIsHasAtt" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderPrice" runat="server" TargetControlID="lnkPopup"
        PopupControlID="PanelPopupPrice" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <%--    <ext:Window ID="ModalPopupExtenderPrice" runat="server" Title="Debit Note" Icon="Application"
        Maximizable="true" Modal="true" Hidden="true" Width="<%$ appSettings:windWidthSize %>"
        Height="<%$ appSettings:windHeightSizeS %>">
        <Content>--%>
    <asp:Panel ID="PanelPopupPrice" runat="server" CssClass="newpopM radiusClass debitNotePopupWidth"
        Style="display: none;">
        <asp:Panel ID="panDrag" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitle" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteSubmitTotal %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/close.png" CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <div class="debitNotePriceClass">
            <asp:UpdatePanel ID="updatepanelPrice" runat="server">
                <ContentTemplate>
                    <asp:RadioButtonList ID="RadioButtonListPopupPrice" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="RadioButtonListPopupPrice_SelectedIndexChanged">
                        <asp:ListItem Text="Normal" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Discount" Value="1"></asp:ListItem>
                        <asp:ListItem Text="But Say" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:DropDownList ID="DropDownListCurrency" runat="server" DataSourceID="EntityDataSourceCurrency"
                        DataTextField="symbol" DataValueField="rateToHK" OnSelectedIndexChanged="DropDownListCurrency_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="LabelSumPriceTitle" runat="server" Text="Sum (discount):" Visible="false"></asp:Label>
                    <asp:Label ID="LabelSumPrice" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:HiddenField ID="HiddenFieldSumPrice" runat="server" />
                    <br />
                    <asp:Label ID="LabelSumNormalPriceTitle" runat="server" Text="Sum:"></asp:Label>
                    <asp:Label ID="LabelSumNormalPrice" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HiddenFieldSumNormalPrice" runat="server" />
                    <asp:HiddenField ID="HiddenFieldSumDisbursement" runat="server" />
                    <br />
                    <asp:TextBox ID="TextBoxButSayValue" runat="server" Enabled="false"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <asp:Button ID="ButtonPriceCreate" runat="server" Text="Create" OnClick="ButtonPriceCreate_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonPriceCannel" runat="server" Text="Cancel" OnClick="ButtonPriceCannel_Click" />
        </div>
    </asp:Panel>
    <%--        </Content>
    </ext:Window>--%>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderAtt" runat="server" TargetControlID="lnkPopup"
        PopupControlID="PanelPopupAtt" BackgroundCssClass="modalBackground" CancelControlID="btnCancelAtt"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PanelPopupAtt" runat="server" CssClass="newpopM radiusClass" Style="display: none;">
        <asp:Panel ID="panDragAtt" runat="server">
            <div class="panDragClass radiusClass">
                <asp:Label ID="LabelDoworkTitleAtt" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteConfirmAtt %>"
                    CssClass="LabelDoworkTitleClass"></asp:Label>
                <asp:ImageButton ID="btnCancelAtt" runat="server" ImageUrl="~/images/close.png" CssClass="btnCancelClass" />
            </div>
            <br />
        </asp:Panel>
        <asp:Label ID="LabelAttConfirm" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteConfirmAttContent %>"></asp:Label>
        <br />
        <br />
        <asp:Button ID="ButtonAttYes" runat="server" Text="<%$ Resources:LanguagePack, GeneralYes %>"
            OnClick="ButtonAttYes_Click" CausesValidation="false" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonAttNo" runat="server" Text="<%$ Resources:LanguagePack, GeneralNo %>"
            OnClick="ButtonAttNo_Click" CausesValidation="false" />
        <br />
        <br />
    </asp:Panel>
    <a id="lnkPopup" runat="server"></a>
    <asp:EntityDataSource ID="EntityDataSourceTimeEnrty" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="MatterDetails"
        OnSelecting="EntityDataSourceTimeEnrty_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceCurrency" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="CurrencyRates"
        Select="it.[rateToHK], it.[currencyName], it.[symbol]">
    </asp:EntityDataSource>
    <asp:CustomValidator ID="CustomValidatorChecking" runat="server" ErrorMessage="*"
        CssClass="warning" OnServerValidate="CustomValidatorChecking_ServerValidate"></asp:CustomValidator>
    <br />
    <table>
    </table>
    <asp:EntityDataSource ID="EntityDataSourceCountry" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="Countries"
        OrderBy="it.[countryName] ASC" Select="it.[countryName]">
    </asp:EntityDataSource>
</asp:Content>
