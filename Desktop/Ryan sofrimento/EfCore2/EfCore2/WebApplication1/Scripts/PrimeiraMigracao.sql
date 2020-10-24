IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Pedidos] (
    [IdProduto] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [OrderDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([IdProduto])
);

GO

CREATE TABLE [Produtos] (
    [IdProduto] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Preco] real NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([IdProduto])
);

GO

CREATE TABLE [PedidosItens] (
    [IdPedidoItem] uniqueidentifier NOT NULL,
    [IdPedido] uniqueidentifier NOT NULL,
    [IdProduto] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_PedidosItens] PRIMARY KEY ([IdPedidoItem]),
    CONSTRAINT [FK_PedidosItens_Pedidos_IdPedido] FOREIGN KEY ([IdPedido]) REFERENCES [Pedidos] ([IdProduto]) ON DELETE CASCADE,
    CONSTRAINT [FK_PedidosItens_Produtos_IdProduto] FOREIGN KEY ([IdProduto]) REFERENCES [Produtos] ([IdProduto]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_PedidosItens_IdPedido] ON [PedidosItens] ([IdPedido]);

GO

CREATE INDEX [IX_PedidosItens_IdProduto] ON [PedidosItens] ([IdProduto]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200922171218_InitialCrate', N'3.1.8');

GO

ALTER TABLE [PedidosItens] ADD [Quantidade] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200922172232_Quantidade', N'3.1.8');

GO

