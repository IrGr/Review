<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="NyNyhed.aspx.cs" Inherits="Admin_NyNyhed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h2>Opret en ny nyhed</h2>
    <hr />
    <div class="row form-group">
        <!--Overskrift-->

        <asp:Label ID="Label_Overskrift" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Overskrift"></asp:Label>
        <div class="col-md-4">
            <asp:TextBox ID="TextBox_Overskrift" runat="server" class="form-control" ValidationGroup="nyhed"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Overskrift" runat="server"
                ErrorMessage="Må ikke være tomt!!"
                Text="Må ikke være tom!! * "
                ControlToValidate="TextBox_Overskrift"
                Display="Dynamic"
                ForeColor="Red"
                Font-Size="X-Small"
                ValidationGroup="Nyhed">
            </asp:RequiredFieldValidator>
             <asp:CustomValidator ID="CustomValidator_Text"
                runat="server"
                
                OnServerValidate="CustomValidator_TekstValidate"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Skriv tekst. Der skal være min. 3 bogstaver"
                Font-Size="X-Small"
                ValidationGroup="Nyhed">
            </asp:CustomValidator>
        </div>
    </div>

    <!--Tekst-->
    <div class="form-group row">
        <asp:Label ID="Label_Tekst" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Tekst"></asp:Label>
        <div class="col-md-4">
            <asp:TextBox ID="TextBox_Tekst" class="topalign form-control" runat="server" TextMode="MultiLine" ValidationGroup="Nyhed"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Tekst" runat="server"
                ErrorMessage="Må ikke være tom!!"
                Text="Må ikke være tomt!! * "
                ControlToValidate="TextBox_Tekst"
                Display="Dynamic"
                ForeColor="Red"
                Font-Size="X-Small"
                ValidationGroup="Nyhed">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_Tekst"
                runat="server"
                ControlToValidate="TextBox_Tekst"
                ValidationExpression=".{3,5000}"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Skriv tekst. Der skal være min. 3 bogstaver og max 5000"
                Font-Size="X-Small"
                ValidationGroup="Nyhed">
            </asp:RegularExpressionValidator>

        </div>
    </div>

    <asp:Button ID="Button_GemNyNyhed" runat="server"
        class="col-md-2 col-md-offset-3" OnClick="Button_GemNyNyhed_Click"
        Text="Gem" ValidationGroup="Nyhed" />

</asp:Content>

