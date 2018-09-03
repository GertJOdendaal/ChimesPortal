using ChimesPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;

namespace ChimesPortal.Controllers
{
    public class CranesController:UmbracoApiController
    {
        public List<Crane> GetAll()
        {
            // get the id of the type (by alias) 
            IContentTypeService contentTypeService = ApplicationContext.Services.ContentTypeService;
            IContentType mytype = contentTypeService.GetContentType("Crane");

            // get all content by type
            IContentService contentService = ApplicationContext.Services.ContentService;
            IEnumerable<IContent> items = contentService.GetContentOfContentType(mytype.Id);

            List<Crane> Cranes = new List<Crane>();
            foreach(var item in items.Where(x=>!x.Trashed).OrderBy(x => x.SortOrder))
            {
  
                var img = Umbraco.TypedMedia(item.Properties["craneImage"].Value);
                var category = Umbraco.TypedContent(item.Properties["category"].Value);

                //Todo:Inline conversion did not resolve correctly
                object boomLengthObj = item.Properties["boomLength"].Value;
                object jibLengthObj = item.Properties["jibLength"].Value;
                object numberOfAxlesObj = item.Properties["numberOfAxles"].Value;
                decimal? boomLength = null;
                decimal? jibLength = null;
                int? numberOfAxles = null;
                if (boomLengthObj != null)
                    boomLength = (decimal)boomLengthObj;
                if (jibLengthObj != null)
                    jibLength = (decimal)jibLengthObj;
                if (numberOfAxlesObj != null)
                    numberOfAxles = (int)numberOfAxlesObj;
                //

                Cranes.Add(new Crane()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Properties["description"].Value?.ToString(),
                    Model = item.Properties["model"].Value?.ToString(),
                    Type = item.Properties["type"].Value?.ToString(),
                    BoomLength = boomLength,
                    JibLength = jibLength,
                    NumberOfAxles = numberOfAxles,
                    Image = new Uri(new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority)), img.Url).ToString(),
                    Category = category.Id
                });
            }

            return Cranes;
        }
    }
}