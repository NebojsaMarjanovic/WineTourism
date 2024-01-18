using WineTourism.Application.Common;

namespace WineTourism.WebAPI.Common
{
    public class CurrentUser : IUser
    {
        public string? Id { get; set; }
    }
}
