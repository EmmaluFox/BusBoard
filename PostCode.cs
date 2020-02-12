namespace BusBoard
{
    public class PostCode
    {
        public PostCode(string adminWard, float latitude, float longitude)
        {
            AdminWard = adminWard;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string AdminWard { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}