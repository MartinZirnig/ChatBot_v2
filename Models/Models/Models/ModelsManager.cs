using Microsoft.ML.Trainers;
using ModelsMl.Data;
using ModelsMl.Data.Tables;
using ModelsMl.Models.Data.SourceData;
using ModelsMl.Models.Models.Models;
using ModelsMl.Pairs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Models.Models
{
    internal class ModelsManager
    {
        private EmotionsDetector _emotions;
        private FormatProvider _format;
        private InformationsProvider _informations;
        private IntendIdentifier _intend;
        private OutputGenerator _output;
        private PurposeIdentifier _purpose;

        private Dictionary<Model, Action<IEnumerable<CompleteConversation>>> _navigation;

        public ModelsManager()
        {
            GeneralMlModel.EnsureCorrectState();

            _emotions = new EmotionsDetector();
            _format = new FormatProvider();
            _informations = new InformationsProvider();
            _intend = new IntendIdentifier();
            _output = new OutputGenerator();
            _purpose = new PurposeIdentifier();


            Task.Run(_emotions.InitWhenEmpty);
            Task.Run(_format.InitWhenEmpty);
            Task.Run(_informations.InitWhenEmpty);
            Task.Run(_intend.InitWhenEmpty);
            Task.Run(_output.InitWhenEmpty);
            Task.Run(_purpose.InitWhenEmpty);


            _navigation = new Dictionary<Model, Action<IEnumerable<CompleteConversation>>>
            {
                {Model.All,  TrainAll},

                {Model.EmotionsDetector,  TrainEmotions},
                {Model.FormatProvider,  TrainFormat},
                {Model.InformationProvider,  TrainInformations},
                {Model.IntendIdentifier,  TrainIntend},
                {Model.OutputGenerator,  TrainOutput},
                {Model.PurposeIdentifier,  TrainPurpose}
            };
        }


        public string GetResponse(string input)
        {
            var emotions = _emotions.Predict(input);
            var intends = _intend.Predict(input);
            var purposes = _purpose.Predict(input);

            var format = _format.Predict($"Input:'{input}',Emotions:'{emotions}'");
            var informations = _informations.Predict($"Intends:'{intends}',Purposes:'{purposes}'");

            var output = _output.Predict($"Format:'{format}',Emotions:'{emotions}',Informations:'{informations}'");
            return output;
        }

        public async Task Train(IEnumerable<CompleteConversation> conversations)
        {
            /*
            ConcurrentDictionary<Model, ConcurrentBag<CompleteConversation>> map = new();

            Parallel.ForEach(conversations, x =>
            {
                if (!map.ContainsKey(x.Model))
                    map[x.Model] = new ConcurrentBag<CompleteConversation>();

                map[x.Model].Add(x);
            });
            */
            Dictionary<Model, List<CompleteConversation>> map = new();
            foreach ( var conversation in conversations)
            {
                if (!map.ContainsKey(conversation.Model))
                    map[conversation.Model] = new List<CompleteConversation>();
                map[conversation.Model].Add(conversation);
            }

            List<Task> tasks = new List<Task>();

            foreach (var item in map.Keys)
                tasks.Add(Task.Run(() => _navigation[item](map[item])));

            await Task.WhenAll(tasks.ToArray());

        }

        private void TrainAll(IEnumerable<CompleteConversation> conversations)
        {
            TrainEmotions(conversations);
            TrainFormat(conversations);
            TrainInformations(conversations);
            TrainIntend(conversations);
            TrainOutput(conversations);
            TrainPurpose(conversations);
        }
        private void TrainEmotions(IEnumerable<CompleteConversation> conversations)
        {
            this._emotions.Train(conversations
                .Select(x => new EmotionsDataSource()
                {
                    Emotions = x.Emotions,
                    Input = x.Input
                }));
            this._emotions.Save();
        }
        private void TrainFormat(IEnumerable<CompleteConversation> conversations)
        {
            this._format.Train(conversations
                .Select(x => new FormatDataSource()
                {
                    Input = x.Input,
                    Emotions = x.Emotions,
                    Format = x.Format
                }));
            this._format.Save();
        }
        private void TrainInformations(IEnumerable<CompleteConversation> conversations)
        {
            this._informations.Train(conversations
                .Select(x => new InformationsDataSource()
                {
                    Intends = x.Intends,
                    Informations = x.Informations,
                    Purposes = x.Purposes
                }));
            this._informations.Save();
        }
        private void TrainIntend(IEnumerable<CompleteConversation> conversations)
        {
            this._intend.Train(conversations
                .Select(x => new IntendsDataSource()
                {
                    Input = x.Input,
                    Intends = x.Intends
                }));
            this._intend.Save();
        }
        private void TrainOutput(IEnumerable<CompleteConversation> conversations)
        {
            this._output.Train(conversations
                .Select(x => new OutputDataSource()
                {
                    Format = x.Format,
                    Emotions = x.Emotions,
                    Informations = x.Informations,
                    Output = x.Output
                }));
            this._output.Save();
        }
        private void TrainPurpose(IEnumerable<CompleteConversation> conversations)
        {
            this._purpose.Train(conversations
                .Select(x => new PurposeDataSource()
                {
                    Input = x.Input,
                    Purposes = x.Purposes
                }));
            this._purpose.Save();
        }


        public void Backup(string name)
        {
            string sourcePath = GeneralMlModel.MlRootPath;
            string destinationPath = Path.Combine(GeneralMlModel.MlBackupPath, name);
            if (!Directory.Exists(destinationPath))
                Directory.CreateDirectory(destinationPath);

            foreach (var file in Directory.GetFiles(sourcePath))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationPath, fileName);
                File.Copy(file, destFile, true);
            }

        }
        public void Restore(string name)
        {
            string destinationPath = GeneralMlModel.MlRootPath;
            string sourcePath = Path.Combine(GeneralMlModel.MlBackupPath, name);

            if (Directory.Exists(sourcePath))
            {
                foreach (var file in Directory.GetFiles(sourcePath))
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(destinationPath, fileName);
                    File.Copy(file, destFile, true);
                }
            }
        }
        public void Clear()
        {
            Backup($"ClBckAi_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}");

            foreach (var item in Directory.GetFiles(GeneralMlModel.MlRootPath))
            {
                File.Delete(item);
            }

            _emotions = new EmotionsDetector();
            _format = new FormatProvider();
            _informations = new InformationsProvider();
            _intend = new IntendIdentifier();
            _output = new OutputGenerator();
            _purpose = new PurposeIdentifier();
        }
        public IEnumerable<string> GetBackups()
        {
            return Directory.GetDirectories(GeneralMlModel.MlBackupPath)
                .Select(x =>
                {
                    var parts = x.Split(Path.DirectorySeparatorChar);
                    return parts[^1];
                });
        }
    }
}
