using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RetKontakt : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            int id = 0;
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {


                var oplysninger = db._Kontaktoplysningers.Where(k => k.id.Equals(id)).FirstOrDefault();

                if (oplysninger != null)
                {
                    TextBox_Addresse.Text = oplysninger.adresse;
                    TextBox_Postnr.Text = oplysninger.postnr.ToString();
                    TextBox_Byen.Text = oplysninger.byen;
                    TextBox_Telefon.Text = oplysninger.telefon;
                    TextBox_Email.Text = oplysninger.email;
                }
                else
                {
                    Response.Write("Der opstå en fejl. Prøv igen senere");
                }
            }
            else
            {
                Response.Write("Der opstå en fejl. Prøv igen senere");
            }

        }

    }
    protected void Button_RedKontaktoplysninger_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(TextBox_Addresse.Text) &&
            !string.IsNullOrEmpty(TextBox_Postnr.Text) &&
            !string.IsNullOrEmpty(TextBox_Byen.Text) &&
            !string.IsNullOrEmpty(TextBox_Telefon.Text) &&
            !string.IsNullOrEmpty(TextBox_Email.Text) )
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            //Vores query indeholder værdier fra vores valgte kolonne
            var query = db._Kontaktoplysningers.Where(n => n.id == id).FirstOrDefault();

            //Gem de nye værdier
            query.adresse = TextBox_Addresse.Text;
            query.postnr = Convert.ToInt32(TextBox_Postnr.Text);
            query.byen = TextBox_Byen.Text;
            query.telefon = TextBox_Telefon.Text;
            query.email = TextBox_Email.Text;


            // Prøver at gemme de nye værdier, og inlæsser siden igen 

            try
            {
                db.SubmitChanges();
                Response.Redirect("~/Admin/KontaktAdmin.aspx");
            }
            catch (Exception ex)
            {

                Response.Write("Der opstod en fejl:" + ex.Message);
            }
        }
    }
}