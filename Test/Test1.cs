using ModelsMl.Data.Tables;
using ModelsMl.Models.Data.InputData;
using ModelsMl.Models.Data.SourceData;
using ModelsMl.Models.Models;
using System.Diagnostics;

namespace Test
{
    [TestClass]
    public sealed class TestAI
    {
        [TestMethod]
        public void TestEmotions()
        {
            ChatbotModel<List<EmotionsSourceData>, List<object>, ReferedString>.EnsureDirectoryExists();

            var model = new EmotionsDetector();
            model.TrainAndSave(new List<EmotionsSourceData>
            {
                new EmotionsSourceData()
                {
                    Input = "I am happy",
                    Emotions = new string[] { "happy" }
                }
            });

            Debug.WriteLine(model.Predict("I am so happy"));
        }
    }
}
