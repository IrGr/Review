using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WUC_WUC_KontaktFormular : System.Web.UI.UserControl
{
     private DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_NyBesked_Click(object sender, EventArgs e)
    {
        //string fra = "afsender@xxx.xx";
        //string til = "modtager@xxx.xx";
        //string subjekt = "Hej!";
        //string besked_indhold = TextBox_Kommentar.Text.ToString();

        //MailMessage mailobj = new MailMessage(fra,til,subjekt,besked_indhold);
        //mailobj.IsBodyHtml=true;

        ////SmtpClient benytte de oplysninger, som står i Web.config filens mailSettings
        //// i virkliheden skal der bruges de mail-settings, som matche
        //SmtpClient SMTPServer= new SmtpClient();
        //SMTPServer.Send(mailobj);


        TextBox_Besked.Text = "";
        TextBox_Email.Text = "";
        TextBox_Navn.Text = "";
        TextBox_Telefon.Text = "";
        TextBox_Person.Text = "";
       
        Label_TakBesked.Visible = true;
    }
}