<template>
  <div class="container-top">
    <header class="d-flex justify-content-center py-3">
      <ul class="nav nav-pills">
        <li class="nav-item">
          <a
            href="https://www.facebook.com/p/Departamento-de-Enfermer%C3%ADa-Universidad-Aut%C3%B3noma-de-Aguascalientes-100050921893106/"
            class="nav-link active"
            aria-current="page"
            >DEPARTAMENTO DE ENFERMERÍA</a
          >
        </li>
      </ul>
    </header>
  </div>

  <nav class="navbar sticky-top navbar-expand-sm navbar-white">
    <div class="container-fluid">
      <a class="navbar-brand ms-2" href="#">
        <img
          src="../assets/img/logo.png"
          alt="Logo"
          width="40"
          height="40"
          class="d-inline-block align-center"
        />
        <span class="web-color ms-2">PRÁCTICAS - SALUD LABORAL</span>
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
            <a class="nav-link" href="#iniciarsesion">Iniciar Sesión</a>
          </li>
        </ul>
      </div>
    </div>
  </nav>

  <div id="carouselExampleCaptions" class="carousel slide carousel-shadow">
    <div class="carousel-indicators">
      <button
        type="button"
        data-bs-target="#carouselExampleCaptions"
        data-bs-slide-to="0"
        class="active"
        aria-current="true"
        aria-label="Slide 1"
      ></button>
      <button
        type="button"
        data-bs-target="#carouselExampleCaptions"
        data-bs-slide-to="1"
        aria-label="Slide 2"
      ></button>
    </div>
    <div class="carousel-inner">
      <div class="carousel-item active">
        <img src="../assets/img/01C.png" class="d-block w-100" alt="..." />
        <div class="carousel-caption d-none d-md-block">
          <h5 class="programacion">Prácticas de Enfermería</h5>
          <h5 class="intro">Salud Laboral</h5>
          <p class="carousel-02">
            La salud laboral es fundamental porque busca proteger el bienestar físico, mental y
            social de los trabajadores en su entorno laboral. Un ambiente de trabajo saludable no
            solo previene enfermedades y accidentes, sino que también mejora la calidad de vida, la
            productividad y el rendimiento de las personas.
          </p>
        </div>
      </div>
      <div class="carousel-item">
        <img src="../assets/img/02C.png" class="d-block w-100" alt="..." />
        <div class="carousel-caption d-none d-md-block">
          <h5>Departamento</h5>
          <h5 class="programacion">de Enfermería</h5>
          <p class="carousel-02">
            El Departamento de Enfermería de la Universidad Autónoma de Aguascalientes es una unidad
            académica comprometida con la formación integral de profesionales altamente capacitados
            en el cuidado de la salud. A través de un enfoque científico, ético y humanista, prepara
            a sus estudiantes para enfrentar los retos del entorno clínico, comunitario y laboral.
          </p>
        </div>
      </div>
      <button
        class="carousel-control-prev"
        type="button"
        data-bs-target="#carouselExampleCaptions"
        data-bs-slide="prev"
      >
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
      </button>
      <button
        class="carousel-control-next"
        type="button"
        data-bs-target="#carouselExampleCaptions"
        data-bs-slide="next"
      >
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
      </button>
    </div>
  </div>

  <section id="iniciarsesion">
    <div class="contenedor w-50">
      <!-- <form
        action="http://localhost:8080/Proyecto_SaludLaboral/ServletLogIn"
        method="post"
        class="formulario"
      > -->
      <div>
        <img src="../assets/img/uaa.png" alt="Logo 1" class="logo1" />
        <img src="../assets/img/uaa_enf.jpg" alt="Logo 2" class="logo2" />
      </div>

      <div class="campo">
        <label for="usuario">Usuario:</label>
        <input
          type="text"
          id="usuario"
          name="usuario"
          class="input-usuario"
          v-model="usuario"
          required
        />
      </div>

      <div class="campo">
        <label for="codigo">Contrase&ntilde;a:</label>
        <input
          type="password"
          id="codigo"
          name="codigo"
          class="input-codigo"
          v-model="contrasena"
          required
        />
      </div>

      <div class="d-flex justify-content-center">
        <button class="boton" @click="login">Ingresar</button>
      </div>
      <!-- </form> -->
      <div id="mensajeError" class="mensaje-error"></div>
    </div>
  </section>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      usuario: '',
      contrasena: '',
    }
  },
  methods: {
    async login() {
      var Estudiante = {
        id_estudiante: this.usuario,
        contrasena: this.contrasena,
      }
      const res = await this.$axios.post('https://localhost:44338/api/login', Estudiante)

      if (res.data.rol == 'user' || res.data.rol == 'admin') {
        localStorage.setItem('userSession', JSON.stringify(res.data))

        if (res.data.rol == 'user') {
          this.$router.push({ name: 'inicioalumno' })
        } else if (res.data.rol == 'admin') {
          this.$router.push({ name: 'inicioadmin' })
        }
      }

      console.log('datos')
      console.log(res.data)
    },
  },
}
</script>
