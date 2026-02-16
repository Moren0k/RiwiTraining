<template>
  <HeaderNetflix />

  <div data-page="admin">
    <div data-container="main">
      <h1>Admin Dashboard</h1>

      <!-- CREATE MEDIA SECTION -->
      <section>
        <h2>Create New Media</h2>
        <form @submit.prevent="handleCreate">
          <div>
            <label>Title</label>
            <input v-model="form.title" type="text" required />
          </div>

          <div>
            <label>Description</label>
            <textarea v-model="form.description" required></textarea>
          </div>

          <div>
            <label>Media Type</label>
            <select v-model="form.mediaType" required>
              <option :value="10">Movie</option>
              <option :value="20">Series</option>
            </select>
          </div>

          <div>
            <label>Media URL (Video)</label>
            <input v-model="form.mediaUrl" type="text" required />
          </div>

          <div>
            <label>Category IDs (Comma separated)</label>
            <input v-model="form.categoryIds" type="text" placeholder="GUID1, GUID2" />
          </div>

          <div>
            <label>Poster Image</label>
            <input type="file" @change="handleFileUpload" accept="image/*" required />
          </div>

          <button type="submit" :disabled="loading" class="submit-btn">
            {{ loading ? 'Creating...' : 'Create Media' }}
          </button>
        </form>
      </section>

      <!-- MEDIA LIST SECTION -->
      <section>
        <h2>Media Management</h2>
        <div v-if="loadingList" data-loading>Loading medias...</div>

        <table v-else>
          <thead>
            <tr>
              <th>Poster</th>
              <th>Info</th>
              <th>URLs</th>
              <th>Status</th>
              <th>Actions</th>
            </tr>
          </thead>

          <tbody>
            <tr v-for="media in medias" :key="media.id">
              <td>
                <img :src="media.posterUrl" alt="Poster" />
              </td>

              <td>
                <div>
                  <strong>{{ media.title }}</strong>
                  <p>{{ media.description }}</p>
                </div>
              </td>

              <td>
                <div>
                  <a :href="media.mediaUrl" target="_blank">Video Link</a>
                  <a :href="media.posterUrl" target="_blank">Poster Link</a>
                </div>
              </td>

              <td>
                <span @click="toggleFeature(media)">
                  {{ media.isFeatured ? 'ACTIVE' : 'INACTIVE' }}
                </span>
              </td>

              <td>
                <button @click="deleteMedia(media.id)">
                  Delete
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </section>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, onMounted } from 'vue';
import HeaderNetflix from '@/components/layout/HeaderNetflix.vue';
import MediaService, { type Media } from '@/services/MediaService';
import { useAuthStore } from '@/stores/auth';
import { useToastStore } from '@/stores/toast';

const authStore = useAuthStore();
const toastStore = useToastStore();
const medias = ref<Media[]>([]);
const loading = ref(false);
const loadingList = ref(false);

const form = reactive({
  title: '',
  description: '',
  mediaType: 10,
  mediaUrl: '',
  categoryIds: '',
});
const posterFile = ref<File | null>(null);

const handleFileUpload = (event: Event) => {
  const target = event.target as HTMLInputElement;
  if (target.files && target.files[0]) {
    posterFile.value = target.files[0];
  }
};

const fetchMedias = async () => {
  loadingList.value = true;
  try {
    medias.value = await MediaService.getAllMedias();
  } catch (error) {
    console.error('Error fetching medias:', error);
  } finally {
    loadingList.value = false;
  }
};

