<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kitap_ekle.aspx.cs" Inherits="WebApplication1.kitap_ekle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Kitap Ekle</title>
<link href="style.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <div>
        <asp:Label ID="txtWelcome" runat="server" Width="200px" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" ForeColor="#CC0066"></asp:Label>
    </div>
    <h1>KİTAP EKLE</h1>
    <section>
         <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" runat="server"/> <br /><br />
        <asp:TextBox CssClass="textBox" ID="txt_kitap_adi" runat="server" placeholder="Kitap Adı" Width="90%"></asp:TextBox>
        <asp:TextBox CssClass="textBox" ID="txt_yazar" runat="server" placeholder="Yazar" Width="90%"></asp:TextBox>
        <asp:TextBox CssClass="textBox" ID="txt_isbn" runat="server" placeholder="ISBN NO" TextMode="number" Width="90%"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btn_kitap_ekle" runat="server" Text="Kitap Ekle" OnClick="btn_kitap_ekle_Click"/><br /><br />
             <asp:Button ID="btn_anasayfa" runat="server" Text="Anasayfaya Dön" OnClick="btn_anasayfa_Click" />
         </form>
    </section>

</body>
</html>

