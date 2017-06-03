<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Nyheder.aspx.cs" Inherits="Nyheder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 id="Overskrift" runat="server"></h2>
    <hr />

    <asp:Repeater ID="Repeater_Nyheder" ItemType="_Nyhed" runat="server">
        <ItemTemplate>
            <div class="nyhed">
                <h6><%#Item.overskrift %></h6>
                <asp:LinkButton ID="LinkButton_Frameld" ForeColor="Black" runat="server"><%# " " + Item.dato.ToString("dd.MM.yyyy") %> </asp:LinkButton>
                <article><%# Item.tekst %> </article>

            </div>
            <hr class="rodfarve" />

        </ItemTemplate>
    </asp:Repeater>


</asp:Content>

