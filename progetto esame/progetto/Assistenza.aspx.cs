using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;

public partial class Assistenza : System.Web.UI.Page
{
    dbHelper help = new dbHelper();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    
    protected void btnInvia_Click(object sender, EventArgs e)
    {
        help.connetti();
        help.assegnaComando("SELECT Email From Utenti WHERE ID_Utente="+Session["Utente"].ToString());
        rs = help.estraiDati();
        rs.Read();
        string mail = rs["Email"].ToString();
        help.disconnetti();
        try
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("assistenzaprogettoesame@gmail.com", "Assistenza");

            MailMessage email = new MailMessage();

            email.To.Add("assistenzaprogettoesame@gmail.com");
            email.From = new MailAddress(mail);
            email.Subject = txtOggetto.Text;
            email.Body = "Email ricevuta da: "+mail+" "+txtMsg.Text;
            client.Send(email);
            
        }
        catch
        {
            MessageBox.Show("C'è stato un errore nell'invio della mail");
        }


    }

    protected void txtOggetto_TextChanged(object sender, EventArgs e)
    {

    }
}