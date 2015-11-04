namespace Medica
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Consultas")]
    public partial class Consulta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "numeric")]
        
        public decimal ConsultaId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal MedicoId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PacienteId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm }")]
        public DateTime Fecha { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm }")]
        public DateTime FechaFin { get; set; }
        
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Sintomas { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Diagnostico { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Tratamiento { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
