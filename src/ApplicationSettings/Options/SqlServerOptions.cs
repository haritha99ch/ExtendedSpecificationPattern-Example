﻿namespace ApplicationSettings.Options;
public sealed class SqlServerOptions : IApplicationOptions
{
    [Required]
    public string ConnectionString { get; set; } = default!;
    public int MaxRetryCount { get; set; } = 5;
    public int CommandTimeout { get; set; } = 30;
    public bool EnableDetailedErrors { get; set; } = true;
    public bool EnableSensitiveDataLogging { get; set; } = true;
}
