using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WUC_WUC_LoginForm : System.Web.UI.UserControl
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_Login_Click(object sender, EventArgs e)
    {
    
        string salt = "mad";
        string email = TextBox_Brugernavn.Text;
        string password = Helper.GetMD5Hash(TextBox_Password.Text + salt);

        if (string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(password))
        {
            Label_Error.Text = "Skriv dine brugeroplysninger";
            Label_Error.Visible = true;
            Label_Error.CssClass = "Label_Error";
            return;
        }
        try
        {
            var query = new DB().TagBrugeren(db, email, password);

            Session["id"] = query.bruger_id;
            Session["brugernavn"] = query.brugernavn;


            Response.Redirect("~/Admin/DefaultAdmin.aspx");
        }
        catch (Exception)
        {
            Label_Error.Text = "Den log ind-information, du har angivet, er ikke korekt. Prøv igen!";
            Label_Error.Visible = true;
            Label_Error.CssClass = "Label_Error";
        }
    }
}