using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPeopleRepo
    {
        Task<Author> GetAuthorById(Guid id);
    }
}
