<template>
  <div class="bloque-titulo">
    <h1>I. FACTORES CONDICIONANTES B&Aacute;SICOS</h1>
  </div>
  <div class="contenedor">
    <br />
    <form
      action="http://localhost:8080/Proyecto_SaludLaboral/ServletGuardarRespuestas"
      method="post"
    >
      <!-- Página 1 -->
      <div class="pagina" id="pagina1">
        <fieldset class="fieldset">
          <legend>Descriptivos de la Persona</legend>

          <label for="folio" class="label">Folio:</label>
          <input
            type="text"
            v-model="folio"
            id="folio"
            name="folio"
            class="input"
            required
          /><br /><br />

          <label for="fecha" class="label">Fecha:</label>
          <input type="date" v-model="fecha" id="fecha" name="fecha" class="input" required />
          <br /><br />

          <label for="nombre" class="label">Nombre:</label>
          <input type="text" v-model="nombre" id="nombre" name="nombre" class="input" required />
          <br /><br />

          <label for="apellidos" class="label">Apellidos:</label>
          <input
            type="text"
            id="apellidos"
            v-model="apellidos"
            name="apellidos"
            class="input"
            required
          />
          <br /><br />

          <label for="edad" class="label">Edad:</label>
          <input
            type="number"
            v-model="edad"
            id="edad"
            name="edad"
            class="input"
            required
          /><br /><br />

          <label for="sexo" class="label">Sexo:</label>
          <select id="sexo" name="sexo" class="select" v-model="sexo" required>
            <option value="">Seleccione una opci&oacute;n</option>
            <option value="Masculino">Masculino</option>
            <option value="Femenino">Femenino</option>
            <option value="Prefiero no Contestar">Prefiero no Contestar</option></select
          ><br /><br />

          <label for="estadocivil" class="label">Estado Civil:</label>
          <select
            id="estadocivil"
            name="estadocivil"
            v-model="estado_civil"
            class="select"
            required
          >
            <option value="">Seleccione una opci&oacute;n</option>
            <option value="Soltero">Soltero</option>
            <option value="Casado">Casado</option>
            <option value="Divorciado">Divorciado</option>
            <option value="Union Libre">Union Libre</option>
            <option value="Viudo">Viudo</option>
            <option value="Otro">Otro</option></select
          ><br /><br />

          <label for="escolaridad" class="label">Escolaridad:</label>
          <select id="escolaridad" name="escolaridad" v-model="escolaridad" class="select" required>
            <option value="">Seleccione una opci&oacute;n</option>
            <option value="Prescolar">Prescolar</option>
            <option value="Primaria">Primaria</option>
            <option value="Secundaria">Secundaria</option>
            <option value="Media Superior">Media Superior</option>
            <option value="Superior">Superior</option>
            <option value="Otro">Otro</option></select
          ><br /><br />

          <label for="empresa" class="label">Empresa:</label>
          <input
            type="text"
            id="empresa"
            name="empresa"
            v-model="nombre_empresa"
            class="input"
            required
          /><br /><br />
        </fieldset>
        <div class="navegacion">
          <button type="button" class="boton-completo" @click="siguiente">
            <span class="flecha">&#x25B6;</span> Siguiente
          </button>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      id_trabajador: null,
      nombre: null,
      apellidos: null,
      edad: null,
      sexo: null,
      estado_civil: null,
      escolaridad: null,
      id_empresa: null,
      nombre_empresa: null,
      folio: null,
      fecha: null,
      respuesta: null,
      id_pregunta: null,
    }
  },

  methods: {
    async siguiente() {
      var Trabajador = {
        id_trabajador: this.id_trabajador,
        nombre: this.nombre,
        apellidos: this.apellidos,
        edad: this.edad,
        sexo: this.sexo,
        estado_civil: this.estado_civil,
        escolaridad: this.escolaridad,
        id_empresa: this.id_empresa,
      }
      var Empresa = {
        id_empresa: this.id_empresa,
        nombre: this.nombre_empresa,
      }
      var Formulario = [
        {
          id_formulario: this.id_empresa,
          folio: this.folio,
          fecha: this.fecha,
          respuesta: this.respuesta,
          id_trabajador: this.id_trabajador,
          id_pregunta: this.id_pregunta,
        },
      ]

      var CapturaFormulario = {
        Trabajador,
        Empresa,
        Formulario,
      }
      console.log(CapturaFormulario)
      const res = await this.$axios.post(
        'https://localhost:44338/api/GuardarDatosFormulario',
        CapturaFormulario,
      )

      console.log(res)

      localStorage.setItem('DatosFormulario', JSON.stringify(res.data))

      //Captura de preguntas de formulario
      this.$router.push('/formulario2')
    },
  },
}
</script>
