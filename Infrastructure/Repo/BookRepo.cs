using Core.Contracts;
using Core.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo;

public class BookRepo : IBookRepo
{
    private readonly ApplicationDbContext _context;
    private readonly  ILogger<BookRepo> _logger;
    public BookRepo(ApplicationDbContext context, ILogger<BookRepo> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task AddBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Book>> GetAll()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> GetById(int id)
    {
        Book book = new Book();
        try
        {
            
            book = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id) ?? throw new Exception();
            
           
        }
        catch (Exception ex)
        {
            
            _logger.LogInformation("book is not found!!");
            
           
        }
        
        return book;

    }
}
