using System;
using System.Windows.Forms;

namespace Estructura_de_datos
{
    public partial class Form1 : Form
    {
        // ===== ESTRUCTURAS =====
        List lista = new List();
        DoubleList listaDoble = new DoubleList();
        CircularList listaCircular = new CircularList();

        CircularQueue colaCircular = new CircularQueue();
        DoubleQueue colaDoble = new DoubleQueue();

        HashTable<int, string> diccionario = new HashTable<int, string>();
        Graph grafo = new Graph(false, false);

        public Form1()
        {
            InitializeComponent();

            cmbEstructura.Items.AddRange(new string[]
            {
                "Lista Simple",
                "Lista Doble",
                "Lista Circular",
                "Cola Circular",
                "Cola Doble",
                "Diccionario (Tabla Hash)",
                "Grafo"
            });

            cmbEstructura.SelectedIndex = 0;
            grafo.Output = Mostrar;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDato.Text, out int dato))
            {
                MessageBox.Show("Ingrese un número válido");
                return;
            }

            switch (cmbEstructura.SelectedItem.ToString())
            {
                case "Lista Simple":
                    lista.Add(new NodeList(dato));
                    break;

                case "Lista Doble":
                    listaDoble.Add(new NodeDoubleList(dato));
                    break;

                case "Lista Circular":
                    listaCircular.Add(new NodeCirculares(dato));
                    break;

                case "Cola Circular":
                    colaCircular.Enqueue(dato);
                    break;

                case "Cola Doble":
                    colaDoble.Enqueue(dato);
                    break;

                case "Diccionario (Tabla Hash)":
                    diccionario.Insertar(dato, "Valor_" + dato);
                    break;

                case "Grafo":
                    if (string.IsNullOrWhiteSpace(txtDato.Text))
                    {
                        MessageBox.Show("Ingresa una letra para el nodo");
                        return;
                    }

                    char nodo = char.ToUpper(txtDato.Text[0]);
                    grafo.AddNodo(new GraphNode(nodo));

                    txtSalida.Clear();
                    txtSalida.Text = grafo.Print();
                    return;



            }

            MostrarTodo();
        }

        // ================= ELIMINAR CON MENSAJES =================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDato.Text, out int dato))
            {
                MessageBox.Show("Ingrese un número válido");
                return;
            }

            bool eliminado = false;

            try
            {
                switch (cmbEstructura.SelectedItem.ToString())
                {
                    case "Lista Simple":
                        if (lista.Exists(dato))
                        {
                            lista.Remove(dato);
                            eliminado = true;
                        }
                        break;

                    case "Lista Doble":
                        if (listaDoble.Exists(dato))
                        {
                            listaDoble.Remove(dato);
                            eliminado = true;
                        }
                        break;

                    case "Lista Circular":
                        eliminado = listaCircular.Delete(dato);
                        break;

                    case "Cola Circular":
                        if (!colaCircular.IsEmpty())
                        {
                            colaCircular.Dequeue();
                            eliminado = true;
                        }
                        break;

                    case "Cola Doble":
                        if (!colaDoble.IsEmpty())
                        {
                            colaDoble.Dequeue();
                            eliminado = true;
                        }
                        break;

                    case "Diccionario (Tabla Hash)":
                        eliminado = diccionario.Eliminar(dato);
                        break;
                }

                if (eliminado)
                    MessageBox.Show("Dato eliminado correctamente ?");
                else
                    MessageBox.Show("Dato no encontrado ?");

                MostrarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDato.Text, out int dato))
            {
                MessageBox.Show("Ingrese un número válido");
                return;
            }

            bool encontrado = false;

            switch (cmbEstructura.SelectedItem.ToString())
            {
                case "Lista Simple":
                    encontrado = lista.Exists(dato);
                    break;

                case "Lista Doble":
                    encontrado = listaDoble.Exists(dato);
                    break;

                case "Lista Circular":
                    encontrado = listaCircular.Exists(dato);
                    break;

                case "Diccionario (Tabla Hash)":
                    encontrado = diccionario.ContainsKey(dato);
                    break;
            }

            MessageBox.Show(encontrado ? "Dato encontrado ?" : "Dato NO encontrado ?");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lista = new List();
            listaDoble = new DoubleList();
            listaCircular = new CircularList();
            colaCircular = new CircularQueue();
            colaDoble = new DoubleQueue();
            diccionario.Clear();

            txtSalida.Clear();
        }

        private void MostrarTodo()
        {
            switch (cmbEstructura.SelectedItem.ToString())
            {
                case "Lista Simple":
                    txtSalida.Text = lista.ToString();
                    break;

                case "Lista Doble":
                    txtSalida.Text = listaDoble.Show();
                    break;

                case "Lista Circular":
                    txtSalida.Text = listaCircular.ShowList();
                    break;


                case "Cola Circular":
                    txtSalida.Text = colaCircular.ToString();
                    break;

                case "Cola Doble":
                    txtSalida.Text = colaDoble.ToString();
                    break;

                case "Diccionario (Tabla Hash)":
                    txtSalida.Text = diccionario.Mostrar();
                    break;

                case "Grafo":
                    txtSalida.Text = grafo.Print();
                    break;
            }
        }

        private void Mostrar(string texto)
        {
            txtSalida.AppendText(texto + Environment.NewLine);
        }

        private void btnConectarGrafos_Click(object sender, EventArgs e)
        {
            if (txtOrigen.Text.Length == 0 || txtDestino.Text.Length == 0)
            {
                MessageBox.Show("Ingresa nodo origen y destino");
                return;
            }

            char origen = txtOrigen.Text[0];
            char destino = txtDestino.Text[0];

            grafo.AddArista(origen, destino);
            txtSalida.Text = grafo.Print();
        }
    }
}
