<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MLStar.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>關於陌柳星事務所</title>
    <script language="JavaScript" type="text/javascript">
        function doLoad()
        {
            var msg = document.getElementById('<%=hidMsg.ClientID%>').value;
            if (msg != "") {
                alert(msg);
            }
        }
    </script>
    <style>
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        <table id="maintable" style="width:100%" class="mainframe">
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <div style="text-align:center" class="title">
                        陌柳星事務所<br />
                    </div>
                    <br/>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <span>事務所起源：</span><br/><br/>
                    　　1991年冬，陌阿柳駕著飛行器離開陌柳星，開始他的旅途，卻因事故而迫降於蔚藍行星，在身周都是外星人環繞之下，他擬化了外表，暫時成為地球人。<br/><br/>
                    　　在地球生活了些許年頭，陌阿柳十分想念他的陌柳星，還有他的貓貓們，他尤其想念陌柳星的夜晚，那是滿天的星斗與轉瞬即逝的火紅。<br/><br/>
                    　　一個因緣際會之下，陌阿柳成立了他的事務所，並嘗試建立這個網站，專門處裡各種疑難雜症，用以籌措飛行器修理費用與旅費來返回陌柳星。<br/><br/>
                    <br/>

                    <span>關於所長的二三事：</span><br/><br/>
                    　　來自陌柳星的陌阿柳，自從迫降地球後，已經建立在地基地SR00與無線基地SW01，他曾經想要融入地球，卻發現地球很恐怖，目前為了逃離地球而籌措旅費中，近期目標是建立無線基地SW02與在地基地SR01經費籌備。<br/><br/>
                    　　陌阿柳非常喜歡地球上名叫動畫的東西，曾經一天至少要看三小時，對於統稱小說的文章也很有興趣，覺得小方塊很優美。<br/><br/>
                    　　在地球生活的期間，偶爾會擬化成其他人的模樣，或者是去拍攝陌柳星上沒有的景物，最近的興趣大概是學習與撰寫各種神秘的語言吧？<br/><br/>
                    <table style="border-collapse:collapse;border:1px solid black;width:100%" class="content_title_photo">
                        <tr>
                            <td style="vertical-align:text-top;width:100%" colspan="2">
                                <span>所長的小檔案</span><br/>
                            </td>
                        </tr>
                        <tr>
                            <td><img alt="陌阿柳" src="Pic/MLChou.jpg" style="width:90%"/></td>
                            <td style="vertical-align:text-top;width:80%">
                                學名：愁陌柳<br/>
                                俗名：陌阿柳、莫尋柳，又稱小柳((其實大家都隨便叫<br/>
                                興趣：看看動畫吐吐槽，看看小說寫寫文；<br/>
                                　　　夜半獨酌碼程式，夢醒時分來捉蟲。<br/>
                                　　　閒來無事做遊戲，心血來潮做道具；<br/>
                                　　　躺著一顆排球魂，天若晴朗外拍去。<br/>
                                聯絡方式：<br />
                                　　臉書：<a href="https://www.facebook.com/profile.php?id=100000122587591&ref=bookmarks" target="_blank" class="btn_link">FB</a><br />
                                　　噗浪：<a href="https://www.plurk.com/liu3hsu4fen1fei1" target="_blank" class="btn_link">Plurk</a><br />
                                <br/>
                            </td>
                        </tr>
                    </table>
                    <br/>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <br/>
                    <br/>
                </td>
                <td></td>
            </tr>
        </table>
        <br/>
    </div>
    <div>
        <asp:HiddenField ID="hidDirName" runat="server" />
        <asp:HiddenField ID="hidFileName" runat="server" />
        <asp:HiddenField ID="hidMsg" runat="server" />
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
