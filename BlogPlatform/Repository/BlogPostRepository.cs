using BlogPlatform.Context;
using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BlogPlatform.Repository
{
    public class BlogPostRepository : IRepository<int,BlogPost>
    {
        private readonly BlogPlatformContext _context;

        public BlogPostRepository(BlogPlatformContext context)
        {
            _context = context;

        }

        public async Task<BlogPost> Add(BlogPost entity)
        {
            try
            {
                var blogpost = _context.BlogPosts.FirstOrDefault(x => x.PostId == entity.PostId);
                if (blogpost == null)
                {

                    await _context.BlogPosts.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                else
                {
                    throw new InvalidExpressionException("Blog post already exits");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"BlogPost already exits");
            }



        }

        public async Task<BlogPost> Delete(int key)
        {
            var deletePost = await Get(key);
            if(deletePost != null)
            {
                _context.BlogPosts.Remove(deletePost);
                await _context.SaveChangesAsync();
                return deletePost;

            }
            throw new Exception("BlogPost Delete Failed");
        }

        public async Task<BlogPost> Get(int  key)
        {
            var post = _context.BlogPosts.FirstOrDefault(x => x.PostId == key);
            return post;
        }


        public async Task<IEnumerable<BlogPost>> GetAll()
        {
            var posts = _context.BlogPosts.ToList();
            if(posts.Any())
            {
                return posts;
            }
            throw new Exception("BlogPosts Collection is empty");
        }

        public async Task<BlogPost> Update(BlogPost entity, int  key)
        {
            var updatedPost = await Get(key);
            if (updatedPost != null)
            {
                updatedPost.PostId = entity.PostId;
                updatedPost.Title = entity.Title;
                updatedPost.Content = entity.Content;
                updatedPost.BloggerID = entity.BloggerID;

                await _context.SaveChangesAsync();
                return updatedPost;


            }
            throw new Exception("Update post failed");

        }

   
    }
}

