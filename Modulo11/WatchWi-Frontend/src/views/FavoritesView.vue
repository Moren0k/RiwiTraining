<template>
  <HeaderNetflix />
  
  <main data-page="favorites">
    <div data-container="content">
      <header class="view-header">
        <h1>Mi Lista</h1>
        <p v-if="favStore.favorites.length">
          Tienes {{ favStore.favorites.length }} {{ favStore.favorites.length === 1 ? 'película o serie' : 'películas o series' }} guardadas.
        </p>
      </header>

      <!-- EMPTY STATE -->
      <div v-if="!favStore.loading && favStore.favorites.length === 0" class="empty-state">
        <div class="empty-icon">❤️</div>
        <h2>Tu lista está vacía</h2>
        <p>Aún no has agregado ninguna película o serie a tus favoritos.</p>
        <router-link to="/home" class="btn-browse">Explorar contenido</router-link>
      </div>

      <!-- GRID -->
      <div v-else class="favorites-grid">
        <MovieCard
          v-for="media in favStore.favorites"
          :key="media.id"
          :media="media"
          @click="openModal"
        />
      </div>
    </div>
  </main>

  <Teleport to="body">
    <MovieModal
      :is-open="isModalOpen"
      :media-id="selectedMedia?.id || null"
      @close="closeModal"
    />
  </Teleport>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import HeaderNetflix from '@/components/layout/HeaderNetflix.vue';
import MovieCard from '@/components/netflix/MovieCard.vue';
import MovieModal from '@/components/MovieModal.vue';
import { useFavoritesStore } from '@/stores/favorites';
import type { Media } from '@/services/MediaService';

const favStore = useFavoritesStore();
const isModalOpen = ref(false);
const selectedMedia = ref<Media | null>(null);

const openModal = (media: Media) => {
  selectedMedia.value = media;
  isModalOpen.value = true;
};

const closeModal = () => {
  isModalOpen.value = false;
  selectedMedia.value = null;
};

onMounted(() => {
  favStore.fetchFavorites();
});
</script>

<style scoped>
[data-page="favorites"] {
  min-height: calc(100vh - 64px);
  padding: var(--space-10) var(--space-4);
  display: flex;
  justify-content: center;
}

[data-container="content"] {
  width: 100%;
  max-width: 1200px;
  display: flex;
  flex-direction: column;
  gap: var(--space-10);
}

.view-header h1 {
  font-size: 32px;
  font-weight: 900;
  margin: 0 0 var(--space-2);
}

.view-header p {
  color: var(--color-muted);
  font-weight: 600;
}

.favorites-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(180px, 1fr));
  gap: var(--space-6);
}

.empty-state {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: var(--space-12) 0;
  text-align: center;
  background: rgba(255, 255, 255, 0.02);
  border: 1px dashed var(--color-border);
  border-radius: var(--radius-3);
}

.empty-icon {
  font-size: 64px;
  margin-bottom: var(--space-6);
  filter: grayscale(1);
  opacity: 0.3;
}

.empty-state h2 {
  font-size: 24px;
  margin-bottom: var(--space-2);
}

.empty-state p {
  color: var(--color-muted);
  margin-bottom: var(--space-8);
}

.btn-browse {
  padding: var(--space-3) var(--space-8);
  background: var(--color-primary);
  color: white;
  text-decoration: none;
  font-weight: 900;
  border-radius: var(--radius-2);
  transition: all 160ms ease;
}

.btn-browse:hover {
  filter: brightness(1.1);
  box-shadow: 0 0 20px var(--color-glow);
}

@media (max-width: 520px) {
  .favorites-grid {
    grid-template-columns: repeat(auto-fill, minmax(140px, 1fr));
    gap: var(--space-4);
  }
}
</style>
