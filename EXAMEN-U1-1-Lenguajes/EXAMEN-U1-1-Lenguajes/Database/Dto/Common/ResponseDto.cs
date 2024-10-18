using System.Text.Json.Serialization;

namespace EXAMEN_U1_1_Lenguajes.Database.Dto.Common
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public bool Status { get; set; }
    }
}
