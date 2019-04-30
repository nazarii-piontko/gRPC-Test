namespace gRPC_Test.Application
{
    public  sealed class Person
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Age { get; set; }
        
        public double Weigth { get; set; }
        
        public Sex Sex { get; set; }
        
        public bool Single { get; set; }
    }
    
    public enum Sex
    {
        Male,
        Female
    }
}