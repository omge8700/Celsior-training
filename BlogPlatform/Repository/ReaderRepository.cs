using BlogPlatform.Context;
using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BlogPlatform.Repository
{
    public class ReaderRepository: IRepository<int,Reader>
    {

        private readonly BlogPlatformContext _context;

        public ReaderRepository(BlogPlatformContext context)
        {
            _context = context;
            
        }

        public async Task<Reader> Add(Reader entity)
        {

            try
            {
                var readblogpost = _context.Readers.FirstOrDefault(x => x.userId==entity.userId);
                if (readblogpost == null)
                {

                    await _context.Readers.AddAsync(entity);
                    await _context.SaveChangesAsync();
                    return entity;
                }
                else
                {
                    throw new InvalidExpressionException("Reader already exits");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Reader already exits");
            }


        }

        public async Task<Reader> Delete(int key)
        {
            var deletereader = await Get(key);
            if (deletereader != null)
            { 

                _context.Readers.Remove(deletereader);
                await _context.SaveChangesAsync();
                return deletereader;

            }

            throw new Exception("Reader Details is unavilable");
            
        }

        public async Task<Reader> Get(int key)
        {
            var readerdetail = _context.Readers.FirstOrDefault(x=>x.userId==key);
            
           return readerdetail;

    }

        public async Task<IEnumerable<Reader>> GetAll()
        {
            var readerdetaills = _context.Readers.ToList();
            if (readerdetaills.Any())
            {
                return readerdetaills;
            }
            throw new Exception("BlogPosts Collection is empty");
        }

        public async Task<Reader> Update(Reader entity, int key)
        {
            var updatereaderdetails = await Get(key);
            if (updatereaderdetails != null)
            {
                updatereaderdetails.Avatar = entity.Avatar;
                updatereaderdetails.PersonalInfo = entity.PersonalInfo;
                updatereaderdetails.commentonpost = entity.commentonpost;

                await _context.SaveChangesAsync();
                return updatereaderdetails;
            }

            throw new Exception("Update failed");
        }
    }
}
