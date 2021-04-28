using AyaksApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyaksApplication.Repositoryes
{
    public class RealtorsRepository
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext context;

        public RealtorsRepository(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            this.context = context;
        }

        public List<Realtors> GetAllRealtors()
        {
            var realtors = context.Realtors
                .Include(x => x.Division)
                .ToList();

            return realtors;
        }

        public List<Realtors> GetAllRealtors(int page, int size)
        {
            var realtors = context.Realtors
                .Skip((page - 1) * size)
                .Take(size)
                .Include(x => x.Division)
                .ToList();

            return realtors;
        }

        public void Add(Realtors realtors)
        {
            context.Realtors.Add(realtors);
            context.SaveChanges();
        }

        public void Update(Realtors realtors)
        {
            context.Realtors.Update(realtors);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var message = context.Realtors.FirstOrDefault(x => x.Id == id);

            context.Realtors.Remove(message);
            context.SaveChanges();
        }

        public Realtors Get(int id)
        {
            return (context.Realtors.FirstOrDefault(x => x.Id == id));
        }
    }
}
