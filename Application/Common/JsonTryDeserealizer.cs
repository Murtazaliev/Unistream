using Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;

namespace Application.Common
{
    public static class JsonTryDeserealizer
    {




        public static string FromClass<T>(T data, bool isEmptyToNull = false,
                                          JsonSerializerSettings jsonSettings = null)
        {
            string response = string.Empty;

            if (!EqualityComparer<T>.Default.Equals(data, default(T)))
                response = JsonConvert.SerializeObject(data, jsonSettings);

            return isEmptyToNull ? (response == "{}" ? "null" : response) : response;
        }

        public static T ToClass<T>
        (string data, string schema)
        {
            IList<string> errorMessages;
            JObject entity = JObject.Parse(data);
            bool valid = entity.IsValid(JSchema.Parse(schema), out errorMessages);
            if (!valid)
            {
                throw new JSchemaValidationException(errorMessages.FirstOrDefault());
            }


            JsonTextReader reader = new JsonTextReader(new StringReader(data));

            JSchemaValidatingReader validatingReader = new JSchemaValidatingReader(reader);
            validatingReader.Schema = JSchema.Parse(schema);

            IList<string> messages = new List<string>();
            validatingReader.ValidationEventHandler += (o, a) => messages.Add(a.Message);

            JsonSerializer serializer = new JsonSerializer();
            var result = serializer.Deserialize<T>(validatingReader);
            return result;
        }
    }
}
