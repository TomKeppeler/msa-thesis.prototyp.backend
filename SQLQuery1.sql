BEGIN
    CREATE TABLE [auf].[Customer] (
        [Id] uniqueidentifier NOT NULL,
        [CreatedOn] DATETIME NOT NULL,
        [ModifiedOn] DATETIME NOT NULL,
        CONSTRAINT [PK_Customer] PRIMARY KEY ([Id])
    );
END;
GO

BEGIN
    CREATE TABLE [auf].[Employee] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(250) NOT NULL,
        [Email] nvarchar(450) NOT NULL,
        [CreatedOn] DATETIME NOT NULL,
        [ModifiedOn] DATETIME NOT NULL,
        CONSTRAINT [PK_Employee] PRIMARY KEY ([Id])
    );
END;
GO

BEGIN
    CREATE TABLE [auf].[Team] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [CreatedOn] DATETIME NOT NULL,
        [ModifiedOn] DATETIME NOT NULL,
        CONSTRAINT [PK_Team] PRIMARY KEY ([Id])
    );
END;
GO

BEGIN
    CREATE TABLE [auf].[Order] (
        [Id] uniqueidentifier NOT NULL,
        [TeamId] uniqueidentifier NOT NULL,
        [OwnerId] uniqueidentifier NOT NULL,
        [CustomerId] uniqueidentifier NOT NULL,
        [Name] nvarchar(250) NOT NULL,
        [Volume] float NOT NULL,
        [Description] nvarchar(50) NOT NULL,
        [CreatedOn] DATETIME NOT NULL,
        [ModifiedOn] DATETIME NOT NULL,
        CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Order_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [auf].[Customer] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Order_Employee_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [auf].[Employee] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Order_Team_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [auf].[Team] ([Id]) ON DELETE CASCADE
    );
END;
GO

BEGIN
    CREATE TABLE [auf].[ConsultingRole] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Rate] float NOT NULL,
        [Quantity] float NULL,
        [CustomerNumber] nvarchar(50) NOT NULL,
        [OrderId] uniqueidentifier NOT NULL,
        [CreatedOn] DATETIME NOT NULL,
        [ModifiedOn] DATETIME NOT NULL,
        CONSTRAINT [PK_ConsultingRole] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ConsultingRole_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [auf].[Order] ([Id]) ON DELETE CASCADE
    );
END;
GO

BEGIN
    CREATE TABLE [auf].[Invoice] (
        [Id] uniqueidentifier NOT NULL,
        [InvoicedOn] DATETIME NULL,
        [PlannedInvoicedOn] DATETIME NULL,
        [PaidOn] DATETIME NULL,
        [PaymentTarget] DATETIME NULL,
        [InvoiceText] nvarchar(450) NOT NULL,
        [OrderId] uniqueidentifier NULL,
        [CreatedOn] DATETIME NOT NULL,
        [ModifiedOn] DATETIME NOT NULL,
        CONSTRAINT [PK_Invoice] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Invoice_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [auf].[Order] ([Id])
    );
END;
GO

BEGIN
    CREATE TABLE [auf].[Milestone] (
        [Id] uniqueidentifier NOT NULL,
        [OrderId] uniqueidentifier NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [Volume] float NULL,
        [State] int NOT NULL,
        [CompletedOn] DATE NOT NULL,
        [CreatedOn] DATETIME NOT NULL,
        [ModifiedOn] DATETIME NOT NULL,
        CONSTRAINT [PK_Milestone] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Milestone_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [auf].[Order] ([Id]) ON DELETE CASCADE
    );
END;
GO

BEGIN
    CREATE TABLE [auf].[Capacity] (
        [Id] uniqueidentifier NOT NULL,
        [EmployeeId] uniqueidentifier NOT NULL,
        [ConsultingRoleId] uniqueidentifier NOT NULL,
        [PlannedTurnover] float NOT NULL,
        [DaysOff] float NOT NULL,
        [CapacityPerDay] float NOT NULL,
        [OrderId] uniqueidentifier NULL,
        [CreatedOn] DATETIME NOT NULL,
        [ModifiedOn] DATETIME NOT NULL,
        CONSTRAINT [PK_Capacity] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Capacity_ConsultingRole_ConsultingRoleId] FOREIGN KEY ([ConsultingRoleId]) REFERENCES [auf].[ConsultingRole] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Capacity_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [auf].[Order] ([Id])
    );
END;
GO

BEGIN
    CREATE TABLE [auf].[Feature] (
        [Id] uniqueidentifier NOT NULL,
        [TeamId] uniqueidentifier NOT NULL,
        [Title] nvarchar(200) NOT NULL,
        [Effort] float NOT NULL,
        [StartDate] DATETIME NULL,
        [TargetDate] DATETIME NULL,
        [MilestoneId] uniqueidentifier NULL,
        [CreatedOn] DATETIME NOT NULL,
        [ModifiedOn] DATETIME NOT NULL,
        CONSTRAINT [PK_Feature] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Feature_Milestone_MilestoneId] FOREIGN KEY ([MilestoneId]) REFERENCES [auf].[Milestone] ([Id])
    );
END;
GO

BEGIN
    CREATE INDEX [IX_Capacity_ConsultingRoleId] ON [auf].[Capacity] ([ConsultingRoleId]);
END;
GO

BEGIN
    CREATE INDEX [IX_Capacity_EmployeeId] ON [auf].[Capacity] ([EmployeeId]);
END;
GO

BEGIN
    CREATE INDEX [IX_Capacity_OrderId] ON [auf].[Capacity] ([OrderId]);
END;
GO

BEGIN
    CREATE INDEX [IX_ConsultingRole_OrderId] ON [auf].[ConsultingRole] ([OrderId]);
END;
GO

BEGIN
    CREATE INDEX [IX_Feature_MilestoneId] ON [auf].[Feature] ([MilestoneId]);
END;
GO

BEGIN
    CREATE INDEX [IX_Invoice_OrderId] ON [auf].[Invoice] ([OrderId]);
END;
GO

BEGIN
    CREATE INDEX [IX_Milestone_OrderId] ON [auf].[Milestone] ([OrderId]);
END;
GO

BEGIN
    CREATE INDEX [IX_Order_CustomerId] ON [auf].[Order] ([CustomerId]);
END;
GO

BEGIN
    CREATE INDEX [IX_Order_OwnerId] ON [auf].[Order] ([OwnerId]);
END;
GO

BEGIN
    CREATE INDEX [IX_Order_TeamId] ON [auf].[Order] ([TeamId]);
END;
GO

COMMIT;

END;