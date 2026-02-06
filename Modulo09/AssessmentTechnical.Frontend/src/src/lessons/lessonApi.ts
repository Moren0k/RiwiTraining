import { http } from "../api/http";
import type { Lesson } from "./lessonTypes";

export async function getLessons(courseId: string): Promise<Lesson[]> {
  const { data } = await http.get<Lesson[]>(`/api/courses/${courseId}/lessons`);
  return data;
}

export async function createLesson(
  courseId: string,
  title: string
): Promise<void> {
  await http.post(`/api/courses/${courseId}/lessons`, {
    title,
  });
}

export async function updateLesson(
  courseId: string,
  lessonId: string,
  title: string,
  order: number
): Promise<void> {
  await http.put(`/api/courses/${courseId}/lessons/${lessonId}`, {
    title,
    order,
  });
}

export async function deleteLesson(
  courseId: string,
  lessonId: string
): Promise<void> {
  await http.delete(`/api/courses/${courseId}/lessons/${lessonId}`);
}