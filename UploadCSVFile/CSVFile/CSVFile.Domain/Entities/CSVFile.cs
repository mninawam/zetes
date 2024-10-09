using System;
using System.Collections.Generic;
using CSVFile.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "2.0")]

namespace CSVFile.Domain.Entities
{
  public class CSVFile : IHasDomainEvent
  {
    public Guid Id { get; set; }
    public virtual List<CSVField> Fields { get; set; } = new List<CSVField>();
    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
  }

  public class FieldData
  {
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public int FieldId { get; set; }
    public virtual Field Field { get; set; }
  }

  public class Field
  {
    public int Id { get; set; }
    public virtual List<FieldData> Data { get; set; } = new List<FieldData>();

    // Public or protected constructor
    public Field() { }
  }

  public class CSVField
  {
    public int Id { get; set; }
    public virtual Field FieldData { get; set; } = new Field();
  }

  public class ImportResult
  {
    public List<CSVField> FieldData { get; set; }  = new List<CSVField>();
    public List<string> Errors { get; set; } = new List<string>();
  }

}