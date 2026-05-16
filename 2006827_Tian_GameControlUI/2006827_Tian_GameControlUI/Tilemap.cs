using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameControlUI
{
    public class Tilemap
    {
        private Texture2D tileset;
        private int tilesetColumns;
        private int tilesetRows;
        private const int tileDimensions = 16;
        private int[,] tilemap;
        private Vector2 scale;

        public Tilemap(ContentManager content, string tilesetImagePath, int tilesetColumns, int tilesetRows, int[,] tilemap, Vector2 scale)
        {
            this.tileset = content.Load<Texture2D>(tilesetImagePath);
            this.tilesetColumns = tilesetColumns;
            this.tilesetRows = tilesetRows;
            this.tilemap = tilemap;
            this.scale = scale;

        }

        public void Draw(SpriteBatch batch)
        {
            Vector2 currPos = Vector2.Zero;

        }
    }
}
