using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Z.EntityFramework.Plus;

namespace BlazorSimpleSurvey.Data
{
    public class SimpleSurveyService
    {
        private readonly SimpleSurveyContext _context;
        private readonly IWebHostEnvironment _environment;

        public SimpleSurveyService(SimpleSurveyContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

    }
}
