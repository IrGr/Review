using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OpretProdukt : System.Web.UI.Page
{
    private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //opfylder DDL med Kategorier
            var kategorier = new DB().TagKategorier(db);
            new ListeHelper().DDL(kategorier, "kategori_navn", "kategori_id", DropDownList_Kategori);
            DropDownList_Kategori.Items.Add(new ListItem("Vælg en værdi", "0"));
            DropDownList_Kategori.SelectedValue = "0";// startværdien

            //opfylder DDL med mærker
            var mearker = new DB().TagMearker(db);
            new ListeHelper().DDL(mearker, "mearke_navn", "mearke_id", DropDownList_Mearke);
            DropDownList_Mearke.Items.Add(new ListItem("Vælg en værdi", "0"));
            DropDownList_Mearke.SelectedValue = "0";// startværdien

        }
    }
    protected void Button_NytProdukt_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;


        string navn = TextBox_Navn.Text;
        string beskrivelse = TextBox_Beskrivelse.Text;
        string produktdetaljer = TextBox_Produktdetaljer.Text;
        string pris = TextBox_Pris.Text;

        int kategoriid;
        int.TryParse(DropDownList_Kategori.SelectedValue, out kategoriid);

        int mearkeid;
        int.TryParse(DropDownList_Mearke.SelectedValue, out mearkeid);

        // hvis en af de inputfelter er tomt - viser fejlbesked og hopper ud af metoden(onclick) 
        if (string.IsNullOrEmpty(navn)
            || string.IsNullOrEmpty(beskrivelse)
            || string.IsNullOrEmpty(produktdetaljer)
            || string.IsNullOrEmpty(pris)
            || kategoriid == 0
            || mearkeid == 0)
        {
            Label_Besked.Visible = true;
            Label_Besked.Text = "Alle inputfelter skal være udfyldt";

            return;
        }
        try
        {
            //opreter et nyt produkt
            var nytprodukt = OpretProdukt(navn, beskrivelse, produktdetaljer, pris, kategoriid, mearkeid);

            StringBuilder fejlStatus = new StringBuilder();
            //hvis der er nogle billeder i vores FileUpload kontrol,
            //så gemmer vi dem i images mappen og ind i DB
            if (FileUpload_Billede.HasFile)
            {
                string datetimestamp = DateTime.Now.ToFileTime().ToString();

                //sleter billedenavn og tager kun billedeformat 
                string extension = Path.GetExtension(FileUpload_Billede.PostedFile.FileName);
                string fileNavn = datetimestamp + extension;

                //Scalerer og gemmer billedet i mappen

                int countError = 0;
                
                if (nytprodukt.fk_kategori_id == 1)
                {


                    int error = new ImageHelper().MultiThumbUploader(FileUpload_Billede.PostedFile.InputStream, Server.MapPath("~/Images/lille/" + fileNavn), 65, 100, 80L);
                    if (error != 0)
                    {
                        switch (error)
                        {
                            case 1:
                                fejlStatus.AppendLine(FileUpload_Billede.PostedFile.FileName + " filen findes ikke i mappe " + Server.MapPath("~/"));
                                break;
                            case 2:
                                fejlStatus.AppendLine(FileUpload_Billede.PostedFile.FileName + " kan ikke gemmes i størrelse 65*100. Fejlen håndteres ikke");
                                break;
                            default:
                                fejlStatus.AppendLine(FileUpload_Billede.PostedFile.FileName + " kan ikke gemmes i størrelse 65*100. Ukendt fejl");
                                break;
                        }

                        if (File.Exists(Server.MapPath("~/Images/lille/" + fileNavn)))
                        {
                            File.Delete(Server.MapPath("~/Images/lille/" + fileNavn));
                        }
                        countError++;
                    }

                    error = new ImageHelper().MultiThumbUploader(FileUpload_Billede.PostedFile.InputStream, Server.MapPath("~/Images/stor/" + fileNavn), 375, 576, 80L);
                    if (error != 0)
                    {
                        switch (error)
                        {
                            case 1:
                                fejlStatus.AppendLine(FileUpload_Billede.PostedFile.FileName + " filen findes ikke i mappe " + Server.MapPath("~/"));
                                break;
                            case 2:
                                fejlStatus.AppendLine(FileUpload_Billede.PostedFile.FileName + " kan ikke gemmes i størrelse 375*576. Fejlen håndteres ikke");
                                break;
                            default:
                                fejlStatus.AppendLine(FileUpload_Billede.PostedFile.FileName + " kan ikke gemmes i størrelse 375*576. Ukendt fejl");
                                break;
                        }

                        if (File.Exists(Server.MapPath("~/Images/stor/" + fileNavn)))
                        {
                            File.Delete(Server.MapPath("~/Images/stor/" + fileNavn));
                        }
                        countError++;
                    }
                }
                else
                {
                    int error = new ImageHelper().MultiThumbUploader(FileUpload_Billede.PostedFile.InputStream, Server.MapPath("~/Images/lille/" + fileNavn), 100, 82, 80L);
                    if (error != 0)
                    {
                        switch (error)
                        {
                            case 1:
                                fejlStatus.AppendLine(FileUpload_Billede.PostedFile.FileName + " filen findes ikke i mappe " + Server.MapPath("~/"));
                                break;
                            case 2:
                                fejlStatus.AppendLine(FileUpload_Billede.PostedFile.FileName + " kan ikke gemmes i størrelse 100*82. Fejlen håndteres ikke");
                                break;
                            default:
                                fejlStatus.AppendLine(FileUpload_Billede.PostedFile.FileName + " kan ikke gemmes i størrelse 100*82. Ukendt fejl");
                                break;
                        }

                        if (File.Exists(Server.MapPath("~/Images/lille/" + fileNavn)))
                        {
                            File.Delete(Server.MapPath("~/Images/lille/" + fileNavn));
                        }
                        countError++;
                    }
                    FileUpload_Billede.SaveAs(Server.MapPath("~/Images/stor/" + fileNavn));
                }

                if (countError == 0)
                {
                    var billede = GemBilledeDb(fileNavn);

                    nytprodukt.fk_billede_id = billede.billede_id;
                    db.SubmitChanges();
                }
            }

            Label_Besked.Text = fejlStatus.ToString();
            Label_Besked.Visible = true;

            if (nytprodukt.fk_kategori_id == 1)
            {
                Response.Redirect("BreandeovneAdmin.aspx");
            }
            else
            {
                Response.Redirect("TilbehorAdmin.aspx");
            }
        }
        catch (Exception ex)
        {

            Label_Besked.Text = "Der opstår en fejl" + ex.Message;
            Label_Besked.Visible = true;
        }
        finally
        {
            FileUpload_Billede.Dispose();
        }

    }
    protected void DropDownList_Kategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        int katId = 0;
        int.TryParse(DropDownList_Kategori.SelectedValue, out katId);
        var mearker = new DB().TagMearker(db);

        if (katId != 0)
        {
            //opfylder DDL med mærker
            mearker = mearker.Where(m => m.fk_kategori_id.Equals(katId)).ToList();
        }
        new ListeHelper().DDL(mearker, "mearke_navn", "mearke_id", DropDownList_Mearke);
        DropDownList_Mearke.Items.Add(new ListItem("Vælg en værdi", "0"));
        DropDownList_Mearke.SelectedValue = "0";// startværdien

    }


    /// <summary>
    /// Opret et nyt produkt
    /// </summary>
    /// <returns></returns>
    private _Produkt OpretProdukt(string navn, string beskrivelse, string produktdetaljer, string pris, int kategoriid, int mearkeid)
    {
        _Produkt nytprodukt = new _Produkt();
        nytprodukt.model = navn;
        nytprodukt.pris = Convert.ToDecimal(pris);
        nytprodukt.beskrivelse = beskrivelse;
        nytprodukt._Kategori = db._Kategoris.Where(k => k.kategori_id.Equals(kategoriid)).FirstOrDefault();
        nytprodukt._Mearke = db._Mearkes.Where(m => m.mearke_id.Equals(mearkeid)).FirstOrDefault();
        nytprodukt.produktdetaljer = produktdetaljer;
        int? myInt = null;
        nytprodukt.fk_billede_id = myInt;
        db._Produkts.InsertOnSubmit(nytprodukt);
        try
        {
            db.SubmitChanges();
        }
        catch (Exception ex)
        {

            Response.Write("Der opstår en fejl:" + ex.Message);
        }


        return nytprodukt;
    }

    /// <summary>
    /// Opretter et nyt billede i DB
    /// </summary>
    /// <param name="fileNavn"></param>
    /// <returns></returns>
    private _Billede GemBilledeDb(string fileNavn)
    {
        _Billede billede = new _Billede();
        billede.billede_navn = fileNavn;
        db._Billedes.InsertOnSubmit(billede);
        try
        {
            db.SubmitChanges();
        }
        catch (Exception ex)
        {

            Response.Write("Der opstår en fejl:" + ex.Message);
        }
        return billede;
    }

    /// <summary>
    /// Validerer TextBox med Text
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void CustomValidator_TekstValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = string.IsNullOrEmpty(args.Value) || args.Value.Length < 3 ? false : true;
    }

}