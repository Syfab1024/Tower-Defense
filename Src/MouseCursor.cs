/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schulz
 * Datum: 26.09.2011
 * Zeit: 14:54
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;

namespace TowDef
{
   /// <summary>
   /// Description of MouseCursor.
   /// </summary>
   public class MouseCursor
   {
      private Point m_Position = new Point();
      public Point Position {
         get { return m_Position; }
         set { m_Position = value; }
      }
      
      private MouseCursorStates m_State = MouseCursorStates.Normal;         
      public MouseCursorStates State {
         get { return m_State; }
         set 
         { 
            m_State = value; 
         }
      }
      
      private int m_NormalSize = 2;
      private Tower m_TowerToBuild;         
      public Tower TowerToBuild {
         get { return m_TowerToBuild; }
         set { m_TowerToBuild = value; }
      }
      
      public MouseCursor()
      {         
      }
      
      public void Paint(Graphics g)
      {
         if (m_Position.IsEmpty)
            return;
         
         if (m_State == MouseCursorStates.Normal)
         {
            g.FillEllipse(Brushes.Black,
                          m_Position.X - m_NormalSize,
                          m_Position.Y - m_NormalSize ,
                          m_NormalSize * 2, m_NormalSize * 2);            
            return;
         }
         
         
         // Tower-Range:
         g.FillEllipse(new SolidBrush(Color.FromArgb(30, 0, 0, 0)),
                       m_Position.X - m_TowerToBuild.Range,
                       m_Position.Y - m_TowerToBuild.Range,
                       m_TowerToBuild.Range * 2, m_TowerToBuild.Range * 2);
         
         // Anzeigen, ob Tower baubar ist (Green) oder nicht (Red)
         Brush brush = Brushes.Black;
         if (m_State == MouseCursorStates.TowerBuildYes)
            brush = Brushes.Green;
         if (m_State == MouseCursorStates.TowerBuildNo)
            brush = Brushes.Red;
         
         g.FillRectangle(brush, 
                       m_Position.X - m_TowerToBuild.Size / 2,
                       m_Position.Y - m_TowerToBuild.Size / 2, 
                       m_TowerToBuild.Size, m_TowerToBuild.Size);         
      }
      
      public void Hide()
      {
         m_Position = new Point();
      }
   }
}
