using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using gRPC_Test.Application;
using MediatR;

namespace gRPC_Test.gRPC
{
    public sealed class TestService : GRPCTest.GRPC.Communication.TestService.TestServiceBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TestService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        public override async Task<GRPCTest.GRPC.Communication.TestResponse> Test(GRPCTest.GRPC.Communication.TestRequest request, 
            ServerCallContext context)
        {
            var grpcRequest = _mapper.Map<TestRequest>(request);
            var response = await _mediator.Send(grpcRequest);
            var grpcResponse = _mapper.Map<GRPCTest.GRPC.Communication.TestResponse>(response);
            return grpcResponse;
        }
    }
}