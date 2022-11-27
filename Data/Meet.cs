namespace ForRS.Data
{
    public class Meet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartMeet { get; set; } = DateTime.Now.AddDays(1);
        public DateTime EndMeet { get; set; } = DateTime.Now.AddDays(1);
        public int Alert { get; set; }

        public Meet(string title, DateTime start, DateTime end, int alert)
        {
            Title = title;
            StartMeet = start;
            EndMeet = end;
            Alert = alert;
        }

        public Meet()
        {
        }
    }
}
