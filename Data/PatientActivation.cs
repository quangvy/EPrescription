using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Data.Helper;

namespace Data
{
    public class PatientActivation
    {
        public string ConnectionString { get; set; } = "CMS";
        public string Fullname { get; set; }
        public string DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string TransactionId { get; set; }
        public string MemberType { get; set; }
        

        public PatientActivation()
        {
            
        }
        
        public IEnumerable<PatientActivation> List()
        {
            return
                SqlHelper.GetObjects<PatientActivation>("SELECT firstname+' '+lastname AS fullname, DateOfBirth, Sex,TransactionId,MemberType FROM dbo.PatientActivation WHERE (CONVERT(DATE,CreateDate))=(CONVERT(DATE,getdate()))", ConnectionString);
        }
    }
}
