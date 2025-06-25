<template>
  <div class="bloque-titulo">
    <h1>Dar de Baja al Estudiante</h1>
  </div>
  <div class="centro">
    <br /><br />
    <form>
      <label for="id">ID del alumno:</label>
      <input v-model="id_estudiante" type="number" id="id" name="id" required /><br /><br />

      <input @click="ConfirmarBaja" class="boton" value="Eliminar" />
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
    }
  },
  methods: {
    async ConfirmarBaja() {
      var id = {
        Id_estudiante: this.id_estudiante,
      }

      await this.$axios.post('https://localhost:44338/api/EliminarUsuario', id)
      this.LimpiarCampos()
      alert('¡Usuario eliminado con éxito!')
    },

    async LimpiarCampos() {
      this.id_estudiante = null
    },
  },
}
</script>
