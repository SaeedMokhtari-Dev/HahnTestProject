namespace Hahn.ApplicationProcess.December2020.Domain.Configs
{
    public class RestCountriesAPIs: IConfigs
    {
        public string BaseAddress { get; set; }
        public string SearchByFullName { get; set; }
        public string SearchByCode { get; set; }
    }
}