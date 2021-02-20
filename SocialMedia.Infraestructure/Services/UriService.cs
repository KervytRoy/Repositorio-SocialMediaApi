using SocialMedia.Core.QueryFilters;
using SocialMedia.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _urlBase;

        public UriService(string urlBase)
        {
            _urlBase = urlBase;
        }

        public Uri GetPostPaginationUrl(PostQueryFilters filter, string actionUrl)
        {
            string baseUrl = $"{_urlBase}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
