import api from "./http";
import type { User } from "../models/User";
import type { Media } from "./MediaService";

export class UsersService {
    static async getProfile(): Promise<User> {
        const response = await api.get<User>("Users/profile");
        return response.data;
    }

    static async updateProfile(username: string): Promise<User> {
        const response = await api.put<User>("Users/profile", {
            username
        });
        return response.data;
    }

    static async uploadProfileImage(file: File): Promise<User> {
        const formData = new FormData();
        formData.append('file', file);
        
        const response = await api.post<User>("Users/profile-image", formData, {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        });
        return response.data;
    }

    static async getFavorites(): Promise<Media[]> {
        const response = await api.get<any[]>("Users/favorites");
        return response.data.map((item: any) => ({
            id: item.id || item.Id,
            title: item.title || item.Title,
            description: item.description || item.Description || '',
            posterUrl: item.posterUrl || item.PosterUrl || '',
            mediaUrl: '', // Favorites DTO doesn't include mediaUrl
            isFeatured: false
        }));
    }

    static async addFavorite(mediaId: string): Promise<string> {
        const response = await api.post<string>(`Users/favorites/${mediaId}`);
        return response.data;
    }

    static async removeFavorite(mediaId: string): Promise<string> {
        const response = await api.delete<string>(`Users/favorites/${mediaId}`);
        return response.data;
    }
}
