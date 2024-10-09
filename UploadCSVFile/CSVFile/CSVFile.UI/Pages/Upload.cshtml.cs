using CSVFile.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text;

namespace CSVFile.UI.Pages
{
  public class UploadModel : PageModel
  {
    [BindProperty]
    public IFormFile CsvFile { get; set; }
    public List<FileMetadata> FileMetadataList { get; set; }
    public string HtmlTable { get; private set; }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!IsCsvFile(CsvFile))
      {
        ModelState.AddModelError("CsvFile", "Please upload a valid CSV file.");
        return Page();
      }

      using (var memoryStream = new MemoryStream())
      {
        await CsvFile.CopyToAsync(memoryStream);
        var fileBytes = memoryStream.ToArray();
        var base64String = Convert.ToBase64String(fileBytes);

        // Call the API with the base64 string
        using (var httpClient = new HttpClient())
        {
          var content = new StringContent(JsonSerializer.Serialize(new { FileContents = base64String }), Encoding.UTF8, "application/json");
          var response = await httpClient.PostAsync("https://localhost:44388/api/csvfiles", content);

          if (response.IsSuccessStatusCode)
          {
            var responseString = await response.Content.ReadAsStringAsync();
            ImportResult apiResponses = JsonSerializer.Deserialize<ImportResult>(responseString);
            //FileMetadataList = JsonSerializer.Deserialize<List<FileMetadata>>(responseString);
            if(apiResponses.errors.Any())
            {
              foreach (var error in apiResponses.errors)
              {
                ModelState.AddModelError(string.Empty, error);
              }
              return Page();
            }
            HtmlTable = GenerateHtmlTable(apiResponses.fieldData);
          }
          else
          {
            ModelState.AddModelError(string.Empty, "Error uploading file to API.");
          }
        }
      }

      return Page();
    }

    private string GenerateHtmlTable(List<ApiResponse> apiResponses)
    {
      var headers = apiResponses.SelectMany(r => r.fieldData.data.Select(d => d.key)).Distinct().ToList();

      var html = "<table border='1' class='table'>";
      html += "<tr>";
      foreach (var header in headers)
      {
        html += $"<th>{header}</th>";
      }
      html += "</tr>";

      foreach (var response in apiResponses)
      {
        html += "<tr>";
        foreach (var header in headers)
        {
          var value = response.fieldData.data.FirstOrDefault(d => d.key == header)?.value ?? string.Empty;
          html += $"<td>{value}</td>";
        }
        html += "</tr>";
      }

      html += "</table>";
      return html;
    }

    private bool IsCsvFile(IFormFile file)
    {
      if (file == null || file.Length == 0)
        return false;

      var extension = Path.GetExtension(file.FileName).ToLower();
      if (extension != ".csv")
        return false;

      var mimeType = file.ContentType.ToLower();
      if (mimeType != "text/csv" && mimeType != "application/vnd.ms-excel")
        return false;

      return true;
    }

  }
}
