using SocialMedia.Core.QueryFilters;
using System;

namespace SocialMedia.Infraestructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUrl(PostQueryFilters filter, string actionUrl);
    }
}