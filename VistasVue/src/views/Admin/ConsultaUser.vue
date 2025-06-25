<template>
  <div class="bloque-titulo">
    <h1>Consultar datos del Estudiante</h1>
  </div>
  <div class="centro">
    <br /><br />
    <form
      action="http://localhost:8080/Proyecto_SaludLaboral/ServletConsultarUsuario"
      method="post"
    >
      <p class="d-flex justify-content-center">
        Llene el campo del atributo que quiera con lo que desee consultar:
      </p>
      <br />

      <label for="id">ID: </label>
      <input v-model="id_estudiante" type="number" id="id" name="id" /><br /><br />

      <div>
        <label for="nombre">Nombre:</label>
        {{ estudiante.nombre }}
      </div>
      <br /><br />

      <div>
        <label for="apellidos">Apellidos:</label>
        {{ estudiante.apellidos }}
      </div>
      <br /><br />

      <div>
        <label for="grupo">Grupo:</label>
        {{ estudiante.grupo }}
      </div>
      <br /><br />

      <div>
        <label for="grupo">Rol:</label>
        {{ estudiante.rol }}
      </div>
      <br /><br />

      <p class="d-flex justify-content-center">
        Si desea ver todos los estudiantes registrados s&oacute;lo presione Enviar:
      </p>
      <br />

      <input @click="ObtenerUsuario" class="boton" value="Enviar" />
      <input @click="LimpiarCampos" value="Limpiar" class="boton" />
    </form>
    <br />
    <p><router-link to="/AdminUser" class="regresar"> Regresar </router-link></p>
  </div>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      id_estudiante: null,
      estudiante: {},
    }
  },
  methods: {
    async ObtenerUsuario() {
      var Usuario = {
        Id_estudiante: this.id_estudiante,
      }
      console.log(Usuario)
      const res = await this.$axios.post('https://localhost:44338/api/ConsultarUsuario', Usuario)
      console.log(res)

      this.estudiante = res.data
    },

    async LimpiarCampos() {
      this.id_estudiante = null
      this.estudiante = {}
    },
  },
}
</script>
