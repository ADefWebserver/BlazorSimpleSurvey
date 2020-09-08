using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSimpleSurvey.Data
{
    public class SurveyItem
    {
        private int _SurveyItemId;
        private string _ItemLabel;
        private string _ItemType;
        private string _ItemValue;
        private DateTime? _ItemDateValue;
        private bool _Required = false;
        private List<SurveyItemOption> _SurveyItemOptions;

        //  initialization
        public SurveyItem()
        {
        }

        //  public properties
        public string ItemLabel
        {
            get
            {
                return _ItemLabel;
            }
            set
            {
                _ItemLabel = value;
            }
        }

        public string ItemType
        {
            get
            {
                return _ItemType;
            }
            set
            {
                _ItemType = value;
            }
        }

        public string ItemValue
        {
            get
            {
                return _ItemValue;
            }
            set
            {
                _ItemValue = value;
            }
        }

        public DateTime? ItemDateValue
        {
            get
            {
                return _ItemDateValue;
            }
            set
            {
                _ItemDateValue = value;
            }
        }

        public int SurveyItemId
        {
            get
            {
                return _SurveyItemId;
            }
            set
            {
                _SurveyItemId = value;
            }
        }

        public bool Required
        {
            get
            {
                return _Required;
            }
            set
            {
                _Required = value;
            }
        }

        public List<SurveyItemOption> SurveyItemOptions
        {
            get
            {
                return _SurveyItemOptions;
            }
            set
            {
                _SurveyItemOptions = value;
            }
        }
    }
    public class SurveyItemOption
    {
        public string SurveyItemOptionId { get; set; }
        public string OptionLabel { get; set; }
    }
}
