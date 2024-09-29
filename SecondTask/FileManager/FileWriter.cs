using System.Text;
using System.Xml;
using System.Xml.Linq;
using XMLClientsList.Data;

namespace XMLClientsList.FileManager
{
    public class FileWriter
    {
        public static void WriteXmlFileAllClients(List<Client> clientList, string filePath)
        {
            XmlReader xmlReader = new XmlTextReader(filePath);

            XDocument xmlDoc = new XDocument
            (
                new XElement("Clients",
                    clientList.Select(client =>
                        (
                            new XElement("Client",
                            new XAttribute("RegistratorID", client.RegistratorID),
                            new XElement("FIO", client.FIO),
                            new XElement("RegNumber", client.RegNumber),
                            new XElement("DiasoftID", client.DiasoftID),
                            new XElement("Registrator", client.Registrator))
                        )
                    )
                )
            );

            xmlDoc.Save(filePath);
        }

        public static void WriteXmlFileClientRegistrators(List<Client> clientList, string filePath)
        {
            XmlReader xmlReader = new XmlTextReader(filePath);

            XDocument xmlDoc = new XDocument
            (
                new XElement("Clients",
                    clientList.Select(client =>
                        (
                            new XElement("Client",
                            new XElement("Name", client.Registrator),
                            new XElement("ID", client.RegNumber))
                        )
                    )
                )
            );

            xmlDoc.Save(filePath);
        }

        public static void WriteTxtFileInvalidClientsToErrorList(Dictionary<string, int> invalidClientList, string filePath)
        {
            StringBuilder errorsList = new StringBuilder();
            errorsList.AppendLine("Список ошибок:\n");

            foreach (var error in invalidClientList.OrderByDescending(p => p.Value))
            {
                if (error.Value > 0)
                    errorsList.AppendLine($"{error.Key}: {error.Value} записей.\n");
            }

            using (StreamWriter fileToWrite = new StreamWriter(filePath))
            {
                fileToWrite.Write(errorsList.ToString());
            }
        }
    }
}