const handleCreate = async () => {
  if (!posterFile.value) {
    toastStore.warning('Se requiere una imagen de póster');
    return;
  }

  loading.value = true;

  try {
    const formData = new FormData();
    formData.append('Title', form.title);
    formData.append('Description', form.description);
    formData.append('MediaType', form.mediaType.toString());
    formData.append('MediaUrl', form.mediaUrl);
    formData.append('Poster', posterFile.value);

    if (form.categoryIds) {
      const ids = form.categoryIds.split(',').map(id => id.trim());
      ids.forEach(id => {
        if (id) formData.append('CategoryIds', id);
      });
    }

    await MediaService.createMedia(formData);

    toastStore.success('Contenido creado correctamente');

    // Reset Form
    form.title = '';
    form.description = '';
    form.mediaUrl = '';
    form.categoryIds = '';
    posterFile.value = null;
    const fileInput = document.querySelector('input[type="file"]') as HTMLInputElement;
    if (fileInput) fileInput.value = '';

    fetchMedias();
  } catch (error) {
    console.error(error);
    // Errobres ya manejados por el interceptor global
  } finally {
    loading.value = false;
  }
};

const deleteMedia = async (id: string) => {
  if (!confirm('Are you sure you want to delete this media?')) return;

  try {
    await MediaService.deleteMedia(id);
    medias.value = medias.value.filter(m => m.id !== id);
  } catch (error) {
    console.error('Error deleting media:', error);
    alert('Failed to delete media');
  }
};

const toggleFeature = async (media: Media) => {
  if (authStore.user?.role !== 'Admin') return; // Strict role check

  try {
    await MediaService.toggleFeature(media.id);
    // Success: Refresh list to reflect server-side enforcement (only one featured)
    await fetchMedias();
  } catch (error: any) {
    console.error('Error toggling feature:', error);

    if (error.response) {
      const status = error.response.status;
      if (status === 401 || status === 403) {
        alert('Unauthorized: Only admins can perform this action.');
      } else {
        alert('Failed to update status: ' + (error.response.data?.message || 'Unknown error'));
      }
    } else {
      alert('Network error or server unreachable.');
    }
  }
};

onMounted(() => {
  fetchMedias();
});
</script>

<style scoped>
/* ====== Page wrapper (2 divs anidados) ====== */
[data-page="admin"] {
  min-height: 100vh;
  padding: var(--space-8) var(--space-4) var(--space-12);
  position: relative;
}

/* Ambient background */
[data-page="admin"]::before {
  content: "";
  position: fixed;
  inset: 0;
  z-index: -1;
  pointer-events: none;

  background:
    radial-gradient(900px circle at 18% 10%, rgba(177, 0, 255, 0.10), transparent 55%),
    radial-gradient(1100px circle at 88% 35%, rgba(124, 0, 255, 0.08), transparent 60%),
    radial-gradient(900px circle at 55% 95%, rgba(177, 0, 255, 0.05), transparent 55%);
}

[data-container="main"] {
  width: 100%;
  max-width: 1200px;
  margin: 0 auto;

  display: flex;
  flex-direction: column;
  gap: var(--space-8);
}

/* ====== Headings ====== */
h1 {
  margin: 0;
  font-size: clamp(22px, 3vw, 32px);
  font-weight: 900;
  letter-spacing: 0.6px;
  color: var(--color-text);
}

h1::after {
  content: "";
  display: block;
  margin-top: var(--space-3);
  height: 1px;
  background: linear-gradient(90deg, rgba(177, 0, 255, 0.45), rgba(255,255,255,0.08), transparent);
}

h2 {
  margin: 0 0 var(--space-4);
  font-size: 14px;
  font-weight: 800;
  letter-spacing: 0.3px;
  color: rgba(241, 241, 243, 0.85);
}

/* ====== Sections (cards) ====== */
section {
  border-radius: var(--radius-3);
  padding: clamp(16px, 2.5vw, 22px);

  background: linear-gradient(
      180deg,
      rgba(22, 17, 31, 0.70),
      rgba(15, 12, 20, 0.65)
    );

  border: 1px solid rgba(255, 255, 255, 0.10);

  box-shadow:
    var(--shadow-1),
    0 0 0 1px rgba(177, 0, 255, 0.10),
    0 0 32px rgba(177, 0, 255, 0.10);

  position: relative;
  overflow: hidden;
}

