namespace HandyMan.Data.DataModels
{
    public class UsersModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string idNumber { get; set; }
        public string gender { get; set; }
        public string occupation { get; set; }
        public string organization { get; set; }
        public string position { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string address { get; set; }
        public string comment { get; set; }
    }
}
