using Dapper;
using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LibraryRepo : ILibraryRepo
    {
        private readonly LibraryDBContext _dbContext;

        public LibraryRepo(LibraryDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Book> GetBookById(int id)
        {
            using (var connection = _dbContext.CreateConnection())
            {
                var paramsBook = new DynamicParameters();
                paramsBook.Add("@pId", id);
                var book = await connection.QueryFirstOrDefaultAsync<Book>("GetBookById", paramsBook, commandType: System.Data.CommandType.StoredProcedure);
                return book;
            }
        }
    }
}
