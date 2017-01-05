<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="PutAway.aspx.cs" Inherits="Report_PutAway" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, putaway_lblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Table ID="TableLayout" runat="server" Height="108px" Width="747px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelDate" runat="server" Text="<%$ Resources:LanguagePack,putaway_lblDate %>"></asp:Label>
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
                <asp:Label ID="LabelDateTo" runat="server" Text="<%$ Resources:LanguagePack,putaway_lblDateTo %>"></asp:Label>
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
                <asp:Label ID="LabelFeeEarner" runat="server" Text="<%$ Resources:LanguagePack,putaway_LabelFeeEarner %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListFeeEarner" runat="server" OnSelectedIndexChanged="DropDownListFeeEarner_SelectedIndexChanged"
                    AutoPostBack="true" CssClass="DropdownCommon">
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelClient" runat="server" Text="<%$ Resources:LanguagePack,putaway_LabelClient %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList CssClass="DropdownCommon" ID="DropDownListClient" runat="server"
                    OnSelectedIndexChanged="DropDownListClient_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelMatterNo" runat="server" Text="<%$ Resources:LanguagePack,putaway_LabelMatterNo %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList CssClass="DropdownCommon" ID="DropDownListMatterNo" runat="server">
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelSubject" runat="server" Text="<%$ Resources:LanguagePack,putaway_LabelSubject %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListSubject" runat="server" AutoPostBack="true" CssClass="DropdownCommon"
                    OnSelectedIndexChanged="DropDownListSubject_SelectedIndexChanged">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelJobType" runat="server" Text="<%$ Resources:LanguagePack,putaway_LabelJobType %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList CssClass="DropdownCommon" ID="DropDownListJobType" runat="server"
                    OnSelectedIndexChanged="DropDownListJobType_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
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
</asp:Content>
