DELETE FROM HouseData;
DECLARE @i INT = 0;
WHILE @i < 300
BEGIN
    
    INSERT INTO [dbo].[HouseData] 
    (
        [houseNumber], 
        [streetPrefixId], 
        [street], 
        [apartmentNumber], 
        [ownerName], 
        [totalApartments]
    )
    VALUES 
    (
        CAST(RAND()*500+1 AS NCHAR(10)),  -- generates a random string for houseNumber
        CAST(RAND() * 8 + 1 AS INT),  -- generates a random integer between 1 and 8 for streetPrefixId
        N'Улица' + CAST(RAND()*1000+1 AS NCHAR(10)),  -- generates a random string for street
        CAST(RAND() * 100 AS INT),  -- generates a random integer between 0 and 100 for apartmentNumber
        N'Владелец'+CAST(RAND()*1000+1 AS NCHAR(50)),  -- generates a random string for ownerName
        CAST(RAND() * 100 AS INT)  -- generates a random integer between 0 and 100 for totalApartments
    );
    SET @i = @i + 1;
END
