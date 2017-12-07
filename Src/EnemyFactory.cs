/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schulz
 * Datum: 26.09.2011
 * Zeit: 16:26
 * 
 */
using System;
using System.Drawing;

namespace TowDef
{
   /// <summary>
   /// Description of EnemyFactory.
   /// </summary>
   public static class EnemyFactory
   {      
      public static Enemy GetNewEnemy(string Type, int Stage)
      {
         Enemy e = new Enemy();
         
         if (Type == "1")
         {
            e.Type = Type;
            e.Size = 15;
            e.SpeedPerFrame = 2;
            e.MaxLifePoints = 50 * Stage;
            e.Money = 10;
            e.Damage = 1;
            e.Brush = Brushes.Black;
            e.BrushLifePoint= Brushes.DarkRed; 

            return e;
         }
         
         return null;
      }
   }
}