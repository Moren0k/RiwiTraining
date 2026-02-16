import api from "./http";
import type { AuthResponse } from "../models/User";

export class AuthService {

    static async login(email: string, password: string): Promise<AuthResponse> {
        const response = await api.post<AuthResponse>("Auth/login", {
            email,
            password
        });
        return response.data;
    }

    static async register(username: string, email: string, password: string): Promise<AuthResponse> {
        const response = await api.post<AuthResponse>("Auth/register", {
            username,
            email,
            password
        });
        return response.data;
    }
}