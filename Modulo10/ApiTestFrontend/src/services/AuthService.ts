import { api } from "@/api/http";
import type {
  AuthResponse,
  LoginRequest,
  RegisterRequest,
} from "@/models/AuthModels";

export class AuthService {
  static async authLogin(request: LoginRequest): Promise<AuthResponse> {
    const response = await api.post<AuthResponse>("auth/login", request);

    return response.data;
  }

  static async authRegister(request: RegisterRequest): Promise<AuthResponse> {
    const response = await api.post<AuthResponse>("auth/register", request);

    return response.data;
  }
}
