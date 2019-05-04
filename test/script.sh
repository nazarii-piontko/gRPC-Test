./ghz --proto=../src/gRPC-Test.gRPC/Protos/service.proto --insecure --format=pretty --output=/Users/nazar/Desktop/ghz.pretty --concurrency=200 --connections=100 --total 100000 --call=Test.TestService/Test --data='{"count": 50}' localhost:50051

./hey -c 200 -n 100000 -m POST -T 'application/json' -d '{"Count": 50}' http://localhost:5000/test