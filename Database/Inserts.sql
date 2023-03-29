USE CubiculosTEC
GO



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