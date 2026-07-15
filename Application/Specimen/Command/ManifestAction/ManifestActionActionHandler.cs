using Domain.Enums;
using Domain.ExceptionHandling;
using Infrastructure.Repository;
using MediatR;

namespace Application.Specimen.Command.ManifestAction
{
    public class ManifestActionActionHandler : IRequestHandler<ManifestActionActionRequestDto, ResponseDto<ManifestActionActionResponseDto>>
    {
        private readonly DbRepository _dbRepository;
        public ManifestActionActionHandler(DbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<ResponseDto<ManifestActionActionResponseDto>> Handle(ManifestActionActionRequestDto request, CancellationToken cancellationToken)
        {
            if (request.SpecimenId != 0)
            {
                var response = await _dbRepository.GetSpecimenByIdAsync(request.SpecimenId, request.ManifestId);
                if (response != null)
                {
                    switch (request.Action)
                    {
                        case SpecimenStatus.Received:
                            {
                                response.Status = SpecimenStatus.Received;
                                break;
                            }
                        case SpecimenStatus.Flagged:
                            {
                                response.Status = SpecimenStatus.Flagged;
                                await _dbRepository.RaiseDscrepancy(new Domain.Tables.Discrepancy()
                                {
                                    ManifestId = request.ManifestId,
                                    SpecimenId = request.SpecimenId,
                                    Type = DiscrepancyType.Missing,
                                    Status = DiscrepancyStatus.Open
                                });
                                break;
                            }
                    }
                    await _dbRepository.SaveChangesAsync();
                }
            }
            else
            {
                var response = await _dbRepository.GetManifestByIdAsync(request.ManifestId);
                if (response != null && request.CloseManifest && (!await _dbRepository.IsResolved(request.ManifestId)))
                {
                    response.Status = ManifestStatus.Closed;
                    await _dbRepository.SaveChangesAsync();
                }
            }

            return new ResponseDto<ManifestActionActionResponseDto>(new ManifestActionActionResponseDto(), 200);
        }
    }
}
