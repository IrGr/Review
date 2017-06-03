using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProdukterTabel : System.Web.UI.Page
{
    private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 1;
        Repeater_ProdukterTabel.DataSource = new DB().TagAlleProdukterFraEnKategori(db, id);
        Repeater_ProdukterTabel.DataBind();
    }

    protected void LinkButton_AddProdukt_Click(object sender, EventArgs e)
    {
        Response.Redirect("OpretProdukt.aspx");
    }

    protected void Repeater_ProdukterTabel_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Slet")
        {
            int id = Convert.ToInt32(e.CommandArgument);

            //1. Sletter Produkt_Tilbud relationer
            var tilbud = new DB().TagTilbudTilEtProdukt(db, id);
            foreach (_Tilbud item in tilbud)
            {
                db._Tilbuds.DeleteOnSubmit(item);
            }

            //2.Sletter produkt
            var produkt = new DB().TagEtProdukt(db, id);
            if (produkt!=null)
            {
                 db._Produkts.DeleteOnSubmit(produkt);
            }
           

            //4.Sletter billeder
            var billede = db._Billedes.Where(b => b.billede_id == produkt.fk_billede_id).FirstOrDefault();
            if (billede != null)
            {
                db._Billedes.DeleteOnSubmit(billede);

                File.Delete(Server.MapPath("~/Images/lille/" + billede.billede_navn));
                File.Delete(Server.MapPath("~/Images/stor/" + billede.billede_navn));
            }
            try
            {
                db.SubmitChanges();
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                Response.Write("Der opstod en fejl:" + ex.Message);
            }

        }
    }
}