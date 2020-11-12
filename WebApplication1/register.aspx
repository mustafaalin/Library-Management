<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Kütüphane Uygulaması</title>

<link href="style.css" type="text/css" rel="stylesheet"/>


</head>
<body>
    <form id="form1" runat="server">
    <h1>KAYIT OL</h1>
    <section>
        <asp:TextBox CssClass="textBox" ID="txt_kullanici_adi" runat="server" placeholder="Kullanıcı Adı"></asp:TextBox>
        <asp:TextBox CssClass="textBox" ID="txt_nick" runat="server" placeholder="Kullanıcı Nick"></asp:TextBox>
        <asp:TextBox CssClass="textBox" ID="txt_mail" runat="server" placeholder="Mail Adresi" TextMode="Email"></asp:TextBox>
        <asp:TextBox CssClass="textBox" ID="txt_sifre" runat="server" placeholder="Sifreniz" TextMode="Password"></asp:TextBox>
        <asp:TextBox CssClass="textBox" ID="txt_sifre2" runat="server" placeholder="Sifrenizi Onaylayiniz" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="btn_kayit_ol" runat="server" Text="KAYIT OL" OnClick="btn_kayit_ol_Click" />
    </section>
    </form>
</body>
</html>
