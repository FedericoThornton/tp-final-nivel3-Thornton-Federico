<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3ThorntonFederico.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; color: royalblue">ELECTROWEB</h1>
    <hr />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" style="max-width: min-content; height: auto" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text" style="text-align: center; font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; color: blue">$<%#Eval("Precio") %></p>
                            <hr />
                            <asp:Button Text="Ver detalle" CssClass="btn btn-primary" ID="btnDetalle" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnDetalle_Click" />

                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <hr />
    <!-- Footer -->
    <footer style="text-align: center; font-size: 14px; color: gray;">
        <hr />
        <p>&copy; 2024 Electro Web. Todos los derechos reservados.</p>
    </footer>
</asp:Content>
