using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Estructura_de_datos
{
    public partial class Form1 : Form
    {
        // ===== ESTRUCTURAS =====
        List lista = new List();
        DoubleList listaDoble = new DoubleList();
        CircularList listaCircular = new CircularList();
        ListaDobleCircular listaDobleCircular = new ListaDobleCircular();
        PriorityQueue colaPrioridad = new PriorityQueue();

        Stack pila = new Stack();

        SimpleQueue colaSimple = new SimpleQueue();
        CircularQueue colaCircular = new CircularQueue();
        DoubleQueue colaDoble = new DoubleQueue();

        Tree arbol = new Tree();
        Dictionarys<string, string> diccionario = new Dictionarys<string, string>();
        HashTable<string, string> tablahash = new HashTable<string, string>();
        Graph grafo = new Graph(false, false);

        public Form1()
        {
            InitializeComponent();

            cmbEstructura.Items.AddRange(new string[]
            {
                "Lista Simple",
                "Lista Doble",
                "Lista Circular",
                "Lista Doble Circular",
                "Pila",
                "Cola Simple",
                "Cola Circular",
                "Cola Doble",
                "Cola Prioridad",
                "Árbol Binario",
                "Diccionario",
                "Tabla Hash",
                "Grafo"
            });

            cmbEstructura.SelectedIndex = 0;
            grafo.Output = Mostrar;
        }

        // ================= AGREGAR =================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDato.Text, out int dato) && cmbEstructura.Text != "Grafo")
            {
                MessageBox.Show("Ingresa un número válido");
                return;
            }
            string DATA = txtDato.Text;
            string Clave = txtOrigen.Text;
            string Valor = txtDestino.Text;
            switch (cmbEstructura.Text)
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

                case "Lista Doble Circular":
                    listaDobleCircular.Add(dato);
                    break;

                case "Pila":
                    pila.Push(dato);
                    break;

                case "Cola Simple":
                    colaSimple.Enqueue(dato);
                    break;

                case "Cola Circular":
                    colaCircular.Enqueue(dato);
                    break;

                case "Cola Doble":
                    colaDoble.Enqueue(dato);
                    break;
                case "Cola de Prioridad":

                    break;



                case "Árbol Binario":
                    EjecutarCapturandoConsola(() => arbol.Agregar(int.Parse(DATA)));
                    Log($"Agregado al Árbol: {DATA}");
                    break;



                case "Diccionario":
                    diccionario.Insertar(Clave, "Valor_" + Valor);
                    break;
                case "Tabla Hash":
                    tablahash.Insertar(Clave, "Valor" + Valor);
                    break;

                case "Grafo":
                    if (string.IsNullOrWhiteSpace(txtDato.Text))
                    {
                        MessageBox.Show("Ingresa una letra");
                        return;
                    }
                    char nodo = char.ToUpper(txtDato.Text[0]);
                    grafo.AddNodo(new GraphNode(nodo));
                    txtSalida.Text = grafo.Print();
                    return;
            }


            MostrarTodo();
        }

        // ================= ELIMINAR =================
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(txtDato.Text, out int dato) && cmbEstructura.Text != "Cola Simple" && cmbEstructura.Text != "Cola Circular" && cmbEstructura.Text != "Pila"
                && cmbEstructura.Text != "Cola Doble" && cmbEstructura.Text != "Cola Prioridad" && cmbEstructura.Text != "Tabla Hash" && cmbEstructura.Text != "Diccionario")
            {
                MessageBox.Show("Ingresa un número válido");
                return;
            }

            bool eliminado = false;
            string Valor = txtDestino.Text;
            string Clave = txtOrigen.Text;
            string Data = txtDato.Text;

            switch (cmbEstructura.Text)
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

                case "Lista Doble Circular":
                    eliminado = listaDobleCircular.Eliminar(dato);
                    break;

                case "Pila":
                    if (!pila.IsEmpty())
                    {
                        pila.Pop();
                        eliminado = true;
                    }
                    break;

                case "Cola Simple":
                    if (!colaSimple.IsEmpty())
                    {
                        colaSimple.Dequeue();
                        eliminado = true;
                    }
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
                case "Cola de Prioridad":
                    try
                    {
                        int datoEliminado = colaPrioridad.Dequeue();

                        MessageBox.Show($"Elemento eliminado: {datoEliminado} ");
                        eliminado = true;
                    }
                    catch (InvalidOperationException)
                    {
                        MessageBox.Show("La cola de prioridad está vacía ");
                        eliminado = false;
                    }
                    break;

                case "Árbol Binario":
                    arbol.Eliminar(dato);
                    eliminado = true;
                    break;

                case "Diccionario":
                    eliminado = diccionario.Eliminar(Clave);
                    break;
                case "Tabla Hash":
                    eliminado = tablahash.Eliminar(Clave);
                    break;
                case "Grafo":
                    if (string.IsNullOrWhiteSpace(txtDato.Text))
                    {
                        MessageBox.Show("Ingresa la letra del nodo a eliminar");
                        return;
                    }

                    char nodoEliminar = char.ToUpper(txtDato.Text[0]);
                    grafo.RemoveNodo(nodoEliminar);
                    MessageBox.Show($"Nodo '{nodoEliminar}' y todas sus aristas eliminadas");
                    txtSalida.Text = grafo.Print(); // actualizar visualización
                    eliminado = true;
                    break;
            }

            MessageBox.Show(eliminado
                ? "Dato eliminado correctamente "
                : "Dato no encontrado ");

            MostrarTodo();
        }

        // ================= BUSCAR =================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDato.Text, out int dato) && cmbEstructura.Text == "Diccionario")
            {
                MessageBox.Show("Ingresa un número válido");
                return;
            }

            bool encontrado = false;
            string Clave = txtDato.Text;

            switch (cmbEstructura.Text)
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

                case "Lista Doble Circular":
                    encontrado = listaDobleCircular.Buscar(dato) != null;
                    break;
            }

            MessageBox.Show(encontrado
                ? "Dato encontrado "
                : "Dato NO encontrado ");
        }

        // ================= LIMPIAR =================
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lista = new List();
            listaDoble = new DoubleList();
            listaCircular = new CircularList();
            listaDobleCircular = new ListaDobleCircular();

            pila = new Stack();

            colaSimple = new SimpleQueue();
            colaCircular = new CircularQueue();
            colaDoble = new DoubleQueue();
            colaPrioridad = new PriorityQueue();

            arbol = new Tree();
            diccionario.Clear();
            tablahash.Clear();

            txtSalida.Clear();
        }

        // ================= MOSTRAR =================
        private void MostrarTodo()
        {
            switch (cmbEstructura.Text)
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

                case "Lista Doble Circular":
                    txtSalida.Text = listaDobleCircular.ObtenerListado();
                    break;

                case "Pila":
                    txtSalida.Text = pila.ToString();
                    break;

                case "Cola Simple":
                    txtSalida.Text = colaSimple.ToString();
                    break;

                case "Cola Circular":
                    txtSalida.Text = colaCircular.ToString();
                    break;

                case "Cola Doble":
                    txtSalida.Text = colaDoble.ToString();
                    break;
                case "Cola de Prioridad":
                    txtSalida.Text = colaPrioridad.ToString();
                    break;

                case "Diccionario":
                    txtSalida.Text = diccionario.Mostrar();
                    break;
                case "Tabla Hash":
                    txtSalida.Text = tablahash.Mostrar();
                    break;

                case "Grafo":
                    txtSalida.Text = grafo.Print();
                    break;
            }
        }

        // ====== SALIDA PARA GRAFOS ======
        private void Mostrar(string texto)
        {
            txtSalida.AppendText(texto + Environment.NewLine);
        }

        // ====== CONECTAR GRAFOS ======
        private void btnConectarGrafos_Click(object sender, EventArgs e)
        {

            if (cmbEstructura.Text == "Cola Prioridad")

            {
                if (!int.TryParse(txtOrigen.Text, out int valor) || !int.TryParse(txtDestino.Text, out int prioridad))
                {
                    MessageBox.Show("Ingresa una prioridad válida (1, 2 o 3)");
                    return;
                }

                if (prioridad < 1 || prioridad > 3)
                {
                    MessageBox.Show("La prioridad debe ser 1, 2 o 3");
                    return;
                }

                colaPrioridad.Enqueue(valor, prioridad);
                txtSalida.Text = colaPrioridad.ToString();
            }
            if (cmbEstructura.Text == "Grafo")
            {
                if (txtOrigen.Text.Length == 0 || txtDestino.Text.Length == 0)
                {
                    MessageBox.Show("Ingresa nodo origen y destino");
                    return;
                }

                char origen = char.ToUpper(txtOrigen.Text[0]);
                char destino = char.ToUpper(txtDestino.Text[0]);

                grafo.AddArista(origen, destino);
                txtSalida.Text = grafo.Print();
            }
            if (cmbEstructura.Text == "Diccionario")
            {
                string Clave = txtOrigen.Text;
                string Valor = txtDestino.Text;
                diccionario.Insertar(Clave, "Valor_" + Valor);
                txtSalida.Text = diccionario.Mostrar();

            }
            if (cmbEstructura.Text == "Tabla Hash")
            {
                string Clave = txtOrigen.Text;
                string Valor = txtDestino.Text;
                tablahash.Insertar(Clave, "Valor_" + Valor);
                txtSalida.Text = tablahash.Mostrar();
            }
        }

        private void cmbEstructura_SelectedIndexChanged(object sender, EventArgs e)
        {
            string op = cmbEstructura.SelectedItem.ToString();

            switch (op)
            {
                case "Lista Simple":
                    btnInOrden.Enabled = false;
                    btnPostOrden.Enabled = false;
                    btnPreOrden.Enabled = false;
                    txtDato.Enabled = true;
                    label1.Text = null;
                    label2.Text = null;
                    txtOrigen.Enabled = false;
                    txtDestino.Enabled = false;
                    btnConectarGrafos.Enabled = false;
                    break;
                case "Lista Doble":
                    btnInOrden.Enabled = false;
                    btnPostOrden.Enabled = false;
                    btnPreOrden.Enabled = false;
                    txtDato.Enabled = true;
                    label1.Text = null;
                    label2.Text = null;
                    txtOrigen.Enabled = false;
                    txtDestino.Enabled = false;
                    btnConectarGrafos.Enabled = false;
                    break;
                case "Lista Circular":
                    btnInOrden.Enabled = false;
                    btnPostOrden.Enabled = false;
                    btnPreOrden.Enabled = false;
                    txtDato.Enabled = true;
                    label1.Text = null;
                    label2.Text = null;
                    txtOrigen.Enabled = false;
                    txtDestino.Enabled = false;
                    btnConectarGrafos.Enabled = false;
                    break;
                case "Lista Doble Circular":
                    txtDato.Enabled = true;
                    label1.Text = null;
                    label2.Text = null;
                    txtOrigen.Enabled = false;
                    txtDestino.Enabled = false;
                    btnConectarGrafos.Enabled = false;
                    break;
                case "Pila":
                    btnInOrden.Enabled = false;
                    btnPostOrden.Enabled = false;
                    btnPreOrden.Enabled = false;
                    txtDato.Enabled = true;
                    label1.Text = null;
                    label2.Text = null;
                    txtOrigen.Enabled = false;
                    txtDestino.Enabled = false;
                    btnConectarGrafos.Enabled = false;
                    break;
                case "Cola Simple":
                    btnInOrden.Enabled = false;
                    btnPostOrden.Enabled = false;
                    btnPreOrden.Enabled = false;
                    txtDato.Enabled = true;
                    label1.Text = null;
                    label2.Text = null;
                    txtOrigen.Enabled = false;
                    txtDestino.Enabled = false;
                    btnConectarGrafos.Enabled = false;
                    break;
                case "Cola Circular":
                    btnInOrden.Enabled = false;
                    btnPostOrden.Enabled = false;
                    btnPreOrden.Enabled = false;
                    txtDato.Enabled = true;
                    label1.Text = null;
                    label2.Text = null;
                    txtOrigen.Enabled = false;
                    txtDestino.Enabled = false;
                    btnConectarGrafos.Enabled = false;
                    break;
                case "Cola Doble":
                    btnInOrden.Enabled = false;
                    btnPostOrden.Enabled = false;
                    btnPreOrden.Enabled = false;
                    txtDato.Enabled = true;
                    label1.Text = null;
                    label2.Text = null;
                    txtOrigen.Enabled = false;
                    txtDestino.Enabled = false;
                    btnConectarGrafos.Enabled = false;
                    break;
                case "Cola Prioridad":
                    btnInOrden.Enabled = false;
                    btnPostOrden.Enabled = false;
                    btnPreOrden.Enabled = false;
                    txtDato.Enabled = false;
                    label1.Text = "Dato (int):";
                    label2.Text = "Prioridad (1-3):";
                    txtOrigen.Enabled = true;
                    txtDestino.Enabled = true;
                    btnConectarGrafos.Enabled = true;
                    btnConectarGrafos.Text = "Agregar prioridad";
                    break;
                case "Árbol Binario":
                    txtDato.Enabled = true;
                    label1.Text = null;
                    label2.Text = null;
                    txtOrigen.Enabled = false;
                    txtDestino.Enabled = false;
                    btnConectarGrafos.Enabled = false;
                    btnInOrden.Enabled = true;
                    btnPostOrden.Enabled = true;
                    btnPreOrden.Enabled = true;
                    break;
                case "Grafo":
                    txtDato.Enabled = true;
                    label1.Text = "Nodo Origen (char):";
                    label2.Text = "Nodo Destino (char):";
                    txtOrigen.Enabled = true;
                    txtDestino.Enabled = true;
                    btnConectarGrafos.Enabled = true;
                    btnInOrden.Enabled = false;
                    btnPostOrden.Enabled = false;
                    btnPreOrden.Enabled = false;
                    btnConectarGrafos.Text = "Agregar Conexión";
                    break;
                case "Diccionario":
                    txtDato.Enabled = false;
                    btnInOrden.Enabled = false;
                    btnPostOrden.Enabled = false;
                    btnPreOrden.Enabled = false;
                    label1.Text = "Clave / Filtro:";
                    label2.Text = "Valor (string):";
                    txtOrigen.Enabled = true;
                    txtDestino.Enabled = true;
                    btnConectarGrafos.Enabled = true;
                    btnConectarGrafos.Text = "Agregar al Diccionario";
                    break;
                case "Tabla Hash":
                    txtDato.Enabled = true; ;
                    btnInOrden.Enabled = false;
                    btnPostOrden.Enabled = false;
                    btnPreOrden.Enabled = false;
                    label1.Text = "Clave / Filtro:";
                    label2.Text = "Valor (string):";
                    txtOrigen.Enabled = true;
                    txtDestino.Enabled = true;
                    btnConectarGrafos.Enabled = true;
                    btnConectarGrafos.Text = "Agregar a la tabla Hash";
                    btnAgregar.Enabled = false;
                    break;
            }
        }

        private void txtOrigen_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInOrden_Click(object sender, EventArgs e)
        {
            Log("--- Recorrido InOrden ---");
            EjecutarCapturandoConsola(() => arbol.MostrarInOrden());

        }

        private void btnPostOrden_Click(object sender, EventArgs e)
        {
            Log("--- Recorrido PostOrden ---");
            EjecutarCapturandoConsola(() => arbol.MostrarPostOrden());

        }

        private void btnPreOrden_Click(object sender, EventArgs e)
        {
            Log("--- Recorrido PreOrden ---");
            EjecutarCapturandoConsola(() => arbol.MostrarPreOrden());
        }
        private void Log(string mensaje)
        {
            txtSalida.AppendText(mensaje + "\r\n");
            txtSalida.ScrollToCaret();
        }
        private void EjecutarCapturandoConsola(Action accion)
        {
            var writerOriginal = Console.Out;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                try
                {
                    accion();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    Console.SetOut(writerOriginal);
                    Log(sw.ToString());
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
