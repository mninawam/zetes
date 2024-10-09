using Intent.RoslynWeaver.Attributes;

 
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.AspNetCore.IntegrationTesting.DtoContract", Version = "2.0")]

namespace CSVFile.IntegrationTests.Services.CSVFiles
{
    public class FieldDto
    {
        public FieldDto()
        {
            Name = null!;
            Type = null!;
            Searchable = null!;
            Filterable = null!;
            Visible = null!;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Searchable { get; set; }
        public string Filterable { get; set; }
        public string Visible { get; set; }

        public static FieldDto Create(string name, string type, string searchable, string filterable, string visible)
        {
            return new FieldDto
            {
                Name = name,
                Type = type,
                Searchable = searchable,
                Filterable = filterable,
                Visible = visible
            };
        }
    }
}