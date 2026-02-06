import { http } from "../api/http";
import type { Course } from "./courseTypes";

export type SearchCoursesParams = {
  q?: string;
  status?: number;
  page: number;
  pageSize: number;
};

export type CreateCourseRequest = {
  title: string;
};

export type UpdateCourseRequest = {
  title: string;
};

export async function searchCourses(
  params: SearchCoursesParams
): Promise<Course[]> {
  const { data } = await http.get<Course[]>("/api/courses/search", { params });
  return data;
}

export async function createCourse(req: CreateCourseRequest): Promise<void> {
  await http.post("/api/courses", req);
}

export async function updateCourse(
  id: string,
  req: UpdateCourseRequest
): Promise<void> {
  await http.put(`/api/courses/${id}`, req);
}

export async function deleteCourse(id: string): Promise<void> {
  await http.delete(`/api/courses/${id}`);
}

export async function publishCourse(id: string): Promise<void> {
  await http.patch(`/api/courses/${id}/publish`);
}

export async function unpublishCourse(id: string): Promise<void> {
  await http.patch(`/api/courses/${id}/unpublish`);
}