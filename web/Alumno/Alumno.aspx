<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="web.Alumno.Alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 236px;
            text-align: center;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:HyperLink ID="tareasGenericas" runat="server" NavigateUrl="~/Alumno/TareasAlumno.aspx">Tareas Genéricas</asp:HyperLink>
                    </td>
                    <td class="auto-style2" rowspan="3"><span class="auto-style3">Gestión Web de Tareas-Dedicación</span><br class="auto-style3" />
                        <br class="auto-style3" />
                        <span class="auto-style3">Alumnos<br />
                        <br />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:Timer ID="Timer1" runat="server" Interval="2000">
                        </asp:Timer>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="otherLoggedLabel" runat="server" Text="Label"></asp:Label>
                                &nbsp;<br />
                                <asp:ListBox ID="otherAccounts" runat="server"></asp:ListBox>
                                <br />
                                <asp:Label ID="studentLoggedLabel" runat="server" Text="Label"></asp:Label>
                                <br />
                                <asp:ListBox ID="studentAccounts" runat="server"></asp:ListBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" />
                            </Triggers>
                        </asp:UpdatePanel>
                        </span></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:HyperLink ID="tareasPropias" runat="server">Tareas Propias</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:HyperLink ID="grupos" runat="server">Grupos</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
