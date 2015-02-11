using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HappyHorse
{
    public class Animation
    {
        private const int Frames = 7;
        double TotalElapsed = 0;
        int Frame = 0;
        public int getFrame
        {
            get { return Frame; }
        }
        public void UpdateFrame(float elapsed, float Speed, double FrameTime)
        {
            if (Speed==0)
            {
                Frame = 0;
            }
            else
            {
                TotalElapsed += elapsed;
                if (TotalElapsed > FrameTime)
                {
                    Frame++;
                    if (Frame >= Frames)
                        Frame = 0;
                    TotalElapsed -= FrameTime;
                }
            }
        }
    }
}
