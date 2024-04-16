using System.Drawing;
using System.Numerics;

namespace Final_Project.Entites
{
    public class Entity
    {
        public int posX;
        public int posY;

        public int dirX;
        public int dirY;

        private bool isMoving;

        public int size;
        private int flip;

        private int idleFrame;
        private int jumpFrame;
        private int runFrame;

        private int currentAnimation;
        private int currentFrame;
        private int currentLimit;

        public Image spriteSheet;

        public Entity(int posX, int posY, int idleFrame, int runFrame, int jumpFrame, Image spriteSheet)
        {
            this.posX = posX;
            this.posY = posY;
            this.idleFrame = idleFrame;
            this.runFrame = runFrame;
            this.jumpFrame = jumpFrame;
            this.spriteSheet = spriteSheet;

            size = 35;
            flip = 1;

            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = idleFrame;
        }

        public bool GetIsMoving()
        {
            return isMoving;
        }

        public void SetIsMoving(bool isMove)
        {
            isMoving = isMove;
        }

        public int GetFlip()
        {
            return flip;
        }

        public void SetFlip(int newFlip)
        {
            flip = newFlip;
        }
        public void Move()
        {
            posX += dirX;
            posY += dirY;
        }

        public void PlayAnimation(Graphics g)
        {
            if (currentFrame < currentLimit - 1)
            {
                currentFrame++;
            }
            else currentFrame = 0;

            g.DrawImage(spriteSheet, new Rectangle(new Point(posX, posY), new Size(size, size)), 32 * currentFrame, 0, size, size, GraphicsUnit.Pixel);
        }

        public void SetAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    currentLimit = idleFrame;
                    break;
                case 1:
                    currentLimit = runFrame;
                    break;
                case 2:
                    currentLimit = jumpFrame;
                    break;
            }
        }
    }
    
}