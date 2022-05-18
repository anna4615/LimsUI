using LimsUI.Models.ProcessModels;
using LimsUI.Models.UIModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text.Json;

namespace LimsUI.Utilities
{
    public static class SessionMethods
    {
        public static void SetSendRawDataReturnValues(this ISession session, string key,
                                                        SendRawDataReturnValues returnValues)
        {
            session.SetString(key, JsonSerializer.Serialize(returnValues));
        }


        public static Elisa GetElisaFromSendRawDataReturnValues(this ISession session, string key)
        {
            string sessionValue = session.GetString(key);

            if (sessionValue != null)
            {
                SendRawDataReturnValues returnValues = JsonSerializer.Deserialize<SendRawDataReturnValues>(sessionValue, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                Elisa elisa= JsonSerializer.Deserialize<Elisa>(returnValues.variables.elisa.value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return elisa;
            }

            else
                return null;
        }

        public static List<StandardData> GetStandardDataFromSendRawDataReturnValues(this ISession session, string key)
        {
            string sessionValue = session.GetString(key);

            if (sessionValue != null)
            {
                SendRawDataReturnValues returnValues = JsonSerializer.Deserialize<SendRawDataReturnValues>(sessionValue, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                List<StandardData> standardDatas = JsonSerializer.Deserialize<List<StandardData>>(returnValues.variables.standardsData.value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return standardDatas;
            }

            else
                return null;
        }

        public static void SetElisaIds(this ISession session, string key, List<int> elisaIds)
        {
            session.SetString(key, JsonSerializer.Serialize(elisaIds));
        }

        public static List<int> GetElisaIds(this ISession session, string key)
        {
            string sessionValue = session.GetString(key);
            List<int> elisaIds = JsonSerializer.Deserialize<List<int>>(sessionValue, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return elisaIds;
        }

        public static void SetSamples(this ISession session, string key, List<Sample> samples)
        {
            session.SetString(key, JsonSerializer.Serialize(samples));
        }

        public static List<Sample> GetSamples(this ISession session, string key)
        {
            string sessionValue = session.GetString(key);
            List<Sample> samples = JsonSerializer.Deserialize<List<Sample>>(sessionValue, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return samples;
        }

    }
}
