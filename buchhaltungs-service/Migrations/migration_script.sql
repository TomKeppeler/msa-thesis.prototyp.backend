IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240113211438_mssql.container_migration_208_initCreate'
)
BEGIN
    IF SCHEMA_ID(N'buc') IS NULL EXEC(N'CREATE SCHEMA [buc];');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240113211438_mssql.container_migration_208_initCreate'
)
BEGIN
    CREATE TABLE [buc].[Employee] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(250) NOT NULL,
        [Email] nvarchar(450) NOT NULL,
        [CreatedOn] DATETIME NOT NULL,
        [ModifiedOn] DATETIME NOT NULL,
        CONSTRAINT [PK_Employee] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240113211438_mssql.container_migration_208_initCreate'
)
BEGIN
    CREATE TABLE [buc].[Invoice] (
        [Id] uniqueidentifier NOT NULL,
        [InvoicedOn] DATETIME NULL,
        [PlannedInvoicedOn] DATETIME NULL,
        [PaidOn] DATETIME NULL,
        [PaymentTarget] DATETIME NULL,
        [InvoiceText] nvarchar(450) NOT NULL,
        [CreatedOn] DATETIME NOT NULL,
        [ModifiedOn] DATETIME NOT NULL,
        CONSTRAINT [PK_Invoice] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240113211438_mssql.container_migration_208_initCreate'
)
BEGIN
    CREATE TABLE [buc].[Activity] (
        [Id] uniqueidentifier NOT NULL,
        [InvoiceId] uniqueidentifier NULL,
        [Description] nvarchar(max) NOT NULL,
        [Price] float NOT NULL,
        [CreatedOn] DATETIME NOT NULL,
        [ModifiedOn] DATETIME NOT NULL,
        CONSTRAINT [PK_Activity] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Activity_Invoice_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [buc].[Invoice] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240113211438_mssql.container_migration_208_initCreate'
)
BEGIN
    CREATE INDEX [IX_Activity_InvoiceId] ON [buc].[Activity] ([InvoiceId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240113211438_mssql.container_migration_208_initCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240113211438_mssql.container_migration_208_initCreate', N'8.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240113212139_mssql.container_migration_942_initCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240113212139_mssql.container_migration_942_initCreate', N'8.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240113212903_mssql.container_migration_470_initCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240113212903_mssql.container_migration_470_initCreate', N'8.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240113213413_mssql.container_migration_718'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240113213413_mssql.container_migration_718', N'8.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240113213754_mssql_migration_671'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240113213754_mssql_migration_671', N'8.0.1');
END;
GO

COMMIT;
GO

