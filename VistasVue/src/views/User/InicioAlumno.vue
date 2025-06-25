<template>
  <nav class="navbar sticky-top navbar-expand-sm">
    <div class="container-fluid">
      <a class="navbar-brand ms-2" href="#">
        <span class="web-color ms-2">ALUMNO</span>
      </a>
      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#mynavbar"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="mynavbar">
        <ul class="navbar-nav ms-auto">
          <li class="nav-item">
            <router-link to="/guia" target="mainFrame" class="nav-link">
              Guía de Evaluación
            </router-link>
          </li>

          <li class="nav-item">
            <router-link to="/ayuda" target="mainFrame" class="nav-link"> Ayuda </router-link>
          </li>

          <li class="nav-item">
            <a class="nav-link" @click="Logout" target="_top">Salir</a>
          </li>
        </ul>
      </div>
    </div>
  </nav>

  <!-- Texto central con declaración -->
  <div class="text-center mb-5">
    <br />
    <br />
    <h2>DECLARACIÓN DE CONSENTIMIENTO INFORMADO</h2>
    <div class="texto mt-3">
      <p>
        Se le informa con claridad y veracidad que se respetará la confiabilidad e intimidad de la
        información suministrada, lo mismo que su seguridad física y psicológica con respecto al
        proyecto académico, que los estudiantes de la Licenciatura en enfermería de la UAA, le
        invitan a participar de manera libre y voluntaria como colaborador, contribuyendo a este
        procedimiento de forma activa.
      </p>
    </div>
  </div>

  <!-- Realizar entrevista -->
  <div class="row justify-content-center mb-3 text-center">
    <div class="col-md-4">
      <!-- Card más pequeña y centrada -->
      <div class="card mb-4 rounded-3 shadow-sm h-100">
        <div class="card-body">
          <i class="bi bi-clipboard-check display-4 mb-3"></i>
          <h5 class="card-title">Realizar entrevista</h5>
          <router-link to="/formulario" target="mainFrame" class="boton"> Formulario </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {}
  },
  methods: {
    async Logout() {
      localStorage.removeItem('userSession')
      this.$router.push({ name: 'login' })
    },
  },
}
</script>
