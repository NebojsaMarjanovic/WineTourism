using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WineTourism.Application.Interfaces.Repositories;
using WineTourism.Domain.Entities;
using WineTourism.Shared;

namespace WineTourism.Application.Features.Reservations.Queries
{
    public record GetAllReservationsQuery : IRequest<Result<List<GetAllReservationsDTO>>>;

    internal class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, Result<List<GetAllReservationsDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllReservationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllReservationsDTO>>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _unitOfWork.Repository<Reservation>().Entites
                .ProjectTo<GetAllReservationsDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllReservationsDTO>>.SuccessAsync(reservations);
        }
    }
}
