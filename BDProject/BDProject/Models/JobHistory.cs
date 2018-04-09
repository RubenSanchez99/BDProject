//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BDProject.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel;

	public partial class JobHistory
    {
		[DisplayName("Empleado")]
		public int employee_id { get; set; }
		[DisplayName("Fecha de inicio")]
		public System.DateTime start_date { get; set; }
		[DisplayName("Fecha de fin")]
		public Nullable<System.DateTime> end_date { get; set; }
		[DisplayName("Puesto")]
		public int job_id { get; set; }
		[DisplayName("Departamento")]
		public int department_id { get; set; }

		[DisplayName("Departamento")]
		public virtual Department Department { get; set; }
		[DisplayName("Empleado")]
		public virtual Employee Employee { get; set; }
		[DisplayName("Puesto")]
		public virtual Job Job { get; set; }
    }
}
