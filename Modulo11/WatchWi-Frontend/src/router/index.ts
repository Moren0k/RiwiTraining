
import { createRouter, createWebHistory } from "vue-router";
import LoginVue from "@/views/LoginVue.vue";
import RegisterVue from "@/views/RegisterVue.vue";
import HomeUserView from "@/views/HomeUserView.vue";
import AdminDashboardView from "@/views/AdminDashboardView.vue";
import ProfileView from "@/views/ProfileView.vue";
import FavoritesView from "@/views/FavoritesView.vue";

const routes = [
    { path: "/", component: LoginVue, name: 'login' },
    { path: "/register", component: RegisterVue, name: 'register' },
    { 
        path: "/home", 
        component: HomeUserView, 
        name: 'home',
        meta: { requiresAuth: true }
    },
    { 
        path: "/admin", 
        component: AdminDashboardView, 
        name: 'admin',
        meta: { requiresAuth: true, requiresAdmin: true }
    },
    { 
        path: "/profile", 
        component: ProfileView, 
        name: 'profile',
        meta: { requiresAuth: true }
    },
    { 
        path: "/favorites", 
        component: FavoritesView, 
        name: 'favorites',
        meta: { requiresAuth: true }
    },
];

export const router = createRouter({
  history: createWebHistory(),
  routes
});

router.beforeEach((to, from, next) => {
  const token = localStorage.getItem('accessToken');
  const userStr = localStorage.getItem('user');
  const isAuthenticated = !!token;

  // 1. Check if route requires auth
  if (to.meta.requiresAuth && !isAuthenticated) {
    return next('/');
  }

  // 2. Already logged in and going to login/register? Redirect to home
  if ((to.name === 'login' || to.name === 'register') && isAuthenticated) {
    return next('/home');
  }

  // 3. Admin specific logic
  if (to.meta.requiresAdmin) {
    try {
      const user = userStr ? JSON.parse(userStr) : null;
      if (user?.role === 'Admin') {
        next();
      } else {
        next('/home');
      }
    } catch (e) {
      next('/');
    }
    return;
  }

  next();
});