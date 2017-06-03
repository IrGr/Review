<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="TilbudAdmin.aspx.cs" Inherits="Admin_TilbudAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
            <div class="col-md-12">
                <!--PlaceHolder_TilbudList start -->
                <asp:PlaceHolder ID="PlaceHolder_TilbudList" runat="server">
                    <div class="row col-md-12 custyle">
                        <div class="table-responsive">
                            <table id="TilbudTabel" class="table table-striped custab table-hover">
                                <thead>
                                    <asp:LinkButton ID="LinkButton_AddNyhed" OnClick="LinkButton_AddNyhed_Click"
                                        class="btn btn-xs pull-right" ForeColor="White" BackColor="Black"
                                        runat="server"><b>+</b>Tiljøj ny tilbud</asp:LinkButton>
                                    <tr>
                                        <th>ID</th>
                                        <th>Produkt Navn</th>
                                        <th>Før pris</th>
                                        <th>Tilbudspris</th>
                                        <th>Start dato</th>
                                        <th>Slut dato</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <asp:PlaceHolder ID="PlaceHolder_TilbudTabel" runat="server">
                                    <asp:Repeater ID="Repeater_TilbudTabel" ItemType="_Tilbud" 
                                        OnItemCommand="Repeater_TilbudTabel_ItemCommand"
                                         runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="topalign"><%# Item.tilbud_id %></td>
                                                <td class="topalign"><%# Item._Produkt._Mearke.mearke_navn +" "+ Item._Produkt.model %></td>
                                                <td class="topalign">
                                                    <%# Item._Produkt.pris %>
                                                </td>
                                                <td class="topalign">
                                                    <%# Item.tilbud_pris %>
                                                </td>
                                                <td>
                                                   <%# Item.startdato.ToLongDateString() %>
                                                </td>
                                                <td>
                                                   <%# Item.slutdato.ToLongDateString() %>
                                                </td>
                                                <td class="text-center topalign col-xs-2">
                                                     <asp:HyperLink ID="HyperLink_Ret" CssClass=" btn btn-info btn-xs"
                                                                       NavigateUrl = '<%# "~/Admin/RetTilbud.aspx?id=" + Item.tilbud_id %>' 
                                                                       runat="server"><span class="glyphicon glyphicon-edit"></span>Ret</asp:HyperLink>
                                                    <asp:LinkButton ID="LinkButton_Slet" class="btn btn-danger btn-xs" runat="server"
                                                                    CommandArgument='<%# Item.tilbud_id %>' CommandName="Slet"
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

