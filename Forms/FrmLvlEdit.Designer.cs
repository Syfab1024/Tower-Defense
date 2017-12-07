/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schulz
 * Datum: 28.09.2011
 * Zeit: 17:08
 * 
 */
namespace TowDef
{
   partial class FrmLvlEdit
   {
      /// <summary>
      /// Designer variable used to keep track of non-visual components.
      /// </summary>
      private System.ComponentModel.IContainer components = null;
      
      /// <summary>
      /// Disposes resources used by the form.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing) {
            if (components != null) {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }
      
      /// <summary>
      /// This method is required for Windows Forms designer support.
      /// Do not change the method contents inside the source code editor. The Forms designer might
      /// not be able to load this method if it was changed manually.
      /// </summary>
      private void InitializeComponent()
      {
      	this.pbMain = new System.Windows.Forms.PictureBox();
      	this.btnOk = new System.Windows.Forms.Button();
      	this.btnReset = new System.Windows.Forms.Button();
      	this.btnSave = new System.Windows.Forms.Button();
      	this.btnLoad = new System.Windows.Forms.Button();
      	this.lPathInfo = new System.Windows.Forms.Label();
      	this.btnRandomize = new System.Windows.Forms.Button();
      	((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
      	this.SuspendLayout();
      	// 
      	// pbMain
      	// 
      	this.pbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      	this.pbMain.Location = new System.Drawing.Point(12, 12);
      	this.pbMain.Name = "pbMain";
      	this.pbMain.Size = new System.Drawing.Size(800, 540);
      	this.pbMain.TabIndex = 1;
      	this.pbMain.TabStop = false;
      	this.pbMain.MouseLeave += new System.EventHandler(this.PbMainMouseLeave);
      	this.pbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbMainMouseMove);
      	this.pbMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbMainMouseClick);
      	this.pbMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PbMainPaint);
      	// 
      	// btnOk
      	// 
      	this.btnOk.Location = new System.Drawing.Point(720, 561);
      	this.btnOk.Name = "btnOk";
      	this.btnOk.Size = new System.Drawing.Size(87, 23);
      	this.btnOk.TabIndex = 2;
      	this.btnOk.Text = "Übernehmen";
      	this.btnOk.UseVisualStyleBackColor = true;
      	this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
      	// 
      	// btnReset
      	// 
      	this.btnReset.Location = new System.Drawing.Point(627, 561);
      	this.btnReset.Name = "btnReset";
      	this.btnReset.Size = new System.Drawing.Size(87, 23);
      	this.btnReset.TabIndex = 3;
      	this.btnReset.Text = "Alles löschen";
      	this.btnReset.UseVisualStyleBackColor = true;
      	this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
      	// 
      	// btnSave
      	// 
      	this.btnSave.Location = new System.Drawing.Point(534, 561);
      	this.btnSave.Name = "btnSave";
      	this.btnSave.Size = new System.Drawing.Size(87, 23);
      	this.btnSave.TabIndex = 4;
      	this.btnSave.Text = "Speichern...";
      	this.btnSave.UseVisualStyleBackColor = true;
      	this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
      	// 
      	// btnLoad
      	// 
      	this.btnLoad.Location = new System.Drawing.Point(441, 561);
      	this.btnLoad.Name = "btnLoad";
      	this.btnLoad.Size = new System.Drawing.Size(87, 23);
      	this.btnLoad.TabIndex = 5;
      	this.btnLoad.Text = "Laden...";
      	this.btnLoad.UseVisualStyleBackColor = true;
      	this.btnLoad.Click += new System.EventHandler(this.BtnLoadClick);
      	// 
      	// lPathInfo
      	// 
      	this.lPathInfo.Location = new System.Drawing.Point(12, 566);
      	this.lPathInfo.Name = "lPathInfo";
      	this.lPathInfo.Size = new System.Drawing.Size(191, 18);
      	this.lPathInfo.TabIndex = 6;
      	this.lPathInfo.Text = "Pfadlänge: 88888";
      	// 
      	// btnRandomize
      	// 
      	this.btnRandomize.Location = new System.Drawing.Point(348, 561);
      	this.btnRandomize.Name = "btnRandomize";
      	this.btnRandomize.Size = new System.Drawing.Size(87, 23);
      	this.btnRandomize.TabIndex = 7;
      	this.btnRandomize.Text = "Zufall";
      	this.btnRandomize.UseVisualStyleBackColor = true;
      	this.btnRandomize.Click += new System.EventHandler(this.BtnRandomizeClick);
      	// 
      	// FrmLvlEdit
      	// 
      	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      	this.ClientSize = new System.Drawing.Size(819, 596);
      	this.Controls.Add(this.btnRandomize);
      	this.Controls.Add(this.lPathInfo);
      	this.Controls.Add(this.btnLoad);
      	this.Controls.Add(this.btnSave);
      	this.Controls.Add(this.btnReset);
      	this.Controls.Add(this.btnOk);
      	this.Controls.Add(this.pbMain);
      	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      	this.Name = "FrmLvlEdit";
      	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      	this.Text = "Level Editor";
      	((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
      	this.ResumeLayout(false);
      }
      private System.Windows.Forms.Button btnRandomize;
      private System.Windows.Forms.Label lPathInfo;
      private System.Windows.Forms.Button btnLoad;
      private System.Windows.Forms.Button btnSave;
      private System.Windows.Forms.Button btnOk;
      private System.Windows.Forms.Button btnReset;
      private System.Windows.Forms.PictureBox pbMain;
   }
}
