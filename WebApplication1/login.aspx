<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Kütüphane Uygulaması</title>

<link href="style.css" type="text/css" rel="stylesheet"/>


</head>
<body>
<h1>HOŞGELDİNİZ</h1>
<section>
    <form id="form1" runat="server">
        <asp:TextBox CssClass="textBox" ID="txtKullaniciAdi" runat="server" placeholder="Kullanıcı Adı"></asp:TextBox>
        <asp:TextBox CssClass="textBox" ID="txtSifre" runat="server" placeholder="Şifre"></asp:TextBox><br />
        <asp:Button ID="btn_giris" runat="server" Text="Giriş Yap" OnClick="btn_giris_Click" />
        <asp:Button ID="btn_kayit" runat="server" Text="Kayıt Ol" OnClick="btn_kayit_Click" />
    </form>
</section>

</body>
</html>
