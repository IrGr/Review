using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MasterPageAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Helper.ErLoggetInd())
        {
            HyperLink_Logo.Text = ConstantClass.logo;
            HyperLink_KontaktAdmin.Text = ConstantClass.kontaktNav;
            HyperLink_BreandeovneAdmin.Text = ConstantClass.breandeovneNav;
            HyperLink_TilbehorAdmin.Text = ConstantClass.tilbehorNav;
            HyperLink_Nyheder.Text = ConstantClass.nyhederNav;
            HyperLink_TilbudAdmin.Text = ConstantClass.tilbud;
            Hyperlink_LogUd.Text = ConstantClass.logud;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    /// <summary>
    /// Det aktuelle menupunkt markeres en hover farve 
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    protected string IsCurrent(string page)
    {
        return Request.Url.AbsolutePath.ToLower().EndsWith(page.ToLower()) ? "active" : "";
    }
    protected void Hyperlink_LogUd_Click(object sender, EventArgs e)
    {
        Helper.LogUd();
    }
}
