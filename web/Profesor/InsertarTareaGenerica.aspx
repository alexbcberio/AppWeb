<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarTareaGenerica.aspx.cs" Inherits="web.Profesor.InsertarTareaGenerica" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 82px;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Codigo:
                    </td>
                    <td>
                        <asp:TextBox ID="codigo" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="codigo" EnableClientScript="False"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Descripción:
                    </td>
                    <td>
                        <asp:TextBox ID="desc" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="desc" EnableClientScript="False"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Asignatura:
                    </td>
                    <td>
                        <asp:DropDownList ID="asig" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Horas estimadas:
                    </td>
                    <td>
                        <asp:TextBox ID="horas" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="horas" EnableClientScript="False"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Tipo tarea:
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="tipo" runat="server">
                            <asp:ListItem Selected="True">Laboratorio</asp:ListItem>
                            <asp:ListItem>Trabajo</asp:ListItem>
                            <asp:ListItem>Ejercicio</asp:ListItem>
                            <asp:ListItem>Examen</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="añadir" runat="server" Text="Añadir Tarea" OnClick="añadir_Click" />
                        <br />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hads21-16ConnectionString %>" 
                        SelectCommand="SELECT [Asignaturas].[codigo] FROM ([Asignaturas] INNER JOIN [GruposClase] ON [Asignaturas].[codigo]=[GruposClase].[codigoasig]) INNER JOIN [ProfesoresGrupo] ON [ProfesoresGrupo].[codigogrupo]=[GruposClase].[codigo] WHERE ([ProfesoresGrupo].[email] = @email)">
                        <SelectParameters>
                            <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="TareasProfesor" runat="server" NavigateUrl="~/Profesor/TareasProfe.aspx">Ver Tareas</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
