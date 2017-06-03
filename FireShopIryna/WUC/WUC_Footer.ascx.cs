using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WUC_WUC : System.Web.UI.UserControl
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater_Kontaktoplysninger.DataSource = db._Kontaktoplysningers.ToList();
        Repeater_Kontaktoplysninger.DataBind();
    }
}