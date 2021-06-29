CREATE TABLE [dbo].[TBCompromisso] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [assunto]     VARCHAR (200) NOT NULL,
    [local]       VARCHAR (200) NOT NULL,
    [data]        DATE          NOT NULL,
    [horaInicio]  TIME (7)      NOT NULL,
    [horaTermino] TIME (7)      NOT NULL,
    [idContatos]  INT           NOT NULL,
    CONSTRAINT [FK_TBCompromisso_TBContatos] FOREIGN KEY ([idContatos]) REFERENCES [dbo].[TBContatos] ([Id])
);

