//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CliMed.Persistencia
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_PACIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_PACIENTE()
        {
            this.TB_AGENDA = new HashSet<TB_AGENDA>();
        }
    
        public int CD_PACIENTE { get; set; }
        public string NM_PACIENTE { get; set; }
        public string DS_CPF { get; set; }
        public string DS_RG { get; set; }
        public string DS_TELEFONE { get; set; }
        public System.DateTime DT_NASCIMENTO { get; set; }
        public string DS_CEP { get; set; }
        public string DS_UF { get; set; }
        public string DS_CIDADE { get; set; }
        public string DS_ENDERECO { get; set; }
        public string DS_BAIRRO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_AGENDA> TB_AGENDA { get; set; }
    }
}
