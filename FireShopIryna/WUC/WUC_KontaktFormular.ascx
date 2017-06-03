<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_KontaktFormular.ascx.cs" Inherits="WUC_WUC_KontaktFormular" %>

<asp:Panel ID="Panel_KontaktFormular" runat="server">


    <div class="form-group">
        <asp:Label ID="Label_Navn" runat="server" Text="Evt. firmanavn"></asp:Label>
        <asp:TextBox ID="TextBox_Navn" runat="server" ValidationGroup="Kontakt"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator_Navn"
            runat="server"
            ControlToValidate="TextBox_Navn"
            ValidationExpression=".{3,100}"
            ForeColor="Red"
            Display="Dynamic"
            ErrorMessage="Der skal være min. 3 bogstaver"
            Font-Size="X-Small"
            ValidationGroup="Kontakt">
        </asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <asp:Label ID="Label_Person" runat="server" Text="Kontaktperson"></asp:Label>
        <asp:TextBox ID="TextBox_Person" runat="server" ValidationGroup="Kontakt"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Person" runat="server"
            ErrorMessage="Må ikke være tom!!"
            Text="Må ikke være tom!! * "
            ControlToValidate="TextBox_Person"
            Display="Dynamic"
            ForeColor="Red"
            Font-Size="X-Small"
            ValidationGroup="Kontakt">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator_Person"
            runat="server"
            ControlToValidate="TextBox_Person"
            ValidationExpression=".{3,100}"
            ForeColor="Red"
            Display="Dynamic"
            ErrorMessage="Skriv dit navn! Der skal være min. 3 bogstaver"
            Font-Size="X-Small"
            ValidationGroup="Kontakt">
        </asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <asp:Label ID="Label_Telefon" runat="server" Text="Telefon"></asp:Label>
        <asp:TextBox ID="TextBox_Telefon" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Tlf" runat="server"
            ErrorMessage="Må ikke være tom!!"
            Text="Må ikke være tom!! * "
            ControlToValidate="TextBox_Telefon"
            Display="Dynamic"
            ForeColor="Red"
            Font-Size="X-Small"
            ValidationGroup="Kontakt">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator_Tlf"
            ControlToValidate="TextBox_Telefon"
            runat="server"
            ForeColor="Red"
            Display="Dynamic"
            Font-Size="X-Small"
            ValidationGroup="Kontakt"
            ErrorMessage="Telefonnummer er ikke gyldigt (Eks:+45 35 35 35 35)"
            ValidationExpression="^((\(?\+45\)?)?)(\s?\d{2}\s?\d{2}\s?\d{2}\s?\d{2})$">
            <%--Pass:(+45) 35 35 35 35 ||| +45 35 35 35 35 ||| 35 35 35 35 ||| 35353535
                    Fail:	(45)35353535 ||| 4535353535--%>
        </asp:RegularExpressionValidator>

    </div>

    <div class="form-group">
        <asp:Label ID="Label_Email" runat="server" Text="E-mail"></asp:Label>
        <asp:TextBox ID="TextBox_Email" runat="server" ValidationGroup="Kontakt"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server"
            ErrorMessage="Må ikke være tom!!"
            Text="Må ikke være tom!! * "
            ControlToValidate="TextBox_Email"
            Display="Dynamic"
            ForeColor="Red"
            Font-Size="X-Small"
            ValidationGroup="Kontakt">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator_Email"
            runat="server"
            ControlToValidate="TextBox_Email"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ForeColor="Red"
            Display="Dynamic"
            ErrorMessage="Skriv din Email! Eks.:bruger@gmail.com"
            Font-Size="X-Small"
            ValidationGroup="Kontakt">
        </asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <asp:Label ID="Label_Besked" runat="server" Text="Spørgsmål"></asp:Label>
        <asp:TextBox ID="TextBox_Besked" TextMode="multiline" runat="server" ValidationGroup="Kontakt"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Besked" runat="server"
            ErrorMessage="Må ikke være tom!!"
            Text="Må ikke være tom!! * "
            ControlToValidate="TextBox_Besked"
            Display="Dynamic"
            ForeColor="Red"
            Font-Size="X-Small"
            ValidationGroup="Kontakt">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator_Besked"
            runat="server"
            ControlToValidate="TextBox_Besked"
            ValidationExpression=".{3,1500}"
            ForeColor="Red"
            Display="Dynamic"
            ErrorMessage="Skriv din besked! Der skal være min. 3 bogstaver"
            Font-Size="X-Small"
            ValidationGroup="Kontakt">
        </asp:RegularExpressionValidator>
    </div>
    <asp:Button ID="Button_NyBesked" OnClick="Button_NyBesked_Click" runat="server" Text="OK" ValidationGroup="Kontakt" />
    
     <p>
        <asp:Label ID="Label_TakBesked" runat="server" 
            Font-Bold="true" ForeColor="Green" Font-Size="X-Small" 
            Text="Tak for din besked. Du hører fra os hurtigst muligt." 
            Visible="false"></asp:Label>
    </p>
</asp:Panel>
