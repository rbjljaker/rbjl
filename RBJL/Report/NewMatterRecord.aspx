<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="NewMatterRecord.aspx.cs" Inherits="Report_NewMatterRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, newmatterrecord_lblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Table ID="TableLayout" runat="server" Height="108px" Width="747px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelDate" runat="server" Text="<%$ Resources:LanguagePack,newmatterrecord_lblDate %>"></asp:Label>
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
                <asp:Label ID="LabelFeeEarner" runat="server" Text="<%$ Resources:LanguagePack,newmatterrecord_LabelFeeEarner %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <%--<asp:TextBox ID="TextBoxFeeEarner" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="DropDownListFeeEarner" runat="server" OnSelectedIndexChanged="DropDownListFeeEarner_SelectedIndexChanged"
                    AutoPostBack="true" CssClass="DropdownCommon">
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelMatterNo" runat="server" Text="<%$ Resources:LanguagePack,newmatterrecord_LabelMatterNo %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListMatterNo" runat="server" CssClass="DropdownCommon"
                    OnSelectedIndexChanged="DropDownListMatterNo_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelSubject" runat="server" Text="<%$ Resources:LanguagePack,newmatterrecord_LabelSubject %>">
                </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <%--    <asp:TextBox ID="TextBoxSubject" runat="server">
                </asp:TextBox>--%>
                <asp:DropDownList ID="DropDownListSubject" runat="server" AutoPostBack="true" CssClass="DropdownCommon"
                    OnSelectedIndexChanged="DropDownListSubject_SelectedIndexChanged">
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelClient" runat="server" Text="<%$ Resources:LanguagePack,newmatterrecord_LabelClient %>">
                </asp:Label></asp:TableCell>
            <asp:TableCell>
                <%--                <asp:TextBox ID="TextBoxClient" runat="server">
                </asp:TextBox>--%>
                <asp:DropDownList ID="DropDownListClient" runat="server" AutoPostBack="true" CssClass="DropdownCommon"
                    OnSelectedIndexChanged="DropDownListClient_SelectedIndexChanged">
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
    <asp:Panel ID="PanelAllMatter" runat="server">
        <br />
        <br />
        <hr />
        <br />
        <asp:Label ID="LabelAllMatter" runat="server" Text="<%$ Resources:LanguagePack,CurrentMattersLabelAllMatter %>"></asp:Label>
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
        <asp:Button ID="ButtonAllMatter" runat="server" Text="<%$ Resources:LanguagePack,lblMatterExport %>"
            OnClick="ButtonAllMatter_Click" />
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
