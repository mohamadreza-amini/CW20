using Core.Contracts;
using Core.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

public class BookService : IBookService
{
    private readonly IBookRepo _bookRepo;

    private readonly IAuthorRepo _authorRepo;
    public BookService(IBookRepo bookRepo,IAuthorRepo authorRepo)
    {
        _bookRepo = bookRepo;
        _authorRepo = authorRepo;
    }
    public async Task AddBook(Book book)
    {
        try
        {
            await ValidateAuthorExpertibility(book);
            await _bookRepo.AddBook(book);
        }
        catch (Exception ex)
        {
            Console.WriteLine("book can't be add because author isn't expert");
        }
       
    }

    private async Task ValidateAuthorExpertibility(Book book)
    {
       
            foreach (var author in book.Authors)
            {
                var resut = await _authorRepo.GetById(author.AuthorId);
                if (resut.IsExpert == false && book.IsExpert == true)
                {
                    throw new Exception();
                }
            }
        
    }

    public async Task<List<Book>> GetAll()
    {
        return await _bookRepo.GetAll();
    }

    public async Task<Book> GetById(int id)
    {
        return await _bookRepo.GetById(id);
    }
}
