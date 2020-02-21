using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingImage
{
    //Bitmapをbyte配列に落として使う
    class ImageData
    {
        public byte[] pixels;//BGR(a)の順に入っている
        public int Width;
        public int Height;

        //
        public ImageData(byte[] bytes,int Width,int Height)
        {
            this.pixels = bytes;
            this.Width = Width;
            this.Height = Height;
        }

        public ImageData(Bitmap bitmap)
        {
            //画像が24bit画像でない場合もとりあえず24bit画像に変換して扱う
            if (bitmap.PixelFormat != PixelFormat.Format24bppRgb)
            {
                bitmap = bitmap.Clone(new RectangleF(0, 0, bitmap.Width, bitmap.Height), PixelFormat.Format24bppRgb);
            }


            // Bitmapをロックし、BitmapDataを取得する
            BitmapData bitmapData =
                bitmap.LockBits( new Rectangle(0, 0, bitmap.Width, bitmap.Height),ImageLockMode.WriteOnly, bitmap.PixelFormat);

            // 変換対象のカラー画像の情報をバイト列へ書き出す
            byte[] pixels = new byte[bitmapData.Stride * bitmapData.Height];
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, pixels, 0, pixels.Length);
            //
            bitmap.UnlockBits(bitmapData);

            this.pixels = pixels;
            this.Width = bitmap.Width;
            this.Height = bitmap.Height;
        }

        //bitmapとして書き出す
        public Bitmap GenerateBitmap()
        {
            Bitmap bitmap = new Bitmap(this.Width,this.Height);
            //生成する画像サイズを決定
            Rectangle rect = new Rectangle(0,0,this.Width,this.Height);
            //画像サイズとフォーマットを決定
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            //bitmapDataに書き出し
            System.Runtime.InteropServices.Marshal.Copy(this.pixels, 0, bitmapData.Scan0, pixels.Length);
            
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        //輝度変換(グレースケール)
        public void LuminanceGray()
        {
            //輝度変換の係数
            const double vR = 0.2126, vG = 0.7152, vB = 0.0722;

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++ )
                {
                    int position = y*Width*3 + x*3;
                    double sum = (pixels[position] * vB + pixels[position + 1] * vG + pixels[position + 2] * vR) / 3.0;
                    byte result = DoubleToByte(sum);

                    pixels[position] = result;
                    pixels[position + 1] = result;
                    pixels[position + 2] = result;
                }
            }
        }
        //明度変換
        public void BrightnessGray()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int position = y * Width * 3 + x * 3;
                    double sum = (pixels[position] + pixels[position + 1] + pixels[position + 2]) / 3.0;
                    byte avg = DoubleToByte(sum / 3.0);

                    pixels[position] = avg;
                    pixels[position + 1] = avg;
                    pixels[position + 2] = avg;
                }
            }
        }
        
        //閾値で二値化
        public void Binarization(int Threshold)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int position = y * Width * 3 + x * 3;
                    double sum = (pixels[position] + pixels[position + 1] + pixels[position + 2]) / 3;
                    byte avg = DoubleToByte(sum / 3);
                    
                    if(avg < Threshold)
                    {
                        avg = 0;
                    }
                    else
                    {
                        avg = 255;
                    }
                    
                    pixels[position] = avg;
                    pixels[position + 1] = avg;
                    pixels[position + 2] = avg;
                }
            }
        }
        //エッジ抽出
        public void EdgeExtraction()
        {
            const int maskSize = 3;
            double[,] mask = new double[maskSize, maskSize]{
                                {1.0,1.0,1.0},
                                {1.0,-8.0,1.0},
                                {1.0,1.0,1.0}};

            byte[] edgeImg = new byte[pixels.Length];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    double sum = 0;
                    int position = y * Width * 3 + x * 3;

                    for (int k = -maskSize / 2; k <= maskSize / 2; k++)
                    {
                        for (int n = -maskSize / 2; n <= maskSize / 2; n++)
                        {
                            if (x + n >= 0 && x + n < Width && y + k >= 0 && y + k < Height)
                            {
                                int diff = n * 3 + k * Width * 3;
                                sum += pixels[position + diff] * mask[n + maskSize / 2, k + maskSize / 2];
                            }
                        }
                    }

                    edgeImg[position] = (byte)(255 - DoubleToByte(sum));
                    edgeImg[position+1] = (byte)(255 - DoubleToByte(sum));
                    edgeImg[position + 2] = (byte)(255 - DoubleToByte(sum));
                }
            }

            pixels = edgeImg;
        }
        //回転
        public void RotateImage(double theta)
        {
            //回転後の画像の縦横のサイズ計算
            double calcH = Width * Math.Abs(Math.Sin(theta * Math.PI / 180)) + Height * Math.Abs(Math.Sin((90.0 - theta) * Math.PI / 180));
            double calcW = Width * Math.Abs(Math.Cos(theta * Math.PI / 180)) + Height * Math.Abs(Math.Cos((90.0 - theta) * Math.PI / 180));
            //intにキャスト
            int afterH = (int)calcH;
            int afterW = (int)calcW;
            //回転後の配列
            byte[] rotatePixels = new byte[Height * Width * 3];

            for (int y = -Height/2; y < Height/2; y++)
            {
                for (int x = -Width/2; x < Width/2; x++)
                {

                    //回転後の座標
                    int position = (y + Height / 2) * Width * 3 + (x + Width / 2) * 3;
                    //回転前の座標を求める
                    double bX = x * Math.Cos(theta * Math.PI / 180) + y * Math.Sin(theta * Math.PI / 180) + Width/2;
                    double bY = -x * Math.Sin(theta * Math.PI / 180) + y * Math.Cos(theta * Math.PI / 180) + Height/2;

                    if (bX < 0 || bX >= Width || bY < 0 || bY >= Height) continue;

                    int bPosition = (int)bY * Width * 3 + (int)bX * 3;
                    
                    rotatePixels[position] = pixels[bPosition];
                    rotatePixels[position + 1] = pixels[bPosition + 1];
                    rotatePixels[position + 2] = pixels[bPosition + 2];
            
                }
            }

            ImageData rotateData = new ImageData(rotatePixels,Width,Height);
        }
    
        public void BrightnessAdjustment(int rate)
        {
            double per = (double)rate / 100;
            Console.WriteLine("per:"+per);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int position = y * Width * 3 + x * 3;

                    pixels[position] = DoubleToByte(pixels[position]*per); 
                    pixels[position + 1] = DoubleToByte(pixels[position+1] * per);
                    pixels[position + 2] = DoubleToByte(pixels[position+2] * per);
                }
            }
        }

        public void ContrastAdjustment()
        {

        }

        //
        private static byte DoubleToByte(double num)
        {
            if (num > 255) return 255;
            else if (num < 0) return 0;
            else return (byte)num;
        }

        private static byte IntToByte(int num)
        {
            return (byte)num;
        }
    }

}
