using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTest1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class PublicationsController : Controller
    {
        private readonly ApplicationContext context;

        public PublicationsController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetPublications()
        {
            var publications = this.context.Publications
                //.Include(it => it.Categories)
                //.Include(it => it.NewCategories)
                //.Include(it => it.Votes)
                .OrderByDescending(it => it.Id)
                .Select(publication => new
                {
                    Id = publication.Id,
                    Title = publication.Title,
                    Content = publication.Text,
                    Categories = publication
                        .PublicationCategories
                        .Where(publicationCategory => publicationCategory.PublicationId == publication.Id)
                        .Select(publicationCategory => new
                        {
                            Id = publicationCategory.CategoryId,
                            Name = publication
                                .Categories
                                .First(category => category.Id == publicationCategory.CategoryId)
                                .Name
                        })
                })
                .ToList();

            return Ok(publications);
        }
    }
}