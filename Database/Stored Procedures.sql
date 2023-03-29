USE CubiculosTEC
GO

-- Estudiantes
DROP PROCEDURE IF EXISTS dbo.agregarEstudiante
GO
CREATE PROCEDURE agregarEstudiante @correo varchar(50), @contrasena varchar(50), @nombre varchar(50),
@apellido1 varchar(50), @apellido2 varchar(50), @fechaDeNacimiento date
AS
INSERT INTO dbo.Estudiantes (correo, contrasena, nombre, apellido1, apellido2, edad, fechaDeNacimiento, idEstadoEstudiante)
VALUES (@correo, @contrasena, @nombre, @apellido1, @apellido2, DATEDIFF(year , @fechaDeNacimiento, GETDATE()),
@fechaDeNacimiento, 1)
GO


DROP PROCEDURE IF EXISTS dbo.leerEstudiante
GO
CREATE PROCEDURE leerEstudiante @correo varchar(50)
AS
SELECT idEstudiante, correo, contrasena, nombre, apellido1, apellido2, edad, fechaDeNacimiento, idEstadoEstudiante
FROM dbo.Estudiantes
WHERE correo = @correo
GO


DROP PROCEDURE IF EXISTS dbo.modificarEstudiante
GO
CREATE PROCEDURE modificarEstudiante @correo varchar(50), @contrasena varchar(50), @nombre varchar(50),
@apellido1 varchar(50), @apellido2 varchar(50), @fechaDeNacimiento date, @estado smallint
AS
UPDATE dbo.Estudiantes SET
contrasena = @contrasena, nombre = @nombre, apellido1 = @apellido1, apellido2 = @apellido2,
edad = DATEDIFF(year , @fechaDeNacimiento, GETDATE()), fechaDeNacimiento = @fechaDeNacimiento,
idEstadoEstudiante = @estado 
WHERE
correo = @correo
GO


DROP PROCEDURE IF EXISTS dbo.eliminarEstudiante
GO
CREATE PROCEDURE eliminarEstudiante @correo varchar(50)
AS
DELETE FROM dbo.Estudiantes
WHERE correo = @correo
GO



-- Cubiculos

DROP PROCEDURE IF EXISTS dbo.crearCubiculo
GO
CREATE PROCEDURE crearCubiculo @nombre varchar(50), @capacidad int
AS
INSERT INTO dbo.Cubiculos (nombre, idEstado, capacidad)
VALUES (@nombre, 1, @capacidad)
GO


DROP PROCEDURE IF EXISTS dbo.leerCubiculo
GO
CREATE PROCEDURE leerCubiculo @nombre varchar(50)
AS
SELECT idCubiculo, nombre, idEstado, capacidad, tiempoMaximo
FROM dbo.Cubiculos
WHERE nombre = @nombre
GO


DROP PROCEDURE IF EXISTS dbo.modificarCubiculo
GO
CREATE PROCEDURE modificarCubiculo @nombreOriginal varchar(50), @nombreNuevo varchar(50),
@idEstado smallint, @capacidad int, @tiempoMaximo time(0)
AS
UPDATE dbo.Cubiculos SET
nombre = @nombreNuevo, idEstado = @idEstado, capacidad = @capacidad, tiempoMaximo = @tiempoMaximo
WHERE
nombre = @nombreOriginal
GO


DROP PROCEDURE IF EXISTS dbo.eliminarCubiculo
GO
CREATE PROCEDURE eliminarCubiculo @nombre varchar(50)
AS
DELETE FROM dbo.Cubiculos
WHERE nombre = @nombre
GO



-- Reservaciones

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
CREATE PROCEDURE leerReservacion @idCubiculo int, @idEstudiante int, @fechaDeUso date, @horaInicio time(0), @horaFinal time(0)
AS
SELECT idReservacion, idCubiculo, idEstudiante, fechaDeUso, horaInicio, horaFinal, confirmacion, fechaDeReservacion
FROM dbo.Reservaciones
WHERE idCubiculo = @idCubiculo and idEstudiante = @idEstudiante and fechaDeUso = @fechaDeUso and horaInicio = @horaInicio and
horaFinal = @horaFinal
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
CREATE PROCEDURE eliminarReservacion @idCubiculo int, @idEstudiante int, @fechaDeUso date, @horaInicio time(0),
@horaFinal time(0)
AS
DELETE FROM dbo.Reservaciones
WHERE
idCubiculo = @idCubiculo and idEstudiante = @idEstudiante and fechaDeUso = @fechaDeUso and horaInicio = @horaInicio and
horaFinal = @horaFinal
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