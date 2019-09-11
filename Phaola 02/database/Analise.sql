drop table Analise;
CREATE TABLE [dbo].Analise (
	[Id]			VARCHAR(10) NOT NULL PRIMARY KEY,
    [Data]          DATE       NOT NULL,
    [MatGorda]      FLOAT (53) NOT NULL,
    [Densidade]     FLOAT (53) NOT NULL,
    [Acidez]        FLOAT (53) NOT NULL,
    [Lactose]       FLOAT (53) NOT NULL,
    [PH]            FLOAT (53) NOT NULL,
    [ESD]           FLOAT (53) NOT NULL,
	[EST]           FLOAT (53) NOT NULL,
    [Crioscopia]    FLOAT (53) NOT NULL,
    [Proteinas]     FLOAT (53) NOT NULL,
    [CCS]           FLOAT (53) NOT NULL,
    [CTB]           FLOAT (53) NOT NULL,
    [SolidosTotais] FLOAT (53) NOT NULL
);

