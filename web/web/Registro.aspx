<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="web.WebForm2" %>

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
                    <td><span style="color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">REGISTRO DE USUARIOS</span></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="email" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="email" ErrorMessage="Campo Obligatorio*" ForeColor="Red" ValidationGroup="abc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ErrorMessage="Introduce un email válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="abc"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Nombre</td>
                    <td>
                        <asp:TextBox ID="nombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="nombre" ErrorMessage="Campo Obligatorio*" ForeColor="Red" ValidationGroup="abc"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Apellidos</td>
                    <td>
                        <asp:TextBox ID="apellidos" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="apellidos" ErrorMessage="Campo Obligatorio*" ForeColor="Red" ValidationGroup="abc"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña</td>
                    <td>
                        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="password" ErrorMessage="Campo Obligatorio*" ForeColor="Red" ValidationGroup="abc"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Repetir Contraseña</td>
                    <td>
                        <asp:TextBox ID="repeatpassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="repeatpassword" ErrorMessage="Campo Obligatorio*" ForeColor="Red" ValidationGroup="abc"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="repeatpassword" ControlToValidate="password" ErrorMessage="Las contraseñas deben ser iguales" ForeColor="Red" ValueToCompare="abc"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>Rol</td>
                    <td>
                        <asp:RadioButtonList ID="radioButton" runat="server">
                            <asp:ListItem Selected="True">Alumno</asp:ListItem>
                            <asp:ListItem>Profesor</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="radioButton" ErrorMessage="Campo Obligatorio*" ForeColor="Red" ValidationGroup="abc"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Registrar" ValidationGroup="abc" Width="300px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
