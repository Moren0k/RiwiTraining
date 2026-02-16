<template>
  <div class="toast-container">
    <TransitionGroup name="toast">
      <div 
        v-for="toast in toastStore.toasts" 
        :key="toast.id" 
        class="toast-item"
        :class="`is-${toast.type}`"
        @click="toastStore.remove(toast.id)"
      >
        <span class="toast-icon">
          <i v-if="toast.type === 'success'">✓</i>
          <i v-else-if="toast.type === 'error'">✕</i>
          <i v-else-if="toast.type === 'warning'">!</i>
          <i v-else>i</i>
        </span>
        <p class="toast-message">{{ toast.message }}</p>
      </div>
    </TransitionGroup>
  </div>
</template>

<script setup lang="ts">
import { useToastStore } from '@/stores/toast';
const toastStore = useToastStore();
</script>

<style scoped>
.toast-container {
  position: fixed;
  top: var(--space-6);
  right: var(--space-6);
  z-index: 9999;
  display: flex;
  flex-direction: column;
  gap: var(--space-3);
  pointer-events: none;
}

.toast-item {
  pointer-events: auto;
  min-width: 280px;
  max-width: 400px;
  padding: var(--space-3) var(--space-4);
  border-radius: var(--radius-2);
  background: var(--color-surface-2);
  border: 1px solid var(--color-border);
  box-shadow: var(--shadow-2);
  display: flex;
  align-items: center;
  gap: var(--space-3);
  cursor: pointer;
  
  /* Glassmorphism effect */
  backdrop-filter: blur(10px);
}

.toast-item.is-success {
  border-left: 4px solid var(--color-success);
  box-shadow: 0 4px 15px rgba(22, 163, 74, 0.2);
}

.toast-item.is-error {
  border-left: 4px solid var(--color-danger);
  box-shadow: 0 4px 15px rgba(255, 59, 107, 0.2);
}

.toast-item.is-warning {
  border-left: 4px solid var(--color-warning);
  box-shadow: 0 4px 15px rgba(245, 158, 11, 0.2);
}

.toast-item.is-info {
  border-left: 4px solid var(--color-primary);
  box-shadow: 0 4px 15px rgba(177, 0, 255, 0.2);
}

.toast-icon {
  width: 24px;
  height: 24px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-weight: 900;
  border-radius: 50%;
  font-style: normal;
}

.is-success .toast-icon { color: var(--color-success); background: rgba(22, 163, 74, 0.1); }
.is-error .toast-icon { color: var(--color-danger); background: rgba(255, 59, 107, 0.1); }
.is-warning .toast-icon { color: var(--color-warning); background: rgba(245, 158, 11, 0.1); }
.is-info .toast-icon { color: var(--color-primary); background: rgba(177, 0, 255, 0.1); }

.toast-message {
  margin: 0;
  font-size: 14px;
  font-weight: 600;
  color: var(--color-text);
  line-height: 1.4;
}

/* Transitions */
.toast-enter-active,
.toast-leave-active {
  transition: all 0.4s cubic-bezier(0.175, 0.885, 0.32, 1.275);
}

.toast-enter-from {
  opacity: 0;
  transform: translateX(50px) scale(0.9);
}

.toast-leave-to {
  opacity: 0;
  transform: translateX(20px) scale(1);
}
</style>
