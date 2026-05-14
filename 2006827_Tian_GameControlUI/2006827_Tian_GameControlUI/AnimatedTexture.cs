using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameControlUI
{
    public class AnimatedTexture
    {
        private int frameCount;
        private int columns;
        private int rows;
        public int Row { get; set; } = 0;
        private Texture2D texture;
        private float timePerFrame;
        private int frame;
        private float totalElapsed;
        private bool isPaused;
        public float Rotation, Depth;
        public Microsoft.Xna.Framework.Vector2 Scale;
        public Microsoft.Xna.Framework.Vector2 Origin;
        public int FrameHeight;
        public int FrameWidth;

        // constructor
        public AnimatedTexture(Microsoft.Xna.Framework.Vector2 origin, float rotation, Microsoft.Xna.Framework.Vector2 scale, float depth)
        {
            this.Origin = origin;
            this.Rotation = rotation;
            this.Scale = scale;
            this.Depth = depth;
        }

        public void Load(ContentManager content, string asset, int frameCount, int columns, int rows, int framesPerSec)
        {
            this.frameCount = frameCount;
            this.columns = columns;
            this.rows = rows;
            texture = content.Load<Texture2D>(asset);
            timePerFrame = (float)1 / framesPerSec;
            frame = 0;
            totalElapsed = 0;
            isPaused = false;
        }

        public void UpdateFrame(float elapsed)
        {
            if (isPaused)
            {
                return;
            }
            totalElapsed += elapsed;
            if (totalElapsed > timePerFrame)
            {
                frame++;
                frame %= frameCount;
                totalElapsed -= timePerFrame;
            }
        }

        public void DrawFrame(SpriteBatch batch, Microsoft.Xna.Framework.Vector2 screenPos, Microsoft.Xna.Framework.Graphics.SpriteEffects spriteEffect)
        {
            DrawFrame(batch, frame, screenPos, spriteEffect);
        }

        public void DrawFrame(SpriteBatch batch, int frame, Microsoft.Xna.Framework.Vector2 screenPos, Microsoft.Xna.Framework.Graphics.SpriteEffects spriteEffect)
        {
            FrameWidth = texture.Width / columns;
            FrameHeight = texture.Height / rows;
            Microsoft.Xna.Framework.Rectangle sourceRect = new Microsoft.Xna.Framework.Rectangle(FrameWidth * frame, FrameHeight * Row, FrameWidth, FrameHeight);
            batch.Draw(texture, screenPos, sourceRect, Microsoft.Xna.Framework.Color.White, Rotation, Origin, Scale, spriteEffect, Depth);
        }
    }
}
