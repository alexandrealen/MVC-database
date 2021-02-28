using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GoiabinhaRoom.Models
{
    public class Goiabinha
    {

        public int id { get; set; }
        public string nome { get; set; }
        public string techLeader { get; set; }
        public int horas { get; set; }
        public int tickets { get; set; }
    }
}
