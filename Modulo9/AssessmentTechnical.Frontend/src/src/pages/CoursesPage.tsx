import { useEffect, useState } from "react";
import type { Course } from "../courses/courseTypes";
import { courseStatusLabel } from "../courses/courseUtils";
import {
  searchCourses,
  createCourse,
  publishCourse,
  unpublishCourse,
  updateCourse,
  deleteCourse,
} from "../courses/courseApi";

export function CoursesPage() {
  const [courses, setCourses] = useState<Course[]>([]);
  const [statusFilter, setStatusFilter] = useState<number | "">("");
  const [page, setPage] = useState(1);
  const pageSize = 5;

  const [newTitle, setNewTitle] = useState("");
  const [editingId, setEditingId] = useState<string | null>(null);
  const [editingTitle, setEditingTitle] = useState("");

  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [success, setSuccess] = useState<string | null>(null);

  async function loadCourses() {
    setLoading(true);
    setError(null);

    try {
      const data = await searchCourses({
        page,
        pageSize,
        status: statusFilter === "" ? undefined : statusFilter,
      });
      setCourses(data);
    } catch {
      setError("Error cargando cursos");
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => {
    loadCourses();
  }, [page, statusFilter]);

  async function onCreateCourse(e: React.FormEvent) {
    e.preventDefault();
    if (!newTitle.trim()) return;

    try {
      await createCourse({ title: newTitle });
      setNewTitle("");
      setSuccess("Curso creado");
      await loadCourses();
    } catch {
      setError("Error creando curso");
    }
  }

  async function onSaveEdit(id: string) {
    try {
      await updateCourse(id, { title: editingTitle });
      setEditingId(null);
      setEditingTitle("");
      setSuccess("Curso actualizado");
      await loadCourses();
    } catch {
      setError("No se pudo actualizar el curso");
    }
  }

  async function onDelete(id: string) {
    if (!window.confirm("¿Eliminar este curso?")) return;

    try {
      await deleteCourse(id);
      setSuccess("Curso eliminado");
      await loadCourses();
    } catch {
      setError("No se pudo eliminar el curso");
    }
  }

  async function onPublish(id: string) {
    try {
      await publishCourse(id);
      await loadCourses();
    } catch {
      setError("No se pudo publicar");
    }
  }

  async function onUnpublish(id: string) {
    try {
      await unpublishCourse(id);
      await loadCourses();
    } catch {
      setError("No se pudo despublicar");
    }
  }

  return (
    <div style={{ padding: 16 }}>
      <h2>Cursos</h2>

      {loading && <p>Cargando...</p>}
      {error && <p style={{ color: "red" }}>{error}</p>}
      {success && <p style={{ color: "green" }}>{success}</p>}

      <form onSubmit={onCreateCourse} style={{ marginBottom: 16 }}>
        <input
          placeholder="Nuevo curso"
          value={newTitle}
          onChange={(e) => setNewTitle(e.target.value)}
        />
        <button type="submit">Crear</button>
      </form>

      <table border={1} cellPadding={8}>
        <thead>
          <tr>
            <th>Título</th>
            <th>Estado</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {courses.map((c) => (
            <tr key={c.id}>
              <td>
                {editingId === c.id ? (
                  <input
                    value={editingTitle}
                    onChange={(e) => setEditingTitle(e.target.value)}
                  />
                ) : (
                  <a href={`/courses/${c.id}`}>{c.title}</a>
                )}
              </td>
              <td>{courseStatusLabel(c.status)}</td>
              <td>
                {editingId === c.id ? (
                  <>
                    <button onClick={() => onSaveEdit(c.id)}>Guardar</button>
                    <button onClick={() => setEditingId(null)}>Cancelar</button>
                  </>
                ) : (
                  <>
                    <button
                      onClick={() => {
                        setEditingId(c.id);
                        setEditingTitle(c.title);
                      }}
                    >
                      Editar
                    </button>

                    <button onClick={() => onDelete(c.id)}>Eliminar</button>

                    {c.status === 0 && (
                      <button onClick={() => onPublish(c.id)}>Publicar</button>
                    )}
                    {c.status === 1 && (
                      <button onClick={() => onUnpublish(c.id)}>
                        Despublicar
                      </button>
                    )}
                  </>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <div style={{ marginTop: 12 }}>
        <button
          disabled={page === 1}
          onClick={() => setPage((p) => Math.max(1, p - 1))}
        >
          Anterior
        </button>

        <span style={{ margin: "0 8px" }}>Página {page}</span>

        <button onClick={() => setPage((p) => p + 1)}>
          Siguiente
        </button>
      </div>

    </div>
  );
}
