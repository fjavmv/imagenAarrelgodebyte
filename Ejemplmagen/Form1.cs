namespace Ejemplmagen
{
    public partial class Form1 : Form
    {
        Image img;
        ModelImg modelImg = new ModelImg();
        Imagen imagen = new Imagen();
        DbPostgresql dbPostgresql = new DbPostgresql();
        //List<string> lista = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileDialog image = new FileDialog();
            img = image.obtener(openFileDialog1, pictureBox1);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            
            String data = imagen.Redimensionar(img, "temporal");
            modelImg.img = imagen.Imagen_A_Bytes(data);
            MessageBox.Show("imagen convertida");
            
            //pictureBox2.Image = imagen.Bytes_A_Imagen(dataBytes);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            bool click = btnInsertar.Enabled;
            dbPostgresql.insertar(modelImg);
            MessageBox.Show("Se ha guardado la imagen en la db");
            
            if (click == true)
            {
                List<string> lista = dbPostgresql.consultarIds();
                List<string> listaAux = new List<string>();
                foreach (string id in lista)
                {
                    listaAux.Add("ID: " + id);
                }
                listBIds.DataSource = listaAux;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            
            if (txtId.Text.Length!=0)
            {
                int id = Convert.ToInt16(txtId.Text);
                Byte[] dataImg = dbPostgresql.consultarTodo(id);
                modelImg.imagenModel = imagen.Bytes_A_Imagen(dataImg);
                pictureBox2.Image = modelImg.imagenModel;
            }
            else
            {
                MessageBox.Show("El campo no puede esta vacío");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> lista = dbPostgresql.consultarIds();
            List<string> listaAux = new List<string>();
            foreach (string id in lista)
            {
                listaAux.Add("ID: " + id);
            }
            listBIds.DataSource = listaAux;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}