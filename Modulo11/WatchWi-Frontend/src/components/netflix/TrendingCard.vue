<script setup lang="ts">
import { useFavoritesStore } from '@/stores/favorites';
import type { Media } from '@/services/MediaService';

defineProps<{
  media: Media;
}>();

defineEmits<{
  (e: 'click', media: Media): void;
}>();

const favStore = useFavoritesStore();
</script>

<template>
  <div class="trending-card" @click="$emit('click', media)">
    <div class="background">
      <img :src="media.posterUrl" :alt="media.title" loading="lazy" />
      <div class="gradient-overlay"></div>
    </div>
    
    <div class="content">
      <div class="text-info">
        <h3>{{ media.title }}</h3>
        <p class="description">{{ media.description }}</p>
      </div>
      
      <button 
        class="fav-btn" 
        :class="{ 'is-active': favStore.isFavorite(media.id) }"
        @click.stop="favStore.toggleFavorite(media)"
        :aria-label="favStore.isFavorite(media.id) ? 'Quitar de favoritos' : 'Agregar a favoritos'"
      >
        <i>♥</i>
      </button>
    </div>
  </div>
</template>

<style scoped>
.trending-card {
  position: relative;
  width: 380px; /* Desktop default */
  height: 220px;
  flex-shrink: 0;
  border-radius: var(--radius-3);
  overflow: hidden;
  cursor: pointer;
  transition: transform 0.3s cubic-bezier(0.2, 0.8, 0.2, 1), box-shadow 0.3s ease;
  background: var(--color-surface);
  border: 1px solid rgba(255, 255, 255, 0.05);
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.4);
}

.trending-card:hover {
  transform: scale(1.02);
  box-shadow: 0 8px 30px rgba(0, 0, 0, 0.6);
  z-index: 2;
  border-color: rgba(255, 255, 255, 0.15);
}

.background {
  position: absolute;
  inset: 0;
  width: 100%;
  height: 100%;
}

.background img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  /* Adjust object position if needed, widely usually centers well or top */
  object-position: center top; 
  transition: transform 0.4s ease;
}

.trending-card:hover .background img {
  transform: scale(1.05);
}

.gradient-overlay {
  position: absolute;
  inset: 0;
  background: linear-gradient(
    to top,
    rgba(15, 12, 20, 0.95) 0%,
    rgba(15, 12, 20, 0.6) 40%,
    transparent 100%
  );
}

.content {
  position: absolute;
  bottom: 0;
  left: 0;
  width: 100%;
  padding: var(--space-4);
  display: flex;
  justify-content: space-between;
  align-items: flex-end;
  gap: var(--space-3);
}

.text-info {
  flex: 1;
  display: flex;
  flex-direction: column;
  gap: 4px;
}

h3 {
  margin: 0;
  font-size: 16px;
  font-weight: 800;
  color: #fff;
  text-shadow: 0 2px 4px rgba(0,0,0,0.8);
  display: -webkit-box;
  -webkit-line-clamp: 1;
  -webkit-box-orient: vertical;
  overflow: hidden;
}

.description {
  margin: 0;
  font-size: 12px;
  color: rgba(255, 255, 255, 0.7);
  font-weight: 500;
  line-height: 1.4;
  display: -webkit-box;
  -webkit-line-clamp: 2;
  -webkit-box-orient: vertical;
  overflow: hidden;
}

.fav-btn {
  background: rgba(255, 255, 255, 0.1);
  border: 1px solid rgba(255, 255, 255, 0.2);
  color: rgba(255, 255, 255, 0.6);
  width: 32px;
  height: 32px;
  border-radius: 50%;
  display: grid;
  place-items: center;
  font-style: normal;
  cursor: pointer;
  transition: all 0.2s ease;
  backdrop-filter: blur(4px);
}

.fav-btn:hover {
  background: rgba(255, 255, 255, 0.2);
  color: #fff;
  transform: scale(1.1);
}

.fav-btn.is-active {
  background: var(--color-primary);
  border-color: var(--color-primary);
  color: #fff;
  box-shadow: 0 0 10px var(--color-glow);
}

/* Responsive */
@media (max-width: 768px) {
  .trending-card {
    width: 300px;
    height: 180px;
  }
}

@media (max-width: 480px) {
  .trending-card {
    width: 260px;
    height: 160px;
  }
}
</style>
