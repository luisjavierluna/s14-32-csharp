﻿namespace eventPlannerBack.Models.VModels.ContractorDTO
{
    public class ContractorDTO
    {
        public string Id { get; set; }
        public string CUIT { get; set; }
        public ICollection<VocationDTO.VocationDTO> Vocations { get; set; }
    }
}
