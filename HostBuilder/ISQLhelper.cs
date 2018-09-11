using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HostBuilderServices
{
    public interface ISQLHelper
    {
        SqlConnection GetConnection();
        DbDataReader GetDataReader(string procedureName, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure);
        int ExecuteNonQuery(string procedureName, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure);
        DbCommand GetCommand(DbConnection connection, string commandText, CommandType commandType);
    }
}
