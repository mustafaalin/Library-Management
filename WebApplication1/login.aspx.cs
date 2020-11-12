using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=");
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Abandon();
        }

        
        protected void btn_kayit_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kulAd = txtKullaniciAdi.Text;
            string kulPass = txtSifre.Text;
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM kullanicilar WHERE kul_nick='"+kulAd+"' and kul_pass='"+kulPass+"';", baglanti);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                
                Session.Add("KullaniciAdi", txtKullaniciAdi.Text);
                //Session.Add("KullaniciPass", txtSifre.Text);
                if (kulAd.Equals("admin"))
                {
                    Response.Redirect("admin.aspx");

                }
                else
                {
                    Response.Redirect("Anasayfa.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Kullanıcı adı veya Parola Yanlış! ')</script>");
            }
        }
    }
}