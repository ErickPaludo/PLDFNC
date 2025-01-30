namespace PLDFinanc.Componentes
{
    partial class FiltrosComp
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            dataIni = new MicroComponentes.DataControl();
            dataFim = new MicroComponentes.DataControl();
            comboTipo = new MicroComponentes.ComboControl();
            inputId = new MicroComponentes.ImputControl();
            inputTitulo = new MicroComponentes.ImputControl();
            inputDesc = new MicroComponentes.ImputControl();
            checkControl1 = new MicroComponentes.CheckControl();
            inputValor = new MicroComponentes.ImputControl();
            SuspendLayout();
            // 
            // dataIni
            // 
            dataIni.Location = new Point(281, 45);
            dataIni.Name = "dataIni";
            dataIni.Size = new Size(130, 70);
            dataIni.TabIndex = 5;
            // 
            // dataFim
            // 
            dataFim.Location = new Point(417, 45);
            dataFim.Name = "dataFim";
            dataFim.Size = new Size(130, 70);
            dataFim.TabIndex = 6;
            // 
            // comboTipo
            // 
            comboTipo.Location = new Point(281, 3);
            comboTipo.Name = "comboTipo";
            comboTipo.Size = new Size(344, 36);
            comboTipo.TabIndex = 7;
            // 
            // inputId
            // 
            inputId.Location = new Point(20, 6);
            inputId.Name = "inputId";
            inputId.Size = new Size(399, 39);
            inputId.TabIndex = 8;
            // 
            // inputTitulo
            // 
            inputTitulo.Location = new Point(20, 51);
            inputTitulo.Name = "inputTitulo";
            inputTitulo.Size = new Size(399, 39);
            inputTitulo.TabIndex = 9;
            // 
            // inputDesc
            // 
            inputDesc.Location = new Point(20, 93);
            inputDesc.Name = "inputDesc";
            inputDesc.Size = new Size(399, 39);
            inputDesc.TabIndex = 10;
            // 
            // checkControl1
            // 
            checkControl1.Location = new Point(281, 107);
            checkControl1.Name = "checkControl1";
            checkControl1.Size = new Size(262, 25);
            checkControl1.TabIndex = 11;
            // 
            // inputValor
            // 
            inputValor.Location = new Point(20, 136);
            inputValor.Name = "inputValor";
            inputValor.Size = new Size(399, 39);
            inputValor.TabIndex = 12;
            // 
            // FiltrosComp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(inputValor);
            Controls.Add(checkControl1);
            Controls.Add(comboTipo);
            Controls.Add(dataIni);
            Controls.Add(inputTitulo);
            Controls.Add(inputId);
            Controls.Add(dataFim);
            Controls.Add(inputDesc);
            Name = "FiltrosComp";
            Size = new Size(579, 190);
            ResumeLayout(false);
        }

        #endregion
        private MicroComponentes.DataControl dataIni;
        private MicroComponentes.DataControl dataFim;
        private MicroComponentes.ComboControl comboTipo;
        private MicroComponentes.ImputControl inputId;
        private MicroComponentes.ImputControl inputTitulo;
        private MicroComponentes.ImputControl inputDesc;
        private MicroComponentes.CheckControl checkControl1;
        private MicroComponentes.ImputControl inputValor;
    }
}
