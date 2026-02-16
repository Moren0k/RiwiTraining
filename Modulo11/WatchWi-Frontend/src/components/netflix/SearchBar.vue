<script setup lang="ts">
import { ref, computed, watch, onMounted, onUnmounted } from 'vue';
import type { Media } from '@/services/MediaService';

const props = defineProps<{
  items: Media[];
}>();

const emit = defineEmits<{
  (e: 'select', item: Media): void;
}>();

const query = ref('');
const isOpen = ref(false);
const highlightedIndex = ref(-1);
const searchInput = ref<HTMLInputElement | null>(null);
const searchContainer = ref<HTMLElement | null>(null);

// Debounced query to avoid heavy computations on every keypress
const debouncedQuery = ref('');
let debounceTimeout: number | null = null;

watch(query, (newVal) => {
  if (debounceTimeout) clearTimeout(debounceTimeout);
  debounceTimeout = window.setTimeout(() => {
    debouncedQuery.value = newVal.trim();
    isOpen.value = debouncedQuery.value.length > 0;
    highlightedIndex.value = -1;
  }, 200);
});

const filteredResults = computed(() => {
  const q = debouncedQuery.value.toLowerCase();
  if (!q) return [];

  // 1. Prefix matches
  const prefixMatches = props.items.filter(item => 
    item.title.toLowerCase().startsWith(q)
  );

  // 2. Substring matches (excluding those already in prefixMatches)
  const substringMatches = props.items.filter(item => 
    item.title.toLowerCase().includes(q) && !item.title.toLowerCase().startsWith(q)
  );

  return [...prefixMatches, ...substringMatches].slice(0, 10);
});

const handleKeydown = (e: KeyboardEvent) => {
  if (!isOpen.value) return;

  switch (e.key) {
    case 'ArrowDown':
      e.preventDefault();
      highlightedIndex.value = (highlightedIndex.value + 1) % filteredResults.value.length;
      break;
    case 'ArrowUp':
      e.preventDefault();
      highlightedIndex.value = (highlightedIndex.value - 1 + filteredResults.value.length) % filteredResults.value.length;
      break;
    case 'Enter':
      e.preventDefault();
      {
        const selection = filteredResults.value[highlightedIndex.value];
        if (selection) {
          selectItem(selection);
        }
      }
      break;
    case 'Escape':
      closeDropdown();
      break;
  }
};

const selectItem = (item: Media) => {
  emit('select', item);
  query.value = '';
  closeDropdown();
};

const closeDropdown = () => {
  isOpen.value = false;
  highlightedIndex.value = -1;
};

const handleClickOutside = (e: Event) => {
  if (searchContainer.value && !searchContainer.value.contains(e.target as Node)) {
    closeDropdown();
  }
};

onMounted(() => {
  document.addEventListener('click', handleClickOutside);
});

onUnmounted(() => {
  document.removeEventListener('click', handleClickOutside);
});
</script>

<template>
  <div class="search-container" ref="searchContainer" @keydown="handleKeydown">
    <div class="search-input-wrapper" :class="{ 'is-focused': isOpen }">
      <div class="search-icon-wrapper">
        <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round" class="search-svg">
          <circle cx="11" cy="11" r="8"></circle>
          <line x1="21" y1="21" x2="16.65" y2="16.65"></line>
        </svg>
      </div>
      <input
        ref="searchInput"
        v-model="query"
        type="text"
        placeholder="Buscar películas..."
        @focus="isOpen = query.length > 0"
      />
      <button v-if="query" class="clear-btn" @click="query = ''" title="Limpiar búsqueda">
        <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="3" stroke-linecap="round" stroke-linejoin="round">
          <line x1="18" y1="6" x2="6" y2="18"></line>
          <line x1="6" y1="6" x2="18" y2="18"></line>
        </svg>
      </button>
    </div>

    <Transition name="fade-slide">
      <div v-if="isOpen && (filteredResults.length > 0 || debouncedQuery)" class="search-dropdown">
        <div v-if="filteredResults.length === 0" class="no-results">
          No se encontraron resultados para <span class="query-text">"{{ debouncedQuery }}"</span>
        </div>
        <ul v-else>
          <li
            v-for="(item, index) in filteredResults"
            :key="item.id"
            :class="{ 'is-highlighted': index === highlightedIndex }"
            @click="selectItem(item)"
            @mouseenter="highlightedIndex = index"
          >
            <div class="thumb-wrapper">
              <img :src="item.posterUrl" :alt="item.title" class="result-thumb" />
            </div>
            <div class="result-info">
              <span class="result-title">{{ item.title }}</span>
              <p class="result-desc">{{ item.description }}</p>
            </div>
          </li>
        </ul>
      </div>
    </Transition>
  </div>
</template>

<style scoped>
.search-container {
  position: relative;
  width: 100%;
  max-width: 480px;
  z-index: 100;
}

