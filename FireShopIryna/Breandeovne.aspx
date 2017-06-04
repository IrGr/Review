<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Breandeovne.aspx.cs" Inherits="Breandeovne" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--Link med oplysninger om det valgte mærke-->
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Beskrivelse" runat="server">
        <ContentTemplate>
            <div id="overskriftBox">
                <div class="linkbutton">
                    <asp:LinkButton ID="LinkButton_MereOmMearke" OnClick="LinkButton_MereOmMearke_Click" runat="server"></asp:LinkButton>
                </div>
                <h2 id="Overskrift" class="overskrift" runat="server"></h2>
            </div>
            <hr class="kontaktoplysninger_info" />
            <asp:Repeater ID="Repeater_BeskrivelseMearke" ItemType="_Mearke" Visible="false" runat="server">
                <ItemTemplate>
                    <article>
                        <%# Item.mearke_beskrivelse %>
                    </article>
                    <hr />
                </ItemTemplate>
            </asp:Repeater>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="LinkButton_MereOmMearke" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>


    <!--Alle mærker-->
    <asp:Repeater ID="Repeater_ProduktMearker" ItemType="_Mearke" runat="server">
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink_ProduktMearke" NavigateUrl='<%# "~/Breandeovne.aspx?id=" + Item.mearke_id%>' runat="server">
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
            <asp:Panel ID="Panel_Produkt" runat="server">
                <div class="row">
                    <div class="col-md-2">
                        <asp:HyperLink ID="HyperLink_BilledeProdukt" NavigateUrl='<%# "~/BestemtProdukt.aspx?id=" + Item.id%>' runat="server">
                            <asp:Image ID="Image_Produkt" Width="65" AlternateText='<%# "Billede af "+Item.model %>'
                                ImageUrl='<%# Item.fk_billede_id !=null ? "../Images/lille/"+ Item._Billede.billede_navn :"~/Images/billede-på-vej.jpg" %>'
                                runat="server" />
                        </asp:HyperLink>
                    </div>
                    <div class="col-md-10">
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



    <asp:PlaceHolder ID="PlaceHolder_UkendtUrl" Visible="false" runat="server">
        <h3>Der skete desværre en fejl</h3>
        <p>
            SIDEN FINDES IKKE
                Vi kunne ikke finde den efterspurgte side. Det kan skyldes, at siden ikke findes, at siden er flyttet eller at linket er skrevet forkert.
        </p>
        <asp:HyperLink ID="HyperLink_LinkTilListe" NavigateUrl="~/Breandeovne.aspx" runat="server">Klik her for at komme til produktliste.</asp:HyperLink>
    </asp:PlaceHolder>

</asp:Content>

