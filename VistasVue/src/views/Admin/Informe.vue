<template>
  <nav class="navbar sticky-top navbar-expand-sm navbar-white">
    <div class="container-fluid">
      <div class="navbar-center">
        <a class="navbar-brand ms-2" href="#">
          <span class="web-color ms-2">SOLICITA INFORME</span>
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
      <div class="container my-5">
        <div class="row row-cols-1 row-cols-md-4 g-4 text-center justify-content-center">
          <!-- Card 1 -->
          <div class="col">
            <div class="card h-100 shadow-sm rounded-3">
              <div class="card-body">
                <i class="bi bi-people-fill display-4 mb-3"></i>
                <h5 class="card-title">Trabajadores y diagnóstico</h5>
                <button @click="$router.push('/resultado')" class="boton">Ingresar</button>
              </div>
            </div>
          </div>

          <!-- Card 2 -->
          <div class="col">
            <div class="card h-100 shadow-sm rounded-3">
              <div class="card-body">
                <i class="bi bi-person-lines-fill display-4 mb-3"></i>
                <h5 class="card-title">Info. de trabajadores</h5>
                <button @click="mensaje" class="boton">Ingresar</button>
              </div>
            </div>
          </div>

          <!-- Card 3 -->
          <div class="col">
            <div class="card h-100 shadow-sm rounded-3">
              <div class="card-body">
                <i class="bi bi-ui-checks-grid display-4 mb-3"></i>
                <h5 class="card-title">Estructura del formulario</h5>

                <button @click="mensaje" class="boton">Ingresar</button>
              </div>
            </div>
          </div>

          <!-- Card 4 -->
          <!-- <div class="col">
            <div class="card h-100 shadow-sm rounded-3">
              <div class="card-body">
                <i class="bi bi-bar-chart-line-fill display-4 mb-3"></i>
                <h5 class="card-title">Resultados del trabajador</h5>
                <a href="../Admin/Resultados.vue" target="mainFrame" class="boton">Ingresar</a>
              </div>
            </div>
          </div> -->
        </div>

        <!-- Botón regresar -->
        <div class="text-center mt-5">
          <router-link to="/InicioAdmin" class="boton"> Regresar </router-link>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  data() {
    return {}
  },

  methods: {
    mensaje() {
      alert('Disponible para el siguiente semestre!')
    },
  },

  async mounted() {},
}
</script>