.search-input-wrapper {
  display: flex;
  align-items: center;
  background: rgba(22, 17, 31, 0.6);
  backdrop-filter: blur(8px);
  -webkit-backdrop-filter: blur(8px);
  border: 1px solid rgba(255, 255, 255, 0.08);
  border-radius: var(--radius-3);
  padding: 0 16px;
  height: 44px;
  transition: all 0.25s cubic-bezier(0.4, 0, 0.2, 1);
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.2);
}

.search-input-wrapper.is-focused,
.search-input-wrapper:focus-within {
  border-color: var(--color-primary);
  box-shadow: 0 0 20px rgba(177, 0, 255, 0.15), 0 4px 15px rgba(0, 0, 0, 0.3);
  background: rgba(22, 17, 31, 0.85);
  transform: translateY(-1px);
}

.search-icon-wrapper {
  display: flex;
  align-items: center;
  margin-right: 12px;
}

.search-svg {
  color: var(--color-muted);
  transition: color 0.25s ease;
  opacity: 0.7;
}

.search-input-wrapper:focus-within .search-svg {
  color: var(--color-primary);
  opacity: 1;
}

input {
  flex: 1;
  background: transparent;
  border: none;
  color: var(--color-text);
  font-size: 14px;
  font-weight: 500;
  outline: none;
  padding: 8px 0;
  height: 100%;
}

input::placeholder {
  color: var(--color-muted);
  opacity: 0.5;
}

.clear-btn {
  background: rgba(255, 255, 255, 0.05);
  border: none;
  color: var(--color-muted);
  width: 24px;
  height: 24px;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  margin-left: 8px;
  transition: all 0.2s ease;
}

.clear-btn:hover {
  background: rgba(255, 255, 255, 0.12);
  color: var(--color-text);
  transform: scale(1.1);
}

/* Dropdown */
.search-dropdown {
  position: absolute;
  top: calc(100% + 12px);
  left: 0;
  right: 0;
  background: rgba(15, 12, 20, 0.88);
  backdrop-filter: blur(16px);
  -webkit-backdrop-filter: blur(16px);
  border: 1px solid rgba(255, 255, 255, 0.08);
  border-radius: var(--radius-3);
  box-shadow: 0 15px 40px rgba(0, 0, 0, 0.7), 0 0 0 1px rgba(255, 255, 255, 0.05);
  max-height: 480px;
  overflow-y: auto;
  scrollbar-width: thin;
  scrollbar-color: var(--color-primary) transparent;
  animation: slideDropdown 0.3s cubic-bezier(0.16, 1, 0.3, 1);
}

@keyframes slideDropdown {
  from { opacity: 0; transform: translateY(-10px) scale(0.98); }
  to { opacity: 1; transform: translateY(0) scale(1); }
}

.no-results {
  padding: 24px;
  text-align: center;
  color: var(--color-muted);
  font-size: 14px;
}

.query-text {
  color: var(--color-text);
  font-weight: 700;
}

ul {
  list-style: none;
  padding: 8px;
  margin: 0;
}

li {
  display: flex;
  gap: 16px;
  padding: 10px 12px;
  cursor: pointer;
  border-radius: var(--radius-2);
  transition: all 0.2s cubic-bezier(0.4, 0, 0.2, 1);
  margin-bottom: 4px;
}

li:last-child {
  margin-bottom: 0;
}

li.is-highlighted {
  background: rgba(177, 0, 255, 0.12);
  transform: translateX(4px);
}

.thumb-wrapper {
  width: 44px;
  height: 64px;
  border-radius: 6px;
  overflow: hidden;
  flex-shrink: 0;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.4);
}

.result-thumb {
  width: 100%;
  height: 100%;
  object-fit: cover;
  background: var(--color-surface);
}

.result-info {
  flex: 1;
  display: flex;
  flex-direction: column;
  justify-content: center;
  overflow: hidden;
}

.result-title {
  font-weight: 700;
  font-size: 14px;
  color: #fff;
  margin-bottom: 4px;
}

.result-desc {
  font-size: 12px;
  color: var(--color-muted);
  display: -webkit-box;
  -webkit-line-clamp: 2;
  line-clamp: 2;
  -webkit-box-orient: vertical;
  overflow: hidden;
  margin: 0;
  line-height: 1.4;
  opacity: 0.8;
}

/* Scrollbar */
.search-dropdown::-webkit-scrollbar {
  width: 5px;
}

.search-dropdown::-webkit-scrollbar-thumb {
  background: rgba(177, 0, 255, 0.4);
  border-radius: 10px;
}

.search-dropdown::-webkit-scrollbar-thumb:hover {
  background: var(--color-primary);
}

@media (max-width: 600px) {
  .search-container {
    max-width: 100%;
  }
  
  .search-input-wrapper {
    height: 48px;
    padding: 0 14px;
  }
}
</style>
