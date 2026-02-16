import { defineStore } from 'pinia';
import { ref } from 'vue';

export type ToastType = 'success' | 'error' | 'warning' | 'info';

interface Toast {
    id: number;
    message: string;
    type: ToastType;
}

export const useToastStore = defineStore('toast', () => {
    const toasts = ref<Toast[]>([]);
    let counter = 0;

    function show(message: string, type: ToastType = 'info') {
        const id = ++counter;
        toasts.value.push({ id, message, type });

        // Auto remove after 4 seconds
        setTimeout(() => {
            remove(id);
        }, 4000);
    }

    function remove(id: number) {
        toasts.value = toasts.value.filter(t => t.id !== id);
    }

    function success(message: string) { show(message, 'success'); }
    function error(message: string) { show(message, 'error'); }
    function warning(message: string) { show(message, 'warning'); }
    function info(message: string) { show(message, 'info'); }

    return {
        toasts,
        success,
        error,
        warning,
        info,
        remove
    };
});
