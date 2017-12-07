/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schulz
 * Datum: 28.09.2011
 * Zeit: 17:08
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using Helper;

namespace TowDef
{
   /// <summary>
   /// Description of LvlEdit.
   /// </summary>
   public partial class FrmLvlEdit : Form
   {
      private List<Point> m_List = new List<Point>();
      public List<Point> Path {
         get { return m_List; }
         set { m_List = value; }
      }
      private Path m_Path = new Path(null);
      
      private Point m_CurrentMouseCursorLocation = new Point();
      
      public FrmLvlEdit(List<Point> pathList)
      {
         InitializeComponent();
         m_Path.List.Clear();
         foreach(Point p in pathList)
         {
            m_List.Add(p);
         }
         UpdatePath();
      }
      
      private void UpdatePath()
      {
         m_Path.CreatePath(m_List);
         pbMain.Invalidate();
         lPathInfo.Text = "Pfadlänge: " + m_Path.Length.ToString();
         btnOk.Enabled = m_Path.Length > 0;
      }
      
      void PbMainMouseClick(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            m_List.Add(m_CurrentMouseCursorLocation);
         }
         if (e.Button == MouseButtons.Right)
         {
            if (m_List.Count > 0)
               m_List.Remove(m_List[m_List.Count - 1]);
         }
         
         UpdatePath();
      }
      
      void PbMainPaint(object sender, PaintEventArgs e)
      {
         if (m_List.Count == 0)
            return;
         
         e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
         
         // Verbindung aller bisherigen Punkte:
         m_Path.Paint(e.Graphics);
         
         // neue Linie:
         if (!m_CurrentMouseCursorLocation.IsEmpty)
            e.Graphics.DrawLine(Pens.Green, m_List[m_List.Count - 1], m_CurrentMouseCursorLocation);         
         
         // Startpunkt:
         if (m_List.Count == 1)
         {
            e.Graphics.FillEllipse(Brushes.Black, m_List[0].X, m_List[0].Y, 2, 2);
            return;
         }
      }
      
      private double GetDistanceBetweenPoints(Point p1, Point p2)
      {
         if (p1.IsEmpty || p2.IsEmpty)
            return 999999;
         
         // Entfernung über Pythagoras:  distance := sqrt(a^2 + b^2)
         int diffX = p1.X - p2.X;
         int diffY = p1.Y - p2.Y;
         
         double distance = MathHelper.Sqrt(diffX * diffX + diffY * diffY);
         
         return distance;
      }          
      
      /// <summary>
      /// Es sind nur gerade Linien mit einer Mindestlänge von 40px erlaubt
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      void PbMainMouseMove(object sender, MouseEventArgs e)
      {
         if (m_List.Count == 0)
         {
            m_CurrentMouseCursorLocation = e.Location;
            return;
         }
            
         // in welche Richtung soll die gerade Linie gezeichnet werden?
         Point lastPoint = m_List[m_List.Count - 1];
         Point sameX = new Point(lastPoint.X, e.Y);
         Point sameY = new Point(e.X, lastPoint.Y);
         double distSameX = GetDistanceBetweenPoints(lastPoint, sameX);
         double distSameY = GetDistanceBetweenPoints(lastPoint, sameY);
         
         if (distSameX > distSameY)
            m_CurrentMouseCursorLocation = sameX;
         else
            m_CurrentMouseCursorLocation = sameY;
         
         
         // mind. ... Pixel Abstand zum vorherigen Punkt:
         int minDistance = m_Path.Width + 20;
         int diffX = m_CurrentMouseCursorLocation.X - lastPoint.X;
         int diffY = m_CurrentMouseCursorLocation.Y - lastPoint.Y;
         if (Math.Abs(diffX) < minDistance && diffX != 0)
            m_CurrentMouseCursorLocation.X += minDistance - diffX;
         if (Math.Abs(diffY) < minDistance && diffY != 0)
            m_CurrentMouseCursorLocation.Y += minDistance - diffY;
            
         // neuzeichnen veranlassen
         pbMain.Invalidate();
      }
      
      void BtnOkClick(object sender, EventArgs e)
      {
      	DialogResult = DialogResult.OK;
      }
      
      void PbMainMouseLeave(object sender, EventArgs e)
      {
         m_CurrentMouseCursorLocation = new Point();
         // neuzeichnen veranlassen
         pbMain.Invalidate();         
      }
      
      void BtnResetClick(object sender, EventArgs e)
      {
         m_List.Clear();
         m_Path.List.Clear();
         UpdatePath();
      }
      
      void BtnSaveClick(object sender, EventArgs e)
      {
         SaveFileDialog sfd = new SaveFileDialog();
         sfd.CheckPathExists = true;
         sfd.AddExtension = true;
         sfd.Filter = "Tower Defense Map (*.map)|*.map";
         sfd.FileName = "TowDefMap_" + DateTime.Now.ToString("yyyy-MM-dd") + ".map";
         
         if(sfd.ShowDialog() == DialogResult.OK)
         {
            Stream stream = File.Open(sfd.FileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, m_List);            
            stream.Close();     
         }
      }
      
      void BtnLoadClick(object sender, EventArgs e)
      {
         FileDialog fd = new OpenFileDialog();
         fd.Filter = "Tower Defense Map (*.map)|*.map";
         fd.DefaultExt = ".map";
         
         if(fd.ShowDialog() == DialogResult.OK)
         {
             Stream stream = File.Open(fd.FileName, FileMode.Open, FileAccess.Read);
             try
             {                
                 BinaryFormatter bf = new BinaryFormatter();                
                 m_List = bf.Deserialize(stream) as List<Point>;  
             }
             catch(Exception ex)
             {
                 MsgBox.ShowCmnError(ex.Message);
             }
             finally
             {
                stream.Close();                 
                UpdatePath();
             }
         }
      }
      
      void BtnRandomizeClick(object sender, EventArgs e)
      {
         m_List.Clear();
         Random r = new Random();
         
         int maxX = pbMain.Width;
         int maxY = pbMain.Height;
         
         Point pStart = new Point(r.Next(50, maxX), r.Next(50, maxY));
         m_List.Add(pStart);
         
         Point p = pStart;
         
         bool holdXCoorinate = true;
         
         for (int i = 0; i < 8 ; i++)
         {  
            // nach oben/unten / links/rechts?
            int factorX = 1;
            if (p.X > maxX / 2)
               factorX = -1;
            int factorY = 1;
            if (p.Y > maxY / 2)
               factorY = -1;            
            
            if (holdXCoorinate)
               p = new Point(p.X, p.Y + factorY * r.Next(50, maxY / 2));
            else
               p = new Point(p.X + factorX * r.Next(50, maxX / 2), p.Y);
            
            m_List.Add(p);
                
            holdXCoorinate = !holdXCoorinate;
         }
         
         UpdatePath();
      }
   }
}
