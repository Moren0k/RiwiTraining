<template>
  <HeaderNetflix />
  
  <main data-page="profile">
    <div data-container="form">
      <header class="view-header">
        <h1>Mi Perfil</h1>
      </header>

      <section class="profile-section">
        <div class="avatar-card">
          <div class="avatar-preview">
            <img 
              :src="displayAvatar" 
              alt="Avatar" 
              @error="handleImageError"
            />
            <div v-if="uploading" class="upload-overlay">
              <span class="spinner"></span>
            </div>
          </div>
          <div class="avatar-info">
            <h3>Foto de perfil</h3>
            <div class="avatar-actions">
              <label class="btn-upload" :class="{ disabled: uploading }">
                {{ uploading ? 'Subiendo...' : 'Cambiar foto' }}
                <input type="file" @change="handleFileChange" accept="image/*" :disabled="uploading" hidden />
              </label>
            </div>
          </div>
        </div>

        <!-- USERNAME FORM -->
        <div class="info-card">
          <h3>Información de la cuenta</h3>
          <form @submit.prevent="handleUpdateUsername" class="profile-form">
            <div class="field">
              <label>Nombre de usuario</label>
              <input v-model="username" type="text" placeholder="Tu nombre" required minlength="3" />
            </div>
            <div class="field disabled">
              <label>Correo electrónico</label>
              <input :value="authStore.user?.email" type="email" disabled />
              <small>El correo no se puede cambiar.</small>
            </div>
            
            <button type="submit" class="btn-primary" :disabled="updating || username === authStore.user?.username">
              {{ updating ? 'Guardando...' : 'Guardar cambios' }}
            </button>
          </form>
        </div>
      </section>
    </div>
  </main>
</template>

<script setup lang="ts">
import { ref, computed, watch } from 'vue';
import HeaderNetflix from '@/components/layout/HeaderNetflix.vue';
import { useAuthStore } from '@/stores/auth';
import { useToastStore } from '@/stores/toast';
import { UsersService } from '@/services/UsersService';

const authStore = useAuthStore();
const toastStore = useToastStore();

const username = ref(authStore.user?.username || '');
const updating = ref(false);
const uploading = ref(false);
const avatarPreview = ref<string | null>(null);

const avatarError = ref(false);
const DUMMY_AVATAR = 'https://res.cloudinary.com/dj8l87pnr/image/upload/v1738507205/ImgProfiles/dummy_p3u2r6.png';

const displayAvatar = computed(() => {
  if (avatarPreview.value) return avatarPreview.value;
  if (avatarError.value || !authStore.user?.profileImageUrl) return DUMMY_AVATAR;
  return authStore.user.profileImageUrl;
});

const handleImageError = () => {
  if (!avatarError.value) avatarError.value = true;
};

watch(() => authStore.user?.profileImageUrl, () => {
  avatarError.value = false;
});
watch(avatarPreview, () => {
  avatarError.value = false;
});

const handleFileChange = async (event: Event) => {
  const target = event.target as HTMLInputElement;
  const file = target.files?.[0];
  if (!file) return;

  // Local preview
  const reader = new FileReader();
  reader.onload = (e) => {
    avatarPreview.value = e.target?.result as string;
  };
  reader.readAsDataURL(file);

  // Upload
  uploading.value = true;
  try {
    const updatedUser = await UsersService.uploadProfileImage(file);
    authStore.setUser(updatedUser);
    toastStore.success('Imagen de perfil actualizada');
  } catch (error) {
    console.error('Upload failed:', error);
    avatarPreview.value = null;
  } finally {
    uploading.value = false;
  }
};

const handleUpdateUsername = async () => {
  if (username.value === authStore.user?.username) return;
  
  updating.value = true;
  try {
    const updatedUser = await UsersService.updateProfile(username.value);
    authStore.setUser(updatedUser);
    toastStore.success('Nombre de usuario actualizado');
  } catch (error) {
    console.error('Update failed:', error);
  } finally {
    updating.value = false;
  }
};
</script>

