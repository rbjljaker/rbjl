<%@ Control Language="C#" AutoEventWireup="true" CodeFile="paging.ascx.cs" Inherits="WebControl_paging" %>
                <div style="text-align: center">
                <table>
                    <tr style="font-size: 14px;">
                        <td align="center">
                            <asp:Label ID="Label1" runat="server" Text="PAGE"></asp:Label>
                            <asp:PlaceHolder ID="phInGridView1" runat="server"></asp:PlaceHolder>
                             <asp:LinkButton  ID="lbFirstPage" runat="server" Font-Size="14px" CommandArgument="First" CommandName="Page" CausesValidation="false">First</asp:LinkButton>
                            <asp:Literal ID="ltlPageLine1" runat="server">   </asp:Literal>
                            <asp:LinkButton  ID="lbPreviousPage" runat="server" Font-Size="14px" CommandArgument="Prev" CommandName="Page" CausesValidation="false">Previous</asp:LinkButton>  
                           <asp:LinkButton ID="lbNextPage" runat="server" Font-Size="14px" CommandArgument="Next" CommandName="Page" CausesValidation="false">Next</asp:LinkButton>
                            <asp:Literal ID="ltlPageLine2" runat="server">   </asp:Literal>
                            <asp:LinkButton ID="lbLastPage" runat="server" Font-Size="14px" CommandArgument="Last" CommandName="Page" CausesValidation="false">Last</asp:LinkButton>
                        </td>
                    </tr>
                </table>
                </div>
 