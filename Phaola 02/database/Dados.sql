CREATE TABLE [dbo].Dados (
	[Id]			VARCHAR(8) NOT NULL PRIMARY KEY,
    [Data]          DATE       NOT NULL,
    [MatGorda]      FLOAT (53) NULL,
    [Densidade]     FLOAT (53) NULL,
    [Acidez]        FLOAT (53) NULL,
    [Lactose]       FLOAT (53) NULL,
    [PH]            FLOAT (53) NULL,
    [ESD]           FLOAT (53) NULL,
	[EST]           FLOAT (53) NULL,
    [Crioscopia]    FLOAT (53) NULL,
    [PROTEINAS]     FLOAT (53) NULL,
    [CCS]           FLOAT (53) NULL,
    [CTB]           FLOAT (53) NULL,
    [SolidosTotais] FLOAT (53) NULL
);

