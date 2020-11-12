<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebApplication1.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Yönetici Sayfasi</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
          <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
      <link href="style.css" type="text/css" rel="stylesheet"/>
    
    
    <style type="text/css">
        .csstable {
            width: 60%;
            margin-left: 20%;
        }
    </style>
    
    
</head>
<body>
    <asp:Label ID="Label1" runat="server" Text="" Width="200px" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" ForeColor="#CC0066"></asp:Label><br/>
    
         <br />
    <form id="form1" runat="server">
     <asp:Button ID="Button1" runat="server" Text="Çıkış" Width="70px" OnClick="Button1_Click" />
    <h1>Yönetici Sayfasına Hoşgeldiniz</h1>
    <section>
        <div>
            <asp:Button ID="btn_kitap_ekle" runat="server" Text="Kitap Ekle" OnClick="btn_kitap_ekle_Click" />
            <asp:Button ID="btn_zaman_atla" runat="server" Text="Zaman Atla" OnClick="btn_zaman_atla_Click" />
            <asp:Button ID="listele" runat="server" Text="Kullanıcı Listele" OnClick="listele_Click1" />
        </div>
         </section>
        <section>
        <div id="panel1" runat="server" class="bosluk_div" style="height: 128px">
          
            <asp:Label ID="lblAdi" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbl1" runat="server" Text="1. Kitap"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="lbl2" runat="server" Text="2. Kitap"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="lbl3" runat="server" Text="3. Kitap"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox>
          
        </div>
            </section>
    <div>
        <br/>
        <table id="kulListele" class="table table-bordered table-striped csstable">
                <thead>
                <tr>
                <th>Kullanıcı ID</th>
                <th>Adı Soyadı</th>
                <th>Kullanıcı Adı</th>
                <th>İşlem</th>
                </tr>
                </thead>
                <tbody>
            <asp:Repeater ID="rptKullanicilar" runat="server" OnItemCommand="rptKullanicilar_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td><%# DataBinder.Eval(Container.DataItem, "kul_id") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "adi_soyadi")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "kul_nick")%></td>
                    <td><asp:LinkButton ID="LinkButton1" runat="server" CssClass=" btn btn-primary btn-sm"  CommandName="Detay" CommandArgument='<%#Eval("kul_id") %>'>Detay</asp:LinkButton></td>
                </tr>
                 <br/>
            </ItemTemplate>
        </asp:Repeater>
                    </tbody>
                    </table>
        </div>
    </form>
</body>
</html>
