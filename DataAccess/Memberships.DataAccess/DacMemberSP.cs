using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using TaeM.Framework.Data;
using Memberships.Entity;

namespace Memberships.DataAccess
{
    public class DacMemberSP
    {
        private static readonly string PROVIDER_NAME = "System.Data.SqlClient";

        private static readonly string CONNECTION_STRING
            = "Data Source=localhost,32774;Initial Catalog=Product;Persist Security Info=True;User ID=sa;Password=qwert12345!;Connect Timeout=60";


        private string providerName;
        private SqlConnection connection;


        public DacMemberSP() : this(PROVIDER_NAME, CONNECTION_STRING)
        {
        }
        public DacMemberSP(string providerName, string connectionString)
        {
            this.providerName = providerName;
            this.connection = new SqlConnection(connectionString);
        }
        public DacMemberSP(string providerName, SqlConnection connection)
        {
            this.providerName = providerName;
            this.connection = connection;
        }


        /// <summary>
        /// InsertMember method
        /// - InsertMember Member table row from member information
        /// </summary>
        /// <param name="member">Member information</param>
        /// <returns></returns>
        public Member InsertMember(Member member)
        {
            try
            {
                using (connection)
                {
                    connection.Open();

                    Member ret = (Member)MsSqlDataHelperFactory.SelectSingleEntity<Member>(connection,
                        typeof(Member),
                        CommandType.StoredProcedure,
                        "Product.dbo.sp_Memberships_Insert_Member",
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@MemberName", member.MemberName, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@IsAvailable", member.IsAvailable, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@Email", member.Email, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@PhoneNumber", member.PhoneNumber, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@Address", member.Address, ParameterDirection.Input)
                        );

                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// SelectMember method
        /// - Select Member table row by memberID 
        /// </summary>
        /// <param name="memberID">Member ID</param>
        /// <returns></returns>
        public Member SelectMember(int memberID)
        {
            try
            {
                using (connection)
                {
                    connection.Open();

                    Member ret = (Member)MsSqlDataHelperFactory.SelectSingleEntity<Member>(connection,
                        typeof(Member),
                        CommandType.StoredProcedure,
                        "Product.dbo.sp_Memberships_Select_Member_By_MemberID", 
                        MsSqlParameterHelperFactory.CreateParameter<SqlDbType>(providerName, "@MemberID", memberID, SqlDbType.Int, ParameterDirection.Input)
                        );

                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// SelectMembers method
        /// - Select Member table rows by memberName 
        /// </summary>
        /// <param name="memberName">Member name</param>
        /// <returns></returns>
        public List<Member> SelectMembers(string memberName)
        {
            try
            {
                using (connection)
                {
                    connection.Open();

                    List<Member> ret = (List<Member>)MsSqlDataHelperFactory.SelectMultipleEntities<Member>(connection,
                        typeof(Member),
                        CommandType.StoredProcedure,
                        "Product.dbo.sp_Memberships_Select_Members_By_MemberName",      
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@MemberName", memberName, ParameterDirection.Input)
                        );

                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// SelectNumsOfMembers method
        /// - Select number of Member table rows by memberName 
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public int SelectNumsOfMembers(string memberName)
        {
            try
            {
                using (connection)
                {
                    connection.Open();

                    int ret = (int)MsSqlDataHelperFactory.SelectScalar(connection,
                        CommandType.StoredProcedure,
                        "Product.dbo.sp_Memberships_Select_Num_Of_Members_By_MemberName",
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@MemberName", memberName, ParameterDirection.Input)
                        );

                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// UpdateMember method
        /// - Update Member table row by member information
        /// </summary>
        /// <param name="member">Member information</param>
        /// <returns></returns>
        public bool UpdateMember(Member member)
        {
            try
            {
                using (connection)
                {
                    connection.Open();

                    int ret = MsSqlDataHelperFactory.Execute(connection,
                        CommandType.StoredProcedure,
                        "Product.dbo.sp_Memberships_Update_Member",
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@MemberName", member.MemberName, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@IsAvailable", member.IsAvailable, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@Email", member.Email, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@PhoneNumber", member.PhoneNumber, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@Address", member.Address, ParameterDirection.Input),
                        MsSqlParameterHelperFactory.CreateParameter(providerName, "@MemberID", member.MemberID, ParameterDirection.Input)
                        );

                    return (ret == 1) ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DeleteMember() method
        /// - Delete Member table row by memberID
        /// </summary>
        /// <param name="memberID">Member ID</param>
        /// <returns></returns>
        public bool DeleteMember(int memberID)
        {
            try
            {
                using (connection)
                {
                    connection.Open();

                    int ret = MsSqlDataHelperFactory.Execute(connection,
                        CommandType.StoredProcedure,
                        "Product.dbo.sp_Memberships_Delete_Member_By_MemberID",
                        MsSqlParameterHelperFactory.CreateParameter<SqlDbType>(providerName, "@MemberID", memberID, SqlDbType.Int, ParameterDirection.Input)
                        );

                    return (ret == 1) ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}