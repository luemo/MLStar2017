<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Writings.aspx.cs" Inherits="MLStar.Writings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>午夜喃呢 - 陌柳星事務所</title>
    <script language="JavaScript" type="text/javascript">
        function doLoad()
        {
            var msg = document.getElementById('<%=hidMsg.ClientID%>').value;
            if (msg != "") {
                alert(msg);
            }
            var filename = document.getElementById('<%=hidFileName.ClientID%>').value;
            if (filename != "") {
                document.getElementById('maintable').className = "mainframe";
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
        <table id="maintable" style="width:100%">
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
                            <asp:Table ID="tabFileList" runat="server" Width="100%"></asp:Table>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel_File" runat="server">
                        <div id="File" style="text-align:left">
                            <div class="title">
                                <asp:Label ID="labTitle" runat="server"></asp:Label><br />
                            </div>
                            <asp:Label ID="labTime" runat="server" CssClass="content_time"></asp:Label>
                            <asp:Table ID="tabFile" runat="server"></asp:Table>
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
                        回目錄：<a href="Writings.aspx" class="content_NextFiletxt">午夜呢喃</a><br />
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
