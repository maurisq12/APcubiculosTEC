USE CubiculosTEC



-- EstadosEstudiante

INSERT INTO dbo.EstadosEstudiante (estado)
VALUES ('Activo')

INSERT INTO dbo.EstadosEstudiante (estado)
VALUES ('Suspendido')

SELECT * FROM dbo.EstadosEstudiante



-- EstadosCubiculo

INSERT INTO dbo.EstadosCubiculo (estadoActual)
VALUES ('Libre')

INSERT INTO dbo.EstadosCubiculo (estadoActual)
VALUES ('Ocupado')

INSERT INTO dbo.EstadosCubiculo (estadoActual)
VALUES ('En Mantenimiento')

SELECT * FROM dbo.EstadosCubiculo



-- ServiciosEspeciales

INSERT INTO dbo.ServiciosEspeciales (servicioEspecial)
VALUES ('NVDA')

INSERT INTO dbo.ServiciosEspeciales (servicioEspecial)
VALUES ('Landa 1.4')

INSERT INTO dbo.ServiciosEspeciales (servicioEspecial)
VALUES ('JAWS')

INSERT INTO dbo.ServiciosEspeciales (servicioEspecial)
VALUES ('Teclado Especial')

INSERT INTO dbo.ServiciosEspeciales (servicioEspecial)
VALUES ('Línea Braille')

INSERT INTO dbo.ServiciosEspeciales (servicioEspecial)
VALUES ('Impresora Fuse')

SELECT * FROM dbo.ServiciosEspeciales



-- "Estudiante" administrador (para bloquear cubiculos)

INSERT INTO dbo.Estudiantes (correo, contrasena, cedula, carne, nombre, apellido1, apellido2, edad, fechaDeNacimiento, idEstadoEstudiante)
VALUES ('', '', 0, 0, '', '', '', 0,
'', 1)

SELECT * FROM dbo.Estudiantes