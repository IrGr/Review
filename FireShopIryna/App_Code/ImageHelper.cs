using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ImageHelper
/// </summary>
public class ImageHelper
{
	public ImageHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

   
    /// <summary>
    /// Opret et Thumb, baseret på en fil og en mappe anvendes til flere filer
    /// </summary>
    /// <param name="imageSrc">Fil, som skal skaleres/kildefile</param>
    /// <param name="fileDestinationFullPath">Stien til den nye fil</param>
    /// <param name="newWidth">den ønskede bredde</param>
    /// <param name="quality">den ønskede kvalitet</param>
    /// <returns>Returns 0 if file is saved, 1 if file is absent,2 if exception is raised within konvert and save file</returns>
    public int MultiThumbUploader(Stream imageSrc, string fileDestinationFullPath, int newWidth, int newHeight, Int64 quality)
    {
        // find det uploadede image
        if (imageSrc == null)
        {
            return 1;
        }

        try
        {
            System.Drawing.Image OriginalImg = System.Drawing.Image.FromStream(imageSrc);

            // find højde og bredde på image
            int originalWidth = OriginalImg.Width;
            int originalHeight = OriginalImg.Height;

            //double ratio = (double)originalWidth;
            //int newHeight = originalHeight;

            //if (originalWidth > newWidth)
            //{
            //    // beregn den nye højde på thumbnailbilledet
            //    ratio = newWidth / (double)originalWidth;
            //    newHeight = Convert.ToInt32(ratio * originalHeight);
            //}
            //else
            //{
            //    newWidth = originalWidth;
            //}


            Bitmap Thumb = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
            Thumb.SetResolution(OriginalImg.HorizontalResolution, OriginalImg.VerticalResolution);

            // dette er alt hvad der skal til, for at kunne beholde billedets transparens!
            Thumb.MakeTransparent();

            Graphics ThumbMaker = Graphics.FromImage(Thumb);
            ThumbMaker.InterpolationMode = InterpolationMode.HighQualityBicubic;
            
            ThumbMaker.DrawImage(OriginalImg,
                new Rectangle(0, 0, newWidth, newHeight),
                new Rectangle(0, 0, originalWidth, originalHeight),
                GraphicsUnit.Pixel);


            ImageCodecInfo encoder;
            string fileExt = System.IO.Path.GetExtension(fileDestinationFullPath);
            switch (fileExt)
            {
                case ".png":
                    encoder = GetEncoderInfo("image/png");
                    break;

                case ".gif":
                    encoder = GetEncoderInfo("image/gif");
                    break;

                default:
                    // default til JPG 
                    encoder = GetEncoderInfo("image/jpeg");
                    break;
            }


            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            // gem thumbnail i mappen 
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(fileDestinationFullPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    Thumb.Save(memory, encoder, encoderParameters);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }

            //// Fjern originalbilledet, thumbnail mm, fra computerhukommelsen
            OriginalImg.Dispose();
            ThumbMaker.Dispose();
            Thumb.Dispose();
        }
        catch (Exception ex)
        {

            return 2;
        }

        return 0;
    }


    private static ImageCodecInfo GetEncoderInfo(String mimeType)
    {
        ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
        for (int i = 0; i < encoders.Length; i++)
        {
            if (encoders[i].MimeType == mimeType)
            {
                return encoders[i];
            }
        }
        return null;
    }

}