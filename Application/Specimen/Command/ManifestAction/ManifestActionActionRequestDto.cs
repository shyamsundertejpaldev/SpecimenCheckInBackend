using Domain.Enums;
using MediatR;
using Domain.ExceptionHandling;

namespace Application.Specimen.Command.ManifestAction
{
    public class ManifestActionActionRequestDto : IRequest<ResponseDto<ManifestActionActionResponseDto>>
    {
        public int ManifestId { get; set; }
        public int SpecimenId { get; set; } = 0;
        public SpecimenStatus Action { get; set; }
        public bool CloseManifest { get; set; } = false;
    }
}
