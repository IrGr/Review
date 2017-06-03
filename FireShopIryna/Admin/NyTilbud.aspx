<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="NyTilbud.aspx.cs" Inherits="Admin_NyTilbud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Opret et nyt tilbud</h2>
    <hr />

    <asp:Label ID="Label_Fejl" runat="server" Visible="false" Text="Label"></asp:Label>
    <!--Produkter-->
    <div class="form-group row">
        <asp:Label ID="Label_Besked" runat="server" Visible="false" Text="Label"></asp:Label>
        <asp:Label ID="Label_Produkt" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Produkt"></asp:Label>
        <div class="col-md-4">
            <asp:DropDownList ID="DropDownList_Produkt" runat="server" class="form-control" AutoPostBack="true" ValidationGroup="Tilbud"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_DdlProdukt" runat="server" ValidationGroup="Tilbud"
                ControlToValidate="DropDownList_Produkt" InitialValue="0" ForeColor="Red" Font-Size="X-Small"
                ErrorMessage="Vælg en værdi fra listen." Display="Dynamic" />
        </div>
    </div>

    <!--Pris-->
    <div class="row form-group">
        <asp:Label ID="Label_Pris" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Pris"></asp:Label>
        <div class="col-md-4">
            <asp:TextBox ID="TextBox_Pris" runat="server" class="form-control" ValidationGroup="Tilbud"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Pris" runat="server"
                ErrorMessage="Må ikke være tomt!!"
                Text="Må ikke være tomt!! * "
                ControlToValidate="TextBox_Pris"
                Display="Dynamic"
                ForeColor="Red"
                Font-Size="X-Small"
                ValidationGroup="Tilbud">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_Pris"
                runat="server"
                ControlToValidate="TextBox_Pris"
                ValidationExpression="^\d{0,8}(\.\d{1,4})?$"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Der kan kun være cifre"
                Font-Size="X-Small"
                ValidationGroup="Tilbud">
            </asp:RegularExpressionValidator>
        </div>
    </div>

    <!--Dato-->
    <div class="row center-block">
        <div class="col-md-6">
            <asp:Label ID="Label_StartDato" runat="server" Text="Label"></asp:Label>
            <asp:Calendar ID="Calendar_StartDato" runat="server"
                OnSelectionChanged="Calendar_StartDato_SelectionChanged">
                <OtherMonthDayStyle ForeColor="Gray"></OtherMonthDayStyle>
            </asp:Calendar>
        </div>
        <div class="col-md-6">
            <asp:Label ID="Label_SlutDato" runat="server" Text="Label"></asp:Label>
            <asp:Calendar ID="Calendar_SlutDato" runat="server" OnSelectionChanged="Calendar_SlutDato_SelectionChanged">
                <OtherMonthDayStyle ForeColor="Gray"></OtherMonthDayStyle>
            </asp:Calendar>
        </div>
    </div>

    <asp:Button ID="Button_GemNyTilbud" runat="server"
        class="col-md-2 col-md-offset-3" OnClick="Button_GemNyTilbud_Click"
        Text="Gem" ValidationGroup="Tilbud" />


</asp:Content>

