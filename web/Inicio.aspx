<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="userEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="userEmail" ErrorMessage="Campo Obligatorio*" ForeColor="Red" ValidationGroup="abc"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="userEmail" ErrorMessage="Introduce un email válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="abc"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>PassWord</td>
                <td>
                    <asp:TextBox ID="userpass" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="userpass" ErrorMessage="Campo Obligatorio*" ForeColor="Red" ValidationGroup="abc"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Login" ValidationGroup="abc" />
                &nbsp;&nbsp;<asp:HyperLink ID="register" runat="server" NavigateUrl="~/Registro.aspx">Registro</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CambiarPassword.aspx">Modificar Contraseña  </asp:HyperLink>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
