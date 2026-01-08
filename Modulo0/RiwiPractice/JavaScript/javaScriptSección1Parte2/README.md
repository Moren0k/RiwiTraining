# Ejercicio de practica JavaScript sección 1 parte 2

## Parte 1: Declaración y Asignación con Lógica Implícita

### Historia de Usuario 1: Perfil de Usuario Dinámico

Como administrador del sistema, necesito gestionar la información de un usuario para que pueda ver su perfil completo y su estatus de miembro premium basado en su capacidad económica.

    • Detalles:
        - Debe haber una variable para el nombreUsuario (ej. "Carlos Gómez").
        - Una variable para la edadUsuario (ej. 32).
        - Una variable para el saldoCuenta (ej. 1500.75).
        - Quiero una variable booleana usuarioPremium que se establezca en True si el saldoCuenta es superior a 1000, de lo contrario False. (¡Piensa cómo
        puedes asignar directamente el resultado de la comparación!).
        - Finalmente, necesito ver en la consola el nombre, edad, saldo y el estado
        de usuarioPremium, incluyendo el tipo de dato de esta última variable para
        confirmar su correcta asignación.

### Historia de Usuario 2: Cálculo de Pedido con Descuento y Clasificación

Como gestor de ventas, necesito calcular el costo final de un pedido y clasificarlo como "grande" para tomar decisiones sobre logística y descuentos adicionales.

    • Detalles:
        - Se definirá la cantidadArticulos (ej. 7) y el precioBaseArticulo (ej. 25.50).
        - Se aplicará un descuentoAplicado del 0.10 (10%).
        - Necesito calcular el subtotal (cantidad * precio base).
        - Luego, calcular el montoDescuento aplicado.
        - Obtener el totalPagar final.
        - Además, quiero una variable booleana pedidoGrande que sea True si la
        cantidadArticulos es 5 o más, de lo contrario False.
        - Finalmente, debo imprimir el totalPagar y el valor de pedidoGrande en la
        consola.

## Parte 2: Manipulación Avanzada de Cadenas y Datos Numéricos

### Historia de Usuario 3: Detalles de Nomenclatura de Producto

Como ingeniero de catalogación, necesito extraer información clave del nombre de un
producto para su correcta indexación y búsqueda.

    • Detalles:
        - Dada la variable nombreProducto = "Smartphone XYZ 128GB".
        - Quiero obtener la longitudNombre (cuántos caracteres tiene).
        - Necesito el primerCaracter del nombre.
        - También el ultimoCaracter del nombre.
        - Todos estos datos deben ser impresos en la consola para su verificación.

### Historia de Usuario 4: Decodificación de Código de Identificación

Como especialista en logística, necesito descomponer un código de seguimiento complejo para identificar sus partes componentes.

    • Detalles:
        - Tengo un codigoOriginal = "ABC-123-DEF-456".
        - Debo extraer las primeras tres letras y guardarlas como parte1.
        - Luego, los tres números después del primer guion (123) como parte2.
        - Finalmente, las tres letras después del segundo guion (DEF) como parte3.
        - Quiero ver parte1, parte2 y parte3 impresas en la consola.

### Historia de Usuario 5: Evaluación de Desempeño Académico

Como tutor, necesito calcular el promedio de las calificaciones de un estudiante y
determinar rápidamente si aprobó el curso.

    • Detalles:
        - Se me proporcionan tres notas: nota1 = 4.5, nota2 = 3.8, nota3 = 5.0.
        - Debo calcular la promedioFinal del estudiante.
        - Quiero una variable booleana aproboCurso que sea True si el
        promedioFinal es 3.0 o mayor, de lo contrario False.
        - El promedioFinal y el estado de aproboCurso deben ser impresos en la
        consola.

## Parte 3: Combinación de Operaciones y Concatenación Compleja

### Historia de Usuario 6: Reporte Detallado de Inventario

Como gerente de almacén, necesito un reporte consolidado del valor de los ítems en
inventario para una rápida auditoría.

    • Detalles:
        - Tengo nombreItem = "Laptop Gamer", cantidadStock = 3, y
        precioUnitarioItem = 1200.00.
        - Debo calcular el valorTotalInventario para este ítem.
        - Necesito que se genere una cadenaReporte con el formato exacto: "Ítem:
        Laptop Gamer. Stock: 3 unidades. Valor total: $3600.00." (Asegúrate de que
        el valor total siempre muestre dos decimales, si es posible con tus
        herramientas actuales, si no, aproxímate lo mejor que puedas).
        - La cadenaReporte debe ser impresa.
  
### Historia de Usuario 7: Monitoreo de Estado de Servidor

Como operador de sistemas, necesito una visualización clara del estado de los
servidores para identificar problemas rápidamente.

    • Detalles:
        - Se me proporciona el servidor = "Web_Server_01", su status = "Activo", y el
        pingMs = 24 (tiempo de respuesta en milisegundos).
        - Debo construir una mensajeEstado que diga: "El servidor Web_Server_01
        está Activo con una latencia de 25ms."
        - El mensajeEstado debe ser impreso en la consola.

### Historia de Usuario 8: Generación de Etiqueta de Producto

Como diseñador de empaques, necesito generar etiquetas de producto estandarizadas
que incluyan la marca, el nombre del producto y su peso.

    • Detalles:
        - Tengo la marca = "EcoClean", el producto = "Detergente Ecológico", y el
        pesoKg = 1.5.
        - Debo crear una etiqueta que siga el formato: "[EcoClean] Detergente
        Ecológico - 1.5 Kg".
        - Esta etiqueta debe ser impresa para su revisión.

### Historia de Usuario 9: Temporizador de Cuenta Regresiva

Como usuario de una aplicación, necesito ver el tiempo restante en un formato
comprensible de horas, minutos y segundos.

    • Detalles:
        - Tengo un total de segundosTotales = 3670.
        - Necesito calcular cuántas horas completas hay.
        - Cuántos minutos quedan después de las horas.
        - Y cuántos segundos sobran al final.
        - Luego, construir un mensaje en el formato "1 hora, 1 minuto, 10 segundos
        restantes." (Ajustando los números según el cálculo).
        - Este mensaje debe ser impreso en la consola.

### Historia de Usuario 10: Resumen de Cálculo de Impuestos

Como contribuyente, necesito un resumen claro de cuánto impuesto pagaré y cuál será
mi ingreso neto.

    • Detalles:
        - Mi ingresoBruto es 50000.00.
        - La tasaImpuesto es 0.15 (15%).
        - Debo calcular el montoImpuesto.
        - Luego, calcular el ingresoNeto.
        - Finalmente, necesito un mensaje que diga: "Para un ingreso bruto de
        $50000.00, el impuesto es $7500.00, resultando en un ingreso neto de
        $42500.00."
        - Este mensaje debe ser impreso para mi registro.
