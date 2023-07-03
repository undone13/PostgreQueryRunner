namespace PostgreQueryRunner
{
    public class Appsettings
    {
        public string host { get; set; }
        public string port { get; set; }
        public string dbname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    public class Root
    {
        public Appsettings appsettings { get; set; }
        public List<string> queries { get; set; }
    }
}
