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
    public class ContactPeopleController : UmbracoApiController
    {
        public List<ContactPerson> GetAll()
        {
            // get the id of the type (by alias) 
            IContentTypeService contentTypeService = ApplicationContext.Services.ContentTypeService;
            IContentType mytype = contentTypeService.GetContentType("ContactPerson");

            // get all content by type
            IContentService contentService = ApplicationContext.Services.ContentService;
            IEnumerable<IContent> items = contentService.GetContentOfContentType(mytype.Id);

            List<ContactPerson> ContactPeople = new List<ContactPerson>();
            foreach(var item in items.Where(x=>!x.Trashed).OrderBy(x => x.SortOrder))
            {
  
                var img = Umbraco.TypedMedia(item.Properties["profileImage"].Value);
            
                ContactPeople.Add(new ContactPerson()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Mobile = item.Properties["Mobile"].Value?.ToString(),
                    Email = item.Properties["Email"].Value?.ToString(),
                    Title = item.Properties["Title"].Value?.ToString(),
                    Image = new Uri(new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority)), img.Url).ToString(),
                });
            }

            return ContactPeople;
        }
    }
}