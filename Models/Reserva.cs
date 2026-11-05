namespace ReservasDeportivasApi.Models;

using ReservasDeportivasApi.Enums;

public class Reserva
{
    public int Id { get; set; }
    public string NombreCliente { get; set; }
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