--PROCEDIMIENTO ALMACENADO PARA ELIMINAR LOS TUBOS

CREATE OR ALTER PROCEDURE dbo.sp_deletepipe
	@id int
AS
BEGIN
	
	DELETE FROM InformationPipes
	WHERE ID = @id;

END;

--Ejecuci�n del sp para eliminar el ID de la tabla y as� eliminar lo correspondiente
EXEC sp_deletepipe @id = '5567';

EXEC sp_getpipes