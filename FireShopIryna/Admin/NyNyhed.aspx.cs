using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NyNyhed : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_GemNyNyhed_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;

        string overskrift = TextBox_Overskrift.Text;
        string tekst = TextBox_Tekst.Text;

        if (!string.IsNullOrEmpty(overskrift)
            && !string.IsNullOrEmpty(tekst))
        {
          
            _Nyhed nynyhed = new _Nyhed
            {
                overskrift = overskrift,
                tekst = tekst,
                dato = DateTime.Now
            };

            db._Nyheds.InsertOnSubmit(nynyhed);
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Response.Redirect("~/Admin/NyhederAdmin.aspx");
        }
    }

    protected void CustomValidator_TekstValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = string.IsNullOrEmpty(args.Value) || args.Value.Length < 3 ? false : true;
    }

}