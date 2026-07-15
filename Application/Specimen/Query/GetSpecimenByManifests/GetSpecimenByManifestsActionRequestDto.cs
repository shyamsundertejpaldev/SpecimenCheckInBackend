using Domain.Enums;
using MediatR;
using Domain.ExceptionHandling;

namespace Application.Specimen.Query.GetSpecimenByManifests
{
    public class GetSpecimenByManifestsActionRequestDto : IRequest<ResponseDto<GetSpecimenByManifestsActionResponseDto>>
    {
        public int ManifestId { get; set; } = 0;
    }
}
