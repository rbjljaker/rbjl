<%@ Control Language="C#" AutoEventWireup="true" CodeFile="statusBarS.ascx.cs" Inherits="WebControl_statusBarS" %>
<%--<div>
    <table cellspacing="0" cellpadding="0" border="1" width="150" class="statusBarTable">
        <tr>
            <td class="statusBarValue statusBarRed">
            </td>
            <td class="statusBarBlue">
            </td>
        </tr>
    </table>
</div>
--%>
<div id="progressBar" class="big-red" title="7.75 hour per day">
    <sapn id="billable">
    </sapn>
    <sapn id="nonBillalbe">
    </sapn>
</div>
<br />
<div id="progressBarBillableByMonth" class="big-green" title="Monthly billable/non-billable">
    <sapn id="billable">
    </sapn>
    <sapn id="nonBillalbe1">
    </sapn>
</div>
<br />
<div id="progressBarBillable" class="big-green" title="Monthly billed">
    <div>
    </div>
</div>
<asp:Label ID="LabelValue" runat="server" Text="" CssClass="billedValue" title="Monthly billed"></asp:Label>
