using System;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Windows.Forms;
using Final_Project.Controllers;
using Final_Project.Entites;
using Final_Project.Models;
using System.Drawing.Drawing2D;
using System.Reflection.Emit;

namespace Final_Project
{
    public partial class Game : Form
    {
        public static int score = 0;

        private Image frogSheet;
        private Image flagSheet;
        private Image endSheet;
        private Image enemySheet;
        private Image appleSheet;
        private Image dudeSheet;
        private Image ESheet;
        private Image mapSheet;
        private Image chestSheet;

        private Entity player;
        private Entity flag;
        private Entity end;
        private Entity enemy;
        private Entity enemy2;
        private Entity dude;
        private Entity E;
        private Entity map;
        private Entity chest;

        private List<Entity> apples = new List<Entity>();
        List<Entity> applesToRemove = new List<Entity>();

        private int direction;
        private int direction2;
        private bool check = false;
        private bool fight = false;
        private int checkFight = 0;
        private bool checkNear = false;
        private bool checkE = false;
        private bool checkChest = false;
        private bool isChestOpen = false;

        public Game()
        {
            InitializeComponent();

            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);
            Closing += ExecuteOnClosing;

            Init();
        }

        void ExecuteOnClosing(object sender, CancelEventArgs e)
        {
            Application.Exit();
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = 0;
                    break;
                case Keys.S:
                    player.dirY = 0;
                    break;
                case Keys.A:
                    player.dirX = 0;
                    break;
                case Keys.D:
                    player.dirX = 0;
                    break;
            }

            if (player.dirX == 0 && player.dirY == 0)
            {
                player.SetAnimationConfiguration(0);
                string baseDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString();
                string imageName = (player.GetFlip() == 1) ? "Idle.png" : "IdleLeft.png";
                string imagePath = Path.Combine(baseDirectory, "D:\\study\\FinalProject\\Final-Project\\Final-Project\\Sprites\\Frog", imageName);

                if (File.Exists(imagePath))
                {
                    player.spriteSheet = new Bitmap(imagePath);
                }
            }

