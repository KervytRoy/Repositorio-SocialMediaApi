using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMedia.Api.Responses;
using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public PostController(IPostService postService, IMapper mapper, IUriService uriService)
        {
            _postService = postService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all posts
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetPosts))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<PostDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPosts([FromQuery]PostQueryFilters filters)
        {
            var posts =  _postService.GetPosts(filters);
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

            foreach (var item in postsDto)
            {
                var nameImage = item.Image;
                item.Image = _uriService.GetControllerUrl(Url.Action("GetImage", "Image", new { fileName = nameImage })).ToString();                
            }

            var metaData = new MetaData
            {
                TotalCount = posts.TotalCount,
                TotalPages = posts.TotalPages,
                HasNextPage = posts.HasNextPage,
                HasPreviousPage = posts.HasPreviousPage,
                CurrentPage = posts.CurrentPage,
                PageSize = posts.PageSize,
                NextPageUrl = _uriService.GetPostPaginationUrl(filters, Url.RouteUrl(nameof(GetPosts))).ToString(),
                PreviousPageUrl = _uriService.GetPostPaginationUrl(filters, Url.RouteUrl(nameof(GetPosts))).ToString()
            };

            var response = new ApiResponse<IEnumerable<PostDto>>(postsDto)
            {
                Meta = metaData
            };

            Response.Headers.Add("x-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);

            var nameImage = postDto.Image;
            postDto.Image = _uriService.GetControllerUrl(Url.Action("GetImage", "Image", new { fileName = nameImage })).ToString();
            return Ok(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postService.InsertPost(post);
            postDto = _mapper.Map<PostDto>(post);
            return Ok(postDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;

            var result = await _postService.UpdatePost(post);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {            
            var result = await _postService.DeletePost(id);
            return Ok(result);
        }
    }
}
