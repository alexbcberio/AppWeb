<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="web.Alumno.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1096px;
            height: 525px;
        }
        .auto-style2 {
            width: 328px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:HyperLink ID="tareas_profe" runat="server" BackColor="Yellow" BorderColor="#FF9999" BorderWidth="5px" NavigateUrl="~/Profesor/TareasProfe.aspx">Tareas</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="tareas_profe0" runat="server" BackColor="Yellow" BorderColor="#FF9999" BorderWidth="5px" NavigateUrl="~/Profesor/estadic.aspx">Estadicticas</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                
                 <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink1" runat="server" BackColor="Yellow" BorderColor="#FF9999" BorderWidth="5px" NavigateUrl="~/Profesor/importarTareas.aspx">IMportar Tareas</asp:HyperLink> 
                     <asp:HyperLink ID="HyperLink3" runat="server" BackColor="Yellow" BorderColor="#FF9999" BorderWidth="5px" NavigateUrl="~/Profesor/imnporttareadataset.aspx">IMportar Tareas VDataSet</asp:HyperLink>
                     </td>
               
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:Timer ID="Timer1" runat="server" Interval="2000">
                    </asp:Timer>
                 </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
               
                 <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" BackColor="Yellow" BorderColor="#FF9999" BorderWidth="5px" NavigateUrl="~/Profesor/exportarTareas.aspx">Exportar Tareas</asp:HyperLink>
                     <br />
                    <asp:HyperLink ID="HyperLink4" runat="server" BackColor="Yellow" BorderColor="#FF9999" BorderWidth="5px" NavigateUrl="~/Profesor/coordinador.aspx">Coordinador</asp:HyperLink></td>
                 <td class="auto-style2">
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
                 </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
