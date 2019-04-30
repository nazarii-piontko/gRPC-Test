using System.Collections.Generic;
using MediatR;

namespace gRPC_Test.Application
{
    public sealed class TestRequest : IRequest<TestResponse>
    {
        public int Count { get; set; }
        
        public List<Person> Persons { get; set; }
    }
}