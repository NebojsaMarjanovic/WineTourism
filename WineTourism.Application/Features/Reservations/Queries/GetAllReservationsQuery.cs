using MediatR;
using WineTourism.Application.Interfaces.Repositories;
using WineTourism.Shared;

namespace WineTourism.Application.Features.Reservations.Queries
{
    public record GetAllReservationsQuery : IRequest<Result<List<GetAllReservationsDTO>>>;

    internal class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, Result<List<GetAllReservationsDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllReservationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<GetAllReservationsDTO>>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var reservations = await _unitOfWork.Repository<Reservation>().Entites
            //    .ProjectTo<GetAllReservationsDTO>(_mapper.ConfigurationProvider)
            //    .ToListAsync(cancellationToken);

            //return await Result<List<GetAllReservationsDTO>>.SuccessAsync(reservations);
        }
    }
}
