using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
using Structs;
using System;

namespace Classes
{
    [Serializable]
    public class Hero
    {
        [SerializeField]
        private string name;
        [SerializeField]
        private int hp;
        [SerializeField]
        private Stats baseStats;
        [SerializeField]
        private ELEMENT resistence;
        [SerializeField]
        private ELEMENT weakness;
        [SerializeField]
        private Weapon weapon;

        public Hero(string name, int hp, Stats baseStats, ELEMENT resistence, ELEMENT weakness, Weapon weapon)
        {
            this.name = name;
            this.hp = hp;
            this.baseStats = baseStats;
            this.resistence = resistence;
            this.weakness = weakness;
            this.weapon = weapon;
        }
      
        public string GetName() { return name; }       
        public int GetHp() { return hp; }       
        public Stats GetBaseStats() { return baseStats; }        
        public ELEMENT GetResistence() { return resistence; }        
        public ELEMENT GetWeakness() { return weakness; }       
        public Weapon GetWeapon() { return weapon; }
        public void SetName(string name) { this.name = name; }
        public void SetHp(int hp) { this.hp = hp; }
        public void SetBaseStats(Stats baseStats) { this.baseStats = baseStats; }
        public void SetResistence(ELEMENT resistance) { this.resistence = resistance;}
        public void SetWeakness(ELEMENT weakness) { this.weakness = weakness;}
        public void SetWeapon(Weapon weapon) { this.weapon = weapon; }

        public void AddHp(int amount) { SetHp(GetHp()+amount); }
        public void TakeDamage(int damage) { AddHp(-damage); }
        public bool IsAlive() { return hp > 0; }

    }
}