            if ((520 <= player.posX && player.posX <= 604 && 510 <= player.posY && player.posY <= 594) || (score > 200))
            {
                timer1.Stop();
                Hide();
                Win menu = new Win();
                menu.ShowDialog();
            }
        }

        private void OnPress(object sender, KeyEventArgs e)
        {
            int animationConfig = 1;
            string baseSpritePath = "D:\\study\\FinalProject\\Final-Project\\Final-Project\\Sprites\\Frog\\";

            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -2;
                    break;
                case Keys.S:
                    player.dirY = 2;
                    break;
                case Keys.A:
                    player.dirX = -2;
                    player.SetFlip(-1);
                    break;
                case Keys.D:
                    player.dirX = 2;
                    player.SetFlip(1);
                    break;
                case Keys.Space:
                    player.dirX = 0;
                    player.dirY = 0;
                    player.SetIsMoving(false);
                    animationConfig = 2;
                    break;
                case Keys.E:
                    if (checkNear || checkChest)
                    {
                        checkE = !checkE;
                    }
                    break;
            }

            player.SetAnimationConfiguration(animationConfig);
            string spritePath = Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), baseSpritePath);
            string spriteFileName = (player.GetFlip() == 1) ? "Run.png" : "RunLeft.png";



            if (e.KeyCode == Keys.Space)
            {
                spriteFileName = "DoubleJump.png";
                if (check && player.posX <= enemy.posX + 15 && player.posX >= enemy.posX - 15 && player.posY <= enemy.posY + 15 && player.posY >= enemy.posY - 15)
                {
                    score = 100;
                    //check = false;
                    fight = true;
                    // checkFight++;
                }
            }
            player.spriteSheet = new Bitmap(Path.Combine(spritePath, spriteFileName));
            player.SetIsMoving(true);
        }
        private void Update(object sender, EventArgs e)
        {
            if (!PhysicsController.IsCollide(player, new Point(player.dirX, player.dirY)) && player.GetIsMoving())
            {
                player.Move();
            }

            if (enemy.posX >= 280)
            {
                direction = -1;
                enemy.spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "D:\\study\\FinalProject\\Final-Project\\Final-Project\\Sprites\\Enemy\\RunLeft.png"));
            }
            else if (enemy.posX <= 120)
            {
                direction = 1;
                enemy.spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "D:\\study\\FinalProject\\Final-Project\\Final-Project\\Sprites\\Enemy\\Run.png"));
            }

            enemy.posX += 2 * direction;

            if (player.posX <= enemy.posX + 15 && player.posX >= enemy.posX - 15 && player.posY <= enemy.posY + 15 && player.posY >= enemy.posY - 15)
            {
                fight = false;
                check = true;
                // checkFight++;
                //score = 0;
            }

            if (enemy2.posX >= 280)
            {
                direction2 = -1;
                enemy2.spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "D:\\study\\FinalProject\\Final-Project\\Final-Project\\Sprites\\Enemy\\RunLeft.png"));
            }
            else if (enemy2.posX <= 23)
            {
                direction2 = 1;
                enemy2.spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "D:\\study\\FinalProject\\Final-Project\\Final-Project\\Sprites\\Enemy\\Run.png"));
            }

            enemy2.posX += 2 * direction2;

            if (player.posX <= enemy2.posX + 15 && player.posX >= enemy2.posX - 15 && player.posY <= enemy2.posY + 15 && player.posY >= enemy2.posY - 15)
            {
                check = true;
                score = 0;
            }

            if (player.posX <= dude.posX + 25 && player.posX >= dude.posX - 25 && player.posY <= dude.posY + 25 && player.posY >= dude.posY - 25)
            {
                checkNear = true;
            }
            else
            {
                checkNear = false;
            }
            if (player.posX <= chest.posX + 25 && player.posX >= chest.posX - 25 && player.posY <= chest.posY + 25 && player.posY >= chest.posY - 25)
            {
                checkChest = true;
            }
            else
            {
                checkChest = false;
            }

            foreach (Entity apple in apples)
            {
                if (apple != null && player.posX <= apple.posX + 15 && player.posX >= apple.posX - 15
                    && player.posY <= apple.posY + 15 && player.posY >= apple.posY - 15)
                {
                    score += 10;
                    applesToRemove.Add(apple);
                }
            }

            foreach (Entity appleToRemove in applesToRemove)
            {
                apples.Remove(appleToRemove);
            }

            UpdateScoreLabel();

            Invalidate();
        }

        private void UpdateScoreLabel()
        {
            label1.Text = "Scores: " + score.ToString();
        }

        private void Init()
        {
            MapController.Init();

            this.Width = MapController.GetWidth();
            this.Height = MapController.GetHeight();

            string baseSpritePath = Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                "D:\\study\\FinalProject\\Final-Project\\Final-Project\\Sprites");

            frogSheet = new Bitmap(Path.Combine(baseSpritePath, "Frog\\Idle.png"));
            flagSheet = new Bitmap(Path.Combine(baseSpritePath, "add\\Start (Moving) (64x64).png"));
            endSheet = new Bitmap(Path.Combine(baseSpritePath, "add\\End.png"));
            enemySheet = new Bitmap(Path.Combine(baseSpritePath, "Enemy\\Run.png"));
            appleSheet = new Bitmap(Path.Combine(baseSpritePath, "Fruits\\Apple.png"));
            dudeSheet = new Bitmap(Path.Combine(baseSpritePath, "Dude\\Dude_Idle.png"));
            ESheet = new Bitmap(Path.Combine(baseSpritePath, "Keys\\E-Key.png"));
            mapSheet = new Bitmap(Path.Combine(baseSpritePath, "Map\\map.png"));
            chestSheet = new Bitmap(Path.Combine(baseSpritePath, "add\\Chests.png"));

            player = new Entity(15, 15, Hero.GetIdleFrames(), Hero.GetRunFrames(), Hero.GetJumpFrames(), frogSheet);
            flag = new Entity(15, -10, 18, 18, 18, flagSheet)
            {
                size = 58
            };
            end = new Entity(530, 520, 0, 0, 0, endSheet)
            {
                size = 64
            };
            enemy = new Entity(120, 305, 12, 12, 12, enemySheet);
            enemy2 = new Entity(23, 490, 12, 12, 12, enemySheet);
            apples.AddRange(new[]
            {
                new Entity(150, 95, 17, 17, 17, appleSheet),
                new Entity(310, 95, 17, 17, 17, appleSheet),
                new Entity(495, 180, 17, 17, 17, appleSheet),
                new Entity(495, 320, 17, 17, 17, appleSheet),
                new Entity(560, 145, 17, 17, 17, appleSheet),
                new Entity(560, 340, 17, 17, 17, appleSheet),
                new Entity(63, 65, 17, 17, 17, appleSheet),
                new Entity(365, 30, 17, 17, 17, appleSheet),
                new Entity(63, 150, 17, 17, 17, appleSheet),
                new Entity(63, 230, 17, 17, 17, appleSheet),
                new Entity(220, 280, 17, 17, 17, appleSheet),
                new Entity(340, 370, 17, 17, 17, appleSheet),
                new Entity(280, 500, 17, 17, 17, appleSheet)
            });

            dude = new Entity(125, 150, 11, 11, 11, dudeSheet);
            E = new Entity(30, 560, 2, 2, 2, ESheet);
            map = new Entity(45, 35, 1, 1, 1, mapSheet)
            {
                size = 512
            };
            chest = new Entity(555, 415, 1, 1, 1, chestSheet)
            {
                size = 40
            };

            timer1.Start();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            MapController.DrawMap(g);
            flag.PlayAnimation(g);
            end.PlayAnimation(g);
            enemy.PlayAnimation(g);
            enemy2.PlayAnimation(g);
            dude.PlayAnimation(g);
            chest.PlayAnimation(g);

            if (checkE && checkChest)
            {
                chest.spriteSheet = new Bitmap(Path.Combine("D:\\study\\FinalProject\\Final-Project\\Final-Project\\Sprites\\add\\Chests-open.png"));
                if (!isChestOpen)
                {
                    apples.AddRange(new[]
                    {
                        new Entity(chest.posX, chest.posY, 17, 17, 17, appleSheet),
                        new Entity(chest.posX - 5, chest.posY, 17, 17, 17, appleSheet),
                        new Entity(chest.posX, chest.posY - 5, 17, 17, 17, appleSheet),
                        new Entity(chest.posX - 5, chest.posY - 5, 17, 17, 17, appleSheet),
                        new Entity(chest.posX + 5, chest.posY + 5, 17, 17, 17, appleSheet),
                        new Entity(chest.posX - 5, chest.posY, 17, 17, 17, appleSheet),
                        new Entity(chest.posX, chest.posY - 5, 17, 17, 17, appleSheet),
                        new Entity(chest.posX - 5, chest.posY - 5, 17, 17, 17, appleSheet),
                    });

                    isChestOpen = true;
                }
            }

            foreach (Entity apple in apples)
            {
                if (apple != null)
                {
                    apple.PlayAnimation(g);
                }
            }

            Rectangle lightBounds = new Rectangle(player.posX - 90, player.posY - 90, 200, 200);

            using (GraphicsPath path = new GraphicsPath())
            {
                player.PlayAnimation(g);
                path.AddEllipse(lightBounds);
                if (!Welcome.GetSimpleCheck())
                {
                    using (SolidBrush darknessBrush = new SolidBrush(Color.Black))
                    {
                        Region darknessRegion = new Region(new Rectangle(0, 0, this.Width, this.Height));
                        darknessRegion.Exclude(path);
                        g.FillRegion(darknessBrush, darknessRegion);
                    }
                }

                if (checkE && checkNear)
                {
                    map.PlayAnimation(g);
                }

                if (checkNear || checkChest)
                {
                    E.PlayAnimation(g);
                }

                if (check && !fight)
                {
                    Hide();
                    Lose lose = new Lose();
                    lose.ShowDialog();
                }
            }
        }

    }
}

