namespace ForRS.Data.Database
{
    public class GenerateRequests
    {
        /// <summary>
        /// Метод AddMeet формирует SQL инструкцию INSERT
        /// для внесения новой встречи
        /// </summary>
        /// <param name="title">Название встречи</param>
        /// <param name="start">Время встречи</param>
        /// <param name="end">Время окончания встречи</param>
        /// <param name="alert">Предупредить за</param>
        /// <returns>Возвращает текстовое представление инструкции типа INSERT</returns>
        public string AddMeet(string title, DateTime start, DateTime end, int alert)
        {
            return $"INSERT INTO meets (Title, StartMeet, EndMeet, Alert) VALUES (\'{title}\', \'{start}\', \'{end}\', \'{alert}\')";
        }
        /// <summary>
        /// Метод DeleteMeet формирует SQL инструкцию DELETE
        /// для удаления выбраной встречи
        /// </summary>
        /// <param name="index">индекс записи в БД</param>
        /// <returns>Возвращает текстовое представление инструкции типа DELETE</returns>
        public string DeleteMeet(int index)
        {
            return $"DELETE FROM meets WHERE id={index}";
        }
        /// <summary>
        /// Метод EditMeet формирует SQL инструкцию UPDATE
        /// для внесения изменений во встречу
        /// </summary>
        /// <param name="title">Название встречи</param>
        /// <param name="start">Время встречи</param>
        /// <param name="end">Время окончания встречи</param>
        /// <param name="alert">Предупредить за</param>
        /// <param name="index">индекс записи в БД</param>
        /// <returns>Возвращает текстовое представление инструкции типа UPDATE</returns>
        public string EditMeet(string title, DateTime start, DateTime end, int alert, int index)
        {
            return $"UPDATE meets SET Title = \'{title}\', StartMeet = \'{start}\', EndMeet = \'{end}\', Alert = \'{alert}\' WHERE id = {index}";
        }
        /// <summary>
        /// Метод GetMeets формирует SQL запрос SELECT
        /// для получения полного списка встреч
        /// </summary>
        /// <returns>Возвращает текстовое представление запроса типа SELECT</returns>
        public string GetMeets()
        {
            return $"SELECT * FROM meets";
        }
        /// <summary>
        /// Метод CheckMeet формирует SQL запрос SELECT
        /// для проверки пересечений с уже имеющимися встречами
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Возвращает текстовое представление запроса типа SELECT</returns>
        public string CheckMeet(DateTime start, DateTime end)
        {
            return $"SELECT * FROM meets WHERE(startmeet BETWEEN \'{start}\' and \'{end}\') OR (endmeet BETWEEN \'{start}\' and \'{end}\')";
        }
    }
}
