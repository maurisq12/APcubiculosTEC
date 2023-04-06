USE CubiculosTEC
GO

-- ESTUDIANTES

DROP PROCEDURE IF EXISTS dbo.agregarEstudiante
GO
CREATE PROCEDURE agregarEstudiante @correo varchar(50), @contrasena varchar(50), @cedula int, @carne int,
@nombre varchar(50), @apellido1 varchar(50), @apellido2 varchar(50), @fechaDeNacimiento date
AS
INSERT INTO dbo.Estudiantes (correo, contrasena, cedula, carne, nombre, apellido1, apellido2, edad, fechaDeNacimiento, idEstadoEstudiante)
VALUES (@correo, @contrasena, @cedula, @carne, @nombre, @apellido1, @apellido2, DATEDIFF(year , @fechaDeNacimiento, GETDATE()),
@fechaDeNacimiento, 1)
GO


DROP PROCEDURE IF EXISTS dbo.leerEstudiante
GO
CREATE PROCEDURE leerEstudiante @idEstudiante int
AS
SELECT idEstudiante, correo, contrasena, cedula, carne, nombre, apellido1, apellido2, edad, fechaDeNacimiento, idEstadoEstudiante
FROM dbo.Estudiantes
WHERE idEstudiante = @idEstudiante
GO


DROP PROCEDURE IF EXISTS dbo.modificarEstudiante
GO
CREATE PROCEDURE modificarEstudiante @correo varchar(50), @contrasena varchar(50), @cedula int, @carne int,
@nombre varchar(50), @apellido1 varchar(50), @apellido2 varchar(50), @fechaDeNacimiento date, @estado smallint
AS
UPDATE dbo.Estudiantes SET
contrasena = @contrasena, cedula = @cedula, carne = @carne, nombre = @nombre, apellido1 = @apellido1, apellido2 = @apellido2,
edad = DATEDIFF(year , @fechaDeNacimiento, GETDATE()), fechaDeNacimiento = @fechaDeNacimiento,
idEstadoEstudiante = @estado 
WHERE
correo = @correo
GO


DROP PROCEDURE IF EXISTS dbo.eliminarEstudiante
GO
CREATE PROCEDURE eliminarEstudiante @idEstudiante int
AS
DELETE FROM dbo.Estudiantes
WHERE idEstudiante = @idEstudiante
GO



-- CUBICULOS

DROP PROCEDURE IF EXISTS dbo.crearCubiculo
GO
CREATE PROCEDURE crearCubiculo @nombre varchar(50), @capacidad int
AS
INSERT INTO dbo.Cubiculos (nombre, idEstado, capacidad)
VALUES (@nombre, 1, @capacidad)
GO


DROP PROCEDURE IF EXISTS dbo.leerCubiculo
GO
CREATE PROCEDURE leerCubiculo @idCubiculo int
AS
SELECT idCubiculo, nombre, idEstado, capacidad, tiempoMaximo
FROM dbo.Cubiculos
WHERE idCubiculo = @idCubiculo
GO


DROP PROCEDURE IF EXISTS dbo.modificarCubiculo
GO
CREATE PROCEDURE modificarCubiculo @idCubiculo int, @nombre varchar(50),
@idEstado smallint, @capacidad int, @tiempoMaximo time(0)
AS
UPDATE dbo.Cubiculos SET
nombre = @nombre, idEstado = @idEstado, capacidad = @capacidad, tiempoMaximo = @tiempoMaximo
WHERE
idCubiculo = @idCubiculo
GO


DROP PROCEDURE IF EXISTS dbo.eliminarCubiculo
GO
CREATE PROCEDURE eliminarCubiculo @idCubiculo int
AS
DELETE FROM dbo.Cubiculos
WHERE idCubiculo = @idCubiculo
GO


-- filtrar cubiculos por fecha, hora de inicio y hora final
DROP PROCEDURE IF EXISTS dbo.filtrarCubiculosFecha
GO
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
GO



-- RESERVACIONES

DROP PROCEDURE IF EXISTS dbo.agregarReservacion
GO
CREATE PROCEDURE agregarReservacion @idCubiculo int, @idEstudiante int, @fechaDeUso date, @horaInicio time(0),
@horaFinal time(0), @fechaDeReservacion date
AS
INSERT INTO dbo.Reservaciones (idCubiculo, idEstudiante, fechaDeUso, horaInicio, horaFinal, confirmacion, fechaDeReservacion)
VALUES (@idCubiculo, @idEstudiante, @fechaDeUso, @horaInicio, @horaFinal, 0, @fechaDeReservacion)
GO


DROP PROCEDURE IF EXISTS dbo.leerReservacion
GO
CREATE PROCEDURE leerReservacion @idReservacion int
AS
SELECT idReservacion, idCubiculo, idEstudiante, fechaDeUso, horaInicio, horaFinal, confirmacion, fechaDeReservacion
FROM dbo.Reservaciones
WHERE idReservacion = @idReservacion
GO


DROP PROCEDURE IF EXISTS dbo.modificarReservacion
GO
CREATE PROCEDURE modificarReservacion @idCubiculo int, @idEstudiante int, @fechaDeUso date, @horaInicio time(0),
@horaFinal time(0), @idCubiculoNuevo int, @fechaDeUsoNueva date, @horaInicioNueva time(0), @horaFinalNueva time(0),
@confirmacionNueva bit, @fechaDeReservacionNueva date
AS
UPDATE dbo.Reservaciones SET
idCubiculo = @idCubiculoNuevo, fechaDeUso = @fechaDeUsoNueva, horaInicio = @horaInicioNueva, horaFinal = @horaFinalNueva,
confirmacion = @confirmacionNueva, fechaDeReservacion = @fechaDeReservacionNueva
WHERE
idCubiculo = @idCubiculo and idEstudiante = @idEstudiante and fechaDeUso = @fechaDeUso and horaInicio = @horaInicio and
horaFinal = @horaFinal
GO


DROP PROCEDURE IF EXISTS dbo.eliminarReservacion
GO
CREATE PROCEDURE eliminarReservacion @idReservacion int
AS
DELETE FROM dbo.Reservaciones
WHERE
idReservacion = @idReservacion
GO


DROP PROCEDURE IF EXISTS dbo.confirmarCubiculo
GO
CREATE PROCEDURE confirmarCubiculo @idCubiculo int, @idEstudiante int, @fechaDeUso date, @horaInicio time(0),
@horaFinal time(0)
AS
UPDATE dbo.Reservaciones SET
confirmacion = 1
WHERE
idCubiculo = @idCubiculo and idEstudiante = @idEstudiante and fechaDeUso = @fechaDeUso and horaInicio = @horaInicio and
horaFinal = @horaFinal
GO



-- bloquear cubiculos (admin)
DROP PROCEDURE IF EXISTS dbo.bloquearCubiculo
GO
CREATE PROCEDURE bloquearCubiculo @idCubiculo int, @fechaDeUso date, @horaInicio time(0), @horaFinal time(0),
@fechaDeReservacion date
AS
EXEC dbo.agregarReservacion @idCubiculo = @idCubiculo, @idEstudiante = 1, @fechaDeUso = @fechaDeUso, @horaInicio = @horaInicio,
@horaFinal = @horaFinal, @fechaDeReservacion = @fechaDeReservacion
GO