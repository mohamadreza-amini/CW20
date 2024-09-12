﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts;

public interface IBookRepo
{
    Task<List<Book>> GetAll();
    Task<Book> GetById(int id);

    Task AddBook(Book book);
}
