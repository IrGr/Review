using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink_Forsiden.Text = ConstantClass.forsideNav;
        HyperLink_Breandeovne.Text = ConstantClass.breandeovneNav;
        HyperLink_Tilbehor.Text = ConstantClass.tilbehorNav;
        HyperLink_Kontakt.Text = ConstantClass.kontaktNav;
        HyperLink_Nyheder.Text = ConstantClass.nyhederNav;

        Label_TilbudOverskrift.Text = ConstantClass.tilbud;


        var billeder = new DB().TagRandomHeaderBilleder(db);
        Repeater_HeaderBillede.DataSource = billeder;
        Repeater_HeaderBillede.DataBind();


    }
 
    protected void Button_Sog_Click(object sender, EventArgs e)
    {
        Response.Redirect("SogningResultat.aspx?sog=" + TextBox_Sog.Text);
    }
    protected void LinkButton_Sog_Click(object sender, EventArgs e)
    {
        Response.Redirect("AvanceretSog.aspx");
    }
}
