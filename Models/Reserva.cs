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
}