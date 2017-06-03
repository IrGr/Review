<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SogningResultat.aspx.cs" Inherits="SogningResultat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Repeater ID="Repeater_AlleProdukterTilMearket" ItemType="_Produkt" runat="server">
        <ItemTemplate>
            <asp:Panel ID="Panel_Produkt" runat="server">
                <div class="row">
                    <div class="col-md-3">
                        <asp:HyperLink ID="HyperLink_BilledeProdukt" NavigateUrl='<%# "~/BestemtProdukt.aspx?id=" + Item.id%>' runat="server">
                            <asp:Image ID="Image_Produkt"
                                ImageUrl='<%# Item.fk_billede_id !=null ? "../Images/lille/"+ Item._Billede.billede_navn :"~/Images/billede-på-vej.jpg" %>'
                                runat="server" />
                        </asp:HyperLink>
                    </div>
                    <div class="col-md-9">
                        <asp:HyperLink ID="HyperLink_NavnProdukt" NavigateUrl='<%# "~/BestemtProdukt.aspx?id=" + Item.id%>' runat="server">
                            <h5 class="rodfarve text-left"><%# Item._Mearke.mearke_navn +" "+ Item.model %></h5>

                        </asp:HyperLink>
                        <p class="text-justify"><%# Item.beskrivelse%></p>
                        <p><%# "Pris: " + String.Format(((Math.Round(Item.pris)==Item.pris)?"{0},-" : "{0:0.00}"),Item.pris) %></p>
                    </div>
                </div>
            </asp:Panel>

        </ItemTemplate>
    </asp:Repeater>


    <asp:Panel ID="Panel_Fejl" Visible="false" runat="server">
        <h2> Der er desværre ikke nogen emner, der matcher dine søgekriterier. </h2>
    </asp:Panel>


</asp:Content>

