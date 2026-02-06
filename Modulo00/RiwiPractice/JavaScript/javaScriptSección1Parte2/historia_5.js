//Historia de Usuario 5: Evaluación de Desempeño Académico
let = nota1 = 4.5;
let = nota2 = 3.8;
let = nota3 = 5.0;
let aproboCurso = false;
let sumarNotas = nota1 + nota2 + nota3;
let promedio = sumarNotas / 3;

if (promedio > 3) {
    aproboCurso = true;
};

console.log(`El promedio es: ${promedio}, Estado de aprobación: ${aproboCurso}`);