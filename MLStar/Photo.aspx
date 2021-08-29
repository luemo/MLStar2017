<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Photo.aspx.cs" Inherits="MLStar.Photo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>攝‧影 - 陌柳星事務所</title>
    <script language="JavaScript" type="text/javascript">
        function doLoad()
        {
            var msg = document.getElementById('<%=hidMsg.ClientID%>').value;
            if (msg != "") {
                alert(msg);
            }
        }
        function LastPic()
        {
            alert("已經是最後一張了！");
            return false;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        <table style="width:100%"  class="mainframe">
            <tr>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Panel ID="Panel_DirList" runat="server">
                        <div id="DirList">
                            <div style="text-align:center" class="title">
                                <asp:Label ID="labDirListTitle" runat="server">攝‧影</asp:Label><br />
                            </div>
                            <br />
                            <asp:Table ID="tabDirList" runat="server"></asp:Table>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel_FileList" runat="server">
                        <div id="FileList" style="text-align:center">
                            <div style="text-align:center" class="title">
                                <asp:Label ID="labFileListTitle" runat="server"></asp:Label><br />
                            </div>
                            <br />
                            <asp:Table ID="tabFileList" runat="server"></asp:Table>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel_File" runat="server">
                        <div id="File" style="text-align:center">
                            <div style="text-align:center" class="title">
                                <asp:Label ID="labTitle" runat="server"></asp:Label><br />
                            </div>
                            <br />
                            <asp:Table ID="tabFile" runat="server" BorderStyle="Double"></asp:Table>
                            <br />
                            <br />
                            <br />
                        </div>
                    </asp:Panel>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Panel ID="Panel_FileNext" runat="server">
                        <br />
                        上一篇：<asp:Label ID="labLast" runat="server"></asp:Label><br />
                        下一篇：<asp:Label ID="labNext" runat="server"></asp:Label><br />
                        回目錄：<asp:Label ID="labDir" runat="server"></asp:Label><br />
                    </asp:Panel>
                    <asp:Panel ID="Panel_DirNext" runat="server">
                        <br />
                        上一本：<asp:Label ID="labLastDir" runat="server"></asp:Label><br />
                        下一本：<asp:Label ID="labNextDir" runat="server"></asp:Label><br />
                        回相簿目錄：<a href="Photo.aspx" class="content_NextFiletxt">攝‧影</a><br />
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