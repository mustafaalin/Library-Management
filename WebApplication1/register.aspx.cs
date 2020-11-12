using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_kayit_ol_Click(object sender, EventArgs e)
        {
            if (!txt_kullanici_adi.Text.Equals("") && !txt_nick.Text.Equals("") && !txt_mail.Text.Equals("") && !txt_sifre.Text.Equals("") && !txt_sifre2.Text.Equals(""))
            {
                if (txt_sifre.Text.Equals(txt_sifre2.Text))
                {
                    baglanti.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("insert into kullanicilar (adi_soyadi, kul_nick, kul_mail, kul_pass) values (@adi, @nick, @mail, @pass)", baglanti);
                    mySqlCommand.Parameters.AddWithValue("@adi", txt_kullanici_adi.Text);
                    mySqlCommand.Parameters.AddWithValue("@nick", txt_nick.Text);
                    mySqlCommand.Parameters.AddWithValue("@mail", txt_mail.Text);
                    mySqlCommand.Parameters.AddWithValue("@pass", txt_sifre.Text);
                    mySqlCommand.ExecuteNonQuery();
                    mySqlCommand.Dispose();
                    baglanti.Dispose();
                    Response.Write("<script>alert('Tebrikler. Kaydiniz başarıyla oluşturuldu')</script>");
                    Session["KullaniciAdi"] = txt_nick.Text;
                    Response.Redirect("Anasayfa.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Sifreniz uyusmamaktadir !')</script>");
                }

            }
            else if(txt_kullanici_adi.Text.Equals(""))
            {
                Response.Write("<script>alert('Kullanici adi bos gecilemez !')</script>");
            }
            else if (txt_nick.Text.Equals(""))
            {
                Response.Write("<script>alert('Nick bos gecilemez !')</script>");
            }
            else if (txt_mail.Text.Equals(""))
            {
                Response.Write("<script>alert('Mail adresi bos gecilemez !')</script>");
            }
            else if (txt_sifre.Text.Equals(""))
            {
                Response.Write("<script>alert('Sifre bos gecilemez !')</script>");
            }
            else
            {
                Response.Write("<script>alert('Sifreniz uyusmamaktadir !')</script>");
            }

        }
    }
}