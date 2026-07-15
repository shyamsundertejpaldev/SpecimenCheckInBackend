using Domain.Enums;
using MediatR;
using Domain.ExceptionHandling;

namespace Application.Specimen.Query.GetManifests
{
    public class GetManifestsActionRequestDto : IRequest<ResponseDto<GetManifestsActionResponseDto>>
    {
    }
}
