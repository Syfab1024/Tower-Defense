/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schulz
 * Datum: 04.10.2011
 * Zeit: 13:47
 */
using System;
using System.Collections.Generic;

namespace TowDef
{
   /// <summary>
   /// Description of MathHelper.
   /// </summary>
   public static class MathHelper
   {
      private static SortedDictionary<int, double> m_Sqrt = new SortedDictionary<int, double>();
      
      public static double Sqrt(int Value)
      {
         if (!m_Sqrt.ContainsKey(Value))
             m_Sqrt.Add(Value, Math.Sqrt(Value));

         return m_Sqrt[Value];
      }
   }
}
