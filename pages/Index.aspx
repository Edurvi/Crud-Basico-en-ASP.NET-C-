<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CrudBasico.pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titile" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width:300px">
            <h2>Listado de Registros</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col aling-self-end">
                    <asp:Button Text="Create" ID="BtnCreate" CssClass="btn btn-sucess form-control" runat="server" onclick="BtnCreate_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvusuarios" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del Administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnRead" Text="Read" CssClass="btn form-control-sm btn-info" OnClick="btnRead_Click" />
                                <asp:Button runat="server" ID="btnUpdate" Text="Update" CssClass="btn form-control-sm btn-info" OnClick="btnUpdate_Click" />
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn form-control-sm btn-info" OnClick="btnDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
