namespace mini_api.Services
{
    public interface ISigningServ
    {
        string SignData(string dataSign);
        bool VerifyData(string originalData, string signature);
    }
}
