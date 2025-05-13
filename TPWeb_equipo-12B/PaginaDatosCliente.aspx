<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="PaginaDatosCliente.aspx.cs" Inherits="TPWeb_equipo_12B.PaginaDatosCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center needs-validation">
        <div class="col-10 col-md-8 col-lg-6">
            <div class="m-4">
                <h2 class="mb-4 text-left font-weight-bold">Datos Personales</h2>
            </div>

            <div class="p-4 rounded bg-white shadow-sm">
                <div class="row">
                    <div class="col-12">
                        <!-- DNI -->
                        <div class="mb-3">
                            <label for="txtDni" class="form-label font-weight-bold text-dark">DNI</label>
                            <asp:TextBox runat="server" ID="txtDni" CssClass="form-control" AutoPostBack="true" TextMode="SingleLine" required="true" OnTextChanged="txtDni_TextChanged" MaxLength="8" placeholder="11222333" />
                            <div class="invalid-feedback">Ingrese un DNI válido (sólo números, mínimo 7 dígitos).</div>
                        </div>

                        <!-- Nombre -->
                        <div class="mb-3">
                            <label for="txtNombre" class="form-label font-weight-bold text-dark">Nombre:</label>
                            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" required="true" pattern="^[A-Za-zÁÉÍÓÚáéíóúÑñ]+(?: [A-Za-zÁÉÍÓÚáéíóúÑñ]+)*$" placeholder="Pedro" />
                            <div class="invalid-feedback">Ingrese un nombre válido.</div>
                        </div>

                        <!-- Apellido -->
                        <div class="mb-3">
                            <label for="txtApellido" class="form-label font-weight-bold text-dark">Apellido:</label>
                            <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" required="true" pattern="^[A-Za-zÁÉÍÓÚáéíóúÑñ]+(?: [A-Za-zÁÉÍÓÚáéíóúÑñ]+)*$" placeholder="Lopez" />
                            <div class="invalid-feedback">Ingrese un apellido válido.</div>
                        </div>

                        <!-- Email -->
                        <div class="mb-3">
                            <label for="txtEmail" class="form-label font-weight-bold text-dark">Email:</label>
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" required="true" placeholder="nombre@gmail.com" />
                            <div class="invalid-feedback">Ingrese un email válido.</div>
                        </div>
                    </div>

                    <div class="col-12">
                        <!-- Dirección -->
                        <div class="mb-3">
                            <label for="txtDireccion" class="form-label font-weight-bold text-dark">Dirección:</label>
                            <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" required="true" pattern="^[A-Za-zÁÉÍÓÚáéíóúÑñ.0-9]+(?: [A-Za-zÁÉÍÓÚáéíóúÑñ0-9]+)*$" placeholder="Avenida siempre viva 123" />
                            <div class="invalid-feedback">Ingrese una dirección válida.</div>
                        </div>

                        <!-- Ciudad -->
                        <div class="mb-3">
                            <label for="txtCiudad" class="form-label font-weight-bold text-dark">Ciudad:</label>
                            <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" required="true" pattern="^[A-Za-zÁÉÍÓÚáéíóúÑñ.]+(?: [A-Za-zÁÉÍÓÚáéíóúÑñ]+)*$" placeholder="Pacheco" />
                            <div class="invalid-feedback">La ciudad no puede contener números.</div>
                        </div>

                        <!-- Código Postal -->
                        <div class="mb-3">
                            <label for="txtCP" class="form-label font-weight-bold text-dark">CP:</label>
                            <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" TextMode="Number" required="true" placeholder="1617" />
                            <div class="invalid-feedback">Ingrese un código postal válido(sólo números).</div>
                        </div>
                    </div>
                </div>

                <!-- Campos obligatorios texto -->
                <div class="text-start mt-3">
                    <p class="text-muted" style="font-size: 12px;">Todos los campos son obligatorios.</p>
                </div>

                <!-- Botones -->
                <div class="row justify-content-between mt-4">
                    <div class="col-md-6 mb-2 text-center">
                        <asp:Button Text="Participar" ID="btnParticipar" CssClass="btn btn-primary w-100" runat="server" OnClick="btnParticipar_Click" UseSubmitBehavior="true" />
                    </div>
                    <div class="col-md-6 mb-2 text-center">
                        <a href="PaginaPremios.aspx" class="btn btn-secondary w-100">Volver</a>
                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>
