using Domain.ExceptionHandling;
using Infrastructure.Repository;
using MediatR;

namespace Application.Specimen.Query.GetSpecimenByManifests
{
    public class GetSpecimenByManifestsActionHandler : IRequestHandler<GetSpecimenByManifestsActionRequestDto, ResponseDto<GetSpecimenByManifestsActionResponseDto>>
    {
        private readonly DbRepository _dbRepository;
        public GetSpecimenByManifestsActionHandler(DbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<ResponseDto<GetSpecimenByManifestsActionResponseDto>> Handle(GetSpecimenByManifestsActionRequestDto request, CancellationToken cancellationToken)
        {
            var response = await _dbRepository.GetSpecimenAsync(request.ManifestId);
            if(response!=null)
            {
                return new ResponseDto<GetSpecimenByManifestsActionResponseDto>(new GetSpecimenByManifestsActionResponseDto()
                {
                    Specimens = response
                });
            }
            return new ResponseDto<GetSpecimenByManifestsActionResponseDto>(new GetSpecimenByManifestsActionResponseDto()
            {
            },404);
        }
    }
}
