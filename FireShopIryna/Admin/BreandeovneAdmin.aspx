<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="BreandeovneAdmin.aspx.cs" Inherits="Admin_ProdukterTabel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="row">
            <div class="col-md-12">
                <!--PlaceHolder_ProdukterList start -->
                <asp:PlaceHolder ID="PlaceHolder_ProdukterList" runat="server">
                    <div class="row col-md-12 custyle">
                        <div class="table-responsive">
                            <table id="ProdukterTabel" class="table table-striped custab table-hover">
                                <thead>
                                    <asp:LinkButton ID="LinkButton_AddProdukt" OnClick="LinkButton_AddProdukt_Click"
                                        class="btn btn-xs pull-right" ForeColor="White"
                                        runat="server"><b>+</b>Tiljøj nyt produkt</asp:LinkButton>
                                    <tr>
                                        <th>ID</th>
                                        <th>Mærke</th>
                                        <th>Model</th>
                                        <th>Pris</th>
                                        <th>Beskrivelse</th>
                                        <th>Produktdetaljer</th>
                                        <th>Billeder</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <asp:PlaceHolder ID="PlaceHolder_ProdukterTabel" runat="server">
                                    <asp:Repeater ID="Repeater_ProdukterTabel" ItemType="_Produkt"
                                        OnItemCommand="Repeater_ProdukterTabel_ItemCommand"
                                        runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="topalign"><%# Item.id%></td>
                                                <td class="topalign"><%# Item._Mearke.mearke_navn%></td>
                                                
                                                <td>
                                                    <%# Item.model%>
                                                </td>
                                                <td>
                                                    <%# Item.pris%>
                                                </td>
                                                 <td class="topalign">
                                                    <%# Item.beskrivelse.ToString().Length >= 200 ? Item.beskrivelse.ToString().Substring(0,150) + "..." : Item.beskrivelse.ToString() %>
                                                </td>
                                                <td class="topalign">
                                                    <%# Item.produktdetaljer %>
                                                </td>
                                                <td class="topalign">
                                                 <asp:Image ID="Image_Billede" Width="50" Height="50"
                                                         ImageUrl='<%# Item._Billede !=null ? "../Images/lille/"+ Item._Billede.billede_navn :"~/Images/billede-på-vej.jpg" %>' runat="server" />
                                                </td>
                                                <td class="text-center topalign col-xs-2">
                                                    <asp:HyperLink ID="HyperLink_Ret" CssClass=" btn btn-info btn-xs"
                                                        NavigateUrl='<%# "~/Admin/RetProdukt.aspx?id=" + Item.id   %>'
                                                        runat="server"><span class="glyphicon glyphicon-edit"></span>Ret</asp:HyperLink>
                                                    <asp:LinkButton ID="LinkButton_Slet" 
                                                        class="btn btn-danger btn-xs" runat="server"
                                                        CommandName="Slet" CommandArgument='<%# Item.id %>'
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

