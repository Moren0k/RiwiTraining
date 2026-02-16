import api from "./http";

export interface Media {
    id: string;
    title: string;
    description: string;
    posterUrl: string;
    mediaUrl: string;
    isFeatured: boolean;
}

class MediaService {
    async getAllMedias(): Promise<Media[]> {
        const response = await api.get<Media[]>("api/Media");
        return response.data;
    }

    async getById(id: string): Promise<Media> {
        const response = await api.get<Media>(`api/Media/${id}`);
        return response.data;
    }

    async createMedia(formData: FormData): Promise<Media> {
        const response = await api.post<Media>("api/Media", formData, {
            headers: {
                "Content-Type": "multipart/form-data"
            }
        });
        return response.data;
    }

    async deleteMedia(id: string): Promise<void> {
        await api.delete(`api/Media/${id}`);
    }

    async toggleFeature(id: string): Promise<void> {
        await api.patch(`api/Media/${id}/feature`);
    }
}

export default new MediaService();
