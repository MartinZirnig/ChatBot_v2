using Microsoft.EntityFrameworkCore;
using ModelsMl.Data;
using ModelsMl.Data.Tables;
using ModelsMl.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Pairs
{
    public record EmotionPair(
        string Input,
        List<string> Emotions,

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

            db.Inputs.Add(input);
            db.Emotions.Add(emotions);

            Conversations conversations = new Conversations()
            {
                Input = input,
                Emotions = emotions,

                Loaded = this.Loaded,
                Ignored = this.Ignored,
                UsedByModel = this.Model
            };

            db.Conversations.Add(conversations);
        }
    }
}
