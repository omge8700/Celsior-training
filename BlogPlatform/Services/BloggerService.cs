using BlogPlatform.Interfaces;
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
           
            
                var checkbloggerid = await _bloggerrepo.Get(BloggerID);
                if (checkbloggerid == null)
                {
                    throw new Exception($"The blogger id entered is incorrect");
                }

                return checkbloggerid;

               
          

        }

        public async Task<IEnumerable<Blogger>> GetBloggerListAsync()
        {
            var getbloggerlist = await _bloggerrepo.GetAll();
            return getbloggerlist;




        }

        public async Task<string> UpdateBloggerAsync(BloggerDTO blogger,int BloggerID)
        {
            try
            {
                var checkbloggeridupdate = await _bloggerrepo.Get(BloggerID);
                if (checkbloggeridupdate == null)
                {
                    throw new Exception($"Blogger Cannot be found with blogger id :{BloggerID}");
                }
                Blogger updateblogger = new Blogger()
                {
                    bio = blogger.Bio,
                    profilePicture = blogger.ProfilePicture,

                };

                var updatedBlogger = await _bloggerrepo.Update( updateblogger, BloggerID);

                return $"The blogger is updated with the profile :{BloggerID}";


            }

            catch (Exception ex)
            {

                throw new Exception("Could not update the blogger");
            }
           
        }

       
    }
}
