/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schulz
 * Datum: 23.09.2011
 * Zeit: 14:32
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;

using Helper;

namespace TowDef
{
   /// <summary>
   /// Description of Path.
   /// </summary>
   public class Path
   {
      // Path
      private List<Point> m_List = new List<Point>();         
      public List<Point> List {
         get { return m_List; }
         set { m_List = value; }
      }
      
      private List<Rectangle> m_RectangleList = new List<Rectangle>();         
      public List<Rectangle> RectangleList {
         get { return m_RectangleList; }
      }
      private int m_Width = 40;         
      public int Width {
         get { return m_Width; }
      }
      
      private Point[] m_EnemyPath;         
      public Point[] EnemyPath {
         get { return m_EnemyPath; }
      }
      
      public int Length {
         get 
         { 
            if (m_EnemyPath == null)
                return 0;

            return m_EnemyPath.Length; 
         }
      }
      
      public Path(List<Point> path)
      {
         CreatePath(path);
      }

      public void CreatePath(List<Point> path)
      {
         if (path == null)
         {
            m_List.Clear();
           
            m_List.Add(new Point(80, 0));
            m_List.Add(new Point(80, 80));
            m_List.Add(new Point(120, 80));
            m_List.Add(new Point(120, 160));
            m_List.Add(new Point(200, 160));
            m_List.Add(new Point(200, 80));
            m_List.Add(new Point(280, 80));
            m_List.Add(new Point(280, 240));
            m_List.Add(new Point(800 - 80, 240));
            m_List.Add(new Point(800 - 80, 540));              
         }
         else
         {
            m_List = path;
         }
         
         CreatePathRectangles();
         CreateEnemyPath();
      }
      

      /// <summary>
      /// Erzeugt für jeden Pfadabschnitt ein Rechteck
      /// </summary>
      public void CreatePathRectangles()
      {
         Point lastPoint = new Point();
         m_RectangleList.Clear();
         
         foreach(Point currPoint in m_List)
         {
            if (!lastPoint.IsEmpty)
            {
               Rectangle r = new Rectangle();
               
               if (lastPoint.X < currPoint.X)
                  r.X = lastPoint.X - m_Width / 2;
               else
                  r.X = currPoint.X - m_Width / 2;
               
               if (lastPoint.Y < currPoint.Y)
                  r.Y = lastPoint.Y - m_Width / 2;
               else
                  r.Y = currPoint.Y - m_Width / 2;
               
               if (lastPoint.X == currPoint.X)
               {                  
                  // Pfad von oben nach unten
                  r.Width = m_Width;
                  r.Height = Math.Abs(currPoint.Y - lastPoint.Y) + m_Width;
               }
               else if (lastPoint.Y == currPoint.Y)
               {  
                  // Pfad von links nach rechts
                  r.Width = Math.Abs(currPoint.X - lastPoint.X) + m_Width;
                  r.Height = m_Width;
               }
               else
               {
                  MsgBox.ShowCmnError("Nicht unterstützte Pfadreihenfolge.");
               }
               
               m_RectangleList.Add(r);
            }
            
            lastPoint = currPoint;
         }         
      }
      
      public void Paint(Graphics g)
      {
         if (m_List == null)
            return;
         
         foreach(Rectangle r in m_RectangleList)
         {
            g.DrawRectangle(Pens.Black, r);
            g.FillRectangle(Brushes.Peru, r);
         }
         
         // Start- und Endpunkt einzeichnen:
         Point start = m_List[0];
         g.FillRectangle(Brushes.GreenYellow, 
                         start.X - m_Width / 4,
                         start.Y - m_Width / 4,
                         m_Width / 2, m_Width / 2);
         g.DrawRectangle(Pens.Black, 
                         start.X - m_Width / 4,
                         start.Y - m_Width / 4,
                         m_Width / 2, m_Width / 2);         
         
         Point end = m_List[m_List.Count - 1];
         g.FillRectangle(Brushes.DarkRed, 
                         end.X - m_Width / 4,
                         end.Y - m_Width / 4,
                         m_Width / 2, m_Width / 2);        
         g.DrawRectangle(Pens.Black, 
                         end.X - m_Width / 4,
                         end.Y - m_Width / 4,
                         m_Width / 2, m_Width / 2);           
      }
      
      /// <summary>
      /// Erzeugt anhand des Path's ein Array aus Koordinaten, 
      /// welches die Enemies ablaufen müssen
      /// </summary>
      private void CreateEnemyPath()
      {         
         if (m_List == null || m_List.Count == 0)
         {
            m_EnemyPath = null;
            return;
         }
            
         
         int currentPosition = 0;
         List<Point> pathList = new List<Point>();
         Point currPoint = m_List[currentPosition];
         
         //solange Ziel noch nicht erreicht
         while (currentPosition < m_List.Count)
         {
            // ermittle nächstes Ziel
            Point dest = m_List[currentPosition];
            
            int xSign = 1;
            int ySign = 1;
            
            //solange nächstes Ziel noch nicht erreicht
            while (xSign != 0 || ySign != 0)
            {
               // festlegen, in welcher Richtung es weitergeht
               int x = dest.X - currPoint.X;
               int y = dest.Y - currPoint.Y;
               
               xSign = Math.Sign(x);
               ySign = Math.Sign(y);
               currPoint.X = currPoint.X + xSign;
               currPoint.Y = currPoint.Y + ySign;
               
               if (xSign != 0 || ySign != 0)
                  pathList.Add(currPoint);
            }
            
            // ZwischenZiel erreicht --> nächstes Ziel
            currPoint = dest;
            currentPosition++;
         }
         m_EnemyPath = pathList.ToArray();
      }        
   }
}
