using WineTourism.Domain.Entities;
using WineTourism.Shared;

namespace WineTourism.Application.Contracts
{
    public interface IPdfService
    {
        Task<Result<string>> CreatePdf(Reservation reservation);
    }
}
