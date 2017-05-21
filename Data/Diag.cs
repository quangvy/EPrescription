using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Data.Helper;

namespace Data
{
    public class Diag
    {
        public string ConnectionString { get; set; } = "CMS";
        public string Diag_code { get; set; }
        public string Diag_name { get; set; }
        

        public Diag()
        {
            
        }
       
        public IEnumerable<Diag> List()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@diag", Diag_name);
            return
                SqlHelper.GetObjects<Diag>("SELECT * FROM dbo.diag_list where diag_name like '%'+@diag+'%'", ConnectionString,parameters);
        }
    }
}
