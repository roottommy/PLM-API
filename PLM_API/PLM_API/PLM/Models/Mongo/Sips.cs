namespace PLM_API.PLM.Models.Mongo
{
    public class Sips
    {
        public string partNumber { get; set; }

        public int version { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public List<string> drawings { get; set; }

        public string checkItems { get; set; }
    }
}
