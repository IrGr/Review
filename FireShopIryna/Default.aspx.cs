using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "FireShop: Forsiden";

        Label_VelkommenOverskrift.Text = ConstantClass.velkommen;

        
        //ForsidensIndhold
        Repeater_ForsidensIndhold.DataSource = db._Indholds.ToList();
        Repeater_ForsidensIndhold.DataBind();
    }
}