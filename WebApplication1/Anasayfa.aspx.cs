using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.Common;

namespace WebApplication1
{
    public partial class user : System.Web.UI.Page
    {
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=");
        protected void Page_Load(object sender, EventArgs e)
        {
            //DateTime time;
            //time = time.ToUniversalTime();
            if(Session["KullaniciAdi"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                txtWelcome.Text = "Hosgeldiniz " + Session["KullaniciAdi"].ToString();
            }
        }

        protected void btn_kitap_ara0_Click(object sender, EventArgs e)
        {
            String arananKitap;
            String arananISBN;
            arananKitap = txt_KitapAra.Text;
            arananISBN = txt_isbnAra.Text;
            if (!txt_KitapAra.Text.Equals(""))
            {
                MySqlDataAdapter adapter1 = new MySqlDataAdapter("SELECT * FROM books WHERE book_name LIKE '" + "%" + arananKitap + "%" + "';", baglanti);
                DataTable dataTable = new DataTable();
                adapter1.Fill(dataTable);
                adapter1.Dispose();
                baglanti.Dispose();

                rptKitaplar.DataSource = dataTable;
                rptKitaplar.DataBind();
                //GridView1.DataSource = dataTable;
                //GridView1.DataBind();
                dataTable.Dispose();
            }else if(txt_KitapAra.Text.Equals("") && !txt_isbnAra.Text.Equals(""))
            {
                MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT * FROM books WHERE isbn_no LIKE '" + "%" + arananISBN + "%" + "';", baglanti);
                DataTable dataTable = new DataTable();
                adapter2.Fill(dataTable);
                adapter2.Dispose();
                baglanti.Dispose();

                rptKitaplar.DataSource = dataTable;
                rptKitaplar.DataBind();
                //GridView1.DataSource = dataTable;
                //GridView1.DataBind();
                dataTable.Dispose();


            }
            else
            {
                Response.Write("<script>alert('Lutfen en az bir deger giriniz !')</script>");
            }
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int secilen = GridView1.SelectedIndex;
            //GridViewRow row = GridView1.Rows[secilen];
            //string abc = row.Cells[0].ToString();
            //TextBox2.Text = row.Cells[1].Text;
            //TextBox3.Text = row.Cells[2].Text; 
            //Response.Write("<script>alert('"+ abc+"') </script>");
            

        }

        protected void rptKitaplar_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd=");
            int kulId = -1;
            string kitap_kulID = null;
            DateTime verisTarihi;
            Int64 isbn;
            int kitapAdet=0;


            if (e.CommandName.Equals("AL"))
            {
                int teslimKontrol = 0;
                baglanti.Open();


                int line = (e.Item.ItemIndex);
                isbn = Convert.ToInt64(e.CommandArgument);
                //Response.Write(isbn.ToString());

                MySqlCommand komut = new MySqlCommand("SELECT kul_id, kitap_adet FROM kullanicilar WHERE kul_nick='" + Session["KullaniciAdi"] + "'", baglanti);
                MySqlDataReader mySqlDataReader = komut.ExecuteReader();
                mySqlDataReader.Read();
                kulId = Convert.ToInt32(mySqlDataReader.GetString(0));
                
                kitapAdet = Convert.ToInt32(mySqlDataReader.GetString(1)); // kitap adet varsayılan 0
                
                komut.Dispose();
                //Kullanıcının üstündeki kitapların Teslim tarihlerini çekiyoruz.
                MySqlCommand komut0 = new MySqlCommand("SELECT veris_tarihi, book_name FROM books WHERE kul_id = "+kulId, baglanti);
                MySqlDataReader mySqlDataReader1 = komut0.ExecuteReader();
                while (mySqlDataReader1.Read())
                {
                    string kitapAdi = mySqlDataReader1.GetString(1);
                    verisTarihi = Convert.ToDateTime(mySqlDataReader1.GetString(0));
                    if (verisTarihi < DateTime.Today)
                    {
                        Response.Write("<script>alert('Üzerinizde teslim tarihi geçmiş kitap var.Lütfen onu teslim ediniz!" +kitapAdi+ "')</script>");
                        teslimKontrol++;
                    }
                    
                }
                baglanti.Dispose();
                if(teslimKontrol == 0) // Kişinin üzerinde teslim tarihi geçen kitap yoksa
                {
                    baglanti.Open();
                    MySqlCommand komut1 = new MySqlCommand("SELECT kul_id, veris_tarihi FROM books WHERE isbn_no='" + isbn + "'", baglanti);
                    MySqlDataReader mySqlDataReader2 = komut1.ExecuteReader();
                    mySqlDataReader2.Read();
                    if (!mySqlDataReader2.IsDBNull(0))
                    {
                        kitap_kulID = mySqlDataReader2.GetString(0);
                    }

                    if (!mySqlDataReader2.IsDBNull(1))
                    {
                        verisTarihi = Convert.ToDateTime((mySqlDataReader2.GetString(1)));
                    }
                    baglanti.Dispose();
                    if (kitapAdet >= 3) // kişide 3 kitap varsa
                    {
                        Response.Write("<script>alert('En fazla 3 Kitap alabilirsiniz!') </script>");
                    }

                    else if (kitap_kulID != null) // kitap birinin üzerindeyse
                    {
                        if (kulId == Convert.ToInt32(kitap_kulID))
                        {
                            Response.Write("<script>alert('Bu kitap zaten şuan sizde!') </script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Bu kitap baskasında olduğu için alamazsınız!') </script>");
                        }
                    }
                    else
                    {
                        kitapAdet++;
                        baglanti.Open();
                        string isbn1 = isbn.ToString();
                        string strAlisT = DateTime.Now.Year.ToString()+"-"+DateTime.Now.Month.ToString()+"-"+DateTime.Now.Day.ToString();
                        //Response.Write("<script>alert('"+strAlisT+"')</script>");
                        string strVerisT = DateTime.Now.AddDays(7).Year.ToString() + "-" + DateTime.Now.AddDays(7).Month.ToString() + "-" + DateTime.Now.AddDays(7).Day.ToString();
                        //Response.Write("<script>alert('" + strVerisT + "')</script>");
                        MySqlCommand komut2 = new MySqlCommand("UPDATE library.books SET kul_id = " + kulId + ", alis_tarihi = '"+strAlisT+"' , veris_tarihi = '"+strVerisT+"' WHERE isbn_no = " + isbn, baglanti);
                        int durum = komut2.ExecuteNonQuery();
                        MySqlCommand komut3 = new MySqlCommand("UPDATE `kullanicilar` SET `kitap_adet` = " + kitapAdet + " WHERE `kullanicilar`.`kul_id` =" + kulId, baglanti);
                        int durum2 = komut3.ExecuteNonQuery();

                        if (durum > 0 && durum2 > 0)
                        {
                            Response.Write("<script>alert('Kitap Başarıyla alındı.\\n"+"Alış tarihi: "+strAlisT+".\\n"+ "Veriş Tarihi: "+strVerisT+" ') </script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Kitap Ekleme Başarısız oldu!') </script>");
                        }
                    }
                }


                baglanti.Dispose();

            }

            if (e.CommandName.Equals("Ver"))
            {
                //Response.Write("<script>alert('VER tıklandı !') </script>");

                baglanti.Open();

                int line = (e.Item.ItemIndex);
                isbn = Convert.ToInt64(e.CommandArgument);
                //Response.Write(isbn.ToString());

                MySqlCommand komut = new MySqlCommand("SELECT kul_id, kitap_adet FROM kullanicilar WHERE kul_nick='" + Session["KullaniciAdi"] + "'", baglanti);
                MySqlDataReader mySqlDataReader = komut.ExecuteReader();
                mySqlDataReader.Read();
                kulId = Convert.ToInt32(mySqlDataReader.GetString(0));
                kitapAdet = Convert.ToInt32(mySqlDataReader.GetString(1)); // kitap adet varsayılan 0
                komut.Dispose();
                mySqlDataReader.Dispose();
                if (kitapAdet == 0)
                {
                    Response.Write("<script>alert('Üzerinizde kitap bulunamadı!') </script>");

                }
                else  // Eğer kişinin üstünde en az bir kitap varsa
                {
                    //Response.Write("<script>alert('En az bir kitap var içine girdi!') </script>");
                    int kontol_Isbn = 0;
                    MySqlCommand komut1 = new MySqlCommand("SELECT isbn_no FROM books WHERE kul_id= " + kulId, baglanti);
                    MySqlDataReader mySqlDataReader1 = komut1.ExecuteReader();
                    //mySqlDataReader1.Read();
                    Int64 kisiISBN;
                    //komut1.Dispose();
                    while (mySqlDataReader1.Read())
                    {
                        //Response.Write("<script>alert('While in içine girdi') </script>");

                        kisiISBN = Convert.ToInt64(mySqlDataReader1.GetString(0));
                        if (isbn == kisiISBN)
                        {
                            kontol_Isbn++;
                            mySqlDataReader1.Dispose();
                            // Eğer kişi üstündeki kitap isbn ile vermek istediği kitap isbn aynı ise
                            MySqlCommand komut2 = new MySqlCommand("UPDATE books SET kul_id = null , alis_tarihi = null , veris_tarihi = null WHERE isbn_no= " + isbn, baglanti);
                            int durum = komut2.ExecuteNonQuery();
                            komut2.Dispose();
                            kitapAdet = kitapAdet - 1; // kullanıcının üstündeki kitap adet sayısı 1 azaltılıyor.
                            MySqlCommand komut3 = new MySqlCommand("UPDATE kullanicilar SET kitap_adet = " + kitapAdet+ " WHERE kul_id= "+kulId, baglanti);
                            int durum2 = komut3.ExecuteNonQuery();
                            komut3.Dispose();

                            if (durum > 0 && durum2 > 0)
                            {
                                Response.Write("<script>alert('Kitap başarılı bir şekilde geri verildi !') </script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Kitap verme İşlemi başarısız !') </script>");
                            }
                            break;
                        }
                    }
                    if (kontol_Isbn == 0)
                    {
                        Response.Write("<script>alert('Bu kitap sizde olmadığı için teslim edemezsiniz !') </script>");
                    }


                    //Response.Write("<script>alert('Üzerinizde kitap var !') </script>");

                }
            }
        }

        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}