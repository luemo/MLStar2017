<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MLStar.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>歡迎光臨陌柳星事務所</title>
    <script language="JavaScript" type="text/javascript">
        function doLoad()
        {
        }
    </script>
    <style>
        #Div_Top{
            position: absolute;
            top: 50%;
            left:50%;
            transform:translate(-50%,-50%);
        }
        .btn_link{/*目錄連結*/
            color:dodgerblue;
            background: rgba(238%, 241%, 0%, 0.7);
            border-radius: 10px;
            text-decoration:none;
        }
    </style>
</head>
<body style="background-image:url(/Pic/background_H.jpg);vertical-align:middle" onload="doLoad()">
    <form id="form1" runat="server">
    <div id="Div_Top">
        <table style="text-align:center;width: 100%;">
            <tr>
                <td>
                    <h1>歡迎光臨陌柳星事務所</h1>
                    <br />
                    <br />
                    <br />
                    委託事務請走這邊→ <a href="https://www.facebook.com/profile.php?id=100000122587591&ref=bookmarks" target="_blank" class="btn_link">FB</a>、<a href="https://www.plurk.com/liu3hsu4fen1fei1" target="_blank" class="btn_link">Plurk</a><br />
                    <br />
                    事務所介紹→ 關於<a href="About.aspx" target="_self" class="btn_link">陌柳星事務所</a><br />
                    <br />
                    本事務所提供之相關服務<br />
                    <div style="text-align:center">
                        <br />
                        <asp:HyperLink ID="LinkPhote" runat="server" NavigateUrl="~/Photo.aspx" class="btn_link">相簿</asp:HyperLink>、<asp:HyperLink 
                            ID="LinkGame" runat="server" NavigateUrl="~/Game.aspx" class="btn_link">遊戲</asp:HyperLink>、<asp:HyperLink 
                                ID="LinkNovel" runat="server" NavigateUrl="~/Novel.aspx" class="btn_link">小說</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="LinkLyrics" runat="server" NavigateUrl="~/Lyrics.aspx" class="btn_link">填詞</asp:HyperLink>、<asp:HyperLink 
                            ID="LinkWritings" runat="server" NavigateUrl="~/Writings.aspx" class="btn_link">雜記</asp:HyperLink>、<asp:HyperLink 
                                ID="LinkAbout" runat="server" NavigateUrl="~/About.aspx" class="btn_link">陌柳星事務所</asp:HyperLink>
                        <br />
                    </div>
                    <br />
                    <br />
                    再次感謝您光臨陌柳星事務所
                    <div style="text-align:right">
                        所長　愁陌柳
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