section::before {
  content: "";
  position: absolute;
  inset: -2px;
  pointer-events: none;
  border-radius: inherit;

  background: radial-gradient(700px circle at 20% 0%, rgba(177, 0, 255, 0.14), transparent 55%);
}

/* ====== Form ====== */
form {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: var(--space-4);
  align-items: start;
}

form > div {
  display: flex;
  flex-direction: column;
  gap: var(--space-2);
}

label {
  font-size: 12px;
  font-weight: 800;
  letter-spacing: 0.2px;
  color: rgba(241, 241, 243, 0.78);
}

/* Inputs */
input,
textarea,
select {
  border-radius: var(--radius-2);
  border: 1px solid rgba(255, 255, 255, 0.10);
  background: rgba(0, 0, 0, 0.28);
  color: var(--color-text);

  padding: 10px 12px;
  outline: none;

  transition: border-color 160ms ease, box-shadow 160ms ease, background-color 160ms ease;
}

textarea {
  min-height: 110px;
  resize: vertical;
}

input:focus,
textarea:focus,
select:focus {
  border-color: rgba(177, 0, 255, 0.45);
  box-shadow: 0 0 0 3px rgba(177, 0, 255, 0.16);
  background: rgba(0, 0, 0, 0.35);
}

/* File input no se deja “bonito” con CSS puro igual que los otros,
   pero al menos lo alineamos y respetamos tipografía */
input[type="file"] {
  padding: 10px;
}

/* Submit button (el del form) */
form > button[type="submit"] {
  grid-column: 1 / -1;

  border: 1px solid rgba(255, 255, 255, 0.10);
  border-radius: var(--radius-2);

  background: linear-gradient(180deg, var(--color-primary), var(--color-primary-2));
  color: #fff;

  padding: 12px 14px;
  font-weight: 900;
  letter-spacing: 0.3px;

  cursor: pointer;

  box-shadow: 0 0 22px rgba(177, 0, 255, 0.22);
  transition: transform 160ms ease, box-shadow 160ms ease, filter 160ms ease;
}

form > button[type="submit"]:hover:not(:disabled) {
  filter: brightness(1.05);
  box-shadow: 0 0 30px rgba(177, 0, 255, 0.28);
}

form > button[type="submit"]:active:not(:disabled) {
  transform: translateY(1px);
}

form > button[type="submit"]:disabled {
  opacity: 0.65;
  cursor: not-allowed;
  box-shadow: none;
}

/* Message <p v-if="message"> */
form > p {
  grid-column: 1 / -1;
  margin: 0;

  padding: 10px 12px;
  border-radius: var(--radius-2);
  font-weight: 750;
  font-size: 13px;

  border: 1px solid rgba(255, 255, 255, 0.10);
  background: rgba(255, 255, 255, 0.05);
  color: rgba(241, 241, 243, 0.88);
}

/* Si quieres diferenciar success/error sin tocar template:
   usamos :has() si el navegador soporta (Chrome/Safari modernos).
   Si no lo soporta, el mensaje igual se ve bien neutro. */
form:has(p) p {
  box-shadow: 0 0 20px rgba(177, 0, 255, 0.10);
}

/* ====== LoadingList (div v-if) ====== */
[data-loading] {
  padding: var(--space-8) 0;
  text-align: center;
  color: var(--color-muted);
  font-weight: 700;
}

/* ====== Table ====== */
table {
  width: 100%;
  border-collapse: collapse;

  border-radius: var(--radius-3);
  overflow: hidden;

  border: 1px solid rgba(255, 255, 255, 0.10);
  background: rgba(0, 0, 0, 0.18);
}

thead th {
  text-align: left;
  font-size: 12px;
  letter-spacing: 0.3px;
  font-weight: 900;

  padding: 12px;
  color: rgba(241, 241, 243, 0.78);

  background: rgba(255, 255, 255, 0.04);
  border-bottom: 1px solid rgba(255, 255, 255, 0.08);
}

