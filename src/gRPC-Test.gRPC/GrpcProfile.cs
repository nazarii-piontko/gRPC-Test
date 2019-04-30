using AutoMapper;
using gRPC_Test.Application;

namespace gRPC_Test.gRPC
{
    public class GrpcProfile : Profile
    {
        public GrpcProfile()
        {
            CreateMap<Person, GRPCTest.GRPC.Communication.Person>()
                .ReverseMap();
            
            CreateMap<GRPCTest.GRPC.Communication.TestRequest, TestRequest>();
            
            CreateMap<TestResponse, GRPCTest.GRPC.Communication.TestResponse>()
                .ForMember(o => o.Persons, e => e.UseDestinationValue());
        }
    }
}