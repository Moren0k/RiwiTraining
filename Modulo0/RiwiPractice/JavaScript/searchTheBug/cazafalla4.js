
let contador = 0;
while (contador < 5) {
  console.log("El contador es: " + contador);
 
}


for (let i = 5; i < 0; i++) { 
}


let j = 5;
do {
  console.log("Valor de j: " + j);
  j--;
} while (j > 5); /

const numeros = [1, 2, 3, 4, 5];

for (let numero in numeros) {
  console.log("Número (usando for...in): " + numero); // Esto mostrará los índices, no los valores.
}