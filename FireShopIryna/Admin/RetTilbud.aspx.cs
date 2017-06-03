using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RetTilbud : System.Web.UI.Page
{
    private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;

        if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
        {
            var tilbud = db._Tilbuds.Where(t => t.tilbud_id == id).Single();

            if (tilbud != null)
            {
                if (!IsPostBack)
                {
                    //Opfylder alle vores kontroler 
                    //1.TextBox
                    TextBox_Pris.Text = tilbud.tilbud_pris.ToString();

                    //2. DropDownList
                    //udtrækker alle produkter udskriver dem i DDL
                    var produkter = new DB().TagAlleProdukter(db); ;
                    new ListeHelper().DDL(produkter, "model", "id", DropDownList_Produkt);
                    DropDownList_Produkt.SelectedValue = Convert.ToString(tilbud.fk_prod_id);

                    //3. Calendar
                    Calendar_StartDato.SelectedDate = tilbud.startdato;
                    Calendar_StartDato.VisibleDate = tilbud.startdato;

                    Calendar_SlutDato.SelectedDate = tilbud.slutdato;
                    Calendar_SlutDato.VisibleDate = tilbud.slutdato;
                }

                Calendar_SlutDato.TitleFormat = TitleFormat.Month;
                Calendar_StartDato.TitleFormat = TitleFormat.Month;

                DateTime startdato = Calendar_StartDato.SelectedDate;
                DateTime slutdato = Calendar_SlutDato.SelectedDate;

                Label_StartDato.Text = startdato.ToString("dd.MM.yyyy");
                Label_SlutDato.Text = slutdato.ToString("dd.MM.yyyy");
            }
        }

    }

    /// <summary>
    /// Gemmer Tilbud efter redigering
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_GemTilbud_Click(object sender, EventArgs e)
    {
        int produkt = 0;
        int.TryParse(DropDownList_Produkt.SelectedValue, out produkt);
        decimal nypris = Convert.ToDecimal(TextBox_Pris.Text);

        int id = 0;
        if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
        {
            var tilbud = db._Tilbuds.Where(t => t.tilbud_id == id).FirstOrDefault();
            if (tilbud != null)
            {
                tilbud.tilbud_pris = nypris;
                tilbud._Produkt = db._Produkts.Where(p => p.id.Equals(produkt)).FirstOrDefault();
                tilbud.startdato = Calendar_StartDato.SelectedDate;
                tilbud.slutdato = Calendar_SlutDato.SelectedDate;
                // Prøv at gemme de nye værdier, og inlæs siden igen
                try
                {
                    db.SubmitChanges();
                    Response.Redirect("TilbudAdmin.aspx");
                }
                catch (Exception ex)
                {

                    Response.Write("Der opstod en fejl:" + ex.Message);
                }
            }
        }
    }

    //Når vi vælger en ny dato i calendar - udskriver vi den i Label
    protected void Calendar_SlutDato_SelectionChanged(object sender, EventArgs e)
    {
        
        if (Calendar_SlutDato.SelectedDate < Calendar_StartDato.SelectedDate)
        {
            Calendar_StartDato.SelectedDate = Calendar_SlutDato.SelectedDate;
            Calendar_StartDato.SelectedDate = Calendar_StartDato.SelectedDate;

            DateTime startdato = Calendar_StartDato.SelectedDate;
            Label_StartDato.Text = startdato.ToString("dd.MM.yyyy");
        }
        DateTime slutdato = Calendar_SlutDato.SelectedDate;
        Label_SlutDato.Text = slutdato.ToString("dd.MM.yyyy");
    }
    protected void Calendar_StartDato_SelectionChanged(object sender, EventArgs e)
    {
        if (Calendar_StartDato.SelectedDate > Calendar_SlutDato.SelectedDate)
        {
            Calendar_SlutDato.SelectedDate = Calendar_StartDato.SelectedDate;
            Calendar_SlutDato.SelectedDate = Calendar_SlutDato.SelectedDate;

            DateTime slutdato = Calendar_SlutDato.SelectedDate;
            Label_StartDato.Text = slutdato.ToString("dd.MM.yyyy");
        }


        DateTime startdato = Calendar_StartDato.SelectedDate;
        Label_StartDato.Text = startdato.ToString("dd.MM.yyyy");
    }
}