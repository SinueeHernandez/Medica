namespace Medica
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MedicoEspecialidad")]
    public partial class MedicoEspecialidad
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MedicoId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EspecilidadId { get; set; }

        public virtual Especialidades Especialidades { get; set; }

        public virtual Medico Medico { get; set; }
    }
}
