<template>
  <div class="bloque-titulo">
    <h1>Cambiar datos del Estudiante</h1>
  </div>
  <div class="centro">
    <br /><br />
    <form>
      <label for="idActual">ID Actual del alumno:</label>
      <input
        v-model="id_estudiante"
        type="number"
        id="idActual"
        name="idActual"
        required
      /><br /><br />

      <p class="d-flex justify-content-center">
        Llene el campo que desee modificar con los cambios que quiere:
      </p>
      <br />

      <!-- <label for="idNuevo">Nuevo ID del alumno:</label>
      <input type="number" id="idNuevo" name="idNuevo" /><br /><br /> -->

      <label for="nombre">Nombre:</label>
      <input v-model="nombre" type="text" id="nombre" name="nombre" /><br /><br />

      <label for="apellidos">Apellidos:</label>
      <input v-model="apellidos" type="text" id="apellidos" name="apellidos" /><br /><br />

      <label for="grupo">Grupo:</label>
      <input v-model="grupo" type="text" id="grupo" name="grupo" /><br /><br />

      <label for="password">Contrase&ntilde;a:</label>
      <input v-model="contrasena" type="text" id="password" name="password" /><br /><br />

      <label for="rol" class="label centro">Rol:</label>
      <select v-model="rol" id="rol" name="rol" class="select w-25" required>
        <option value="">Seleccione una opci&oacute;n</option>
        <option value="user">Alumno</option>
        <option value="admin">Administrador</option></select
      ><br />
      <br />

      <input @click="ModificarUsuario" class="boton" value="Enviar" />
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
      nombre: null,
      apellidos: null,
      grupo: null,
      contrasena: null,
      rol: null,
    }
  },
  methods: {
    async ModificarUsuario() {
      var Usuario = {
        Id_estudiante: this.id_estudiante,
        Nombre: this.nombre,
        Apellidos: this.apellidos,
        Grupo: this.grupo,
        Contrasena: this.contrasena,
        Rol: this.rol,
      }
      console.log(Usuario)
      await this.$axios.post('https://localhost:44338/api/ModificarUsuario', Usuario)
      this.LimpiarCampos()
      alert('¡Usuario actualizado con éxito!')
    },

    async LimpiarCampos() {
      this.id_estudiante = null
      this.nombre = null
      this.apellidos = null
      this.grupo = null
      this.contrasena = null
      this.rol = null
    },
  },
}
</script>
