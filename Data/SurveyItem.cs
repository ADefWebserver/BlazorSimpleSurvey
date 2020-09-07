using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSimpleSurvey.Data
{
    public class SurveyItem
    {
        private int _SurveyDataItemID;
        private string _ItemLabel;
        private string _ItemType;
        private string _ItemValue;
        private DateTime? _ItemDateValue;
        private bool _Required = false;

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

        public int SurveyDataItemID
        {
            get
            {
                return _SurveyDataItemID;
            }
            set
            {
                _SurveyDataItemID = value;
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
    }
}
