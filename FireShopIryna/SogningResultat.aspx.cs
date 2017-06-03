using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SogningResultat : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        List<_Produkt> result = new List<_Produkt>();
        if (Request.QueryString.Count > 1 && Request.QueryString["sog"]==null )
        {
            //Vi ved nu at det er en søgning
            string fritext = "";
            decimal maxpris;
            int kategori;
            int mearke;

            // Vi tilskriver søge værdier ud fra betingelser
            // Vi sætter strenge til lowercase uden at tage højde for
            // Lande specifik kode
           
            if (!string.IsNullOrWhiteSpace(Request.QueryString["t"]))
            {
                fritext = Request.QueryString["t"];
            }
            // Min max er tal så her kan vi bare konvertere sikkert
            int.TryParse(Request.QueryString["kat"], out kategori);
            int.TryParse(Request.QueryString["m"], out mearke);
            decimal.TryParse(Request.QueryString["max"], out maxpris);

            var listofProds = new DB().TagAlleProdukter(db);
            SogHelper search = new SogHelper(listofProds);
            result = search.TagResultatAfSogning(kategori,mearke, fritext,  maxpris);

            if (result.Count == 0)
            {
                Panel_Fejl.Visible = true;
            }
        }


        if (Request.QueryString["sog"]!=null)
        {
            string sogord = Request.QueryString["sog"];
            List<string> ordene = new List<string>(sogord.ToLower().Split(' '));
            if (ordene.Count>0)
            {
                result=(from p in db._Produkts
                        join m in db._Mearkes on p.fk_mearke_id equals m.mearke_id
                        select new
                        {
                            Produkt = p,
                            Mearke = m
                        }).ToList()
                        .Where(fm => ordene.Where(o => fm.Produkt.model.ToLower().Contains(o)
                            || fm.Mearke.mearke_navn.ToLower().Contains(o)).FirstOrDefault() != null)
                        .Select(fm=>fm.Produkt).ToList();
            }
            if (result.Count==0)
            {
                Panel_Fejl.Visible = true;
            }
        }

        if (Request.QueryString.Count <= 1 && Request.QueryString["q"] != null)
        {
            result = new DB().TagAlleProdukter(db);
        }


        Repeater_AlleProdukterTilMearket.DataSource = result;
        Repeater_AlleProdukterTilMearket.DataBind();

    }
}