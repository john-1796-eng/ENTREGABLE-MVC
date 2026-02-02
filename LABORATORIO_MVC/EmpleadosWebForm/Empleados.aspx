<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="LABORATORIO_MVC.EmpleadosWebForm.Empleados" %>
<!DOCTYPE html>
<html>
<head>
    <title>Formulario Empleados</title>
    <link rel="stylesheet" href="/Content/bootstrap.css" />
</head>
<body>

<form id="form1" runat="server" class="container mt-4">


<h1>Formulario Empleados</h1>

<asp:Label ID="lbl_nombres" runat="server" Text="Nombres" CssClass="badge rounded-pill bg-secondary d-inline-block mb-2"></asp:Label>
<div class="col-md-4 mb-3">
    <asp:TextBox ID="txt_nombres" runat="server" CssClass="form-control" placeholder="Nombres"></asp:TextBox>
 
    <asp:Label ID="lbl_apellidos" runat="server" Text="Apellidos" CssClass="badge rounded-pill bg-secondary d-inline-block mb-2"></asp:Label>
    <asp:TextBox ID="txt_apellidos" runat="server" CssClass="form-control" placeholder="Apellido1 Apellido2"></asp:TextBox>

    <asp:Label ID="lbl_direccion" runat="server" Text="Direccion" CssClass="badge rounded-pill bg-secondary d-inline-block mb-2"></asp:Label>
    <asp:TextBox ID="txt_direccion" runat="server" CssClass="form-control" placeholder="#Casa, calle o avenida"></asp:TextBox>

    <asp:Label ID="lbl_telefono" runat="server" Text="Telefono" CssClass="badge rounded-pill bg-secondary d-inline-block mb-2"></asp:Label>
    <asp:TextBox ID="txt_telefono" runat="server" CssClass="form-control" placeholder="Eje: 555522222:" TextMode="Number"></asp:TextBox>

    <asp:Label ID="lbl_fn" runat="server" Text="Fecha Nacimiento" CssClass="badge rounded-pill bg-secondary d-inline-block mb-2"></asp:Label>
    <asp:TextBox ID="txt_fn" runat="server" CssClass="form-control" placeholder="yyyy-mm-dd :" TextMode="Date"></asp:TextBox>

    <asp:Label ID="lbl_puesto" runat="server" Text="Puesto" CssClass="badge rounded-pill bg-secondary d-inline-block mb-2"></asp:Label>
    <asp:TextBox ID="txt_puesto" runat="server" CssClass="form-control" placeholder="Puesto"></asp:TextBox>

</div>

<button type="button" class="btn btn-outline-secondary mt-3" style="margin-right:15px;">Crear</button>
<button type="button" class="btn btn-outline-success mt-3" style="margin-right:15px;">Actualizar</button>
<button type="button" class="btn btn-outline-warning mt-3">Borrar</button>

<asp:GridView 
    ID="grid_empleados" 
    runat="server" 
    AutoGenerateColumns="False" 
    CssClass="table table-striped table-bordered mt-4">
</asp:GridView>
</form>
</body>
</html>
