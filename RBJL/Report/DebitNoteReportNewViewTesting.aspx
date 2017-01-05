<%@ Page Title="" Language="C#" MasterPageFile="~/MasterReport.master" AutoEventWireup="true" CodeFile="DebitNoteReportNewViewTesting.aspx.cs" Inherits="Report_DebitNoteReportNewViewTesting" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("[title*='Excel']").css("display", "none");
            $("[title*='Word']").css("display", "none");
        });
    </script>
    <style type="text/css">
        body:nth-of-type(1) img[src*="Blank.gif"]
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <rsweb:ReportViewer ID="ReportViewerDebitNote" runat="server" Font-Names="Verdana"
        Font-Size="8pt" Height="900px" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
        WaitMessageFont-Size="14pt" Width="760px">
        <LocalReport ReportPath="ReportFrame\ebitNoteReportTesting2.rdlc" EnableExternalImages="True">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
