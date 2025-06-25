<template>
  <div id="iniciarsesion">
    <div class="container mx-auto p-4">
      <div class="contenedor bg-white p-6 rounded-lg shadow-lg">
        <h2
          class="text-2xl font-bold mb-6 text-center"
          style="font-family: 'DM Sans'; color: #2e4a80"
        >
          Cuestionario
        </h2>

        <div v-if="Preguntas" class="bg-white p-6 rounded-lg">
          <p class="font-semibold mb-4 text-lg" style="color: #4763b9">
            {{ Preguntas[idPregunta - 1].categoriaDescripcion }}
          </p>
          <p class="mb-4 text-gray-600">Pregunta {{ idPregunta }} de {{ Preguntas.length }} :</p>
          <p class="font-semibold mb-6 text-lg" style="color: #2e4a80">
            {{ Preguntas[idPregunta - 1].preguntaDescripcion }}
          </p>

          <div class="flex flex-col gap-4 mb-6">
            <label v-for="(option, idx) in Opciones" :key="idx">
              <div v-if="option.idPregunta == idPregunta">
                <div v-if="option.opcion == 'Booleano'">
                  <div class="form-check mb-3">
                    <input
                      v-model="RespuestaSi"
                      class="form-check-input h-4 w-4 border border-gray-300 rounded-sm bg-white checked:bg-blue-600 checked:border-blue-600 focus:outline-none transition duration-200 mt-1 align-top bg-no-repeat bg-center bg-contain float-left mr-2 cursor-pointer"
                      type="radio"
                      name="radioDefault"
                      id="radioDefault1"
                    />
                    <label class="form-check-label inline-block text-gray-800" for="radioDefault1">
                      Si
                    </label>
                  </div>
                  <div class="form-check">
                    <input
                      v-model="RespuestaNo"
                      class="form-check-input h-4 w-4 border border-gray-300 rounded-sm bg-white checked:bg-blue-600 checked:border-blue-600 focus:outline-none transition duration-200 mt-1 align-top bg-no-repeat bg-center bg-contain float-left mr-2 cursor-pointer"
                      type="radio"
                      name="radioDefault"
                      id="radioDefault2"
                    />
                    <label class="form-check-label inline-block text-gray-800" for="radioDefault2">
                      No
                    </label>
                  </div>
                </div>
                <div v-else-if="option.opcion == 'texto'">
                  <div class="campo">
                    <label for="usuario" class="block text-gray-700 mb-2">Respuesta</label>
                    <input
                      type="text"
                      id="usuario"
                      name="usuario"
                      class="input-usuario w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
                      v-model="Respuesta"
                    />
                  </div>
                </div>
                <div v-else>
                  <div class="form-check me-3 mb-3">
                    <input
                      v-model="Respuesta"
                      class="form-check-input h-4 w-4 border border-gray-300 rounded-sm bg-white checked:bg-blue-600 checked:border-blue-600 focus:outline-none transition duration-200 mt-1 align-top bg-no-repeat bg-center bg-contain float-left mr-2 cursor-pointer"
                      type="radio"
                      name="radioDefault"
                      :id="'radioOption' + idx"
                    />
                    <label
                      class="form-check-label inline-block text-gray-800"
                      :for="'radioOption' + idx"
                    >
                      {{ option.opcion }}
                    </label>
                  </div>
                </div>
              </div>
            </label>
          </div>

          <div class="flex justify-between mt-8">
            <button
              @click="prevQuestion"
              :disabled="idPregunta === 0"
              class="boton bg-gray-400 px-6 py-2 rounded-full disabled:opacity-50 font-medium"
              style="background-image: linear-gradient(to right, #a0aec0, #718096)"
            >
              Anterior
            </button>
            <button
              @click="nextQuestion"
              :disabled="Preguntas != null && idPregunta === Preguntas.length"
              class="boton px-6 py-2 rounded-full disabled:opacity-50 font-medium"
              style="background-image: linear-gradient(to right, #7ca6e2, #4763b8)"
            >
              Siguiente
            </button>
          </div>
        </div>

        <button
          @click="submitAnswers"
          v-if="Preguntas != null && idPregunta == Preguntas.length"
          class="boton w-full mt-6 px-6 py-3 rounded-full font-medium"
          style="background-image: linear-gradient(to right, #7ca6e2, #4763b8)"
        >
          Enviar Formulario
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      idPregunta: 1,
      questions: [],
      answers: [],
      CapturaRespuestas: null,
      Preguntas: null,
      Opciones: null,
      Respuesta: null,
      RespuestaSi: null,
      RespuestaNo: null,
    }
  },
  created() {},
  methods: {
    async nextQuestion() {
      if (this.RespuestaSi == 'on') {
        this.Respuesta = 'Si'
      }
      if (this.RespuestaNo == 'on') {
        this.Respuesta = 'No'
      }

      var CapRes = {
        Id_formulario: 0,
        Folio: this.CapturaRespuestas.formulario[0].folio,
        Fecha: this.CapturaRespuestas.formulario[0].fecha,
        Respuesta: this.Respuesta,
        Id_trabajador: this.CapturaRespuestas.trabajador.id_trabajador,
        Id_pregunta: this.idPregunta,
      }

      const res = await this.$axios.post('https://localhost:44338/api/GuardarRespuestas', CapRes)

      if (res.data > 0) {
        if (this.idPregunta <= this.Preguntas.length - 1) {
          this.idPregunta++

          //Limpiar respuestas
          this.RespuestaSi = null
          this.RespuestaNo = null
          this.Respuesta = null
        }
      }
    },
    prevQuestion() {
      if (this.idPregunta > 0) {
        this.idPregunta--
      }
    },
    submitAnswers() {
      if (this.RespuestaSi == 'on') {
        this.Respuesta = 'Si'
      }
      if (this.RespuestaNo == 'on') {
        this.Respuesta = 'No'
      }
      if (this.Respuesta == null) {
        alert('Responde la ultima pregunta!')
        return
      }
      alert('¡Respuestas enviadas!')
      //Borrar datos de local

      this.nextQuestion()
      localStorage.removeItem('DatosFormulario')
      this.$router.push('/')
    },
  },

  beforeCreate() {
    var session = JSON.parse(localStorage.getItem('DatosFormulario'))

    if (session == null) {
      this.$router.push('/')
    }
  },

  async mounted() {
    // Recuperar los datos del formulario
    //console.log(this.Preguntas)
    //Obtener Preguntas
    this.CapturaRespuestas = JSON.parse(localStorage.getItem('DatosFormulario'))

    const res = await this.$axios.post(
      'https://localhost:44338/api/ObtenerPreguntas',
      this.CapturaRespuestas,
    )
    //console.log(res)
    // Se asigna resultado a variable pregunta
    this.Preguntas = res.data

    //Consultar Opciones
    const op = await this.$axios.get('https://localhost:44338/api/ObtenerOpciones')
    // Se asigna resultado a variable opciones
    this.Opciones = op.data

    //console.log(this.Opciones)
  },
}
</script>
