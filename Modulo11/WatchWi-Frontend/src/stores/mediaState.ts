import { defineStore } from 'pinia';
import { ref } from 'vue';
import MediaService, { type Media } from '@/services/MediaService';

export const useMediaStateStore = defineStore('mediaState', () => {
    const medias = ref<Media[]>([]);
    const selectedMedia = ref<Media | null>(null);
    const isModalOpen = ref(false);
    const isLoading = ref(false);

    async function fetchMedias() {
        isLoading.value = true;
        try {
            medias.value = await MediaService.getAllMedias();
        } catch (error) {
            console.error('Failed to fetch medias:', error);
        } finally {
            isLoading.value = false;
        }
    }

    function openModal(media: Media) {
        selectedMedia.value = media;
        isModalOpen.value = true;
    }

    function closeModal() {
        isModalOpen.value = false;
        selectedMedia.value = null;
    }

    return {
        medias,
        selectedMedia,
        isModalOpen,
        isLoading,
        fetchMedias,
        openModal,
        closeModal
    };
});
