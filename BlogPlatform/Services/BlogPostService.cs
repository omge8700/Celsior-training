using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;
using System.Reflection;

namespace BlogPlatform.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IRepository<int, BlogPost> _blogpostrepo;

        public BlogPostService(IRepository<int, BlogPost> blogpostRepository)
        {
            _blogpostrepo = blogpostRepository;

        }

        public async Task<string> AddPostAsync(BlogPostDTO blogpost)
        {
            BlogPost newblog = new BlogPost()
            {

                Title = blogpost.Title,
                Content = blogpost.Content,
                Tags = blogpost.Tags,
                BloggerID = blogpost.BloggerID,
                Status = blogpost.Status,
                PublicationDate = DateTime.Now,

            };
            try
            {

                var addblogpost = await _blogpostrepo.Add(newblog);
                return $"The post is added with title :";

            }
            catch (Exception ex)
            {
                throw new Exception("Could Not add Post");
            }
        }

        public async Task<string> DeletePostAsync(BlogPostDTO post,int PostId)
        {
            try
            {
                var checkdeletepostid = await  _blogpostrepo.Get(PostId);
                if (checkdeletepostid == null)
                {

                    throw new Exception($"There is no PostId with:{PostId}");
                }

                BlogPost blogposttobedeleted = new BlogPost()
                {
                    PostId = post.PostId,
                };

                await _blogpostrepo.Delete(PostId);
                return $"This post is deleted with post id :{PostId}";
            }


            catch (Exception ex)
            {

                throw new Exception("Could not found the post");

            }
        }

        public Task<IEnumerable<BlogPost>> GetAllPostsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BlogPost> GetPostByIdAsync(int postId)
        {
            var getpostid = await  _blogpostrepo.Get(postId);
            return getpostid;

        }

        public async Task<string> UpdatePostAsync(BlogPostDTO blogPost, int PostId)
        {
            try
            {
                var checkid = await  _blogpostrepo.Get(PostId);
                if (checkid == null)
                {
                    throw new Exception($"There is not Post with PostID: {PostId}");



                }

                BlogPost blogposttobeupdated = new BlogPost()
                {

                    Title = blogPost.Title,
                    Content = blogPost.Content,
                };
                var updatepost = await _blogpostrepo.Update(blogposttobeupdated, PostId);

                return $"This BlogPost is updated :{PostId}";
            }


            catch (Exception ex)
            {
                throw new Exception("Could Not Update Post");
            }
        }
    }
}
