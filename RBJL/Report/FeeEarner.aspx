<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="FeeEarner.aspx.cs" Inherits="Report_FeeEarner" %>

<%@ Register Src="~/WebControl/MultiselectDropdownIntroducer.ascx" TagName="WebUserControlIntroducer"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, feeearner_lblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Table ID="TableLayout" runat="server" Height="108px" Width="747px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelDate" runat="server" Text="<%$ Resources:LanguagePack,feeearner_lblDate %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxDate" runat="server" OnTextChanged="TextBoxDate_TextChanged"
                    AutoPostBack="true"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtenderDate" runat="server" TargetControlID="TextBoxDate"
                    Format="dd-MMM-yyyy">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderDate" runat="server"
                    TargetControlID="TextBoxDate" WatermarkText="dd-Jan-YYYY">
                </ajaxToolkit:TextBoxWatermarkExtender>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelDateTo" runat="server" Text="<%$ Resources:LanguagePack,newmatterrecord_lblDateTo %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxDateTo" runat="server" OnTextChanged="TextBoxDateTo_TextChanged"
                    AutoPostBack="true"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtenderDateTo" runat="server" TargetControlID="TextBoxDateTo"
                    Format="dd-MMM-yyyy">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderDateTo" runat="server"
                    TargetControlID="TextBoxDateTo" WatermarkText="dd-Jan-YYYY">
                </ajaxToolkit:TextBoxWatermarkExtender>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelFeeEarner" runat="server" Text="<%$ Resources:LanguagePack,feeearner_LabelFeeEarner %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListFeeEarner" CssClass="DropdownCommon" runat="server"
                    OnSelectedIndexChanged="DropDownListFeeEarner_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelClient" runat="server" Text="<%$ Resources:LanguagePack,feeearner_LabelClient %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList CssClass="DropdownCommon" ID="DropDownListClient" runat="server"
                    OnSelectedIndexChanged="DropDownListClient_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelMatterNo" runat="server" Text="<%$ Resources:LanguagePack,feeearner_LabelMatterNo %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList CssClass="DropdownCommon" ID="DropDownListMatterNo" runat="server"
                    OnSelectedIndexChanged="DropDownListMatterNo_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelRefer" runat="server" Text="<%$ Resources:LanguagePack,feeearner_LabelRefer %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList CssClass="DropdownCommon" ID="DropDownListRefer" runat="server"
                    OnSelectedIndexChanged="DropDownListRefer_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelJobType" runat="server" Text="<%$ Resources:LanguagePack,feeearner_LabelJobType %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList CssClass="DropdownCommon" ID="DropDownListJobType" runat="server"
                    OnSelectedIndexChanged="DropDownListJobType_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Label ID="LabelOption" runat="server" CssClass="underLinkText" Text="<%$ Resources:LanguagePack, report_option %>"></asp:Label>
    <br />
    <table border="0" cellpadding="0" cellspacing="10" class="reportShow reportContentCenter">
        <tr>
            <td class="reportShowCheckBox">
                <asp:RadioButton ID="RadioButtonBillable" runat="server" Checked="true" GroupName="Options" />
                <%-- <asp:CheckBox ID="CheckBoxBillable" runat="server" Checked="true" />--%>
            </td>
            <td class="borderCommon reportFeeEarnerWidth">
                <asp:RadioButtonList ID="RadioButtonListBillable" runat="server">
                    <asp:ListItem Text="<%$ Resources:LanguagePack,report_bill %>" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:LanguagePack,report_unbill %>"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:LanguagePack,report_Both %>"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <%--            <td class="reportFeeEarnerWidth">
                &nbsp;
            </td>--%>
            <td class="reportShowCheckBox">
                <asp:RadioButton ID="RadioButtonNonBillable" runat="server" GroupName="Options" />
                <%--   <asp:CheckBox ID="CheckBoxDesciption" runat="server" Checked="true" />--%>
            </td>
            <td class="borderCommon reportFeeEarnerWidth">
                <div class="">
                    <%--<asp:Label runat="server" Text="<%$ Resources:LanguagePack,report_desciption %>"></asp:Label>--%>
                    <asp:Label ID="LabelNonBillable" runat="server" Text="<%$ Resources:LanguagePack,report_nonBillable %>"></asp:Label>
                </div>
            </td>
            <%--            <td class="reportFeeEarnerWidth">
                &nbsp;
            </td>--%>
            <td class="reportShowCheckBox">
                <asp:RadioButton ID="RadioButtonBoth" runat="server" GroupName="Options" />
                <%-- <asp:CheckBox ID="CheckBoxbill" runat="server" Checked="true" />--%>
            </td>
            <td class="borderCommon reportFeeEarnerWidth">
                <%--                <asp:RadioButtonList ID="RadioButtonListbill" runat="server">
                    <asp:ListItem Text="<%$ Resources:LanguagePack,report_bill %>" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:LanguagePack,report_Both %>"></asp:ListItem>
                </asp:RadioButtonList>--%>
                <asp:Label ID="LabelBoth" runat="server" Text="<%$ Resources:LanguagePack,report_Both %>"></asp:Label>
            </td>
        </tr>
    </table>
    <%--    <asp:Label ID="LabelPrintTo" runat="server" CssClass="underLinkText" Text="<%$ Resources:LanguagePack, print_PrintTo %>"></asp:Label>
    <br />
    <asp:RadioButtonList ID="RadioButtonListPrintTo" runat="server">
        <asp:ListItem Text="<%$ Resources:LanguagePack,print_onScreen %>"></asp:ListItem>
        <asp:ListItem Text="<%$ Resources:LanguagePack,print_pdf %>"></asp:ListItem>
        <asp:ListItem Text="<%$ Resources:LanguagePack,print_excel %>"></asp:ListItem>
    </asp:RadioButtonList>--%>
    <asp:Button ID="ButtonPrint" runat="server" Text="<%$ Resources:LanguagePack,lblPrint %>"
        OnClick="ButtonPrint_Click" />
    <asp:Button ID="ButtonCancel" runat="server" Text="<%$ Resources:LanguagePack,lblCancel %>"
        OnClick="ButtonCancel_Click" />
    <br />
    <br />
    <hr />
    <br />
    <asp:Panel ID="PanelFeeEarnerChart" runat="server">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:LanguagePack,chartTitle %>"></asp:Label>
        <br />
        <br />
        <asp:Table ID="TableAllMatterDate" runat="server" Width="747px" CssClass="lineHeight">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAllMatterDate" runat="server" Text="<%$ Resources:LanguagePack,agent_lblDate %>"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAllMatterDate" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderAllMatterDate" runat="server" TargetControlID="TextBoxAllMatterDate"
                        Format="dd-MMM-yyyy">
                    </ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderAllMatterDate"
                        runat="server" TargetControlID="TextBoxAllMatterDate" WatermarkText="dd-Jan-YYYY">
                    </ajaxToolkit:TextBoxWatermarkExtender>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LabelAllMatterDateTo" runat="server" Text="<%$ Resources:LanguagePack,agent_lblDateTo %>"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAllMatterDateTo" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderAllMatterDateTo" runat="server"
                        TargetControlID="TextBoxAllMatterDateTo" Format="dd-MMM-yyyy">
                    </ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderAllMatterDateTo"
                        runat="server" TargetControlID="TextBoxAllMatterDateTo" WatermarkText="dd-Jan-YYYY">
                    </ajaxToolkit:TextBoxWatermarkExtender>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="LabelFeeEarnerChart" runat="server" Text="<%$ Resources:LanguagePack,feeearner_LabelFeeEarner %>"></asp:Label>
        <uc1:WebUserControlIntroducer ID="MultiselectDropdownIntroducer" runat="server" type="FeeEarner" />
        <br />
        <br />
        <asp:Button ID="ButtonFeeEarnerChart" runat="server" Text="<%$ Resources:LanguagePack,feeEarnerViewChart %>"
            OnClick="ButtonFeeEarnerChart_Click" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
</asp:Content>
