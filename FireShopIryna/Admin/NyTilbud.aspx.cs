using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NyTilbud : System.Web.UI.Page
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //opfylder DDL med produkter
            var produkter = new DB().TagAlleProdukter(db);
            new ListeHelper().DDL(produkter, "model", "id", DropDownList_Produkt);
            DropDownList_Produkt.Items.Add(new ListItem("Vælg en værdi", "0"));
            DropDownList_Produkt.SelectedValue = "0";// startværdien


            Calendar_StartDato.SelectedDate = DateTime.Today;
            Calendar_StartDato.VisibleDate = DateTime.Today;

            Calendar_SlutDato.SelectedDate = DateTime.Today;
            Calendar_SlutDato.VisibleDate = DateTime.Today;
        } 
            Calendar_SlutDato.TitleFormat = TitleFormat.Month;
            Calendar_StartDato.TitleFormat = TitleFormat.Month;

            DateTime startdato = Calendar_StartDato.SelectedDate;
            DateTime slutdato = Calendar_SlutDato.SelectedDate;

            Label_StartDato.Text = startdato.ToString("dd.MM.yyyy");
            Label_SlutDato.Text = slutdato.ToString("dd.MM.yyyy");
    }


    protected void Button_GemNyTilbud_Click(object sender, EventArgs e)
    {

        string pris = TextBox_Pris.Text;
        int prodid;
        int.TryParse(DropDownList_Produkt.SelectedValue, out prodid);

        // hvis en af de inputfelter er tomt - viser fejlbesked og hopper ud af metoden(onclick) 
        if (Convert.ToInt32(DropDownList_Produkt.SelectedValue)==0
            || string.IsNullOrEmpty(pris))
        {
            Label_Besked.Visible = true;
            Label_Besked.Text = "Alle felter skal være udfyldt";
            return;
        }
        try
        {
         
            //opreter et nyt produkt
            var nyttilbud = OpretTilbud();

            Response.Redirect("TilbudAdmin.aspx");
        }
        catch (Exception ex)
        {
            Label_Besked.Text = "Der opstår en fejl" + ex.Message;
            Label_Besked.Visible = true;
        }

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
    protected void Calendar_SlutDato_SelectionChanged(object sender, EventArgs e)
    {
        if (Calendar_SlutDato.SelectedDate  < Calendar_StartDato.SelectedDate )
        {
            Calendar_StartDato.SelectedDate = Calendar_SlutDato.SelectedDate;
            Calendar_StartDato.SelectedDate = Calendar_StartDato.SelectedDate;

            DateTime startdato = Calendar_StartDato.SelectedDate;
            Label_StartDato.Text = startdato.ToString("dd.MM.yyyy");
        }
        DateTime slutdato = Calendar_SlutDato.SelectedDate;
        Label_SlutDato.Text = slutdato.ToString("dd.MM.yyyy");
    }




    /// <summary>
    /// Opret et nyt tilbud
    /// </summary>
    /// <returns></returns>
    private _Tilbud OpretTilbud()
    {
        _Tilbud nyttilbud = new _Tilbud();
        nyttilbud.tilbud_pris = Convert.ToDecimal(TextBox_Pris.Text);
        nyttilbud.fk_prod_id = Convert.ToInt32(DropDownList_Produkt.SelectedValue);
        nyttilbud.startdato = Calendar_StartDato.SelectedDate;
        nyttilbud.slutdato = Calendar_SlutDato.SelectedDate;
        db._Tilbuds.InsertOnSubmit(nyttilbud);
        db.SubmitChanges();

        return nyttilbud;
    }
}