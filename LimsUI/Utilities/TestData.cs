using LimsUI.Models.ProcessModels;
using LimsUI.Models.ProcessModels.Variables;

namespace LimsUI.Utilities

{
    public static class TestData
    {

        public static SendRawDataReturnValues MakeSendRawDataReturnValuesExample()
        {
            SendRawDataReturnValues sendRawDataReturnValues = new SendRawDataReturnValues
            {
                resultType = "Execution",
                execution = new Execution
                {
                    id = "77e36c07-c9fb-11ec-8c91-005056c00001",
                    processInstanceId = "77deb106-c9fb-11ec-8c91-005056c00001",
                    ended = true,
                    tenantId = null
                },
                processInstance = null,
                variables = new SendRawDataReturnVariables
                {
                    elisa = new ElisaResult
                    {
                        type = "Object",
                        value = "{\"id\":38,\"tests\":[{\"id\":68,\"sampleId\":1,\"elisaId\":38,\"sampleName\":\"Prov1\",\"measureValue\":0.381,\"concentration\":73.74193,\"platePosition\":1,\"status\":\"In Progress\"},{\"id\":69,\"sampleId\":2,\"elisaId\":38,\"sampleName\":\"Prov2\",\"measureValue\":1.132,\"concentration\":219.09676,\"platePosition\":2,\"status\":\"In Progress\"}],\"status\":null}",
                        valueInfo = new Valueinfo
                        {
                            objectTypeName = "com.example.workflow.Models.DaoModels.Elisa",
                            serializationDataFormat = "application/json"
                        }
                    },
                    tests = new Tests
                    {
                        type = "Object",
                        value = "[{\"id\":68,\"sampleId\":1,\"elisaId\":38,\"sampleName\":\"Prov1\",\"measureValue\":0.0,\"concentration\":0.0,\"platePosition\":1,\"status\":\"In Progress\"},{\"id\":69,\"sampleId\":2,\"elisaId\":38,\"sampleName\":\"Prov2\",\"measureValue\":0.0,\"concentration\":0.0,\"platePosition\":2,\"status\":\"In Progress\"}]",
                        valueInfo = new Valueinfo()
                    },
                    elisaId = new Elisaid
                    {
                        type = "Integer",
                        value = 38,
                        valueInfo = new Valueinfo()
                    },
                    samplesData = new Samplesdata
                    {
                        type = "String",
                        value = "[{\"pos\":1,\"sampleId\":1,\"name\":\"Prov1\",\"measValue\":0.381},{\"pos\":2,\"sampleId\":2,\"name\":\"Prov2\",\"measValue\":1.132}]",
                        valueInfo = new Valueinfo()
                    },
                    plate = new Plate
                    {
                        type = "Object",
                        value = "{\"elisaId\":38,\"wells\":[{\"pos\":1,\"wellName\":\"A1\",\"reagent\":\"Prov1\"},{\"pos\":2,\"wellName\":\"B1\",\"reagent\":\"Prov2\"},{\"pos\":3,\"wellName\":\"C1\",\"reagent\":null},{\"pos\":4,\"wellName\":\"D1\",\"reagent\":null},{\"pos\":5,\"wellName\":\"E1\",\"reagent\":null},{\"pos\":6,\"wellName\":\"F1\",\"reagent\":null},{\"pos\":7,\"wellName\":\"G1\",\"reagent\":null},{\"pos\":8,\"wellName\":\"H1\",\"reagent\":null},{\"pos\":9,\"wellName\":\"A2\",\"reagent\":null},{\"pos\":10,\"wellName\":\"B2\",\"reagent\":null},{\"pos\":11,\"wellName\":\"C2\",\"reagent\":null},{\"pos\":12,\"wellName\":\"D2\",\"reagent\":null},{\"pos\":13,\"wellName\":\"E2\",\"reagent\":null},{\"pos\":14,\"wellName\":\"F2\",\"reagent\":null},{\"pos\":15,\"wellName\":\"G2\",\"reagent\":null},{\"pos\":16,\"wellName\":\"H2\",\"reagent\":null},{\"pos\":17,\"wellName\":\"A3\",\"reagent\":null},{\"pos\":18,\"wellName\":\"B3\",\"reagent\":null},{\"pos\":19,\"wellName\":\"C3\",\"reagent\":null},{\"pos\":20,\"wellName\":\"D3\",\"reagent\":null},{\"pos\":21,\"wellName\":\"E3\",\"reagent\":null},{\"pos\":22,\"wellName\":\"F3\",\"reagent\":null},{\"pos\":23,\"wellName\":\"G3\",\"reagent\":null},{\"pos\":24,\"wellName\":\"H3\",\"reagent\":null},{\"pos\":25,\"wellName\":\"A4\",\"reagent\":null},{\"pos\":26,\"wellName\":\"B4\",\"reagent\":null},{\"pos\":27,\"wellName\":\"C4\",\"reagent\":null},{\"pos\":28,\"wellName\":\"D4\",\"reagent\":null},{\"pos\":29,\"wellName\":\"E4\",\"reagent\":null},{\"pos\":30,\"wellName\":\"F4\",\"reagent\":null},{\"pos\":31,\"wellName\":\"G4\",\"reagent\":null},{\"pos\":32,\"wellName\":\"H4\",\"reagent\":null},{\"pos\":33,\"wellName\":\"A5\",\"reagent\":null},{\"pos\":34,\"wellName\":\"B5\",\"reagent\":null},{\"pos\":35,\"wellName\":\"C5\",\"reagent\":null},{\"pos\":36,\"wellName\":\"D5\",\"reagent\":null},{\"pos\":37,\"wellName\":\"E5\",\"reagent\":null},{\"pos\":38,\"wellName\":\"F5\",\"reagent\":null},{\"pos\":39,\"wellName\":\"G5\",\"reagent\":null},{\"pos\":40,\"wellName\":\"H5\",\"reagent\":null},{\"pos\":41,\"wellName\":\"A6\",\"reagent\":null},{\"pos\":42,\"wellName\":\"B6\",\"reagent\":null},{\"pos\":43,\"wellName\":\"C6\",\"reagent\":null},{\"pos\":44,\"wellName\":\"D6\",\"reagent\":null},{\"pos\":45,\"wellName\":\"E6\",\"reagent\":null},{\"pos\":46,\"wellName\":\"F6\",\"reagent\":null},{\"pos\":47,\"wellName\":\"G6\",\"reagent\":null},{\"pos\":48,\"wellName\":\"H6\",\"reagent\":null},{\"pos\":49,\"wellName\":\"A7\",\"reagent\":null},{\"pos\":50,\"wellName\":\"B7\",\"reagent\":null},{\"pos\":51,\"wellName\":\"C7\",\"reagent\":null},{\"pos\":52,\"wellName\":\"D7\",\"reagent\":null},{\"pos\":53,\"wellName\":\"E7\",\"reagent\":null},{\"pos\":54,\"wellName\":\"F7\",\"reagent\":null},{\"pos\":55,\"wellName\":\"G7\",\"reagent\":null},{\"pos\":56,\"wellName\":\"H7\",\"reagent\":null},{\"pos\":57,\"wellName\":\"A8\",\"reagent\":null},{\"pos\":58,\"wellName\":\"B8\",\"reagent\":null},{\"pos\":59,\"wellName\":\"C8\",\"reagent\":null},{\"pos\":60,\"wellName\":\"D8\",\"reagent\":null},{\"pos\":61,\"wellName\":\"E8\",\"reagent\":null},{\"pos\":62,\"wellName\":\"F8\",\"reagent\":null},{\"pos\":63,\"wellName\":\"G8\",\"reagent\":null},{\"pos\":64,\"wellName\":\"H8\",\"reagent\":null},{\"pos\":65,\"wellName\":\"A9\",\"reagent\":null},{\"pos\":66,\"wellName\":\"B9\",\"reagent\":null},{\"pos\":67,\"wellName\":\"C9\",\"reagent\":null},{\"pos\":68,\"wellName\":\"D9\",\"reagent\":null},{\"pos\":69,\"wellName\":\"E9\",\"reagent\":null},{\"pos\":70,\"wellName\":\"F9\",\"reagent\":null},{\"pos\":71,\"wellName\":\"G9\",\"reagent\":null},{\"pos\":72,\"wellName\":\"H9\",\"reagent\":null},{\"pos\":73,\"wellName\":\"A10\",\"reagent\":\"2\"},{\"pos\":74,\"wellName\":\"B10\",\"reagent\":\"4\"},{\"pos\":75,\"wellName\":\"C10\",\"reagent\":\"8\"},{\"pos\":76,\"wellName\":\"D10\",\"reagent\":\"16\"},{\"pos\":77,\"wellName\":\"E10\",\"reagent\":\"32\"},{\"pos\":78,\"wellName\":\"F10\",\"reagent\":\"64\"},{\"pos\":79,\"wellName\":\"G10\",\"reagent\":\"128\"},{\"pos\":80,\"wellName\":\"H10\",\"reagent\":\"256\"},{\"pos\":81,\"wellName\":\"A11\",\"reagent\":\"2\"},{\"pos\":82,\"wellName\":\"B11\",\"reagent\":\"4\"},{\"pos\":83,\"wellName\":\"C11\",\"reagent\":\"8\"},{\"pos\":84,\"wellName\":\"D11\",\"reagent\":\"16\"},{\"pos\":85,\"wellName\":\"E11\",\"reagent\":\"32\"},{\"pos\":86,\"wellName\":\"F11\",\"reagent\":\"64\"},{\"pos\":87,\"wellName\":\"G11\",\"reagent\":\"128\"},{\"pos\":88,\"wellName\":\"H11\",\"reagent\":\"256\"},{\"pos\":89,\"wellName\":\"A12\",\"reagent\":\"2\"},{\"pos\":90,\"wellName\":\"B12\",\"reagent\":\"4\"},{\"pos\":91,\"wellName\":\"C12\",\"reagent\":\"8\"},{\"pos\":92,\"wellName\":\"D12\",\"reagent\":\"16\"},{\"pos\":93,\"wellName\":\"E12\",\"reagent\":\"32\"},{\"pos\":94,\"wellName\":\"F12\",\"reagent\":\"64\"},{\"pos\":95,\"wellName\":\"G12\",\"reagent\":\"128\"},{\"pos\":96,\"wellName\":\"H12\",\"reagent\":\"256\"}]}",
                        valueInfo = new Valueinfo
                        {
                            objectTypeName = "com.example.workflow.Models.Plate",
                            serializationDataFormat = "application/json"
                        }
                    },
                    samples = new Samples
                    {
                        type = "String",
                        value = "{\"id\":1,\"name\":\"Prov1\"};{\"id\":2,\"name\":\"Prov2\"}",
                        valueInfo = new Valueinfo()
                    },
                    standardsData = new Standardsdata
                    {
                        type = "String",
                        value = "[{\"pos\":73,\"concentration\":2.0,\"measValue\":0.01},{\"pos\":74,\"concentration\":4.0,\"measValue\":0.02},{\"pos\":75,\"concentration\":8.0,\"measValue\":0.04},{\"pos\":76,\"concentration\":16.0,\"measValue\":0.08},{\"pos\":77,\"concentration\":32.0,\"measValue\":0.16},{\"pos\":78,\"concentration\":64.0,\"measValue\":0.32},{\"pos\":79,\"concentration\":128.0,\"measValue\":0.64},{\"pos\":80,\"concentration\":256.0,\"measValue\":1.28},{\"pos\":81,\"concentration\":2.0,\"measValue\":0.012},{\"pos\":82,\"concentration\":4.0,\"measValue\":0.024},{\"pos\":83,\"concentration\":8.0,\"measValue\":0.048},{\"pos\":84,\"concentration\":16.0,\"measValue\":0.096},{\"pos\":85,\"concentration\":32.0,\"measValue\":0.192},{\"pos\":86,\"concentration\":64.0,\"measValue\":0.384},{\"pos\":87,\"concentration\":128.0,\"measValue\":0.768},{\"pos\":88,\"concentration\":256.0,\"measValue\":1.536},{\"pos\":89,\"concentration\":2.0,\"measValue\":0.009},{\"pos\":90,\"concentration\":4.0,\"measValue\":0.018},{\"pos\":91,\"concentration\":8.0,\"measValue\":0.036},{\"pos\":92,\"concentration\":16.0,\"measValue\":0.072},{\"pos\":93,\"concentration\":32.0,\"measValue\":0.144},{\"pos\":94,\"concentration\":64.0,\"measValue\":0.288},{\"pos\":95,\"concentration\":128.0,\"measValue\":0.576},{\"pos\":96,\"concentration\":256.0,\"measValue\":1.152}]",
                        valueInfo = new Valueinfo()
                    }
                }
            };

            return sendRawDataReturnValues;
        }

    }
}
