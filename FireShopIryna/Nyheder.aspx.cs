using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Nyheder : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "FireShop: Nyheder";
        Overskrift.InnerText = ConstantClass.nyhederNav;
        // viser 3 seneste nyheder, der sorteres efter dato
        // den nyeste øvest
        Repeater_Nyheder.DataSource = new DB().TagNyheder(db);
        Repeater_Nyheder.DataBind();

    }
}