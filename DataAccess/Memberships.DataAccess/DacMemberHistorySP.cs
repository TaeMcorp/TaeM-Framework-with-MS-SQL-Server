using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using TaeM.Framework.Data;
using Memberships.Entity;

namespace Memberships.DataAccess
{
    public class DacMemberHistorySP
    {
        private static readonly string PROVIDER_NAME = "System.Data.SqlClient";

        private static readonly string CONNECTION_STRING
            = "Data Source=localhost,32774;Initial Catalog=Product;Persist Security Info=True;User ID=sa;Password=qwert12345!;Connect Timeout=60";


        private string providerName;
        private SqlConnection connection;


        public DacMemberHistorySP() : this(PROVIDER_NAME, CONNECTION_STRING)
        {
        }
        public DacMemberHistorySP(string providerName, string connectionString)
        {
            this.providerName = providerName;
            this.connection = new SqlConnection(connectionString);
        }
        public DacMemberHistorySP(string providerName, SqlConnection connection)
        {
            this.providerName = providerName;
            this.connection = connection;
        }


        /// <summary>
        /// InsertMemberHistory method
        /// - Insert MemberHistory table row from member history information
        /// </summary>
        /// <param name="member">Member history information</param>
        /// <returns></returns>
        public MemberHistory InsertMemberHistory(MemberHistory memberHistory)
        {
            try
            {
                using (connection)
                {
                    connection.Open();

                    return (MemberHistory)MsSqlDataHelperFactory.SelectSingleEntity<MemberHistory>(connection,
                        typeof(MemberHistory),
                        CommandType.StoredProcedure,
                        "Product.dbo.sp_Memberships_Insert_MemberHistory",
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@MemberID", memberHistory.MemberID, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@MemberName", memberHistory.MemberName, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@Successful", memberHistory.IsSuccess, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@Message", memberHistory.Message, ParameterDirection.Input)
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// SelectMemberHistories() method
        /// - Select MemberHistory table row by fromDate and toDate 
        /// </summary>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <returns></returns>
        public List<MemberHistory> GetMemberHistories(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (connection)
                {
                    connection.Open();

                    return (List<MemberHistory>)MsSqlDataHelperFactory.SelectMultipleEntities<MemberHistory>(connection,
                        typeof(MemberHistory),
                        CommandType.StoredProcedure,
                        "Product.dbo.sp_Memberships_Select_MemberHistory_By_FromToDate",
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@FromDate", fromDate, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@ToDate", toDate, ParameterDirection.Input)
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}