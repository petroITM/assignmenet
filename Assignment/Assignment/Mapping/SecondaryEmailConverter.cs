using Assignment.Model;
using AutoMapper;

namespace Assignment.Mapping
{
    public class StringToSecondaryEmailConverter : ITypeConverter<string, SecondaryEmail>
    {
        public SecondaryEmail Convert(string source, SecondaryEmail destination, ResolutionContext context)
        {
            destination = new SecondaryEmail();
            destination.EmailAddress = source;
            return destination;
        }
    }
}
