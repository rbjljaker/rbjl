<%@ Page Language="C#" AutoEventWireup="true" CodeFile="exportMatter.aspx.cs" Inherits="Report_exportMatter"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/WebControl/LBLFeeEarner.ascx" TagName="WebUserControlLBLFeeEarner"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/getMatterStatus.ascx" TagName="WebUserControlGetStatus"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/LBLIntroducer.ascx" TagName="WebUserControlLBLIntroducer"
    TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="display: none;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="matterSubject,clientName,clientNum,ClientbillingAddressFirst,ClientbillingAddressSecond,ClientcontactPerson,Clienttel,Clientemail,ClientBillingEmail,refererName,RefererbillingAddressFirst,RefererbillingAddressSecond,ReferercontactPerson,Referertel,Refereremail,id"
            DataSourceID="EntityDataSource1">
            <Columns>
                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_FeeEarner %>">
                    <ItemTemplate>
                        <uc1:WebUserControlLBLFeeEarner ID="uc1FeeEarner" runat="server" initGuidId='<%# Guid.Parse((Eval("id")).ToString()) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_HandlingColleague %>">
                    <ItemTemplate>
                        <uc1:WebUserControlLBLFeeEarner ID="uc1HandlingColleague" runat="server" initGuidId='<%# Guid.Parse((Eval("id")).ToString()) %>'
                            type="HandlingColleague" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="matterNum" HeaderText="matterNum" SortExpression="matterNum" />
                <asp:BoundField DataField="matterSubject" HeaderText="matterSubject" ReadOnly="True"
                    SortExpression="matterSubject" />
                <asp:BoundField DataField="refererFee" HeaderText="refererFee" SortExpression="refererFee" />
                <asp:BoundField DataField="jobTypeId" HeaderText="jobTypeId" SortExpression="jobTypeId" />
                <asp:BoundField DataField="jobTypeName" HeaderText="jobTypeName" SortExpression="jobTypeName" />
                <asp:BoundField DataField="fileOpenDate" HeaderText="fileOpenDate" SortExpression="fileOpenDate" />
                <asp:BoundField DataField="discount" HeaderText="discount" SortExpression="discount" />
                <asp:BoundField DataField="masterKeywordName" HeaderText="masterKeywordName" SortExpression="masterKeywordName" />
                <asp:BoundField DataField="customKeywordFirst" HeaderText="customKeywordFirst" SortExpression="customKeywordFirst" />
                <asp:BoundField DataField="customKeywordSecond" HeaderText="customKeywordSecond"
                    SortExpression="customKeywordSecond" />
                <asp:BoundField DataField="customKeywordThird" HeaderText="customKeywordThird" SortExpression="customKeywordThird" />
                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, PendinglistIntroducer %>">
                    <ItemTemplate>
                        <uc1:WebUserControlLBLIntroducer ID="uc1I" runat="server" userGuid='<%# Eval("introducer")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="releaseToPublic" HeaderText="releaseToPublic" SortExpression="releaseToPublic" />
                <%--                <asp:BoundField DataField="status" HeaderText="status" 
                    SortExpression="status" />--%>
                <asp:TemplateField HeaderText="<%$ Resources:LanguagePack, Mattercore_Status %>"
                    SortExpression="status">
                    <ItemTemplate>
                        <uc1:WebUserControlGetStatus ID="ucGetStatus" runat="server" statudId='<%# Eval("status")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="remarks" HeaderText="remarks" SortExpression="remarks" />
                <asp:CheckBoxField DataField="isReopen" HeaderText="isReopen" SortExpression="isReopen" />
                <asp:BoundField DataField="ioNumOfRefererM" HeaderText="ioNumOfRefererM" SortExpression="ioNumOfRefererM" />
                <asp:BoundField DataField="refNumOfRefererM" HeaderText="refNumOfRefererM" SortExpression="refNumOfRefererM" />
                <asp:BoundField DataField="clientName" HeaderText="clientName" ReadOnly="True" SortExpression="clientName" />
                <asp:BoundField DataField="accountGroup" HeaderText="accountGroup" SortExpression="accountGroup" />
                <asp:BoundField DataField="clientNum" HeaderText="clientNum" ReadOnly="True" SortExpression="clientNum" />
                <asp:BoundField DataField="ClientbillingAddressFirst" HeaderText="ClientbillingAddressFirst"
                    ReadOnly="True" SortExpression="ClientbillingAddressFirst" />
                <asp:BoundField DataField="ClientbillingAddressSecond" HeaderText="ClientbillingAddressSecond"
                    ReadOnly="True" SortExpression="ClientbillingAddressSecond" />
                <asp:BoundField DataField="ClientcorrespondingAddress1First" HeaderText="ClientcorrespondingAddress1First"
                    SortExpression="ClientcorrespondingAddress1First" />
                <asp:BoundField DataField="ClientcorrespondingAddress1Second" HeaderText="ClientcorrespondingAddress1Second"
                    SortExpression="ClientcorrespondingAddress1Second" />
                <asp:BoundField DataField="ClientcorrespondingAddress2First" HeaderText="ClientcorrespondingAddress2First"
                    SortExpression="ClientcorrespondingAddress2First" />
                <asp:BoundField DataField="ClientcorrespondingAddress2Second" HeaderText="ClientcorrespondingAddress2Second"
                    SortExpression="ClientcorrespondingAddress2Second" />
                <asp:BoundField DataField="ClientcontactPerson" HeaderText="ClientcontactPerson"
                    ReadOnly="True" SortExpression="ClientcontactPerson" />
                <asp:BoundField DataField="Clienttel" HeaderText="Clienttel" ReadOnly="True" SortExpression="Clienttel" />
                <asp:BoundField DataField="Clientemail" HeaderText="Clientemail" ReadOnly="True"
                    SortExpression="Clientemail" />
                <asp:BoundField DataField="ClientcontactPerson02" HeaderText="ClientcontactPerson02"
                    SortExpression="ClientcontactPerson02" />
                <asp:BoundField DataField="Clienttel02" HeaderText="Clienttel02" SortExpression="Clienttel02" />
                <asp:BoundField DataField="Clientemail02" HeaderText="Clientemail02" SortExpression="Clientemail02" />
                <asp:BoundField DataField="ClientcontactPerson03" HeaderText="ClientcontactPerson03"
                    SortExpression="ClientcontactPerson03" />
                <asp:BoundField DataField="Clienttel03" HeaderText="Clienttel03" SortExpression="Clienttel03" />
                <asp:BoundField DataField="Clientemail03" HeaderText="Clientemail03" SortExpression="Clientemail03" />
                <asp:BoundField DataField="ClientcontactPerson04" HeaderText="ClientcontactPerson04"
                    SortExpression="ClientcontactPerson04" />
                <asp:BoundField DataField="Clienttel04" HeaderText="Clienttel04" SortExpression="Clienttel04" />
                <asp:BoundField DataField="Clientemail04" HeaderText="Clientemail04" SortExpression="Clientemail04" />
                <asp:BoundField DataField="ClientcontactPerson05" HeaderText="ClientcontactPerson05"
                    SortExpression="ClientcontactPerson05" />
                <asp:BoundField DataField="Clienttel05" HeaderText="Clienttel05" SortExpression="Clienttel05" />
                <asp:BoundField DataField="Clientemail05" HeaderText="Clientemail05" SortExpression="Clientemail05" />
                <asp:BoundField DataField="ClientcontactPerson06" HeaderText="ClientcontactPerson06"
                    SortExpression="ClientcontactPerson06" />
                <asp:BoundField DataField="Clienttel06" HeaderText="Clienttel06" SortExpression="Clienttel06" />
                <asp:BoundField DataField="Clientemail06" HeaderText="Clientemail06" SortExpression="Clientemail06" />
                <asp:BoundField DataField="ClientcontactPerson07" HeaderText="ClientcontactPerson07"
                    SortExpression="ClientcontactPerson07" />
                <asp:BoundField DataField="Clienttel07" HeaderText="Clienttel07" SortExpression="Clienttel07" />
                <asp:BoundField DataField="Clientemail07" HeaderText="Clientemail07" SortExpression="Clientemail07" />
                <asp:BoundField DataField="ClientcontactPerson08" HeaderText="ClientcontactPerson08"
                    SortExpression="ClientcontactPerson08" />
                <asp:BoundField DataField="Clienttel08" HeaderText="Clienttel08" SortExpression="Clienttel08" />
                <asp:BoundField DataField="Clientemail08" HeaderText="Clientemail08" SortExpression="Clientemail08" />
                <asp:BoundField DataField="ClientcontactPerson09" HeaderText="ClientcontactPerson09"
                    SortExpression="ClientcontactPerson09" />
                <asp:BoundField DataField="Clienttel09" HeaderText="Clienttel09" SortExpression="Clienttel09" />
                <asp:BoundField DataField="Clientemail09" HeaderText="Clientemail09" SortExpression="Clientemail09" />
                <asp:BoundField DataField="ClientcontactPerson10" HeaderText="ClientcontactPerson10"
                    SortExpression="ClientcontactPerson10" />
                <asp:BoundField DataField="Clienttel10" HeaderText="Clienttel10" SortExpression="Clienttel10" />
                <asp:BoundField DataField="Clientemail10" HeaderText="Clientemail10" SortExpression="Clientemail10" />
                <asp:BoundField DataField="ClientcontactPerson11" HeaderText="ClientcontactPerson11"
                    SortExpression="ClientcontactPerson11" />
                <asp:BoundField DataField="Clienttel11" HeaderText="Clienttel11" SortExpression="Clienttel11" />
                <asp:BoundField DataField="Clientemail11" HeaderText="Clientemail11" SortExpression="Clientemail11" />
                <asp:BoundField DataField="ClientcontactPerson12" HeaderText="ClientcontactPerson12"
                    SortExpression="ClientcontactPerson12" />
                <asp:BoundField DataField="Clienttel12" HeaderText="Clienttel12" SortExpression="Clienttel12" />
                <asp:BoundField DataField="Clientemail12" HeaderText="Clientemail12" SortExpression="Clientemail12" />
                <asp:BoundField DataField="ClientcontactPerson13" HeaderText="ClientcontactPerson13"
                    SortExpression="ClientcontactPerson13" />
                <asp:BoundField DataField="Clienttel13" HeaderText="Clienttel13" SortExpression="Clienttel13" />
                <asp:BoundField DataField="Clientemail13" HeaderText="Clientemail13" SortExpression="Clientemail13" />
                <asp:BoundField DataField="ClientcontactPerson14" HeaderText="ClientcontactPerson14"
                    SortExpression="ClientcontactPerson14" />
                <asp:BoundField DataField="Clienttel14" HeaderText="Clienttel14" SortExpression="Clienttel14" />
                <asp:BoundField DataField="Clientemail14" HeaderText="Clientemail14" SortExpression="Clientemail14" />
                <asp:BoundField DataField="ClientcontactPerson15" HeaderText="ClientcontactPerson15"
                    SortExpression="ClientcontactPerson15" />
                <asp:BoundField DataField="Clienttel15" HeaderText="Clienttel15" SortExpression="Clienttel15" />
                <asp:BoundField DataField="Clientemail15" HeaderText="Clientemail15" SortExpression="Clientemail15" />
                <asp:BoundField DataField="ClientcontactPerson16" HeaderText="ClientcontactPerson16"
                    SortExpression="ClientcontactPerson16" />
                <asp:BoundField DataField="Clienttel16" HeaderText="Clienttel16" SortExpression="Clienttel16" />
                <asp:BoundField DataField="Clientemail16" HeaderText="Clientemail16" SortExpression="Clientemail16" />
                <asp:BoundField DataField="ClientcontactPerson17" HeaderText="ClientcontactPerson17"
                    SortExpression="ClientcontactPerson17" />
                <asp:BoundField DataField="Clienttel17" HeaderText="Clienttel17" SortExpression="Clienttel17" />
                <asp:BoundField DataField="Clientemail17" HeaderText="Clientemail17" SortExpression="Clientemail17" />
                <asp:BoundField DataField="ClientcontactPerson18" HeaderText="ClientcontactPerson18"
                    SortExpression="ClientcontactPerson18" />
                <asp:BoundField DataField="Clienttel18" HeaderText="Clienttel18" SortExpression="Clienttel18" />
                <asp:BoundField DataField="Clientemail18" HeaderText="Clientemail18" SortExpression="Clientemail18" />
                <asp:BoundField DataField="ClientcontactPerson19" HeaderText="ClientcontactPerson19"
                    SortExpression="ClientcontactPerson19" />
                <asp:BoundField DataField="ClientTel19" HeaderText="ClientTel19" SortExpression="ClientTel19" />
                <asp:BoundField DataField="ClientEmail19" HeaderText="ClientEmail19" SortExpression="ClientEmail19" />
                <asp:BoundField DataField="ClientContactPerson20" HeaderText="ClientContactPerson20"
                    SortExpression="ClientContactPerson20" />
                <asp:BoundField DataField="ClientTel20" HeaderText="ClientTel20" SortExpression="ClientTel20" />
                <asp:BoundField DataField="ClientEmail20" HeaderText="ClientEmail20" SortExpression="ClientEmail20" />
                <asp:BoundField DataField="ClientBillingEmail" HeaderText="ClientBillingEmail" ReadOnly="True"
                    SortExpression="ClientBillingEmail" />
                <asp:BoundField DataField="ClientDiscount" HeaderText="ClientDiscount" SortExpression="ClientDiscount" />
                <asp:BoundField DataField="ClientRemarks" HeaderText="ClientRemarks" SortExpression="ClientRemarks" />
                <asp:BoundField DataField="refererName" HeaderText="refererName" ReadOnly="True"
                    SortExpression="refererName" />
                <asp:BoundField DataField="refererNum" HeaderText="refererNum" SortExpression="refererNum" />
                <asp:BoundField DataField="RefererbillingAddressFirst" HeaderText="RefererbillingAddressFirst"
                    ReadOnly="True" SortExpression="RefererbillingAddressFirst" />
                <asp:BoundField DataField="RefererbillingAddressSecond" HeaderText="RefererbillingAddressSecond"
                    ReadOnly="True" SortExpression="RefererbillingAddressSecond" />
                <asp:BoundField DataField="ReferercorrespondingAddress1First" HeaderText="ReferercorrespondingAddress1First"
                    SortExpression="ReferercorrespondingAddress1First" />
                <asp:BoundField DataField="ReferercorrespondingAddress1Second" HeaderText="ReferercorrespondingAddress1Second"
                    SortExpression="ReferercorrespondingAddress1Second" />
                <asp:BoundField DataField="ReferercorrespondingAddress2First" HeaderText="ReferercorrespondingAddress2First"
                    SortExpression="ReferercorrespondingAddress2First" />
                <asp:BoundField DataField="ReferercorrespondingAddress2Second" HeaderText="ReferercorrespondingAddress2Second"
                    SortExpression="ReferercorrespondingAddress2Second" />
                <asp:BoundField DataField="ReferercontactPerson" HeaderText="ReferercontactPerson"
                    ReadOnly="True" SortExpression="ReferercontactPerson" />
                <asp:BoundField DataField="Referertel" HeaderText="Referertel" ReadOnly="True" SortExpression="Referertel" />
                <asp:BoundField DataField="Refereremail" HeaderText="Refereremail" ReadOnly="True"
                    SortExpression="Refereremail" />
                <asp:BoundField DataField="ReferercontactPerson02" HeaderText="ReferercontactPerson02"
                    SortExpression="ReferercontactPerson02" />
                <asp:BoundField DataField="Referertel02" HeaderText="Referertel02" SortExpression="Referertel02" />
                <asp:BoundField DataField="Refereremail02" HeaderText="Refereremail02" SortExpression="Refereremail02" />
                <asp:BoundField DataField="ReferercontactPerson03" HeaderText="ReferercontactPerson03"
                    SortExpression="ReferercontactPerson03" />
                <asp:BoundField DataField="Referertel03" HeaderText="Referertel03" SortExpression="Referertel03" />
                <asp:BoundField DataField="Refereremail03" HeaderText="Refereremail03" SortExpression="Refereremail03" />
                <asp:BoundField DataField="ReferercontactPerson04" HeaderText="ReferercontactPerson04"
                    SortExpression="ReferercontactPerson04" />
                <asp:BoundField DataField="Referertel04" HeaderText="Referertel04" SortExpression="Referertel04" />
                <asp:BoundField DataField="Refereremail04" HeaderText="Refereremail04" SortExpression="Refereremail04" />
                <asp:BoundField DataField="ReferercontactPerson05" HeaderText="ReferercontactPerson05"
                    SortExpression="ReferercontactPerson05" />
                <asp:BoundField DataField="Referertel05" HeaderText="Referertel05" SortExpression="Referertel05" />
                <asp:BoundField DataField="Refereremail05" HeaderText="Refereremail05" SortExpression="Refereremail05" />
                <asp:BoundField DataField="ReferercontactPerson06" HeaderText="ReferercontactPerson06"
                    SortExpression="ReferercontactPerson06" />
                <asp:BoundField DataField="Referertel06" HeaderText="Referertel06" SortExpression="Referertel06" />
                <asp:BoundField DataField="Refereremail06" HeaderText="Refereremail06" SortExpression="Refereremail06" />
                <asp:BoundField DataField="ReferercontactPerson07" HeaderText="ReferercontactPerson07"
                    SortExpression="ReferercontactPerson07" />
                <asp:BoundField DataField="Referertel07" HeaderText="Referertel07" SortExpression="Referertel07" />
                <asp:BoundField DataField="Refereremail07" HeaderText="Refereremail07" SortExpression="Refereremail07" />
                <asp:BoundField DataField="ReferercontactPerson08" HeaderText="ReferercontactPerson08"
                    SortExpression="ReferercontactPerson08" />
                <asp:BoundField DataField="Referertel08" HeaderText="Referertel08" SortExpression="Referertel08" />
                <asp:BoundField DataField="Refereremail08" HeaderText="Refereremail08" SortExpression="Refereremail08" />
                <asp:BoundField DataField="ReferercontactPerson09" HeaderText="ReferercontactPerson09"
                    SortExpression="ReferercontactPerson09" />
                <asp:BoundField DataField="Referertel09" HeaderText="Referertel09" SortExpression="Referertel09" />
                <asp:BoundField DataField="Refereremail09" HeaderText="Refereremail09" SortExpression="Refereremail09" />
                <asp:BoundField DataField="ReferercontactPerson10" HeaderText="ReferercontactPerson10"
                    SortExpression="ReferercontactPerson10" />
                <asp:BoundField DataField="Referertel10" HeaderText="Referertel10" SortExpression="Referertel10" />
                <asp:BoundField DataField="Refereremail10" HeaderText="Refereremail10" SortExpression="Refereremail10" />
                <asp:BoundField DataField="ReferercontactPerson11" HeaderText="ReferercontactPerson11"
                    SortExpression="ReferercontactPerson11" />
                <asp:BoundField DataField="Referertel11" HeaderText="Referertel11" SortExpression="Referertel11" />
                <asp:BoundField DataField="Refereremail11" HeaderText="Refereremail11" SortExpression="Refereremail11" />
                <asp:BoundField DataField="ReferercontactPerson12" HeaderText="ReferercontactPerson12"
                    SortExpression="ReferercontactPerson12" />
                <asp:BoundField DataField="Referertel12" HeaderText="Referertel12" SortExpression="Referertel12" />
                <asp:BoundField DataField="Refereremail12" HeaderText="Refereremail12" SortExpression="Refereremail12" />
                <asp:BoundField DataField="ReferercontactPerson13" HeaderText="ReferercontactPerson13"
                    SortExpression="ReferercontactPerson13" />
                <asp:BoundField DataField="Referertel13" HeaderText="Referertel13" SortExpression="Referertel13" />
                <asp:BoundField DataField="Refereremail13" HeaderText="Refereremail13" SortExpression="Refereremail13" />
                <asp:BoundField DataField="ReferercontactPerson14" HeaderText="ReferercontactPerson14"
                    SortExpression="ReferercontactPerson14" />
                <asp:BoundField DataField="Referertel14" HeaderText="Referertel14" SortExpression="Referertel14" />
                <asp:BoundField DataField="Refereremail14" HeaderText="Refereremail14" SortExpression="Refereremail14" />
                <asp:BoundField DataField="ReferercontactPerson15" HeaderText="ReferercontactPerson15"
                    SortExpression="ReferercontactPerson15" />
                <asp:BoundField DataField="Referertel15" HeaderText="Referertel15" SortExpression="Referertel15" />
                <asp:BoundField DataField="Refereremail15" HeaderText="Refereremail15" SortExpression="Refereremail15" />
                <asp:BoundField DataField="ReferercontactPerson16" HeaderText="ReferercontactPerson16"
                    SortExpression="ReferercontactPerson16" />
                <asp:BoundField DataField="Referertel16" HeaderText="Referertel16" SortExpression="Referertel16" />
                <asp:BoundField DataField="Refereremail16" HeaderText="Refereremail16" SortExpression="Refereremail16" />
                <asp:BoundField DataField="ReferercontactPerson17" HeaderText="ReferercontactPerson17"
                    SortExpression="ReferercontactPerson17" />
                <asp:BoundField DataField="Referertel17" HeaderText="Referertel17" SortExpression="Referertel17" />
                <asp:BoundField DataField="Refereremail17" HeaderText="Refereremail17" SortExpression="Refereremail17" />
                <asp:BoundField DataField="ReferercontactPerson18" HeaderText="ReferercontactPerson18"
                    SortExpression="ReferercontactPerson18" />
                <asp:BoundField DataField="Referertel18" HeaderText="Referertel18" SortExpression="Referertel18" />
                <asp:BoundField DataField="Refereremail18" HeaderText="Refereremail18" SortExpression="Refereremail18" />
                <asp:BoundField DataField="ReferercontactPerson19" HeaderText="ReferercontactPerson19"
                    SortExpression="ReferercontactPerson19" />
                <asp:BoundField DataField="Referertel19" HeaderText="Referertel19" SortExpression="Referertel19" />
                <asp:BoundField DataField="Refereremail19" HeaderText="Refereremail19" SortExpression="Refereremail19" />
                <asp:BoundField DataField="ReferercontactPerson20" HeaderText="ReferercontactPerson20"
                    SortExpression="ReferercontactPerson20" />
                <asp:BoundField DataField="Referertel20" HeaderText="Referertel20" SortExpression="Referertel20" />
                <asp:BoundField DataField="Refereremail20" HeaderText="Refereremail20" SortExpression="Refereremail20" />
                <asp:BoundField DataField="Refererremark" HeaderText="Refererremark" SortExpression="Refererremark" />
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="false" />
            </Columns>
        </asp:GridView>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
            DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="View_ExportMatter"
            OnSelecting="EntityDataSource1_Selecting" OnQueryCreated="EntityDataSource1_QueryCreated">
        </asp:EntityDataSource>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    <asp:Label ID="Label1" runat="server" Text="No data" Visible="false"></asp:Label>
    </form>
</body>
</html>
