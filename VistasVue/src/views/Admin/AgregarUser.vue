<template>
  <div class="bloque-titulo">
    <h1>Dar de alta a Estudiante</h1>
  </div>
  <div class="centro">
    <br /><br />
    <form>
      <label for="id">ID del alumno:</label>
      <input v-model="id_estudiante" type="number" id="id" name="id" required /><br /><br />

      <label for="nombre">Nombre:</label>
      <input v-model="nombre" type="text" id="nombre" name="nombre" required /><br /><br />

      <label for="apellidos">Apellidos:</label>
      <input v-model="apellidos" type="text" id="apellidos" name="apellidos" required /><br /><br />

      <label for="grupo">Grupo:</label>
      <input v-model="grupo" type="text" id="grupo" name="grupo" required /><br /><br />

      <label for="password">Contrase&ntilde;a:</label>
      <input v-model="contrasena" type="text" id="password" name="password" required /><br /><br />

      <label for="rol" class="label centro">Rol:</label>
      <select id="rol" name="rol" v-model="rol" class="select w-25" required>
        <option value="">Seleccione una opci&oacute;n</option>
        <option value="user">Alumno</option>
        <option value="admin">Administrador</option></select
      ><br />
      <br />
      <br />

      <input @click="AgregarUser" class="boton" value="Enviar" />

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
    async AgregarUser() {
      var Usuario = {
        Id_estudiante: this.id_estudiante,
        Nombre: this.nombre,
        Apellidos: this.apellidos,
        Grupo: this.grupo,
        Contrasena: this.contrasena,
        Rol: this.rol,
      }

      await this.$axios.post('https://localhost:44338/api/AgregarUsuario', Usuario)
      this.LimpiarCampos()
      alert('¡Usuario registrado con éxito!')
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
