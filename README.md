# TEST PRÁCTICO PARA DESARROLLADOR FULLSTACK
🧩 Parte 1: Backend (.NET Core + API REST)
Objetivo: Desarrollar una API RESTful en .NET Core que gestione un sistema de órdenes de compra, con énfasis en lógica compleja de negocio y manipulación de colecciones de datos.
🧱 Modelo de Datos
- Cliente: Id, Nombre, Email, FechaRegistro
- Producto: Id, Nombre, Precio, Stock
- Orden: Id, ClienteId, FechaOrden, Total
- DetalleOrden: Id, OrdenId, ProductoId, Cantidad, PrecioUnitario
📌 Requisitos Funcionales
1. Listar todas las órdenes con:
   - Nombre del cliente
   - Total de la orden
   - Número de productos distintos
   - Fecha de la orden

2. Listar los 3 clientes con mayor gasto total en los últimos 6 meses.

3. Listar productos con stock = 0.

4. Crear una nueva orden con múltiples productos.
   - Validar existencia de cliente y productos
   - Validar stock suficiente
   - Actualizar stock de productos
   - Calcular total automáticamente

5. Actualizar precio o stock de un producto.
✅ Validaciones
- Cliente debe existir al crear una orden
- No se puede ordenar productos sin stock
- No se puede registrar una orden sin productos
- Email del cliente debe tener formato válido
- Cantidad de productos debe ser mayor a 0
⚠️ Manejo de Excepciones
- Respuestas claras para errores comunes:
  - 400: Datos inválidos
  - 404: Recurso no encontrado
  - 500: Error interno
🎨 Parte 2: Frontend (Angular + TypeScript)
Objetivo: Crear una SPA que consuma la API anterior.
🖥️ Pantallas
1. Dashboard de Clientes:
   - Tabla con los clientes top (nombre, total gastado)
   - Filtro por fecha

2. Gestión de Órdenes:
   - Crear nueva orden (selección de cliente y productos)
   - Validaciones en tiempo real (stock, campos requeridos)
   - Mostrar resumen de orden antes de enviar

3. Gestión de Productos:
   - Lista de productos con opción de editar stock y precio
   - Filtro por productos agotados
🧰 Requisitos Técnicos
- Servicios Angular para consumir la API
- Buen manejo de estados de carga y errores en la UI
