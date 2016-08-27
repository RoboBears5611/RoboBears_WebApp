using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class ImageData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageDataId { get; set; }

        public string ImageName { get; set; }

        public byte[] imageData { get; set; }

        public string ImageType { get; set; }

        public int? DescriptionId { get; set; }

        public static explicit operator DataContracts.ImageData(ImageData value)
        {
            return new DataContracts.ImageData()
            {
                Description = (DataContracts.Description)new DatabaseContext().Descriptions.Find(value.DescriptionId),
                imageData = value.imageData,
                ImageDataId = value.ImageDataId,
                ImageName = value.ImageName,
                ImageType = (DataContracts.ImageType)Enum.Parse(typeof(DataContracts.ImageType), value.ImageType),
            };
        }

        public static explicit operator ImageData(DataContracts.ImageData value)
        {
            return new ImageData()
            {
                DescriptionId = value.Description.DescriptionId,
                imageData = value.imageData,
                ImageDataId = value.ImageDataId,
                ImageName = value.ImageName,
                ImageType = value.ImageType.ToString()
            };
        }
    }
}