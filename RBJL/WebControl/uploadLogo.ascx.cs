using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class WebControl_uploadLogo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public bool uploadLogo(ref string path)
    {
        bool result = false;
        if (FileUploadLogo.HasFile)
        {
            int fileSize = FileUploadLogo.PostedFile.ContentLength;
            int maxFileSize = 3;
            if (fileSize > (maxFileSize * 1024 * 1024))
            {
                //displayAlert("Filesize of image is too large. Maximum file size permitted is " + maxFileSize + "MB");
                return false;
            }

            string fileExt = System.IO.Path.GetExtension(FileUploadLogo.FileName).ToLower();
            string[] arrExtension = { ".gif", ".jpg", ".jpeg", ".bmp", ".png", ".mp4" };
            for (int i = 0; i < arrExtension.Length; i++)
            {
                if (fileExt.Equals(arrExtension[i]))
                {
                    Random rm = new Random();
                    string tempFileNmae = String.Format("{0:yyyyMMdd}", DateTime.Now) + "_" + (rm.Next(100000, 999999)).ToString() + "_" + System.IO.Path.GetFileName(FileUploadLogo.FileName);
                    string divName = HttpContext.Current.Server.MapPath("~/Logo/");
                    string savePath = HttpContext.Current.Server.MapPath("~/Logo/" + tempFileNmae);


                    System.Drawing.Image image_file = System.Drawing.Image.FromStream(FileUploadLogo.PostedFile.InputStream);
                    int image_height = image_file.Height;
                    int image_width = image_file.Width;
                    int max_height = 130;
                    int max_width = 550;

                    image_height = (image_height * max_width) / image_width;
                    image_width = max_width;

                    if (image_height > max_height)
                    {
                        image_width = (image_width * max_height) / image_height;
                        image_height = max_height;
                    }

                    Bitmap bitmap_file = new Bitmap(image_file, image_width, image_height);
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();

                    bitmap_file.Save(savePath);


                    //FileUploadLogo.SaveAs(savePath);
                    path = "~/Logo/" + tempFileNmae;
                    return true;
                }
            }
        }
        return result;

    }

}