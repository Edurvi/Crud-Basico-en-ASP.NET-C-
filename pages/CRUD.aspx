<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="CrudBasico.pages.CRUD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titile" runat="server">
    Crud
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width: 250px">
        <asp:Label  runat="server" CssClass="h2" ID="lblTitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex aling-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"></asp:TextBox>
            </div>


            <div class="mb-3">
                <label class="form-label">Edad</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEdad"></asp:TextBox>
            </div>


            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"></asp:TextBox>
            </div>


            <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="txtFecha"></asp:TextBox>
            </div>

            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnCreate" Text="Create" Visible="false" OnClick="btnCreate_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnUpdate" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnEliminar" Text="Eliminar" Visible="false" OnClick="btnEliminar_Click" />

            <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="btnVolver" Text="Volver" Visible="true" onclick="btnVolver_Click"/>

        </div>



    </form>
</asp:Content>
