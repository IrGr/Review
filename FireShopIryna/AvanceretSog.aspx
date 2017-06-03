<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AvanceretSog.aspx.cs" Inherits="AvanceretSog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <h2 id="Overskrift" runat="server"></h2>
    <hr />

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!--Kategorier-->
            <div class="form-group row sogefelte_margin">
                <asp:Label ID="Label_Kategori" CssClass="col-md-1 form-control-label" runat="server" Text="Kategori:"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="DropDownList_Kategori" runat="server" OnSelectedIndexChanged="DropDownList_Kategori_SelectedIndexChanged"
                          AutoPostBack="true" ValidationGroup="AvancSog"></asp:DropDownList>
                   
                </div>
            </div>
            <!--Mærker-->
            <div class="form-group row sogefelte_margin">
                <asp:Label ID="Label_Mearke" CssClass="col-md-1 form-control-label" runat="server" Text="Mærke:"></asp:Label>
                <div class="col-md-4">
                    <asp:DropDownList ID="DropDownList_Mearke" runat="server"  AutoPostBack="true" ValidationGroup="AvancSog"></asp:DropDownList>
                
                </div>
            </div>
        </ContentTemplate>
         <Triggers>
            <asp:AsyncPostBackTrigger ControlID="DropDownList_Kategori" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>

     <!--Pris-->
    <div class="row form-group sogefelte_margin">
        <asp:Label ID="Label_Pris" CssClass="col-md-1 form-control-label" runat="server" Text="Max. pris:"></asp:Label>
        <div class="col-md-4">
            <asp:TextBox ID="TextBox_Pris" runat="server"  ValidationGroup="AvancSog"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_Pris"
                runat="server"
                ControlToValidate="TextBox_Pris"
                ValidationExpression="^\d{0,8}(\.\d{1,4})?$"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Der kan kun være cifre"
                Font-Size="X-Small"
                ValidationGroup="AvancSog">
            </asp:RegularExpressionValidator>
        </div>
    </div>

    <!--FriTekst-->

    <div class="row form-group sogefelte_margin">
        <asp:Label ID="Label_FriTekst" runat="server" CssClass="col-md-1 form-control-label" Text="Søgeord:"></asp:Label>
        <div class="col-md-4">
            <asp:TextBox ID="TextBox_FriTekst" runat="server"  ValidationGroup="AvancSog"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_FriTekst"
                runat="server"
                ControlToValidate="TextBox_FriTekst"
                ValidationExpression=".{3,100}"
                ForeColor="Red"
                Display="Dynamic"
                ErrorMessage="Skriv tekst! Der skal være min. 3 bogstaver"
                Font-Size="X-Small"
                ValidationGroup="AvancSog">
            </asp:RegularExpressionValidator>
        </div>
    </div>
    <asp:Button ID="Button_AvancSog" ValidationGroup="AvancSog" OnClick="Button_AvancSog_Click" runat="server" Text="Søg" />

</asp:Content>

