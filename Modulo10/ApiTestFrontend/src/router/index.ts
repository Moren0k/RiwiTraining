import { createRouter, createWebHistory } from "vue-router";
import LoginVue from "@/views/auth/LoginVue.vue";
import RegisterVue from "@/views/auth/RegisterVue.vue";
import AdminView from "@/views/admin/AdminView.vue";
import UserViwe from "@/views/user/UserViwe.vue";

const routes = [
    {path: "/login", component: LoginVue},
    {path: "/register", component: RegisterVue},
    {path: "/admin", component: AdminView},
    {path: "/user", component: UserViwe}
];

export const router = createRouter({
  history: createWebHistory(),
  routes
});