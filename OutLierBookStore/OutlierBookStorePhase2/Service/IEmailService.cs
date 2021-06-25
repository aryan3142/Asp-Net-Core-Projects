using OutlierBookStorePhase2.Models;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
    }
}