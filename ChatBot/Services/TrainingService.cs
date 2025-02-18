using ModelsMl;
using ModelsMl.Pairs;

namespace ChatBot.Services
{
    public class TrainingService
    {
        private ILogger _logger;
        public TrainingService(ILogger logger)
        {
            _logger = logger;
        }
        public bool TrainEmotions(EmotionPair pair)
        {
            try
            {
                Api.TrainEmotionsDetector(pair);
                Api.Flush();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error training emotions");
                return false;
            }
        }
        public bool TrainPurposes(PurposePair pair)
        {
            try
            {
                Api.TrainPurposeIdentifier(pair);
                Api.Flush();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error training purposes");
                return false;
            }
        }
        public bool TrainIntends(IntendPair pair)
        {
            try
            {
                Api.TrainIntendIdentifier(pair);
                Api.Flush();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error training intends");
                return false;
            }
        }
        public bool TrainFormats(FormatPair pair)
        {
            try
            {
                Api.TrainFormatProvider(pair);
                Api.Flush();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error training formats");
                return false;
            }
        }
        public bool TrainInformations(InformationPair pair)
        {
            try
            {
                Api.TrainInformationsProvider(pair);
                Api.Flush();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error training informations");
                return false;
            }
        }
        public bool TrainOutputs(OutputPair pair)
        {
            try
            {
                Api.TrainOutputGenerator(pair);
                Api.Flush();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error training outputs");
                return false;
            }
        }
        public bool TrainEverything(CompleteConversation pair)
        {
            try
            {
                Api.TrainEverything(pair);
                Api.Flush();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error training everything");
                return false;
            }
        }

    }
}
