namespace LabProjectDemo.Infrastructure.ProductionLines.DTO
{
    public class LineJsonDTO
    {
        public List<CameraJsonDTO> productCamera { get; set; }
        public List<CameraJsonDTO> boxCamera { get; set; }
        public List<CameraJsonDTO> palletCamera { get; set; }
        public List<PrinterJsonDTO> printer { get; set; }


    }
}
