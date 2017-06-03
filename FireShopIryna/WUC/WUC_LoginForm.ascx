<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_LoginForm.ascx.cs" Inherits="WUC_WUC_LoginForm" %>
<div class="container">
    <asp:PlaceHolder ID="PlaceHolderLoginForm" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="modal-dialog" style="margin-bottom: 0">
                    <div class="modal-content">
                        <div class="panel-heading">
                            <h3 class="panel-title text-uppercase">Log ind</h3>
                        </div>
                        <div class="panel-body">
                            <div role="form">
                                <fieldset>
                                    <p>
                                        <asp:Label ID="Label_Error" CssClass="Label_Error" Visible="false" runat="server" Text="Label"></asp:Label></p>
                                    <div class="form-group">
                                        <h4>
                                            <asp:Label ID="Label_Brugernavn" runat="server" Text="Brugernavn"></asp:Label></h4>
                                        <asp:TextBox ID="TextBox_Brugernavn" class="form-control input-lg" placeholder="Brugernavn:admin" runat="server"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <h4>
                                            <asp:Label ID="Label_Password" runat="server" Text="Password"></asp:Label></h4>
                                        <asp:TextBox ID="TextBox_Password" class="form-control input-lg" placeholder="Password:1234"
                                            TextMode="Password" name="password" runat="server">
                                        </asp:TextBox>
                                    </div>
                                    <br />
                                    <br />
                                    <asp:Button ID="Button_Login"
                                        class="btn btn-lg pull-right btn-success"
                                        OnClick="Button_Login_Click"
                                        runat="server" Text="Log ind" />
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:PlaceHolder>

</div>
