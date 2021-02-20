using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _context;        

        public UnitOfWork(SocialMediaContext context)
        {
            _context = context;
        }

        public IPostRepository PostRepository => new PostRepository(_context);

        public IRepository<User> UserRepository =>  new BaseRepository<User>(_context);

        public IRepository<Comment> CommentRepository =>  new BaseRepository<Comment>(_context);

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
