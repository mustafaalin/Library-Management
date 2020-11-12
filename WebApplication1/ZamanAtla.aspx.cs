using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ZamanAtla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KullaniciAdi"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (Session["KullaniciAdi"].ToString() == "admin")
            {
                Label1.Text = "Hosgeldiniz " + Session["KullaniciAdi"].ToString();
            }
            else
            {
                Response.Redirect("Anasayfa.aspx");
            }
        }
    }
}