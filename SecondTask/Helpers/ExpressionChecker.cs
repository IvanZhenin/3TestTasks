using System.Collections.Generic;
using XMLClientsList.Data;

namespace XMLClientsList.Helpers
{
    public class ExpressionChecker
    {
        public const string EMPTY_FIO = "Не указано ФИО";
        public const string EMPTY_REGNUMBER = "Не указан регистрационный номер";
        public const string EMPTY_DIASOFTID = "Не указан DiasoftID";
        public const string EMPTY_REGISTRATOR = "Не указан регистратор";

        public static List<string> CheckClientValidOrNot(string? fio, string? regNumber, string? diasoftId, string? registrator)
        {
            List<string> result = new List<string>();
            if (String.IsNullOrEmpty(fio))
                result.Add(EMPTY_FIO);
            if (String.IsNullOrEmpty(regNumber))
                result.Add(EMPTY_REGNUMBER);
            if (String.IsNullOrEmpty(diasoftId))
                result.Add(EMPTY_DIASOFTID);
            if (String.IsNullOrEmpty(registrator))
                result.Add(EMPTY_REGISTRATOR);

            return result;
        }
    }
}