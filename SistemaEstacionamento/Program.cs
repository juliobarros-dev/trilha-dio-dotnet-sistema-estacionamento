using SistemaEstacionamento.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

const string welcomeMessage = "Bem-vindo ao sistema!\n";
const string basePriceMessage = "Digite o preço inicial (0.00): ";
const string valuePerHourMessage = "Digite o preço por hora (0.00): ";

HomeScreen();

Parking parking = new();
string? inputValue = string.Empty;

Console.Write(basePriceMessage);
inputValue = Console.ReadLine();

while (!decimal.TryParse(inputValue, out decimal _convertedValue))
{
  Console.Clear();
  HomeScreen();
  Console.Write(basePriceMessage);
  inputValue = Console.ReadLine();
}

decimal basePrice = decimal.Parse(inputValue);
parking.BasePrice = basePrice;

Console.Write(valuePerHourMessage);
inputValue = Console.ReadLine();

while (!decimal.TryParse(inputValue, out decimal _convertedValue))
{
  Console.Clear();
  HomeScreen();
  Console.Write($"{basePriceMessage} R${parking.BasePrice.ToString("0.00")}\n");
  Console.Write(valuePerHourMessage);
  inputValue = Console.ReadLine();
}

decimal pricePerHour = decimal.Parse(inputValue);
parking.PricePerHour = pricePerHour;

bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
  Console.Clear();
  Console.WriteLine("Digite a sua opção:");
  Console.WriteLine("1 - Cadastrar veículo");
  Console.WriteLine("2 - Remover veículo");
  Console.WriteLine("3 - Listar veículos");
  Console.WriteLine("4 - Encerrar\n");

  switch (Console.ReadLine())
  {
    case "1":
      parking.AddVehicle();
      break;

    case "2":
      parking.RemoveVehicle();
      break;

    case "3":
      parking.GetVehicles();
      break;

    case "4":
      exibirMenu = false;
      break;

    default:
      Console.WriteLine("Opção inválida");
      break;
  }

  if (exibirMenu == false)
  {
    Console.Clear();
    Console.WriteLine("Sistema encerrado.");
    return;
  }

  Console.WriteLine("\nAperte ENTER para retornar ao menu anterior");
  Console.ReadLine();
}

void HomeScreen()
{
  Console.WriteLine(welcomeMessage);
}