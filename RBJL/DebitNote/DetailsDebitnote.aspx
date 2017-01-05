<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="DetailsDebitnote.aspx.cs" Inherits="DebitNote_DetailsDebitnote" %>

<%@ Register Src="~/WebControl/DebitNoteCostOrDisbursement.ascx" TagName="WebUserControlCostOrDisbursement"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/CalenderTextBox.ascx" TagName="WebUserControlCalenderTextBox"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/DDLOtherParties.ascx" TagName="WebUserControlDDLOtherPartiesDDl"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLUserName.ascx" TagName="WebUserControlLBLUserName"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../Scripts/checkBoxSelect.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="Debit Note Details" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <div id="divedit" runat="server" class="Tab">
        <ajaxToolkit:TabContainer ID="TabContainerDebitNoteCore" runat="server" ActiveTabIndex="0">
            <ajaxToolkit:TabPanel ID="TabPanelDebitNoteGeneral" runat="server" HeaderText="General">
                <ContentTemplate>
                    <asp:Panel ID="PanelGeneral" runat="server">
                        <asp:Label ID="LabelDebitNoteNum" runat="server" Text="Debit Note No.:"></asp:Label>
                        <asp:TextBox ID="TextBoxDebitNoteNum" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelStartDate" runat="server" Text="Start Date:"></asp:Label>
                        <uc1:WebUserControlCalenderTextBox ID="ucTextBoxStartDate" runat="server" />
                        <br />
                        <asp:Label ID="LabelEndDate" runat="server" Text="End Date:"></asp:Label>
                        <uc1:WebUserControlCalenderTextBox ID="ucTextBoxEndDate" runat="server" />
                        <br />
                        <asp:Label ID="LabelClient" runat="server" Text="Client:"></asp:Label>
                        <asp:Label ID="LabelClientValue" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelOtherParties" runat="server" Text="Other Parties:"></asp:Label>
                        <uc1:WebUserControlDDLOtherPartiesDDl ID="ucDDLOtherParties" runat="server" />
                        <br />
                        <asp:Label ID="LabelReferer" runat="server" Text="Referer:"></asp:Label>
                        <asp:Label ID="LabelRefererValue" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelAddress" runat="server" Text="Address:"></asp:Label>
                        <asp:DropDownList ID="DropDownListAddress" runat="server">
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="LabelRef" runat="server" Text="Ref:"></asp:Label>
                        <asp:TextBox ID="TextRef" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelYourRef" runat="server" Text="Your Ref:"></asp:Label>
                        <asp:TextBox ID="TextBoxYourRef" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelStatus" runat="server" Text="Status:"></asp:Label>
                        <asp:Label ID="LabelStatusValue" runat="server" Text="Pannding"></asp:Label>
                        <br />
                        <asp:Label ID="LabelVersion" runat="server" Text="Version:"></asp:Label>
                        <asp:Label ID="LabelVersionValue" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelAmendedBy" runat="server" Text="Amend By:"></asp:Label>
                        <asp:Label ID="LabelAmendedByValue" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelAmendedDate" runat="server" Text="Amend Date:"></asp:Label>
                        <asp:Label ID="LabelAmendedDateValue" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelMatterNum" runat="server" Text="Matter No:"></asp:Label>
                        <asp:Label ID="LabelMatterNumValue" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelDebitNoteMode" runat="server" Text="Debit Note:"></asp:Label>
                        <asp:DropDownList ID="DropDownListDebitNoteMode" runat="server">
                            <asp:ListItem Text="Interim Debit Note" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Renewal" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Maintenance Debit Note" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Final" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Button ID="ButtonGeneralSubmit" runat="server" Text="Next" OnClick="ButtonGeneralSubmit_Click" />
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelCost" runat="server" HeaderText="Cost">
                <ContentTemplate>
                    <asp:Panel ID="PanelCost" runat="server">
                        <asp:GridView ID="GridViewcostedit" runat="server" AlternatingRowStyle-VerticalAlign="NotSet"
                            DataSourceID="EntityDataSourceCost" OnRowUpdated="GridViewcostedit_RowUpdated"
                            DataKeyNames="id" AutoGenerateColumns="False">
                            <Columns>
                                <asp:CommandField ShowEditButton="True" />
                                <asp:BoundField DataField="id" Visible="false" HeaderText="id" />
                                <asp:BoundField DataField="description" HeaderText="description" />
                                <asp:BoundField DataField="cost" HeaderText="cost" ReadOnly="true" />
                                <asp:BoundField DataField="remark" HeaderText="remark" ReadOnly="true" />
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="ButtonCostNext" runat="server" Text="Next" OnClick="ButtonCostNext_Click" />
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelDisbursement" runat="server" HeaderText="Disbursement">
                <ContentTemplate>
                    <asp:Panel ID="PanelDisbursement" runat="server">
                        <asp:GridView ID="GridViewDisbursementedit" runat="server" AlternatingRowStyle-VerticalAlign="NotSet"
                            DataSourceID="EntityDataSourceDisbursement" DataKeyNames="id" AutoGenerateColumns="False">
                            <Columns>
                                <asp:CommandField ShowEditButton="True" />
                                <asp:BoundField DataField="id" Visible="false" HeaderText="id" />
                                <asp:BoundField DataField="description" HeaderText="description" />
                                <asp:BoundField DataField="cost" HeaderText="cost" ReadOnly="true" />
                                <asp:BoundField DataField="remark" HeaderText="remark" ReadOnly="true" />
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="ButtonDisbursementNext" runat="server" Text="Next" OnClick="ButtonDisbursementNext_Click" />
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelNarrative" runat="server" HeaderText="Narrative">
                <ContentTemplate>
                    <asp:Panel ID="PanelNarrative" runat="server">
                        <asp:GridView ID="GridViewNarrativeedit" runat="server" AlternatingRowStyle-VerticalAlign="NotSet"
                            DataSourceID="EntityDataSourceNarrative" DataKeyNames="id" AutoGenerateColumns="False">
                            <Columns>
                                <asp:CommandField ShowEditButton="True" />
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                    Visible="False" />
                                <asp:BoundField DataField="itemNum" HeaderText="itemNum" ReadOnly="true"></asp:BoundField>
                                <asp:BoundField DataField="date" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="date"
                                    ReadOnly="true"></asp:BoundField>
                                <asp:BoundField DataField="description" HeaderText="description"></asp:BoundField>
                                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_FeeEarner %>">
                                    <ItemTemplate>
                                        <uc1:WebUserControlLBLUserName ID="ucLBLUserName" runat="server" userGuid='<%# Bind("feeEarner") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="timespan" HeaderText="timespan" ReadOnly="true"></asp:BoundField>
                                <asp:BoundField DataField="fixedCost" HeaderText="fixedCost" ReadOnly="true"></asp:BoundField>
                                <asp:BoundField DataField="billable" HeaderText="billable" ReadOnly="true"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <%--                        <asp:GridView ID="GridViewTimeEnrty" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                            DataSourceID="EntityDataSourceNarrative">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                    Visible="False" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckAll" runat="server" onclick="javascript: SelectAllCheckboxes(this);"
                                            Text="SelectAll" ToolTip="SelectAll" CssClass="CheckAll" /></HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxTarEntry" CssClass="chk" runat="server" Text="" /></ItemTemplate>
                                </asp:TemplateField>
                                <asp:DynamicField DataField="itemNum" HeaderText="itemNum"></asp:DynamicField>
                                <asp:DynamicField DataField="date" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="date">
                                </asp:DynamicField>
                                <asp:DynamicField DataField="description" HeaderText="description"></asp:DynamicField>
                                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_FeeEarner %>">
                                    <ItemTemplate>
                                        <uc1:WebUserControlLBLUserName ID="ucLBLUserName" runat="server" userGuid='<%# Bind("feeEarner") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:DynamicField DataField="timespan" HeaderText="timespan"></asp:DynamicField>
                                <asp:DynamicField DataField="fixedCost" HeaderText="fixedCost"></asp:DynamicField>
                                <asp:DynamicField DataField="billable" HeaderText="billable"></asp:DynamicField>
                            </Columns>
                        </asp:GridView>
                        --%>
                    </asp:Panel>
                    <asp:Button ID="ButtonNarrativeNext" runat="server" Text="Next" OnClick="ButtonNarrativeNext_Click" />
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
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment2" runat="server" Text="Attachment 2 : "></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadAttachment2" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment3" runat="server" Text="Attachment 3 : "></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadAttachment3" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment4" runat="server" Text="Attachment 4 : "></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadAttachment4" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment5" runat="server" Text="Attachment 5 : "></asp:Label>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUploadAttachment5" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <%--<asp:Button ID="ButtonUpload" runat="server" Text="Upload" OnClick="ButtonUpload_Click" />--%>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
    <br />
    <br />
    <asp:Button ID="ButtonCreate" runat="server" Text="Save" OnClick="ButtonCreate_Click"
        Visible="false" />
    <br />
    <br />
    <div id="divview" class="Tab" runat="server">
        <ajaxToolkit:TabContainer ID="TabContainerDebitNoteCoreview" runat="server" ActiveTabIndex="3">
            <ajaxToolkit:TabPanel ID="TabPanelDebitNoteGeneralview" runat="server" HeaderText="General">
                <ContentTemplate>
                    <asp:Panel ID="PanelGeneralview" runat="server">
                        <asp:Label ID="LabelDebitNoteNumview" runat="server" Text="Debit Note No.:"></asp:Label>
                        <asp:Label ID="LabelDebitNoteNumvalueview" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelStartDateview" runat="server" Text="Start Date:"></asp:Label>
                        <asp:Label ID="LabelStartDatevalueview" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelEndDateview" runat="server" Text="End Date:"></asp:Label>
                        <asp:Label ID="LabelEndDatevalueview" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelClientview" runat="server" Text="Client:"></asp:Label>
                        <asp:Label ID="LabelClientValueview" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelOtherPartiesview" runat="server" Text="Other Parties:"></asp:Label>
                        <asp:Label ID="LabelOtherPartiesvalueview" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelRefererview" runat="server" Text="Referer:"></asp:Label>
                        <asp:Label ID="LabelRefererValueview" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelAddressview" runat="server" Text="Address:"></asp:Label>
                        <asp:Label ID="LabelAddressvalueview" runat="server" Text="Address:"></asp:Label>
                        <br />
                        <asp:Label ID="LabelRefview" runat="server" Text="Ref:"></asp:Label>
                        <asp:Label ID="LabelRefvalueview" runat="server" Text="Ref:"></asp:Label>
                        <br />
                        <asp:Label ID="LabelYourRefview" runat="server" Text="Your Ref:"></asp:Label>
                        <asp:Label ID="LabelYourRefvalueview" runat="server" Text="Your Ref:"></asp:Label>
                        <br />
                        <asp:Label ID="LabelStatusview" runat="server" Text="Status:"></asp:Label>
                        <asp:Label ID="LabelStatusValueview" runat="server" Text="Pannding"></asp:Label>
                        <br />
                        <asp:Label ID="LabelVersionview" runat="server" Text="Version:"></asp:Label>
                        <asp:Label ID="LabelVersionValueview" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelAmendedByview" runat="server" Text="Amend By:"></asp:Label>
                        <asp:Label ID="LabelAmendedByValueview" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelAmendedDateview" runat="server" Text="Amend Date:"></asp:Label>
                        <asp:Label ID="LabelAmendedDateValueview" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelMatterNumview" runat="server" Text="Matter No:"></asp:Label>
                        <asp:Label ID="LabelMatterNumValueview" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LabelDebitNoteModeview" runat="server" Text="Debit Note:"></asp:Label>
                        <asp:Label ID="LabelDebitNoteModevalueview" runat="server" Text="Debit Note:"></asp:Label>
                        <br />
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelCostview" runat="server" HeaderText="Cost">
                <ContentTemplate>
                    <asp:Panel ID="PanelCostview" runat="server">
                        <%--                    <table>
                    <tr>
                    <td>
            <asp:Label ID="LabelCostTemplate" runat="server" Text="Template:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LabelCostTemplatevalue" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelCostDescription" runat="server" Text="Description:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LabelCostDescriptionvalue" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelCost" runat="server" Text="Cost:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LabelCostvalue" runat="server" Text=""></asp:Label>
         </td>
    </tr>
    <tr id="isRemark" runat="server">
        <td>
            <asp:Label ID="LabelRemark" runat="server" Text="Remark:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LabelRemarkValue" runat="server" Text=""></asp:Label>
        </td> 
