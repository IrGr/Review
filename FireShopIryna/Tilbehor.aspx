<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tilbehor.aspx.cs" Inherits="Tilbehor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h2 id="Overskrift" runat="server"></h2>
    <hr />

    <asp:Repeater ID="Repeater_ProduktMearker" ItemType="_Mearke" runat="server">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink_ProduktMearke" NavigateUrl='<%# "~/Tilbehor.aspx?id=" + Item.mearke_id%>' runat="server">
                <asp:Panel ID="Panel_Type" CssClass="col-md-4 mearkestyle" runat="server">
                    <figure>
                        <asp:Image ID="Image_Mearke"
                            ImageUrl='<%# Item.fk_billede_id !=0 ? "../Images/mearke/"+ Item._Billede.billede_navn :"~/Images/billede-på-vej.jpg" %>' runat="server" />
                        <figcaption class="rodfarve"><%# Item.mearke_navn %></figcaption>
                </asp:Panel>
            </asp:HyperLink>
        </ItemTemplate>
    </asp:Repeater>

    <!--Alle produkter der tilhører til det valgte mærke-->
    <asp:Repeater ID="Repeater_AlleProdukterTilMearket" ItemType="_Produkt" runat="server">
        <ItemTemplate>
            <asp:Panel ID="Panel_Produkt" CssClass="Panel_Produkt" runat="server">
                <div class="row">
                    <div class="col-md-3">
                        <a data-lightbox="roadtrip" href='<%# Item.fk_billede_id!=null ? "~/Images/stor/" + Item._Billede.billede_navn : "~/Images/billede-på-vej-stor.jpg"  %>'
                            runat="server">
                            <asp:Image ID="Image_Produkt"
                                ImageUrl='<%# Item.fk_billede_id !=null ? "../Images/lille/"+ Item._Billede.billede_navn :"~/Images/billede-på-vej.jpg" %>'
                                runat="server" />
                        </a>
                    </div>
                    <div class="col-md-9">
                        <h5 class="rodfarve text-left"><%#  Item.model %></h5>
                        <p class="text-justify"><%# Item.beskrivelse%></p>
                        <p><%# "Pris: " + String.Format(((Math.Round(Item.pris)==Item.pris)?"{0},-" : "{0:0.00}"),Item.pris) %></p>
                    </div>

                </div>
            </asp:Panel>

        </ItemTemplate>
    </asp:Repeater>





</asp:Content>

