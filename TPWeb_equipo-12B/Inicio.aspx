<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPWeb_equipo_12B.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid d-flex flex-column">
        <div class="row justify-content-center">
            <div class="col-12 text-center">
                <asp:Image ID="imgBanderines" ImageUrl="images/banderines.png" runat="server" CssClass="img-fluid"  alt="Banderines"  />
            </div>
        </div>

        <div class="text-center m-5">
            <h1 class="display-5">¡Bienvenido!</h1>
            <p class="text-center m-1">
                Acá podés canjear increíbles premios.
            </p>
        </div>

        <div class="container" style="margin-top: 40px">
            <div class="text-center" style="max-width: 300px; margin: 0 auto;">
                <div class="mb-3">
                    <asp:Label Text="Ingresá el código de tu voucher:" ID="lblIngresaVoucher" CssClass="form-label" runat="server" />
                    <asp:TextBox type="text" CssClass="form-control text-center" ID="txtboxVoucher" placeholder="Codigo00" required="true" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button Text="Canjear" ID="btnAceptarVoucher" OnClick="btnAceptarVoucher_Click" CssClass="btn btn-success" runat="server" />
                    <div class="textVoucherInvalido">
                        <asp:Label Text="Ingrese un voucher válido..." ID="lblVoucherInvalido" Visible="false" CssClass="form-label" runat="server" />
                    </div>
                </div>
            </div>
        </div>

        <div class="carousel-wrapper">
          <div class="carousel-track" id="logoTrack">
            <img src="images/logitech.jpg" alt="Logitech" class="logo" />
            <img src="images/huawei.png" alt="Huawei" class="logo" />
            <img src="images/motorola.png" alt="Motorola" class="logo" />
            <img src="images/royal.jpg" alt="Royal" class="logo" />
            <img src="images/wilson.png" alt="Wilson" class="logo" />
          </div>
        </div>

        <div class="row justify-content-center mt-5">
            <div class="col-12 text-center">
                <h2>
                    Cómo participar?
                </h2>
            </div>
            </div>
            <div class="row justify-content-center text-center m-4">
            <div class="col-4 col-md-3">
                <div class="rounded-circle mx-auto bgDarkOrange shadowMd zoomOnHover contentCircleOrange">
                    <span>Ingresá el código del voucher</span>
                </div>
            </div>
            <div class="col-4 col-md-3">
                <div class="rounded-circle mx-auto bgDarkOrange shadowMd zoomOnHover contentCircleOrange">
                    <span>Seleccioná el producto</span>
                </div>
            </div>
            <div class="col-4 col-md-3">
                <div class="rounded-circle mx-auto bgDarkOrange shadowMd zoomOnHover contentCircleOrange">
                    <span>Completa el formulario</span>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>
