<script setup lang="ts">
import { ref } from 'vue';
import { useAuthStore } from '@/stores/auth';
import { AuthService } from '@/services/AuthService';
import { useRouter } from 'vue-router';

const username = ref('');
const email = ref('');
const password = ref('');
const loading = ref(false);
const errorMsg = ref('');
const authStore = useAuthStore();
const router = useRouter();

async function handleRegister() {
  if (!username.value || !email.value || !password.value) {
    errorMsg.value = 'Por favor completa todos los campos';
    return;
  }

  loading.value = true;
  errorMsg.value = '';

  try {
    const response = await AuthService.register(username.value, email.value, password.value);

    // Auto-login after register
    authStore.setToken(response.accessToken);
    authStore.setUser(response.user);

    router.push('/home');
  } catch (err: any) {
    console.error(err);
    if (err.response && err.response.data) {
      // Suponiendo que el backend devuelve un mensaje de error
      errorMsg.value = 'Error al registrarse. Verifica tus datos.';
    } else {
      errorMsg.value = 'Error de conexión. Intenta más tarde.';
    }
  } finally {
    loading.value = false;
  }
}
</script>

<template>
  <div data-page="auth">
    <div data-card="register">
      <h1>WatchWi</h1>
      <h2>Crear Cuenta</h2>

      <form @submit.prevent="handleRegister">
        <div>
          <label for="username">Nombre de Usuario</label>
          <input
            id="username"
            v-model="username"
            type="text"
            placeholder="Tu nombre de usuario"
            required
          />
        </div>

        <div>
          <label for="email">Email</label>
          <input
            id="email"
            v-model="email"
            type="email"
            placeholder="ejemplo@correo.com"
            required
          />
        </div>

        <div>
          <label for="password">Contraseña</label>
          <input
            id="password"
            v-model="password"
            type="password"
            placeholder="••••••••"
            required
          />
        </div>

        <div v-if="errorMsg">
          {{ errorMsg }}
        </div>

        <button type="submit" :disabled="loading">
          <span v-if="loading">Cargando...</span>
          <span v-else>Registrarse</span>
        </button>
      </form>

      <div>
        ¿Ya tienes cuenta? <router-link to="/">Inicia sesión</router-link>
      </div>
    </div>
  </div>
</template>

<style scoped>
/* Layout: full-screen, centrado, ambient glow (consistente con Login) */
[data-page="auth"] {
  min-height: 100vh;
  display: grid;
  place-items: center;
  padding: var(--space-6);
  position: relative;
}

[data-page="auth"]::before {
  content: "";
  position: fixed;
  inset: 0;
  z-index: -1;
  pointer-events: none;

  background:
    radial-gradient(900px circle at 20% 18%, rgba(177, 0, 255, 0.12), transparent 55%),
    radial-gradient(1100px circle at 85% 35%, rgba(124, 0, 255, 0.10), transparent 60%),
    radial-gradient(900px circle at 55% 95%, rgba(177, 0, 255, 0.06), transparent 55%);
}

/* Card */
[data-card="register"] {
  width: min(460px, 100%);
  border-radius: var(--radius-3);
  padding: clamp(22px, 4vw, 34px);

  background: linear-gradient(
      180deg,
      rgba(22, 17, 31, 0.88),
      rgba(15, 12, 20, 0.88)
    );

  border: 1px solid rgba(255, 255, 255, 0.10);

  box-shadow:
    var(--shadow-2),
    0 0 0 1px rgba(177, 0, 255, 0.12),
    0 0 42px rgba(177, 0, 255, 0.16);

  position: relative;
  overflow: hidden;
}

[data-card="register"]::before {
  content: "";
  position: absolute;
  inset: -2px;
  pointer-events: none;
  border-radius: inherit;

  background: radial-gradient(
    700px circle at 18% 0%,
    rgba(177, 0, 255, 0.16),
    transparent 55%
  );
}

/* Branding */
h1 {
  margin: 0 0 var(--space-2);
  font-size: 28px;
  font-weight: 900;
  letter-spacing: 1px;

  color: var(--color-primary);
  text-shadow: 0 0 18px var(--color-glow);
}

h2 {
  margin: 0 0 var(--space-8);
  font-size: 14px;
  font-weight: 600;
  color: var(--color-muted);
  letter-spacing: 0.3px;
}

/* Form spacing */
form {
  display: flex;
  flex-direction: column;
  gap: var(--space-4);
}

/* Field group */
form > div {
  display: flex;
  flex-direction: column;
  gap: var(--space-2);
}

label {
  font-size: 12px;
  font-weight: 700;
  color: rgba(241, 241, 243, 0.78);
  letter-spacing: 0.2px;
}

/* Inputs */
input {
  border-radius: var(--radius-2);
  border: 1px solid rgba(255, 255, 255, 0.10);
  background: rgba(0, 0, 0, 0.30);
  color: var(--color-text);

  padding: 12px 12px;

  outline: none;
  transition: border-color 160ms ease, box-shadow 160ms ease, background-color 160ms ease;
}

input::placeholder {
  color: rgba(166, 161, 179, 0.55);
}

input:focus {
  border-color: rgba(177, 0, 255, 0.45);
  box-shadow: 0 0 0 3px rgba(177, 0, 255, 0.18);
  background: rgba(0, 0, 0, 0.38);
}

/* Error message (tu div v-if="errorMsg") */
form > div[v-if] {
  border: 1px solid rgba(255, 59, 107, 0.25);
  background: rgba(255, 59, 107, 0.10);
  color: #ffd1dc;

  padding: 10px 12px;
  border-radius: var(--radius-2);
  font-size: 13px;
  font-weight: 650;
  text-align: center;
}

/* Submit button */
button[type="submit"] {
  margin-top: var(--space-2);

  border: 1px solid rgba(255, 255, 255, 0.10);
  border-radius: var(--radius-2);

  background: linear-gradient(180deg, var(--color-primary), var(--color-primary-2));
  color: #fff;

  padding: 12px 14px;
  font-weight: 800;
  letter-spacing: 0.3px;

  cursor: pointer;

  box-shadow: 0 0 22px rgba(177, 0, 255, 0.22);
  transition: transform 160ms ease, box-shadow 160ms ease, filter 160ms ease;
}

button[type="submit"]:hover:not(:disabled) {
  filter: brightness(1.05);
  box-shadow: 0 0 28px rgba(177, 0, 255, 0.28);
}

button[type="submit"]:active:not(:disabled) {
  transform: translateY(1px);
}

button[type="submit"]:disabled {
  opacity: 0.65;
  cursor: not-allowed;
  box-shadow: none;
}

/* Footer link */
[data-card="register"] > div:last-child {
  margin-top: var(--space-8);
  color: rgba(166, 161, 179, 0.85);
  font-size: 13px;
}

a {
  color: rgba(241, 241, 243, 0.92);
  text-decoration: none;
  font-weight: 750;
  border-bottom: 1px solid rgba(177, 0, 255, 0.35);
  transition: color 160ms ease, border-color 160ms ease, text-shadow 160ms ease;
}

a:hover {
  color: var(--color-text);
  border-bottom-color: rgba(177, 0, 255, 0.75);
  text-shadow: 0 0 16px rgba(177, 0, 255, 0.25);
}

/* Responsive */
@media (max-width: 420px) {
  h1 {
    font-size: 24px;
  }

  h2 {
    margin-bottom: var(--space-6);
  }
}

/* Reduce motion */
@media (prefers-reduced-motion: reduce) {
  input,
  button[type="submit"],
  a {
    transition: none;
  }
}
</style>