<style scoped>
[data-page="profile"] {
  min-height: calc(100vh - 64px);
  padding: var(--space-10) var(--space-4);
  display: flex;
  justify-content: center;
}

[data-container="form"] {
  width: 100%;
  max-width: 800px;
  display: flex;
  flex-direction: column;
  gap: var(--space-8);
}

.view-header h1 {
  font-size: 32px;
  font-weight: 900;
  margin: 0 0 var(--space-2);
}

.view-header p {
  color: var(--color-muted);
}

.profile-section {
  display: flex;
  flex-direction: column;
  gap: var(--space-6);
}

.avatar-card, .info-card {
  background: var(--color-surface);
  border: 1px solid var(--color-border);
  padding: var(--space-8);
  border-radius: var(--radius-3);
  box-shadow: var(--shadow-1);
}

.avatar-card {
  display: flex;
  align-items: center;
  gap: var(--space-8);
}

.avatar-preview {
  position: relative;
  width: 120px;
  height: 120px;
  border-radius: 50%;
  overflow: hidden;
  border: 4px solid var(--color-surface-2);
  box-shadow: 0 0 20px rgba(177, 0, 255, 0.15);
}

.avatar-preview img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.upload-overlay {
  position: absolute;
  inset: 0;
  background: rgba(0, 0, 0, 0.6);
  display: flex;
  align-items: center;
  justify-content: center;
}

.avatar-info h3 { margin: 0 0 var(--space-2); }
.avatar-info p { color: var(--color-muted); font-size: 14px; margin: 0 0 var(--space-4); }

.btn-upload {
  display: inline-block;
  padding: var(--space-2) var(--space-4);
  background: rgba(255, 255, 255, 0.05);
  border: 1px solid var(--color-border);
  border-radius: var(--radius-2);
  cursor: pointer;
  font-weight: 700;
  font-size: 14px;
  transition: all 160ms ease;
}

.btn-upload:hover { background: rgba(255, 255, 255, 0.1); border-color: var(--color-primary); }
.btn-upload.disabled { opacity: 0.5; cursor: not-allowed; }

.info-card h3 { margin: 0 0 var(--space-6); }

.profile-form {
  display: grid;
  gap: var(--space-6);
}

.field {
  display: flex;
  flex-direction: column;
  gap: var(--space-2);
}

.field label {
  font-size: 13px;
  font-weight: 800;
  color: var(--color-muted);
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.field input {
  background: var(--color-surface-2);
  border: 1px solid var(--color-border);
  padding: 12px var(--space-4);
  border-radius: var(--radius-2);
  color: var(--color-text);
  font-weight: 600;
  transition: all 160ms ease;
}

.field input:focus {
  outline: none;
  border-color: var(--color-primary);
  box-shadow: 0 0 0 3px rgba(177, 0, 255, 0.1);
}

.field.disabled input {
  opacity: 0.5;
  cursor: not-allowed;
}

.field small { color: var(--color-muted); font-size: 12px; }

.btn-primary {
  padding: 14px;
  background: var(--color-primary);
  color: white;
  border: none;
  border-radius: var(--radius-2);
  font-weight: 900;
  cursor: pointer;
  transition: all 160ms ease;
  margin-top: var(--space-4);
}

.btn-primary:hover:not(:disabled) {
  filter: brightness(1.1);
  box-shadow: 0 0 20px var(--color-glow);
}

.btn-primary:disabled {
  opacity: 0.5;
  cursor: not-allowed;
}

.spinner {
  width: 24px;
  height: 24px;
  border: 3px solid rgba(255, 255, 255, 0.3);
  border-top-color: var(--color-text);
  border-radius: 50%;
  animation: spin 0.8s linear infinite;
}

@keyframes spin { to { transform: rotate(360deg); } }

@media (max-width: 600px) {
  .avatar-card { flex-direction: column; text-align: center; }
}
</style>
