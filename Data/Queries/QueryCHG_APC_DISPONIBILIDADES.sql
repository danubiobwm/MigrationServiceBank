--SELECT * FROM APC_DISPONIBILIDADES_TABLE;


-- QueryCHG_APC_DISPONIBILIDADES.sql
-- SELECT * 
-- FROM TB_SAFRA_PARAM_DS A
-- INNER JOIN TB_SAFRA_PARAM_ARQ_DS B ON B.id_processo = A.id_processo 
-- WHERE A.id_processo = 1;


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
