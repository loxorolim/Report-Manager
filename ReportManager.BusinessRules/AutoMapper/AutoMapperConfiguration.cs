using AutoMapper;
using ReportManager.BusinessRules.DataTransferObjects;
using ReportManager.Persistence.Entities;

namespace ReportManager.BusinessRules.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ReportDTO, ReportEntity>().ReverseMap());
            
        }
    }
}
