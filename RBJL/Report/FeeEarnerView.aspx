﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterReport.master" AutoEventWireup="true"
    CodeFile="FeeEarnerView.aspx.cs" Inherits="Report_FeeEarnerView" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <rsweb:ReportViewer ID="ReportViewerFeeEarner" runat="server" Font-Names="Verdana"
        Font-Size="8pt" Height="900px" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
        WaitMessageFont-Size="14pt" Width="900px">
        <LocalReport ReportPath="ReportFrame\FeeEarnerReport.rdlc" EnableExternalImages="True">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
