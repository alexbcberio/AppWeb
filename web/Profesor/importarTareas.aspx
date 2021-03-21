<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="importarTareas.aspx.cs" Inherits="web.Profesor.importarTareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1025px;
            height: 324px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <br />
                        Importar tareas</td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Logout.aspx">Cerrar Sesión</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        Selecionar Asignatura<br />
                        <asp:DropDownList ID="codasig" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" OnSelectedIndexChanged="codasig_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sqlserver %>" 
                        SelectCommand="SELECT [Asignaturas].[codigo] FROM ([Asignaturas] INNER JOIN [GruposClase] ON [Asignaturas].[codigo]=[GruposClase].[codigoasig]) INNER JOIN [ProfesoresGrupo] ON [ProfesoresGrupo].[codigogrupo]=[GruposClase].[codigo] WHERE ([ProfesoresGrupo].[email] = @email)" ProviderName="<%$ ConnectionStrings:sqlserver.ProviderName %>">
                        <SelectParameters>
                            <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
        <asp:Xml ID="Xml1" runat="server" Visible="False"></asp:Xml>
                </tr>
                <tr>
                    <td>
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="Insertar" runat="server" Text="IMPORTAR" ClientIDMode="AutoID" OnClick="Insertar_Click" />
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Profesor/Profesor.aspx">Volver</asp:HyperLink>
    </form>
</body>
</html>

