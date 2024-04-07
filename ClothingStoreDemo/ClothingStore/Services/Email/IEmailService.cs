namespace ClothingStore.Services.Email
{
    public interface IEmailService
    {
        void SendEmail(Dictionary<string, string> data);
    }
}
