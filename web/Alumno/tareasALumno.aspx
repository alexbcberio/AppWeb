<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TareasAlumno.aspx.cs" Inherits="web.Alumno.alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        Alumnos <br />
                        Gestión de tareas genéricas
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CerrarSesion.aspx">Cerrar Sesión</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        Selecionar Asignatura (solo se muestran aquellas en las que esta matriculado): <br />
                        <asp:DropDownList ID="codasig" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </td>
                </tr>

                </table>
        </div>
        <asp:GridView ID="tasksGrid" runat="server" CellPadding="3" GridLines="Vertical" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="tasksGrid_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="Gainsboro" />
            <Columns>
                <asp:CommandField ButtonType="Button" SelectText="Instanciar" ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Alumno/Alumno.aspx">Volver</asp:HyperLink>
        </form>
</body>
</html>

