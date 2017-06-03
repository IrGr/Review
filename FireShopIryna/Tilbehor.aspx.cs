using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tilbehor : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "FireShop: Tilbehør";

        int id = 0;
        int.TryParse(Request.QueryString["id"], out id);
        if (Request.QueryString["id"] == null)
        {
            Overskrift.InnerText = ConstantClass.tilbehorNav;
            Repeater_ProduktMearker.DataSource = db._Mearkes.Where(m => m.fk_kategori_id.Equals(2)).ToList();
            Repeater_ProduktMearker.DataBind();
        }
        else
        {

            var aktuelMearke = db._Mearkes.Where(k => k.mearke_id.Equals(id)).FirstOrDefault();
            Overskrift.InnerText = aktuelMearke.mearke_navn;
            Repeater_AlleProdukterTilMearket.DataSource = db._Produkts.Where(p => p.fk_mearke_id.Equals(id)).ToList();
            Repeater_AlleProdukterTilMearket.DataBind();
        }
    }
}