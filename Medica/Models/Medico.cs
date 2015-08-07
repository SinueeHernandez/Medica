namespace Medica
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.IO;
    using System.Web.Mvc;
    using System.Web;

    [Table("Medico")]
    public partial class Medico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
            MedicoEspecialidad = new HashSet<MedicoEspecialidad>();
        }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal MedicoID { get; set; }

        [StringLength(500)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string ApellidoPaterno { get; set; }

        [Required]
        [StringLength(500)]
        public string ApellidoMaterno { get; set; }

        [Column(TypeName = "numeric")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        public decimal Telefono { get; set; }

        
        public byte[] Foto { get; set; }

        public string Biografia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consulta> Consulta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicoEspecialidad> MedicoEspecialidad { get; set; }



       

    }


}
