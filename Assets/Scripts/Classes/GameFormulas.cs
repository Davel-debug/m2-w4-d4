using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
using Structs;
using System;
using System.Net.Mail;
using UnityEditor.Experimental.GraphView;

namespace Classes
{
    public static class GameFormulas
    {
        public static bool HasElementAdvantage(ELEMENT attackElement, Hero defender)
        {
            return attackElement == defender.GetWeakness();
        }

        public static bool HasElementDisdvantage(ELEMENT attackElement, Hero defender)
        {
            return attackElement == defender.GetResistence();
        }

        public static float EvaluateElementalModifier(ELEMENT attackElement, Hero defender)
        {
            if (HasElementAdvantage(attackElement, defender)) { return 1.5f; }
            else if (HasElementDisdvantage(attackElement, defender)) { return 0.5f; }
            else { return 1; }
        }

        public static bool HasHit(Stats attacker, Stats defender)
        {
            int hitChance = attacker.aim - defender.eva;
            if (hitChance > UnityEngine.Random.Range(0, 99)) { return true; }
            Debug.Log("MISS");
            return false;
        }

        public static bool IsCrit(int critValue)
        {
            if (critValue > UnityEngine.Random.Range(0, 99)) { return false; }
            Debug.Log("CRIT");
            return true;
        }

        public static int CalculateDamage(Hero attacker, Hero defender)
        {
            int damage; //return

            Stats StatsAttacker = HeroStatsSum(attacker); //stats
            Stats StatsDefender = HeroStatsSum(defender);

            int difesa;
            int attacco =  attacker.GetBaseStats().atk;

            if (attacker.GetWeapon().GetDmgType() == DAMAGE_TYPE.PHYSICAL) // stats type check
            {
                difesa = StatsDefender.def;
            }
            else
            {
                difesa = StatsDefender.res;
            }

            damage = attacco - difesa; //base dmg
            float modificatore = EvaluateElementalModifier(attacker.GetWeapon().GetElem(), defender); //modifier calc
            damage = Mathf.RoundToInt(damage * modificatore);

            if (IsCrit(StatsAttacker.crt)) { damage *= 2; }//check crit then increase dmg

            if (damage < 0) { Debug.Log("ËRROR"); return 0; } else { return damage; }
        }

        public static Stats HeroStatsSum(Hero hero)
        {
            return Stats.Sum(hero.GetBaseStats(), hero.GetWeapon().GetBonusStats());
        }

        public static void DamageManagment(Hero first,  Stats firstW,  Hero second,  Stats secondW)
        {
            if (GameFormulas.HasHit(firstW, secondW)) //hit check
            {
                ELEMENT weaponE = first.GetWeapon().GetElem(); //the element of the attacker's weapon
                
                if (GameFormulas.EvaluateElementalModifier(weaponE, second) == 1.5f)
                {
                    Debug.Log("WEAKNESS");
                }
                else if (GameFormulas.EvaluateElementalModifier(weaponE, second) == 0.5f)
                {
                    Debug.Log("RESIST");
                }

                int damage = CalculateDamage(first, second);
                
                Debug.Log("Vita di " + second.GetName() + " prima del colpo:" + second.GetHp());
                second.TakeDamage(damage); //defender get damaged
                Debug.Log("Vita di " + second.GetName() + " dopo il colpo:" + second.GetHp());
            }
        }

        public static void OrderBySpeed(Hero heroA, Hero heroB, out Hero first, out Stats firstW, out Hero second, out Stats secondW)
        {
            Stats statsA = GameFormulas.HeroStatsSum(heroA);
            Stats statsB = GameFormulas.HeroStatsSum(heroB);

            if (statsA.spd > statsB.spd)
            {
                first = heroA;
                firstW = statsA;
                second = heroB;
                secondW = statsB;
            }
            else
            {
                first = heroB;
                firstW = statsB;
                second = heroA;
                secondW = statsA;
            }
        }

        public static void SwapHero(Hero heroA, Hero heroB, out Hero first, out Stats firstW, out Hero second, out Stats secondW)
        {
            Stats statsA = GameFormulas.HeroStatsSum(heroA);
            Stats statsB = GameFormulas.HeroStatsSum(heroB);

            first = heroB;
            firstW = statsB;
            second = heroA;
            secondW = statsA;
        }


    }
}
