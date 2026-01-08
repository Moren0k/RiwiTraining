// URL de la API donde están las personas guardadas
// Aquí se conecta con el servidor local en el puerto 3000
const API_URL = "http://localhost:3000/people";

// Cuando la página termine de cargar, se llama a la función para mostrar las personas en la tabla
document.addEventListener("DOMContentLoaded", loadPeople);

// Esta función carga los datos de las personas desde la API y los pone en la tabla HTML
function loadPeople() {
    // Se hace una solicitud (fetch) al servidor para traer los datos
    fetch(API_URL)
        .then(res => res.json()) // Se convierte la respuesta del servidor en formato JSON (datos que podemos usar)
        .then(data => {
            // Seleccionamos el cuerpo de la tabla donde pondremos las personas
            const tableBody = document.getElementById("peopleTable");

            // Limpiamos el contenido de la tabla por si ya había personas antes
            tableBody.innerHTML = "";

            // Recorremos cada persona recibida del servidor
            data.forEach(person => {
                // Agregamos una nueva fila (tr) con los datos de cada persona
                tableBody.innerHTML += `
                    <tr>
                        <td>${person.name}</td>           <!-- Nombre -->
                        <td>${person.lastname}</td>       <!-- Primer apellido -->
                        <td>${person.lastname2 || ""}</td> <!-- Segundo apellido (si no tiene, se deja vacío) -->
                        <td>${person.age}</td>            <!-- Edad -->
                        <td>${person.id}</td>             <!-- ID -->
                        <td>${person.email}</td>          <!-- Correo electrónico -->
                        <td>${person.country || ""}</td>   <!-- País (si no tiene, se deja vacío) -->
                    </tr>
                `;
            });
        })
        // Si hay un error al obtener los datos, se muestra en la consola
        .catch(err => console.error(err));
}

// Esta parte escucha cuando se envía el formulario (cuando haces clic en "Guardar" o "Agregar persona")
document.getElementById("personForm").addEventListener("submit", function(e) {
    // Esto evita que la página se recargue al enviar el formulario
    e.preventDefault();

    // Creamos un objeto con los datos que el usuario escribió en el formulario
    const formData = new FormData(this); // formData contiene todos los campos del formulario
    const data = Object.fromEntries(formData.entries()); // Convertimos a un objeto más fácil de manejar

    // Enviamos los datos al servidor con una solicitud POST para agregar la nueva persona
    fetch(API_URL, {
        method: "POST", // Tipo de solicitud: POST (para crear)
        headers: {
            "Content-Type": "application/json" // Indicamos que los datos se enviarán como JSON
        },
        body: JSON.stringify(data) // Convertimos el objeto de datos en texto JSON
    })
    .then(res => res.json()) // Convertimos la respuesta en JSON
    .then(() => {
        // Si todo salió bien...

        // Cerramos el modal (ventana emergente del formulario)
        const modal = bootstrap.Modal.getInstance(document.getElementById("addPersonModal"));
        modal.hide();

        // Limpiamos el formulario para que quede vacío
        this.reset();

        // Volvemos a cargar la tabla para que aparezca la nueva persona
        loadPeople();
    })
    // Si hay un error al enviar los datos, lo mostramos en la consola
    .catch(err => console.error(err));
});
