using Domain.ExceptionHandling;
using Infrastructure.Repository;
using MediatR;

namespace Application.Specimen.Query.GetManifests
{
    public class GetManifestsActionHandler : IRequestHandler<GetManifestsActionRequestDto, ResponseDto<GetManifestsActionResponseDto>>
    {
        private readonly DbRepository _dbRepository;
        public GetManifestsActionHandler(DbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<ResponseDto<GetManifestsActionResponseDto>> Handle(GetManifestsActionRequestDto request, CancellationToken cancellationToken)
        {
            var response = await _dbRepository.GetManifestAsync();
            return new ResponseDto<GetManifestsActionResponseDto>(new GetManifestsActionResponseDto()
            {
                Manifest = response
            });
        }
    }
}
