<script setup lang="ts">
import { ref, onMounted } from 'vue'
import UserServices from '@/services/UserService'
import { Image } from '@/models/Image'


const canShowImages = ref(false)
const error = ref('')
const images = ref<Image[]>([])

async function loadImages() {
  try {
    images.value = await UserServices.getAllImages();
  } catch (error) {
    error.value = "Error cargando imagenes"
  }
}

onMounted(() => {
  const userRole = localStorage.getItem('user_role')

  if (userRole === 'User') {
    canShowImages.value = true
    loadImages();
  } else {
    error.value = 'No autorizado. Solo para user'
  }
})
</script>

<template>
  <div>
    <div v-if="canShowImages">
      <div v-for="image in images" :key="image.url">
        <img :src="image.publicId" 
        alt="Imagen" 
        />
      </div>
    </div>

    <div v-else>
      <div>
        <span>⚠️</span>
        <p>{{ error }}</p>
      </div>
    </div>
  </div>
</template>
