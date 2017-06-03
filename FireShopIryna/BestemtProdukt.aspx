<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BestemtProdukt.aspx.cs" Inherits="BestemtProdukt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--Link med oplysninger om det valgte mærke-->
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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

    <asp:Repeater ID="Repeater_BestemtProdukt" ItemType="_Produkt" runat="server">
        <ItemTemplate>
            <div class="row">
                <div class="col-md-2 imageText">
                    <figure>
                        <a data-lightbox="roadtrip" href='<%# Item.fk_billede_id!=null ? "~/Images/stor/" + Item._Billede.billede_navn :"~/Images/billede-på-vej-stor.jpg"   %>'
                            runat="server">
                            <asp:Image ID="Image_Produkt" ImageUrl='<%# Item.fk_billede_id!=null ?  "~/Images/lille/" + Item._Billede.billede_navn :"~/Images/billede-på-vej.jpg" %>' runat="server" />
                        </a>
                    </figure>
                    <figcaption>Klik for stor billede
                    </figcaption>
                </div>
                <div class="col-md-10">
                    <h3 class="rodfarve"><%# Item._Mearke.mearke_navn + " "+ Item.model %></h3>
                    <article><%#Item.beskrivelse %></article>
                    <p><%# "Pris:" + String.Format(((Math.Round(Item.pris)==Item.pris)?"{0},-" : "{0:0.00}"),Item.pris) %></p>

                    <p>Produkt detaljer</p>
                    <!--Viser produkt detaljer, som en liste-->
                    <asp:Repeater ID="Repeater_Tekst" ItemType="System.String" DataSource="<%# Item.produktdetaljer.Split('\n')  %>" runat="server">
                        <HeaderTemplate>
                            <ul class="produktDetaljerList">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <%# Item %>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
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

