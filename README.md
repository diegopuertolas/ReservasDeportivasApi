# Prueba práctica de API REST — Versión A: Reservas deportivas

**Duración:** 3 horas (16:00–19:00)  
**Puntuación máxima:** 10 puntos

Desarrolla una API REST con ASP.NET Core y **controladores** para gestionar reservas de instalaciones deportivas. Los datos se almacenarán únicamente en memoria.

## Ejercicios

### 1. Proyecto y control de versiones (1 punto)

Crea un proyecto ASP.NET Core Web API con controladores e inicializa un repositorio Git con un archivo `.gitignore` adecuado para .NET. Desarrolla cada ejercicio de implementación en una rama independiente, utilizando nombres descriptivos con el prefijo `feature/`. Realiza al menos un commit por rama y fusiona cada rama con `main` antes de comenzar el siguiente ejercicio. Conserva las ramas y el historial.

### 2. Modelo de datos (0,5 puntos)

Crea una clase `Reserva` con las propiedades:

- `Id` (`int`)
- `NombreCliente` (`string`)
- `Instalacion` (`string`)
- `Fecha` (`DateTime`)
- `DuracionHoras` (`int`)
- `Estado` (`EstadoReserva`)
- `RequiereMaterial` (`bool`)

Define el enumerado `EstadoReserva` con los valores `Pendiente` y `Confirmada`.

### 3. Almacenamiento en memoria (0,5 puntos)

Crea un controlador con una colección **estática** `List<Reserva>` inicializada con al menos tres reservas diferentes. Incluye valores `true` y `false` para `RequiereMaterial` en los datos iniciales. Los cambios deben mantenerse entre peticiones mientras la aplicación esté en ejecución.

### 4. Consulta de reservas (1,25 puntos)

- `GET /api/reservas`: devuelve todas las reservas (`200 OK`).
- `GET /api/reservas/{id}`: devuelve la reserva solicitada (`200 OK`) o `404 Not Found` si no existe.

### 5. Creación de reservas (1,25 puntos)

Implementa `POST /api/reservas`. Genera automáticamente el identificador y establece siempre el estado inicial `Pendiente`, aunque se reciban otros valores en la petición. Devuelve `201 Created` mediante `CreatedAtAction`.

### 6. Modificación y eliminación (2 puntos)

- `PUT /api/reservas/{id}`: modifica `NombreCliente`, `Instalacion`, `Fecha`, `DuracionHoras` y `RequiereMaterial`, pero **no** `Id` ni `Estado`.
- `DELETE /api/reservas/{id}`: elimina la reserva indicada.

Devuelve `204 No Content` si la operación se realiza correctamente o `404 Not Found` si el identificador no existe.

### 7. Confirmación de reservas (1 punto)

Implementa `PUT /api/reservas/{id}/confirmar` para pasar una reserva de `Pendiente` a `Confirmada`:

- Si no existe, devuelve `404 Not Found`.
- Si ya está confirmada, devuelve `409 Conflict`.
- Si se confirma correctamente, devuelve `204 No Content`.

### 8. Consultas con LINQ (1,5 puntos)

- `GET /api/reservas/recientes`: devuelve las reservas ordenadas por `Fecha` de mayor a menor mediante LINQ. Acepta el parámetro opcional `[FromQuery] int cantidad = 5` para limitar el número de resultados. Si `cantidad` es menor o igual que cero, devuelve `400 Bad Request`.
- `GET /api/reservas/buscar`: recibe el parámetro `[FromQuery] string cliente` y devuelve las reservas cuyo `NombreCliente` contenga ese texto, **sin distinguir mayúsculas y minúsculas**. Si no hay coincidencias, devuelve una lista vacía.

### 9. Validaciones (0,5 puntos)

En `POST` y `PUT`, comprueba que `NombreCliente` e `Instalacion` no estén vacíos y que `DuracionHoras` sea mayor que cero. Devuelve `400 Bad Request` si alguna condición no se cumple.

### 10. Pruebas de funcionamiento (0,5 puntos)

Comprueba la API con Postman o Swagger y aporta capturas de **al menos seis peticiones**: una consulta, una creación, una modificación, una eliminación y dos peticiones que produzcan errores. Deben verse la petición, el código HTTP y, cuando corresponda, los datos devueltos.

## Indicaciones

- Puedes utilizar .NET 8 o .NET 10.
- Utiliza controladores; no se admiten Minimal API.
- Se permite consultar apuntes, ejercicios anteriores y documentación; no se permite utilizar inteligencia artificial ni comunicarse con compañeros.
- No se requieren DTO, servicios, repositorios, bases de datos ni Entity Framework.
- Realiza los commits y merges progresivamente. Si un ejercicio queda incompleto, puedes integrar sus avances y continuar.

## Entrega

Entrega en Classroom **un único archivo ZIP** que contenga:

- El proyecto completo, incluyendo la carpeta `.git` y el archivo `.gitignore`, pero sin las carpetas `bin` ni `obj`. Los cambios desarrollados deberán estar integrados en `main`.
- Una carpeta `evidencias` con las **capturas obligatorias** de las pruebas solicitadas en el ejercicio 10. Puedes organizarlas en el formato que consideres adecuado (imágenes, Word o PDF).
- Opcionalmente, observaciones, incidencias o documentación complementaria, por ejemplo en un archivo `README.md` u otro `.md`.

La documentación complementaria es opcional y **no sustituye las capturas obligatorias** de las pruebas.