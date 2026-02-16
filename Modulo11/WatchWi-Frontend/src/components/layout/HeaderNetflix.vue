<template>
  <header>
    <div>
      <router-link to="/home" class="logo">
        <h1>WATCHWi</h1>
      </router-link>
      
      <nav>
        <router-link to="/home">Inicio</router-link>
        <router-link to="/favorites">Mi lista</router-link>
        <router-link to="/admin" v-if="isAdmin">Admin</router-link>
      </nav>

      <SearchBar 
        :items="medias" 
        @select="openModal"
        class="home-search" 
      />

      <div class="user-actions">
        <!-- Skeleton Loader -->
        <div v-if="authStore.isLoadingUser" class="skeleton-loader"></div>

        <!-- Authenticated User -->
        <template v-else-if="authStore.user">
          <router-link to="/profile" class="profile-link">
            <span class="username">{{ authStore.user.username }}</span>
            <div class="avatar-wrapper">
              <img 
                :src="userProfileImage" 
                alt="Avatar"
                class="avatar"
                @error="handleImageError"
              />
            </div>
          </router-link>
          <button @click="handleLogout" class="logout-btn" title="Cerrar sesión">
            <i>⏻</i>
          </button>
        </template>
      </div>
    </div>
  </header>
</template>

<script setup lang="ts">
import { computed, ref, watch } from 'vue';
import { useAuthStore } from '@/stores/auth';
import SearchBar from '@/components/netflix/SearchBar.vue';
import { useMediaStateStore } from '@/stores/mediaState';
import { storeToRefs } from 'pinia';

const authStore = useAuthStore();
const mediaStore = useMediaStateStore();
const { medias } = storeToRefs(mediaStore);
const { openModal } = mediaStore;

const isAdmin = computed(() => authStore.user?.role === 'Admin');

const avatarError = ref(false);
const DUMMY_AVATAR = 'https://res.cloudinary.com/dj8l87pnr/image/upload/v1738507205/ImgProfiles/dummy_p3u2r6.png';

const userProfileImage = computed(() => {
  if (avatarError.value || !authStore.user?.profileImageUrl) {
    return DUMMY_AVATAR;
  }
  return authStore.user.profileImageUrl;
});

const handleImageError = () => {
  if (!avatarError.value) {
    avatarError.value = true;
  }
};

watch(() => authStore.user?.profileImageUrl, () => {
  avatarError.value = false;
});

const handleLogout = () => {
  authStore.logout();
};
</script>

<style scoped>
/* Loader Styles */
.skeleton-loader {
  width: 120px;
  height: 32px;
  background: rgba(255, 255, 255, 0.05);
  border-radius: 999px;
  animation: pulse 1.5s infinite;
}

@keyframes pulse {
  0% { opacity: 0.6; }
  50% { opacity: 0.3; }
  100% { opacity: 0.6; }
}
/* ... existing styles ... */
/* End of Loader Styles */
header {
  position: sticky;
  top: 0;
  z-index: 1000;
  height: 64px;
  display: flex;
  align-items: center;
  background: rgba(7, 6, 10, 0.72);
  backdrop-filter: blur(12px);
  border-bottom: 1px solid var(--color-border);
}

header > div {
  width: 100%;
  max-width: 1200px;
  margin: 0 auto;
  padding: 0 var(--space-4);
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.logo {
  text-decoration: none;
}

h1 {
  margin: 0;
  font-size: 18px;
  font-weight: 900;
  letter-spacing: 3px;
  color: var(--color-primary);
  text-shadow: 0 0 18px var(--color-glow);
}

nav {
  display: flex;
  align-items: center;
  gap: var(--space-4);
  margin-left: var(--space-6);
  flex: 1;
}

nav a {
  padding: 8px 12px;
  color: rgba(241, 241, 243, 0.78);
  text-decoration: none;
  font-size: 13px;
  font-weight: 600;
  border-radius: 999px;
  transition: all 160ms ease;
}

nav a:hover, nav a.router-link-active {
  color: var(--color-text);
  background: rgba(255, 255, 255, 0.06);
}

nav a.router-link-active {
  background: rgba(177, 0, 255, 0.14);
  box-shadow: 0 0 0 1px rgba(177, 0, 255, 0.18);
}

.user-actions {
  display: flex;
  align-items: center;
  gap: var(--space-4);
}

.profile-link {
  display: flex;
  align-items: center;
  gap: var(--space-3);
  text-decoration: none;
  color: var(--color-text);
  padding: 4px 4px 4px 12px;
  border-radius: 999px;
  background: rgba(255, 255, 255, 0.04);
  border: 1px solid transparent;
  transition: all 160ms ease;
}

.profile-link:hover {
  background: rgba(255, 255, 255, 0.08);
  border-color: rgba(177, 0, 255, 0.3);
}

.username {
  font-size: 13px;
  font-weight: 700;
  color: var(--color-muted);
}

.avatar-wrapper {
  width: 32px;
  height: 32px;
  border-radius: 50%;
  overflow: hidden;
  border: 2px solid var(--color-surface);
  box-shadow: 0 0 0 1px rgba(255, 255, 255, 0.1);
}

.avatar {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.logout-btn {
  background: transparent;
  border: none;
  color: var(--color-muted);
  font-size: 18px;
  cursor: pointer;
  padding: 8px;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 50%;
  transition: all 160ms ease;
}

.logout-btn:hover {
  color: var(--color-danger);
  background: rgba(255, 59, 107, 0.1);
}

/* Responsive */
@media (max-width: 768px) {
  .username {
    display: none;
  }
}

@media (max-width: 520px) {
  nav {
    display: none; /* Simplificado para el ejemplo, en real se usaría un menú hamburguesa */
  }
}
</style>