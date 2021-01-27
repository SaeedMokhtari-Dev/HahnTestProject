namespace Hahn.ApplicationProcess.December2020.Domain.Models
{
    public class ResponseModel
    {
        public ResponseModel(int entityId, string getUrl)
        {
            EntityId = entityId;
            GetUrl = getUrl;
        }
        public int EntityId { get; set; }
        public string GetUrl { get; set; }
    }
}