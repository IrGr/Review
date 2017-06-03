<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="DefaultAdmin.aspx.cs" Inherits="Admin_DefaultAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h4><i class="glyphicon glyphicon-dashboard"></i>Mit Dashboard</h4>
        <hr />
        <div class="row">
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>Det nyeste produkt</h4>
                    </div>
                    <div class="panel-body">
                        <!--PlaceHolder_Produktstart -->
                        <asp:Repeater ID="Repeater_NyesteProdukt" ItemType="_Produkt" runat="server">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-md-4 col-xs-4">
                                        <asp:Image ID="Image_Prod" CssClass="img-responsive"
                                            ImageUrl='<%# Item._Billede !=null ? "../Images/lille/"+ Item._Billede.billede_navn  :"~/Images/billede-på-vej.jpg" %>' runat="server" />
                                    </div>
                                    <div class="col-md-8 col-xs-8">
                                        <div runat="server">
                                            <p>
                                                <asp:Label ID="Label_ProdVarenr" runat="server" ForeColor="Black" Text='<%# "Kategori: " + Item._Kategori.kategori_navn  %>'></asp:Label>
                                            </p>
                                            <p>
                                                <asp:Label ID="Label_ProdNavn" runat="server" ForeColor="Black" Text='<%# "Navn: "+ Item._Mearke.mearke_navn + " "+ Item.model %>'></asp:Label>
                                            </p>
                                            <p>
                                                <asp:Label ID="Label_ProdPris" runat="server" ForeColor="Black" Text='<%# "Pris: " + Item.pris + " Kr." %>'></asp:Label>
                                            </p>

                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <!--/col-->
            <div class="col-md-6">
                <asp:PlaceHolder ID="PlaceHolder_Tab" runat="server">
                    <div class="table-responsive">
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Nyhed</th>
                                    <th>Dato</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="Repeater_NyhedTab" ItemType="_Nyhed" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Item.nyhed_id%></td>
                                            <td><%# Item.overskrift %></td>
                                            <td><%# Item.dato.ToLongDateString() %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </asp:PlaceHolder>
            </div>
            <!--/col-span-6-->
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>Udløbende tilbud</h4>
                    </div>
                    <div class="panel-body">
                        <asp:PlaceHolder ID="PlaceHolder_Tilbud" runat="server">
                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <thead>
                                        <tr>
                                            <th>Id</th>
                                            <th>Kategori</th>
                                            <th>Produkt</th>
                                            <th>Dato</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater_Tilbud" ItemType="_Tilbud" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Item.tilbud_id%></td>
                                                    <td><%# Item._Produkt._Kategori.kategori_navn%></td>
                                                    <td><%# Item._Produkt._Mearke.mearke_navn + " " +  Item._Produkt.model %></td>
                                                    <td><%# Item.startdato.ToLongDateString() + " - " + Item.startdato.ToLongDateString()  %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </asp:PlaceHolder>
                    </div>
                </div>
            </div>
            <!--/col-span-6-->
        </div>
    </div>



  
</asp:Content>

