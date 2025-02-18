using Microsoft.AspNetCore.Mvc;
using ModelsMl;
using ModelsMl.Pairs;

namespace ChatBot.Controllers.Training
{
    public partial class TrainingController
    {
#pragma warning disable CS1998
        public async Task<IActionResult> TrainConversations([FromBody] CompleteConversation pair)
        {
            var result = this._trainingService.TrainEverything(pair);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> TrainEmotions([FromBody] EmotionPair pair)
        {
            var result = this._trainingService.TrainEmotions(pair);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> TrainPurposes([FromBody] PurposePair pair)
        {
            var result = this._trainingService.TrainPurposes(pair);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> TrainIntends([FromBody] IntendPair pair)
        {
            var result = this._trainingService.TrainIntends(pair);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> TrainFormats([FromBody] FormatPair pair)
        {
            var result = this._trainingService.TrainFormats(pair);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> TrainInformations([FromBody] InformationPair pair)
        {
            var result = this._trainingService.TrainInformations(pair);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> TrainOutputs([FromBody] OutputPair pair)
        {
            var result = this._trainingService.TrainOutputs(pair);

            return Ok(result);
        }
#pragma warning restore CS1998
    }
}
