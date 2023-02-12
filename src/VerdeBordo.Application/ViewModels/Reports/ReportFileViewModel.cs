namespace VerdeBordo.Application.ViewModels.Reports;

public class ReportFileViewModel
{
    public ReportFileViewModel(byte[] content, string reportFileName, string reportFileType)
    {
        Content = content;
        ReportFileName = reportFileName;
        ReportFileType = reportFileType;
    }

    public byte[] Content { get; set; }
    public string ReportFileName { get; set; }
    public string ReportFileType { get; set; }
}
