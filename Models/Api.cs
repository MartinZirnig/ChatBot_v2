using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.VisualBasic;
using ModelsMl.Data;
using ModelsMl.Data.Tables;
using ModelsMl.Models.Models;
using ModelsMl.Pairs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl
{
    public static class Api
    {
        private static DatabaseConnection? _connection;
        private static ModelsManager _modelsManager;


        public static void Open()
        {
            _connection = new DatabaseConnection();

            _connection.Database.EnsureCreated();

            _modelsManager = new ModelsManager();
        }

        public static void Close(bool flush = true)
        {
            if (flush) Flush();

            _connection?.Dispose();
        }


        public static string GetResponse(string input)
        {
            ThrowWhenClosed();
            return _modelsManager.GetResponse(input);
        }
        public static void Flush()
        {
            ThrowWhenClosed();

            _connection!.SaveChanges();
        }
        private static IEnumerable<CompleteConversation> GetTrainingData(bool loaded, bool ignored)
        {
            var data = _connection!.Conversations
                .Include(x => x.Input)
                .Include(x => x.Emotions)
                .Include(x => x.Format)
                .Include(x => x.Output)
                .Include(x => x.Purposes)
                .Include(x => x.Intends)
                .Include(x => x.Informations)
                .AsNoTracking();
            
            if (!loaded)
                data = data.Where(x => !x.Loaded);
            if (!ignored)
                data = data.Where(x => !x.Ignored);

            var result = data.ToList()
                .Select(data => new CompleteConversation(
                    data.Input?.Input,
                    data.Output?.Output,
                    data.Format?.Format,
                    data.Intends?.Intend.ToList(),
                    data.Purposes?.Purpose.ToList(),
                    data.Emotions?.Emotion.ToList(),
                    data.Informations?.Information.ToList(),
                    data.Loaded,
                    data.Ignored
                )
                {
                    Model = data.UsedByModel,
                    Id = data.Id,
                    CreatedAt = data.CreatedAt
                });
            return result;
        }
        private static void SetTrainingDataLoaded()
        {
            foreach (var item in _connection!.Conversations)
            {
                item.Loaded = true;
            }
            Flush();
        }
        public static void ClearDatabase(string password)
        {
            ThrowWhenClosed();

            RemoveFromSet(_connection!.Conversations);
            RemoveFromSet(_connection!.Emotions);
            RemoveFromSet(_connection!.Formats);
            RemoveFromSet(_connection!.Informations);
            RemoveFromSet(_connection!.Inputs);
            RemoveFromSet(_connection!.Intends);
            RemoveFromSet(_connection!.Outputs);
            RemoveFromSet(_connection!.Purposes);

            void RemoveFromSet(dynamic set)
            {
                foreach (var item in set)
                {
                    set.Remove(item);
                }
            }
        }

        public static async Task Train()
        {
            ThrowWhenClosed();

            await _modelsManager.Train(GetTrainingData(false, false));
            SetTrainingDataLoaded();
        }
        public static Task TrainAsync()
        {
            ThrowWhenClosed();

            return Task.Run(() => TrainModelsAsync(GetTrainingData(false, false)));
        }
        public static async Task Retrain()
        {
            ThrowWhenClosed();

            _modelsManager.Clear();
            await _modelsManager.Train(GetTrainingData(true, true));
            SetTrainingDataLoaded();
        }
        public static Task RetrainAsync()
        {
            ThrowWhenClosed();

            _modelsManager.Clear();
            return Task.Run(() => TrainModelsAsync(GetTrainingData(true, false)));


        }
        private static async Task TrainModelsAsync(IEnumerable<CompleteConversation> trainingData)
        {
            await _modelsManager.Train(trainingData);
            SetTrainingDataLoaded();
        }

        public static void TrainEverything(CompleteConversation conversation)
        {
            ThrowWhenClosed();
            conversation.Model = Model.All;
            conversation.PushToDb(_connection!);
        }
        public static void TrainEmotionsDetector(EmotionPair emotion)
        {
            ThrowWhenClosed();
            emotion.Model = Model.EmotionsDetector;
            emotion.PushToDb(_connection!);
        }
        public static void TrainFormatProvider(FormatPair format)
        {
            ThrowWhenClosed();
            format.Model = Model.FormatProvider;
            format.PushToDb(_connection!);
        }
        public static void TrainIntendIdentifier(IntendPair intend)
        {
            ThrowWhenClosed();
            intend.Model = Model.IntendIdentifier;
            intend.PushToDb(_connection!);
        }
        public static void TrainPurposeIdentifier(PurposePair purpose)
        {
            ThrowWhenClosed();
            purpose.Model = Model.PurposeIdentifier;
            purpose.PushToDb(_connection!);
        }
        public static void TrainInformationsProvider(InformationPair information)
        {
            ThrowWhenClosed();
            information.Model = Model.InformationProvider;
            information.PushToDb(_connection!);
        }
        public static void TrainOutputGenerator(OutputPair output)
        {
            ThrowWhenClosed();
            output.Model = Model.OutputGenerator;
            output.PushToDb(_connection!);
        }


        public static void SetIgnore(int id, bool state)
        {
            ThrowWhenClosed();

            var conversation = _connection!.Conversations
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (conversation is null)
                throw new InvalidOperationException("Conversation not found");
            conversation.Ignored = state;
        }
        public static void BackupDatabase(string name)
        {
            ThrowWhenClosed();
            _connection!.Backup(name);
        }
        public static void RestoreDatabase(string name)
        {
            ThrowWhenClosed();
            _connection!.Restore(name);
        }
        public static void ClearDatabase()
        {
            ThrowWhenClosed();
            _connection!.Clear();
        }
        public static IEnumerable<string> GetDatabaseBackups()
        {
            ThrowWhenClosed();
            if (Directory.Exists(DatabaseConnection.DbBackupPath))
            {
                return Directory.GetDirectories(DatabaseConnection.DbBackupPath)
                    .Select(x =>
                    {
                        var parts = x.Split(Path.DirectorySeparatorChar);
                        return parts[^1];
                    })!;
            }
            return [];
        }


        public static void BackupModel(string name)
        {
            ThrowWhenClosed();
            _modelsManager.Backup(name);
        }
        public static void RestoreModel(string name)
        {
            ThrowWhenClosed();
            _modelsManager.Restore(name);
        }
        public static void ClearModel()
        {
            ThrowWhenClosed();
            _modelsManager.Clear();
        }
        public static IEnumerable<string> GetModelsBackup()
        {
            ThrowWhenClosed();
            return _modelsManager.GetBackups();
        } 

        private static List<Conversations> GetGeneralData(int top, int skip, bool showIgnored, bool showLoaded, Model model)
        {
            ThrowWhenClosed();

            var data = _connection!.Conversations
                .Include(x => x.Input)
                .Include(x => x.Emotions)
                .Include(x => x.Format)
                .Include(x => x.Output)
                .Include(x => x.Purposes)
                .Include(x => x.Intends)
                .Include(x => x.Informations)
                .AsNoTracking();

            if (model != Model.All)
                data = data.Where(x => x.UsedByModel == model);
            if (top > 0)
                data = data.Take(top);
            if (skip > 0)
                data = data.Skip(skip);
            if (!showIgnored)
                data = data.Where(x => !x.Ignored);
            if (!showLoaded)
                data = data.Where(x => !x.Loaded);

            return data.ToList();
        }
        public static EmotionPair[] GetEmotions(int top, int skip, bool showIgnored = false, bool showLoaded = true)
        {
            var data = GetGeneralData(top, skip, showIgnored, showLoaded, Model.EmotionsDetector);
#pragma warning disable CS8604  
            return data
                .Select(x => new EmotionPair(
                    x.Input?.Input,
                    x.Emotions?
                        .Emotion
                        .ToList(),
                    x.Loaded,
                    x.Ignored)
                {
                    Model = x.UsedByModel,
                    Id = x.Id,
                    CreatedAt = x.CreatedAt
                })
                .ToArray();
#pragma warning restore CS8604  
        }
        public static CompleteConversation[] GetCompleteConversations(int top, int skip, bool showIgnored = false, bool showLoaded = true)
        {
            var data = GetGeneralData(top, skip, showIgnored, showLoaded, Model.All);

            return data
#pragma warning disable CS8604
                .Select(x => new CompleteConversation(
                    x.Input?.Input,
                    x.Output?.Output,
                    x.Format?.Format,
                    x.Intends?
                        .Intend
                        .ToList(),
                    x.Purposes?
                        .Purpose
                        .ToList(),
                    x.Emotions?
                        .Emotion
                        .ToList(),
                    x.Informations?
                        .Information
                        .ToList(),
                    x.Loaded,
                    x.Ignored
                    )
                {
                    Model = x.UsedByModel,
                    Id = x.Id,
                    CreatedAt = x.CreatedAt
                })
                .ToArray();
#pragma warning restore CS8604
        }
        public static FormatPair[] GetFormats(int top, int skip, bool showIgnored = false, bool showLoaded = true)
        {
            var data = GetGeneralData(top, skip, showIgnored, showLoaded, Model.FormatProvider);
#pragma warning disable CS8604
            return data
                .Select(x => new FormatPair(
                    x.Input?.Input,
                    x.Emotions?
                        .Emotion
                        .ToList(),
                    x.Format?.Format,
                    x.Loaded,
                    x.Ignored
                    )
                {
                    Model = x.UsedByModel,
                    Id = x.Id,
                    CreatedAt = x.CreatedAt
                })
                .ToArray();
#pragma warning restore CS8604
        }
        public static InformationPair[] GetInformation(int top, int skip, bool showIgnored = false, bool showLoaded = true)
        {
            var data = GetGeneralData(top, skip, showIgnored, showLoaded, Model.InformationProvider);
#pragma warning disable CS8604
            return data
                .Select(x => new InformationPair(
                    x.Intends?
                        .Intend
                        .ToList(),
                    x.Purposes?
                        .Purpose
                        .ToList(),
                    x.Informations?
                        .Information
                        .ToList(),
                    x.Loaded,
                    x.Ignored
                    )
                {
                    Model = x.UsedByModel,
                    Id = x.Id,
                    CreatedAt = x.CreatedAt
                })
                .ToArray();
#pragma warning restore CS8604
        }
        public static IntendPair[] GetIntends(int top, int skip, bool showIgnored = false, bool showLoaded = true)
        {
            var data = GetGeneralData(top, skip, showIgnored, showLoaded, Model.IntendIdentifier);
#pragma warning disable CS8604
            return data
                .Select(x => new IntendPair(
                    x.Input?.Input,
                    x.Intends?
                        .Intend
                        .ToList(),
                    x.Loaded,
                    x.Ignored
                    )
                {
                    Model = x.UsedByModel,
                    Id = x.Id,
                    CreatedAt = x.CreatedAt
                })
                .ToArray();
#pragma warning restore CS8604
        }
        public static OutputPair[] GetOutputs(int top, int skip, bool showIgnored = false, bool showLoaded = true)
        {
            var data = GetGeneralData(top, skip, showIgnored, showLoaded, Model.OutputGenerator);
#pragma warning disable CS8604
            return data
                .Select(x => new OutputPair(
                    x.Format?.Format,
                    x.Emotions?
                        .Emotion
                        .ToList(),
                    x.Informations?
                        .Information
                        .ToList(),
                    x.Output?.Output,
                    x.Loaded,
                    x.Ignored
                    )
                {
                    Model = x.UsedByModel,
                    Id = x.Id,
                    CreatedAt = x.CreatedAt
                })
                .ToArray();
#pragma warning restore CS8604
        }
        public static PurposePair[] GetPurposes(int top, int skip, bool showIgnored = false, bool showLoaded = true)
        {
            var data = GetGeneralData(top, skip, showIgnored, showLoaded, Model.PurposeIdentifier);
#pragma warning disable CS8604
            return data
                .Select(x => new PurposePair(
                    x.Input?.Input,
                    x.Purposes?
                        .Purpose
                        .ToList(),
                    x.Loaded,
                    x.Ignored
                    )
                {
                    Model = x.UsedByModel,
                    Id = x.Id,
                    CreatedAt = x.CreatedAt
                })
                .ToArray();
#pragma warning restore CS8604  
        }

        private static void ThrowWhenClosed()
        {
            if (_connection is null)
                throw new InvalidOperationException("Api is closed, call Open function");
        }
    }
}
