<script setup lang="ts">
import { useFavoritesStore } from '@/stores/favorites';
import type { Media } from '@/services/MediaService';

const props = defineProps<{
  media: Media;
}>();

defineEmits<{
  (e: 'click', media: Media): void;
}>();

const favStore = useFavoritesStore();
</script>

<template>
  <div class="card" @click="$emit('click', media)">
    <div class="poster-wrapper">
      <img :src="media.posterUrl" :alt="media.title" loading="lazy" />
      <div class="overlay">
        <span>{{ media.title }}</span>
      </div>
      
      <button 
        class="fav-btn" 
        :class="{ 'is-active': favStore.isFavorite(media.id) }"
        @click.stop="favStore.toggleFavorite(media)" 
        :aria-label="favStore.isFavorite(media.id) ? 'Quitar de favoritos' : 'Agregar a favoritos'"
      >
        <svg viewBox="0 0 24 24" width="24" height="24">
          <path d="M12 21.35l-1.45-1.32C5.4 15.36 2 12.28 2 8.5 2 5.42 4.42 3 7.5 3c1.74 0 3.41.81 4.5 2.09C13.09 3.81 14.76 3 16.5 3 19.58 3 22 5.42 22 8.5c0 3.78-3.4 6.86-8.55 11.54L12 21.35z"/>
        </svg>
      </button>
    </div>
  </div>
</template>

<style scoped>
.card {
  min-width: 160px;
  flex-shrink: 0;
  cursor: pointer;
  position: relative;
  border-radius: var(--radius-2);
  transition: transform 0.3s cubic-bezier(0.2, 0.8, 0.2, 1);
  isolation: isolate;
}

.poster-wrapper {
  position: relative;
  width: 100%;
  aspect-ratio: 2/3;
  overflow: hidden;
  border-radius: var(--radius-2);
  box-shadow: 0 4px 10px rgba(0,0,0,0.3);
}

.card img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  transition: transform 0.4s ease;
}

/* Hover effects */
.card:hover {
  transform: scale(1.05);
  z-index: 10;
}

.card:hover img {
  transform: scale(1.1);
}

/* Overlay title (appears on hover) */
.overlay {
  position: absolute;
  inset: 0;
  background: linear-gradient(to top, rgba(0,0,0,0.9), transparent 60%);
  opacity: 0;
  transition: opacity 0.3s ease;
  display: flex;
  align-items: flex-end;
  padding: 12px;
}

.card:hover .overlay {
  opacity: 1;
}

.overlay span {
  color: #fff;
  font-size: 14px;
  font-weight: 700;
  text-shadow: 0 2px 4px rgba(0,0,0,0.8);
}

/* Favorites Button */
.fav-btn {
  position: absolute;
  top: 8px;
  right: 8px;
  
  width: 32px;
  height: 32px;
  border-radius: 50%;
  
  border: 1px solid rgba(255, 255, 255, 0.2);
  background: rgba(0, 0, 0, 0.4);
  backdrop-filter: blur(4px);
  -webkit-backdrop-filter: blur(4px);
  
  display: grid;
  place-items: center;
  
  cursor: pointer;
  opacity: 0; /* Hidden by default */
  transform: translateY(-5px);
  transition: all 0.2s ease;
  
  color: rgba(255, 255, 255, 0.7);
}

/* Show button on specific conditions */
.card:hover .fav-btn,
.fav-btn:focus-visible {
  opacity: 1;
  transform: translateY(0);
}

.fav-btn svg {
  fill: currentColor;
  width: 18px;
  height: 18px;
  transition: fill 0.2s, stroke 0.2s;
}

.fav-btn:hover {
  background: rgba(177, 0, 255, 0.2);
  border-color: rgba(177, 0, 255, 0.5);
  color: #fff;
  box-shadow: 0 0 12px rgba(177, 0, 255, 0.4);
}

.fav-btn.is-active {
  color: #fff;
  background: var(--color-primary);
  border-color: var(--color-primary);
  opacity: 1;
  transform: translateY(0);
  box-shadow: 0 0 15px var(--color-glow);
}

.fav-btn.is-active svg {
  fill: #fff;
}

.fav-btn:active {
  transform: scale(0.9);
}

@media (min-width: 1024px) {
  .card {
    min-width: 220px;
  }
}
</style>