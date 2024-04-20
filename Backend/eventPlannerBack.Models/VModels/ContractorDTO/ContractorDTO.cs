namespace eventPlannerBack.Models.VModels.ContractorDTO
{
    public class ContractorDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CUIT { get; set; }
        public ICollection<VocationDTO.VocationDTO> Vocations { get; set; }
    }
}
