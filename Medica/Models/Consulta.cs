namespace Medica
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Consulta")]
    public partial class Consulta
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ConsultaId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MedicoId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PacienteId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaFin { get; set; }
        
        [StringLength(500)]
        public string Sintomas { get; set; }

        [StringLength(500)]
        public string Diagnostico { get; set; }

        [StringLength(500)]
        public string Tratamiento { get; set; }

        [StringLength(500)]
        public string Observaciones { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
