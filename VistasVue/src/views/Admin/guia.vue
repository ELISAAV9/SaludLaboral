<template>
  <div class="container my-5">
    <div class="row justify-content-center">
      <div class="col-md-10">
        <div class="card shadow rounded-4">
          <div class="card-body">
            <h1 class="text-center mb-4">GUÍA DE EVALUACIÓN</h1>

            <!-- PDF embebido -->
            <div class="ratio ratio-16x9">
              <embed src="/doc/evaluacion.pdf" type="application/pdf" />
            </div>

            <div class="text-center mt-4">
              <a href="/doc/evaluacion.pdf" class="btn btn-primary" target="_blank">
                <i class="bi bi-file-earmark-pdf"></i> Ver PDF en pestaña nueva
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
