--PROCEDIMIENTO ALMACENADO PARA INSERTAR NUEVOS CAMPOS

CREATE OR ALTER PROCEDURE dbo.sp_insertpipes
	@id int,
	@heat int,
	@wo int,
	@createdate datetime,
	@updatedate datetime
AS
BEGIN
	INSERT INTO dbo.InformationPipes (ID, Heat, WO, CreateDate, UpdateDate)
	VALUES (@id, @heat, @wo, SYSDATETIME(), SYSDATETIME());
END;

--Ejecución del sp para insertar tubos
EXEC sp_insertpipes @id ='1632', @heat = '872039', @wo = '928300', @createdate = ' ', @updatedate = ' ';

--Ejecucíón del sp para obtener la info de los tubos
EXEC sp_getpipes

--Elimina las filas del nombre de la columna donde sea nulo
DELETE FROM dbo.InformationPipes where Heat IS NULL;
