using Microsoft.AspNetCore.Http;

namespace BaseLayer.Logger;

public class RequestProfilerModel
{
    public DateTimeOffset RequestTime { get; set; }
    public HttpContext Context { get; set; }
    public string Request { get; set; }
    public string Response { get; set; }
    public DateTimeOffset ResponseTime { get; set; }
}
