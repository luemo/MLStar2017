<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="MLStar.Game" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>遊戲製作 - 陌柳星事務所</title>
    <script language="JavaScript" type="text/javascript">
        function doLoad()
        {
            var msg = document.getElementById('<%=hidMsg.ClientID%>').value;
            if (msg != "") {
                alert(msg);
            }
            var jtitle = document.getElementById('<%=hidFileName.ClientID%>').value;
            if (jtitle != "") {
                document.getElementById('frmGame').src = jtitle;
            }
        }
        function Changiframe()
        {
            var idoc = document.getElementById('frmGame');
            idoc.style.height = idoc.contentWindow.document.body.scrollHeight + 40 + "px";
        }
    </script>
    <style>
        html,body { height: 100% }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        <table style="width:100%" class="mainframe">
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
                                <asp:Label ID="labFileListTitle" runat="server">遊戲製作</asp:Label><br />
                            </div>
                            <br />
                            <asp:Table ID="tabFileList" runat="server"></asp:Table>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel_File" runat="server">
                        <div id="File" style="text-align:center">
                            <iframe style="width: 100%;border:none;" onload="Changiframe();" id="frmGame" scrolling="no" ></iframe>
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
                        回目錄：<a href="Game.aspx" class="content_NextFiletxt">打打遊戲</a><br />
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
