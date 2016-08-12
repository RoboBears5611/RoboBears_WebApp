namespace RoboBears.DataContracts
{
    public class ImageData
    {
        public int ImageDataId { get; set; }

        public string ImageName { get; set; }

        public byte[] imageData { get; set; }

        public ImageType ImageType { get; set; }

        public Description Description { get; set; }

    }
}