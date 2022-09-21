namespace SistemaEstacionamento.Models
{
  internal class Vehicle
  {
    public string LicensePlate { get; set; } = string.Empty;

    public Vehicle(string? licensePlate)
    {
      LicensePlate = licensePlate;
    }

    public override string ToString()
    {
      return $"{LicensePlate.ToUpper()}";
    }
  }
}
