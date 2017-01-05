<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tseting.aspx.cs" Inherits="tseting" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="Scripts/mouseOverSearch.js" type="text/javascript"></script>
    <%--    <script type="text/javascript">
        //    $(document).ready(function() {
        //        $('input[type="button"][value="Update"]').click(function () {
        //            return confirm("Are you sure you want to delete this record?");
        //        })
        //
        //        });

        $(document).ready(function () {

            alert("123");

            $('input[type="button"][name="Button1"]').click(function () {
                alert("345");
                var msg = 'Confirmation Msg.';
                var div = $("<div>" + msg + "</div>");
                div.dialog({
                    title: "Confirm",
                    buttons: [
                        {
                            text: "Yes",
                            click: function () {
                                //add ur stuffs here
                            }
                        },
                        {
                            text: "No",
                            click: function () {
                                div.dialog("close");
                            }
                        }
                    ]

                })


            });
        });

    </script>--%>
    <%--    <script type="text/javascript">

        $(function () {

            mouseOverSearchInit("#Button4", "#dvimg");
        });

       


    </script>--%>
    <script type="text/javascript">

        $(function () {


            //initControl();
            $("#btnToggleAdd01").click(function () {
                add();
            });

            $("#btnToggleSub02").click(function () {
                sub();
            });
        });

        function add() {
            $("[glevel]=g02").each(function () {
                $(this).closest('tr').removeClass("displayNone");
            });
        }

        function sub() {
            $("[glevel]=g02").each(function () {
                $(this).closest('tr').attr('class', "displayNone");
                $(this).parent().find("input[type=text]").val("");
            });
        }

        function initControl() {
            $("[glevel]=g02").each(function () {
                $(this).closest('tr').attr('class', "displayNone");

            });
        }




    </script>
    <style type="text/css">
        .displayNone
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <%-- <div>
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
 <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>Simple Ext.NET Window Sample</h1>
        
        <p>The following sample demonstrates how to configure a new Window Component and "show" the Window if closed.</p>
    
        <ext:Button ID="Button1" 
            runat="server" 
            Text="Show Window (Client Event)" 
            Icon="Application" 
            OnClientClick="#{Window1}.show();" 
            />
        
        <br />
        
        <ext:Button ID="Button2" 
            runat="server" 
            Text="Show Window (Server Event)" 
            Icon="Application" 
            OnDirectClick="Button2_Click" 
            />
        
        <ext:Window 
            ID="Window1" 
            runat="server" 
            Title="Hello World"  
            Icon="Application"
            Height="185" 
            Width="350"
            BodyStyle="background-color: #fff;" 
            BodyPadding="5"
            Modal="true">
            <Content>
                This is my first <a target="_blank" href="http://www.ext.net/"> Ext.NET</a> Window.
            </Content>
        </ext:Window>--%>
    <div style="display: none">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <asp:FileUpload ID="FileUpload2" runat="server" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        <br />
        <br />
        <asp:FileUpload ID="FileUpload3" runat="server" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
        <br />
        <br />
        <div>
            <asp:Button ID="Button4" runat="server" Text="Hover the Mouse Here to Show Div!"
                Height="50"></asp:Button>
            <div id="dvimg" style="display: none; background-color: Green; width: 450px; height: 100px;
                color: White; position: fixed;">
                This is the testing div shown on the mouse hover.
            </div>
        </div>
    </div>
    <br />
    <br />
    <%-- <asp:DetailsView ID="DetailsViewClientInsert" runat="server" CssClass="masterDe lineHeight"
        AutoGenerateRows="False" DataKeyNames="id" DataSourceID="EntityDataSourceClientInsert"
        DefaultMode="Insert">
        <Fields>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                Visible="False" />
            <asp:DynamicField DataField="accountGroup" HeaderText="<%$ Resources:master, client_accountGroup %>" />
            <asp:DynamicField DataField="clientNum" HeaderText="<%$ Resources:master, client_clientNum  %>" />
            <asp:DynamicField DataField="clientName" HeaderText="<%$ Resources:master, client_clientName  %>" />
            <asp:DynamicField DataField="billingAddressFirst" HeaderText="<%$ Resources:master, client_billingAddressFirst  %>" />
            <asp:DynamicField DataField="billingAddressSecond" HeaderText="<%$ Resources:master, client_billingAddressSecond  %>" />
            <asp:DynamicField DataField="correspondingAddress1First" HeaderText="<%$ Resources:master, client_correspondingAddress1First  %>" />
            <asp:DynamicField DataField="correspondingAddress1Second" HeaderText="<%$ Resources:master, client_correspondingAddress1Second  %>" />
            <asp:DynamicField DataField="correspondingAddress2First" HeaderText="<%$ Resources:master, client_correspondingAddress2First  %>" />
            <asp:DynamicField DataField="correspondingAddress2Second" HeaderText="<%$ Resources:master, client_correspondingAddress2Second  %>" />
            <asp:DynamicField DataField="Country" HeaderText="<%$ Resources:LanguagePack, CountryName  %>" />
            <asp:DynamicField DataField="fax" HeaderText="<%$ Resources:master, client_fax  %>" />
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="contactPerson" SortExpression="contactPerson">
                <EditItemTemplate>
                    <asp:DynamicControl ID="DynamicControl1" runat="server" DataField="contactPerson"
                        Mode="Edit" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="DynamicControl1" runat="server" DataField="contactPerson"
                        Mode="Insert" />
                    <input type="button" value="add" id="btnToggleAdd01" isdisplay="T" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="tel" SortExpression="tel">
                <EditItemTemplate>
                    <asp:DynamicControl ID="DynamicControl2" runat="server" DataField="tel" Mode="Edit" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="DynamicControl2" runat="server" DataField="tel" Mode="Insert" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="email" SortExpression="email">
                <ItemTemplate>
                    <asp:DynamicControl ID="DynamicControl3" runat="server" DataField="email" Mode="ReadOnly" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DynamicControl ID="DynamicControl3" runat="server" DataField="email" Mode="Edit" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="DynamicControl3" runat="server" DataField="email" Mode="Insert" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="contactPerson02"
                SortExpression="contactPerson02">
                <EditItemTemplate>
                    <asp:DynamicControl ID="DynamicControl4" runat="server" DataField="contactPerson02"
                        Mode="Edit" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="DynamicControl4" runat="server" DataField="contactPerson02"
                        Mode="Insert" />
                    <div glevel="g02">
                        <input type="button" value="sub" id="btnToggleSub02" isdisplay="T" />
                    </div>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="tel02" SortExpression="tel02">
                <EditItemTemplate>
                    <asp:DynamicControl ID="DynamicControl5" runat="server" DataField="tel02" Mode="Edit" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="DynamicControl5" runat="server" DataField="tel02" Mode="Insert" />
                    <div glevel="g02">
                    </div>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="email02" SortExpression="email02">
                <EditItemTemplate>
                    <asp:DynamicControl ID="DynamicControl6" runat="server" DataField="email02" Mode="Edit" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="DynamicControl6" runat="server" DataField="email02" Mode="Insert" />
                    <div glevel="g02">
                    </div>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="contactPerson03"
                SortExpression="contactPerson03">
                <EditItemTemplate>
                    <asp:DynamicControl ID="DynamicControl7" runat="server" DataField="contactPerson03"
                        Mode="Edit" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="DynamicControl7" runat="server" DataField="contactPerson03"
                        Mode="Insert" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="tel03" SortExpression="tel03">
                <EditItemTemplate>
                    <asp:DynamicControl ID="DynamicControl8" runat="server" DataField="tel03" Mode="Edit" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="DynamicControl8" runat="server" DataField="tel03" Mode="Insert" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="email03" SortExpression="email03">
                <EditItemTemplate>
                    <asp:DynamicControl ID="DynamicControl9" runat="server" DataField="email03" Mode="Edit" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="DynamicControl9" runat="server" DataField="email03" Mode="Insert" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="contactPerson04"
                SortExpression="contactPerson04">
                <EditItemTemplate>
                    <asp:DynamicControl ID="DynamicControl10" runat="server" DataField="contactPerson04"
                        Mode="Edit" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="DynamicControl10" runat="server" DataField="contactPerson04"
                        Mode="Insert" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="tel04" SortExpression="tel04">
                <EditItemTemplate>
                    <asp:DynamicControl ID="DynamicControl11" runat="server" DataField="tel04" Mode="Edit" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="DynamicControl11" runat="server" DataField="tel04" Mode="Insert" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="email04" SortExpression="email04">
                <EditItemTemplate>
                    <asp:DynamicControl ID="DynamicControl12" runat="server" DataField="email04" Mode="Edit" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="DynamicControl12" runat="server" DataField="email04" Mode="Insert" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="contactPerson05" HeaderText="contactPerson05" ItemStyle-CssClass="g05" />
            <asp:DynamicField DataField="tel05" HeaderText="<%$ Resources:master, client_tel05  %>" />
            <asp:DynamicField DataField="email05" HeaderText="<%$ Resources:master, client_email05  %>" />
            <asp:DynamicField DataField="contactPerson06" HeaderText="<%$ Resources:master, client_contactPerson06  %>" />
            <asp:DynamicField DataField="tel06" HeaderText="<%$ Resources:master, client_tel06  %>" />
            <asp:DynamicField DataField="email06" HeaderText="<%$ Resources:master, client_email06  %>" />
            <asp:DynamicField DataField="contactPerson07" HeaderText="<%$ Resources:master, client_contactPerson07  %>" />
            <asp:DynamicField DataField="tel07" HeaderText="<%$ Resources:master, client_tel07  %>" />
            <asp:DynamicField DataField="email07" HeaderText="<%$ Resources:master, client_email07  %>" />
            <asp:DynamicField DataField="contactPerson08" HeaderText="<%$ Resources:master, client_contactPerson08  %>" />
            <asp:DynamicField DataField="tel08" HeaderText="<%$ Resources:master, client_tel08  %>" />
            <asp:DynamicField DataField="email08" HeaderText="<%$ Resources:master, client_email08  %>" />
            <asp:DynamicField DataField="contactPerson09" HeaderText="<%$ Resources:master, client_contactPerson09  %>" />
            <asp:DynamicField DataField="tel09" HeaderText="<%$ Resources:master, client_tel09  %>" />
            <asp:DynamicField DataField="email09" HeaderText="<%$ Resources:master, client_email09  %>" />
            <asp:DynamicField DataField="contactPerson10" HeaderText="<%$ Resources:master, client_contactPerson10  %>" />
            <asp:DynamicField DataField="tel10" HeaderText="<%$ Resources:master, client_tel10  %>" />
            <asp:DynamicField DataField="email10" HeaderText="<%$ Resources:master, client_email10  %>" />
            <asp:DynamicField DataField="contactPerson11" HeaderText="<%$ Resources:master, client_contactPerson11  %>" />
            <asp:DynamicField DataField="tel11" HeaderText="<%$ Resources:master, client_tel11  %>" />
            <asp:DynamicField DataField="email11" HeaderText="<%$ Resources:master, client_email11  %>" />
            <asp:DynamicField DataField="contactPerson12" HeaderText="<%$ Resources:master, client_contactPerson12  %>" />
            <asp:DynamicField DataField="tel12" HeaderText="<%$ Resources:master, client_tel12  %>" />
            <asp:DynamicField DataField="email12" HeaderText="<%$ Resources:master, client_email12  %>" />
            <asp:DynamicField DataField="contactPerson13" HeaderText="<%$ Resources:master, client_contactPerson13  %>" />
            <asp:DynamicField DataField="tel13" HeaderText="<%$ Resources:master, client_tel13  %>" />
            <asp:DynamicField DataField="email13" HeaderText="<%$ Resources:master, client_email13  %>" />
            <asp:DynamicField DataField="contactPerson14" HeaderText="<%$ Resources:master, client_contactPerson14  %>" />
            <asp:DynamicField DataField="tel14" HeaderText="<%$ Resources:master, client_tel14  %>" />
            <asp:DynamicField DataField="email14" HeaderText="<%$ Resources:master, client_email14  %>" />
            <asp:DynamicField DataField="contactPerson15" HeaderText="<%$ Resources:master, client_contactPerson15  %>" />
            <asp:DynamicField DataField="tel15" HeaderText="<%$ Resources:master, client_tel15  %>" />
            <asp:DynamicField DataField="email15" HeaderText="<%$ Resources:master, client_email15  %>" />
            <asp:DynamicField DataField="contactPerson16" HeaderText="<%$ Resources:master, client_contactPerson16  %>" />
            <asp:DynamicField DataField="tel16" HeaderText="<%$ Resources:master, client_tel16  %>" />
            <asp:DynamicField DataField="email16" HeaderText="<%$ Resources:master, client_email16  %>" />
            <asp:DynamicField DataField="contactPerson17" HeaderText="<%$ Resources:master, client_contactPerson17  %>" />
            <asp:DynamicField DataField="tel17" HeaderText="<%$ Resources:master, client_tel17  %>" />
            <asp:DynamicField DataField="email17" HeaderText="<%$ Resources:master, client_email17  %>" />
            <asp:DynamicField DataField="contactPerson18" HeaderText="<%$ Resources:master, client_contactPerson18  %>" />
            <asp:DynamicField DataField="tel18" HeaderText="<%$ Resources:master, client_tel18  %>" />
            <asp:DynamicField DataField="email18" HeaderText="<%$ Resources:master, client_email18  %>" />
            <asp:DynamicField DataField="contactPerson19" HeaderText="<%$ Resources:master, client_contactPerson19  %>" />
            <asp:DynamicField DataField="tel19" HeaderText="<%$ Resources:master, client_tel19  %>" />
            <asp:DynamicField DataField="email19" HeaderText="<%$ Resources:master, client_email19 %>" />
            <asp:DynamicField DataField="contactPerson20" HeaderText="<%$ Resources:master, client_contactPerson20  %>" />
            <asp:DynamicField DataField="tel20" HeaderText="<%$ Resources:master, client_tel20  %>" />
            <asp:DynamicField DataField="email20" HeaderText="<%$ Resources:master, client_email20  %>" />
            <asp:DynamicField DataField="billingEmail" HeaderText="<%$ Resources:master, client_billingEmail  %>" />
            <asp:DynamicField DataField="Referer" HeaderText="<%$ Resources:master, client_Referer  %>" />
            <asp:TemplateField HeaderText="<%$ Resources:master, client_discount  %>">
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBoxDiscountEdit" runat="server" Text='<%# Bind("discount") %>'></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorDiscount" runat="server"
                        ErrorMessage="*Percentage" ControlToValidate="TextBoxDiscountEdit" ValidationExpression="^(100\.00|100\.0|100)|([0-9]{1,2}){0,1}(\.[0-9]{1,2}){0,1}$"
                        CssClass="warning"></asp:RegularExpressionValidator>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="refNumOfReferer" HeaderText="<%$ Resources:master, client_refNumOfReferer  %>"
                Visible="false" />
            <asp:DynamicField DataField="ioNumOfReferer" HeaderText="<%$ Resources:master, client_ioNumOfReferer  %>"
                Visible="false" />
            <asp:DynamicField DataField="remarks" HeaderText="<%$ Resources:master, clientRemarks  %>" />
            <asp:CommandField ShowInsertButton="True" ButtonType="Button" />
        </Fields>
    </asp:DetailsView>
    <asp:EntityDataSource ID="EntityDataSourceClientInsert" runat="server" ConnectionString="name=RBJLLawFirmDBEntities"
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" EnableInsert="True"
        EntitySetName="Clients" ContextTypeName="" EnableDelete="True" EnableUpdate="True"
        EntityTypeFilter="" OnSelecting="EntityDataSourceClientInsert_Selecting" Select=""
        Where="">
    </asp:EntityDataSource>--%>


