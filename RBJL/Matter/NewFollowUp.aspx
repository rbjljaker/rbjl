<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="NewFollowUp.aspx.cs" Inherits="Matter_NewFollowUp" %>

<%@ Register Src="~/WebControl/getMatterStatus.ascx" TagName="WebUserControlGetStatus"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/DDLTemplate.ascx" TagName="WebUserControlDDLTemplate"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLUserName.ascx" TagName="WebUserControlLBLUserName"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/DDLFeeEarner.ascx" TagName="WebUserControlDDLFeeEarner"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="uc" TagName="ucPaging" Src="~/WebControl/paging.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function checkingMultiple(sender, e) {
            var roundedNumber = Math.round(e.Value * 100);
            var integerNumber = parseInt(roundedNumber);
            if (integerNumber % 5 == 0)
                e.IsValid = true;
            else
                e.IsValid = false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, NewFollowUpTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Panel ID="PanelTimeEntryInsert" runat="server">
        <asp:UpdatePanel ID="updatepanel1" runat="server">
            <ContentTemplate>
                <div class="matterMaster">
                    <asp:Panel ID="PanelMatterDetails" runat="server" CssClass="floatL timeEntryPanel">
                        <asp:HiddenField ID="HiddenFieldTimeStart" runat="server" />
                        <asp:HiddenField ID="HiddenFieldTimeEnd" runat="server" />
                        <table class="lineHeight">
                            <%--                            <tr>
                                <td>
                                    <asp:Label ID="LabelMatterNumTitle" runat="server" Text="Matter No:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LabelMatterNum" runat="server" Text="!!"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelItemNo" runat="server" Text="Item No:"></asp:Label>
                                </td>
                                </td>
                                <td>
                                    <%--<asp:TextBox ID="TextBoxItemNo" runat="server"></asp:TextBox>--%>
                                    <asp:Label ID="LabelBoxItemNoValue" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelDate" runat="server" Text="Date:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderDate" runat="server" TargetControlID="TextBoxDate"
                                        Format="dd-MMM-yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderDate" runat="server"
                                        TargetControlID="TextBoxDate" WatermarkText="dd-Jan-YYYY">
                                    </ajaxToolkit:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ErrorMessage="*"
                                        CssClass="warning" ControlToValidate="TextBoxDate">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelFeeEarnerTitle" runat="server" Text="Fee Earner:"></asp:Label>
                                </td>
                                <td>
                                    <uc1:WebUserControlDDLFeeEarner ID="ucDDLFeeEarner" runat="server" />
                                </td>
                            </tr>
                            <%--                            <tr>
                                <td>
                                    <asp:Label ID="LabelOtherFeeEarnerTitle" runat="server" Text="Other Fee Earner:"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelTimeSpent" runat="server" Text="Time Spent:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxTimeSpent" runat="server" OnTextChanged="TextBoxTimeSpent_TextChanged"
                                        AutoPostBack="true">
                                    </asp:TextBox>
                                    <asp:CustomValidator ID="CustomValidatorTimeSpent" runat="server" ErrorMessage="*"
                                        CssClass="warning" ClientValidationFunction="checkingMultiple" ControlToValidate="TextBoxTimeSpent"></asp:CustomValidator>
                                    <%--                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTimeSpent" runat="server" ErrorMessage="*"
                                        CssClass="warning" ControlToValidate="TextBoxTimeSpent">
                                    </asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelFixedCost" runat="server" Text="Fixed Cost:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxFixedCost" runat="server" OnTextChanged="TextBoxFixedCost_TextChanged"
                                        AutoPostBack="true">
                                    </asp:TextBox>
                                    <%--                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorFixedCost" runat="server" ErrorMessage="*"
                                        CssClass="warning" ControlToValidate="TextBoxFixedCost">
                                    </asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelFixedCostTimeSpent" runat="server" Text="Fixed Cost Time Spent:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxFixedCostTimeSpent" runat="server" OnTextChanged="TextBoxFixedCostTimeSpent_TextChanged"
                                        AutoPostBack="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr id="setBillable" class="displayNone" runat="server">
                                <td>
                                    <asp:Label ID="LabelBillable" runat="server" Text="Billable:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxBillable" runat="server">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelStatus" runat="server" Text="Status:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LabelStatusValue" runat="server" Text="Pending"></asp:Label>
                                    <%--<uc1:WebUserControlGetStatus ID="ucGetStatus1" runat="server" />--%>
                                    <%--            <br />
            <asp:CheckBox ID="CheckBoxCopyTo" runat="server" Text="CopyTo" />
            <br />
            <asp:CheckBox ID="CheckBoxMoveTo" runat="server" Text="MoveTo" />
                                    --%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelIsBilled" runat="server" Text="Billable:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListIsBilled" runat="server">
                                        <asp:ListItem Text="Yes" Value="T"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="F"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelDescription" runat="server" Text="Description:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" Rows="8">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelTemplate" runat="server" Text="Template:"></asp:Label>
                                </td>
                                <td>
                                    <%-- <uc1:WebUserControlDDLTemplate ID="ucDllTemplate" runat="server" />--%>
                                    <asp:DropDownList ID="DropDownListTemplateCore" runat="server" DataSourceID="EntityDataSourceTemplateCore"
                                        DataTextField="typeName" DataValueField="id" OnSelectedIndexChanged="DropDownListTemplateCore_SelectedIndexChanged"
                                        AutoPostBack="true" CssClass="DDLWidth">
                                    </asp:DropDownList>
                                    <asp:EntityDataSource ID="EntityDataSourceTemplateCore" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
                                        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="TemplateTypes">
                                    </asp:EntityDataSource>
                                    <%--                                    <asp:DropDownList ID="DropDownListTemplateCore" runat="server" CssClass="DDLWidth">
                                    </asp:DropDownList>
                                    <ajaxToolkit:CascadingDropDown ID="ajaxDDLTemplateCore" runat="server" TargetControlID="DropDownListTemplateCore"
                                        LoadingText="Loading..." ServicePath="~/ServiceDDL.asmx" ServiceMethod="GetTemplateCore"
                                        Category="id">
                                    </ajaxToolkit:CascadingDropDown>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="DropDownListTemplateDetails" runat="server" CssClass="DDLWidth"
                                                    OnSelectedIndexChanged="DropDownListTemplateDetails_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                                <%--                                                <ajaxToolkit:CascadingDropDown ID="ajaxDDLTemplateDetails" runat="server" TargetControlID="DropDownListTemplateDetails"
                                                    ParentControlID="DropDownListTemplateCore" LoadingText="Loading..." ServicePath="~/ServiceDDL.asmx"
                                                    ServiceMethod="GetTemplateDetails" Category="id">
                                                </ajaxToolkit:CascadingDropDown>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <div class="timerMaster floatL">
                        <div class="floatL">
                            <asp:Label ID="LabelStartTitle" runat="server" Text="Timer Start" />
                            <div class="timer">
                                <span class="time" id="timeId" runat="server">00:00:00</span>
                            </div>
                        </div>
                        <div class="floatR">
                            <asp:Label ID="LabelStopTitle" runat="server" Text="Timer Stop" />
                            <div class="timer">
                                <span class="timeStop" id="timeStop" runat="server">00:00:00</span>
                            </div>
                        </div>
                        <div class="timeControl headerRMaster">
                            <div class="headerRB">
                                <asp:ImageButton ID="ImageButtonStart" runat="server" ImageUrl="~/images/__btn_play.png"
                                    OnClick="ImageButtonStart_Click" CausesValidation="false"></asp:ImageButton>
                                <asp:ImageButton ID="ImageButtonPause" runat="server" ImageUrl="~/images/__btn_pause_hover.png"
                                    OnClick="ImageButtonPause_Click" CausesValidation="false"></asp:ImageButton>
                                <asp:ImageButton ID="ImageButtonStop" runat="server" ImageUrl="~/images/__btn_stop_hover.png"
                                    OnClick="ImageButtonStop_Click" CausesValidation="false"></asp:ImageButton>
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="clear">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="ButtonRun" runat="server" Text="Create" OnClick="ButtonRun_Click" />
        <%--OnClientClick='<%$ Resources:LanguagePack,AddConfirm %>'--%>
        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click"
            Visible="false" OnClientClick='<%$ Resources:LanguagePack,UpdateConfirm %>' />
        <asp:Button ID="ButtonCancel" runat="server" Text="<%$ Resources:LanguagePack,lblCancel %>"
            OnClick="ButtonCancel_Click" CausesValidation="false" />
        <br />
        <asp:Button ID="LinkButtonCopyTo" Visible="false" OnClick="LinkButtonCopyTo_OnClick"
            runat="server" Text="CopyTo" CausesValidation="false" />
        <br />
        <asp:Button ID="LinkButtonMoveTo" Visible="false" OnClick="LinkButtonMoveTo_OnClick"
            runat="server" Text="MoveTo" CausesValidation="false" />
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="gvMD" runat="server">
        <asp:Button ID="ButtonMultiMove" runat="server" Text="Move To" OnClick="ButtonMultiMove_Click" />
        <br />
        <br />
        <asp:GridView ID="GridViewMatterDetails" RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster"
            runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSourceMatterDetails"
            ShowFooter="True" OnRowCommand="GridViewMatterDetails_RowCommand" OnRowDataBound="GridViewMatterDetails_RowDataBound"
            OnRowDeleted="GridViewMatterDetails_RowDeleted" OnDataBound="GridViewMatterDetails_DataBound"
            AllowPaging="True" PageSize="<%$ appSettings:GridViewPageSize %>">
            <SelectedRowStyle BackColor="LightGoldenrodYellow" ForeColor="DarkOrange" Font-Bold="true" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="CheckBoxAllCopyOrMove" runat="server" onclick="javascript: SelectAllCopyOrMove(this);"
                            class="CheckBoxAllCopyOrMove" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxCopyOrMove" CssClass="CheckBoxCopyOrMove" runat="server" Text="" /></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_itemNum %>">
                    <ItemTemplate>
                        <asp:Label ID="LabelItemNum" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:DynamicField DataField="date" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="<%$ Resources:LanguagePack, Mattercore_date %>">
                </asp:DynamicField>
                <%--                <asp:DynamicField DataField="description" HeaderText="<%$ Resources:LanguagePack, Mattercore_description %>">
                </asp:DynamicField>--%>
                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_description %>">
                    <ItemTemplate>
                        <asp:Label ID="LabelMatterDescription" runat="server" Text='<%# showString(Eval("description"))%>'
                            title='<%# Eval("description")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
                <asp:TemplateField HeaderStyle-Width="200">
                    <ItemTemplate>
                        <asp:Button ID="ButtonEditMatter" runat="server" CausesValidation="False" CommandName="Select"
                            Text="<%$ Resources:LanguagePack, lblEdit %>" CommandArgument='<%# Bind("id") %>'>
                        </asp:Button>
                        <asp:Button ID="LinkButtonSelect" runat="server" CausesValidation="False" CommandName="EditMatter"
                            Text="<%$ Resources:LanguagePack, lblMoveToMatter %>" CommandArgument='<%# Bind("id") %>'>
                        </asp:Button>
                        <asp:Button ID="LinkButtonDelete" runat="server" CausesValidation="False" CommandName="Delete"
                            CommandArgument='<%# Eval("id")%>' Text="<%$ Resources:LanguagePack, lblDelete %>"
                            OnClientClick="<%$ Resources:LanguagePack, DeleteConfirm %>"></asp:Button>
                        </asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
                <uc:ucPaging ID="ucPaging" runat="server" />
            </PagerTemplate>
        </asp:GridView>
        <asp:EntityDataSource ID="EntityDataSourceMatterDetails" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
            DefaultContainerName="RBJLLawFirmDBEntities" EnableDelete="True" EnableFlattening="False"
            EnableInsert="True" EnableUpdate="True" EntitySetName="MatterDetails" OnSelecting="EntityDataSourceMatterDetails_Selecting">
        </asp:EntityDataSource>
    </asp:Panel>
    <asp:CustomValidator ID="CustomValidatorTimeSpentAndFixedCost" runat="server" ErrorMessage="*"
        CssClass="warning" OnServerValidate="CustomValidatorTimeSpentAndFixedCost_ServerValidate"></asp:CustomValidator>
</asp:Content>
