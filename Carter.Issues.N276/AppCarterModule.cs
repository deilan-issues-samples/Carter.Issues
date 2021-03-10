using Carter.Request;
using Carter.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carter.Issues.N276
{
    public sealed class AppCarterModule : CarterModule
    {
        private static readonly Actor[] Actors = new[]
        {
            new Actor() { Id = 1, Name = "First"},
            new Actor() { Id = 2, Name = "Second"},
            new Actor() { Id = 3, Name = "Third"},
        };
        public AppCarterModule()
        {
            Get("/actors", async ctx =>
            {
                IEnumerable<Actor> result = Actors;
                var ids = ctx.Request.Query.As<int[]>("Id");
                if (ids != null)
                {
                    result = result.Where(x => ids.Contains(x.Id));
                }
                await ctx.Response.Negotiate(result);
            });
        }
    }
}
