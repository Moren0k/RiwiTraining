//Mostrar datos de la tabla people
fetch('http://localhost:3000/people')
    .then(response => response.json())
    .then(data => {
        const tableBody = document.getElementById('peopleTable');
        let rows = '';
        data.forEach(person => {
            rows += `
                <tr>
                    <td>${person.id}</td>
                    <td>${person.name}</td>
                    <td>${person.lastname}</td>
                    <td>${person.second_lastname}</td>
                    <td>${person.email}</td>
                    <td>${person.phone}</td>
                    <td>${formatDate(person.birth_date)}</td>
                    <td>${person.work_id}</td>
                </tr>
            `;
        });
        tableBody.innerHTML = rows;
    })
    .catch(error => console.error('Error:', error));

//Formatear la fecha
function formatDate(dateString) {
    const date = new Date(dateString);
    return date.toLocaleDateString('es-CO', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit'
    });
}

//Mostrar datos de la tabla works
fetch('http://localhost:3000/works')
    .then(response => response.json())
    .then(data => {
        const tableBody = document.getElementById('worksTable');
        let rows = '';
        data.forEach(work => {
            rows += `
                <tr>
                    <td>${work.id}</td>
                    <td>${work.job_title}</td>
                </tr>
            `;
        });
        tableBody.innerHTML = rows;
    })
    .catch(error => console.error('Error:', error));

//Tabla agregar personas
const showFormBtn = document.getElementById('showFormBtn');
    // Mostrar/Ocultar formulario
    showFormBtn.addEventListener('click', () => {
        personForm.style.display = personForm.style.display === 'none' ? 'block' : 'none';
    });
    // Enviar datos al backend
        personForm.addEventListener('submit', async (e) => {
            e.preventDefault();

            const formData = Object.fromEntries(new FormData(personForm).entries());

            const res = await fetch('http://localhost:3000/people', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(formData)
            });

            const data = await res.json();
            alert(data.message);
            personForm.reset();
            personForm.style.display = 'none';
        });