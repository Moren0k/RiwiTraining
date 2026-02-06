# Instalación de MySQL en Linux (Ubuntu), Windows y macOS

---

## ✅ Entrar a MySQL desde la terminal  
Inicia la consola de MySQL con el usuario root.

```bash
mysql -u root -p
```

---

## 🐧 Instalación en Ubuntu / Linux

1. **Actualizar repositorios**
```bash
sudo apt update
```

2. **Instalar el servidor MySQL**
```bash
sudo apt install mysql-server
```

3. **Verificar que el servicio esté activo**
```bash
sudo systemctl status mysql
```

4. **Iniciar sesión en MySQL**
```bash
sudo mysql -u root -p
```

---

## 🪟 Instalación en Windows

1. **Descargar el instalador desde el sitio oficial**  
   [https://dev.mysql.com](https://dev.mysql.com)

2. **Ejecutar el instalador y seguir los pasos guiados**
   - Seleccionar "Developer Default".
   - Elegir la versión del servidor MySQL.
   - Configurar el root password durante la instalación.

3. **Abrir la consola de MySQL desde CMD o PowerShell**
```bash
mysql -u root -p
```

---

## 🍏 Instalación en macOS

1. **Instalar Homebrew si no lo tienes**
```bash
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"
```

2. **Instalar MySQL**
```bash
brew install mysql
```

3. **Iniciar el servicio de MySQL**
```bash
brew services start mysql
```

4. **Entrar a MySQL**
```bash
mysql -u root -p
```
