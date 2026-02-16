<script setup lang="ts">
import { computed } from 'vue';
import type { Media } from '@/services/MediaService';

const props = defineProps<{
  media?: Media | null;
}>();

defineEmits<{
  (e: 'play', media: Media): void;
  (e: 'info', media: Media): void;
}>();

const backgroundStyle = computed(() => {
  if (!props.media?.posterUrl) return {};
  return {
    backgroundImage: `url('${props.media.posterUrl}')`
  };
});
</script>

<template>
  <section class="hero" :style="backgroundStyle" v-if="media">
    <div class="hero-wrapper">
      <div class="content">
        <h1>{{ media.title }}</h1>
        <p>{{ media.description }}</p>
        <div class="buttons">
          <button class="play" @click="$emit('play', media)">▶ Reproducir</button>
          <!-- <button class="info" @click="$emit('info', media)">ℹ Más información</button> -->
        </div>
      </div>
    </div>
  </section>
  <div v-else class="hero-placeholder">
    <!-- Placeholder or Skeleton if needed while loading -->
  </div>
</template>

<style scoped>
/* Main container */
.hero {
  width: 100%;
  /* Clamp height: min 450px, ideal 55vh, max 650px */
  height: clamp(450px, 55vh, 650px);
  
  background-size: cover;
  background-position: center 20%; 
  background-repeat: no-repeat;
  
  display: flex;
  align-items: center; 
  justify-content: center;
  position: relative;
  
  /* Bottom spacing to blend with next section */
  margin-bottom: var(--space-8);
}

/* Overlays for readability and mood */
.hero::before {
  content: "";
  position: absolute;
  inset: 0;
  background: 
    /* Gradient from bottom (dark) to top (transparent) */
    linear-gradient(to top, var(--color-bg) 5%, rgba(7, 6, 10, 0.6) 40%, rgba(7, 6, 10, 0.3) 100%),
    /* Gradient from left (dark) to right (transparent) for text visibility */
    linear-gradient(to right, rgba(7, 6, 10, 0.9) 0%, rgba(7, 6, 10, 0.5) 40%, transparent 100%);
  z-index: 0;
}

/* Bottom purple glow fade */
.hero::after {
  content: "";
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  height: 120px;
  background: linear-gradient(to top, var(--color-bg) 10%, rgba(177, 0, 255, 0.05) 100%);
  pointer-events: none;
  z-index: 1;
}

.hero-wrapper {
  width: 100%;
  max-width: 1200px;
  padding: 0 var(--space-6);
  z-index: 2;
  display: flex;
  align-items: center;
  margin-top: var(--space-8);
}

.content {
  max-width: 600px;
  color: var(--color-text);
  text-shadow: 0 2px 4px rgba(0, 0, 0, 0.5);
}

.content h1 { 
  font-size: clamp(2rem, 5vw, 3.5rem);
  font-weight: 900;
  line-height: 1.1; 
  margin-bottom: var(--space-4);
  letter-spacing: -0.5px;
}

.content p { 
  font-size: clamp(1rem, 2vw, 1.125rem);
  line-height: 1.5;
  color: rgba(241, 241, 243, 0.9);
  margin-bottom: var(--space-6);
  max-width: 520px;
  
  display: -webkit-box;
  -webkit-line-clamp: 3;
  -webkit-box-orient: vertical;
  overflow: hidden;
  text-shadow: 0 1px 2px rgba(0, 0, 0, 0.8);
}

.buttons {
  display: flex;
  gap: var(--space-4);
}

.buttons button {
  padding: 12px 28px;
  font-size: 1rem;
  font-weight: 700;
  border-radius: var(--radius-2);
  border: none;
  cursor: pointer;
  display: inline-flex;
  align-items: center;
  gap: 8px;
  transition: transform 0.2s cubic-bezier(0.2, 0.8, 0.2, 1), box-shadow 0.2s, background-color 0.2s;
}

.buttons button:active {
  transform: scale(0.98);
}

/* Play button (Primary) */
.play { 
  background: linear-gradient(135deg, #fff 0%, #f1f1f3 100%);
  color: #000;
  box-shadow: 0 4px 12px rgba(0,0,0,0.3);
}

.play:hover { 
  transform: translateY(-2px);
  box-shadow: 
    0 8px 16px rgba(0,0,0,0.4),
    0 0 20px rgba(177, 0, 255, 0.4); /* Purple glow on white button */
}

/* Info button (Ghost/Secondary) */
.info { 
  background: rgba(255, 255, 255, 0.2); 
  color: white; 
  backdrop-filter: blur(8px);
}
.info:hover { 
  background: rgba(255, 255, 255, 0.3); 
}

.hero-placeholder {
  width: 100%;
  height: 55vh;
  background-color: var(--color-surface);
  display: grid;
  place-items: center;
  color: var(--color-muted);
}

/* Responsive */
@media (max-width: 768px) {
  .hero { 
    height: 50vh;
    min-height: 400px;
    background-position: center top;
    margin-bottom: var(--space-6);
  }
  
  .hero-wrapper {
    padding: 0 var(--space-4);
    align-items: flex-end; 
    padding-bottom: var(--space-10);
  }
  
  /* Strengthen bottom gradient on mobile */
  .hero::before {
    background: linear-gradient(to top, var(--color-bg) 15%, rgba(7, 6, 10, 0.4) 60%, transparent 100%);
  }

  .content {
    width: 100%;
    text-align: left;
  }
  
  .content h1 {
    margin-bottom: var(--space-2);
  }
  
  .content p {
    font-size: 1rem;
    -webkit-line-clamp: 2; 
    margin-bottom: var(--space-4);
  }
  
  .buttons button {
    padding: 10px 24px;
    width: 100%; 
    justify-content: center;
  }
  
  .buttons {
    flex-direction: column; 
    width: 100%;
    max-width: 280px;
  }
}
</style>