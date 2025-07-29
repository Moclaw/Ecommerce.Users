using Ecom.Users.Application.Features.Auth.Commands.RefreshToken;

namespace Ecom.Users.API.Endpoints.Auth.Commands
{
    [OpenApiSummary("Refresh JWT token using refresh token")]
    [OpenApiResponse(
        200,
        ResponseType = typeof(RefreshTokenResponse),
        Description = "Token refreshed successfully"
    )]
    public class RefreshTokenEndpoint(IMediator mediator)
        : SingleEndpointBase<RefreshTokenRequest, RefreshTokenResponse>(mediator)
    {
        [HttpPost("auth/refresh-token")]
        public override async Task<Response<RefreshTokenResponse>> HandleAsync(
            RefreshTokenRequest req,
            CancellationToken ct
        )
        {
            return await _mediator.Send(req, ct);
        }
    }
}
