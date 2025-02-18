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
    public record OutputPair(
        string Format,
        List<string> Emotions,
        List<string> Informations,
        string Output,

        bool Loaded,
        bool Ignored
        )
        : StateInfo(Loaded, Ignored)
    {
        internal override void PushToDb(DatabaseConnection db)
        {
            var val = new Conversations()
            {
                Format = new Formats()
                {
                    Format = this.Format,
                },
                Emotions = new Emotions()
                {
                    Emotion = this.Emotions.ToList(),
                },
                Informations = new Informations()
                {
                    Information = this.Informations.ToList(),
                },
                Output = new Outputs()
                {
                    Output = this.Output,
                },
                Loaded = this.Loaded,
                Ignored = this.Ignored,
                UsedByModel = this.Model
            };

            db.Conversations.Add(val);
        }
    }
}
