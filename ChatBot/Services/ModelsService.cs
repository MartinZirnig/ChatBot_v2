using ChatBot.Models;
using ModelsMl;

namespace ChatBot.Services
{
    public class ModelsService
    {
        private ILogger _logger;
        public ModelsService(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<string> GetModelsBackup()
        {
            try
            {
                var result = Api.GetModelsBackup();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting models backup");
                return [];
            }
        }
        public bool RestoreModel(ModelsName model)
        {
            try
            {
                Api.RestoreModel(model.Name);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring model");
                return false;
            }
        }
        public bool BackupModel(ModelsName name)
        {
            try
            {
                Api.BackupModel(name.Name);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error backing up model");
                return false;
            }
        }
        public bool ClearModel()
        {
            try
            {
                Api.ClearModel();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting model");
                return false;
            }

        }


        public bool Train()
        {
            try
            {
                Api.TrainAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error training model");
                return false;
            }
        }
        public bool ReTrain()
        {
            try
            {
                Api.RetrainAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error training model");
                return false;
            }
        }
    }
}
