/*Calcular el saldo final después de un depósito: Si mi saldo inicial es 500 y realizo
un deposito de 200, necesito una operación que calcule el saldo final y lo imprima.*/

let saldo = 500;
let deposito = 200;
let saldoFinal = saldo + deposito;
console.log(saldoFinal);
console.log(saldo + deposito);

/*Determinar la diferencia de temperatura: Registré una temperatura máxima de
30.5 y una temperatura mínima de 18.0. Quiero calcular la diferencia de
temperatura entre ambas y mostrarla.*/

let temperaturaMax = 30.5;
let temperaturaMin = 18.0;
let diferencia = temperaturaMax - temperaturaMin;
console.log("La Diferencia es: ", diferencia);

/*Calcular el salario bruto: Un empleado trabajó 40 horas y su tarifa por hora es
25.5. Necesito calcular su salario bruto y mostrarlo.*/

let horasTrabajadas = 40;
let tarifaHora = 25.5;
console.log("$", tarifaHora * horasTrabajadas);

/*Obtener el promedio de ventas por vendedor: Mis ventas totales fueron 120000
y tuve 4 vendedores. Necesito una forma de calcular el promedio de ventas por
vendedor y obtener ese valor.*/

let vendedores = 4;
let ventasTotales = 120_000;
let promedioVentasVendedor = ventasTotales / vendedores;
console.log(promedioVentasVendedor)

/*Saber los minutos restantes de una clase: Una clase tiene una duración total de
75 minutos. Si consideramos que cada bloque completo es de 60 minutos,
¿cuántos minutos sobran al final? Necesito este cálculo impreso.*/

let duracionClase = 75
let bloque = 60
let minutosRestantes = duracionClase - bloque
console.log(minutosRestantes)