using System.Xml;
using System.Xml.Linq;
using XMLClientsList.Data;
using XMLClientsList.Helpers;

namespace XMLClientsList.FileManager
{
    public class FileReader
    {
        public static List<Client> GetValidClientListFromXml(XDocument xmlDocument)
        {
            List<Client> validClients = new List<Client>();

            foreach (XElement element in xmlDocument.Root.Elements("Client"))
            {
                string? fio = element.Element("FIO")?.Value;
                string? regNumber = element.Element("RegNumber")?.Value;
                string? diasoftId = element.Element("DiasoftID")?.Value;
                string? registrar = element.Element("Registrator")?.Value;

                if (ExpressionChecker.CheckClientValidOrNot(fio, regNumber, diasoftId, registrar).Count <= 0)
                {
                    Client client = new Client
                    {
                        FIO = fio,
                        RegNumber = Convert.ToInt32(regNumber),
                        DiasoftID = Convert.ToInt64(diasoftId),
                        Registrator = registrar,
                        RegistratorID = IdIssuing.GetNumIdToClient(validClients),
                    };
                    validClients.Add(client);
                }
            }

            return validClients;
        }

        public static Dictionary<string, int> GetInValidClientListFromXml(XDocument xmlDocument)
        {
            Dictionary<string, int> errorsList = new Dictionary<string, int>()
            {
                [ExpressionChecker.EMPTY_FIO] = 0,
                [ExpressionChecker.EMPTY_REGNUMBER] = 0,
                [ExpressionChecker.EMPTY_DIASOFTID] = 0,
                [ExpressionChecker.EMPTY_REGISTRATOR] = 0,
            };

            foreach (var element in xmlDocument.Root.Elements("Client"))
            {
                string? fio = element.Element("FIO")?.Value;
                string? regNumber = element.Element("RegNumber")?.Value;
                string? diasoftId = element.Element("DiasoftID")?.Value;
                string? registrar = element.Element("Registrator")?.Value;

                if (String.IsNullOrEmpty(fio) || String.IsNullOrWhiteSpace(fio))
                    errorsList[ExpressionChecker.EMPTY_FIO] += 1;
                if (String.IsNullOrEmpty(regNumber) || String.IsNullOrWhiteSpace(regNumber))
                    errorsList[ExpressionChecker.EMPTY_REGNUMBER] += 1;
                if (String.IsNullOrEmpty(diasoftId) || String.IsNullOrWhiteSpace(diasoftId))
                    errorsList[ExpressionChecker.EMPTY_DIASOFTID] += 1;
                if (String.IsNullOrEmpty(registrar) || String.IsNullOrWhiteSpace(registrar))
                    errorsList[ExpressionChecker.EMPTY_REGISTRATOR] += 1;
            }

            return errorsList;
        }
    }
}