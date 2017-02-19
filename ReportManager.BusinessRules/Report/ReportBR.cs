using AutoMapper;
using ReportManager.BusinessRules.DataTransferObjects;
using ReportManager.Commons;
using ReportManager.Persistence.Entities;
using ReportManager.Persistence.Repositories;
using System.Collections.Generic;

namespace ReportManager.BusinessRules.Report
{
    public class ReportBr
    {
        private ReportRepository _reportRepository;

        public ReportBr()
        {
            _reportRepository = new ReportRepository(Constants.ReportConnectionString);
        }

        public IEnumerable<ReportDTO> GetReportCollectionByRecentDate(int start, int size)
        {
            IEnumerable<ReportEntity> reports = _reportRepository.GetReportCollectionByRecentDate(start, size);

            return Mapper.Map<IEnumerable<ReportEntity>,IEnumerable<ReportDTO>>(reports);
        }
        public ReportDTO GetReportById(int id)
        {
            ReportEntity report = _reportRepository.GetReportById(id);

            return Mapper.Map<ReportEntity, ReportDTO>(report); ;
        }

        public void CreateReport(ReportDTO reportDto)
        {
            ReportEntity reportEntity = Mapper.Map<ReportDTO,ReportEntity>(reportDto);
            _reportRepository.InsertReport(reportEntity);
            //validate


        }
    }
}
