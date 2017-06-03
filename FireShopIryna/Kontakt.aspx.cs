using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kontakt : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Overskrift.InnerText = ConstantClass.kontaktNav;
        this.Title = "FireShop: kontakt";

        //Udtrækker kontaktoplysninger ud fra DB og tilknytte Repeater
        Repeater_Kontaktoplysninger.DataSource = db._Kontaktoplysningers.ToList();
        Repeater_Kontaktoplysninger.DataBind();


        var kortbillede = db._Billedes.Where(b=>b.billede_navn.Contains("danmarkskort")).FirstOrDefault();
        Image_DanmarkKort.ImageUrl = "~/Images/" + kortbillede.billede_navn;
    }
}