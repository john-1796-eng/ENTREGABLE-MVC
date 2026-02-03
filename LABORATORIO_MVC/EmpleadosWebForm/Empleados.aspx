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

 

    <!-- CAMPOS DEL EMPLEADO -->
    <asp:Label ID="lbl_nombres" runat="server" Text="Nombres" CssClass="badge rounded-pill bg-secondary d-inline-block mb-2"></asp:Label>
    <asp:TextBox ID="txt_nombres" runat="server" CssClass="form-control mb-3" placeholder="Nombres"></asp:TextBox>

    <asp:Label ID="lbl_apellidos" runat="server" Text="Apellidos" CssClass="badge rounded-pill bg-secondary d-inline-block mb-2"></asp:Label>
    <asp:TextBox ID="txt_apellidos" runat="server" CssClass="form-control mb-3" placeholder="Apellidos"></asp:TextBox>

    <asp:Label ID="lbl_direccion" runat="server" Text="Dirección" CssClass="badge rounded-pill bg-secondary d-inline-block mb-2"></asp:Label>
    <asp:TextBox ID="txt_direccion" runat="server" CssClass="form-control mb-3" placeholder="Dirección"></asp:TextBox>

    <asp:Label ID="lbl_telefono" runat="server" Text="Teléfono" CssClass="badge rounded-pill bg-secondary d-inline-block mb-2"></asp:Label>
    <asp:TextBox ID="txt_telefono" runat="server" CssClass="form-control mb-3" placeholder="Teléfono" TextMode="Number"></asp:TextBox>

    <asp:Label ID="lbl_fn" runat="server" Text="Fecha Nacimiento" CssClass="badge rounded-pill bg-secondary d-inline-block mb-2"></asp:Label>
    <asp:TextBox ID="txt_fn" runat="server" CssClass="form-control mb-3" TextMode="Date"></asp:TextBox>

    <asp:Label ID="lbl_puesto" runat="server" Text="Puesto" CssClass="badge rounded-pill bg-secondary d-inline-block mb-2"></asp:Label>
    <asp:TextBox ID="txt_puesto" runat="server" CssClass="form-control mb-3" placeholder="Puesto"></asp:TextBox>

    <!-- BOTONES -->
    <asp:Button ID="btn_crear" runat="server" Text="Crear"
        CssClass="btn btn-outline-secondary mt-3 me-2"
        OnClick="btn_crear_Click" />

    <asp:Button ID="btn_actualizar" runat="server" Text="Actualizar"
        CssClass="btn btn-outline-success mt-3 me-2"
        OnClick="btn_actualizar_Click" />

    <asp:Button ID="btn_borrar" runat="server" Text="Borrar"
        CssClass="btn btn-outline-warning mt-3"
        OnClick="btn_borrar_Click" />

    <!-- GRID DE EMPLEADOS -->
    <asp:GridView 
    ID="grid_empleados" 
    runat="server"
    AutoGenerateSelectButton="True"
    OnSelectedIndexChanged="grid_empleados_SelectedIndexChanged"
    CssClass="table table-striped table-bordered mt-4">
</asp:GridView>


</form>

</body>
</html>
