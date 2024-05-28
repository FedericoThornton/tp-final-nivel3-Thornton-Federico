<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="TPFinalNivel3ThorntonFederico.ArticulosLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; color: royalblue">Lista de artículos</h1>
    <hr />
    <div class="row">
        <div class="col-6">
            <asp:Label Text="Filtrar" runat="server" />
            <asp:TextBox AutoPostBack="true" ID="txtfiltro" CssClass="form-control" OnTextChanged="txtfiltro_TextChanged" runat="server" />
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado"
                    CssClass="form-check-label" ID="chkAvanzado" runat="server"
                    AutoPostBack="true"
                    OnCheckedChanged="chkAvanzado_CheckedChanged" />
            </div>
        </div>
    </div>
    <%if (chkAvanzado.Checked)
        { %>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" ID="LblCampo" runat="server" CssClass="form-label" />
                <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="DdlCampo" OnSelectedIndexChanged="DdlCampo_SelectedIndexChanged" runat="server">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Tipo" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Precio" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" ID="LblCriterio" runat="server" CssClass="form-label" />
                <asp:DropDownList CssClass="form-control" ID="DdlCriterio" OnSelectedIndexChanged="DdlCriterio_SelectedIndexChanged" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" ID="lblFitroavanzado" runat="server" CssClass="form-label" />
                <asp:TextBox CssClass="form-control" runat="server" ID="TxtFiltroavanzado">
                </asp:TextBox>
                <% if (string.IsNullOrEmpty(TxtFiltroavanzado.Text))
                    { %>
                <asp:RequiredFieldValidator ErrorMessage="Complete el filtro" CssClass="validacion" ControlToValidate="TxtFiltroavanzado" runat="server" />
                <% }%>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:CheckBox Text="Reiniciar Filtro"
                    CssClass="form-check-label" ID="chkreinicioFiltro" runat="server"
                    AutoPostBack="true"
                    OnCheckedChanged="reinicioFiltro_CheckedChanged" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col">
            <div class="mb-3">
                <asp:Button Text="Buscar" ID="btnBuscar" CssClass=" btn btn-primary" OnClick="btnBuscar_Click" runat="server" />
            </div>
        </div>
    </div>
    <%  } %>
    <hr />
    <asp:GridView ID="DgvArticulos" CssClass="table table-primary table-striped"
        OnSelectedIndexChanged="DgvArticulos_SelectedIndexChanged"
        OnPageIndexChanging="DgvArticulos_PageIndexChanging" DataKeyNames="Id"
        AllowPaging="true" PagerStyle-Font-Bold="true" PageSize="5"
        AutoGenerateColumns="false"
        runat="server">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" ButtonType="Button" ControlStyle-BackColor="LavenderBlush" SelectText="Editar" />
        </Columns>
    </asp:GridView>
    <a href="FormularioArticulos.aspx" class="btn btn-primary">Agregar</a>
    <hr />
</asp:Content>
