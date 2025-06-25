<template>
  <div>
    <nav class="navbar sticky-top navbar-expand-sm navbar-dark">
      <div class="container-fluid">
        <div class="navbar-center">
          <a class="navbar-brand ms-2" href="#">
            <span class="web-color ms-2">Información de Trabajadores</span>
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
      </div>
    </nav>

    <br />
    <!-- DataGrid (Tabla) -->

    <div class="table-responsive">
      <table class="table table-hover table-bordered rounded-lg overflow-hidden shadow-lg">
        <thead class="table-header">
          <tr>
            <th>#</th>
            <th>Nombre</th>
            <th>Apellido</th>
            <th>Edad</th>
            <th>Sexo</th>
            <th>Estado Civil</th>
            <th>Escolaridad</th>
            <th>% Valoración</th>
            <th>Valoración</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(trabajador, index) in trabajadores" :key="index" class="table-row">
            <td>{{ index + 1 }}</td>
            <td>{{ trabajador.nombre }}</td>
            <td>{{ trabajador.apellidos }}</td>
            <td>{{ trabajador.edad }}</td>
            <td>{{ trabajador.sexo }}</td>
            <td>{{ trabajador.estado_Civil }}</td>
            <td>{{ trabajador.escolaridad }}</td>
            <td>{{ trabajador.porcentajeValoracion }}%</td>
            <td>{{ trabajador.resultadoValoracion }}</td>
          </tr>
        </tbody>
      </table>
    </div>
    <br />

    <p><router-link to="/informe" class="regresar"> Regresar </router-link></p>
  </div>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      trabajadores: [],
    }
  },
  methods: {},
  async mounted() {
    const res = await this.$axios.post('https://localhost:44338/api/ConsultarTrabajador', {})
    this.trabajadores = res.data
    console.log(res)
  },
}
</script>

<style>
.table {
  width: 100%;
  border-collapse: separate;
  border-spacing: 0;
  font-family: 'Montserrat', sans-serif;
}

.table-row:hover {
  background-color: #e6f0ff;
}
.table-header {
  background-image: linear-gradient(to right, #a8c4f0, #7ca6e2);
  color: white;
  text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
}

.table-header th {
  padding: 12px 15px;
  text-align: left;
  font-family: 'DM Sans', sans-serif;
  font-weight: 600;
}

.table-row td {
  padding: 12px 15px;
  border-bottom: 1px solid #e0e0e0;
}

.table-bordered {
  border: 1px solid #dee2e6;
}

.table-bordered th,
.table-bordered td {
  border: 1px solid #dee2e6;
}

.rounded-lg {
  border-radius: 15px;
}

.shadow-lg {
  box-shadow:
    0 10px 15px -3px rgba(0, 0, 0, 0.1),
    0 4px 6px -2px rgba(0, 0, 0, 0.05);
}

.navbar-toggler-icon {
  background-image: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 30 30'%3e%3cpath stroke='rgba%28255, 255, 255, 1%29' stroke-linecap='round' stroke-miterlimit='10' stroke-width='2' d='M4 7h22M4 15h22M4 23h22'/%3e%3c/svg%3e");
}
</style>
