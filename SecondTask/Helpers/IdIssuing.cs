using XMLClientsList.Data;

namespace XMLClientsList.Helpers
{
    public class IdIssuing
    {
        public static int GetNumIdToClient(List<Client> clientList)
        {
            return clientList.Count > 0 ? clientList.Last().RegistratorID + 1 : 1;
        }
    }
}