using System.Xml.Linq;
using XMLClientsList.Data;
using XMLClientsList.FileManager;
using XMLClientsList.Helpers;

namespace XMLClientsList
{
    public class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "D:\\FilesFolder\\Clients.xml";
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"Файл '{inputFilePath}' не найден.");
                return;
            }

            XDocument xmlDocument = XDocument.Load(inputFilePath);

            List<Client> validClients = FileReader.GetValidClientListFromXml(xmlDocument);
            Dictionary<string, int> errorsList = FileReader.GetInValidClientListFromXml(xmlDocument);

            FileWriter.WriteXmlFileAllClients(validClients, "valid_clients.xml");
            FileWriter.WriteXmlFileClientRegistrators(validClients, "registrators_clients.xml");
            FileWriter.WriteTxtFileInvalidClientsToErrorList(errorsList, "invalid_clients.txt");

            Console.WriteLine("Запись прошла успешно!");
            Console.ReadKey();
        }
    }
}