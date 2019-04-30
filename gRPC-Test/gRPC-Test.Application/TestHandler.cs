using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace gRPC_Test.Application
{
    public sealed class TestHandler : IRequestHandler<TestRequest, TestResponse>
    {
        public Task<TestResponse> Handle(TestRequest request, CancellationToken cancellationToken)
        {
            var response = new TestResponse();

            if (request.Count > 0)
            {
                response.Persons = new Person[request.Count];

                var rnd = new Random();
                
                for (int i = 0; i < request.Count; i++)
                {
                    response.Persons[i] = new Person
                    {
                        Id = i,
                        Name = "John Dow #" + i,
                        Age = rnd.Next(1, 100),
                        Weigth = rnd.NextDouble() * 100,
                        Sex = rnd.NextDouble() > 0.5 ? Sex.Male : Sex.Female,
                        Single = rnd.NextDouble() > 0.5
                    };
                }
            }

            return Task.FromResult(response);
        }
    }
}