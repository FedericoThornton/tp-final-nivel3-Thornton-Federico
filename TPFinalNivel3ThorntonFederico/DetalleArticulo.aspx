<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TPFinalNivel3ThorntonFederico.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .image {
            max-width:60%; 
            height:60%;
        }
       
     .validacion {
         color: red;
         font-family: Arial, Helvetica, sans-serif;
         font-size: 14px;
     }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="lblTipo" class="form-label">Tipo</label>
                <asp:TextBox ID="txtTipo" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Image ImageUrl="https://th.bing.com/th/id/OIP.F00dCf4bXxX0J-qEEf4qIQHaD6?rs=1&pid=ImgDetMain" ID="ImageArticulos" CssClass="image"  runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" runat="server" />
            </div>
        </div>
        <div class="col-6">
            
            <div class="mb-3">
                <label for="lblNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblMarca" class="form-label">Marca</label>
                <asp:TextBox ID="txtMarca" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" />
               
            </div>
            <a class="btn btn-primary" href="Default.aspx">Volver</a>
        </div>
    </div>
    <hr />
</asp:Content>