<%--    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id,clientId,matterSubject" DataSourceID="EntityDataSource1">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                SortExpression="id" />
            <asp:BoundField DataField="matterNum" HeaderText="matterNum" 
                SortExpression="matterNum" />
            <asp:BoundField DataField="clientId" HeaderText="clientId" ReadOnly="True" 
                SortExpression="clientId" />
            <asp:BoundField DataField="matterSubject" HeaderText="matterSubject" 
                ReadOnly="True" SortExpression="matterSubject" />
            <asp:BoundField DataField="status" HeaderText="status" 
                SortExpression="status" />
            <asp:BoundField DataField="masterKeywordName" HeaderText="masterKeywordName" 
                SortExpression="masterKeywordName" />
            <asp:BoundField DataField="customKeywordFirst" HeaderText="customKeywordFirst" 
                SortExpression="customKeywordFirst" />
            <asp:BoundField DataField="customKeywordSecond" 
                HeaderText="customKeywordSecond" SortExpression="customKeywordSecond" />
            <asp:BoundField DataField="customKeywordThird" HeaderText="customKeywordThird" 
                SortExpression="customKeywordThird" />
            <asp:BoundField DataField="clientName" HeaderText="clientName" 
                SortExpression="clientName" />
            <asp:BoundField DataField="jobTypeId" HeaderText="jobTypeId" 
                SortExpression="jobTypeId" />
            <asp:BoundField DataField="jobTypeName" HeaderText="jobTypeName" 
                SortExpression="jobTypeName" />
            <asp:BoundField DataField="refererId" HeaderText="refererId" 
                SortExpression="refererId" />
            <asp:BoundField DataField="refererName" HeaderText="refererName" 
                SortExpression="refererName" />
            <asp:CheckBoxField DataField="isEnable" HeaderText="isEnable" 
                SortExpression="isEnable" />
            <asp:BoundField DataField="adminStatus" HeaderText="adminStatus" 
                SortExpression="adminStatus" />
            <asp:BoundField DataField="fileOpenDate" HeaderText="fileOpenDate" 
                SortExpression="fileOpenDate" />
            <asp:CheckBoxField DataField="releaseToPublic" HeaderText="releaseToPublic" 
                SortExpression="releaseToPublic" />
            <asp:CheckBoxField DataField="isPending" HeaderText="isPending" 
                SortExpression="isPending" />
            <asp:CheckBoxField DataField="isReopen" HeaderText="isReopen" 
                SortExpression="isReopen" />
            <asp:BoundField DataField="refererFee" HeaderText="refererFee" 
                SortExpression="refererFee" />
            <asp:BoundField DataField="discount" HeaderText="discount" 
                SortExpression="discount" />
            <asp:BoundField DataField="masterKeywordId" HeaderText="masterKeywordId" 
                SortExpression="masterKeywordId" />
            <asp:BoundField DataField="introducer" HeaderText="introducer" 
                SortExpression="introducer" />
            <asp:BoundField DataField="logo" HeaderText="logo" SortExpression="logo" />
            <asp:BoundField DataField="outgoingAgentId" HeaderText="outgoingAgentId" 
                SortExpression="outgoingAgentId" />
            <asp:BoundField DataField="remarks" HeaderText="remarks" 
                SortExpression="remarks" />
            <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" 
                SortExpression="CreateDate" />
            <asp:BoundField DataField="UpdateDate" HeaderText="UpdateDate" 
                SortExpression="UpdateDate" />
            <asp:BoundField DataField="CreateByUserId" HeaderText="CreateByUserId" 
                SortExpression="CreateByUserId" />
            <asp:BoundField DataField="UpdateByUserId" HeaderText="UpdateByUserId" 
                SortExpression="UpdateByUserId" />
            <asp:BoundField DataField="putAwayDate" HeaderText="putAwayDate" 
                SortExpression="putAwayDate" />
            <asp:BoundField DataField="putAwayBoxNum" HeaderText="putAwayBoxNum" 
                SortExpression="putAwayBoxNum" />
            <asp:BoundField DataField="putAwayContent" HeaderText="putAwayContent" 
                SortExpression="putAwayContent" />
            <asp:BoundField DataField="agentName" HeaderText="agentName" 
                SortExpression="agentName" />
            <asp:CheckBoxField DataField="islegalAid" HeaderText="islegalAid" 
                SortExpression="islegalAid" />
            <asp:BoundField DataField="ioNumOfRefererM" HeaderText="ioNumOfRefererM" 
                SortExpression="ioNumOfRefererM" />
            <asp:BoundField DataField="refNumOfRefererM" HeaderText="refNumOfRefererM" 
                SortExpression="refNumOfRefererM" />
            <asp:BoundField DataField="SPList" HeaderText="SPList" 
                SortExpression="SPList" />
        </Columns>
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
        ConnectionString="name=RBJLLawFirmDBEntities" 
        DefaultContainerName="RBJLLawFirmDBEntities" EnableFlattening="False" 
        EntitySetName="View_FindMatter" onselecting="EntityDataSource1_Selecting">
    </asp:EntityDataSource>--%>

    </form>
</body>
</html>
