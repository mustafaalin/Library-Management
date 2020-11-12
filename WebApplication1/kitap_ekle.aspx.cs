using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Mvc;

namespace WebApplication1
{
    
    public partial class kitap_ekle : System.Web.UI.Page
    {
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KullaniciAdi"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if(Session["KullaniciAdi"].ToString() == "admin")
            {
                txtWelcome.Text = "Hosgeldiniz " + Session["KullaniciAdi"].ToString();
            }
            else
            {
                Response.Redirect("Anasayfa.aspx");
            }
                
        }

        protected void btn_kitap_ekle_Click(object sender, EventArgs e)
        {
            int kontrol = 0;
            if(!txt_isbn.Text.Equals("") && !txt_kitap_adi.Text.Equals("") && !txt_yazar.Text.Equals(""))
            {
                if (txt_isbn.Text.Length != 13)
                {
                    Response.Write("<script>alert('ISBN no yanlis girildi.  13 rakamdan olusmali !')</script>");
                }
                else
                {
                    string isbnKontrol = txt_isbn.Text;
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("SELECT isbn_no FROM books", baglanti);
                    MySqlDataReader mySqlDataReader = komut.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        if (isbnKontrol.Equals(mySqlDataReader.GetString(0))){
                            kontrol++;
                        }
                    }
                    mySqlDataReader.Dispose();
                    komut.Dispose();
                    if (kontrol == 0)
                    {
                        MySqlCommand mySqlCommand = new MySqlCommand("insert into books (isbn_no, book_name, yazar, kul_id) values (@isbn_no, @book_name, @yazar, @kul_id)", baglanti);
                        mySqlCommand.Parameters.AddWithValue("@isbn_no", txt_isbn.Text);
                        mySqlCommand.Parameters.AddWithValue("@book_name", txt_kitap_adi.Text);
                        mySqlCommand.Parameters.AddWithValue("@yazar", txt_yazar.Text);
                        //if(txt_kul_id1.Text != null)
                        //{
                        //    mySqlCommand.Parameters.AddWithValue("@kul_id", txt_kul_id1.Text);
                        //}
                        //else if(txt_kul_id1.Text == null)
                        //{
                        //    mySqlCommand.Parameters.AddWithValue("@kul_id", null);
                        //}
                        mySqlCommand.Parameters.AddWithValue("@kul_id", null);
                        mySqlCommand.ExecuteNonQuery();
                        mySqlCommand.Dispose();
                        baglanti.Dispose();
                        Response.Write("<script>alert('Tebrikler. Kitabi Basariyla Eklediniz.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Eklemek istediğiniz Kitap zaten sistemde mevcut!')</script>");
                    }

                }

            }
            else
            {
                Response.Write("<script>alert('Butun alanlari doldurunuz !')</script>");
            }


        }

        protected void btn_anasayfa_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }
    }
}