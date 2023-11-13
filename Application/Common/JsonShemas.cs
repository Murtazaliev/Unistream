using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public static class JsonShemas
    {
        public static string EntityTSchemaJson = @"{""type"":""object"",""properties"":{""id"":{""type"":""string""},""operationDate"":{""type"":""string"",""format"":""yyyy-MM-ddTHH:mm:ss.fffffffzzz""},""amount"":{""type"":""number"",""not"":{""enum"":[0]}}},""required"":[""amount""]}";
    }
}
