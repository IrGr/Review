using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RetNyheder : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = 0;
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {
                var nyheden = new DB().TagEnNyhedMedId(db,id); 

                if (nyheden != null)
                {
                    TextBox_Overskrift.Text = nyheden.overskrift;
                    TextBox_Tekst.Text = nyheden.tekst;
                }
                else
                {
                    Label_Fejl.Visible = true;
                    Label_Fejl.Text = "Der opstå en fejl. Prøv igen senere";
                }
            }
            else
            {
                Label_Fejl.Visible = true;
                Label_Fejl.Text = "Der opstå en fejl. Prøv igen senere";
            }

        }
    }
    protected void Button_GemNyhed_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;

        if (!string.IsNullOrEmpty(TextBox_Overskrift.Text) &&
          !string.IsNullOrEmpty(TextBox_Tekst.Text))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            //Vores query indeholder værdier fra vores valgte kolonne
            var nyhed = new DB().TagEnNyhedMedId(db, id); 

            //Gem de nye værdier
            nyhed.overskrift = TextBox_Overskrift.Text;
            nyhed.tekst = TextBox_Tekst.Text;
            nyhed.dato = DateTime.Now;
            
            // Prøver at gemme de nye værdier
            try
            {
                db.SubmitChanges();
                Response.Redirect("~/Admin/NyhederAdmin.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("Der opstod en fejl:" + ex.Message);
            }
        }
    }


    protected void CustomValidator_TekstValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = string.IsNullOrEmpty(args.Value) || args.Value.Length < 3 ? false : true;
    }
}