//Historia de Usuario 4: Decodificación de Código de Identificación
let codigoOriginal = "ABC-123-DEF-456-";
let parte1 = codigoOriginal.substring(0,3);
let parte2 = codigoOriginal.substring(4,7);
let parte3 = codigoOriginal.substring(8,11);
let parte4 = codigoOriginal.substring(12,15);

console.log(parte1, parte2, parte3, parte4);