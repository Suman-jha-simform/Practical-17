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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230613124343_IntialContext')
BEGIN
    CREATE TABLE [Roles] (
        [EmailAddress] nvarchar(450) NOT NULL,
        [Role] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([EmailAddress])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230613124343_IntialContext')
BEGIN
    CREATE TABLE [Students] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Department] nvarchar(max) NOT NULL,
        [Grades] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Students] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230613124343_IntialContext')
BEGIN
    CREATE TABLE [UserLogin] (
        [EmailAddress] nvarchar(450) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_UserLogin] PRIMARY KEY ([EmailAddress])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230613124343_IntialContext')
BEGIN
    CREATE TABLE [Users] (
        [EmailAddress] nvarchar(450) NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [MobileNumber] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [ConfirmPassword] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([EmailAddress])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230613124343_IntialContext')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230613124343_IntialContext', N'7.0.5');
END;
GO

COMMIT;
GO

