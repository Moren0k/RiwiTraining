class Calculadora {
    constructor(num1, num2){
        this.num1 = parseInt(num1);
        this.num2 = parseInt(num2);
    }

    sumar(num1, num2){
        return this.num1 + this.num2
    }
    restar(num1, num2){
        return this.num1 - this.num2;
    }
    multiplicar(num1, num2){
        return this.num1 * this.num2;
    }
    dividir(num1, num2){
        return this.num1 / this.num2;
    }
    potencia(num1, num2){
        return this.num1 ** this.num2;
    }
    raizCuadrada(num1){
        return Math.sqrt(this.num1);
    }
    raizCubica(num1){
        return Math.cbrt(this.num1);
    }
}

alert("Bienvenido a la calculadora");
let opction = prompt("Ingrese la operación que desea realizar: \n1. Sumar \n2. Restar \n3. Multiplicar \n4. Dividir \n5. Potencia \n6. Raíz Cuadrada \n7. Raíz Cúbica");
let num1 = prompt("Ingrese el primer número");
let num2 = prompt("Ingrese el segundo número");

let calculadora = new Calculadora(num1, num2);
if (opction == 1) {
    alert(`El resultado de la suma es: ${calculadora.sumar()}`);
}
else if (opction == 2) {
    alert(`El resultado de la resta es: ${calculadora.restar()}`);
}
else if (opction == 3) {
    alert(`El resultado de la multiplicación es: ${calculadora.multiplicar()}`);
}
else if (opction == 4) {
    alert(`El resultado de la división es: ${calculadora.dividir()}`);
}
else if (opction == 5) {
    alert(`El resultado de la potencia es: ${calculadora.potencia()}`);
}
else if (opction == 6) {
    alert(`El resultado de la raíz cuadrada es: ${calculadora.raizCuadrada()}`);
}
else if (opction == 7) {
    alert(`El resultado de la raíz cúbica es: ${calculadora.raizCubica()}`);
}
else {
    alert("Operación no válida");
}