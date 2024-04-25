namespace eventPlannerBack.Models.VModels.ContractorDTO
{
    public class ContractorCreationDTO
    {
        public string CUIT { get; set; }
        public string? Link { get; set; }
        public string? BusinessName { get; set; }
        public string? ProfileImage { get; set; }
        public List<string> VocationsId { get; set; } = new List<string>();
    }
}
