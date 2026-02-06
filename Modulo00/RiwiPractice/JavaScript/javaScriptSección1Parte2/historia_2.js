//Historia de Usuario 2: Cálculo de Pedido con Descuento y Clasificación
let cantidadArticulos = 7;
let precioBaseArticulo = 25.500;
let descuentoAplicado = 0.10;
let subTotal = cantidadArticulos * precioBaseArticulo;
let decuento = subTotal * descuentoAplicado;
let totalPagar = subTotal - decuento;
let pedidoGrande = false;

if (cantidadArticulos > 5) {
    pedidoGrande = true;
};

console.log(`TOTAL: ${totalPagar}\nTIPO DE PEDIDO: ${pedidoGrande}`);