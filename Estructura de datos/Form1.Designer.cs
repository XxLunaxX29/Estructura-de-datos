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
            SuspendLayout();
            // 
            // cmbEstructura
            // 
            cmbEstructura.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstructura.Location = new Point(20, 20);
            cmbEstructura.Name = "cmbEstructura";
            cmbEstructura.Size = new Size(200, 28);
            cmbEstructura.TabIndex = 0;
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
            btnConectarGrafos.Location = new Point(535, 130);
            btnConectarGrafos.Name = "btnConectarGrafos";
            btnConectarGrafos.Size = new Size(100, 50);
            btnConectarGrafos.TabIndex = 7;
            btnConectarGrafos.Text = "Conexion Grafos";
            btnConectarGrafos.Click += btnConectarGrafos_Click;
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(596, 97);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(60, 27);
            txtDestino.TabIndex = 8;
            // 
            // txtOrigen
            // 
            txtOrigen.Location = new Point(518, 97);
            txtOrigen.Name = "txtOrigen";
            txtOrigen.Size = new Size(60, 27);
            txtOrigen.TabIndex = 9;
            // 
            // Form1
            // 
            ClientSize = new Size(860, 400);
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
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnConectarGrafos;
        private TextBox txtDestino;
        private TextBox txtOrigen;
    }
}
