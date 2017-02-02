//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;

//namespace ReportManager.ViewModels
//{
//    public class CreateReportViewModel
//    {
//        public DateTime Date { get; set; }

//        public int Status { get; set; }

//        [StringLength(50,ErrorMessage = "Campo Fluxo deve ter no máximo 50 caracteres.")]
//        public string Flow { get; set; }

//        [StringLength(50, ErrorMessage = "Campo Aplicação deve ter no máximo 50 caracteres.")]
//        public string Application { get; set; }

//        [StringLength(100, ErrorMessage = "Campo Impacto deve ter no máximo 100 caracteres.")]
//        public string Impact { get; set; }

//        [StringLength(100, ErrorMessage = "Campo Solução paliativa deve ter no máximo 100 caracteres.")]
//        public string Workaround { get; set; }

//        [StringLength(100, ErrorMessage = "Campo Tempo na madrugada deve ter no máximo 100 caracteres.")]
//        public string WorkaroundTime { get; set; }

//        [StringLength(10000, ErrorMessage = "Campo Solução definitiva deve ter no máximo 10000 caracteres.")]
//        public string Solution { get; set; }

//        [StringLength(100, ErrorMessage = "Campo Tempo na madrugada deve ter no máximo 100 caracteres.")]
//        public string SolutionTime { get; set; }

//        [StringLength(50, ErrorMessage = "Campo Incomodado deve ter no máximo 50 caracteres.")]
//        public string Reporter { get; set; }

//        [StringLength(10000, ErrorMessage = "Campo Problema deve ter no máximo 10000 caracteres.")]
//        public string Description { get; set; }

//        [StringLength(50, ErrorMessage = "Campo Time Responsável deve ter no máximo 50 caracteres.")]
//        public string ResponsibleTeam { get; set; }
//    }
//}