using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidManager.Utility
{
    class ImageHelper
    {
        public static void MakeThumbnail(string imgPath_old, string imgPath_new, int width, int height, string mode, string type)
        {

            System.Drawing.Image img = System.Drawing.Image.FromFile(imgPath_old);
            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = img.Width;
            int oh = img.Height;

            switch (mode.ToUpper())
            {
                case "HW":  //指定高宽缩放（可能变形） 
                    break;
                case "W":  //指定宽，高按比例
                    if (width > img.Width)
                    {
                        towidth = img.Width;
                        toheight = img.Height;
                    }
                    else
                    {
                        toheight = img.Height * width / img.Width;
                    }
                    break;
                case "H":  //指定高，宽按比例
                    if (height > img.Height)
                    {
                        toheight = img.Height;
                        towidth = img.Width;
                    }
                    towidth = img.Width * height / img.Height;
                    break;
                case "CUT":   //指定高宽裁减（不变形） 
                    if ((double)img.Width / (double)img.Height > (double)towidth / (double)toheight)
                    {
                        oh = img.Height;
                        ow = img.Height * towidth / toheight;
                        y = 0;
                        x = (img.Width - ow) / 2;
                    }
                    else
                    {
                        ow = img.Width;
                        oh = img.Width * height / towidth;
                        x = 0;
                        y = (img.Height - oh) / 2;
                    }
                    break;
                case "DB":    // 按值较大的进行等比缩放（不变形）
                    if (width > img.Width && height > img.Height)
                    {
                        toheight = img.Height;
                        towidth = img.Width;
                    }
                    else if ((double)img.Width / (double)towidth < (double)img.Height / (double)toheight)
                    {
                        toheight = height;
                        towidth = img.Width * height / img.Height;
                    }
                    else
                    {
                        towidth = width;
                        toheight = img.Height * width / img.Width;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(img, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //保存缩略图
                switch (type.ToUpper())
                {
                    case "JPG":
                        bitmap.Save(imgPath_new, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "GIF":
                        bitmap.Save(imgPath_new, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "PNG":
                        bitmap.Save(imgPath_new, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case "BMP":
                        bitmap.Save(imgPath_new, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    default:
                        break;
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                img.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
    }
}
