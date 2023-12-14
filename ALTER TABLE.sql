--Convertir el tipo de valor a la hora de que se muestra en pantalla
SELECT CAST (Heat AS int ) FROM dbo.InformationPipes

SELECT CASE 
         WHEN ISNUMERIC(Heat) = 1 THEN CAST(Heat AS INT)
         ELSE NULL -- o algún valor por defecto
       END AS ConvertedHeat
FROM dbo.InformationPipes

--Convertir el tipo de valor 
SELECT CAST(ISNULL(Heat, 0) AS INT) AS HeatToInt FROM dbo.InformationPipes

--Cambiar los tipos de valores
ALTER TABLE dbo.InformationPipes
ALTER COLUMN UpdateDate Datetime;

--actualizar la fecha actual 
UPDATE dbo.InformationPipes
SET CreateDate = SYSDATETIME();

--actualizar la fecha actual 
UPDATE dbo.InformationPipes
SET UpdateDate = SYSDATETIME();