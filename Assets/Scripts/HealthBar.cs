using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   public Image healthbar;
   float maxhealth = 1000f;

   public static float healthloss;

   public static float health;

   private void Start() {
       health = maxhealth;
   }

   private void Update() {
       healthbar.fillAmount = health / maxhealth ;
       health = health - healthloss;
   }
}
