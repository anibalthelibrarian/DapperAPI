﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LibraryDBContext
    {
        private ConnectionStringsOptions _connectionStringsOptions;
        public LibraryDBContext(IOptionsMonitor<ConnectionStringsOptions> optionsMonitor)
        {
            _connectionStringsOptions = optionsMonitor.CurrentValue;
        }

        public SqlConnection CreateConnection() => new SqlConnection(_connectionStringsOptions.LibraryDB);
    }
}
