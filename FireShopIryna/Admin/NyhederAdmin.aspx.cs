using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NyhederAdmin : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater_NyhederTabel.DataSource = new DB().TagAlleNyheder(db);
        Repeater_NyhederTabel.DataBind();
    }
    protected void LinkButton_AddNyhed_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/NyNyhed.aspx");
    }
    protected void Repeater_NyhederTabel_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Slet")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            //Tager en bestemt nyhed, som har id der er lige med CommandArgument
            var nyheden = db._Nyheds.Where(n => n.nyhed_id.Equals(id)).FirstOrDefault();

            //Hvis resultat af forespørgsel er forskellige fra null
            // sletter data fra tabellen i DB
            if (nyheden != null)
            {
                db._Nyheds.DeleteOnSubmit(nyheden);

                try
                {
                    db.SubmitChanges();
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Der opstod en fejl:" + ex.Message);
                }
            }
        }
    }
}