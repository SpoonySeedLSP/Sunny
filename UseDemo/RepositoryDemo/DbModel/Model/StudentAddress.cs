using Sunny.Repository.DbModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryDemo.DbModel
{
    public class StudentAddress : BaseModel
    {
       
       // public int StudentAddressId { get; set; }

        public string Address1 { get; set; }
       
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string  Country { get; set; }

        public  Student Student { get; set; }

       public long StudentId { get; set; }
    }
}
