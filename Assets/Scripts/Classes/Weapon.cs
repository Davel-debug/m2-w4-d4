using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
using Structs;
using System;

namespace Classes
{
    [Serializable]
    public class Weapon
    {
        [SerializeField]
        private string name;
        [SerializeField]
        private DAMAGE_TYPE dmgType;
        [SerializeField]
        private ELEMENT elem;
        [SerializeField]
        private Stats bonusStats;

        public Weapon(string name, DAMAGE_TYPE dmgType, ELEMENT elem, Stats bonusStats)
        {
            this.name = name;
            this.dmgType = dmgType;
            this.elem = elem;
            this.bonusStats = bonusStats;
        }

        public string GetName() {  return name; }
        public DAMAGE_TYPE GetDmgType() { return dmgType; }
        public ELEMENT GetElem() { return elem; }
        public Stats GetBonusStats() { return bonusStats; }
        public void SetName(string name) { this.name = name; }
        public void SetDmgType(DAMAGE_TYPE dmgType) { this.dmgType = dmgType; }
        public void SetElem(ELEMENT elem) { this.elem = elem; }
        public void SetBonusStats(Stats bonusStats) {  this.bonusStats = bonusStats; }

    }
}