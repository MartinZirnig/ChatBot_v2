using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using ModelsMl.Models.Data.SourceData;
using ModelsMl.Models.Data.SourceData.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Models.Models
{
    internal abstract class GeneralMlModel
    {
        private MLContext _mlContext;
        private ITransformer? _model;
        private IDataView? _data;
        //private DataViewSchema _schema;
        private string _modelName { get; init; }
        public GeneralMlModel()
        {
            _modelName = InitializePath();
            _mlContext = new MLContext();


            string modelPath = GetModelPath();
            _model = File.Exists(modelPath)
                ? _mlContext.Model.Load(GetModelPath(), out _)
                : null;
        }
        public void InitWhenEmpty()
        {
            if (_model is null)
            {
                Train(DefaultTrain());
                Save();
            }
        }

        protected virtual string InitializePath()
        {
            return GetType().Name;
        }
        private string GetModelPath()
        {
            return Path.Combine(MlRootPath, $"{_modelName}.AI");
        }


        protected abstract IEnumerable<IDataSource> DefaultTrain();


        public string Predict(string input)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<InputDataPair, OutputDataPair>(_model);

            var modelInput = new InputDataPair()
            {
                InputText = input
            };
            var prediction = predictionEngine.Predict(modelInput);

            return prediction.PredictedLabel;
        }
        public virtual void Train(IEnumerable<IDataSource> input)
        {
            _data = _mlContext.Data.LoadFromEnumerable(input.Select(x => x.ToPair()));

            var pipeline = _mlContext.Transforms.Text.FeaturizeText(
                    outputColumnName: "Features",
                    inputColumnName: nameof(InputDataPair.InputText))
                .Append(_mlContext.Transforms.Conversion.MapValueToKey(
                    outputColumnName: "LabelKey",
                    inputColumnName: nameof(InputDataPair.Label)))
                .Append(_mlContext.MulticlassClassification.Trainers.NaiveBayes(
                    labelColumnName: "LabelKey",
                    featureColumnName: "Features"))

                .Append(_mlContext.Transforms.Conversion.MapKeyToValue(
                    outputColumnName: nameof(OutputDataPair.PredictedLabel),
                    inputColumnName: "PredictedLabel"));

            _model = pipeline.Fit(_data);
        }
        public void Save(string path)
        {
            _mlContext.Model.Save(_model, _data.Schema, path);
        }
        public void Save()
        {
            Save(GetModelPath());
        }

        public static string MlRootPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MachineLearningModel");
        public static string MlBackupPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MachineLearningModel", "Backup");

        public static void EnsureCorrectState()
        {
            Environment.SetEnvironmentVariable("MLNET_MAX_THREAD", Environment.ProcessorCount.ToString());

            if (!Directory.Exists(MlRootPath))
            {
                Directory.CreateDirectory(MlRootPath);
            }
            if (!Directory.Exists(MlBackupPath))
            {
                Directory.CreateDirectory(MlBackupPath);
            }
        }
    }
}
