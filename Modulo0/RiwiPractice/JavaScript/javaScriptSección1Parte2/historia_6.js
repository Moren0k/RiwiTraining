//Historia de Usuario 6: Reporte Detallado de Inventario
let nombreItem = "Laptop Gamer";
let cantidadStock = 3;
let precioUnitarioItem = 1200.00;
let valorTotalInventario = precioUnitarioItem * cantidadStock;
let cadenaReporte = `${nombreItem} Stock: ${cantidadStock} Valor total: ${valorTotalInventario}`;

console.log(cadenaReporte);
