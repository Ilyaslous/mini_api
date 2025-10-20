namespace mini_api.DTOs
{
    public class VerifyReq
    {
        public string Auth { get; set; } = new string("");
        public string Msg { get; set; } = new string("");
        public string Sig { get; set; } = new string("");
    }
}
