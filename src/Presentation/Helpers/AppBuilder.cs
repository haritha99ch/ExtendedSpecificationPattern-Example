using ApplicationSettings;
using ApplicationSettings.Options;
using Domain.Aggregates.Accounts;
using Domain.Aggregates.Accounts.ValueObjects;
using Domain.Aggregates.Blogs;
using Domain.Aggregates.Blogs.ValueObjects;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;

namespace Presentation.Helpers;
internal static class AppBuilder
{
    public static IHost BuildApp()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((_, config) => config.AddApplicationSettings())
            .ConfigureServices(services =>
            {
                services.ConfigureApplicationOptions<SqlServerOptions>();
                services.AddInfrastructure();
                services.AddPersistence();
            })
            .Build();
    }
    public async static Task<(AccountId accountId, BlogId blogId)> AddTestData(this IHost host)
    {
        var context = host.Services.GetRequiredService<ApplicationDbContext>();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        var accounts = new List<Account>();
        for (var i = 0; i < 10; i++)
        {
            accounts.Add(Account.Create(
                $"email.{i}",
                "password",
                "1234567890",
                "Haritha",
                "Rathnayake",
                DateOnly.FromDateTime(DateTime.Now),
                i.ToString(),
                "Street",
                "City"));
        }
        var blogs = accounts.Select(account => Blog.Create(accounts.Select(e => e.Id).First(),
                "Title",
                "Caption",
                new()
                {
                    Url = "url",
                    Type = "Image"
                }))
            .ToList();
        blogs.ForEach(blog =>
        {
            for (var i = 0; i < 3; i++)
            {
                var post = blog.AddPost("Caption", "Content");
                post.AddMediaItem("url", "image");
                post.AddMediaItem("url", "image");
            }
        });
        await context.Accounts.AddRangeAsync(accounts);
        await context.Blogs.AddRangeAsync(blogs);
        await context.SaveChangesAsync();
        return new(accounts.Select(e => e.Id).First(), blogs.Select(e => e.Id).First());
    }
}
