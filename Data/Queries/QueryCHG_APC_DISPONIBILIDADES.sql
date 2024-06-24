--SELECT * FROM APC_DISPONIBILIDADES_TABLE;


CREATE PROCEDURE GetCHG_APC_DISPONIBILIDADES
AS
BEGIN
    SELECT Field1, Field2
    FROM YourTable
    WHERE Condition = 'some condition';
END


CREATE TABLE Siglas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Sigla NVARCHAR(10) NOT NULL,
    Descricao NVARCHAR(100) NOT NULL
);

INSERT INTO Siglas (Sigla, Descricao) VALUES 
('CHG', 'Câmbio - CHG'),
('CHI', 'Câmbio - CHI'),
('TUR', 'Câmbio - TUR');
