using Domain.Aggregates.Accounts;
using Domain.Aggregates.Accounts.ValueObjects;
using Domain.Aggregates.Blogs;
using Domain.Aggregates.Blogs.ValueObjects;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contracts.Repositories;
using Presentation.Helpers;
using Presentation.Specifications.Accounts;
using Presentation.Specifications.Blogs;
using Shared.Models.Accounts;
using Shared.Models.Blogs;

var host = AppBuilder.BuildApp();
var ids = await host.AddTestData();

var accountRepository = host.Services.GetRequiredService<IRepository<Account, AccountId>>();
var blogRepository = host.Services.GetRequiredService<IRepository<Blog, BlogId>>();

var accountInfo = await accountRepository
    .GetOneAsync<AccountInfoById, AccountInfo>(new(ids.accountId));
/*
      SELECT TOP(1) [a].[Email], [u].[FirstName], [u].[LastName]
      FROM [Accounts] AS [a]
      LEFT JOIN [Users] AS [u] ON [a].[Id] = [u].[AccountId]
      WHERE [a].[Id] = @__accountId_0
*/

var blogDetails = await blogRepository
    .GetOneAsync<BlogDetailsById, BlogDetails>(new(ids.blogId));
/*
      SELECT TOP(1) [b].[Title], [b].[Description], [b0].[Url]
      FROM [Blogs] AS [b]
      LEFT JOIN [BlogMediaItems] AS [b0] ON [b].[Id] = [b0].[BlogId]
      WHERE [b].[Id] = @__blogId_0
*/

var blogPostDetails = await blogRepository
    .GetManyAsync<BlogPostDetailsListById, BlogPostDetails>(new(ids.blogId));
/*
    SELECT [p].[Caption], [p].[Content], [b].[Id], [p].[Id], [p0].[Url], [p0].[Id]
    FROM [Blogs] AS [b]
    INNER JOIN [Posts] AS [p] ON [b].[Id] = [p].[BlogId]
    LEFT JOIN [PostMediaItems] AS [p0] ON [p].[Id] = [p0].[PostId]
    WHERE [b].[Id] = @__blogId_0
    ORDER BY [b].[Id], [p].[Id]
*/

Console.ReadKey();
