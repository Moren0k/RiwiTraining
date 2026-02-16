<script setup lang="ts">
import { useFavoritesStore } from '@/stores/favorites';
import type { Media } from '@/services/MediaService';

const props = defineProps<{
  media: Media;
}>();

const favStore = useFavoritesStore();

const handleRemove = () => {
    favStore.toggleFavorite(props.media); // This handles removal if already fav
};
</script>

<template>
  <div class="fav-item">
    <div class="fav-content">
      <h3>{{ media.title }}</h3>
      <p>{{ media.description }}</p>
    </div>
    
    <button class="remove-btn" @click="handleRemove" title="Quitar de favoritos">
      Quitar de favoritos
    </button>
  </div>
</template>

<style scoped>
.fav-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background: var(--color-surface);
  border: 1px solid var(--color-border);
  padding: 16px;
  border-radius: var(--radius-2);
  gap: 16px;
  transition: transform 0.2s ease, border-color 0.2s ease;
}

.fav-item:hover {
  transform: translateX(4px);
  border-color: var(--color-primary);
}

.fav-content {
  flex: 1;
}

h3 {
  margin: 0 0 4px;
  font-size: 16px;
  font-weight: 700;
  color: #fff;
}

p {
  margin: 0;
  font-size: 13px;
  color: var(--color-muted);
  display: -webkit-box;
  -webkit-line-clamp: 2;
  -webkit-box-orient: vertical;
  overflow: hidden;
}

.remove-btn {
  background: transparent;
  border: 1px solid rgba(255, 59, 107, 0.4);
  color: #ff3b6b;
  padding: 8px 16px;
  border-radius: 999px;
  font-size: 12px;
  font-weight: 600;
  cursor: pointer;
  white-space: nowrap;
  transition: all 0.2s ease;
}

.remove-btn:hover {
  background: rgba(255, 59, 107, 0.1);
  border-color: #ff3b6b;
}

/* Responsive */
@media (max-width: 600px) {
  .fav-item {
    align-items: flex-start;
    flex-direction: column;
  }
  
  .remove-btn {
    width: 100%;
    text-align: center;
  }
}
</style>
