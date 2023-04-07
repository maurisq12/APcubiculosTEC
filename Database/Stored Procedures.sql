USE CubiculosTEC


-- ESTUDIANTES

DROP PROCEDURE IF EXISTS dbo.agregarEstudiante

CREATE PROCEDURE agregarEstudiante @correo varchar(50), @contrasena varchar(50), @cedula int, @carne int,
@nombre varchar(50), @apellido1 varchar(50), @apellido2 varchar(50), @fechaDeNacimiento date
AS
INSERT INTO dbo.Estudiantes (correo, contrasena, cedula, carne, nombre, apellido1, apellido2, edad, fechaDeNacimiento, idEstadoEstudiante)
VALUES (@correo, @contrasena, @cedula, @carne, @nombre, @apellido1, @apellido2, DATEDIFF(year , @fechaDeNacimiento, GETDATE()),
@fechaDeNacimiento, 1)



DROP PROCEDURE IF EXISTS dbo.leerEstudiante

CREATE PROCEDURE leerEstudiante @idEstudiante int
AS
SELECT idEstudiante, correo, contrasena, cedula, carne, nombre, apellido1, apellido2, edad, fechaDeNacimiento, idEstadoEstudiante
FROM dbo.Estudiantes
WHERE idEstudiante = @idEstudiante



DROP PROCEDURE IF EXISTS dbo.modificarEstudiante

CREATE PROCEDURE modificarEstudiante @correo varchar(50), @contrasena varchar(50), @cedula int, @carne int,
@nombre varchar(50), @apellido1 varchar(50), @apellido2 varchar(50), @fechaDeNacimiento date, @estado smallint
AS
UPDATE dbo.Estudiantes SET
contrasena = @contrasena, cedula = @cedula, carne = @carne, nombre = @nombre, apellido1 = @apellido1, apellido2 = @apellido2,
edad = DATEDIFF(year , @fechaDeNacimiento, GETDATE()), fechaDeNacimiento = @fechaDeNacimiento,
idEstadoEstudiante = @estado 
WHERE
correo = @correo



DROP PROCEDURE IF EXISTS dbo.eliminarEstudiante

CREATE PROCEDURE eliminarEstudiante @idEstudiante int
AS
DELETE FROM dbo.Estudiantes
WHERE idEstudiante = @idEstudiante




-- CUBICULOS

DROP PROCEDURE IF EXISTS dbo.crearCubiculo

CREATE PROCEDURE crearCubiculo @nombre varchar(50), @capacidad int
AS
INSERT INTO dbo.Cubiculos (nombre, idEstado, capacidad)
VALUES (@nombre, 1, @capacidad)



DROP PROCEDURE IF EXISTS dbo.leerCubiculo

CREATE PROCEDURE leerCubiculo @idCubiculo int
AS
SELECT idCubiculo, nombre, idEstado, capacidad, tiempoMaximo
FROM dbo.Cubiculos
WHERE idCubiculo = @idCubiculo



DROP PROCEDURE IF EXISTS dbo.modificarCubiculo

CREATE PROCEDURE modificarCubiculo @idCubiculo int, @nombre varchar(50),
@idEstado smallint, @capacidad int, @tiempoMaximo time(0)
AS
UPDATE dbo.Cubiculos SET
nombre = @nombre, idEstado = @idEstado, capacidad = @capacidad, tiempoMaximo = @tiempoMaximo
WHERE
idCubiculo = @idCubiculo

DROP PROCEDURE IF EXISTS dbo.definirHoraMaxima

CREATE PROCEDURE definirHoraMaxima @idCubiculo INT, @tiempoMaximo time(0)
AS UPDATE dbo.Cubiculo SET
tiempoMaximo = @tiempoMaximo
WHERE
idCubiculo = @idCubiculo




DROP PROCEDURE IF EXISTS dbo.eliminarCubiculo

CREATE PROCEDURE eliminarCubiculo @idCubiculo int
AS
DELETE FROM dbo.Cubiculos
WHERE idCubiculo = @idCubiculo



-- filtrar cubiculos por fecha, hora de inicio y hora final
DROP PROCEDURE IF EXISTS dbo.filtrarCubiculosFecha

CREATE PROCEDURE filtrarCubiculosFecha @fecha date, @horaInicio time(0), @horaFinal time(0)
AS
SELECT Cubiculos.idCubiculo, nombre, idEstado, capacidad, tiempoMaximo
FROM dbo.Cubiculos
WHERE Cubiculos.idEstado = 1
EXCEPT
SELECT Cubiculos.idCubiculo, nombre, idEstado, capacidad, tiempoMaximo
FROM dbo.Cubiculos
INNER JOIN dbo.Reservaciones
ON Reservaciones.idCubiculo = Cubiculos.idCubiculo
WHERE Reservaciones.fechaDeUso = @fecha AND @horaFinal > Reservaciones.horaInicio AND @horaInicio < Reservaciones.horaFinal




-- RESERVACIONES

DROP PROCEDURE IF EXISTS dbo.agregarReservacion

CREATE PROCEDURE agregarReservacion @idCubiculo int, @idEstudiante int, @fechaDeUso date, @horaInicio time(0),
@horaFinal time(0), @fechaDeReservacion date
AS
INSERT INTO dbo.Reservaciones (idCubiculo, idEstudiante, fechaDeUso, horaInicio, horaFinal, confirmacion, fechaDeReservacion)
VALUES (@idCubiculo, @idEstudiante, @fechaDeUso, @horaInicio, @horaFinal, 0, @fechaDeReservacion)



DROP PROCEDURE IF EXISTS dbo.leerReservacion

CREATE PROCEDURE leerReservacion @idReservacion int
AS
SELECT idReservacion, idCubiculo, idEstudiante, fechaDeUso, horaInicio, horaFinal, confirmacion, fechaDeReservacion
FROM dbo.Reservaciones
WHERE idReservacion = @idReservacion



DROP PROCEDURE IF EXISTS dbo.modificarReservacion

CREATE PROCEDURE modificarReservacion @idReserva INT, @idCubiculo int, @idEstudiante int, @fechaDeUso date, @horaInicio time(0),
@horaFinal time(0),@fechaDeReserva date, @confirmacion bit
AS
UPDATE dbo.Reservaciones SET
idEstudiante=@idEstudiante, fechaDeUso = @fechaDeUso, horaInicio = @horaInicio, horaFinal = @horaFinal,
confirmacion = @confirmacion, fechaDeReservacion = @fechaDeReserva
WHERE
idReservacion = @idReserva



DROP PROCEDURE IF EXISTS dbo.eliminarReservacion

CREATE PROCEDURE eliminarReservacion @idReservacion int
AS
DELETE FROM dbo.Reservaciones
WHERE
idReservacion = @idReservacion



DROP PROCEDURE IF EXISTS dbo.confirmarCubiculo

CREATE PROCEDURE confirmarCubiculo @idReservacion int
AS
UPDATE dbo.Reservaciones SET
confirmacion = 1
WHERE
idReservacion = @idReservacion 




-- bloquear cubiculos (admin)
DROP PROCEDURE IF EXISTS dbo.bloquearCubiculo

CREATE PROCEDURE bloquearCubiculo @idCubiculo int, @fechaDeUso date, @horaInicio time(0), @horaFinal time(0),
@fechaDeReservacion date
AS
EXEC dbo.agregarReservacion @idCubiculo = @idCubiculo, @idEstudiante = 1, @fechaDeUso = @fechaDeUso, @horaInicio = @horaInicio,
@horaFinal = @horaFinal, @fechaDeReservacion = @fechaDeReservacion
