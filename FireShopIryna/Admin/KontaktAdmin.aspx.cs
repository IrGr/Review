using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_KontaktAdmin : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater_Kontaktoplysninger.DataSource = new DB().TagKontaktoplysninger(db);
        Repeater_Kontaktoplysninger.DataBind();

        Repeater_Indhold.DataSource = db._Indholds.ToList();
        Repeater_Indhold.DataBind();
    }
}