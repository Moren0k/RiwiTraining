import { api } from "@/api/http";
import type { ChangeUserRoleRequest } from "@/models/User";

export class AdminService {
  static async getAllUsers() {
    const response = await api.get(`/users`);

    return response.data;
  }

  static async removeUserById(id: string) {
    const response = await api.delete(`/users/${id}`);

    return response.data;
  }

  static async changeUserRole(userId: string, request: ChangeUserRoleRequest) {
    const response = await api.patch(`/users/${userId}/role`, request);

    return response.data;
  }

  static async uploadImage(file: File)
  {
    const response = await api.post(`/images/upload`, file);

    return response.data;
  }
}
