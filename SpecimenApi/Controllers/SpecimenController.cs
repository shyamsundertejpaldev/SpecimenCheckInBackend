using Application.Specimen.Command.ManifestAction;
using Application.Specimen.Query.GetManifests;
using Application.Specimen.Query.GetSpecimenByManifests;
using Domain.ExceptionHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SpecimenApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class SpecimenController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SpecimenController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ResponseDto<GetManifestsActionResponseDto>> Manifests()
        {
            return await _mediator.Send(new GetManifestsActionRequestDto());
        }

        [HttpGet]
        [Route("Manifests")]
        public async Task<ResponseDto<GetSpecimenByManifestsActionResponseDto>> Manifests([FromQuery] GetSpecimenByManifestsActionRequestDto requestDto)
        {
            return await _mediator.Send(requestDto);
        }

        [HttpPost]
        [Route("Manifests")]
        public async Task<ResponseDto<ManifestActionActionResponseDto>> Manifests([FromBody] ManifestActionActionRequestDto requestDto)
        {
            return await _mediator.Send(requestDto);
        }
    }
}
