<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="RetKontakt.aspx.cs" Inherits="Admin_RetKontakt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
     <div class="row">
            <!-- redigere kontaktoplysninger-->
            <asp:PlaceHolder ID="PlaceHolder_RedIndhold" runat="server">
                <h2>Redigere kontaktoplysninger</h2>
                <hr />
                <div class="form-group row">
                    <asp:Label ID="Label_Addresse" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Addresse"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="TextBox_Addresse" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Addresse" runat="server"
                            ErrorMessage="Må ikke være tom!!"
                            Text="Må ikke være tomt!! * "
                            ControlToValidate="TextBox_Addresse"
                            Display="Dynamic"
                            ForeColor="Red"
                            Font-Size="X-Small"
                            CssClass="pull-right"
                            ValidationGroup="RedAddresse">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label ID="Label_Postnr" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Postnr."></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="TextBox_Postnr" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Postnr" runat="server"
                            ErrorMessage="Må ikke være tom!!"
                            Text="Må ikke være tomt!! * "
                            ControlToValidate="TextBox_Postnr"
                            Display="Dynamic"
                            ForeColor="Red"
                            Font-Size="X-Small"
                            CssClass="pull-right"
                            ValidationGroup="RedAddresse">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator_Postnr" 
                             runat="server"
		                     ControlToValidate="TextBox_Postnr"
		                     ErrorMessage="Postnummer må ikke indholde bogstaver" 
                             ForeColor="Red"
		                     ValidationExpression="^[0-9]*$" 
                             ValidationGroup="RedAddresse">*
	                    </asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label ID="Label_Byen" CssClass="col-md-1 col-md-offset-1 form-control-label" runat="server" Text="Byen"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="TextBox_Byen" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Byen" runat="server"
                            ErrorMessage="Må ikke være tomt!!"
                            Text="Må ikke være tom!! * "
                            ControlToValidate="TextBox_Byen"
                            Display="Dynamic"
                            ForeColor="Red"
                            Font-Size="X-Small"
                            CssClass="pull-right"
                            ValidationGroup="RedAddresse">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label ID="Label_Email" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Email"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="TextBox_Email" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server"
                            ErrorMessage="Må ikke være tom!!"
                            Text="Må ikke være tomt!! * "
                            ControlToValidate="TextBox_Email"
                            Display="Dynamic"
                            ForeColor="Red"
                            Font-Size="X-Small"
                            CssClass="pull-right"
                            ValidationGroup="RedAddresse">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator_Email"
                            runat="server"
                            ControlToValidate="TextBox_Email"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ForeColor="Red"
                            Display="Dynamic"
                            ErrorMessage="Skriv din email! Eks. email@gmail.com"
                            Font-Size="X-Small"
                            CssClass="pull-right"
                            ValidationGroup="RedAddresse">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:Label ID="Label_Telefon" runat="server" CssClass="col-md-1 col-md-offset-1 form-control-label" Text="Telefon"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox ID="TextBox_Telefon" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Telefon" runat="server"
                            ErrorMessage="Må ikke være tom!!"
                            Text="Må ikke være tomt!! * "
                            ControlToValidate="TextBox_Telefon"
                            Display="Dynamic"
                            ForeColor="Red"
                            Font-Size="X-Small"
                            CssClass="pull-right"
                            ValidationGroup="RedAddresse">
                        </asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator_Telefon"
                            runat="server"
                            ControlToValidate="TextBox_Telefon"
                            ForeColor="Red"
                            Display="Dynamic"
                            Font-Size="X-Small"
                            CssClass="pull-right"
                            ValidationGroup="RedAddresse"
                            ErrorMessage="Telefonnummer er ikke gyldigt (Eks:+45 35 35 35 35)"
                            ValidationExpression="^((\(?\+45\)?)?)(\s?\d{2}\s?\d{2}\s?\d{2}\s?\d{2})$">
                            <%--Pass:(+45) 35 35 35 35 ||| +45 35 35 35 35 ||| 35 35 35 35 ||| 35353535
                                Fail:	(45)35353535 ||| 4535353535--%>
                        </asp:RegularExpressionValidator>
                     </div>
                </div>
                
                <br />
                <div class="form-group row">
                    <asp:Button ID="Button_RedKontaktoplysninger" ValidationGroup="RedAddresse"
                        CssClass="btn form col-md-offset-5 "
                        OnClick="Button_RedKontaktoplysninger_Click"
                        runat="server" Text="Redigere" />
                </div>

            </asp:PlaceHolder>
        </div>

</asp:Content>

