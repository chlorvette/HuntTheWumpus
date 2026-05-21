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
        private int tileDimensions;
        private (int, int)[,] coordinateTilemap; // tilemap made up of the coordinates on the tileset that correspond to the correct tile that goes there
        private string[,] templateTilemap; // tilemap made up of the keys for each tile type formatted in tilemap format (i.e. A,B,C\nA,B,C)
        private Vector2 scale;
        private string tilesetImagePath;
        private int tilemapWidth;
        private int tilemapHeight;
        private (string, string)[] doorPairs =
        {
            ("BDL", "BDR"),
            ("FDL", "FDR"),
            ("LDT", "LDB"),
            ("RDT", "RDB")
        }; // config door pair keys

        public Tilemap(ContentManager content, string tilesetImagePath, string tilemapTemplatePath, int tileDimensions, (int, int) tilemapDimensions, Vector2 scale, string tilesetKeyPath, int choicesPerType, int totalTypes)
        {
            this.tilesetImagePath = tilesetImagePath;
            this.scale = scale;
            this.tileDimensions = tileDimensions;
            int tilemapRows = tilemapDimensions.Item1;
            int tilemapColumns = tilemapDimensions.Item2;
            this.tilemapWidth = tilemapColumns * tileDimensions * (int)scale.X;
            this.tilemapHeight = tilemapRows * tileDimensions * (int)scale.Y;
            templateTilemap = new string[tilemapRows, tilemapColumns];
            coordinateTilemap = new (int, int)[tilemapRows, tilemapColumns];

            int currentRow = 0;
            using (StreamReader sr = new StreamReader(tilemapTemplatePath))
            {
                for (currentRow = 0; currentRow < tilemapRows; currentRow++)
                {
                    string line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] row = line.Split(",");
                        for (int columnIndex = 0; columnIndex < row.Length; columnIndex++)
                        {
                            templateTilemap[currentRow, columnIndex] = row[columnIndex];
                        }
                    }
                }
            }

            string[] keys = new string[totalTypes];
            (int, int)[,] values = new (int, int)[totalTypes, choicesPerType];

            currentRow = 0;
            using (StreamReader sr = new StreamReader(tilesetKeyPath))
            {
                string line;
                for (currentRow = 0; (line = sr.ReadLine()) != null; currentRow++)
                {
                    string[] splitString = line.Split("(", 2);
                    string key = splitString[0];
                    keys[currentRow] = key;
                    string valuesString = "(" + splitString[1];
                    string[] valuesCoordinates = Regex.Split(valuesString, @"\((\d+,\d+)\)");
                    for (int valueIndex = 1; valueIndex < valuesCoordinates.Length; valueIndex += 2)
                    {
                        MatchCollection coordinateIntegers = Regex.Matches(valuesCoordinates[valueIndex], @"\d+");
                        if (coordinateIntegers.Count == 2) values[currentRow, (valueIndex - 1) / 2] = (int.Parse(coordinateIntegers[0].Value), int.Parse(coordinateIntegers[1].Value));
                    }
                }
            }

            Random random = new Random();
            for (currentRow = 0; currentRow < templateTilemap.GetLength(0); currentRow++)
            {
                for (int columnIndex = 0; columnIndex < templateTilemap.GetLength(1); columnIndex++)
                {
                    string tileType = templateTilemap[currentRow, columnIndex];
                    if (tileType == "X")
                    {
                        coordinateTilemap[currentRow, columnIndex] = (tilemapRows + 1, tilemapColumns + 1);
                    } else
                    {
                        coordinateTilemap[currentRow, columnIndex] = values[Array.IndexOf(keys, tileType), random.Next(choicesPerType)];
                    }
                }
            }
        }

        public Tilemap(ContentManager content, string tilesetImagePath, string tilemapTextPath, int tileDimensions, (int, int) tilemapDimensions, Vector2 scale)
        {
            this.tileDimensions = tileDimensions;
            this.scale = scale;
            int tilemapRows = tilemapDimensions.Item1;
            int tilemapColumns = tilemapDimensions.Item2;
            coordinateTilemap = new (int, int)[tilemapRows, tilemapColumns];

            using (StreamReader sr = new StreamReader(tilemapTextPath))
            {
                for (int currentRow = 0; currentRow < tilemapRows; currentRow++)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }

                    string[] coordinates = Regex.Split(line, @"\((\d+,\d+)\)");

                    for (int currentColumn = 1; currentColumn < coordinates.Length; currentColumn += 2)
                    {
                        MatchCollection coordinateIntegers = Regex.Matches(coordinates[currentColumn], @"\d+");
                        int gridX = (currentColumn - 1) / 2;

                        if (gridX < tilemapColumns)
                        {
                            coordinateTilemap[currentRow, gridX] = (int.Parse(coordinateIntegers[0].Value), int.Parse(coordinateIntegers[1].Value));
                        }
                    }
                }
            }
        }

        public void Load(ContentManager content)
        {
            this.tileset = content.Load<Texture2D>(tilesetImagePath);
        }

        public void Draw(SpriteBatch batch)
        {
            int scaledTileDimensions = (int)(tileDimensions * scale.X);
            Vector2 brushPos;

            for (int gridY = 0; gridY < coordinateTilemap.GetLength(0); gridY++)
            {
                for (int gridX = 0; gridX < coordinateTilemap.GetLength(1); gridX++)
                {
                    int tilesetX = coordinateTilemap[gridY, gridX].Item1 * tileDimensions;
                    int tilesetY = coordinateTilemap[gridY, gridX].Item2 * tileDimensions;
                    brushPos = new Vector2(gridX * scaledTileDimensions, gridY * scaledTileDimensions);
                    Rectangle sourceRectangle = new Rectangle(tilesetX, tilesetY, tileDimensions, tileDimensions);
                    batch.Draw(tileset, brushPos, sourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                }
            }
        }

        public Rectangle[] getWallCollisionRect()
        {
            Rectangle[] rectangles = new Rectangle[4];

            rectangles[0] = new Rectangle(0, 0, tilemapWidth, tileDimensions); // top
            rectangles[1] = new Rectangle(0, 0, tileDimensions, tilemapHeight); // left
            rectangles[2] = new Rectangle((tilemapWidth - tileDimensions), 0, tileDimensions * (int)scale.X, tilemapHeight); // right
            rectangles[3] = new Rectangle(0, (tilemapHeight - tileDimensions), tilemapWidth, tileDimensions * (int)scale.X); // bottom

            return rectangles;
        }

        public (Rectangle[] rectangleList, string[] doorDirections) getDoorCollisionRect()
        {
            Rectangle[] rectangles = new Rectangle[doorPairs.Length];
            string[] doorDirections = new string[doorPairs.Length];
            ((int, int), (int, int))[] doorPairsCoordinates = new ((int, int), (int, int))[doorPairs.Length];
            for (int currentRow = 0; currentRow < templateTilemap.GetLength(0); currentRow++)
            {
                for (int currentColumn = 0; currentColumn < templateTilemap.GetLength(1); currentColumn++)
                {
                    string tileType = templateTilemap[currentRow, currentColumn];
                    for (int doorPairIndex = 0; doorPairIndex < doorPairs.Length; doorPairIndex++)
                    {
                        if (tileType == doorPairs[doorPairIndex].Item1)
                        {
                            doorPairsCoordinates[doorPairIndex].Item1 = (currentRow, currentColumn);
                            doorDirections[doorPairIndex] = tileType.Substring(0, 1);
                            
                        } else if (tileType == doorPairs[doorPairIndex].Item2)
                        {
                            doorPairsCoordinates[doorPairIndex].Item2 = (currentRow, currentColumn);
                        }
                    }
                }
            }

            for (int currentPairIndex = 0; currentPairIndex < doorPairs.Length; currentPairIndex++)
            {
                int xPosPixels;
                int yPosPixels;
                string posRelative = doorPairs[currentPairIndex].Item1.Substring(doorPairs[currentPairIndex].Item1.Length - 2);
                if (posRelative == "L" || posRelative == "T")
                {
                    xPosPixels = doorPairsCoordinates[currentPairIndex].Item1.Item2 * tileDimensions * (int)scale.X; 
                    yPosPixels = doorPairsCoordinates[currentPairIndex].Item1.Item1 * tileDimensions * (int)scale.Y;
                } else
                {
                    xPosPixels = doorPairsCoordinates[currentPairIndex].Item1.Item2 * tileDimensions * (int)scale.X;
                    yPosPixels = doorPairsCoordinates[currentPairIndex].Item1.Item1 * tileDimensions * (int)scale.Y; 
                }

                rectangles[currentPairIndex] = new Rectangle(xPosPixels, yPosPixels, tileDimensions * 2 * (int)scale.X, tileDimensions * (int)scale.Y);
            }

            return (rectangles, doorDirections);
        }
    }
}
