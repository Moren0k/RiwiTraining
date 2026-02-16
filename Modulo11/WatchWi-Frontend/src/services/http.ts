import axios from "axios";
import { router } from "@/router";
import { useAuthStore } from "@/stores/auth";
import { useToastStore } from "@/stores/toast";

const api = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_URL,
    headers: {
        "Content-Type": "application/json"
    }
});

// Request Interceptor
api.interceptors.request.use(config => {
    const token = localStorage.getItem('accessToken');
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

// Response Interceptor
api.interceptors.response.use(
    response => response,
    error => {
        const toastStore = useToastStore();
        const authStore = useAuthStore();

        if (error.response?.status === 401) {
            authStore.logout(); // Cleanup and redirect
            toastStore.error("Session expired. Please login again.");
            return Promise.reject(error);
        }

        if (error.response?.status === 400) {
            const data = error.response.data;
            let message = "Bad Request";

            if (typeof data === 'string') {
                message = data;
            } else if (typeof data === 'object') {
                // Priority: detail > title > first error message
                message = data.detail || data.title || (data.errors ? Object.values(data.errors)[0] : "Invalid request");
            }
            
            toastStore.error(message);
        } else if (error.response?.status === 403) {
            toastStore.error("Access denied. You don't have permissions.");
        } else if (error.response?.status === 404) {
            toastStore.warning("Resource not found.");
        } else if (error.response?.status >= 500) {
            toastStore.error("Server error. Please try later.");
        } else if (!error.response) {
            toastStore.error("Network error. Check your connection.");
        }

        return Promise.reject(error);
    }
);

export default api;