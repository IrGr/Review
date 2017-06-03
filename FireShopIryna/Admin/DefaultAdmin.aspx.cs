using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DefaultAdmin : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater_NyesteProdukt.DataSource = db._Produkts.OrderByDescending(p=>p.id).Take(1).ToList();
        Repeater_NyesteProdukt.DataBind();

        Repeater_NyhedTab.DataSource = new DB().TagFemNyheder(db);
        Repeater_NyhedTab.DataBind();

        Repeater_Tilbud.DataSource = db._Tilbuds.OrderByDescending(t => t.slutdato).Take(7).ToList();
        Repeater_Tilbud.DataBind();
    }
}