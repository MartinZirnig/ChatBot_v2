using Microsoft.EntityFrameworkCore;
using ModelsMl.Data;
using ModelsMl.Data.Tables;
using ModelsMl.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Pairs
{
    public record FormatPair(
        string Input,
        List<string> Emotions,
        string Format,

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
            var emotions = new Emotions()
            {
                Emotion = this.Emotions.ToList(),
            };
            var format = new Formats()
            {
                Format = this.Format,
            };

            db.Inputs.Add(input);
            db.Emotions.Add(emotions);
            db.Formats.Add(format);


            Conversations conversations = new Conversations()
            {
                Input = input,
                Emotions = emotions,
                Format = format,

                Loaded = this.Loaded,
                Ignored = this.Ignored,
                UsedByModel = this.Model
            };

            db.Conversations.Add(conversations);
        }
    }
}
