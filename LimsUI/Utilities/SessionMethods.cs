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


        public static Elisa GetElisaFromCookie(this ISession session, string key)
        {
            string sessionValue = session.GetString(key);

            if (sessionValue != null)
            {
                SendRawDataReturnValues returnValues = JsonSerializer.Deserialize<SendRawDataReturnValues>(sessionValue);
                Elisa elisa= JsonSerializer.Deserialize<Elisa>(returnValues.variables.elisa.value);
                return elisa;
            }

            else
                return null;
        }

        public static List<StandardData> GetStandardDataFromCookie(this ISession session, string key)
        {
            string sessionValue = session.GetString(key);

            if (sessionValue != null)
            {
                SendRawDataReturnValues returnValues = JsonSerializer.Deserialize<SendRawDataReturnValues>(sessionValue);
                List<StandardData> standardDatas = JsonSerializer.Deserialize<List<StandardData>>(returnValues.variables.standardsData.value);
                return standardDatas;
            }

            else
                return null;
        }
    }
}
