<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="NyhederAdmin.aspx.cs" Inherits="Admin_NyhederAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="row">
            <div class="col-md-12">
                <!--PlaceHolder_NyhederList start -->
                <asp:PlaceHolder ID="PlaceHolder_NyhederList" runat="server">
                    <div class="row col-md-12 custyle">
                        <div class="table-responsive">
                            <table id="NyhederTabel" class="table table-striped custab table-hover">
                                <thead>
                                    <asp:LinkButton ID="LinkButton_AddNyhed" OnClick="LinkButton_AddNyhed_Click"
                                        class="btn btn-xs pull-right" ForeColor="White" BackColor="Black"
                                        runat="server"><b>+</b>Tiljøj ny nyhed</asp:LinkButton>
                                    <tr>
                                        <th>ID</th>
                                        <th>Overskrift</th>
                                        <th>Tekst</th>
                                        <th>Oprettelsesdato</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <asp:PlaceHolder ID="PlaceHolder_NyhederTabel" runat="server">
                                    <asp:Repeater ID="Repeater_NyhederTabel" ItemType="_Nyhed" 
                                        OnItemCommand="Repeater_NyhederTabel_ItemCommand"
                                         runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="topalign"><%# Item.nyhed_id %></td>
                                                <td class="topalign"><%# Item.overskrift %></td>
                                                <td class="topalign">
                                                    <%# Item.tekst.ToString().Length >= 450 ? Item.tekst.ToString().Substring(0,450) + "..." : Item.tekst.ToString() %>
                                                </td>
                                                <td>
                                                   <%# Item.dato.ToLongDateString() %>
                                                </td>
                                                <td class="text-center topalign col-xs-2">
                                                     <asp:HyperLink ID="HyperLink_Ret" CssClass=" btn btn-info btn-xs"
                                                                       NavigateUrl = '<%# "~/Admin/RetNyheder.aspx?id=" + Item.nyhed_id %>' 
                                                                       runat="server"><span class="glyphicon glyphicon-edit"></span>Ret</asp:HyperLink>
                                                    <asp:LinkButton ID="LinkButton_Slet" class="btn btn-danger btn-xs" runat="server"
                                                                    CommandArgument='<%# Item.nyhed_id %>' CommandName="Slet"
                                                                    OnClientClick="return confirm ('Er du sikker??');">
                                                            <span class="glyphicon glyphicon-remove"></span>Slet</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </asp:PlaceHolder>
                            </table>
                        </div>
                        <%--/.table-responsive--%>
                    </div>
                    <%--/.row col-md-12 custyle--%>
                </asp:PlaceHolder>
            </div>
        </div>

</asp:Content>

