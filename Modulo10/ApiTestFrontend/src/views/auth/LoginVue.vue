<script setup lang='ts'>
import { ref } from 'vue';
import { AuthService } from '@/services/AuthService';
import type { LoginRequest, AuthResponse } from '@/models/AuthModels';
import { useRouter } from "vue-router";

const router = useRouter();
const email = ref("");
const password = ref("");

async function handleLogin() {

  const request: LoginRequest = {
    email: email.value,
    password: password.value,
  };

  try {
    const response: AuthResponse = await AuthService.authLogin(request);

    const { accessToken, user } = response;

    localStorage.setItem("auth_token", accessToken);
    localStorage.setItem("user_role", user.role);

    if (user.role === "Admin") {
      router.push("/admin");
    } else {
      router.push("/user");
    }

    alert(`Bienvenido ${user.name}`);
  } catch (error) {
    alert("Usuario o contraseña incorrectos");
  }
}
</script>

<template>
  <div>
    <div>
      <h1>Bienvenido</h1>
      <p>Ingresa tus credenciales para continuar</p>

      <div>
        <label>Email</label>
        <input
          v-model="email"
          type="email"
          placeholder="correo@ejemplo.com"
        />
      </div>

      <div>
        <label>Contraseña</label>
        <input
          v-model="password"
          type="password"
          placeholder="••••••••"
        />
      </div>

      <button @click="handleLogin">
        Iniciar Sesión
      </button>

      <p>
        ¿No tienes cuenta?
        <router-link to="/register">Registrarse</router-link>
      </p>
    </div>
  </div>
</template>
