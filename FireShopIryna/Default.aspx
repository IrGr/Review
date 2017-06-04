<%@ Page Title="Forsiden: City Cykler" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>
        <asp:Label ID="Label_VelkommenOverskrift" runat="server" Text="Label"></asp:Label>
    </h3>
    <hr />
    <asp:Repeater ID="Repeater_ForsidensIndhold" ItemType="_Indhold" runat="server">
        <ItemTemplate>
            <asp:Image ID="Image_Forsiden"
                CssClass="pull-right"
                ImageUrl='<%# "~/Images/" + (Item.fk_billede_id != 0 ? Item._Billede.billede_navn : "billede-på-vej.jpg") %>'
                runat="server" />

            <asp:Repeater ID="Repeater_Tekst" ItemType="System.String" DataSource="<%# Item.tekst.Split('\n')  %>" runat="server">
                <ItemTemplate>
                    <article class="forsideTekst">
                        <%# Item %>
                    </article>
                </ItemTemplate>
            </asp:Repeater>

        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