tbody td {
  padding: 12px;
  vertical-align: top;
  border-bottom: 1px solid rgba(255, 255, 255, 0.06);
  color: rgba(241, 241, 243, 0.90);
}

tbody tr:hover {
  background: rgba(177, 0, 255, 0.06);
}

/* Poster thumbnail */
img {
  width: 66px;
  height: 96px;
  object-fit: cover;
  border-radius: var(--radius-2);
  border: 1px solid rgba(255, 255, 255, 0.10);
  box-shadow: 0 0 20px rgba(0,0,0,0.35);
}

/* Title + description */
strong {
  display: block;
  font-weight: 900;
  margin-bottom: 6px;
  letter-spacing: 0.2px;
}

p {
  margin: 0;
  color: var(--color-muted);
  font-size: 13px;

  display: -webkit-box;
  -webkit-line-clamp: 2;
  line-clamp: 2;
  -webkit-box-orient: vertical;
  overflow: hidden;
}

/* URL links */
a {
  color: rgba(241, 241, 243, 0.92);
  text-decoration: none;
  font-weight: 800;

  display: inline-block;
  margin-right: 10px;
  margin-bottom: 6px;

  border-bottom: 1px solid rgba(177, 0, 255, 0.35);
  transition: border-color 160ms ease, text-shadow 160ms ease, color 160ms ease;
}

a:hover {
  border-bottom-color: rgba(177, 0, 255, 0.75);
  text-shadow: 0 0 16px rgba(177, 0, 255, 0.22);
  color: var(--color-text);
}

/* Feature status pill */
span {
  display: inline-flex;
  align-items: center;
  justify-content: center;

  padding: 6px 10px;
  border-radius: 999px;

  font-size: 12px;
  font-weight: 950;
  letter-spacing: 0.4px;

  border: 1px solid rgba(255, 255, 255, 0.10);
  background: rgba(255, 255, 255, 0.06);
  color: rgba(241, 241, 243, 0.92);

  cursor: pointer;
  user-select: none;

  transition: background-color 160ms ease, box-shadow 160ms ease, transform 160ms ease;
}

span:hover {
  background: rgba(177, 0, 255, 0.12);
  box-shadow: 0 0 18px rgba(177, 0, 255, 0.18);
}

span:active {
  transform: translateY(1px);
}

/* Delete button (los botones dentro de la tabla) */
tbody button {
  border: 1px solid rgba(255, 255, 255, 0.10);
  border-radius: var(--radius-2);

  background: rgba(255, 59, 107, 0.14);
  color: rgba(255, 225, 235, 0.95);

  padding: 8px 10px;
  font-weight: 900;
  letter-spacing: 0.2px;

  cursor: pointer;
  transition: background-color 160ms ease, box-shadow 160ms ease, transform 160ms ease;
}

tbody button:hover {
  background: rgba(255, 59, 107, 0.20);
  box-shadow: 0 0 18px rgba(255, 59, 107, 0.12);
}

tbody button:active {
  transform: translateY(1px);
}

/* ====== Responsive ====== */
@media (max-width: 900px) {
  form {
    grid-template-columns: 1fr;
  }

  thead {
    display: none; /* tabla -> cards en móvil */
  }

  table,
  tbody,
  tr,
  td {
    display: block;
    width: 100%;
  }

  tbody tr {
    border-bottom: 1px solid rgba(255, 255, 255, 0.08);
    padding: var(--space-4);
  }

  tbody td {
    border: none;
    padding: 10px 0;
  }

  /* Poster centrado */
  tbody td:first-child {
    display: flex;
    justify-content: flex-start;
  }

  img {
    width: 84px;
    height: 120px;
  }
}

@media (max-width: 520px) {
  [data-page="admin"] {
    padding: var(--space-6) var(--space-3) var(--space-10);
  }
}

/* Reduce motion */
@media (prefers-reduced-motion: reduce) {
  input,
  textarea,
  select,
  button,
  a,
  span,
  tr {
    transition: none;
  }
}
</style>
