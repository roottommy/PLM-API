namespace PLM_API.PLM.Models.Mongo
{
    public class CheckItemProperty
    {
        public string PlmName { get; set; }
        public Type PType { get; set; }
        public string PCName { get; set; }
        public string NewName { get; set; }

        public string GetValueType { get; set; }
    }
}
