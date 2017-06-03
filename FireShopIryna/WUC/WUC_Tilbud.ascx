<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Tilbud.ascx.cs" Inherits="WUC_WUC_Tilbud" %>
<asp:Repeater ID="Repeater_TilbudProdukt" ItemType="_Tilbud" runat="server">
    <ItemTemplate>
        <div class="tilbud">
            <asp:Image ID="Image_TilbudProdukt" CssClass="Panel_TilbudProdukt img"
                ImageUrl='<%# Item._Produkt.fk_billede_id !=null ? "../Images/lille/"+ Item._Produkt._Billede.billede_navn :"~/Images/billede-på-vej.jpg" %>'
                runat="server" />

            <div class="tilbud_beskrivelse">
                <h6><%# Item._Produkt._Mearke.mearke_navn +" "+ Item._Produkt.model %></h6>

                <p><s>Kr.<%#String.Format(((Math.Round(Item._Produkt.pris)==Item._Produkt.pris)?"{0},-" : "{0:0.00}"),Item._Produkt.pris) %></s></p>
                <p class="rodfarve">Kr. <%# String.Format(((Math.Round(Item.tilbud_pris)==Item.tilbud_pris)?"{0},-" : "{0:0.00}"),Item.tilbud_pris)  %></p>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
<asp:Panel ID="Panel_Besked" Visible="false" runat="server">
    <p>
        Vi har desværre ingen varer på tilbud i øjeblikket
    </p>
</asp:Panel>
