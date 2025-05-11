using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Structs
{
    [Serializable]
    public struct Stats
    {
        public int atk;
        public int def;
        public int res;
        public int spd;
        public int crt;
        public int aim;
        public int eva;

        public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
        {
            this.atk = atk;
            this.def = def;
            this.res = res;
            this.spd = spd;
            this.crt = crt;
            this.aim = aim;
            this.eva = eva;
        }

        public static Stats Sum(Stats stats1, Stats stats2)
        {
            Stats stats = new Stats();
            stats.atk = stats1.atk + stats2.atk;
            stats.def = stats1.def + stats2.def;
            stats.res = stats1.res + stats2.res;
            stats.spd = stats1.spd + stats2.spd;
            stats.crt = stats1.crt + stats2.crt;
            stats.aim = stats1.aim + stats2.aim;
            stats.eva = stats1.eva + stats2.eva;

            return stats;

        }

    }
}
