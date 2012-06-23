using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Dapper
{
    internal static class SqlHelper
    {
        public static readonly string ConnectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=PHeart;Integrated Security=True";

        public static readonly string ReadAllStatement =
            @"SELECT * FROM {0}";

        public static readonly string ReadStatement =
            @"SELECT * FROM {0} WHERE Id = @Id";

        public static readonly string DeleteStatement = 
            @"DELETE FROM {0} WHERE Id = @id";
    }
}
