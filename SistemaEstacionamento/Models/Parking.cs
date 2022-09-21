namespace SistemaEstacionamento.Models
{
  internal class Parking
  {
    public decimal PricePerHour;
    public decimal BasePrice;
    private List<Vehicle> Vehicles = new List<Vehicle>();


    public Parking()
    {
    }

    public bool InputValidator(string? value)
    {
      bool isValid = true;

      if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
      {
        isValid = false;
      }

      return isValid;
    }

    public bool NumberValidator(string? value)
    {
      if (int.TryParse(value, out int _result)) return true;
      return false;
    }

    public void OptionMenu(string menu, string message)
    {
      Console.WriteLine(menu);
      Console.WriteLine(message);
    }

    public void AddVehicle()
    {
      const string menuMessage = "ADICIONAR VEÍCULO\n";
      const string addVehicleMessage = "Digite a placa do veículo para estacionar ou 0 para cancelar.";

      string? licensePlate = string.Empty;

      while (!InputValidator(licensePlate))
      {
        Console.Clear();
        OptionMenu(menuMessage, addVehicleMessage);
        licensePlate = Console.ReadLine();
      }

      if (licensePlate == "0") return;

      Vehicle vehicle = new(licensePlate);
      Vehicles.Add(vehicle);
    }

    public void RemoveVehicle()
    {
      const string menuMessage = "REMOVER VEÍCULO\n";
      const string removeVehicleMessage = "Digite a placa do veículo para remover ou 0 para cancelar.";

      Console.Clear();
      OptionMenu(menuMessage, removeVehicleMessage);
      string? licensePlate = Console.ReadLine();
      

      while (!InputValidator(licensePlate))
      {
        Console.Clear();
        OptionMenu(menuMessage, removeVehicleMessage);
        licensePlate = Console.ReadLine();
      }

      if (licensePlate == "0") return;

      if (Vehicles.Any(x => x.LicensePlate.ToUpper() == licensePlate.ToUpper()))
      {
        string chargeMessage = $"Digite a quantidade de horas que o veículo {licensePlate.ToUpper()} permaneceu estacionado: ";

        Console.Clear();
        OptionMenu(menuMessage, chargeMessage);
        string? inputValue = Console.ReadLine();

        bool isValid = InputValidator(inputValue);
        bool isNumber = NumberValidator(inputValue);

        while (!isNumber || !isValid)
        {
          Console.Clear();
          OptionMenu(menuMessage, chargeMessage);
          inputValue = Console.ReadLine();
          isValid = InputValidator(inputValue);
          isNumber = NumberValidator(inputValue);
        }

        int parkedHours = int.Parse(inputValue);

        decimal valorTotal = BasePrice + PricePerHour * parkedHours;

        Vehicle? vehicleToRemove = Vehicles.FirstOrDefault(vehicle => vehicle.LicensePlate.ToUpper() == licensePlate.ToUpper());
        Vehicles.Remove(vehicleToRemove);

        Console.WriteLine($"\nO veículo {licensePlate.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal.ToString("0.00")}");
      }
      else
      {
        Console.WriteLine($"\nDesculpe, o veículo {licensePlate.ToUpper()} não está estacionado aqui. Confira se digitou a placa corretamente\n");
      }
    }

    public void GetVehicles()
    {
      if (Vehicles.Any())
      {
        Console.WriteLine("Os veículos estacionados são: \n");

        foreach (var vehicle in Vehicles)
        {
          Console.WriteLine(vehicle);
        }
      }
      else
      {
        Console.WriteLine("\nNão há veículos estacionados. \n");
      }
    }
  }
}
