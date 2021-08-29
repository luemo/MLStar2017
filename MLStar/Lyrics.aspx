<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Lyrics.aspx.cs" Inherits="MLStar.Lyrics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>一曲新詞唱舊愁 - 陌柳星事務所</title>
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
                    <asp:Panel ID="Panel_FileList" runat="server">
                        <div id="FileList">
                            <div style="text-align:center" class="title">
                                <asp:Label ID="labFileListTitle" runat="server">一曲新詞唱舊愁</asp:Label><br />
                            </div>
                            <br />
                            <asp:Table ID="tabFileList" runat="server"></asp:Table>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel_File" runat="server">
                        <div id="File" style="text-align:left">
                            <div style="text-align:center" class="title">
                                <asp:Label ID="labTitle" runat="server"></asp:Label><br />
                            </div>
                            <br />
                            <asp:Literal ID="litLyrics" runat="server" ></asp:Literal>
                                <div style="text-align:center">
                                    <asp:Image ID="ImgLyrics" runat="server" ImageAlign="Middle" style="margin:auto;width:90%"/>
                                </div>
                        </div>
                    </asp:Panel>
                    <br />
                    <br />
                    <br />
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Panel ID="Panel_FileNext" runat="server" CssClass="div_NextFile">
                        <br />
                        上一篇：<asp:Label ID="labLast" runat="server"></asp:Label><br />
                        下一篇：<asp:Label ID="labNext" runat="server"></asp:Label><br />
                        回目錄：<a href="Lyrics.aspx" class="content_NextFiletxt">一曲新詞唱舊愁</a><br />
                        <br />
                    </asp:Panel>
                </td>
                <td></td>
            </tr>
        </table>
        <br />
    </div>
    <div>
        <asp:HiddenField ID="hidDirName" runat="server" />
        <asp:HiddenField ID="hidFileName" runat="server" />
        <asp:HiddenField ID="hidMsg" runat="server" />
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>