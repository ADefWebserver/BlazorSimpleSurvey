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

        // Users

        #region public IQueryable<Users> GetAllUsersAsync()
        public IQueryable<Users> GetAllUsersAsync()
        {
            return _context.Users.AsQueryable();
        }
        #endregion

        // Surveys

        #region public async Task<List<Survey>> GetAllSurveysAsync()
        public async Task<List<Survey>> GetAllSurveysAsync()
        {
            return await _context.Survey.AsNoTracking().OrderBy(x => x.SurveyName).ToListAsync();
        }
        #endregion

        #region public Task<Survey> CreateSurveyAsync(Survey NewSurvey)
        public Task<Survey> CreateSurveyAsync(Survey NewSurvey)
        {
            try
            {
                Survey objSurvey = new Survey();

                objSurvey.Id = 0;
                objSurvey.SurveyName = NewSurvey.SurveyName;
                objSurvey.UserId = NewSurvey.UserId;
                objSurvey.DateCreated = DateTime.Now;

                _context.Survey.Add(objSurvey);
                _context.SaveChanges();

                return Task.FromResult(objSurvey);
            }
            catch (Exception ex)
            {
                DetachAllEntities();
                throw ex;
            }
        }
        #endregion

        #region public Task<Survey> UpdateSurveyAsync(Survey objExistingSurvey)
        public Task<Survey> UpdateSurveyAsync(Survey objExistingSurvey)
        {
            try
            {
                var ExistingSurvey = _context.Survey
                                    .Where(x => x.Id == objExistingSurvey.Id)
                                    .FirstOrDefault();

                ExistingSurvey.SurveyName = objExistingSurvey.SurveyName;

                _context.SaveChanges();

                return Task.FromResult(ExistingSurvey);
            }
            catch (Exception ex)
            {
                DetachAllEntities();
                throw ex;
            }
        }
        #endregion

        // Utility       

        #region public async Task ExecuteSqlRaw(string sql)
        public async Task ExecuteSqlRaw(string sql)
        {
            await _context.Database.ExecuteSqlRawAsync(sql);
        }
        #endregion

        #region public void DetachAllEntities()
        public void DetachAllEntities()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();
            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
        #endregion
    }
}
