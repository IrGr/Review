<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_Footer.ascx.cs" Inherits="WUC_WUC" %>
<asp:Repeater ID="Repeater_Kontaktoplysninger" ItemType="_Kontaktoplysninger" runat="server">
    <ItemTemplate>
         <asp:Label ID="Label_FooterInfo" 
             Text= ' <%# Item.navn +" - "+ Item.adresse +" - "+ Item.postnr + " "+ Item.byen +" - "+ Item.telefon +" - "+ Item.email %>' runat="server"></asp:Label>
    </ItemTemplate>
</asp:Repeater>