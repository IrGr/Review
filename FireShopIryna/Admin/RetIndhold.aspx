<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="RetIndhold.aspx.cs" Inherits="Admin_RetIndhold" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <asp:PlaceHolder ID="PlaceHolder_RedIndhold" runat="server">
            <h2>Redigere forsidens indhold</h2>
            <hr />
            <!--Beskrivelse-->
            <div class="form-group row">
                <asp:Label ID="Label_Beskrivelse" runat="server"
                    CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Beskrivelse"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox ID="TextBox_Tekst" class="topalign form-control" Height="200" Width="500"
                        runat="server" TextMode="MultiLine" ValidationGroup="Indhold"></asp:TextBox>
                </div>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Beskrivelse" runat="server"
                ErrorMessage="Må ikke være tomt!!"
                Text="Må ikke være tom!! * "
                ControlToValidate="TextBox_Tekst"
                Display="Dynamic"
                ForeColor="Red"
                Font-Size="X-Small"
                ValidationGroup="Indhold">
            </asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator_Beskrivelse"
                runat="server"
                OnServerValidate="CustomValidator_TekstValidate"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Skriv tekst. Der skal være min. 3 bogstaver"
                Font-Size="X-Small"
                ValidationGroup="Produkt">
            </asp:CustomValidator>

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
                        ErrorMessage="Vælg venligst valid jpg,png or gif File fil."
                        Display="Dynamic"
                        ValidationGroup="Indhold" />
                </div>
            </div>
            <div class="form-group row">
                <asp:Image ID="Image_Forsiden" Width="200" runat="server" />
            </div>
            <br />
            <div class="form-group row">
                <asp:Button ID="Button_RetIndhold" ValidationGroup="Indhold"
                    CssClass="btn form col-md-offset-5 "
                    OnClick="Button_RetIndhold_Click"
                    runat="server" Text="Redigere" />
            </div>

        </asp:PlaceHolder>
    </div>

</asp:Content>


