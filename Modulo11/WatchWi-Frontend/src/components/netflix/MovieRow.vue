<script setup lang="ts">
import { ref, computed, onMounted, onUnmounted, nextTick } from 'vue';

const props = defineProps<{ 
  title: string;
  items: any[];
}>();

const scrollContainer = ref<HTMLElement | null>(null);
const autoPlayInterval = ref<number | null>(null);
const isInteracting = ref(false);

// Triple items for infinite illusion
const displayItems = computed(() => {
  if (!props.items || props.items.length === 0) return [];
  // Ensure we have enough items to scroll
  if (props.items.length < 5) {
     return [...props.items, ...props.items, ...props.items, ...props.items, ...props.items];
  }
  return [...props.items, ...props.items, ...props.items];
});

const startAutoplay = () => {
  stopAutoplay();
  autoPlayInterval.value = window.setInterval(() => {
    if (!scrollContainer.value || isInteracting.value) return;
    scroll(1, 1500); // 1 = direction right
  }, 4000);
};

const stopAutoplay = () => {
  if (autoPlayInterval.value) {
    clearInterval(autoPlayInterval.value);
    autoPlayInterval.value = null;
  }
};

const scroll = (direction: number, speed = 600) => {
  if (!scrollContainer.value) return;
  
  const container = scrollContainer.value;
  const cardWidth = 380 + 16; // Card width + gap (approx)
  
  container.scrollBy({
    left: direction * cardWidth,
    behavior: 'smooth'
  });
};

const handleScroll = () => {
  if (!scrollContainer.value) return;
  const { scrollLeft, scrollWidth, clientWidth } = scrollContainer.value;
  
  // Minimal infinite connection logic
  // Reset to middle if at edges (requires seamless jump without smooth behavior)
  const threshold = 100;
  
  // If we scrolled to the very end
  if (scrollLeft + clientWidth >= scrollWidth - threshold) {
     // Jump back to 1/3 (start of second set)
     scrollContainer.value.scrollLeft = scrollWidth / 3;
  } else if (scrollLeft <= threshold) {
     // Jump forward to 2/3? Or 1/3?
     // If at start, jump to 1/3
     scrollContainer.value.scrollLeft = scrollWidth / 3;
  }
};

const manualScroll = (direction: number) => {
  stopAutoplay();
  scroll(direction);
  // Restart autoplay after interaction
  setTimeout(startAutoplay, 5000);
};

const onMouseEnter = () => {
  isInteracting.value = true;
  stopAutoplay();
};

const onMouseLeave = () => {
  isInteracting.value = false;
  startAutoplay();
};

onMounted(async () => {
  await nextTick();
  if (scrollContainer.value) {
    // Start at 1/3 (middle set)
    scrollContainer.value.scrollLeft = scrollContainer.value.scrollWidth / 3;
  }
  startAutoplay();
});

onUnmounted(() => stopAutoplay());
</script>

<template>
  <section class="row">
    <div class="row-container" @mouseenter="onMouseEnter" @mouseleave="onMouseLeave">
      <h2>{{ title }}</h2>
      
      <div class="carousel-wrapper">
        <button class="nav-btn prev" @click="manualScroll(-1)" aria-label="Previous">‹</button>
        
        <div class="movies" ref="scrollContainer" @scroll.passive="handleScroll">
          <div v-for="(item, index) in displayItems" :key="index" class="movie-item">
            <slot name="item" :item="item" />
          </div>
        </div>
        
        <button class="nav-btn next" @click="manualScroll(1)" aria-label="Next">›</button>
      </div>
    </div>
  </section>
</template>

<style scoped>
.row {
  width: 100%;
  padding: 0;
}

.row-container {
  width: 100%;
  display: flex;
  flex-direction: column;
  gap: var(--space-4);
  position: relative;
}

h2 {
  margin: 0;
  font-size: 20px;
  font-weight: 700;
  color: #fff;
  letter-spacing: 0.5px;
  text-shadow: 0 2px 4px rgba(0,0,0,0.5);
  padding-left: var(--space-1);
}

.carousel-wrapper {
  position: relative;
  display: flex;
  align-items: center;
}

.movies {
  display: flex;
  overflow-x: auto;
  gap: var(--space-4);
  padding: var(--space-4) 0;
  scroll-behavior: smooth;
  scrollbar-width: none;
  width: 100%;
}

.movies::-webkit-scrollbar {
  display: none;
}

.nav-btn {
  background: rgba(0, 0, 0, 0.5);
  color: #fff;
  border: none;
  font-size: 3rem;
  width: 50px;
  height: 100%;
  position: absolute;
  z-index: 10;
  cursor: pointer;
  display: grid;
  place-items: center;
  transition: background 0.3s;
  top: 0;
  bottom: 0;
  opacity: 0;
}

.row-container:hover .nav-btn {
  opacity: 1;
}

.nav-btn:hover {
  background: rgba(0, 0, 0, 0.8);
  color: var(--color-primary);
}

.prev { left: 0; border-radius: 0 var(--radius-2) var(--radius-2) 0; background: linear-gradient(to right, rgba(0,0,0,0.8), transparent); }
.next { right: 0; border-radius: var(--radius-2) 0 0 var(--radius-2); background: linear-gradient(to left, rgba(0,0,0,0.8), transparent); }

/* Mobile: Hide buttons, allow swipe */
@media (max-width: 768px) {
  .nav-btn { display: none; }
}
</style>