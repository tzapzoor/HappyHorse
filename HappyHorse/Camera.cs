using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HappyHorse
{
    public class Camera
    {
        Vector2 cameraPosition = new Vector2(0, 0);
        Matrix viewMatrix;
        int ViewWidth = new int();
        public Matrix getViewMatrix
        {
            get { return viewMatrix; }
        }
        public void Initialize(int screenWidth)
        {
            ViewWidth = screenWidth;
        }

        public void Update(Vector2 playerPosition)
        {
            if(!(playerPosition.X>=7552))
                cameraPosition.X = playerPosition.X - (ViewWidth / 2);
            if (cameraPosition.X < 0)
                cameraPosition.X = 0;
            viewMatrix = Matrix.CreateTranslation(new Vector3(-cameraPosition, 0));
        }

    }
}