</tr>
        </table>
                        --%>
                        <asp:GridView ID="GridViewcost" runat="server" AlternatingRowStyle-VerticalAlign="NotSet"
                            AutoGenerateSelectButton="False" DataSourceID="EntityDataSourceCost">
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelDisbursementview" runat="server" HeaderText="Disbursement">
                <ContentTemplate>
                    <asp:Panel ID="PanelDisbursementview" runat="server">
                        <%--                    <table>
                    <tr>
                    <td>
            <asp:Label ID="LabelDisbursementTemplate" runat="server" Text="Template:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LabelDisbursementTemplatevalue" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelDisbursementDescription" runat="server" Text="Description:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LabelDisbursementDescriptionvalue" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelDisbursementCost" runat="server" Text="Cost:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LabelDisbursementCostvalue" runat="server" Text=""></asp:Label>
         </td>
    </tr>
        </table>
                        --%>
                        <asp:GridView ID="GridViewDisbursement" runat="server" DataSourceID="EntityDataSourceDisbursement">
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelNarrativeview" runat="server" HeaderText="Narrative">
                <ContentTemplate>
                    <asp:Panel ID="PanelNarrativeview" runat="server">
                        <asp:GridView ID="GridViewNarrative" runat="server" DataKeyNames="id" DataSourceID="EntityDataSourceNarrative"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                    Visible="False" />
                                <asp:BoundField DataField="itemNum" HeaderText="itemNum" />
                                <asp:BoundField DataField="date" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="date" />
                                <asp:BoundField DataField="description" HeaderText="description" />
                                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_FeeEarner %>">
                                    <ItemTemplate>
                                        <uc1:WebUserControlLBLUserName ID="ucLBLUserName" runat="server" userGuid='<%# Bind("feeEarner") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="timespan" HeaderText="timespan" />
                                <asp:BoundField DataField="fixedCost" HeaderText="fixedCost" />
                                <asp:BoundField DataField="billable" HeaderText="billable" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelAttachmentview" runat="server" HeaderText="Attachment">
                <ContentTemplate>
                    <asp:Panel ID="PanelAttachmentview" runat="server">
                        <table class="lineHeight">
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment1view" runat="server" Text="Attachment 1 : "></asp:Label>
                                    <asp:HyperLink ID="HyperLinkAttachment1" runat="server"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment2view" runat="server" Text="Attachment 2 : "></asp:Label>
                                    <asp:HyperLink ID="HyperLinkAttachment2" NavigateUrl="~/Attachment/1000000000/3/20130718_117426_image_Status_page.zip"
                                        runat="server"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment3view" runat="server" Text="Attachment 3 : "></asp:Label>
                                    <asp:HyperLink ID="HyperLinkAttachment3" NavigateUrl="~/Attachment/1000000000/3/20130718_117426_image_Status_page.zip"
                                        runat="server"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment4view" runat="server" Text="Attachment 4 : "></asp:Label>
                                    <asp:HyperLink ID="HyperLinkAttachment4" NavigateUrl="~/Attachment/1000000000/3/20130718_117426_image_Status_page.zip"
                                        runat="server"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment5view" runat="server" Text="Attachment 5 : "></asp:Label>
                                    <asp:HyperLink ID="HyperLinkAttachment5" NavigateUrl="~/Attachment/1000000000/3/20130718_117426_image_Status_page.zip"
                                        runat="server"></asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                        <%--<asp:Button ID="ButtonUpload" runat="server" Text="Upload" OnClick="ButtonUpload_Click" />--%>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
    <br />
    <br />
    <asp:Button ID="Buttonedit" runat="server" Text="EDIT" OnClick="Buttonedit_Click" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderPrice" runat="server" TargetControlID="lnkPopup"
        PopupControlID="PanelPopupPrice" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"
        PopupDragHandleControlID="">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PanelPopupPrice" runat="server" CssClass="ModalWindowDebitNote panAddDebitNote">
        <div class="debitNotePriceClass">
            <asp:UpdatePanel ID="updatepanelPrice" runat="server">
                <ContentTemplate>
                    <asp:RadioButtonList ID="RadioButtonListPopupPrice" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="RadioButtonListPopupPrice_SelectedIndexChanged">
                        <asp:ListItem Text="Discount" Value="1"></asp:ListItem>
                        <asp:ListItem Text="But Say" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="LabelSumPriceTitle" runat="server" Text="Sum:"></asp:Label>
                    <asp:Label ID="LabelSumPrice" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="TextBoxButSayValue" runat="server" Enabled="false"></asp:TextBox>
                    <br />
                    &nbsp;&nbsp;&nbsp;
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="displayNone" />
    </asp:Panel>
    <a id="lnkPopup" runat="server"></a>
    <asp:EntityDataSource ID="EntityDataSourceTimeEnrty" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="MatterDetails"
        OnSelecting="EntityDataSourceTimeEnrty_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceNarrative" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="DebitNoteNarratives" OnSelecting="EntityDataSourceNarrative_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceCost" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="DebitNoteCosts" OnSelecting="EntityDataSourceCost_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceDisbursement" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
        EnableInsert="True" EnableUpdate="True" EntitySetName="DebitNoteDisbursements"
        OnSelecting="EntityDataSourceDisbursement_Selecting">
    </asp:EntityDataSource>
</asp:Content>
