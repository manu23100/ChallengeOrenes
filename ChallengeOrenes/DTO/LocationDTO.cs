namespace ChallengeOrenes.DTO
{
    public class LocationDTO
    {
        public int Id { get; set; }


        public int coordX { get; set; }


        public int coordY { get; set; }


        public int vehicleId { get; set; }

        public override string ToString()
        {
            return coordX + "," + coordY + "," + vehicleId;
        }
    }
}
