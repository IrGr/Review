using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Breandeovne : System.Web.UI.Page
{
    private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "FireShop: Brændeovne";

        int id = 0;
        int.TryParse(Request.QueryString["id"], out id);
        if (Request.QueryString["id"] == null)
        {
            Overskrift.InnerText = ConstantClass.breandeovneNav;
            Repeater_ProduktMearker.DataSource = db._Mearkes.Where(m => m.fk_kategori_id.Equals(1)).ToList();
            Repeater_ProduktMearker.DataBind();
        }
        else
        {
            var aktuelMearke = db._Mearkes.Where(k => k.mearke_id.Equals(id)).FirstOrDefault();
            if (aktuelMearke != null)
            {
                Overskrift.InnerText = aktuelMearke.mearke_navn;
                LinkButton_MereOmMearke.Text = "<span class='glyphicon glyphicon-play'></span>" + aktuelMearke.mearke_navn + " firma profil";
                this.Title = "FireShop: Brændeovne " + aktuelMearke.mearke_navn;

                Repeater_AlleProdukterTilMearket.DataSource = db._Produkts.Where(p => p.fk_mearke_id.Equals(id)).ToList();
                Repeater_AlleProdukterTilMearket.DataBind();
            }
            else
            {
                PlaceHolder_UkendtUrl.Visible = true;
            }
        }
    }
    protected void LinkButton_MereOmMearke_Click(object sender, EventArgs e)
    {
        int id = 0;
        int.TryParse(Request.QueryString["id"], out id);

        if (Repeater_BeskrivelseMearke.Visible == false)
        {
            Repeater_BeskrivelseMearke.Visible = true;
            Repeater_BeskrivelseMearke.DataSource = db._Mearkes.Where(k => k.mearke_id.Equals(id)).ToList();
            Repeater_BeskrivelseMearke.DataBind();
        }
        else
        {
            Repeater_BeskrivelseMearke.Visible = false;
        }
    }
}