
namespace SatoConnector
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.yaziciPortu = new System.Windows.Forms.ComboBox();
            this.sunucuIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.musteriAdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.kullaniciAdi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sifre = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.sablonPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yazıcı Adı";
            // 
            // yaziciPortu
            // 
            this.yaziciPortu.DisplayMember = "Name";
            this.yaziciPortu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yaziciPortu.FormattingEnabled = true;
            this.yaziciPortu.Location = new System.Drawing.Point(16, 35);
            this.yaziciPortu.Name = "yaziciPortu";
            this.yaziciPortu.Size = new System.Drawing.Size(518, 31);
            this.yaziciPortu.TabIndex = 1;
            // 
            // sunucuIp
            // 
            this.sunucuIp.Location = new System.Drawing.Point(16, 95);
            this.sunucuIp.Name = "sunucuIp";
            this.sunucuIp.Size = new System.Drawing.Size(518, 31);
            this.sunucuIp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sunucu IP Adresi";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(459, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Onayla";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(378, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "İptal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Müşteri Adı";
            // 
            // musteriAdi
            // 
            this.musteriAdi.Location = new System.Drawing.Point(16, 155);
            this.musteriAdi.Name = "musteriAdi";
            this.musteriAdi.Size = new System.Drawing.Size(518, 31);
            this.musteriAdi.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kullanıcı Adı";
            // 
            // kullaniciAdi
            // 
            this.kullaniciAdi.Location = new System.Drawing.Point(16, 215);
            this.kullaniciAdi.Name = "kullaniciAdi";
            this.kullaniciAdi.Size = new System.Drawing.Size(518, 31);
            this.kullaniciAdi.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(12, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Şifre";
            // 
            // sifre
            // 
            this.sifre.Location = new System.Drawing.Point(16, 275);
            this.sifre.Name = "sifre";
            this.sifre.PasswordChar = '*';
            this.sifre.Size = new System.Drawing.Size(518, 31);
            this.sifre.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "prn";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "PRN dosyası|*.prn";
            this.openFileDialog1.Title = "Şablon dosyasını seçin";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 335);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 31);
            this.button3.TabIndex = 4;
            this.button3.Text = "Dosya seç";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(12, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Etiket Şablonu";
            // 
            // sablonPath
            // 
            this.sablonPath.AutoSize = true;
            this.sablonPath.Font = new System.Drawing.Font("Calibri", 10F);
            this.sablonPath.Location = new System.Drawing.Point(137, 343);
            this.sablonPath.Name = "sablonPath";
            this.sablonPath.Size = new System.Drawing.Size(0, 17);
            this.sablonPath.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 425);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.kullaniciAdi);
            this.Controls.Add(this.musteriAdi);
            this.Controls.Add(this.sunucuIp);
            this.Controls.Add(this.yaziciPortu);
            this.Controls.Add(this.sablonPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox yaziciPortu;
        private System.Windows.Forms.TextBox sunucuIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox musteriAdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox kullaniciAdi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sifre;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label sablonPath;
    }
}