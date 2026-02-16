<template>
    <router-view />
    <ToastHost />
</template>

<script setup lang="ts">
import { onMounted } from 'vue';
import ToastHost from '@/components/common/ToastHost.vue';
import { useAuthStore } from '@/stores/auth';
import { useFavoritesStore } from '@/stores/favorites';

const authStore = useAuthStore();
const favStore = useFavoritesStore();

onMounted(() => {
  if (authStore.accessToken) {
    authStore.hydrateUser();
    favStore.fetchFavorites();
  }
});
</script>