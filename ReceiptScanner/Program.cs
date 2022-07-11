using ReceiptScanner;

//Simple text entry for file path. Example C:\Users\Jordan\source\repos\ReceiptScanner\ReceiptScanner\alpha-qr-gFpwhsQ8fkY1.json
Console.WriteLine("Please enter location of related json file as full path verbatim:");
string location = Console.ReadLine();
string jsonText = File.ReadAllText(@location);

//Deserializer for json file meaning all product are direct json translations.
List<Product> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(jsonText);
list = list.OrderBy(x => x.name).ToList();


//Set of counters for price and number of products.
int domesticCounter = 0;
int importedCounter = 0;
float domesticTotal = 0;
float importedTotal = 0;

//Domestic printer.
Console.WriteLine(".Domestic");
foreach (Product product in list)
{
    if (product.domestic==1)
    {
        Console.Write("... ");
        product.printAll();
        domesticCounter++;
        domesticTotal += product.price;
    }
}

//Imported printer.
Console.WriteLine(".Imported");
foreach (Product product in list)
{
    if (product.domestic==0)
    {
        Console.Write("... ");
        product.printAll();
        importedCounter++;
        importedTotal+=product.price;
    }
}

//Final tally of all counters and totals.
Console.WriteLine("Domestic cost: $"+domesticTotal.ToString("N1"));
Console.WriteLine("Imported cost: $"+importedTotal.ToString("N1"));
Console.WriteLine("Domestic count: "+domesticCounter);
Console.WriteLine("Imported count: "+importedCounter);
