<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="web.Alumno.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 42%;
        }
        .auto-style2 {
            width: 116px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Usuario</td>
                    <td>
                        <asp:TextBox ID="email" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Tarea</td>
                    <td>
                        <asp:TextBox ID="task" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Horas Estimadas</td>
                    <td>
                        <asp:TextBox ID="estimatedTime" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Horas Reales</td>
                    <td>
                        <asp:TextBox ID="realTime" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:Button ID="create" runat="server" Text="Crear Tarea" OnClick="create_Click" />
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Alumno/TareasAlumno.aspx">Página Anterior</asp:HyperLink>
        &nbsp;<asp:Label ID="msg" runat="server"></asp:Label>
        </p>
        <asp:GridView ID="instantiatedTasksGrid" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
    </form>
</body>
</html>
