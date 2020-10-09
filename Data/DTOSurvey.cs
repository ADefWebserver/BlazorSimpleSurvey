using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSimpleSurvey.Data
{
    public class DTOSurvey
    {
        public int Id { get; set; }
        public string SurveyName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int UserId { get; set; }
        public List<DTOSurveyItem> SurveyItem { get; set; }
    }
    public class DTOSurveyItem
    {
        public int Id { get; set; }
        public string ItemLabel { get; set; }
        public string ItemType { get; set; }
        public string ItemValue { get; set; }
        public int Position { get; set; }
        public int Required { get; set; }
        public int? SurveyChoiceId { get; set; }             
        public string AnswerValueString { get; set; }
        public DateTime? AnswerValueDateTime { get; set; }
        public List<DTOSurveyItemOption> SurveyItemOption { get; set; }
    }
    public partial class DTOSurveyItemOption
    {
        public int Id { get; set; }
        public string OptionLabel { get; set; }
    }
}
