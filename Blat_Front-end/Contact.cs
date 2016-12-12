using FileHelpers;

namespace Blat_Front_end
{
    [DelimitedRecord(",")]
    public class Contact
    {
        public string firstName;
        public string lastName;
        public string emailAddress;
    }
}
