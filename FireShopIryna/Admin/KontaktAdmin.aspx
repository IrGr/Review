<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="KontaktAdmin.aspx.cs" Inherits="Admin_KontaktAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <h2>Redigere kontaktoplysninger</h2>
        <hr />
        <asp:PlaceHolder ID="PlaceHolder_Kontaktoplysninger" runat="server">
            <br />
            <div class="col-md-12 custyle">
                <div class="table-responsive">
                    <table class="table table-striped custab table-hover">
                        <thead>
                            <tr>
                                <th>Addresse</th>
                                <th>Postnr</th>
                                <th>Byen</th>
                                <th>Email</th>
                                <th>Telefon</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater_Kontaktoplysninger" ItemType="_Kontaktoplysninger" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="topalign"><%# Item.adresse %></td>
                                    <td class="topalign"><%# Item.postnr %></td>
                                    <td class="topalign"><%# Item.byen %></td>
                                    <td class="topalign"><%# Item.email %></td>
                                    <td class="topalign"><%# Item.telefon %></td>
                                    <td class="text-center topalign">
                                        <asp:LinkButton ID="LinkButton_Ret"
                                            class='btn btn-info btn-xs'
                                            href='<%#"RetKontakt.aspx?id=" + Item.id %>'
                                            runat="server"> 
                                            <span class="glyphicon glyphicon-edit"></span> Ret</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
    <!--/.row-->

    <div class="row">
        <h2>Redigere indhold</h2>
        <hr />
        <asp:PlaceHolder ID="PlaceHolder_Indhold" runat="server">
            <div class="col-md-12 custyle">
                <div class="table-responsive">
                    <table class="table table-striped custab table-hover">
                        <thead>
                            <tr>
                                <th>Tekst</th>
                                <th>Billede</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                        <asp:Repeater ID="Repeater_Indhold" ItemType="_Indhold" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="topalign"><%# Item.tekst %></td>
                                    <td class="topalign">
                                        <asp:Image ID="Image_Billede" Width="100" Height="100"
                                            ImageUrl='<%# Item._Billede.billede_navn !=null ? "../Images/"+ Item._Billede.billede_navn :"~/Images/billede-på-vej.jpg" %>' runat="server" />
                                    </td>
                                    <td class="text-center topalign">
                                        <asp:LinkButton ID="LinkButton_Ret"
                                            class='btn btn-info btn-xs'
                                            href='<%#"RetIndhold.aspx?id=" + Item.id %>'
                                            runat="server"> 
                                            <span class="glyphicon glyphicon-edit"></span> Ret</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </asp:PlaceHolder>
    </div>
    <!--/.row-->
</asp:Content>

