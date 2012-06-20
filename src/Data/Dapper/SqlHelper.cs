using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Dapper
{
    internal static class SqlHelper
    {
        public static readonly string ConnectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=Plog;Integrated Security=True";

        public static readonly string ReadAllStatement =
            "SELECT * FROM {0}";

        public static readonly string ReadStatement =
            "SELECT * FROM {0} WHERE Id = @Id";
    }
}
