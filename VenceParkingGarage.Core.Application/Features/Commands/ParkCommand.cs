using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VenceParkingGarage.Core.Domain;
using VenceParkingGarage.Core.Domain.Entities;
using VenceParkingGarage.Core.Domain.Interfaces;

namespace VenceParkingGarage.Core.Application.Features.Commands
{
    public class ParkCommand : IRequest<Unit>
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public int ParkLevelId { get; set; }
        public VehicleType VehicleType { get; set; }

        public class ParkCommandHandler : IRequestHandler<ParkCommand, Unit>
        {
            IRepository<ParkingLevel> _parkingLevelRepository;
            IRepository<Vehicle> _vehicleRepository;
            public ParkCommandHandler(IRepository<ParkingLevel> parkingLevelRepository, IRepository<Vehicle> vehicleRepository)
            {
                _parkingLevelRepository = parkingLevelRepository;
                _vehicleRepository = vehicleRepository;
            }


            public async Task<Unit> Handle(ParkCommand request, CancellationToken cancellationToken)
            {
                var level = (await _parkingLevelRepository.GetAsync(x => x.Id == request.ParkLevelId, x => x.ParkingSlots)).FirstOrDefault();
                if (level == null)
                    throw new ParkingLevelNotFoundException();

                var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId);
                if (vehicle == null)
                    throw new VehicleNotFoundException();

                //TODO: Other validations here, like vehicle is already in garage...

                level.Park(request.VehicleId, request.LicensePlate, request.VehicleType);

                await _parkingLevelRepository.SaveChangeAsync();

                return Unit.Value;
            }
        }
    }
}
