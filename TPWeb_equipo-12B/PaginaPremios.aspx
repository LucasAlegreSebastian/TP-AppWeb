<%@ Page Title="Premios" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="PaginaPremios.aspx.cs" Inherits="TPWeb_equipo_12B.PaginaPremios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/styles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container-fluid fondoPremios" style="min-height:100vh; padding-top: 10px;"> 
          
    <div class="col justify-content-center flex-grow-1">
       
       <div id="tituloPremios" class="col-12 text-center text-white">
         <asp:Image ID="imgBanderines" ImageUrl="images/banderines.png" runat="server" CssClass="img-fluid"  alt="Banderines"  />
           <h1>Selecciona tu premio</h1>
     </div>
 </div>
    <div class="row" style="padding:10px">
        <asp:Repeater ID="RepeaterPremios" runat="server">
            <ItemTemplate>
                <div class="col-xl-4 row-gap-md-5 mb-4 col-sm-12">
                    <div class="card h-100">


                        <div id="carouselArticulo<%# Eval("Id") %>" class="carousel slide" data-bs-ride="carousel">
                            <div class="carousel-inner">
                                <asp:Repeater ID="RepeaterImagenes" runat="server" DataSource='<%# Eval("Imagenes") %>'>
                                    <%-- Usamos la lista de imagenes del articulo para 'repetir' el template,
                                        el primero de la lista es el activo en carrousel, 
                                        al cambiar al segundo indice, ese pasa a ser el primero y es el active --%>
                                    <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                            <img src='<%# Eval("ImagenUrl") %>' class="d-block w-100" alt='<%# Container.DataItem %>'>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carouselArticulo<%# Eval("Id") %>" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carouselArticulo<%# Eval("Id") %>" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>

                        <div class="card-body  text-center">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                        </div>

                        <div class=" card-footer text-muted">
                            <small>Marca: <%# Eval("Marca.Descripcion") %> <br />
                                Categoría: <%# Eval("Categoria.Descripcion") %></small>
                        </div>
                        <div class="row-cols-sm-1 m-3">
                            <asp:Button CssClass="btn btnSelectPremio" CommandArgument='<%# Eval("Id") %>'  OnClick="btnSeleccionarPremios_Click" ID="btnSeleccionarPremios" runat="server" Text="Seleccionar Premio" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
      </div>  
</asp:Content>
