using System;
using TaeM.Framework.Data.MsSql;

namespace Memberships.Entity
{
    public class MemberHistory
    {
        public MemberHistory()
            : this(-1, string.Empty, false, string.Empty)
        {
        }

        public MemberHistory(int memberID, string memberName, bool isSuccess, string message)
            : this(-1, memberID, memberName, isSuccess, message, DateTime.MinValue)
        {
        }

        public MemberHistory(int seq, int memberID, string memberName,
            bool isSuccess, string message, DateTime insertedDate)
        {
            this.Seq = seq;
            this.MemberID = memberID;
            this.MemberName = memberName;

            this.IsSuccess = isSuccess;
            this.Message = message;
            this.InsertedDate = insertedDate;
        }

        [MsSqlDataBinder("Sequence")]
        public int Seq { get; set; }

        [MsSqlDataBinder("MemberID")]
        public int MemberID { get; set; }

        [MsSqlDataBinder("MemberName")]
        public string MemberName { get; set; }

        [MsSqlDataBinder("Successful")]
        public bool IsSuccess { get; set; }

        [MsSqlDataBinder("Message")]
        public string Message { get; set; }

        [MsSqlDataBinder("InsertedDate")]
        public DateTime InsertedDate { get; set; }
    }
}