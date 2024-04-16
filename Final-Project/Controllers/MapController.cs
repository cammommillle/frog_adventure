using Final_Project.Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    public static class MapController
    {
        public static List<MapEntity> mapObjects;

        private const int mapHeight = 20;
        private const int mapWidth = 20;

        private static int cellSize = 31;

        private static int[,] map = new int[mapHeight, mapWidth];
        private static Image spriteSheet;

        public static int GetMapHeight()
        {
            return mapHeight;
        }
        public static int GetMapWidth()
        {
            return mapWidth;
        }

        public static int GetCellSize()
        {
            return cellSize;
        }
        public static void Init()
        {
            map = GetMap();
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "D:\\study\\FinalProject\\Final-Project\\Final-Project\\Sprites\\Map\\Forest.png"));
            mapObjects = new List<MapEntity>();
        }


        public static int[,] GetMap()
        {
            return new int[,]{
                { 1,6,6,6,6,6,6,6,6,6,6,6,6,15,15,15,15,15,15,2},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,13,13,13,13,13,13,7},
                { 14,13,0,13,13,13,13,13,0,13,13,13,13,13,0,0,0,0,13,7},
                { 14,13,13,13,0,0,11,13,0,13,0,0,0,13,0,13,0,13,13,16},
                { 5,0,11,13,0,13,13,13,0,13,13,13,0,13,0,13,0,13,11,7},
                { 5,11,0,13,0,0,0,0,0,13,0,0,0,0,0,13,0,13,0,7},
                { 5,0,13,13,13,13,0,13,13,13,0,13,13,0,13,13,0,13,0,7},
                { 5,0,11,13,0,0,0,0,0,0,0,0,0,0,0,13,13,13,0,7},
                { 5,13,0,13,0,13,13,13,13,13,13,13,13,13,13,0,0,11,0,7},
                { 5,12,0,13,0,13,0,0,13,0,0,0,13,0,0,0,13,13,0,7},
                { 5,13,0,13,0,0,0,0,0,0,13,0,0,0,13,13,0,13,0,7},
                { 5,13,0,13,13,13,13,13,13,13,13,13,13,0,0,13,0,13,0,7},
                { 5,11,0,0,0,13,0,0,0,0,0,0,13,0,11,13,0,13,13,16},
                { 5,13,0,13,0,13,0,13,0,13,13,13,13,0,0,13,0,0,11,7},
                { 5,13,0,13,0,0,0,13,0,0,0,0,0,0,12,13,0,0,0,7},
                { 5,13,0,13,13,13,13,13,13,13,13,13,13,13,13,13,0,11,13,7},
                { 5,0,0,0,0,0,0,0,0,0,13,12,0,0,0,0,0,0,12,7},
                { 5,12,11,0,0,13,11,0,0,13,13,0,0,11,0,13,11,0,0,7},
                { 5,11,12,13,13,13,0,12,0,11,0,0,12,0,13,13,13,0,0,7},
                { 3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,4},
            };
        }

        public static void SeedMap(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == 10)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize * 3, cellSize * 3)), 202, 298, 107, 114, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(cellSize * 3, cellSize * 3));
                        mapObjects.Add(mapEntity);
                    }
                    if (map[i, j] == 11)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(20, 12)), 581, 114, 19, 11, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(20, 12));
                        mapObjects.Add(mapEntity);
                    }
                    if (map[i, j] == 12)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(20, 18)), 453, 225, 18, 22, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(20, 18));
                        mapObjects.Add(mapEntity);
                    }
                    if (map[i, j] == 13)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 330, 297, 43, 51, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize));
                        mapObjects.Add(mapEntity);
                    }
                    if (map[i, j] == 14)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 20, 20, 20, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize));
                        mapObjects.Add(mapEntity);
                    }
                    if (map[i, j] == 15)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 120, 0, 20, 20, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize));
                        mapObjects.Add(mapEntity);
                    }
                    if (map[i, j] == 16)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 30, 20, 20, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize));
                        mapObjects.Add(mapEntity);
                    }
                }
            }
        }

        public static void DrawMap(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {

                    if (map[i, j] == 1)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 0, 20, 20, GraphicsUnit.Pixel);

                    }
                    else
                    if (map[i, j] == 2)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 3)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 4)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 5)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 20, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 6)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 120, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 7)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 30, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 8)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 120, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                }
            }

            MapController.SeedMap(g);
        }
        public static int GetWidth()
        {
            return cellSize * mapWidth + 16;
        }
        public static int GetHeight()
        {
            return cellSize * (mapHeight + 1) + 8;
        }
    }
}
