using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrainStationDemo.Data;
using BrainStationDemo.Models;
using Microsoft.AspNetCore.Cors;
using BrainStationDemo.Models.Dto;

namespace BrainStationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("DemoPolicy")]
    public class PostsController : ControllerBase
    {
        private readonly BrainStationDemoContext _context;

        public PostsController(BrainStationDemoContext context)
        {
            _context = context;
        }

        // api/posts
        [HttpGet]
        public int GetPostCount()
        {
            var totalPosts = _context.Posts.Count();
            return totalPosts;

        }

        // GET: api/Posts
        [HttpGet("{page}")]
        public JsonResult GetPosts([FromRoute] int page)
        {
            var totalPosts = _context.Posts.Count();
            int pageSize = 2;
            int skip = pageSize * (page - 1);
            bool canPage = skip < totalPosts;
            if (!canPage)
                return null;

            var PostsList = _context.Posts
                .Skip(skip)
                .Take(pageSize)
                .Include(p => p.Comments)
                .ToList();

            var jsonResult = new JsonResult(PostsList);
            return jsonResult;
        }

        //// GET: api/Posts/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPost([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var post = await _context.Posts.FindAsync(id);

        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(post);
        //}

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost([FromRoute] int id, [FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        //[HttpGet("{query}/{page}")]
        [HttpGet("{page}/{query}")]
        public JsonResult GetPost( int page ,string query)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            List<Post> result = new List<Post>();
            var postList = _context.Posts.ToList();
            foreach(var post in postList)
            {
               

                if(post.PostText.ToUpper().Contains(query.ToUpper()))
                {
                    result.Add(post);
                }
            }

            var jsonResult = new JsonResult(result);

            return jsonResult;
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return Ok(post);
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}