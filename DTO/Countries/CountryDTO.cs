namespace DTO.Countries
{
    public class CountryDTO
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public CountryDTO(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
