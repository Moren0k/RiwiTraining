const API_URL = "http://localhost:3000/people";
const table = document.getElementById('tabla-people');
const button  = document.getElementById('buttoncsv');

//Function encargada de traer la people
function cargarPeople(){
    fetch(API_URL)
    .then(res => res.json())
    .then(data =>{
        table.innerHTML = '';
        data.forEach(rec => {
            table.innerHTML += `
                <tr>
                    <td>${rec.name}</td>
                    <td>${rec.lastname}</td>
                    <td>${rec.lastname2}</td>
                    <td>${rec.age}</td>
                    <td>${rec.id}</td>
                    <td>${rec.email}</td>
                    <td>${rec.country}</td>
                </tr>
            `;
        });
    });
};

button.addEventListener('click', ()=>{
    uploadData();
});

function uploadData(){
    fetch('http://localhost:3000/uploadCSV',{
    method: 'POST',
    headers: {'Content-Type':'application/json'}
    })
    .then(res => res.json());
}

document.addEventListener('DOMContentLoaded', cargarPeople);