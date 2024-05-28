<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="TPFinalNivel3ThorntonFederico.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .image {
            max-width: 60%;
            height: 60%;
        }

        .validacion {
            color: red;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <hr />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="lblid" class="form-label">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblCodigo" class="form-label">Código de artículo</label>
                <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Complete el campo" CssClass="validacion" ControlToValidate="txtCodigo" runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Complete el campo" CssClass="validacion" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label for="lblTipo" class="form-label">Tipo</label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="lblMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="lblPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="TxtPrecio" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Complete el campo" CssClass="validacion" ControlToValidate="TxtPrecio" runat="server" />
                <%if (!(Request.QueryString["Id"] != null))
                    { %>
                <asp:RegularExpressionValidator ErrorMessage="Solo números" ControlToValidate="TxtPrecio" CssClass="validacion" ValidationExpression="^[0-9]+$" runat="server" />
                <% }%>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a class="btn btn-link" href="ArticulosLista.aspx">Cancelar</a>
                <% if (Request.QueryString["Id"] != null)
                    { %>
                <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click" runat="server" />
                <%  }%>

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <% if (ConfirmaEliminacion)
                            { %>
                        <asp:CheckBox Text="Confirma eliminación definitiva" ID="chkConfirmaeliminacion" runat="server" />
                        <div class="mb-3">
                            <asp:Button Text="Eliminar" ID="btnConfirmaeliminacion" CssClass="btn btn-danger" OnClick="btnConfirmaeliminacion_Click" runat="server" />
                        </div>
                        <%  } %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="lblDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Complete el campo" CssClass="validacion" ControlToValidate="txtDescripcion" runat="server" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="lblImagen" class="form-label">Url Imagen</label>
                        <asp:TextBox ID="txtUrlImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" runat="server" />
                    </div>
                    <asp:Image ImageUrl="https://th.bing.com/th/id/OIP.F00dCf4bXxX0J-qEEf4qIQHaD6?rs=1&pid=ImgDetMain" ID="ImageArticulos" CssClass="image" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <hr />
</asp:Content>
