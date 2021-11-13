
namespace IOAbstraction
{
	partial class FrmMain
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
			this.Btn_Browse = new System.Windows.Forms.Button();
			this.Btn_Get = new System.Windows.Forms.Button();
			this.Btn_Add = new System.Windows.Forms.Button();
			this.Btn_Remove = new System.Windows.Forms.Button();
			this.Ofd_Browse = new System.Windows.Forms.OpenFileDialog();
			this.Txt_Path = new System.Windows.Forms.TextBox();
			this.Rtb_AllResults = new System.Windows.Forms.RichTextBox();
			this.Lbl_Data = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Btn_Browse
			// 
			this.Btn_Browse.Location = new System.Drawing.Point(12, 60);
			this.Btn_Browse.Name = "Btn_Browse";
			this.Btn_Browse.Size = new System.Drawing.Size(465, 75);
			this.Btn_Browse.TabIndex = 0;
			this.Btn_Browse.Text = "Browse";
			this.Btn_Browse.UseVisualStyleBackColor = true;
			this.Btn_Browse.Click += new System.EventHandler(this.Btn_Browse_Click);
			// 
			// Btn_Get
			// 
			this.Btn_Get.Location = new System.Drawing.Point(12, 160);
			this.Btn_Get.Name = "Btn_Get";
			this.Btn_Get.Size = new System.Drawing.Size(151, 57);
			this.Btn_Get.TabIndex = 1;
			this.Btn_Get.Text = "Get All";
			this.Btn_Get.UseVisualStyleBackColor = true;
			this.Btn_Get.Click += new System.EventHandler(this.Btn_Get_Click);
			// 
			// Btn_Add
			// 
			this.Btn_Add.Location = new System.Drawing.Point(169, 160);
			this.Btn_Add.Name = "Btn_Add";
			this.Btn_Add.Size = new System.Drawing.Size(151, 57);
			this.Btn_Add.TabIndex = 2;
			this.Btn_Add.Text = "Add";
			this.Btn_Add.UseVisualStyleBackColor = true;
			this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
			// 
			// Btn_Remove
			// 
			this.Btn_Remove.Location = new System.Drawing.Point(326, 160);
			this.Btn_Remove.Name = "Btn_Remove";
			this.Btn_Remove.Size = new System.Drawing.Size(151, 57);
			this.Btn_Remove.TabIndex = 3;
			this.Btn_Remove.Text = "Remove";
			this.Btn_Remove.UseVisualStyleBackColor = true;
			this.Btn_Remove.Click += new System.EventHandler(this.Btn_Remove_Click);
			// 
			// Ofd_Browse
			// 
			this.Ofd_Browse.Filter = "Data file|*.zzz";
			// 
			// Txt_Path
			// 
			this.Txt_Path.Location = new System.Drawing.Point(12, 12);
			this.Txt_Path.Name = "Txt_Path";
			this.Txt_Path.ReadOnly = true;
			this.Txt_Path.Size = new System.Drawing.Size(463, 22);
			this.Txt_Path.TabIndex = 4;
			// 
			// Rtb_AllResults
			// 
			this.Rtb_AllResults.Location = new System.Drawing.Point(12, 273);
			this.Rtb_AllResults.Name = "Rtb_AllResults";
			this.Rtb_AllResults.Size = new System.Drawing.Size(463, 219);
			this.Rtb_AllResults.TabIndex = 5;
			this.Rtb_AllResults.Text = "";
			// 
			// Lbl_Data
			// 
			this.Lbl_Data.AutoSize = true;
			this.Lbl_Data.Location = new System.Drawing.Point(9, 253);
			this.Lbl_Data.Name = "Lbl_Data";
			this.Lbl_Data.Size = new System.Drawing.Size(57, 17);
			this.Lbl_Data.TabIndex = 6;
			this.Lbl_Data.Text = "All Data";
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(487, 509);
			this.Controls.Add(this.Lbl_Data);
			this.Controls.Add(this.Rtb_AllResults);
			this.Controls.Add(this.Txt_Path);
			this.Controls.Add(this.Btn_Remove);
			this.Controls.Add(this.Btn_Add);
			this.Controls.Add(this.Btn_Get);
			this.Controls.Add(this.Btn_Browse);
			this.Name = "FrmMain";
			this.Text = "Data File Manager";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Btn_Browse;
		private System.Windows.Forms.Button Btn_Get;
		private System.Windows.Forms.Button Btn_Add;
		private System.Windows.Forms.Button Btn_Remove;
		private System.Windows.Forms.TextBox Txt_Path;
		private System.Windows.Forms.OpenFileDialog Ofd_Browse;
		private System.Windows.Forms.RichTextBox Rtb_AllResults;
		private System.Windows.Forms.Label Lbl_Data;
	}
}

