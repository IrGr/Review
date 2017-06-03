<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="OpretProdukt.aspx.cs" Inherits="Admin_OpretProdukt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Opret et nyt produkt</h2>
    <hr />
    <asp:Label ID="Label_Besked" runat="server" ForeColor="Red" Text="Label" Visible="false"></asp:Label>
    <!--Navn-->
    <div class="row form-group">
        <asp:Label ID="Label_ModelNavn" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Model navn"></asp:Label>
        <div class="col-md-4">
            <asp:TextBox ID="TextBox_Navn" runat="server" class="form-control" ValidationGroup="Produkt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Navn" runat="server"
                ErrorMessage="Må ikke være tomt!!"
                Text="Må ikke være tomt!! * "
                ControlToValidate="TextBox_Navn"
                Display="Dynamic"
                ForeColor="Red"
                Font-Size="X-Small"
                ValidationGroup="Produkt">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_Navn"
                runat="server"
                ControlToValidate="TextBox_Navn"
                ValidationExpression=".{3,100}"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Skriv et navn! Der skal være min. 3 bogstaver"
                Font-Size="X-Small"
                ValidationGroup="Produkt">
            </asp:RegularExpressionValidator>
        </div>
    </div>

    <!--Pris-->
    <div class="row form-group">
        <asp:Label ID="Label_Pris" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Pris"></asp:Label>
        <div class="col-md-4">
            <asp:TextBox ID="TextBox_Pris" runat="server" class="form-control" ValidationGroup="Produkt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Pris" runat="server"
                ErrorMessage="Må ikke være tomt!!"
                Text="Må ikke være tomt!! * "
                ControlToValidate="TextBox_Pris"
                Display="Dynamic"
                ForeColor="Red"
                Font-Size="X-Small"
                ValidationGroup="Produkt">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_Pris"
                runat="server"
                ControlToValidate="TextBox_Pris"
                ValidationExpression="^\d{0,8}(\.\d{1,4})?$"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Der kan kun være cifre"
                Font-Size="X-Small"
                ValidationGroup="Produkt">
            </asp:RegularExpressionValidator>
        </div>
    </div>

    <!--Beskrivelse-->
    <div class="form-group row">
        <asp:Label ID="Label_Beskrivelse" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Beskrivelse"></asp:Label>
        <div class="col-md-4">
            <asp:TextBox ID="TextBox_Beskrivelse" class="topalign form-control" runat="server" Rows="5" TextMode="MultiLine" ValidationGroup="Produkt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Beskrivelse" runat="server"
                ErrorMessage="Må ikke være tomt!!"
                Text="Må ikke være tomt!! * "
                ControlToValidate="TextBox_Beskrivelse"
                Display="Dynamic"
                ForeColor="Red"
                Font-Size="X-Small"
                ValidationGroup="Produkt">
            </asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator_Beskrivelse"
                runat="server"
                ControlToValidate="TextBox_Beskrivelse"
                OnServerValidate="CustomValidator_TekstValidate"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Skriv tekst. Der skal være min. 3 bogstaver"
                Font-Size="X-Small"
                ValidationGroup="Produkt">
            </asp:CustomValidator>
        </div>
    </div>

    <!--Produktdetaljer-->
    <div class="form-group row">
        <asp:Label ID="Label_Produktdetaljer" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Produktdetaljer"></asp:Label>
        <div class="col-md-4">
            <asp:TextBox ID="TextBox_Produktdetaljer" class="topalign form-control" runat="server" TextMode="MultiLine" Rows="10" ValidationGroup="Produkt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Produktdetaljer" runat="server"
                ErrorMessage="Må ikke være tomt!!"
                Text="Må ikke være tomt!! * "
                ControlToValidate="TextBox_Produktdetaljer"
                Display="Dynamic"
                ForeColor="Red"
                Font-Size="X-Small"
                ValidationGroup="Produkt">
            </asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator_Produktdetaljer"
                runat="server"
                ControlToValidate="TextBox_Produktdetaljer"
                OnServerValidate="CustomValidator_TekstValidate"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Skriv tekst. Der skal være min. 3 bogstaver"
                Font-Size="X-Small"
                ValidationGroup="Produkt">
            </asp:CustomValidator>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!--Kategorier-->
            <div class="form-group row">
                <asp:Label ID="Label_Kategori" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Kategori"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="DropDownList_Kategori" runat="server" OnSelectedIndexChanged="DropDownList_Kategori_SelectedIndexChanged"
                         class="form-control" AutoPostBack="true" ValidationGroup="Produkt"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_DdlKategori" runat="server" ValidationGroup="Produkt"
                        ControlToValidate="DropDownList_Kategori" InitialValue="0" ForeColor="Red" Font-Size="X-Small"
                        ErrorMessage="Vælg en værdi fra listen." Display="Dynamic" />
                </div>
            </div>
            <!--Mærker-->
            <div class="form-group row">
                <asp:Label ID="Label_Mearke" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Mærke"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="DropDownList_Mearke" runat="server" class="form-control" AutoPostBack="true" ValidationGroup="Produkt"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_Mearke" runat="server" ValidationGroup="Produkt"
                        ControlToValidate="DropDownList_Kategori" InitialValue="0" ForeColor="Red" Font-Size="X-Small"
                        ErrorMessage="Vælg en værdi fra listen." Display="Dynamic" />
                </div>
            </div>
        </ContentTemplate>
         <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList_Kategori" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <!--Upload et billede-->
    <div class="form-group row">
        <asp:Label ID="Label_Billede" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text=""></asp:Label>
        <div class="col-md-4">
            <asp:FileUpload ID="FileUpload_Billede" runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_FileUpload"
                ValidationExpression="([a-zA-ZæøåÆØÅ0-9\s_\\.\-:])+(.jpg|.JPG|.png|.PNG|.jpeg|.JPEG|.GIF|.gif)$"
                ControlToValidate="FileUpload_Billede"
                runat="server"
                ForeColor="Red"
                ErrorMessage="Vælg venligst fil i jpg/jpeg/png/gif format"
                Display="Dynamic"
                ValidationGroup="Produkt" />

        </div>
        <asp:Button ID="Button_NytProdukt"
            runat="server"
            CssClass="pull-center btn"
            OnClick="Button_NytProdukt_Click"
            Text="Gem"
            ValidationGroup="Produkt" />
    </div>



</asp:Content>

