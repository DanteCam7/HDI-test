namespace HDI.Models.Dto
{
    public class ResponseDto
    {
        public object Data { get; set; }

        public int estatus { get; set; }

        public int codigo {  get; set; }

        public string Message { get; set; } = "";
    }
}