//    private void OnPaint(object sender, PaintEventArgs e)
//    {
//        Graphics g = e.Graphics;
//        MapController.DrawMap(g);
//        flag.PlayAnimation(g);
//        end.PlayAnimation(g);
//        player.PlayAnimation(g);
//        enemy.PlayAnimation(g);
//        dude.PlayAnimation(g);
//        chest.PlayAnimation(g);
//        if (checkE && checkNear)
//        {
//            map.PlayAnimation(g);
//        }
//        if (checkE && checkChest)
//        {
//            chest.spriteSheet = new Bitmap(Path.Combine("D:\\study\\FinalProject\\Final-Project\\Final-Project\\Sprites\\add\\Chests-open.png"));
//            if (!isChestOpen)
//            {
//                apples.AddRange(new[]
//                {
//                    new Entity(chest.posX, chest.posY, 17, 17, 17, appleSheet),
//                    new Entity(chest.posX - 5, chest.posY, 17, 17, 17, appleSheet),
//                    new Entity(chest.posX, chest.posY - 5, 17, 17, 17, appleSheet),
//                    new Entity(chest.posX - 5, chest.posY - 5, 17, 17, 17, appleSheet),
//                    new Entity(chest.posX + 5, chest.posY + 5, 17, 17, 17, appleSheet),
//                    new Entity(chest.posX - 5, chest.posY, 17, 17, 17, appleSheet),
//                    new Entity(chest.posX, chest.posY - 5, 17, 17, 17, appleSheet),
//                    new Entity(chest.posX - 5, chest.posY - 5, 17, 17, 17, appleSheet),
//                });

//            isChestOpen = true; 
//            }
//        }

//        if (check)
//        {
//            Hide();
//            Lose lose = new Lose();
//            lose.ShowDialog();
//        }
//        if (checkNear || checkChest)
//        {
//            E.PlayAnimation(g);
//        }
//        foreach (Entity apple in apples)
//        {
//            if (apple != null)
//            {
//                apple.PlayAnimation(g);
//            }
//        }
//    }
//}
//}