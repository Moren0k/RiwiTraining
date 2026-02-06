//Historia de Usuario 10: Resumen de Cálculo de Impuestos
let ingresoBruto = 50000.00;
let tasaImpuesto = 0.15;
let montoImpuesto = ingresoBruto * tasaImpuesto;
let ingresoNeto = ingresoBruto - montoImpuesto;
let mensaje = console.log(`Para un ingreso bruto de: $${ingresoBruto}
El impuesto es: $${montoImpuesto}
Resultando en un ingreso neto de: $${ingresoNeto}`);

console.log(mensaje);