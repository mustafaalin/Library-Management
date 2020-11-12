<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="WebApplication1.user" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Kullanıcı Sayfası</title>
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
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="txtWelcome" runat="server" Width="200px" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" ForeColor="#CC0066"></asp:Label>
        </div>
        <div class="cikis" >
            <asp:Button ID="btnCikis"  runat="server" Text="Çıkış" OnClick="btnCikis_Click" />
        </div>
        <br />
        <h1>Kullanıcı Sayfası</h1>

        <section>
            <asp:Label ID="Label1" runat="server" Text="Label"> Kitap Ara</asp:Label><br /><br />
            <asp:TextBox CssClass="textBox" ID="txt_KitapAra" placeholder="Kitap Adı" runat="server"></asp:TextBox>
            <br />
            veya<br />
            <asp:TextBox CssClass="textBox" ID="txt_isbnAra" placeholder="ISBN numarası" runat="server"></asp:TextBox>
            <br />
            <asp:Button Width= "30%" ID="btn_kitap_ara" runat="server" Text="Kitap Ara" OnClick="btn_kitap_ara0_Click" />
            <br />
         </section>
        <br />
        <div>
            <br />
            <table class="table table-bordered table-striped csstable">
                <thead>
                <tr>
                <th>ISBN NO</th>
                <th>Kitap Adı</th>
                <th>Yazar</th>
                <th>İşlem</th>
                </tr>
                </thead>
                <tbody>
            <asp:Repeater ID="rptKitaplar" runat="server" OnItemCommand="rptKitaplar_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td><%# DataBinder.Eval(Container.DataItem, "isbn_no") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "book_name")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "yazar")%></td>
                    <td><asp:LinkButton ID="LinkButton1" runat="server" CssClass=" btn btn-primary btn-sm"  CommandName="AL" CommandArgument='<%#Eval("isbn_no") %>'>AL</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass=" btn btn-warning btn-sm"  CommandName="Ver" CommandArgument='<%#Eval("isbn_no") %>'>VER</asp:LinkButton></td>
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
