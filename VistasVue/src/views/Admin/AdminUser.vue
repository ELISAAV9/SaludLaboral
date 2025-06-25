<template>
  <nav class="navbar sticky-top navbar-expand-sm navbar-white">
    <div class="container-fluid">
      <div class="navbar-center">
        <a class="navbar-brand ms-2" href="#">
          <span class="web-color ms-2">ADMINISTRAR USUARIO</span>
        </a>
      </div>
      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#mynavbar"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <!-- <div class="collapse navbar-collapse" id="mynavbar">
                    <ul class="navbar-nav ms-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="#../../Principal/PrincipalAdmin.html">Regresar</a>
                    </li>
                        </ul>
                    </li>
                    </ul>
                </div> -->
    </div>
  </nav>

  <section id="pantalla">
    <div class="contenedor">
      <div class="row row-cols-1 row-cols-md-4 mb-3 text-center">
        <!-- Agregar -->
        <div class="col">
          <div class="card mb-4 rounded-3 shadow-sm h-100">
            <div class="card-body">
              <i class="bi bi-person-plus display-4 mb-3"></i>
              <h5 class="card-title">Agregar alumno</h5>
              <router-link to="/AgregarUser" target="mainFrame" class="boton"> Alta </router-link>
            </div>
          </div>
        </div>

        <!-- Eliminar -->
        <div class="col">
          <div class="card mb-4 rounded-3 shadow-sm h-100">
            <div class="card-body">
              <i class="bi bi-person-dash display-4 mb-3"></i>
              <h5 class="card-title">Eliminar alumno</h5>
              <router-link to="/EliminarUser" target="mainFrame" class="boton"> Baja </router-link>
            </div>
          </div>
        </div>

        <!-- Modificar -->
        <div class="col">
          <div class="card mb-4 rounded-3 shadow-sm h-100">
            <div class="card-body">
              <i class="bi bi-pencil-square display-4 mb-3"></i>
              <h5 class="card-title">Modificar alumno</h5>
              <router-link to="/ModificarUser" target="mainFrame" class="boton">
                Cambio
              </router-link>
            </div>
          </div>
        </div>

        <!-- Consultar -->
        <div class="col">
          <div class="card mb-4 rounded-3 shadow-sm h-100">
            <div class="card-body">
              <i class="bi bi-search display-4 mb-3"></i>
              <h5 class="card-title">Consultar alumno</h5>
              <router-link to="/ConsultaUser" target="mainFrame" class="boton">
                Consulta
              </router-link>
            </div>
          </div>
        </div>
      </div>

      <!-- Fila nueva con botón centrado -->
      <div class="row">
        <div class="col text-center mt-4">
          <router-link to="/InicioAdmin" class="boton"> Regresar </router-link>
        </div>
      </div>
    </div>
  </section>
</template>

<script></script>
