using AutoMapper;
using gRPC_Test.Application;

namespace gRPC_Test.gRPC
{
    public class GrpcProfile : Profile
    {
        public GrpcProfile()
        {
            CreateMap<Person, Test.Person>()
                .ReverseMap();
            
            CreateMap<Test.TestRequest, TestRequest>();
            
            CreateMap<TestResponse, Test.TestResponse>()
                .ForMember(o => o.Persons, e => e.UseDestinationValue());
        }
    }
}