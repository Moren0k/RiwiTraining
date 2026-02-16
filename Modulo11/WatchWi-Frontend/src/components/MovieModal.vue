<script setup lang="ts">
import { ref, computed, watch } from 'vue';
import MediaService, { type Media } from '@/services/MediaService';

const props = defineProps<{
  mediaId: string | null;
  isOpen: boolean;
}>();

const emit = defineEmits<{
  (e: 'close'): void;
}>();

const media = ref<Media | null>(null);
const loading = ref(false);

const fetchDetail = async () => {
  if (!props.mediaId) return;
  loading.value = true;
  try {
    media.value = await MediaService.getById(props.mediaId);
  } catch (error) {
    console.error('Failed to fetch media detail:', error);
  } finally {
    loading.value = false;
  }
};

watch(() => props.isOpen, (newVal) => {
  if (newVal) {
    fetchDetail();
  } else {
    media.value = null;
  }
});

const embedUrl = computed(() => {
  if (!media.value?.mediaUrl) return '';

  const url = media.value.mediaUrl;

  if (url.includes('youtube.com/watch') || url.includes('youtu.be/')) {
    const videoIdMatch = url.match(/(?:v=|youtu\.be\/)([^&]+)/);
    if (videoIdMatch && videoIdMatch[1]) {
      const id = videoIdMatch[1];

      const params = new URLSearchParams({
        autoplay: '1',
        modestbranding: '1',
        rel: '0',
        playsinline: '1',
        iv_load_policy: '3',
      });

      return `https://www.youtube.com/embed/${id}?${params.toString()}`;
    }
  }

  return url;
});

const handleBackdropClick = (e: MouseEvent) => {
  // Close only if clicking the backdrop itself, not inside modal content
  if (e.target === e.currentTarget) {
    emit('close');
  }
};
</script>

<template>
  <Transition name="fade">
    <div v-if="isOpen" @click="handleBackdropClick" data-modal="backdrop">
      <div data-modal="container">
        <button @click="$emit('close')">&times;</button>
        <div>
          <iframe
            v-if="embedUrl"
            :src="embedUrl"
            title="Video player"
            frameborder="0"
            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
            allowfullscreen
          ></iframe>

          <div v-else>
            <p>Video URL not available</p>
          </div>
        </div>
      </div>
    </div>
  </Transition>
</template>

<style scoped>
/* 1) Backdrop */
[data-modal="backdrop"] {
  position: fixed;
  inset: 0;
  z-index: 2000;

  display: grid;
  place-items: center;

  padding: var(--space-6);

  background: rgba(0, 0, 0, 0.72);
  backdrop-filter: blur(14px);
  -webkit-backdrop-filter: blur(14px);
}

/* 2) Modal container (+15% aprox) */
[data-modal="container"] {
  position: relative;

  width: min(1280px, 100%); /* antes 1100px */
  border-radius: var(--radius-3);
  overflow: hidden;

  background: linear-gradient(
      180deg,
      rgba(22, 17, 31, 0.92),
      rgba(15, 12, 20, 0.92)
    );

  border: 1px solid rgba(255, 255, 255, 0.10);

  box-shadow:
    var(--shadow-2),
    0 0 0 1px rgba(177, 0, 255, 0.14),
    0 0 50px rgba(177, 0, 255, 0.18);
}

/* Glow */
[data-modal="container"]::before {
  content: "";
  position: absolute;
  inset: -2px;
  border-radius: inherit;
  pointer-events: none;

  background: radial-gradient(
      700px circle at 20% 10%,
      rgba(177, 0, 255, 0.18),
      transparent 55%
    ),
    radial-gradient(
      800px circle at 80% 90%,
      rgba(124, 0, 255, 0.16),
      transparent 60%
    );
}

/* 3) Close button */
[data-modal="container"] > button {
  position: absolute;
  top: 10px;
  right: 10px;
  z-index: 5;

  width: 40px;
  height: 40px;
  border-radius: 999px;

  border: 1px solid rgba(255, 255, 255, 0.12);
  background: rgba(0, 0, 0, 0.35);
  color: var(--color-text);

  display: grid;
  place-items: center;

  font-size: 26px;
  line-height: 1;
  cursor: pointer;

  transition: transform 160ms ease, background-color 160ms ease, box-shadow 160ms ease;
}

[data-modal="container"] > button:hover {
  background: rgba(177, 0, 255, 0.14);
  box-shadow: 0 0 18px rgba(177, 0, 255, 0.22);
}

[data-modal="container"] > button:active {
  transform: translateY(1px);
}

/* 4) Video wrapper */
[data-modal="container"] > div {
  position: relative;
  width: 100%;
  aspect-ratio: 16 / 9;
  background: #000;
}

/* Subtle frame */
[data-modal="container"] > div::after {
  content: "";
  position: absolute;
  inset: 0;
  pointer-events: none;
  box-shadow: inset 0 0 0 1px rgba(255, 255, 255, 0.06);
}

/* 5) Iframe */
[data-modal="backdrop"] iframe {
  position: absolute;
  inset: 0;
  width: 100%;
  height: 100%;
  border: 0;
}

/* 6) Fallback */
[data-modal="container"] > div > div {
  position: absolute;
  inset: 0;

  display: grid;
  place-items: center;
  padding: var(--space-8);

  color: var(--color-muted);
  text-align: center;

  background:
    radial-gradient(500px circle at 30% 20%, rgba(177, 0, 255, 0.10), transparent 60%),
    radial-gradient(600px circle at 70% 80%, rgba(124, 0, 255, 0.10), transparent 60%),
    #05040a;
}

[data-modal="backdrop"] p {
  margin: 0;
  font-weight: 700;
  letter-spacing: 0.2px;
}

/* Fade transition */
.fade-enter-active,
.fade-leave-active {
  transition: opacity 180ms ease;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}

/* Responsive */
@media (max-width: 520px) {
  [data-modal="backdrop"] {
    padding: var(--space-3);
  }

  [data-modal="container"] > button {
    width: 36px;
    height: 36px;
    font-size: 24px;
  }
}

/* Reduce motion */
@media (prefers-reduced-motion: reduce) {
  .fade-enter-active,
  .fade-leave-active {
    transition: none;
  }

  [data-modal="container"] > button {
    transition: none;
  }
}
</style>
