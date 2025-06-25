<template>
  <div class="bloque-titulo">
    <h1>Ver resultados del Trabajador</h1>
  </div>
  <div class="centro">
    <br /><br />
    <form action="http://localhost:8080/Proyecto_SaludLaboral/ServletInforme" method="post">
      <label for="id">ID del Trabajador:</label>
      <input type="number" id="id" name="id" required /><br /><br />

      <label for="folio">Folio del formulario:</label>
      <input type="text" id="folio" name="folio" required /><br /><br />

      <input type="submit" class="boton" value="Enviar" />
      <input type="reset" value="Limpiar" class="boton" />
    </form>

    <br />
    <p><a href="../Admin/Informe.vue" class="regresar">Regresar</a></p>
  </div>
</template>

<script></script>
