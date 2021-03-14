<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="estadic.aspx.cs" Inherits="web.Profesor.estadic" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   
                        Selecionar Alumno:<br />
                   
               
    <form id="form1" runat="server">
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Email" DataValueField="Email">
        </asp:DropDownList>
        <div>
             <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource1">
            <series>
                 <asp:Series Name="Series1" XValueMember="Descripción" YValueMembers="Column1">
                        </asp:Series>
                        <asp:Series Name="Series2" XValueMember="Descripción" YValueMembers="Column2">
                        </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
            <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sqlserver %>" SelectCommand="SELECT [Descripción], AVG([HReales]), AVG(HEstimadas) FROM [TareasPersonales] WHERE ([Email] = @email) GROUP BY [Descripción]

" ProviderName="<%$ ConnectionStrings:sqlserver.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="" Name="email" PropertyName="SelectedValue" />
            </SelectParameters>
                </asp:SqlDataSource>
    </div>

             <div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sqlserver %>" SelectCommand="SELECT distinct[Email] FROM [TareasPersonales] "></asp:SqlDataSource>
    </div>
        </div>
        <p>
            &nbsp;</p>
       
    </form>
</body>
</html>


