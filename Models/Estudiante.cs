using System.ComponentModel.DataAnnotations;

namespace ApiEmpresa.Models;


public class Estudiante{
   [Key]
    public Int32 id_estudiante { get; set; }
    public Int32 carne { get; set; }
    public string? nombres { get; set; }
    public string? apellidos { get; set; }
    public string? direccion { get; set; }
    public string? telefono { get; set; }
    public string? correo { get; set; }
    public string? sangre { get; set; }
    public DateTime? fecha_nacimiento { get; set; }
    
}



