import { api } from "@/api/http";

export default class UserService {

  static async getAllImages() {
    const response = await api.get("/images");

    return response.data;
  }
}
