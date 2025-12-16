namespace Estructura_de_datos
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbEstructura;
        private System.Windows.Forms.TextBox txtDato;
        private System.Windows.Forms.TextBox txtSalida;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbEstructura = new ComboBox();
            txtDato = new TextBox();
            txtSalida = new TextBox();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            btnConectarGrafos = new Button();
            txtDestino = new TextBox();
            txtOrigen = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnPreOrden = new Button();
            btnInOrden = new Button();
            btnPostOrden = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // cmbEstructura
            // 
            cmbEstructura.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstructura.Location = new Point(20, 20);
            cmbEstructura.Name = "cmbEstructura";
            cmbEstructura.Size = new Size(200, 28);
            cmbEstructura.TabIndex = 0;
            cmbEstructura.SelectedIndexChanged += cmbEstructura_SelectedIndexChanged;
            // 
            // txtDato
            // 
            txtDato.Location = new Point(240, 20);
            txtDato.Name = "txtDato";
            txtDato.Size = new Size(100, 27);
            txtDato.TabIndex = 1;
            // 
            // txtSalida
            // 
            txtSalida.Location = new Point(12, 120);
            txtSalida.Multiline = true;
            txtSalida.Name = "txtSalida";
            txtSalida.ReadOnly = true;
            txtSalida.ScrollBars = ScrollBars.Vertical;
            txtSalida.Size = new Size(500, 250);
            txtSalida.TabIndex = 6;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(360, 20);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 28);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(460, 20);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 28);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(560, 20);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 27);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(665, 20);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 28);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnConectarGrafos
            // 
            btnConectarGrafos.Location = new Point(604, 153);
            btnConectarGrafos.Name = "btnConectarGrafos";
            btnConectarGrafos.Size = new Size(100, 50);
            btnConectarGrafos.TabIndex = 7;
            btnConectarGrafos.Click += btnConectarGrafos_Click;
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(665, 120);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(60, 27);
            txtDestino.TabIndex = 8;
            // 
            // txtOrigen
            // 
            txtOrigen.Location = new Point(587, 120);
            txtOrigen.Name = "txtOrigen";
            txtOrigen.Size = new Size(60, 27);
            txtOrigen.TabIndex = 9;
            txtOrigen.TextChanged += txtOrigen_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(587, 93);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(665, 93);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 11;
            // 
            // btnPreOrden
            // 
            btnPreOrden.Location = new Point(714, 209);
            btnPreOrden.Name = "btnPreOrden";
            btnPreOrden.Size = new Size(75, 49);
            btnPreOrden.TabIndex = 12;
            btnPreOrden.Text = "Pre Orden";
            btnPreOrden.Click += btnPreOrden_Click;
            // 
            // btnInOrden
            // 
            btnInOrden.Location = new Point(517, 209);
            btnInOrden.Name = "btnInOrden";
            btnInOrden.Size = new Size(75, 28);
            btnInOrden.TabIndex = 13;
            btnInOrden.Text = "In Orden";
            btnInOrden.Click += btnInOrden_Click;
            // 
            // btnPostOrden
            // 
            btnPostOrden.Location = new Point(616, 209);
            btnPostOrden.Name = "btnPostOrden";
            btnPostOrden.Size = new Size(75, 49);
            btnPostOrden.TabIndex = 14;
            btnPostOrden.Text = "Post Orden";
            btnPostOrden.Click += btnPostOrden_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(240, -3);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 15;
            // 
            // Form1
            // 
            ClientSize = new Size(860, 400);
            Controls.Add(label3);
            Controls.Add(btnPostOrden);
            Controls.Add(btnInOrden);
            Controls.Add(btnPreOrden);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtOrigen);
            Controls.Add(txtDestino);
            Controls.Add(btnConectarGrafos);
            Controls.Add(cmbEstructura);
            Controls.Add(txtDato);
            Controls.Add(btnAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(txtSalida);
            Name = "Form1";
            Text = "Estructuras de Datos";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnConectarGrafos;
        private TextBox txtDestino;
        private TextBox txtOrigen;
        private Label label1;
        private Label label2;
        private Button btnPreOrden;
        private Button btnInOrden;
        private Button btnPostOrden;
        private Label label3;
    }
}
