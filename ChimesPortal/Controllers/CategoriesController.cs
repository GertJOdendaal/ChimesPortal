using ChimesPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;

namespace ChimesPortal.Controllers
{
    public class CategoriesController : UmbracoApiController
    {
        public List<Category> GetAll()
        {
            // get the id of the type (by alias) 
            IContentTypeService contentTypeService = ApplicationContext.Services.ContentTypeService;
            IContentType mytype = contentTypeService.GetContentType("Category");

            // get all content by type
            IContentService contentService = ApplicationContext.Services.ContentService;
            IEnumerable<IContent> items = contentService.GetContentOfContentType(mytype.Id);

            List<Category> Categories = new List<Category>();
            foreach (var item in items.Where(x => !x.Trashed).OrderBy(x=>x.SortOrder))
            {
                var img = Umbraco.TypedMedia(item.Properties["categoryImage"].Value);
                Categories.Add(new Category()
                {
                    Id=item.Id,
                    Name = item.Name,
                    Image = new Uri(new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority)), img.Url).ToString()
                });
            }

            return Categories;
        }
    }
}
