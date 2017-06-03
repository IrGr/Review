using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RetProdukt : System.Web.UI.Page
{
    private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {
                var produkt = db._Produkts.Where(p => p.id == id).FirstOrDefault();

                if (produkt != null)
                {

                    //Opfylder alle vores kontroler 
                    //1.TextBox
                    TextBox_Navn.Text = produkt.model;
                    TextBox_Pris.Text = produkt.pris.ToString();
                    TextBox_Beskrivelse.Text = produkt.beskrivelse;
                    TextBox_Produktdetaljer.Text = produkt.produktdetaljer;

                    //2. DropDownList
                    //udtrækker alle kategorier,mærker og udskriver dem i DDL
                    var kategorier = new DB().TagKategorier(db); ;
                    new ListeHelper().DDL(kategorier, "kategori_navn", "kategori_id", DropDownList_Kategori);
                    DropDownList_Kategori.SelectedValue = Convert.ToString(produkt.fk_kategori_id);

                    //opfylder DDL med mærker
                    var mearker = new DB().TagMearker(db);
                    var mearkerTilKategori = mearker.Where(m => m.fk_kategori_id.Equals(produkt.fk_kategori_id)).ToList();
                    new ListeHelper().DDL(mearkerTilKategori, "mearke_navn", "mearke_id", DropDownList_Mearke);
                    DropDownList_Mearke.SelectedValue = Convert.ToString(produkt.fk_mearke_id);// startværdien


                    //3.Image
                    //primBillede Panel
                    var primBilledde = produkt._Billede;

                    //Hvis produkt har et billede
                    // så skal der være mulighed for at slette kun billede
                    // og bagefter kan man vælge et nyt billede

                    // Vi opretter en knap, der er synlig, når der er et billede
                    // og usynlig, når kunstner ikke har et billede
                    if (primBilledde != null)
                    {
                        Image_PrimertBillede.ImageUrl = "../Images/lille/" + primBilledde.billede_navn;
                        Panel_PrimBillede.Visible = true;
                        FileUpload_Billede.Visible = false;
                    }
                    else
                    {
                        FileUpload_Billede.Visible = true;
                        Panel_PrimBillede.Visible = false;
                    }
                }
            }
        }
    }

    protected void DropDownList_Kategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        int katId = 0;
        int.TryParse(DropDownList_Kategori.SelectedValue, out katId);

        if (katId != 0)
        {
            //opfylder DDL med mærker
            var mearker = new DB().TagMearker(db);
            var mearkerTilKategori = mearker.Where(m => m.fk_kategori_id.Equals(katId)).ToList();
            new ListeHelper().DDL(mearkerTilKategori, "mearke_navn", "mearke_id", DropDownList_Mearke);
            DropDownList_Mearke.Items.Add(new ListItem("Vælg en værdi", "0"));
            DropDownList_Mearke.SelectedValue = "0";// startværdien
        }

        else
        {
            var mearker = new DB().TagMearker(db);
            new ListeHelper().DDL(mearker, "mearke_navn", "mearke_id", DropDownList_Mearke);
            DropDownList_Mearke.Items.Add(new ListItem("Vælg en værdi", "0"));
            DropDownList_Mearke.SelectedValue = "0";// startværdien
        }
    }
    protected void Button_SletBillede_Click(object sender, EventArgs e)
    {
        int id = 0;
        int.TryParse(Request.QueryString["id"], out id);
        var produkt = db._Produkts.Where(p => p.id.Equals(id)).SingleOrDefault();
        var billedet = produkt._Billede.billede_navn;
        var billedeId = produkt._Billede.billede_id;

      
        var billede = new DB().TagEtBilledeEfterId(db, billedeId);
        var billederProdukt = db._Produkts.Where(p => p.fk_billede_id.Equals(billedeId)).ToList();
        produkt._Billede = null;


        if (billederProdukt.Count == 1)
        {
            
            try
            {
                if (billedet != null)
                {
                    if (File.Exists(Server.MapPath("~/Images/lille/" + billedet))
                        && File.Exists(Server.MapPath("~/Images/stor/" + billedet)))
                    {
                        File.Delete(Server.MapPath("../Images/lille/" + billedet));
                        File.Delete(Server.MapPath("../Images/stor/" + billedet));
                    }
                }
            }
            catch (Exception ex)
            {
                Label_Fejl.Visible = true;
                Label_Fejl.Text = "Der opstod en fejl: billeder kan ikke slettes" + ex.Message;
            }

            //Sletter info fra billedetabel
            db._Billedes.DeleteOnSubmit(billede);
        }

        try
        {
            db.SubmitChanges();
        }
        catch (Exception ex)
        {
            Label_Fejl.Text = "Der opstod en fejl: " + ex.Message;
            Label_Fejl.Visible = true;

        }

        Response.Redirect(Request.RawUrl);
    }
    protected void Button_GemProdukt_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;

        //gemmer alle textbox.text i variabler 
        string navn = TextBox_Navn.Text;
        string beslrivelse = TextBox_Beskrivelse.Text;
        string produktdetaljer = TextBox_Produktdetaljer.Text;
        string pris = TextBox_Pris.Text;
        int id;
        int.TryParse(Request.QueryString["id"], out id);

        var produktet = new DB().TagEtProdukt(db, id);

        //hvis de er tomme returnerer, går vi af
        if (string.IsNullOrEmpty(navn)
            || string.IsNullOrEmpty(beslrivelse)
            || string.IsNullOrEmpty(pris)
            || Convert.ToInt32(DropDownList_Kategori.SelectedValue) == 0
            || Convert.ToInt32(DropDownList_Mearke.SelectedValue) == 0
            || produktet == null)
        {
            return;
        }

        try
        {
            produktet.model = navn;
            produktet.beskrivelse = beslrivelse;
            produktet.produktdetaljer = produktdetaljer;
            produktet.pris = Convert.ToDecimal(pris);
            produktet.fk_kategori_id = Convert.ToInt32(DropDownList_Kategori.SelectedValue);
            produktet.fk_mearke_id = Convert.ToInt32(DropDownList_Mearke.SelectedValue);

            db.SubmitChanges();

            StringBuilder fejlStatus = new StringBuilder();
            if (FileUpload_Billede.HasFile)
            {
                string datetimestamp = DateTime.Now.ToFileTime().ToString();
                //sleter billedenavn og tager kun billedeformat 
                string extension = Path.GetExtension(FileUpload_Billede.PostedFile.FileName);
                string fileNavn = datetimestamp + extension;

                //Scalerer og gemmer billedet i mappen
                int countError = 0;


                if (produktet.fk_kategori_id == 1)
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

                    produktet.fk_billede_id = billede.billede_id;
                    db.SubmitChanges();
                }
            }


            Label_Besked.Text = fejlStatus.ToString();
            Label_Besked.Visible = true;

            if (produktet.fk_kategori_id == 1)
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
            Response.Write("Der opstod en fejl:" + ex.Message);
        }



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
        db.SubmitChanges();
        return billede;
    }

    /// <summary>
    /// Validere textbox med tekst
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void CustomValidator_TekstValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = string.IsNullOrEmpty(args.Value) || args.Value.Length < 3 ? false : true;
    }
}