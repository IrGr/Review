<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kontakt.aspx.cs" Inherits="Kontakt" %>

<%@ Register Src="~/WUC/WUC_KontaktFormular.ascx" TagPrefix="uc1" TagName="WUC_KontaktFormular" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 id="Overskrift" runat="server"></h2>
    <hr />
    <div class="row">
        <div class="col-md-4">
            <div class="row">
                <div class="col-md-12">
                    <asp:Repeater ID="Repeater_Kontaktoplysninger" ItemType="_Kontaktoplysninger" runat="server">
                        <ItemTemplate>
                            <p class="kontaktoplysninger_info"><%# Item.navn %></p>
                            <p class="kontaktoplysninger_info"><%# Item.adresse %></p>
                            <p class="kontaktoplysninger_info"><%# Item.postnr +" "+ Item.byen %></p>
                            <p class="kontaktoplysninger_info"><%# Item.telefon %></p>
                            <p class="kontaktoplysninger_info"><%# Item.email %></p>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-md-12">
                    <uc1:WUC_KontaktFormular runat="server" ID="WUC_KontaktFormular" />
                </div>
            </div>
        </div>
        <div class="col-md-8">
            <asp:Image ID="Image_DanmarkKort" runat="server" />
        </div>
    </div>







</asp:Content>

