using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_RetIndhold : System.Web.UI.Page
{
    private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = 0;
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {
                var indhold = db._Indholds.Where(k => k.id.Equals(id)).FirstOrDefault();

                if (indhold != null)
                {
                    TextBox_Tekst.Text = indhold.tekst;
                    Image_Forsiden.ImageUrl = "../Images/" + indhold._Billede.billede_navn;

                }
                else
                {
                    Response.Write("Der opstå en fejl. Prøv igen senere");
                }
            }
            else
            {
                Response.Write("Der opstå en fejl. Prøv igen senere");
            }
        }
    }
    protected void Button_RetIndhold_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return;
        
        if (string.IsNullOrEmpty(TextBox_Tekst.Text))
        {
            return;
        }

        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            //Vores query indeholder værdier fra vores valgte kolonne
            var indhold = db._Indholds.Where(i => i.id == id).FirstOrDefault();

            //Gem de nye værdier
            indhold.tekst = TextBox_Tekst.Text;

            if (FileUpload_Billede.HasFile)
            {
                var gameltBillede = indhold._Billede;
                
                StringBuilder fejlStatus = new StringBuilder();

                string datetimestamp = DateTime.Now.ToFileTime().ToString();
                //sleter billedenavn og tager kun billedeformat 
                string extension = Path.GetExtension(FileUpload_Billede.PostedFile.FileName);
                string fileNavn = "forside" + datetimestamp + extension;

                //Scalerer og gemmer billedet i mappen
                int countError = 0;
                int error = new ImageHelper().MultiThumbUploader(FileUpload_Billede.PostedFile.InputStream, Server.MapPath("~/Images/" + fileNavn), 290, 215, 80L);
                if (error != 0)
                {
                    switch (error)
                    {
                        case 1:
                            fejlStatus.AppendLine(FileUpload_Billede.PostedFile.FileName + " filen findes ikke i mappe " + Server.MapPath("~/"));
                            break;
                        case 2:
                            fejlStatus.AppendLine(FileUpload_Billede.PostedFile.FileName + " kan ikke gemmes i størrelse 290*215. Fejlen håndteres ikke");
                            break;
                        default:
                            fejlStatus.AppendLine(FileUpload_Billede.PostedFile.FileName + " kan ikke gemmes i størrelse 290*215. Ukendt fejl");
                            break;
                    }

                    if (File.Exists(Server.MapPath("~/Images/" + fileNavn)))
                    {
                        File.Delete(Server.MapPath("~/Images/" + fileNavn));
                    }
                    countError++;
                }

                //opretter et nyt billede
                if (countError == 0)
                {
                    string navnAfbillede = indhold._Billede.billede_navn;

                    if (File.Exists(Server.MapPath("~/Images/" + navnAfbillede)))
                    {
                        File.Delete(Server.MapPath("~/Images/" + navnAfbillede));
                    }
                    var billede = GemBilledeDb(fileNavn);
                    indhold._Billede = billede;// db._Billedes.Where(b => b.billede_id.Equals(billede)).FirstOrDefault();

                    db.SubmitChanges(); 

                    db._Billedes.DeleteOnSubmit(gameltBillede);
                }
            }


            db.SubmitChanges();
            Response.Redirect("KontaktAdmin.aspx");
        }
        catch (Exception ex)
        {

            Response.Write("Fejl:" + ex.Message);
        }


    }


    private _Billede GemBilledeDb(string fileNavn)
    {
        _Billede billede = new _Billede();
        billede.billede_navn = fileNavn;
        db._Billedes.InsertOnSubmit(billede);
        db.SubmitChanges();
        return billede;
    }

    protected void CustomValidator_TekstValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = string.IsNullOrEmpty(args.Value) || args.Value.Length < 3 ? false : true;
    }
}