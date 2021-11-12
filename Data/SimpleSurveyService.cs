using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Z.EntityFramework.Plus;
using BlazorSimpleSurvey.Models;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Graph;

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

        // Survey

        #region public async Task<List<Survey>> GetAllSurveysAsync()
        public async Task<List<Survey>> GetAllSurveysAsync()
        {
            return await _context.Survey
                .Include(x => x.SurveyItem)
                .ThenInclude(x => x.SurveyItemOption)
                .AsNoTracking()
                .OrderBy(x => x.SurveyName)
                .ToListAsync();
        }
        #endregion

        #region public Task<Survey?> GetSurvey(int Id)
        public Task<Survey?> GetSurvey(int Id)
        {
            return Task.FromResult(_context.Survey
                .Include(x => x.SurveyItem)
                .ThenInclude(x => x.SurveyItemOption)
                .Where(x => x.Id == Id)
                .FirstOrDefault());
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
            catch
            {
                DetachAllEntities();
                throw;
            }
        }
        #endregion

        #region public Task<Survey?> UpdateSurveyAsync(Survey objExistingSurvey)
        public Task<Survey?> UpdateSurveyAsync(Survey objExistingSurvey)
        {
            try
            {
                var ExistingSurvey = _context.Survey
                                    .Where(x => x.Id == objExistingSurvey.Id)
                                    .FirstOrDefault();

                if (ExistingSurvey != null)
                {
                    ExistingSurvey.SurveyName = objExistingSurvey.SurveyName;
                }

                _context.SaveChanges();

                return Task.FromResult(ExistingSurvey);
            }
            catch
            {
                DetachAllEntities();
                throw;
            }
        }
        #endregion

        #region public Task<bool> DeleteSurveyAsync(Survey objExistingSurvey)
        public Task<bool> DeleteSurveyAsync(Survey objExistingSurvey)
        {
            var ExistingSurvey =
                _context.Survey
                .Where(x => x.Id == objExistingSurvey.Id)
                .FirstOrDefault();

            if (ExistingSurvey != null)
            {
                _context.Survey.Remove(ExistingSurvey);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
        #endregion

        // Survey Item

        #region public async Task<List<SurveyItem>> GetAllSurveyItemsAsync(int SurveyId)
        public async Task<List<SurveyItem>> GetAllSurveyItemsAsync(int SurveyId)
        {
            return await _context.SurveyItem
                .AsNoTracking()
                .Where(x => x.SurveyNavigation.Id == SurveyId)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }
        #endregion

        #region public Task<SurveyItem?> GetSurveyItemAsync(int SurveyItemId)
        public Task<SurveyItem?> GetSurveyItemAsync(int SurveyItemId)
        {
            return Task.FromResult(_context.SurveyItem
                .Where(x => x.Id == SurveyItemId)
                .Include(x => x.SurveyItemOption)
                .FirstOrDefault());
        }
        #endregion

        #region public Task<SurveyItem> CreateSurveyItemAsync(SurveyItem NewSurveyItem)
        public Task<SurveyItem> CreateSurveyItemAsync(SurveyItem NewSurveyItem)
        {
            try
            {
                SurveyItem objSurveyItem = new SurveyItem();

                objSurveyItem.SurveyAnswer = new List<SurveyAnswer>();

                objSurveyItem.SurveyNavigation =
                    _context.Survey
                    .Where(x => x.Id == NewSurveyItem.SurveyNavigation.Id)
                    .FirstOrDefault();

                objSurveyItem.Id = 0;
                objSurveyItem.ItemLabel = NewSurveyItem.ItemLabel;
                objSurveyItem.ItemType = NewSurveyItem.ItemType;
                objSurveyItem.ItemValue = NewSurveyItem.ItemValue;
                objSurveyItem.Required = NewSurveyItem.Required;
                objSurveyItem.Position = 0;

                if (NewSurveyItem.SurveyItemOption != null)
                {
                    objSurveyItem.SurveyItemOption = NewSurveyItem.SurveyItemOption;
                }

                _context.SurveyItem.Add(objSurveyItem);
                _context.SaveChanges();

                // Set position
                int CoutOfSurveyItems =
                    _context.SurveyItem
                    .Where(x => x.SurveyNavigation.Id == NewSurveyItem.SurveyNavigation.Id)
                    .Count();

                objSurveyItem.Position = CoutOfSurveyItems;
                _context.SaveChanges();

                return Task.FromResult(objSurveyItem);
            }
            catch
            {
                DetachAllEntities();
                throw;
            }
        }
        #endregion

        #region public Task<SurveyItem?> UpdateSurveyItemAsync(SurveyItem objExistingSurveyItem)
        public Task<SurveyItem?> UpdateSurveyItemAsync(SurveyItem objExistingSurveyItem)
        {
            try
            {
                var ExistingSurveyItem = _context.SurveyItem
                                        .Where(x => x.Id == objExistingSurveyItem.Id)
                                        .Include(x => x.SurveyItemOption)
                                        .FirstOrDefault();

                if (ExistingSurveyItem != null)
                {
                    ExistingSurveyItem.ItemLabel = objExistingSurveyItem.ItemLabel;
                    ExistingSurveyItem.ItemType = objExistingSurveyItem.ItemType;
                    ExistingSurveyItem.ItemValue = objExistingSurveyItem.ItemValue;
                    ExistingSurveyItem.Required = objExistingSurveyItem.Required;

                    ExistingSurveyItem.SurveyItemOption = objExistingSurveyItem.SurveyItemOption;
                }

                _context.SaveChanges();

                return Task.FromResult(ExistingSurveyItem);
            }
            catch
            {
                DetachAllEntities();
                throw;
            }
        }
        #endregion

        #region public Task<bool> DeleteSurveyItemAsync(SurveyItem objExistingSurveyItem)
        public Task<bool> DeleteSurveyItemAsync(SurveyItem objExistingSurveyItem)
        {
            var ExistingSurveyItem =
                _context.SurveyItem
                .Where(x => x.Id == objExistingSurveyItem.Id)
                .FirstOrDefault();

            if (ExistingSurveyItem != null)
            {
                _context.SurveyItem.Remove(ExistingSurveyItem);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
        #endregion

        // Survey Answers

        #region public Task<bool> CreateSurveyAnswersAsync(DTOSurvey paramDTOSurvey)
        public Task<bool> CreateSurveyAnswersAsync(DTOSurvey paramDTOSurvey)
        {
            try
            {
                List<SurveyAnswer> SurveyAnswers = new List<SurveyAnswer>();

                if (paramDTOSurvey.SurveyItem != null)
                {
                    foreach (var SurveyItem in paramDTOSurvey.SurveyItem)
                    {
                        // Delete possible existing answer
                        var ExistingAnswers = _context.SurveyAnswer
                            .Where(x => x.SurveyItemId == SurveyItem.Id)
                            .Where(x => x.UserId == paramDTOSurvey.UserId)
                            .ToList();

                        if (ExistingAnswers != null)
                        {
                            _context.SurveyAnswer.RemoveRange(ExistingAnswers);
                            _context.SaveChanges();
                        }

                        // Save Answer

                        if (SurveyItem.ItemType != "Multi-Select Dropdown")
                        {
                            SurveyAnswer NewSurveyAnswer = new SurveyAnswer();

                            NewSurveyAnswer.AnswerValue = SurveyItem.AnswerValueString;
                            NewSurveyAnswer.AnswerValueDateTime = SurveyItem.AnswerValueDateTime;
                            NewSurveyAnswer.SurveyItemId = SurveyItem.Id;
                            NewSurveyAnswer.UserId = paramDTOSurvey.UserId;

                            _context.SurveyAnswer.Add(NewSurveyAnswer);
                            _context.SaveChanges();
                        }

                        if (SurveyItem.AnswerValueList != null)
                        {
                            foreach (var item in SurveyItem.AnswerValueList)
                            {
                                SurveyAnswer NewSurveyAnswerValueList = new SurveyAnswer();

                                NewSurveyAnswerValueList.AnswerValue = item;
                                NewSurveyAnswerValueList.SurveyItemId = SurveyItem.Id;
                                NewSurveyAnswerValueList.UserId = paramDTOSurvey.UserId;

                                _context.SurveyAnswer.Add(NewSurveyAnswerValueList);
                                _context.SaveChanges();
                            }
                        }
                    }
                }

                return Task.FromResult(true);
            }
            catch
            {
                DetachAllEntities();
                throw;
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
