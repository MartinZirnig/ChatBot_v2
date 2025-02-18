using Microsoft.EntityFrameworkCore;
using ModelsMl.Data;
using ModelsMl.Data.Tables;
using ModelsMl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Pairs
{
    public record CompleteConversation(
        string? Input,
        string? Output,
        string? Format,
        List<string>? Intends,
        List<string>? Purposes,
        List<string>? Emotions,
        List<string>? Informations,

        bool Loaded,
        bool Ignored
        )
        : StateInfo(Loaded, Ignored)
    {
        internal override void PushToDb(DatabaseConnection db)
        {
            var input = new Inputs()
            {
                Input = this.Input,
            };
            var output = new Outputs()
            {
                Output = this.Output,
            };
            var format = new Formats()
            {
                Format = this.Format,
            };
            var intends = new Intends()
            {
                Intend = this.Intends.ToList()
            };
            var purposes = new Purposes()
            {
                Purpose = this.Purposes.ToList()
            };
            var emotions = new Emotions()
            {
                Emotion = this.Emotions.ToList()
            };
            var informations = new Informations()
            {
                Information = this.Informations.ToList()
            };

            db.Inputs.Add(input);
            db.Outputs.Add(output);
            db.Formats.Add(format);
            db.Intends.Add(intends);
            db.Purposes.Add(purposes);
            db.Emotions.Add(emotions);
            db.Informations.Add(informations);

            db.Conversations.Add(new Conversations()
            {
                Input = input,
                Output = output,
                Format = format,
                Intends = intends,
                Purposes = purposes,
                Emotions = emotions,
                Informations = informations,

                Loaded = this.Loaded,
                Ignored = this.Ignored,
                UsedByModel = this.Model
            });
        }
    }
}
