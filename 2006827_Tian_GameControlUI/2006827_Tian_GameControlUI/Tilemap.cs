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
using System.Text.RegularExpressions;
using System.IO;

namespace GameControlUI
{
    public class Tilemap
    {
        private Texture2D tileset;
        private int tilesetColumns;
        private int tilesetRows;
        private const int tileDimensions = 16;
        private (int, int)[,] tilemap;
        private Vector2 scale;

        public Tilemap(ContentManager content, string tilesetImagePath, string tilemapTextPath, int tilemapColumns, int tilemapRows, int tilesetColumns, int tilesetRows, Vector2 scale)
        {
            this.tileset = content.Load<Texture2D>(tilesetImagePath);
            this.tilesetColumns = tilesetColumns;
            this.tilesetRows = tilesetRows;
            this.tilemap = tilemap;
            this.scale = scale;
            tilemap = new (int, int)[tilemapRows, tilemapColumns];

            string line;
            StreamReader sr = new StreamReader(tilemapTextPath);
            line = sr.ReadLine();
            for (int currentRow = 0; currentRow < tilesetRows; currentRow++)
            {
                string[] coords = Regex.Split(line, @"\((\d,\d)\)");

                for (int currentColumn = 1; currentColumn < coords.Length; currentColumn += 2)
                {
                    MatchCollection coordInts = Regex.Matches(coords[currentColumn], @"\d");
                    tilemap[currentRow, (int)(currentColumn - 1) / 2] = (int.Parse(coordInts[0].Value), int.Parse(coordInts[1].Value));
        }
            }
        }

        public void Load(ContentManager content, string tilesetImagePath)
        {
            this.tileset = content.Load<Texture2D>(tilesetImagePath);
        }

        public void Draw(SpriteBatch batch)
        {
            Vector2 currPos = Vector2.Zero;

        }
    }
}
