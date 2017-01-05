<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DebitNoteCostOrDisbursement.ascx.cs"
    Inherits="WebControl_DebitNoteCostOrDisbursement" %>
<%--<%@ Register Src="~/WebControl/DDLPricing.ascx" TagName="WebUserControlDDLPricing"
    TagPrefix="uc1" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<table class="lineHeight">
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBoxCost" runat="server" OnCheckedChanged="CheckBoxCost_CheckedChanged"
                        AutoPostBack="true" />
                    <asp:Label ID="LabelCostTemplate" runat="server" Text="Fee:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListCost" runat="server" DataSourceID="EntityDataSourceCost"
                        DataTextField="typeName" DataValueField="id" OnSelectedIndexChanged="DropDownListCost_SelectedIndexChanged"
                        AutoPostBack="true" CssClass="DDLWidth">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:DropDownList ID="DropDownListPricingDetails" runat="server" CssClass="DDLWidth"
                                    OnSelectedIndexChanged="DropDownListPricingDetails_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBoxTemplateCore" runat="server" OnCheckedChanged="CheckBoxTemplateCore_CheckedChanged"
                        AutoPostBack="true" />
                    <asp:Label ID="LabelTemplate" runat="server" Text="Template:"></asp:Label>
                </td>
                <td>
                    <%-- <uc1:WebUserControlDDLTemplate ID="ucDllTemplate" runat="server" />--%>
                    <asp:DropDownList ID="DropDownListTemplateCore" runat="server" DataSourceID="EntityDataSourceTemplateCore"
                        DataTextField="typeName" DataValueField="id" OnSelectedIndexChanged="DropDownListTemplateCore_SelectedIndexChanged"
                        AutoPostBack="true" CssClass="DDLWidth">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:DropDownList ID="DropDownListTemplateDetails" runat="server" CssClass="DDLWidth"
                                    OnSelectedIndexChanged="DropDownListTemplateDetails_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </ContentTemplate>
    </asp:UpdatePanel>
    <tr>
        <td>
            <asp:Label ID="LabelCostDescription" runat="server" Text="Description:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxCostDescription" runat="server" TextMode="MultiLine" Rows="10"
                CssClass="textAreaCss"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelCost" runat="server" Text="Cost:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxCost" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Only numbers"
                ValidationExpression="^[-+]?[0-9]+(\.[0-9]+)?$" ControlToValidate="TextBoxCost"
                CssClass="warning"></asp:RegularExpressionValidator>
            <%--<asp:RangeValidator ID="RangeValidator1" runat="server" 
                ErrorMessage="*Only numbers" ControlToValidate="TextBoxCost" 
                MaximumValue="999999999999999" MinimumValue="0"></asp:RangeValidator>--%>
        </td>
    </tr>
    <tr id="isSetFeeEarner" runat="server">
        <td>
            <asp:Label ID="LabelFeeEarner" runat="server" Text="Fee Earner:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownListFeeEarner" runat="server" CssClass="DDLWidth">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelOrderBy" runat="server" Text="Order:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBoxOrderBy" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr id="isRemark" runat="server">
        <td>
            <asp:Label ID="LabelRemark" runat="server" Text="Remark:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LabelRemarkValue" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:HiddenField ID="HiddenFieldTarId" runat="server" />
            <asp:Button ID="ButtonCostSubmit" runat="server" Text="Add" OnClick="ButtonCostSubmit_Click" />
            <asp:Button ID="ButtonCostUpdate" runat="server" Text="Update" Visible="false" OnClick="ButtonCostUpdate_Click" />
            &nbsp;
            <asp:Button ID="ButtonCostCancel" runat="server" Text="Cancel" Visible="false" OnClick="ButtonCostCancel_Click" />
        </td>
    </tr>
</table>
<asp:GridView ID="GridViewCost" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="False"
    OnRowCancelingEdit="GridViewCost_RowCancelingEdit" OnRowDeleting="GridViewCost_RowDeleting"
    OnRowEditing="GridViewCost_RowEditing" OnRowUpdating="GridViewCost_RowUpdating"
    RowStyle-CssClass="lineGridviewMaster" HeaderStyle-CssClass="lineGridviewMaster"
    DataKeyNames="id" OnRowCommand="GridViewCost_RowCommand" OnSelectedIndexChanged="GridViewCost_SelectedIndexChanged">
    <SelectedRowStyle BackColor="LightGoldenrodYellow" ForeColor="DarkOrange" Font-Bold="true" />
    <Columns>
        <asp:TemplateField HeaderText="Template">
            <ItemTemplate>
                <asp:HiddenField ID="HiddenFieldId" runat="server" Value='<%# Eval("id") %>' />
                <asp:Label ID="lblTemplate" runat="server" Text='<%# Eval("TemplateValue") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="lblTemplateEdit" runat="server" Text='<%# Bind("TemplateValue") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description">
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server"  Width='250px'  Text='<%# Eval("Description") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="lblDescriptionEdit" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cost">
            <ItemTemplate>
                <asp:Label ID="lblCost" runat="server" Text='<%# Eval("Cost") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="lblCost" runat="server" Text='<%# Bind("Cost") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fee Earner">
            <ItemTemplate>
                <asp:Label ID="lblEarner" runat="server" Text='<%# findUserName(Eval("FeeEarner")) %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="lblEarner" runat="server" Text='<%# Bind("FeeEarner") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Order">
            <ItemTemplate>
                <asp:Label ID="lblOrder" runat="server" Text='<%# Eval("Order") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="lblOrder" runat="server" Text='<%# Bind("Order") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <%--        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="ButtonEdit" runat="server" CommandArgument='<%# Bind("id") %>' CommandName="Select"
                    Text='Edit' OnClick="ButtonEdit_Click" />
            </ItemTemplate>
        </asp:TemplateField>--%>
        <asp:CommandField ButtonType="Button" ShowDeleteButton="true" ShowSelectButton="true"
            SelectText="Edit" />
    </Columns>
</asp:GridView>

<asp:HiddenField ID="HiddenFieldGetSeesionData" runat="server"/>

<asp:EntityDataSource ID="EntityDataSourceCost" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="PricingTypes">
</asp:EntityDataSource>
<asp:EntityDataSource ID="EntityDataSourceTemplateCore" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
    DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EntitySetName="TemplateTypes">
</asp:EntityDataSource>
