using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployeeEFCore.Services
{
    public class SpeachService
    {
        public static async Task<String> TranslationContinuousRecognitionAsync()
        {

            var config = SpeechTranslationConfig.FromSubscription("a8c500c9ef9f421e977486a17f0adcca", "westeurope");
            string fromLanguage = "pl-PL";
            config.SpeechRecognitionLanguage = fromLanguage;
            config.AddTargetLanguage("pl");
            string result = "";
            // Sets voice name of synthesis output.
            const string PolishVoice = "pl-PL";
            config.VoiceName = PolishVoice;
            // Creates a translation recognizer using microphone as audio input.
            using (var recognizer = new TranslationRecognizer(config))
            {
                // Subscribes to events.


                recognizer.Recognized += async (s, e) =>
                {
                    if (e.Result.Reason == ResultReason.TranslatedSpeech)
                    {

                        await recognizer.StopContinuousRecognitionAsync();
                        result = e.Result.Text;
                    }
                };
                return result;
            }
        }
    }
}
