using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace WebApplication1
{
    public partial class admin : System.Web.UI.Page
    {
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=");
        protected void Page_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            
            if (Session["KullaniciAdi"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if(Session["KullaniciAdi"].ToString() == "admin")
            {
                Label1.Text = "Hosgeldiniz " + Session["KullaniciAdi"].ToString();
            }
            else
            {
                Response.Redirect("Anasayfa.aspx");
            }
        }

        protected void listele_Click1(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM kullanicilar;", baglanti);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            adapter.Dispose();
            baglanti.Dispose();

            rptKullanicilar.DataSource = dataTable;
            rptKullanicilar.DataBind();
            //GridView1.DataSource = dataTable;
            //GridView1.DataBind();
            dataTable.Dispose();
        }

        protected void btn_kitap_ekle_Click(object sender, EventArgs e)
        {
            Response.Redirect("kitap_ekle.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void rptKullanicilar_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=");
            int kulId = -1;
            //string kitap_kulID = null;
            //DateTime verisTarihi;
            //Int64 isbn;
            int kitapAdet = 0;
            string AdiSoyadi;
            ArrayList kitaplar = new ArrayList();
            ArrayList textBox = new ArrayList();

            if (e.CommandName.Equals("Detay"))
            {
                panel1.Visible = true;
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                //Response.Write("<script>alert('Detay ...')</script>");
                baglanti.Open();

                int line = (e.Item.ItemIndex);
                kulId = Convert.ToInt32(e.CommandArgument);
                //Response.Write(kulId.ToString());

                

                MySqlCommand komut = new MySqlCommand("SELECT adi_soyadi, kitap_adet FROM kullanicilar WHERE kul_id=" + kulId, baglanti);
                MySqlDataReader mySqlDataReader = komut.ExecuteReader();
                mySqlDataReader.Read();
                if (!mySqlDataReader.IsDBNull(0))
                {
                    AdiSoyadi = mySqlDataReader.GetString(0);
                    lblAdi.Text = " '" +AdiSoyadi+"' üstündeki kitaplar" ;
                }
                else
                {
                    Response.Write("<script>alert('ADİ SOYADİ OKUNMADI ') </script>");
                }
                if (!mySqlDataReader.IsDBNull(1))
                {
                    kitapAdet = Convert.ToInt32(mySqlDataReader.GetString(1)); // kitap adet varsayılan 0
                }
                else
                {
                    Response.Write("<script>alert('kitap adet okunmadi ') </script>");
                }

                mySqlDataReader.Dispose();
                baglanti.Dispose();
                baglanti.Open();

                MySqlCommand komut1 = new MySqlCommand("SELECT book_name FROM books WHERE kul_id= " + kulId, baglanti);
                MySqlDataReader mySqlDataReader1 = komut1.ExecuteReader();
                if (mySqlDataReader1.Read())
                {
                    if (mySqlDataReader1.IsDBNull(0))
                    {
                        Response.Write("kitap yok!  ");
                    }
                    else if (!mySqlDataReader1.IsDBNull(0))
                    {
                        do
                        {
                            //Response.Write("<script>alert('kitap: " + mySqlDataReader1.GetString(0)+ "')</script>");
                            kitaplar.Add(mySqlDataReader1.GetString(0));

                        } while (mySqlDataReader1.Read());
                    }
                }
                
                if(kitaplar.Count == 1)
                {
                    TextBox1.Text = kitaplar[0].ToString();
                }
                else if(kitaplar.Count == 2)
                {
                    TextBox1.Text = kitaplar[0].ToString();
                    TextBox2.Text = kitaplar[1].ToString();
                }
                else if(kitaplar.Count == 3)
                {
                    TextBox1.Text = kitaplar[0].ToString();
                    TextBox2.Text = kitaplar[1].ToString();
                    TextBox3.Text = kitaplar[2].ToString();
                }
                else
                {
                    panel1.Visible = false;
                    Response.Write("<script>alert('Kisinin üstünde kitap yok!')</script>");
                }

                //while (!mySqlDataReader1.IsDBNull(0))
                //{
                //    Response.Write("<script>alert('while ...')</script>");
                //    TextBox2.Text = (mySqlDataReader1.GetString(0));

                //}
                //for(int i =0; i<kitaplar.Count; i++)
                //{
                //    TextBox1.Text = kitaplar[i].ToString();
                //}
                //string kitapAdi = mySqlDataReader1.GetString(0);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void btn_zaman_atla_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZamanAtla.aspx");
        }
    }
}