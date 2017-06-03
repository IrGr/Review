using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TilbudAdmin : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater_TilbudTabel.DataSource = new DB().TagAlleTilbud(db);
        Repeater_TilbudTabel.DataBind();
    }
    protected void LinkButton_AddNyhed_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/NyTilbud.aspx");
    }
    protected void Repeater_TilbudTabel_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Slet")
        {
            // erklærer en variable, hvor gemmer værdien af commandArgument
            int id = Convert.ToInt32(e.CommandArgument);

            // Udtrækker fra DB genrer med id, der er lig med commandArgument
            // få adgang til data i database, der hører til det valgte Id
            var query = db._Tilbuds.Where(t => t.tilbud_id.Equals(id)).Single();

            //Hvis resultat af query er forskellige fra null
            if (query != null)
            {
                db._Tilbuds.DeleteOnSubmit(query);
                try
                {
                    db.SubmitChanges();
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}