export interface User {
    id: string;
    username: string;
    email: string;
    role: string;
    status: boolean;
    plan: string;
    profileImageUrl: string | null;
}

export interface AuthResponse {
    accessToken: string;
    user: User;
}