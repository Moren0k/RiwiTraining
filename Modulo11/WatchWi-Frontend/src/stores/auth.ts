import { defineStore } from 'pinia';
import { ref } from 'vue';
import type { User } from '@/models/User';
import { router } from '@/router';
import { UsersService } from '@/services/UsersService';

export const useAuthStore = defineStore('auth', () => {
    const user = ref<User | null>(JSON.parse(localStorage.getItem('user') || 'null'));
    const accessToken = ref<string | null>(localStorage.getItem('accessToken'));
    const isLoadingUser = ref(false);

    function setUser(newUser: User) {
        user.value = newUser;
        localStorage.setItem('user', JSON.stringify(newUser));
    }

    function setToken(token: string) {
        accessToken.value = token;
        localStorage.setItem('accessToken', token);
    }

    async function hydrateUser() {
        if (!accessToken.value) return;
        
        isLoadingUser.value = true;
        try {
            const freshUser = await UsersService.getProfile();
            setUser(freshUser);
        } catch (error) {
            console.error('Failed to hydrate user:', error);
            // Optional: if 401, logout is handled by interceptor
        } finally {
            isLoadingUser.value = false;
        }
    }

    function logout() {
        user.value = null;
        accessToken.value = null;
        localStorage.removeItem('user');
        localStorage.removeItem('accessToken');
        router.push('/');
    }

    return {
        user,
        accessToken,
        isLoadingUser,
        setUser,
        setToken,
        hydrateUser,
        logout
    };
});
