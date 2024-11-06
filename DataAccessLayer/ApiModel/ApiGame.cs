using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.ApiModel
{
    public class ApiGame
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Released { get; set; }
        public float Rating { get; set; }
       // public string? Genre { get; set; }
    }
}