using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WUC_WUC_Tilbud : System.Web.UI.UserControl
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        List<_Tilbud> tilbud = new DB().TagTilbud(db);

        if (tilbud.Count <= 0)
        {
            Panel_Besked.Visible = true;
            Repeater_TilbudProdukt.Visible = false;
        }
        else
        {
            Repeater_TilbudProdukt.DataSource = new DB().TagTilbud(db);
            Repeater_TilbudProdukt.DataBind();
        }
    }
}