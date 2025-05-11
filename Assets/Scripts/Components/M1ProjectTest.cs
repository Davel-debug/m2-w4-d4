using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using Enums;
using Structs;

namespace Components
{
    public class M1ProjectTest : MonoBehaviour
    {
        [SerializeField]
        Hero HeroA;
        [SerializeField]
        Hero HeroB;

        Hero first, second;
        Stats firstW, secondW;

        void Start()
        {
            GameFormulas.OrderBySpeed(HeroA, HeroB, out first, out firstW, out second, out secondW); //speed check to choose the first attacker
        }

        void Update()
        {
            if (!HeroA.IsAlive() || !HeroB.IsAlive()) { return; } //check winner

            Debug.Log("Attaccante: " + first.GetName() + " Difensore: " + second.GetName()); //Print turn

            GameFormulas.DamageManagment(first, firstW, second, secondW);

            Debug.Log("Vita di " + first.GetName() + ":" + first.GetHp());
            Debug.Log("Vita di " + second.GetName() + ":" + second.GetHp());

            if (!second.IsAlive())
            {
                Debug.Log("The Winner is: " + first.GetName());
                return;
            }

            GameFormulas.SwapHero(first, second, out first, out firstW, out second, out secondW); //Swap hero

        }
    }
}

