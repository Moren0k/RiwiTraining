import { defineStore } from 'pinia';
import { ref, computed } from 'vue';
import type { Media } from '@/services/MediaService';
import { UsersService } from '@/services/UsersService';
import { useToastStore } from '@/stores/toast';

export const useFavoritesStore = defineStore('favorites', () => {
    const favorites = ref<Media[]>([]);
    const loading = ref(false);
    const toastStore = useToastStore();

    const favoriteIds = computed(() => new Set(favorites.value.map(m => m.id)));

    async function fetchFavorites() {
        loading.value = true;
        try {
            favorites.value = await UsersService.getFavorites();
        } catch (error) {
            console.error('Failed to fetch favorites:', error);
        } finally {
            loading.value = false;
        }
    }

    async function toggleFavorite(media: Media) {
        const isFav = favoriteIds.value.has(media.id);
        
        // Optimistic Update
        const previousFavorites = [...favorites.value];
        if (isFav) {
            favorites.value = favorites.value.filter(m => m.id !== media.id);
        } else {
            favorites.value.push(media);
        }

        try {
            if (isFav) {
                await UsersService.removeFavorite(media.id);
                toastStore.info(`"${media.title}" eliminada de favoritos`);
            } else {
                await UsersService.addFavorite(media.id);
                toastStore.success(`"${media.title}" añadida a favoritos`);
            }
        } catch (error) {
            // Rollback on error
            favorites.value = previousFavorites;
            toastStore.error('Error al actualizar favoritos');
            console.error('Favorite toggle failed:', error);
        }
    }

    function isFavorite(mediaId: string) {
        return favoriteIds.value.has(mediaId);
    }

    return {
        favorites,
        loading,
        favoriteIds,
        fetchFavorites,
        toggleFavorite,
        isFavorite
    };
});
