import { useEffect, useState, useCallback } from "react";
import { useParams } from "react-router-dom";
import type { Lesson } from "../lessons/lessonTypes";
import { getLessons, createLesson, deleteLesson } from "../lessons/lessonApi";

export function CourseDetailPage() {
  const { id } = useParams<{ id: string }>();
  const courseId = id!;

  const [lessons, setLessons] = useState<Lesson[]>([]);
  const [title, setTitle] = useState("");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [success, setSuccess] = useState<string | null>(null);

  const loadLessons = useCallback(async () => {
    setLoading(true);
    setError(null);

    try {
      const data = await getLessons(courseId);
      setLessons(data);
    } catch {
      setError("No se pudieron cargar las lecciones");
    } finally {
      setLoading(false);
    }
  }, [courseId]);

  useEffect(() => {
    loadLessons();
  }, [loadLessons]);

  async function onCreateLesson(e: React.FormEvent) {
    e.preventDefault();
    if (!title.trim()) return;

    setError(null);
    setSuccess(null);
    setLoading(true);

    try {
      await createLesson(courseId, title);
      setTitle("");
      setSuccess("Lección creada correctamente");
      await loadLessons();
    } catch {
      setError("No se pudo crear la lección");
    } finally {
      setLoading(false);
    }
  }

  async function onDeleteLesson(lessonId: string) {
    if (!window.confirm("¿Eliminar esta lección?")) return;

    setError(null);
    setSuccess(null);

    try {
      await deleteLesson(courseId, lessonId);
      setSuccess("Lección eliminada");
      await loadLessons();
    } catch {
      setError("No se pudo eliminar la lección");
    }
  }

  return (
    <div style={{ padding: 16 }}>
      <h2>Lecciones del curso</h2>

      {loading && <p>Cargando...</p>}
      {error && <p style={{ color: "red" }}>{error}</p>}
      {success && <p style={{ color: "green" }}>{success}</p>}

      <form onSubmit={onCreateLesson} style={{ marginBottom: 16 }}>
        <input
          placeholder="Título de la lección"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          style={{ marginRight: 8 }}
        />
        <button type="submit" disabled={loading}>
          Agregar
        </button>
      </form>

      {lessons.length === 0 && !loading && (
        <p>Este curso aún no tiene lecciones</p>
      )}

      <ul>
        {lessons
          .slice()
          .sort((a, b) => a.order - b.order)
          .map((l) => (
            <li key={l.id}>
              {l.title}
              <button
                style={{ marginLeft: 8 }}
                onClick={() => onDeleteLesson(l.id)}
              >
                Eliminar
              </button>
            </li>
          ))}
      </ul>
    </div>
  );
}
