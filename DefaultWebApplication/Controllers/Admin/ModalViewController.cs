using DefaultWebApplication.Database;
using DefaultWebApplication.Models.Domain_Models.Main_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DefaultWebApplication.Controllers.Admin
{
    [Route("/modal")]
    public class ModalViewController : Controller
    {
        private readonly AppDbContext _context;

        public ModalViewController(AppDbContext context)
        {
            _context = context;
        }

        //[HttpGet("get-modal/{domainModelName}/{entityId}")]
        //public async Task<IActionResult> RouteToModalGenerator(string domainModelName, int entityId)
        //{
        //    var entity = GetDbSet(domainModelName).Where(entity => entity.)
        //}


        //private (DbSet<object>, string) GetDbSet(string entityName)
        //{
        //    Type entityType = (Type)_context.Model.GetEntityTypes(entityName).FirstOrDefault()
        //        ?? throw new Exception($"Data context to do not possess entity named as '{entityName}'");

        //    var entityId == entityType.GetField($"{entityName}Id").;

        //    DbSet<object> dbSet = (DbSet<object>)typeof(AppDbContext).GetProperty($"{entityName}s").GetValue(_context);

        //    return dbSet;
        //}
    }
}
