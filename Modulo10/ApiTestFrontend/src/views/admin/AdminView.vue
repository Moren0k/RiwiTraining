<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { AdminService } from '@/services/AdminService'
import { UserRole, type ChangeUserRoleRequest, type User } from '@/models/User'
import { Image } from '@/models/Image'
import UserServices from '@/services/UserService'

const users = ref<User[]>([])
const images = ref<Image[]>([])
const error = ref('')
const selectedFile = ref<File | null>(null)

async function loadUsers() {
  try {
    users.value = await AdminService.getAllUsers()
  } catch (e) {
    error.value = 'Error cargando usuarios'
  }
}

async function loadImages() {
  try {
    images.value = await UserServices.getAllImages();
  } catch (error) {
    error.value = "Error cargando imagenes"
  }
}

function onFileSelected(event: Event) {
  const input = event.target as HTMLInputElement
  if (input.files && input.files.length > 0) {
    selectedFile.value = input.files[0]
  }
}

async function uploadImg() {
  if (!selectedFile.value) {
    alert('Selecciona una imagen')
    return
  }

  try {
    await AdminService.uploadImage(selectedFile.value)
    selectedFile.value = null
    await loadImages()
    alert('Imagen cargada')
  } catch {
    error.value = 'Error subiendo imagen'
  }
}

async function removeUser(id: string) {
  try {
    await AdminService.removeUserById(id)
    alert("Eliminado!")
    loadUsers();
    return
  } catch (e) {
    error.value = 'Error eliminando usuario'
  }
}

async function setUserRole(id: string, role: ChangeUserRoleRequest) {
  try {
    await AdminService.changeUserRole(id, role)
    alert("Actualizado")
    loadUsers();
    return
  } catch (e) {
    error.value = ("Error cambiando rol de usuario")
  }
}

onMounted(() => {
  const userRole = localStorage.getItem('user_role')

  if (userRole !== 'Admin') {
    error.value = 'No autorizado, solo para Admin'
    return
  }

  loadUsers()
  loadImages()
})
</script>

<template>
  <div>
    <h3>
      Lista de Usuarios
    </h3>

    <div v-if="error">
      <strong>Error:</strong> {{ error }}
    </div>

    <div v-if="users && users.length > 0">
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Nombre</th>
            <th>Email</th>
            <th>Rol</th>
            <th>Remove</th>
            <th>ChangeRole</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="user in users" :key="user.id">
            <td>#{{ user.id }}</td>
            <td>{{ user.name }}</td>
            <td>{{ user.email }}</td>
            <td>
              <span>
                {{ user.role }}
              </span>
            </td>
            <td>
              <button @click="removeUser(user.id)">
                Eliminar
              </button>
            </td>
            <td>
              <div v-if="user.role == 'User'">
                <button @click="setUserRole(user.id, { role: UserRole.Admin })">
                  Cambiar a Admin
                </button>
              </div>
              <div v-else="user.role == 'Admin'">
                <button @click="setUserRole(user.id, { role: UserRole.User })">
                  Cambiar a User
                </button>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <div v-else-if="!error">
      <p>No se encontraron usuarios o la lista está vacía.</p>
    </div>
  </div>


  <hr />

  <div>
    <h2>Manejo de Imágenes</h2>

    <input type="file" @change="onFileSelected" />
    <button @click="uploadImg">Subir Imagen</button>

    <div v-if="images.length">
      <div v-for="image in images" :key="image.url">
        <img :src="image.publicId" alt="Imagen" style="max-width: 250px; margin: 10px" />
        <a :href="image.publicId">{{ image.publicId }}</a>
        <p>{{ image.url }}</p>
      </div>
    </div>

    <p v-else>No hay imágenes cargadas</p>
  </div>
</template>