<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="web.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 68%;
            height: 111px;
        }
        .auto-style2 {
            height: 23px;
            width: 454px;
        }
        .auto-style3 {
            height: 23px;
            width: 141px;
        }
        .auto-style4 {
            width: 141px;
        }
        .auto-style5 {
            width: 454px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Solicitar cambio de contraseña</h1>
            <table>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="email" runat="server" Width="321px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="email" ErrorMessage="* Inserta un email" ForeColor="Red" ValidationGroup="abc"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ErrorMessage="Inserta un email válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="requestChange" runat="server" Text="Solicitar Cambio de Password" ValidationGroup="abc" OnClick="requestChange_Click" />
                        <asp:Label ID="requestChangeError" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
                        <asp:Label ID="requestChangeOk" runat="server" EnableViewState="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <hr />
        <h1>Cambiar contraseña</h1>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Email:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="email2" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="email2" ErrorMessage="* Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="email2" ErrorMessage="Inserta un email válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Código:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="passchangeCode" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="passchangeCode" ErrorMessage="* Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="passchangeCode" ErrorMessage="Formato de código inválido" ForeColor="Red" ValidationExpression="[0-9]{5,10}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Contraseña:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="password" ErrorMessage="* Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="password" ErrorMessage="Mínimo 6 carácteres" ForeColor="Red" ValidationExpression="\w{6,}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Confirmar Contraseña:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="confirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="confirmPassword" ErrorMessage="* Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="password" ControlToValidate="confirmPassword" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
        </table>
            <asp:Button ID="change" runat="server" Text="Cambiar contraseña" OnClick="change_Click" />
        <asp:Label ID="changeError" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
        <asp:Label ID="changeOk" runat="server" EnableViewState="False"></asp:Label>
        <asp:HyperLink ID="homeLink" runat="server" EnableViewState="False" NavigateUrl="~/Inicio.aspx" Visible="False">Volver al inicio</asp:HyperLink>
        </form>
    </body>
</html>
