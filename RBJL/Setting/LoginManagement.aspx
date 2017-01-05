<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="LoginManagement.aspx.cs" Inherits="Setting_LoginManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
    <asp:Label ID="lblTitle" runat="server" Text="<%$ Resources:LanguagePack, LoginManagementTitle %>" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <table border="0" cellpadding="0" cellspacing="3" width="100%">
        <asp:ObjectDataSource ID="odsRoles" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRoles" TypeName="MembershipUtilities.RoleODS"></asp:ObjectDataSource>
        <tr>
            <td>
                <table style="width: 400px">
                    <tr>
                        <td style="width: 11px">
                            &nbsp;
                        </td>
                        <td style="width: 311px">
                            <asp:Label ID="lblSelectRole" runat="server" Text="lblSelectRole"></asp:Label>
                        </td>
                        <td style="width: 730px">
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="odsRoles"
                                DataTextField="RoleName" DataValueField="RoleName" OnDataBound="DropDownList1_DataBound">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 11px">
                            &nbsp;
                        </td>
                        <td style="width: 311px">
                            <asp:Label ID="lblUsername" runat="server" Text="lblUsername"></asp:Label>
                        </td>
                        <td style="width: 730px">
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="btnSearch" />
                        </td>
                    </tr>
                </table>
                <br />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:ObjectDataSource ID="odsUsers" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetMembers" TypeName="MembershipUtilities.MembershipUserODS"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="UserName" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="userName" Type="String" />
                        <asp:Parameter Name="isApproved" Type="Boolean" />
                        <asp:Parameter Name="comment" Type="String" />
                        <asp:Parameter Name="lastLockoutDate" Type="DateTime" />
                        <asp:Parameter Name="creationDate" Type="DateTime" />
                        <asp:Parameter Name="email" Type="String" />
                        <asp:Parameter Name="lastActivityDate" Type="DateTime" />
                        <asp:Parameter Name="providerName" Type="String" />
                        <asp:Parameter Name="isLockedOut" Type="Boolean" />
                        <asp:Parameter Name="lastLoginDate" Type="DateTime" />
                        <asp:Parameter Name="isOnline" Type="Boolean" />
                        <asp:Parameter Name="passwordQuestion" Type="String" />
                        <asp:Parameter Name="lastPasswordChangedDate" Type="DateTime" />
                        <asp:Parameter Name="password" Type="String" />
                        <asp:Parameter Name="passwordAnswer" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter Name="returnAllApprovedUsers" Type="Boolean" />
                        <asp:ControlParameter ControlID="TextBox1" Name="usernameToFind" PropertyName="Text"
                            Type="String" />
                        <asp:Parameter Name="sortData" Type="String" />
                        <asp:ControlParameter ControlID="DropDownList1" Name="roleName" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="UserName" Type="String" />
                        <asp:Parameter Name="email" Type="String" />
                        <asp:Parameter Name="isApproved" Type="Boolean" />
                        <asp:Parameter Name="isLockedOut" Type="Boolean" />
                        <asp:Parameter Name="comment" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="UserName,Role"
                    DataSourceID="odsUsers" Width="100%" AllowPaging="True" OnRowEditing="GridView1_RowEditing"
                    OnRowDataBound="GridView1_RowDataBound" CssClass="gvClass">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="false" ShowEditButton="True" />
                        <asp:TemplateField HeaderText="UserName" SortExpression="UserName">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Role" HeaderText="lblGvRole" ReadOnly="True" SortExpression="Role" />
                        <asp:BoundField DataField="Email" HeaderText="lblGvEmail" SortExpression="Email" />
                        <asp:CheckBoxField DataField="IsApproved" HeaderText="lblGvApproved" SortExpression="IsApproved" />
                        <asp:CheckBoxField DataField="IsLockedOut" HeaderText="lblGvLockedOut" ReadOnly="True"
                            SortExpression="IsLockedOut" />
                        <asp:BoundField DataField="LastLoginDate" HeaderText="lblGvLastLoginDate" SortExpression="LastLoginDate" />
                        <%--<asp:CheckBoxField DataField="IsOnline" HeaderText="IsOnline" ReadOnly="True" SortExpression="IsOnline" />--%>
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
