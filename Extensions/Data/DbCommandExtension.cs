using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace SXpowertools.Extensions
{
    public static class DbCommandExtension
    {
        /// <summary>
        /// <para>DE: Fügt einen Parameter hinzu.</para>
        /// <para>EN: Adds the parameter.</para>
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DbParameter AddParameter(this DbCommand cmd, string parameterName, object value)
        {
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = parameterName;
            if (value == null)
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = value;
            }
            cmd.Parameters.Add(param);

            return param;
        }

        /// <summary>
        /// <para>DE: Fügt einen Parameter hinzu.</para>
        /// <para>EN: Adds the parameter.</para>
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <returns></returns>
        public static DbParameter AddParameter(this DbCommand cmd, string parameterName, object value, DbType dbType)
        {
            DbParameter param = cmd.CreateParameter();
            param.DbType = dbType;
            param.ParameterName = parameterName;
            if (value == null)
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = value;
            }
            cmd.Parameters.Add(param);

            return param;
        }

        /// <summary>
        /// <para>DE: Fügt einen Parameter hinzu.</para>
        /// <para>EN: Adds the parameter.</para>
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static DbParameter AddParameter(this DbCommand cmd, string parameterName, object value, DbType dbType, int size)
        {
            return AddParameter(cmd, parameterName, value, dbType, size, ParameterDirection.Input);
        }

        /// <summary>
        /// <para>DE: Fügt einen Parameter hinzu.</para>
        /// <para>EN: Adds the parameter.</para>
        /// </summary>
        /// <param name="cmd">The CMD.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="value">The value.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="size">The size.</param>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        public static DbParameter AddParameter(this DbCommand cmd, string parameterName, object value, DbType dbType, int size, ParameterDirection direction)
        {
            DbParameter param = cmd.CreateParameter();
            param.DbType = dbType;
            param.Direction = direction;
            param.ParameterName = parameterName;
            param.Size = size;
            if (value == null)
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = value;
            }
            cmd.Parameters.Add(param);

            return param;
        }
    }
}
