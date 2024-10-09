namespace CSVFile.UI.Models
{
	public class FileMetadata
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public string Searchable { get; set; }
		public string Filterable { get; set; }
		public string Visible { get; set; }
	}

  public class FieldDataItem
  {
    public int Id { get; set; }
    public string key { get; set; }
    public string value { get; set; }
    public int FieldId { get; set; }
    public object Field { get; set; }
  }

  public class FieldData
  {
    public int Id { get; set; }
    public List<FieldDataItem> data { get; set; } = new List<FieldDataItem>();
  }

  public class ApiResponse
  {
    public int Id { get; set; }
    public FieldData fieldData { get; set; }
  }

  public class ImportResult
  {
    public List<ApiResponse> fieldData { get; set; } = new List<ApiResponse>();
    public List<string> errors { get; set; } = new List<string>();
  }

}
