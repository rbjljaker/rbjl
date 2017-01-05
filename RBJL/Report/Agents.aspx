<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="Agents.aspx.cs" Inherits="Report_Agents" %>

<%@ Register Src="~/WebControl/CalenderTextBox.ascx" TagName="WebUserControlCalenderTextBox"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        var client = "Show client?";
        var refer = "Show instructor?";
        var outgoingAgent = "Show outgoing Agent?";

        $(document).ready(function () {

            var myRadioClient = $('input[type="radio"][value="RadioButtonClient"]');
            var myRadioRefer = $('input[type="radio"][value="RadioButtonRefer"]');
            var myRadioOutgoingAgent = $('input[type="radio"][value="RadioButtonOutgoingAgent"]');

            //            var value1 = myRadioClient.filter(':checked').val();
            //            var value2 = myRadioRefer.filter(':checked').val();
            //            var value3 = myRadioOutgoingAgent.filter(':checked').val();

            //            alert(value1, value2, value3);

            myRadioClient.click(function () {
                initTextClient();
            })
            myRadioRefer.click(function () {
                initTextRefer();
            })
            myRadioOutgoingAgent.click(function () {
                initTextOutgoingAgent();
            })
        });

        function changeTarText(text1, text2) {
            $("#opShow1").html(text1);
            $("#opShow2").html(text2);
        }

        function initTextClient() {
            changeTarText(refer, outgoingAgent);
        }

        function initTextRefer() {
            changeTarText(client, outgoingAgent);
        }

        function initTextOutgoingAgent() {
            changeTarText(client, refer);
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, agent_lblTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <asp:Table ID="TableLayout" runat="server" Width="747px" CssClass="lineHeight">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelDate" runat="server" Text="<%$ Resources:LanguagePack,agent_lblDate %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxDate" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtenderDate" runat="server" TargetControlID="TextBoxDate"
                    Format="dd-MMM-yyyy">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderDate" runat="server"
                    TargetControlID="TextBoxDate" WatermarkText="dd-Jan-YYYY">
                </ajaxToolkit:TextBoxWatermarkExtender>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="LabelDateTo" runat="server" Text="<%$ Resources:LanguagePack,agent_lblDateTo %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxDateTo" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtenderDateTo" runat="server" TargetControlID="TextBoxDateTo"
                    Format="dd-MMM-yyyy">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtenderDateTo" runat="server"
                    TargetControlID="TextBoxDateTo" WatermarkText="dd-Jan-YYYY">
                </ajaxToolkit:TextBoxWatermarkExtender>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <table class="lineHeight">
        <tr>
            <td>
                <asp:RadioButton ID="RadioButtonClient" runat="server" Text="<%$ Resources:LanguagePack,agent_LabelClient %>"
                    GroupName="RAndO" Checked="true" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RadioButtonRefer" runat="server" Text="<%$ Resources:LanguagePack,agent_textRefer %>"
                    GroupName="RAndO" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="RadioButtonOutgoingAgent" runat="server" Text="<%$ Resources:LanguagePack,agent_textOutgoingAgent %>"
                    GroupName="RAndO" />
            </td>
        </tr>
    </table>
    <asp:Label ID="LabelOption" runat="server" CssClass="underLinkText" Text="<%$ Resources:LanguagePack, report_option %>"></asp:Label>
    <br />
    <br />
    <asp:CheckBox ID="CheckBoxIsShow1" runat="server" />
    <span id="opShow1"></span>
    <br />
    <br />
    <asp:CheckBox ID="CheckBoxIsShow2" runat="server" />
    <span id="opShow2"></span>
    <br />
    <br />
    <%--    <asp:Label ID="LabelPrintTo" runat="server" CssClass="underLinkText" Text="<%$ Resources:LanguagePack, print_PrintTo %>"></asp:Label>
    <br />--%>
    <%--    <asp:RadioButtonList ID="RadioButtonListPrintTo" runat="server">
        <asp:ListItem Text="<%$ Resources:LanguagePack,print_onScreen %>"></asp:ListItem>
        <asp:ListItem Text="<%$ Resources:LanguagePack,print_pdf %>"></asp:ListItem>
        <asp:ListItem Text="<%$ Resources:LanguagePack,print_excel %>"></asp:ListItem>
    </asp:RadioButtonList>--%>
    <asp:Button ID="ButtonPrint" runat="server" Text="<%$ Resources:LanguagePack,lblPrint %>"
        OnClick="ButtonPrint_Click" />
    <asp:Button ID="ButtonCancel" runat="server" Text="<%$ Resources:LanguagePack,lblCancel %>"
        OnClick="ButtonCancel_Click" />
</asp:Content>
