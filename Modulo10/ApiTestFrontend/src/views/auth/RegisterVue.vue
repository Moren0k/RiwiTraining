<script setup lang='ts'>
import { ref } from 'vue';
import { AuthService } from '@/services/AuthService';
import type { RegisterRequest, AuthResponse } from '@/models/AuthModels';


const name = ref("");
const email = ref("");
const password = ref("");
const isAdmin = ref(false)

async function handleRegister() {

    const request: RegisterRequest = {
        name: name.value,
        email: email.value,
        password: password.value,
        isAdmin: isAdmin.value
    }

    try {
        const response: AuthResponse = await AuthService.authRegister(request);

        const { accessToken, user } = response;
        localStorage.setItem("auth_token", accessToken);
        localStorage.setItem("user_role", user.role)

        alert(`Bievenido ${user.name} te has registrado correctamente`)
    } catch (error) {
        alert("Registro no exitoso")
    }
}
</script>

<template>
  <div>
    <div>
      <h1>Crear Cuenta</h1>
      <p>Completa tus datos para empezar</p>

      <div>
        <label>Nombre Completo</label>
        <input v-model="name" placeholder="Tu nombre" />
      </div>

      <div>
        <label>Correo Electrónico</label>
        <input v-model="email" type="email" placeholder="ejemplo@correo.com" />
      </div>

      <div>
        <label>Contraseña</label>
        <input v-model="password" type="password" placeholder="Mínimo 8 caracteres" />
      </div>

      <div>
        <input type="checkbox" v-model="isAdmin" id="adminCheck" />
        <label for="adminCheck">
          Solicitar privilegios de <strong>Administrador</strong>
        </label>
      </div>

      <button @click="handleRegister">
        Registrarse ahora
      </button>

      <div>
        <span>
          ¿Ya tienes cuenta?
          <router-link to="/login">Inicia sesión</router-link>
        </span>
      </div>
    </div>
  </div>
</template>
