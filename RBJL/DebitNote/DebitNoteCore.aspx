<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="DebitNoteCore.aspx.cs" Inherits="DebitNote_DebitNoteCore" %>

<%@ Register Src="~/WebControl/LBLUserName.ascx" TagName="WebUserControlLBLUserName"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/lblDebitNoteStatus.ascx" TagName="WebUserControlLBLDebitNoteStatus"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteCoreTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <div class="Tab">
        <ajaxToolkit:TabContainer ID="TabContainerDebitNoteCore" runat="server" ActiveTabIndex="0">
            <ajaxToolkit:TabPanel ID="TabPanelDebitNoteGeneral" runat="server" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreTab1 %>">
                <ContentTemplate>
                    <asp:Panel ID="PanelGeneral" runat="server">
                        <asp:DetailsView ID="DetailsViewDebitNoteCore" runat="server" CssClass="lineHeight"
                            AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourceDebitNoteCore"
                            OnItemUpdated="DetailsViewDebitNoteCore_ItemUpdated" OnItemUpdating="DetailsViewDebitNoteCore_ItemUpdating">
                            <Fields>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                    Visible="False" />
                                <asp:DynamicField DataField="MatterCore" HeaderText="Matter Num:" ReadOnly="True" />
                                <asp:TemplateField HeaderText="Debit Note Num:">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelDebitNoteNum" runat="server" Text='<%# Eval("debitNoteNum") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <% if (mI.userLevel == EnumUserLevel.administrator)
                                           { %>
                                        <asp:TextBox ID="TextBoxDebitNoteNum" runat="server" Text='<%# Bind("debitNoteNum") %>'></asp:TextBox>
                                        <% }
                                           else
                                           {
                                        %>
                                        <asp:Label ID="LabelDebitNoteNum" runat="server" Text='<%# Eval("debitNoteNum") %>'></asp:Label>
                                        <% }
                                        %>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:DynamicField DataField="startDate" HeaderText="Start Date:" DataFormatString="{0:dd-MMM-yyyy}"
                                    ReadOnly="True" />
                                <asp:DynamicField DataField="endDate" HeaderText="End Date:" DataFormatString="{0:dd-MMM-yyyy}"
                                    ReadOnly="True" />
                                <asp:DynamicField DataField="subject" HeaderText="Subject:" />
                                <asp:DynamicField DataField="category" HeaderText="Debit Note Type:" ReadOnly="True" />
                                <asp:DynamicField DataField="Client" HeaderText="Client:" ReadOnly="True" />
                                <asp:DynamicField DataField="OtherParty" HeaderText="OtherParty:" ReadOnly="True" />
                                <asp:DynamicField DataField="Referer" HeaderText="Referer:" ReadOnly="True" />
                                <asp:DynamicField DataField="address" HeaderText="Address:" ReadOnly="True" />
                                <asp:DynamicField DataField="ref" HeaderText="Ref:" />
                                <asp:DynamicField DataField="yourRef" HeaderText="Your Ref:" />
                                <asp:DynamicField DataField="price" HeaderText="Price:" ReadOnly="True" />
                                <asp:DynamicField DataField="version" HeaderText="Version:" ReadOnly="True" />
                                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreDebitNote %>">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelDebitNoteType" runat="server" Text='<%# setDebitNoteStatus(Eval("debitNoteType")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreAmendedBy %>">
                                    <ItemTemplate>
                                        <uc1:WebUserControlLBLUserName ID="ucLBLUserName" runat="server" userGuid='<%# Bind("UpdateByUserId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:DynamicField DataField="UpdateDate" HeaderText="UpdateDate" ReadOnly="True"
                                    DataFormatString="{0:dd-MMM-yyyy HH:mm:ss}" />
                                <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                            </Fields>
                        </asp:DetailsView>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelCost" runat="server" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreCostTab2 %>">
                <ContentTemplate>
                    <asp:Panel ID="PanelCost" runat="server">
                        <asp:GridView ID="GridViewDebitNoteCost" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="id" DataSourceID="EntityDataSourceDebitNoteCost" RowStyle-CssClass="lineGridviewMaster"
                            HeaderStyle-CssClass="lineGridviewMaster" CssClass="MasterWidth">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                    Visible="False" />
                                <asp:DynamicField DataField="debitNoteId" HeaderText="debitNoteId" Visible="False" />
                                <asp:DynamicField DataField="templateType" HeaderText="templateType" Visible="False" />
                                <asp:DynamicField DataField="templateDetails" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreTemplateDetails %>" />
                                <asp:DynamicField DataField="description" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreDescription %>" />
                                <asp:DynamicField DataField="cost" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreCost %>" />
                                <asp:DynamicField DataField="remark" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreRemark %>"
                                    Visible="false" />
                            </Columns>
                        </asp:GridView>
                        <asp:CheckBox ID="mustShowHeader" runat="server" Text="Must show header" />
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelMisc" runat="server" HeaderText="Misc">
                <ContentTemplate>
                    <asp:Panel ID="PanelMisc" runat="server">
                        <asp:GridView ID="GridViewNoteMisc" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="id" DataSourceID="EntityDataSourceDebitNoteMisc" RowStyle-CssClass="lineGridviewMaster"
                            HeaderStyle-CssClass="lineGridviewMaster" CssClass="MasterWidth">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                    Visible="False" />
                                <asp:DynamicField DataField="debitNoteId" HeaderText="debitNoteId" Visible="False" />
                                <asp:DynamicField DataField="templateType" HeaderText="templateType" Visible="False" />
                                <asp:DynamicField DataField="templateDetails" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreTemplateDetails %>" />
                                <asp:DynamicField DataField="description" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreDescription %>" />
                                <asp:DynamicField DataField="cost" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreCost %>" />
                                <asp:DynamicField DataField="remark" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreRemark %>"
                                    Visible="false" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelDisbursement" runat="server" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreDisbursementTab3 %>">
                <ContentTemplate>
                    <asp:Panel ID="PanelDisbursement" runat="server">
                        <asp:GridView ID="GridViewNoteDisursement" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="id" DataSourceID="EntityDataSourceDebitNoteDisursement" RowStyle-CssClass="lineGridviewMaster"
                            HeaderStyle-CssClass="lineGridviewMaster" CssClass="MasterWidth">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                    Visible="False" />
                                <asp:DynamicField DataField="debitNoteId" HeaderText="debitNoteId" Visible="False" />
                                <asp:DynamicField DataField="templateType" HeaderText="templateType" Visible="False" />
                                <asp:DynamicField DataField="templateDetails" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreTemplateDetails %>" />
                                <asp:DynamicField DataField="description" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreDescription %>" />
                                <asp:DynamicField DataField="cost" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreCost %>" />
                                <asp:DynamicField DataField="remark" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreRemark %>"
                                    Visible="false" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelAttachment" runat="server" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreAttachmentTab5 %>">
                <ContentTemplate>
                    <asp:Panel ID="PanelAttachmentview" runat="server">
                        <table class="lineHeight">
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment1view" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteCoreAttachment1 %>"></asp:Label>
                                    <asp:HyperLink ID="HyperLinkAttachment1" runat="server"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment2view" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteCoreAttachment2 %>"></asp:Label>
                                    <asp:HyperLink ID="HyperLinkAttachment2" runat="server"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment3view" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteCoreAttachment3 %>"></asp:Label>
                                    <asp:HyperLink ID="HyperLinkAttachment3" runat="server"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment4view" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteCoreAttachment4 %>"></asp:Label>
                                    <asp:HyperLink ID="HyperLinkAttachment4" runat="server"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelAttachment5view" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteCoreAttachment5 %>"></asp:Label>
                                    <asp:HyperLink ID="HyperLinkAttachment5" runat="server"></asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                        <%--<asp:Button ID="ButtonUpload" runat="server" Text="Upload" OnClick="ButtonUpload_Click" />--%>
                        <asp:Button ID="ButtonEditAtt" runat="server" Text="<%$ Resources:LanguagePack, lblEdit %>"
                            OnClick="ButtonEditAtt_Click" />
                    </asp:Panel>
                    <asp:Panel ID="PanelAttEdit" runat="server" Visible="false">
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
                        <asp:Button ID="ButtonAttUpdate" runat="server" Text="<%$ Resources:LanguagePack, lblUpdate %>"
                            OnClick="ButtonAttUpdate_Click" />
                        <asp:Button ID="ButtonAttBack" runat="server" Text="<%$ Resources:LanguagePack, BottomButtonCancel %>"
                            OnClick="ButtonAttBack_Click" />
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanelNarrative" runat="server" HeaderText="<%$ Resources:LanguagePack, DebitNoteCoreNarrativeTab4 %>">
                <ContentTemplate>
                    <asp:Panel ID="PanelNarrative" runat="server">
                        <asp:GridView ID="GridViewDebitNoteNarrative" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="id" DataSourceID="EntityDataSourceDebitNoteNarrative" RowStyle-CssClass="lineGridviewMaster"
                            HeaderStyle-CssClass="lineGridviewMaster">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                                    Visible="False" />
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
                                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_WittenOff %>">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelWittenOff" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:DynamicField DataField="billable" HeaderText="<%$ Resources:LanguagePack, Mattercore_billable %>">
                                </asp:DynamicField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
        <asp:Button ID="ButtonViewReport" runat="server" Text="View Report" OnClick="ButtonViewReport_Click" />
            <br /><br>
        <asp:Button ID="ButtonViewReport2" runat="server" Text="View Report with header" OnClick="ButtonViewReport2_Click" />
                    <br />
    <br />
    <asp:Button ID="ButtonExcel" runat="server" Text="Export Excel" OnClick="ButtonExcel_Click" />
    <br />
    <br />
    <asp:Button ID="ButtonDebitNoteDelete" runat="server" Text="<%$ Resources:LanguagePack, DebitNoteCoreDelete %>"
        OnClientClick="<%$ Resources:LanguagePack, DeleteConfirm %>" OnClick="ButtonDebitNoteDelete_Click" />
    <br />
    <br />
    <br />
    <asp:HiddenField ID="HiddenFieldMatterNum" runat="server" />
    <asp:HiddenField ID="HiddenFieldDebitNoteType" runat="server" />
    <asp:EntityDataSource ID="EntityDataSourceDebitNoteCore" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableUpdate="True"
        EntitySetName="DebitNoteCores" OnSelecting="EntityDataSourceDebitNoteCore_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceDebitNoteCost" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableUpdate="True"
        EntitySetName="DebitNoteCosts" OnSelecting="EntityDataSourceDebitNoteCost_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceDebitNoteMisc" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableUpdate="True"
        EntitySetName="DebitNoteMiscs" OnSelecting="EntityDataSourceDebitNoteDisursement_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceDebitNoteDisursement" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableUpdate="True"
        EntitySetName="DebitNoteDisbursements" OnSelecting="EntityDataSourceDebitNoteDisursement_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceDebitNoteNarrative" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="DebitNoteNarratives"
        OnSelecting="EntityDataSourceDebitNoteNarrative_Selecting">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EntityDataSourceDebitNoteAttachment" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableUpdate="True"
        EntitySetName="DebitNoteAttachments" OnSelecting="EntityDataSourceDebitNoteAttachment_Selecting">
    </asp:EntityDataSource>
</asp:Content>
