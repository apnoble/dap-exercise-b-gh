using System;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace DAP_Exercise_B
{
    class DataService
    {
        // Calls the REDCap DAP API to get all the records for a project
        public async Task<Record[]> GetRecords()
        {
            var client = new RestClient("https://redcap.dogagingproject.org/api/")
            {
                Timeout = -1
            };

            var request = new RestRequest(Method.POST)
            {
                AlwaysMultipartFormData = true
            };
            
            // Add your API token here - For production code this should be stored in an .env file or hidden using a different method
            request.AddParameter("token", "add your token here");

            request.AddParameter("content", "record");
            request.AddParameter("format", "json");
            request.AddParameter("type", "flat");
            request.AddParameter("csvDelimiter", "");
            request.AddParameter("rawOrLabel", "raw");
            request.AddParameter("rawOrLabelHeaders", "raw");
            request.AddParameter("exportCheckboxLabel", "false");
            request.AddParameter("exportSurveyFields", "false");
            request.AddParameter("exportDataAccessGroups", "false");
            request.AddParameter("returnFormat", "json");

            IRestResponse response = await client.ExecuteAsync(request);

            Record[] records = BuildRecords(response.Content);
            return records;
        }

        // Turns the response content into Record objects
        private Record[] BuildRecords(dynamic content)
        {
            var recs = JsonConvert.DeserializeObject(content);
            int length = recs.Count;
            Record[] records = new Record[length];
            for (int i = 0; i < length; i++)
            {
                Record record = this.BuildARecordHelper(recs[i]);
                records[i] = record;
            }
            return records;
        }

        // Creates a Record object
        private Record BuildARecordHelper(dynamic record)
        {
            string subject_id = record.subject_id;
            string fu_df_frequency = record.fu_df_frequency;
            string fu_df_prim_org = record.fu_df_prim_org;
            string fu_df_prim_brand = record.fu_df_prim_brand;
            string fu_df_overrweight = record.fu_df_overrweight;

            Record resultRecord = new Record(
               subject_id,
               fu_df_frequency,
               fu_df_prim_org,
               fu_df_prim_brand,
               fu_df_overrweight);

            return resultRecord;
        }
    }
}
