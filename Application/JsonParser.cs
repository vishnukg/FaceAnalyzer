using System;
using System.Collections.Generic;
using System.Linq;
using FaceDetectorApi.Models;
using Newtonsoft.Json;

namespace FaceDetectorApi.Application
{
    public class JsonParser : IParser
    {
        public ImageInfo ParseImageInfo(string input)
        {
            var face = JsonConvert.DeserializeObject<List<RootObject>>(input).First();
            return new ImageInfo()
            {
                FaceId = face.FaceId,
                Emotions = new List<ParsedEmotion>()
                {
                    new ParsedEmotion()
                    {
                        TypeofEmotion = "angry",
                        Weightage = Double.Parse(face.FaceAttributes.emotion.anger)
                    },
                    new ParsedEmotion()
                    {
                        TypeofEmotion = "contempt",
                        Weightage = Double.Parse(face.FaceAttributes.emotion.contempt)
                    } ,
                    new ParsedEmotion()
                    {
                        TypeofEmotion = "disgusted",
                        Weightage = Double.Parse(face.FaceAttributes.emotion.disgust)
                    },
                    new ParsedEmotion()
                    {
                        TypeofEmotion = "afraid",
                        Weightage = Double.Parse(face.FaceAttributes.emotion.fear)
                    },
                    new ParsedEmotion()
                    {
                        TypeofEmotion = "happy",
                        Weightage = Double.Parse(face.FaceAttributes.emotion.happiness)
                    },
                    new ParsedEmotion()
                    {
                        TypeofEmotion = "neutral",
                        Weightage = Double.Parse(face.FaceAttributes.emotion.neutral)
                    },
                    new ParsedEmotion()
                    {
                        TypeofEmotion = "sad",
                        Weightage = Double.Parse(face.FaceAttributes.emotion.sadness)
                    },
                    new ParsedEmotion()
                    {
                        TypeofEmotion = "surprised",
                        Weightage = Double.Parse(face.FaceAttributes.emotion.surprise)
                    },


                }

            };
        }
    }
}