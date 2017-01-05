<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="DebitNote.aspx.cs" Inherits="Report_DebitNote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, debitnote_lblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Table ID="TableLayout" runat="server" Height="108px" Width="747px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelDate" runat="server" Text="<%$ Resources:LanguagePack,debitnote_lblDate %>"></asp:Label>
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
                <asp:Label ID="LabelFeeEarner" runat="server" Text="<%$ Resources:LanguagePack,debitnote_LabelFeeEarner %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListFeeEarner" runat="server" OnSelectedIndexChanged="DropDownListFeeEarner_SelectedIndexChanged"
                    AutoPostBack="true" CssClass="DropdownCommon">
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelMatterNo" runat="server" Text="<%$ Resources:LanguagePack,debitnote_LabelMatterNo %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListMatterNo" runat="server" CssClass="DropdownCommon"
                    AutoPostBack="true" OnSelectedIndexChanged="DropDownListMatterNo_SelectedIndexChanged">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelSubject" runat="server" Text="<%$ Resources:LanguagePack,debitnote_LabelSubject %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListSubject" runat="server" CssClass="DropdownCommon"
                    AutoPostBack="true" OnSelectedIndexChanged="DropDownListSubject_SelectedIndexChanged">
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelState" runat="server" Text="<%$ Resources:LanguagePack,debitnote_LabelState %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="DropDownListState" runat="server" CssClass="DropdownCommon"
                    AutoPostBack="true" OnSelectedIndexChanged="DropDownListState_SelectedIndexChanged">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <%--    <asp:CheckBoxList ID="CheckBoxListType" runat="server" CssClass="CheckBoxListD">
        <asp:ListItem Text="<%$ Resources:LanguagePack,debitnote_Type_Draft %>" Selected="true"></asp:ListItem>
        <asp:ListItem Text="<%$ Resources:LanguagePack,debitnote_Type_Trademark %>" class="SearchItemD"></asp:ListItem>
        <asp:ListItem Text="<%$ Resources:LanguagePack,debitnote_Type_General %>" class="SearchItemD"></asp:ListItem>
        <asp:ListItem Text="<%$ Resources:LanguagePack,debitnote_Type_Patent %>" class="SearchItemD"></asp:ListItem>
        <asp:ListItem Text="<%$ Resources:LanguagePack,debitnote_Type_NotanyPublic %>" class="SearchItemD"></asp:ListItem>
        <asp:ListItem Text="<%$ Resources:LanguagePack,debitnote_Type_CompletSet %>" class="SearchDAll"
            onclick="javascript: SelectAllTypeD(this);"></asp:ListItem>
        <asp:ListItem Text="<%$ Resources:LanguagePack,debitnote_Type_Language %>"></asp:ListItem>
    </asp:CheckBoxList>--%>
    <table class="MasterWidth">
        <tr class="ReportTable">
            <td>
                <asp:Label ID="LabelType" runat="server" Text="<%$ Resources:LanguagePack, debitnote_Type_title %>"></asp:Label>
            </td>
            <td class="displayNone">
                <asp:Label ID="LabelCategory" runat="server" Text="<%$ Resources:LanguagePack, debitnote_TypeCategory %>"></asp:Label>
            </td>
            <td class="displayNone">
                <asp:Label ID="LabelLanguage" runat="server" Text="<%$ Resources:LanguagePack, debitnote_TypeLanguage %>"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RadioButtonTypeDraft" runat="server" GroupName="Tpye" Text="<%$ Resources:LanguagePack,debitnote_Type_Draft %>"
                    Checked="true" />
                <br />
                <asp:RadioButton ID="RadioButtonTypeCompletSet" runat="server" GroupName="Tpye" Text="<%$ Resources:LanguagePack,debitnote_Type_CompletSet %>" />
            </td>
            <td class="displayNone">
                <asp:CheckBoxList ID="CheckBoxListType" runat="server" CssClass="CheckBoxListD">
                    <asp:ListItem Text="<%$ Resources:LanguagePack,debitnote_Type_Trademark %>"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:LanguagePack,debitnote_Type_General %>"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:LanguagePack,debitnote_Type_Patent %>"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:LanguagePack,debitnote_Type_NotanyPublic %>"></asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td class="displayNone">
            </td>
        </tr>
    </table>
    <%--<asp:CustomValidator ID="CustomValidatorCheckBoxList" runat="server" ErrorMessage="*"
        ControlToValidate="CheckBoxListType" ClientValidationFunction="checkingCheckBoxList"></asp:CustomValidator>--%>
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
