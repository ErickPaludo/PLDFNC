namespace PrototipoFNCForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker3 = new DateTimePicker();
            button2 = new Button();
            textBoxUser = new TextBox();
            textBoxParcelas = new TextBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            textBoxValorInteiro = new TextBox();
            textBoxValor = new TextBox();
            textBoxDescricao = new TextBox();
            textBoxTitulo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 219);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(826, 190);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(dateTimePicker3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(textBoxUser);
            groupBox1.Controls.Add(textBoxParcelas);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(textBoxValorInteiro);
            groupBox1.Controls.Add(textBoxValor);
            groupBox1.Controls.Add(textBoxDescricao);
            groupBox1.Controls.Add(textBoxTitulo);
            groupBox1.Location = new Point(10, 11);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(826, 204);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(6, 174);
            dateTimePicker2.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(139, 23);
            dateTimePicker2.TabIndex = 6;
            dateTimePicker2.Value = new DateTime(2025, 3, 1, 15, 10, 0, 0);
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Location = new Point(161, 174);
            dateTimePicker3.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(137, 23);
            dateTimePicker3.TabIndex = 7;
            // 
            // button2
            // 
            button2.Location = new Point(680, 174);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(140, 26);
            button2.TabIndex = 8;
            button2.Text = "Pesquisar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(729, 20);
            textBoxUser.Margin = new Padding(3, 2, 3, 2);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.PlaceholderText = "User";
            textBoxUser.Size = new Size(91, 23);
            textBoxUser.TabIndex = 9;
            textBoxUser.Text = "1";
            // 
            // textBoxParcelas
            // 
            textBoxParcelas.Enabled = false;
            textBoxParcelas.Location = new Point(199, 76);
            textBoxParcelas.Margin = new Padding(3, 2, 3, 2);
            textBoxParcelas.Name = "textBoxParcelas";
            textBoxParcelas.PlaceholderText = "Parcelas";
            textBoxParcelas.Size = new Size(134, 23);
            textBoxParcelas.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(197, 130);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(136, 26);
            button1.TabIndex = 6;
            button1.Text = "Cadastre";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Débito", "Crédito", "Saldo" });
            comboBox1.Location = new Point(197, 103);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(134, 23);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "Débito";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(5, 92);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(157, 23);
            dateTimePicker1.TabIndex = 4;
            // 
            // textBoxValorInteiro
            // 
            textBoxValorInteiro.Enabled = false;
            textBoxValorInteiro.Location = new Point(199, 49);
            textBoxValorInteiro.Margin = new Padding(3, 2, 3, 2);
            textBoxValorInteiro.Name = "textBoxValorInteiro";
            textBoxValorInteiro.PlaceholderText = "Valor Inteiro";
            textBoxValorInteiro.Size = new Size(134, 23);
            textBoxValorInteiro.TabIndex = 3;
            // 
            // textBoxValor
            // 
            textBoxValor.Location = new Point(199, 20);
            textBoxValor.Margin = new Padding(3, 2, 3, 2);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.PlaceholderText = "Valor";
            textBoxValor.Size = new Size(134, 23);
            textBoxValor.TabIndex = 2;
            // 
            // textBoxDescricao
            // 
            textBoxDescricao.Location = new Point(5, 44);
            textBoxDescricao.Margin = new Padding(3, 2, 3, 2);
            textBoxDescricao.Multiline = true;
            textBoxDescricao.Name = "textBoxDescricao";
            textBoxDescricao.PlaceholderText = "Descrição";
            textBoxDescricao.Size = new Size(157, 38);
            textBoxDescricao.TabIndex = 1;
            // 
            // textBoxTitulo
            // 
            textBoxTitulo.Location = new Point(5, 20);
            textBoxTitulo.Margin = new Padding(3, 2, 3, 2);
            textBoxTitulo.Name = "textBoxTitulo";
            textBoxTitulo.PlaceholderText = "Titulo";
            textBoxTitulo.Size = new Size(157, 23);
            textBoxTitulo.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 420);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private TextBox textBoxDescricao;
        private TextBox textBoxTitulo;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBoxValorInteiro;
        private TextBox textBoxValor;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker3;
        private Button button1;
        private TextBox textBoxParcelas;
        private Button button2;
        private TextBox textBoxUser;
    }
}
