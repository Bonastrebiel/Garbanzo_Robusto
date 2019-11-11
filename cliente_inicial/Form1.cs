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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        bool SesionIniciada;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SesionIniciada = false;
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

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string contraseña = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (Convert.ToInt32(contraseña)==0)
                {
                    SesionIniciada = true;
                    MessageBox.Show("Has iniciado sesión");
                }
                else
                {
                    SesionIniciada = false;
                    MessageBox.Show("Contraseña incorrecta");
                }
                //this.BackColor = Color.Gray;
                //server.Shutdown(SocketShutdown.Both);
                //server.Close();
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

                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    string respuesta = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show(respuesta);

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
                IPAddress direc = IPAddress.Parse("192.168.56.102");
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

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("El numero de partidas ganadas es: " + mensaje);
                }
                if (Minimo.Checked)
                {
                    
                    string mensaje = "4/";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show("El numero de partidas ganadas es: " + mensaje);
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

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("El nombre del jugador que jugo el dia seleccionado es: " + mensaje);
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

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("El tiempo medio es de: " + mensaje +"s");
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

        private void MostrarConectados_Click(object sender, EventArgs e)
        {
            if (SesionIniciada)
            {
                try   //Pedir Lista Conectados
                {
                    string resultado = String.Empty;
                    string mensaje = "7/";
                    // Enviamos al servidor el código de la función que pide la lista de conectados
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[512];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    string[] trocitos = mensaje.Split('/');
                    int numConectados = trocitos.Length;
                    string[] Conectados = new string[numConectados];
                    int i = 0;
                    for (i = 0; i < numConectados - 1; i++)
                    {
                        Conectados[i] = trocitos[i];
                        resultado = resultado + Conectados[i];
                        if (i < numConectados - 2)
                            resultado = resultado + ", ";

                    }
                    MessageBox.Show(resultado);
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
    }
}
