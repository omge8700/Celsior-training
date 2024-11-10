﻿using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Models.DTOs;

namespace BlogPlatform.Services
{
    public class BloggerService : IBloggerService
    {
        private readonly IRepository<int, Blogger> _bloggerrepo;

        public BloggerService(IRepository<int,Blogger> bloggerRepository)
        {
            _bloggerrepo = bloggerRepository;
            
        }
        public async Task<string> AddBloggerAsync(BloggerDTO blogger, int BloggerId)
        {
            Blogger newblogger = new Blogger()
            {
                bio = blogger.Bio,
                profilePicture = blogger.ProfilePicture,


            };

            try
            {
                var addblogger = await _bloggerrepo.Add(newblogger);
                return $"the blogger is added";
            }
            catch (Exception ex)
            {
                throw new Exception("Could not add Blogger");
            }
            

            
        }

        public async Task<string> DeleteBloggerAsync(BloggerDTO blogger,int BloggerId)
        {
            try
            {
                var checkbloggerid = await _bloggerrepo.Get(BloggerId);
                if(checkbloggerid == null)
                {
                    throw new Exception($"There is bloggerID with : {BloggerId}");
                }

                Blogger bloggertobedeleted = new Blogger()
                {
                    BloggerID = blogger.BloggerID,
                };
                await _bloggerrepo.Delete(BloggerId);
                return $"This Blogger is deleted with bloggerID :{BloggerId}";
            }

            catch(Exception ex) 

             {

                throw new Exception("Could not found the blogger");

            }


        }

        public  async  Task<Blogger> GetBloggerByIdAsync(int BloggerID )
        {
            try
            {
                var checkbloggerid = await _bloggerrepo.Get(BloggerID);
                if (checkbloggerid == null)
                {
                    throw new Exception($"The blogger id entered is incorrect");
                }

                var getbloggerdetails = await _bloggerrepo.Get(BloggerID);

                return getbloggerdetails;
            }
            catch
            {
                throw new Exception("The blogger cannot be found ");
            }

        }

        public async Task<IEnumerable<Blogger>> GetBloggerListAsync(int BloggerID)
        {
            throw new Exception("The blogger cannot be found ");



        }

        public async Task<string> UpdateBloggerAsync(BloggerDTO blogger,int BloggerID)
        {
            try
            {
                var checkbloggeridupdate = await _bloggerrepo.Get(BloggerID);
                if(checkbloggeridupdate == null)
                {
                    throw new Exception($"Blogger Cannot be found with blogger id :{BloggerID}");
                }
                BloggerDTO updateblogger = new BloggerDTO()
                {
                    Bio = blogger.Bio,
                    ProfilePicture = blogger.ProfilePicture,

                };

                var updatedBlogger = await _bloggerrepo.Update(updateblogger);


            }
           
        }
    }
}
