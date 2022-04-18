using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicSurvey.Models
{
    public class ReadSurveyModel
    {
        public Guid QuestionID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Caption { get; set; }
        public bool IsEnable { get; set; }        
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Chosen { get; set; }
       
        
    }
}