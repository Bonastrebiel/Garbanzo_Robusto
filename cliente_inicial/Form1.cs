using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        bool SesionIniciada;
        Thread atender;
        Graphics g;
        int x =-1;
        int y =-1;
        bool moving =false;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SesionIniciada = false;
        }
        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                if (codigo == 1)
                {
                    int Conectar = Convert.ToInt32(trozos[1].Split('\0')[0]);
                    if (Conectar == 0)
                    {
                        SesionIniciada = true;
                        MessageBox.Show("Has iniciado sesión");
                    }
                    else
                    {
                        SesionIniciada = false;
                        MessageBox.Show("Contraseña incorrecta");
                    }
                }
                else if (codigo == 2)
                {
                    MessageBox.Show(trozos[1].Split('\0')[0]);
                }
                else if (codigo == 3 || codigo == 4)
                {
                    string mensaje = trozos[1].Split('\0')[0];
                    MessageBox.Show("El numero de partidas ganadas es: " + mensaje);
                }
                else if (codigo == 5)
                {
                    string mensaje = trozos[1].Split('\0')[0];
                    MessageBox.Show("El nombre del jugador que jugo el dia seleccionado es: " + mensaje);
                }
                else if (codigo == 6)
                {
                    string mensaje = trozos[1].Split('\0')[0];
                    MessageBox.Show("El tiempo medio es de: " + mensaje + "s");
                }
                else if (codigo == 7)
                {
                    string resultado = String.Empty;
                    int numConectados = trozos.Length;
                    string[] Conectados = new string[numConectados];
                    int i;
                    for (i = 1; i < numConectados - 1; i++)
                    {
                        Conectados[i] = trozos[i];
                        resultado = resultado + Conectados[i];
                        if (i < numConectados - 2)
                            resultado = resultado + ", ";
                    }
                    MessageBox.Show(resultado);
                }
            }
        }
        private void IniciarSesion_Click_1(object sender, EventArgs e)
        {

            try
            {
                // Quiere saber la contraseña
                string usuario = nombre.Text;
                string Contra = contra.Text;
                string mensaje = "1/" + usuario +"/" + Contra;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionIniciada == false)
                {
                    string usuario = nombre.Text;
                    string contraseña = contra.Text;
                    // Enviamos al servidor el nombre y contraseña tecleado
                    string mensaje = "2/" + usuario + "/" + contraseña;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }

        private void conectar_Click(object sender, EventArgs e)
        {
            try
            {

                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse("192.168.56.101");
                IPEndPoint ipep = new IPEndPoint(direc, 9050);


                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
        }

        private void Desconectar_Click(object sender, EventArgs e)
        {
            // Se terminó el servicio. 
            // Nos desconectamos
            //this.BackColor = Color.Gray;
            //server.Shutdown(SocketShutdown.Both);
            //server.Close();
            string usuario = nombre.Text;
            string mensaje = "0/" + usuario;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            atender.Abort();
            this.BackColor = Color.Gray;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (SesionIniciada)
            {
            try  //Codigo Biel
            {
                if (Maximo.Checked)
                {
                    
                    string mensaje = "3/";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                if (Minimo.Checked)
                {
                    
                    string mensaje = "4/";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            }
            else
            {
                MessageBox.Show("Por favor inicia sesión");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SesionIniciada)
            {
            try   //Codigo Miguel
            {

                string mensaje = "5/" + textBox1.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            }
            else
            {
                MessageBox.Show("Por favor inicia sesión");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (SesionIniciada)
            {            
            try   //Codigo Uriel
            {
                string mensaje = "6/" + textBox2.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            }
            else
            {
                MessageBox.Show("Por favor inicia sesión");
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
            panel1.Cursor = Cursors.Cross;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
                g.DrawLine(pen, new Point(x, y), e.Location);
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            panel1.Cursor = Cursors.Default;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pen.Color = Color.White;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = Convert.ToInt32(numericUpDown1.Value);
        }

        private void escribir_en_chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chatPannel.Text = chatPannel.Text + "Usuario" + ": " + chatBox.Text + "\n";
                chatBox.Text = "";
            }
        }
        private void chatBox_Leave(object sender, EventArgs e)
        {
            chatBox.Text = "Escribe aqui";
        }

        private void chatBox_Enter(object sender, EventArgs e)
        {
            chatBox.Text = "";
        }

        private void nombre_Enter(object sender, EventArgs e)
        {
            nombre.Text = "";
        }

        private void contra_Enter(object sender, EventArgs e)
        {
            contra.Text = "";
            contra.UseSystemPasswordChar = true;
        }
    }
}
