using ChatBot.Models;
using ModelsMl;
using ModelsMl.Data;
using ModelsMl.Pairs;

namespace ChatBot.Services
{
    public class DatabaseService
    {
        private Dictionary<Model, Func<int, int, bool, bool, StateInfo[]>> _navigation;
        private ILogger _logger;
        public DatabaseService(ILogger logger)
        {
            _logger = logger;
            _navigation = new Dictionary<Model, Func<int, int, bool, bool, StateInfo[]>>
            {
                { Model.All, Api.GetCompleteConversations },
                { Model.EmotionsDetector, Api.GetEmotions },
                { Model.FormatProvider, Api.GetFormats },
                { Model.IntendIdentifier, Api.GetIntends },
                { Model.PurposeIdentifier, Api.GetPurposes },
                { Model.InformationProvider, Api.GetInformation },
                { Model.OutputGenerator, Api.GetOutputs }
            };
        }


        public StateInfo[] GetTrainData(int top, int skip, bool showIgnored, bool showLoaded, Model model)
        {
            try
            {
                var func = _navigation[model];
                var data = func(top, skip, showIgnored, showLoaded);
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting training data");
                return null;
            }
        }
        public bool UpdateIgnore(int id, bool ignore)
        {
            try
            {
                Api.SetIgnore(id, ignore);
                Api.Flush();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating ignore");
                return false;
            }
        }

        public bool Backup(DatabaseName name)
        {
            try
            {
                Api.BackupDatabase(name.Name);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error backing up database");
                return false;
            }
        }
        public bool Restore(DatabaseName name)
        {
            try
            {
                Api.RestoreDatabase(name.Name);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring database");
                return false;
            }
        }
        public bool Clear()
        {
            try
            {
                Api.ClearDatabase();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error clearing database");
                return false;
            }
        }
        public IEnumerable<string> GetBackups()
        {
            try
            {
                var result = Api.GetDatabaseBackups();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting backups");
                return [];
            }
        }
    }
}
