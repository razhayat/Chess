
namespace Chess
{
	partial class Game
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.NewGameBtn = new System.Windows.Forms.Button();
			this.P1PointsLbl = new System.Windows.Forms.Label();
			this.P2PointsLbl = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.GameEndedLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// NewGameBtn
			// 
			this.NewGameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
			this.NewGameBtn.Location = new System.Drawing.Point(818, 521);
			this.NewGameBtn.Name = "NewGameBtn";
			this.NewGameBtn.Size = new System.Drawing.Size(163, 57);
			this.NewGameBtn.TabIndex = 0;
			this.NewGameBtn.Text = "משחק חדש";
			this.NewGameBtn.UseVisualStyleBackColor = true;
			this.NewGameBtn.Click += new System.EventHandler(this.NewGameBtn_Click);
			// 
			// P1PointsLbl
			// 
			this.P1PointsLbl.AutoSize = true;
			this.P1PointsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
			this.P1PointsLbl.Location = new System.Drawing.Point(787, 364);
			this.P1PointsLbl.Name = "P1PointsLbl";
			this.P1PointsLbl.Size = new System.Drawing.Size(47, 52);
			this.P1PointsLbl.TabIndex = 1;
			this.P1PointsLbl.Text = "0";
			// 
			// P2PointsLbl
			// 
			this.P2PointsLbl.AutoSize = true;
			this.P2PointsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
			this.P2PointsLbl.Location = new System.Drawing.Point(954, 364);
			this.P2PointsLbl.Name = "P2PointsLbl";
			this.P2PointsLbl.Size = new System.Drawing.Size(47, 52);
			this.P2PointsLbl.TabIndex = 2;
			this.P2PointsLbl.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
			this.label1.Location = new System.Drawing.Point(758, 312);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 37);
			this.label1.TabIndex = 3;
			this.label1.Text = "שחקן 1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
			this.label2.Location = new System.Drawing.Point(921, 312);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 37);
			this.label2.TabIndex = 4;
			this.label2.Text = "שחקן 2";
			// 
			// GameEndedLabel
			// 
			this.GameEndedLabel.AutoSize = true;
			this.GameEndedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
			this.GameEndedLabel.ForeColor = System.Drawing.Color.Red;
			this.GameEndedLabel.Location = new System.Drawing.Point(756, 109);
			this.GameEndedLabel.Name = "GameEndedLabel";
			this.GameEndedLabel.Size = new System.Drawing.Size(248, 52);
			this.GameEndedLabel.TabIndex = 5;
			this.GameEndedLabel.Text = "המשחק נגמר";
			this.GameEndedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.GameEndedLabel.Visible = false;
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(1107, 674);
			this.Controls.Add(this.GameEndedLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.P2PointsLbl);
			this.Controls.Add(this.P1PointsLbl);
			this.Controls.Add(this.NewGameBtn);
			this.Name = "Game";
			this.Text = "Game";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button NewGameBtn;
		private System.Windows.Forms.Label P1PointsLbl;
		private System.Windows.Forms.Label P2PointsLbl;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label GameEndedLabel;
	}
}