using System;

public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Footer { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}\nContent: {Content}\nFooter: {Footer}";
    }
}

public class ReportBuilder
{
    private readonly Report _report;

    public ReportBuilder()
    {
        _report = new Report();
    }

    public ReportBuilder SetTitle(string title)
    {
        _report.Title = title;
        return this;
    }

    public ReportBuilder SetContent(string content)
    {
        _report.Content = content;
        return this;
    }

    public ReportBuilder SetFooter(string footer)
    {
        _report.Footer = footer;
        return this;
    }

    public Report Build()
    {
        return _report;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var reportBuilder = new ReportBuilder();
        var report = reportBuilder
            .SetTitle("Monthly Report")
            .SetContent("This is the content of the monthly report.")
            .SetFooter("Page 1")
            .Build();

        Console.WriteLine(report);
    }
}