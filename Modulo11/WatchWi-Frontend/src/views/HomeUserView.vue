<template>
  <HeaderNetflix />

  <main data-page="home">
    <div data-layout="content">
      <HeroMovie
        :media="featuredMedia"
        @play="openModal"
      />

      <!-- SECCIÓN FAVORITOS (MOVIDA AL FINAL) -->

      

      <MovieRow title="Tendencias" :items="medias" v-if="medias.length">
        <template #item="{ item }">
          <TrendingCard
            :media="item"
            @click="openModal"
          />
        </template>
      </MovieRow>

      <!-- SECCIÓN GRID COMPLETO -->
      <section class="grid-section" v-if="medias.length">
        <h2>Explorar</h2>
        <div class="media-grid">
          <MovieCard
            v-for="media in medias"
            :key="media.id"
            :media="media"
            @click="openModal"
          />
        </div>
      </section>

      <!-- SECCIÓN FAVORITOS (LISTA) -->
      <section class="favorites-section" v-if="favStore.favorites.length">
        <h2>Tus Favoritos</h2>
        <div class="favorites-list">
          <FavoriteListItem
            v-for="media in favStore.favorites"
            :key="media.id"
            :media="media"
          />
        </div>
      </section>

      <div v-if="!medias.length" data-state="loading">
        Cargando...
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
import { ref, computed, onMounted } from 'vue';
import HeaderNetflix from '@/components/layout/HeaderNetflix.vue';
import HeroMovie from '@/components/netflix/HeroMovie.vue';
import MovieRow from '@/components/netflix/MovieRow.vue';
import MovieCard from '@/components/netflix/MovieCard.vue';
import TrendingCard from '@/components/netflix/TrendingCard.vue';
import FavoriteListItem from '@/components/netflix/FavoriteListItem.vue';
import MovieModal from '@/components/MovieModal.vue';
import { storeToRefs } from 'pinia';
import MediaService, { type Media } from '@/services/MediaService';
import { useFavoritesStore } from '@/stores/favorites';
import { useMediaStateStore } from '@/stores/mediaState';

const favStore = useFavoritesStore();
const mediaStore = useMediaStateStore();
const { medias, selectedMedia, isModalOpen } = storeToRefs(mediaStore);
const { openModal, closeModal } = mediaStore;

const featuredMedia = computed(() => {
  return medias.value.find(m => m.isFeatured) || null;
});

onMounted(() => {
  mediaStore.fetchMedias();
  favStore.fetchFavorites();
});
</script>

<style scoped>
/* Page layout */
/* Page layout */
[data-page="home"] {
  width: 100%;
  display: flex;
  justify-content: center;
  padding: var(--space-6) var(--space-4) var(--space-12);
}

[data-layout="content"] {
  width: 100%;
  max-width: 1200px;
  display: flex;
  flex-direction: column;
  gap: var(--space-10);
  position: relative;
}

/* Sutil ambient “cinema” en el fondo de la página */
[data-page="home"]::before {
  content: "";
  position: fixed;
  inset: 0;
  z-index: -1;
  pointer-events: none;

  background:
    radial-gradient(900px circle at 15% 10%, rgba(177, 0, 255, 0.10), transparent 55%),
    radial-gradient(1100px circle at 85% 30%, rgba(124, 0, 255, 0.08), transparent 60%),
    radial-gradient(1000px circle at 50% 95%, rgba(177, 0, 255, 0.06), transparent 55%);
}

/* Loading state */
[data-state="loading"] {
  padding: var(--space-12) 0;
  text-align: center;
  color: var(--color-muted);
  
  border: 1px solid rgba(255, 255, 255, 0.08);
  background: rgba(15, 12, 20, 0.55);
  border-radius: var(--radius-3);

  box-shadow:
    var(--shadow-1),
    0 0 0 1px rgba(177, 0, 255, 0.10),
    0 0 30px rgba(177, 0, 255, 0.08);

  letter-spacing: 0.2px;
  font-weight: 600;
}

/* Layout Sections */
.grid-section,
.favorites-section {
  display: flex;
  flex-direction: column;
  gap: var(--space-4);
  margin-top: var(--space-4);
}

.home-search {
  align-self: center;
  margin-bottom: var(--space-4);
}

.grid-section h2,
.favorites-section h2 {
  margin: 0;
  font-size: 20px;
  font-weight: 700;
  color: #fff;
  padding-left: var(--space-1);
}

.media-grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: var(--space-4);
  width: 100%;
}

.favorites-list {
  display: flex;
  flex-direction: column;
  gap: var(--space-3);
  width: 100%;
}

@media (min-width: 600px) {
  .media-grid {
    grid-template-columns: repeat(3, 1fr);
  }
}

@media (min-width: 900px) {
  .media-grid {
    grid-template-columns: repeat(4, 1fr);
  }
}

@media (min-width: 1200px) {
  .media-grid {
    grid-template-columns: repeat(5, 1fr);
  }
}

/* Responsive spacing */
@media (max-width: 900px) {
  [data-page="home"] {
    padding: var(--space-5) var(--space-3) var(--space-10);
  }
  
  [data-layout="content"] {
    gap: var(--space-8);
  }
}

@media (max-width: 520px) {
  [data-page="home"] {
    padding: var(--space-4) var(--space-3) var(--space-8);
  }
  
  [data-layout="content"] {
    gap: var(--space-6);
  }

  [data-state="loading"] {
    padding: var(--space-10) var(--space-4);
  }
}

/* Accesibilidad */
@media (prefers-reduced-motion: reduce) {
  [data-page="home"]::before {
    display: none;
  }
}
</style>
