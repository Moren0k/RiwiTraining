/* Employees */
const tableEmployees = document.getElementById('tableEmployees');
const btnUploadCsvEmployees = document.getElementById('btnUploadCsvEmployees');
const btnDelEmployees = document.getElementById('btnDelEmployees');

btnUploadCsvEmployees.addEventListener('click', ()=>{
    uploadEmployeCsv();
});

btnDelEmployees.addEventListener('click', ()=>{
    delEmployees();
})

//Function que borra todos lo datos de la tabla Employees
function delEmployees(){
    fetch('http://localhost:3000/delEmployees', {
        method: 'DELETE',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => res.json())
    .then(showEmployees);
}

// Function que sube los datos Cvs Employees
function uploadEmployeCsv(){
    fetch('http://localhost:3000/uploadCsvEmployees', {
        method: 'POST',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => res.json())
    .then(showEmployees);
};

//function encargada de traer mis empleados y mostrarlos en la tabla
function showEmployees(){
    fetch('http://localhost:3000/getEmployees')
    .then(res => res.json())
    .then(data =>{
        tableEmployees.innerHTML = '';
        data.forEach(employe =>{
            tableEmployees.innerHTML += `
            <tr>
                <td>${employe.id}</td>
                <td>${employe.name}</td>
                <td>${employe.lastname}</td>
                <td>${employe.second_lastname}</td>
                <td>${employe.email}</td>
                <td>${employe.charge}</td>
                <td>${employe.city}</td>
                <td>${employe.salary}</td>
                <td>${employe.age}</td>
            </tr>
            `;
        });
    });
};

/* Projects */
const tableProjects = document.getElementById('tableProjects');
const btnUploadCsvProjects = document.getElementById('btnUploadCsvProjects');
const btnDelProjects = document.getElementById('btnDelProjects');

btnUploadCsvProjects.addEventListener('click', ()=>{
    uploadProjectsCsv();
});

btnDelProjects.addEventListener('click', ()=>{
    delProjects();
})

// Function que elimina todos los datos de la tabla Projects
function delProjects(){
    fetch('http://localhost:3000/delProjects', {
    method: 'DELETE',
    headers: {'Content-Type':'application/json'}
    })
    .then(res => res.json())
    .then(showProjects);
}

// Function que sube los datos Cvs Projects
function uploadProjectsCsv(){
    fetch('http://localhost:3000/uploadCsvProjects', {
        method: 'POST',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => res.json())
    .then(showProjects);
};

//function encargada de traer mis empleados y mostrarlos en la tabla
function showProjects(){
    fetch('http://localhost:3000/getProjects')
    .then(res => res.json())
    .then(data =>{
        tableProjects.innerHTML = '';
        data.forEach(project =>{
            tableProjects.innerHTML += `
            <tr>
                <td>${project.id}</td>
                <td>${project.name}</td>
                <td>${project.description}</td>
                <td>${project.start_date}</td>
                <td>${project.end_date}</td>
                <td>${project.status}</td>
            </tr>
            `;
        });
    });
};

showEmployees();
showProjects();