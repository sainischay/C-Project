using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
{
    internal class Payment
    {
        public int PaymentId { get; set; }
        public int StudentId { get; set; }
        public int Amount {  get; set; }
        public DateTime PaymentDate {  get; set; }
    }
}
