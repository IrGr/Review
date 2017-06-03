using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AvanceretSog : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Overskrift.InnerText = ConstantClass.sog;
        this.Title = "FireShop: Avanceret søg";

        if (!IsPostBack)
        {
            //opfylder DDL med Kategorier
            var kategorier = new DB().TagKategorier(db);
            new ListeHelper().DDL(kategorier, "kategori_navn", "kategori_id", DropDownList_Kategori);
            DropDownList_Kategori.Items.Add(new ListItem("-- Vælg --", "0"));
            DropDownList_Kategori.SelectedValue = "0";// startværdien

            //opfylder DDL med mærker
            var mearker = new DB().TagMearker(db);
            new ListeHelper().DDL(mearker, "mearke_navn", "mearke_id", DropDownList_Mearke);
            DropDownList_Mearke.Items.Add(new ListItem("-- Vælg --", "0"));
            DropDownList_Mearke.SelectedValue = "0";// startværdien

        }
    }
    protected void DropDownList_Kategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        int katId = 0;
        int.TryParse(DropDownList_Kategori.SelectedValue, out katId);

        if (katId != 0)
        {
            //opfylder DDL med mærker
            var mearker = new DB().TagMearker(db);
            var mearkerTilKategori = mearker.Where(m => m.fk_kategori_id.Equals(katId)).ToList();
            new ListeHelper().DDL(mearkerTilKategori, "mearke_navn", "mearke_id", DropDownList_Mearke);
            DropDownList_Mearke.Items.Add(new ListItem("Vælg en værdi", "0"));
            DropDownList_Mearke.SelectedValue = "0";// startværdien
        }
        else
        {
            var mearker = new DB().TagMearker(db);
            new ListeHelper().DDL(mearker, "mearke_navn", "mearke_id", DropDownList_Mearke);
            DropDownList_Mearke.Items.Add(new ListItem("Vælg en værdi", "0"));
            DropDownList_Mearke.SelectedValue = "0";// startværdien
        }
    }

    /// <summary>
    /// Konstruerer QueryString
    /// Hvis der er nogen data i kontroller, så skriver vi dem i QueryString
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_AvancSog_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        sb.AppendFormat("/SogningResultat.aspx?q=1{0}", (Convert.ToInt32(DropDownList_Kategori.SelectedValue) != 0) ? "&kat=" + DropDownList_Kategori.SelectedValue : "");
        sb.AppendFormat("{0}", (Convert.ToInt32(DropDownList_Mearke.SelectedValue) != 0) ? "&m=" + DropDownList_Mearke.SelectedValue : "");
        sb.AppendFormat("{0}", (!string.IsNullOrEmpty(TextBox_Pris.Text)) ? "&max=" + TextBox_Pris.Text : "");
        sb.AppendFormat("{0}", (!string.IsNullOrEmpty(TextBox_FriTekst.Text)) ? "&t=" + TextBox_FriTekst.Text : "");
        Response.Redirect(sb.ToString());
    }
}