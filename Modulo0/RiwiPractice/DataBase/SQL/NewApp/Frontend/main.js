const tablePeople = document.getElementById('tablePeople');
const subirCSV = document.getElementById('subirCSV');


subirCSV.addEventListener('click', ()=>{
    uploadData();
});


function cargarEmpleados(){ //Función encargada de cargar los empleados
    fetch('http://localhost:3000/getEmpleados')
    .then(res => res.json())
    .then(data => {
        tablePeople.innerHTML = '';
        data.forEach(rec => {
            tablePeople.innerHTML += `
            <tr>
                <td>${rec.idEmployee}</td>
                <td>${rec.name}</td>
                <td>${rec.lastname}</td>
                <td>${rec.second_lastname}</td>
                <td>${rec.email}</td>
                <td>${rec.charge}</td>
                <td>${rec.city}</td>
                <td>${rec.salary}</td>
                <td>${rec.age}</td>
            </tr>
            `;
        });
    });
};

function uploadData(){ //Función encargada de subir el archivo CSV
    fetch('http://localhost:3000/uploadCSV', {
        method: 'POST',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => res.json())
    .then(data => {
        console.log(data);
        cargarEmpleados();
    });
};

cargarEmpleados();