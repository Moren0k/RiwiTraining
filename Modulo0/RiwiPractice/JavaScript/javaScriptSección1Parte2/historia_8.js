//Historia de Usuario 8: Generación de Etiqueta de Producto
let diseño = {
    marca: "EcoClean",
    producto : "Detergente Ecológico",
    pesoKg : 1.5,
};

let etiqueta = (`[${diseño["marca"]}] ${diseño["producto"]} - ${diseño["pesoKg"]}Kg.`);

console.log(etiqueta);