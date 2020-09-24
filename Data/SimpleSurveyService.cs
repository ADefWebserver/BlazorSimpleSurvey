using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Z.EntityFramework.Plus;
using BlazorSimpleSurvey.Models;

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

        #region public async Task<List<Survey>> GetAllSurveysAsync()
        public async Task<List<Survey>> GetAllSurveysAsync()
        {
            return await _context.Survey.AsNoTracking().OrderBy(x => x.SurveyName).ToListAsync();
        }
        #endregion

    }
}
