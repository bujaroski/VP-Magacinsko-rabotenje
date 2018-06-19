namespace Magacinsko_rabotenje
{
    partial class Form1
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
            this.Magacini = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIzbrisiProizvod = new System.Windows.Forms.Button();
            this.btnIzbrisiMagacin = new System.Windows.Forms.Button();
            this.btnIzmeniProizvod = new System.Windows.Forms.Button();
            this.btnDodadiProizvod = new System.Windows.Forms.Button();
            this.btnIzmeniMagacin = new System.Windows.Forms.Button();
            this.btnDodadiMagacin = new System.Windows.Forms.Button();
            this.lbProizvodVoMagacin = new System.Windows.Forms.ListBox();
            this.lbMagacini = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label6 = new System.Windows.Forms.Label();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbProizvodi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMagacini = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbFakturi = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDodadi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbIme = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbOpis = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbCena = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbKolicina1 = new System.Windows.Forms.TextBox();
            this.Magacini.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Magacini
            // 
            this.Magacini.AccessibleDescription = "";
            this.Magacini.AccessibleName = "";
            this.Magacini.Controls.Add(this.tabPage1);
            this.Magacini.Controls.Add(this.tabPage2);
            this.Magacini.Controls.Add(this.tabPage3);
            this.Magacini.Location = new System.Drawing.Point(12, 12);
            this.Magacini.Name = "Magacini";
            this.Magacini.SelectedIndex = 0;
            this.Magacini.Size = new System.Drawing.Size(848, 457);
            this.Magacini.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnIzbrisiProizvod);
            this.tabPage1.Controls.Add(this.btnIzbrisiMagacin);
            this.tabPage1.Controls.Add(this.btnIzmeniProizvod);
            this.tabPage1.Controls.Add(this.btnDodadiProizvod);
            this.tabPage1.Controls.Add(this.btnIzmeniMagacin);
            this.tabPage1.Controls.Add(this.btnDodadiMagacin);
            this.tabPage1.Controls.Add(this.lbProizvodVoMagacin);
            this.tabPage1.Controls.Add(this.lbMagacini);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(840, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Магацини";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 397);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "label7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Листа на производи во магацин:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Листа на магацини:";
            // 
            // btnIzbrisiProizvod
            // 
            this.btnIzbrisiProizvod.Location = new System.Drawing.Point(388, 372);
            this.btnIzbrisiProizvod.Name = "btnIzbrisiProizvod";
            this.btnIzbrisiProizvod.Size = new System.Drawing.Size(259, 22);
            this.btnIzbrisiProizvod.TabIndex = 6;
            this.btnIzbrisiProizvod.Text = "Избриши производ";
            this.btnIzbrisiProizvod.UseVisualStyleBackColor = true;
            this.btnIzbrisiProizvod.Click += new System.EventHandler(this.btnIzbrisiProizvod_Click);
            // 
            // btnIzbrisiMagacin
            // 
            this.btnIzbrisiMagacin.Location = new System.Drawing.Point(16, 372);
            this.btnIzbrisiMagacin.Name = "btnIzbrisiMagacin";
            this.btnIzbrisiMagacin.Size = new System.Drawing.Size(237, 22);
            this.btnIzbrisiMagacin.TabIndex = 5;
            this.btnIzbrisiMagacin.Text = "Избриши магацин";
            this.btnIzbrisiMagacin.UseVisualStyleBackColor = true;
            this.btnIzbrisiMagacin.Click += new System.EventHandler(this.btnIzbrisiMagacin_Click);
            // 
            // btnIzmeniProizvod
            // 
            this.btnIzmeniProizvod.Location = new System.Drawing.Point(388, 343);
            this.btnIzmeniProizvod.Name = "btnIzmeniProizvod";
            this.btnIzmeniProizvod.Size = new System.Drawing.Size(259, 23);
            this.btnIzmeniProizvod.TabIndex = 4;
            this.btnIzmeniProizvod.Text = "Измени производ";
            this.btnIzmeniProizvod.UseVisualStyleBackColor = true;
            this.btnIzmeniProizvod.Click += new System.EventHandler(this.btnIzmeniProizvod_Click);
            // 
            // btnDodadiProizvod
            // 
            this.btnDodadiProizvod.Location = new System.Drawing.Point(388, 314);
            this.btnDodadiProizvod.Name = "btnDodadiProizvod";
            this.btnDodadiProizvod.Size = new System.Drawing.Size(259, 23);
            this.btnDodadiProizvod.TabIndex = 3;
            this.btnDodadiProizvod.Text = "Додади производ";
            this.btnDodadiProizvod.UseVisualStyleBackColor = true;
            this.btnDodadiProizvod.Click += new System.EventHandler(this.btnDodadiProizvod_Click);
            // 
            // btnIzmeniMagacin
            // 
            this.btnIzmeniMagacin.Location = new System.Drawing.Point(16, 343);
            this.btnIzmeniMagacin.Name = "btnIzmeniMagacin";
            this.btnIzmeniMagacin.Size = new System.Drawing.Size(237, 23);
            this.btnIzmeniMagacin.TabIndex = 2;
            this.btnIzmeniMagacin.Text = "Измени магацин";
            this.btnIzmeniMagacin.UseVisualStyleBackColor = true;
            this.btnIzmeniMagacin.Click += new System.EventHandler(this.btnIzmeniMagacin_Click);
            // 
            // btnDodadiMagacin
            // 
            this.btnDodadiMagacin.Location = new System.Drawing.Point(16, 314);
            this.btnDodadiMagacin.Name = "btnDodadiMagacin";
            this.btnDodadiMagacin.Size = new System.Drawing.Size(237, 23);
            this.btnDodadiMagacin.TabIndex = 1;
            this.btnDodadiMagacin.Text = "Додади магацин";
            this.btnDodadiMagacin.UseVisualStyleBackColor = true;
            this.btnDodadiMagacin.Click += new System.EventHandler(this.btnDodadiMagacin_Click);
            // 
            // lbProizvodVoMagacin
            // 
            this.lbProizvodVoMagacin.FormattingEnabled = true;
            this.lbProizvodVoMagacin.Location = new System.Drawing.Point(388, 31);
            this.lbProizvodVoMagacin.Name = "lbProizvodVoMagacin";
            this.lbProizvodVoMagacin.Size = new System.Drawing.Size(259, 277);
            this.lbProizvodVoMagacin.TabIndex = 1;
            // 
            // lbMagacini
            // 
            this.lbMagacini.FormattingEnabled = true;
            this.lbMagacini.Location = new System.Drawing.Point(16, 31);
            this.lbMagacini.Name = "lbMagacini";
            this.lbMagacini.Size = new System.Drawing.Size(237, 277);
            this.lbMagacini.TabIndex = 0;
            this.lbMagacini.SelectedIndexChanged += new System.EventHandler(this.lbMagacini_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.btnDodadi);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.lbFakturi);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(840, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Фактури";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(380, 390);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 4;
            this.button7.Text = "Избриши ставка";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbKolicina);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbProizvodi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbMagacini);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 392);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Креирај фактура";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(6, 221);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Избери датум";
            // 
            // tbKolicina
            // 
            this.tbKolicina.Location = new System.Drawing.Point(6, 161);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(100, 20);
            this.tbKolicina.TabIndex = 7;
            this.tbKolicina.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Внеси количина";
            // 
            // cbProizvodi
            // 
            this.cbProizvodi.FormattingEnabled = true;
            this.cbProizvodi.Location = new System.Drawing.Point(6, 100);
            this.cbProizvodi.Name = "cbProizvodi";
            this.cbProizvodi.Size = new System.Drawing.Size(223, 21);
            this.cbProizvodi.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Избери производ";
            // 
            // cbMagacini
            // 
            this.cbMagacini.FormattingEnabled = true;
            this.cbMagacini.Location = new System.Drawing.Point(6, 48);
            this.cbMagacini.Name = "cbMagacini";
            this.cbMagacini.Size = new System.Drawing.Size(223, 21);
            this.cbMagacini.TabIndex = 1;
            this.cbMagacini.SelectedIndexChanged += new System.EventHandler(this.cbMagacini_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Избери магацин";
            // 
            // lbFakturi
            // 
            this.lbFakturi.FormattingEnabled = true;
            this.lbFakturi.Location = new System.Drawing.Point(380, 21);
            this.lbFakturi.Name = "lbFakturi";
            this.lbFakturi.Size = new System.Drawing.Size(220, 355);
            this.lbFakturi.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(783, 431);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnDodadi
            // 
            this.btnDodadi.Location = new System.Drawing.Point(6, 408);
            this.btnDodadi.Name = "btnDodadi";
            this.btnDodadi.Size = new System.Drawing.Size(75, 23);
            this.btnDodadi.TabIndex = 9;
            this.btnDodadi.Text = "Додади";
            this.btnDodadi.UseVisualStyleBackColor = true;
            this.btnDodadi.Click += new System.EventHandler(this.btnDodadi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbKolicina1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbCena);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbOpis);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbIme);
            this.groupBox2.Location = new System.Drawing.Point(624, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 355);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Детали";
            // 
            // tbIme
            // 
            this.tbIme.Enabled = false;
            this.tbIme.Location = new System.Drawing.Point(6, 32);
            this.tbIme.Name = "tbIme";
            this.tbIme.Size = new System.Drawing.Size(175, 20);
            this.tbIme.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Име";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Опис";
            // 
            // tbOpis
            // 
            this.tbOpis.Enabled = false;
            this.tbOpis.Location = new System.Drawing.Point(6, 71);
            this.tbOpis.Multiline = true;
            this.tbOpis.Name = "tbOpis";
            this.tbOpis.Size = new System.Drawing.Size(172, 64);
            this.tbOpis.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Цена";
            // 
            // tbCena
            // 
            this.tbCena.Enabled = false;
            this.tbCena.Location = new System.Drawing.Point(6, 177);
            this.tbCena.Name = "tbCena";
            this.tbCena.Size = new System.Drawing.Size(175, 20);
            this.tbCena.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Количина";
            // 
            // tbKolicina1
            // 
            this.tbKolicina1.Enabled = false;
            this.tbKolicina1.Location = new System.Drawing.Point(6, 228);
            this.tbKolicina1.Name = "tbKolicina1";
            this.tbKolicina1.Size = new System.Drawing.Size(175, 20);
            this.tbKolicina1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 482);
            this.Controls.Add(this.Magacini);
            this.Name = "Form1";
            this.Text = "Магацинско работење";
            this.Magacini.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Magacini;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lbMagacini;
        private System.Windows.Forms.Button btnIzmeniMagacin;
        private System.Windows.Forms.Button btnDodadiMagacin;
        private System.Windows.Forms.ListBox lbProizvodVoMagacin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIzbrisiProizvod;
        private System.Windows.Forms.Button btnIzbrisiMagacin;
        private System.Windows.Forms.Button btnIzmeniProizvod;
        private System.Windows.Forms.Button btnDodadiProizvod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMagacini;
        private System.Windows.Forms.ListBox lbFakturi;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbProizvodi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDodadi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbIme;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbKolicina1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbCena;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbOpis;
    }
}

