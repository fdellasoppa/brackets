﻿namespace BL.Students.Infrastructure.Data;

public class MongoDbSettings
{
    public string Name { get; init; } = string.Empty;
    public string Host { get; init; } = string.Empty;
    public int Port { get; init; }
    public string ConnectionString => $"mongodb://{Host}:{Port}";
}