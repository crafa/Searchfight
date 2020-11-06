using System;
using System.Web.Script.Serialization;

namespace SearchChallenge.engine.Utils
{
    public static class JsonUtility
    {
        public static T GetJsonValue<T>(string json)
        {
            var objectResult = new JavaScriptSerializer().Deserialize<T>(json);
            return objectResult;
        }
    }
}
