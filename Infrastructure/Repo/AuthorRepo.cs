using Core.Contracts;
using Core.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo;

public class AuthorRepo : IAuthorRepo
{
    private readonly ApplicationDbContext _context;
    public AuthorRepo(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    public async Task<List<Author>> GetAll()
    {
        return await _context.Authors.ToListAsync();

    }

    public async Task<Author> GetById(int id)
    {
        Author author = new Author();
        try
        {

            author = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == id) ?? throw new Exception();


        }
        catch (Exception ex)
        {

            // _logger.LogInformation("book is not found!!");


        }

        return author;

    }
}
