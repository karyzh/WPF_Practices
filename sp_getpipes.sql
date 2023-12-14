--PROCEDIMIENTO ALMACENADO PARA OBTENER O CONSULTAR TUBOS
CREATE OR ALTER PROCEDURE dbo.sp_getpipes
AS
BEGIN
	--DECLARE @CreateDate DATETIME;
	--SET @CreateDate = SYSDATETIME();

	----
	--DECLARE @ID INT;
	--BEGIN 
	-- IF NOT EXISTS (SELECT * FROM dbo.InformationPipes WHERE ID = @ID)
	-- BEGIN
	--	INSERT INTO dbo.InformationPipes (ID, CreateDate)
	--	VALUES (@ID, @CreateDate);
	--END
	--SET @ID = @ID + 1;
	--END
	SELECT * FROM dbo.InformationPipes;
END;

EXEC sp_getpipes

--CREATE PROCEDURE dbo.sp_getdate
--AS
--BEGIN
--	DECLARE @CreateDate DATETIME;
--	SET @CreateDate = GETDATE();

--	INSERT INTO dbo.InformationPipes (CreateDate)
--	VALUES (@CreateDate);
--END;

--EXEC dbo.sp_getdate

 