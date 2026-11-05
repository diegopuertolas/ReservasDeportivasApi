namespace ReservasDeportivasApi.Models;

using System.ComponentModel.DataAnnotations;
using ReservasDeportivasApi.Enums;

public class Reserva
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
    public string NombreCliente { get; set; }
    
    [Required(ErrorMessage = "El nombre de la instalación es obligatorio.")]
    public string Instalacion { get; set; }
    public DateTime Fecha { get; set; }
    public int DuracionHoras { get; set; }    
    public EstadoReservaEnum Estado { get; set; }
    public bool RequiereMaterial { get; set; }

    public Reserva(
        int id, 
        string nombreCliente, 
        string instalacion,
         DateTime fecha,
          int duracionHoras, 
          EstadoReservaEnum estado,
          bool requiereMaterial
    )
    {
        Id = id;
        NombreCliente = nombreCliente;
        Instalacion = instalacion;
        Fecha = fecha;
        DuracionHoras = duracionHoras;
        Estado = estado;
        RequiereMaterial = requiereMaterial;
    }
}