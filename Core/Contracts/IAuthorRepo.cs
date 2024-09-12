using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts;

public interface IAuthorRepo
{
    Task<List<Author>> GetAll();
    Task<Author> GetById(int id);
}
