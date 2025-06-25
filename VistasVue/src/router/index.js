import { createRouter, createWebHistory } from 'vue-router'
import Login from '@/views/Login.vue'

import InicioAdmin from '@/views/Admin/InicioAdmin.vue'
import guia from '@/views/Admin/guia.vue'
import formulario from '@/views/Admin/formulario.vue'
import formulario2 from '@/views/Admin/formulario2.vue'
import ayuda from '@/views/Admin/ayuda.vue'
import AdminUser from '@/views/Admin/AdminUser.vue'
import AgregarUser from '@/views/Admin/AgregarUser.vue'
import ConsultaUser from '@/views/Admin/ConsultaUser.vue'
import EliminarUser from '@/views/Admin/EliminarUser.vue'
import Informe from '@/views/Admin/Informe.vue'
import ModificarUser from '@/views/Admin/ModificarUser.vue'
import Resultados from '@/views/Admin/Resultados.vue'
import InicioAlumno from '@/views/User/InicioAlumno.vue'
import resultado from '@/views/Admin/resultado.vue'
import NoAutorizado from '@/views/Admin/NoAutorizado.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'login',
      component: Login,
      meta: { requiresAuth: false, requiredRole: 'all' },
    },
    {
      path: '/noautorizado',
      name: 'noautorizado',
      component: NoAutorizado,
      meta: { requiresAuth: true, requiredRole: 'all' },
    },
    {
      path: '/resultado',
      name: 'resultado',
      component: resultado,
      meta: { requiresAuth: true, requiredRole: 'all' },
    },
    {
      path: '/inicioadmin',
      name: 'inicioadmin',
      component: InicioAdmin,
      meta: { requiresAuth: true, requiredRole: 'admin' },
    },
    {
      path: '/guia',
      name: 'guia',
      component: guia,
      meta: { requiresAuth: true, requiredRole: 'all' },
    },
    {
      path: '/formulario',
      name: 'formulario',
      component: formulario,
      meta: { requiresAuth: true, requiredRole: 'all' },
    },
    {
      path: '/formulario2',
      name: 'formulario2',
      component: formulario2,
      meta: { requiresAuth: true, requiredRole: 'all' },
    },
    {
      path: '/ayuda',
      name: 'ayuda',
      component: ayuda,
      meta: { requiresAuth: true, requiredRole: 'all' },
    },
    {
      path: '/adminuser',
      name: 'adminuser',
      component: AdminUser,
      meta: { requiresAuth: true, requiredRole: 'admin' },
    },
    {
      path: '/agregaruser',
      name: 'agregaruser',
      component: AgregarUser,
      meta: { requiresAuth: true, requiredRole: 'admin' },
    },
    {
      path: '/consultauser',
      name: 'consultauser',
      component: ConsultaUser,
      meta: { requiresAuth: true, requiredRole: 'admin' },
    },
    {
      path: '/eliminaruser',
      name: 'eliminaruser',
      component: EliminarUser,
      meta: { requiresAuth: true, requiredRole: 'admin' },
    },
    {
      path: '/informe',
      name: 'informe',
      component: Informe,
      meta: { requiresAuth: true, requiredRole: 'admin' },
    },
    {
      path: '/modificaruser',
      name: 'modificaruser',
      component: ModificarUser,
      meta: { requiresAuth: true, requiredRole: 'admin' },
    },
    {
      path: '/resultados',
      name: 'resultados',
      component: Resultados,
      meta: { requiresAuth: true, requiredRole: 'admin' },
    },
    {
      path: '/inicioalumno',
      name: 'inicioalumno',
      component: InicioAlumno,
      meta: { requiresAuth: true, requiredRole: 'user' },
    },
  ],
})

router.beforeEach((to, from, next) => {
  // Comprueba si esta logeado
  const isAuthenticated = JSON.parse(localStorage.getItem('userSession'))
  // Variables de las rutas para saber si requiere la autenticacion o que este logeado
  const requiresAuth = to.matched.some((record) => record.meta.requiresAuth)
  // Requiere un rol especifico
  const requiredRole = to.meta.requiredRole

  // Si no hay sesion continua con el login
  if (isAuthenticated === null) {
    next()
  }

  // Validacion de roles, valida si necesita autentificacion
  if (to.meta.requiresAuth && !isAuthenticated) {
    next('/')
  } else {
    //Valida si requiere autenticacion y valida que sea el rol correcto
    if (requiresAuth && (requiredRole == 'all' || isAuthenticated.rol === requiredRole)) {
      next()
    } else {
      // Si la ruta es el login y es usuario lo manda a inicio alumno
      if (to.path === '/' && isAuthenticated.rol == 'user') return next('/inicioalumno')
      // Si la ruta es el login y es usuario lo manda a inicio admin
      else if (to.path === '/' && isAuthenticated.rol == 'admin') return next('/inicioadmin')
      // Si la ruta no existe o no tiene permisos con el rol lo enviara a una ventana de "no autorizado"
      else return next('/noautorizado') // o alguna vista de acceso denegado
    }
  }
})

export default router
