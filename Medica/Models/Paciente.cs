namespace Medica
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pacientes")]
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal PacienteId { get; set; }

        [Required]
        [StringLength(500)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(100)]
        public string ApellidoPaterno { get; set; }

        [StringLength(100)]
        public string ApellidoMaterno { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Telefono { get; set; }

        [StringLength(500)]
        public string Direccion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GeneroID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consulta> Consulta { get; set; }

        public virtual Genero Genero { get; set; }
    }
}
