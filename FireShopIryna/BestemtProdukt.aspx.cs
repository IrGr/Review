using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BestemtProdukt : System.Web.UI.Page
{
    private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;

        if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
        {
            var bestemtProdukt = new DB().TagEtProdukt(db, id);

            if (bestemtProdukt != null)
            {
                Overskrift.InnerText = bestemtProdukt._Mearke.mearke_navn;
                LinkButton_MereOmMearke.Text = "<span class='glyphicon glyphicon-play'></span>" + bestemtProdukt._Mearke.mearke_navn + " firma profil";
                this.Title = "FireShop: Brændeovne " + bestemtProdukt._Mearke.mearke_navn + " " + bestemtProdukt.model;

                List<_Produkt> produktListe = new List<_Produkt>();
                produktListe.Add(bestemtProdukt);
                Repeater_BestemtProdukt.DataSource = produktListe;
                Repeater_BestemtProdukt.DataBind();
            }
            else
            {
                PlaceHolder_UkendtUrl.Visible = true;
            }

        }
        else
        {
            PlaceHolder_UkendtUrl.Visible = true;
        }

    }
    protected void LinkButton_MereOmMearke_Click(object sender, EventArgs e)
    {
        int id = 0;
        int.TryParse(Request.QueryString["id"], out id);
        var bestemtProdukt = new DB().TagEtProdukt(db, id);

        if (Repeater_BeskrivelseMearke.Visible == false)
        {
            Repeater_BeskrivelseMearke.Visible = true;
            Repeater_BeskrivelseMearke.DataSource = db._Mearkes.Where(k => k.mearke_id.Equals(bestemtProdukt.fk_mearke_id)).ToList();
            Repeater_BeskrivelseMearke.DataBind();
        }
        else
        {
            Repeater_BeskrivelseMearke.Visible = false;
        }
    }
}