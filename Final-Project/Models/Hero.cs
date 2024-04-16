using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public static class Hero
    {
        private const int idleFrames = 11;
        private const int runFrames = 12;
        private const int jumpFrames = 7;
        public static int GetIdleFrames()
        {
            return idleFrames;
        }
        public static int GetRunFrames()
        {
            return runFrames;
        }
        public static int GetJumpFrames()
        {
            return jumpFrames;
        }
    }

}

