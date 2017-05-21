using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Data.Helper;

namespace Data
{
    public class Drug
    {
        public string ConnectionString { get; set; } = "UFPharma";
        //public string Fullname { get; set; }
        //public string DateOfBirth { get; set; }
        //public string Sex { get; set; }
        //public string TransactionId { get; set; }
        //public string MemberType { get; set; }
        

        public Drug()
        {
            
        }
        
        public IEnumerable<Drug> List()
        {
            return
                SqlHelper.GetObjects<Drug>("SELECT * from DrugDispo", ConnectionString);
        }
    }
}
