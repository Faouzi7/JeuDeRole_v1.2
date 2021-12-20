using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;

namespace JeuDeRole_v1._2
{
    public class MaitreDuJeu
    {

        #region MyRegion
        public static Joueur Joueur
        {
            get => default;
            set
            {
            }
        }

        public MonstreFacile MonstreFacile
        {
            get => default;
            set
            {
            }
        }

        public De De
        {
            get => default;
            set
            {
            }
        }
        #endregion

        public string text1 = $"Aventurier saisie ton pseudo:";
        //public string text2 = $"{Joueur.Nom} appuis sur touche pour lancer le prochain tour...";
        string text3 = $"";
        string text4 = $"";
        string text5 = $"";

        public void CadrageFenetre(int hauteurFenetre, int largeurFenetre)
        {
            Console.SetWindowSize(hauteurFenetre, largeurFenetre);
            Console.SetBufferSize(hauteurFenetre, largeurFenetre);
        }

        public void Message1()
        {
            var text =this.text1;
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write((text[i]));
                Thread.Sleep(100);
                //Console.Clear();
            }
        }
        //public void Message2()
        //{
        //    var text2 = this.text2;
        //    for (int i = 0; i < text2.Length; i++)
        //    {
        //        Console.Write((text2[i]));
        //        Thread.Sleep(100);
        //    }
        //}
        public void DrawABox(int x, int y, int width, int height, char Edge, string Message)
        {
            int LastIndex = 0;
            Console.SetCursorPosition(x, y);
            for (int h_i = 0; h_i <= height; h_i++)
            {
                if (LastIndex != -1)
                {
                    int seaindex = (LastIndex + (width - 1));
                    if (seaindex >= Message.Length - 1)
                        seaindex = Message.Length - 1;
                    int newIndex = Message.LastIndexOf(' ', seaindex);
                    if (newIndex == -1)
                        newIndex = Message.Length - 1;
                    string substr = Message.Substring(LastIndex, newIndex - LastIndex);
                    LastIndex = newIndex;
                    Console.SetCursorPosition(x + 1, y + h_i);
                    Console.Write(substr);
                }
                for (int w_i = 0; w_i <= width; w_i++)
                {
                    if (h_i % height == 0 || w_i % width == 0)
                    {
                        Console.SetCursorPosition(x + w_i, y + h_i);
                        Console.Write(Edge);
                    }
                }
            }
        }
        #region MyRegion
        private static void Intro()
        {
            Image image = Image.FromFile(@"C:\Users\neoco\source\repos\JeuDeRole_v1.10\Drawning\Images\1.gif");
            FrameDimension dimension = new FrameDimension(image.FrameDimensionsList[0]);

            int frameCount = image.GetFrameCount(dimension);
            StringBuilder sb;

            int left = Console.WindowLeft, top = Console.WindowTop;

            char[] chars = { '.', '.', '#', '#', '=', '+', ' ', ':', '-', '.', ' ' };

            for (int i = 0; ; i = (i + 1) % frameCount)
            {
                sb = new StringBuilder();
                image.SelectActiveFrame(dimension, i);

                for (int h = 0; h < image.Height; h++)
                {
                    for (int w = 0; w < image.Width; w++)
                    {
                        Color cl = ((Bitmap)image).GetPixel(w, h);
                        int gray = (cl.R + cl.G + cl.B) / 3;
                        int index = (gray * (chars.Length - 1)) / 255;

                        sb.Append(chars[index]);
                    }
                    sb.Append('\n');
                }

                Console.SetCursorPosition(left, top);
                Console.Write(sb.ToString());

                Thread.Sleep(80);
            }
        }
        private static Image ScaleImage(Image source, int width, int height)
        {
            Image dest = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(Brushes.White, 0, 0, width, height);
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                float srcwidth = source.Width;
                float srcheight = source.Height;
                float dstwidth = width;
                float dstheight = height;

                if (srcwidth <= dstwidth && srcheight <= dstheight)
                {
                    int left = (width - source.Width) / 3;
                    int top = (height - source.Height) / 3;
                    gr.DrawImage(source, left, top, source.Width, source.Height);
                }
                else if (srcwidth / srcheight > dstwidth * dstheight)
                {
                    float cy = srcheight / srcwidth * dstwidth;
                    float top = ((float)dstheight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(source, 0, top, dstwidth, cy);
                }
                else
                {
                    float cx = srcheight = srcwidth / srcheight * dstheight;
                    float left = ((float)dstwidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                }

                return dest;
            }
        }
        #endregion


    }

}