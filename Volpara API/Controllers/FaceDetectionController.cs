using Microsoft.AspNetCore.Mvc;
using Google.Cloud.Vision.V1;

namespace Volpara_API.Controllers;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class FaceDetectionController : ControllerBase
{
    private readonly ILogger<FaceDetectionController> _logger;

    public FaceDetectionController(ILogger<FaceDetectionController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IEnumerable<string> Post([FromBody] List<string> imageStrings)
    {
        var confidenceLevels = new List<string>();
        var client = ImageAnnotatorClient.Create();
        foreach (var imageString in imageStrings)
        {
            var stringBuilder = new StringBuilder();
            var image = GetImage(imageString);
            var result = client.DetectFaces(image);
            foreach (var face in result)
            {
                string poly = string.Join(" - ", face.BoundingPoly.Vertices.Select(v => $"({v.X}, {v.Y})"));
                stringBuilder.Append($"Confidence: {(int)(face.DetectionConfidence * 100)}%; BoundingPoly: {poly}");
            }
            confidenceLevels.Add(stringBuilder.ToString());
        }

        return confidenceLevels.AsEnumerable();
    }

    private Image GetImage(string imageString)
    {
        var bytes = Convert.FromBase64String(imageString);
        return Image.FromBytes(bytes);
    }
}

