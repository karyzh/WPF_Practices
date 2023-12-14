--PROCEDIMIENTO ALMACENADO PARA ACTUALIZAR DATOS

CREATE OR ALTER PROCEDURE dbo.sp_updatepipe 
	@id int, 
	@heat int,
	@wo int,
	@updatedate datetime
AS
BEGIN
	
	UPDATE InformationPipes
	SET ID = @id,
		Heat = @heat,
		WO = @wo,
		UpdateDate = GETDATE()
	WHERE ID = @id

END;


--Procedimiento almacenado donde actualiza los valores del tubo junto con su fecha actualizada 
EXEC sp_updatepipe @id = '1632', @heat = '872040', @wo = '928310', @updatedate = '';

EXEC sp_getpipes