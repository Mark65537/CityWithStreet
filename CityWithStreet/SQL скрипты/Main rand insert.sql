DECLARE @i INT = 0;

WHILE @i < 300
BEGIN
  INSERT INTO Main (localityId, houseId)
  VALUES (
    7 + ABS(CHECKSUM(NEWID())) % 6,
    1801 + ABS(CHECKSUM(NEWID())) % 300
  )
  SET @i = @i + 1;
END
