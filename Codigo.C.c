#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

int sock_conn, sock_listen, ret;
struct sockaddr_in serv_adr;
char buff[512];
char buff2[512];
int err;
MYSQL *conn;
MYSQL_RES *resultado;
MYSQL_ROW row;
int sockets[100];
int i=0;

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
typedef struct{
	char Usuario[20];
	int socket;
}Conectado;
typedef struct{
	Conectado Conectados[100];
	int num;
}LConectados;
LConectados Lista;
int IniciarSesion(char nombre[20], char contra[20], int socket)
{
	char consulta[100];
	strcpy(consulta, "SELECT Jugador.contra FROM Jugador WHERE Jugador.nombre = '");
	strcat(consulta, nombre);
	strcat(consulta, "'");
	int err;
	err=mysql_query (conn, consulta);
	if (err!=0)
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");			
	else
	{
		if (strcmp(contra, row[0])==0)
		{
			ConectarUsuario(nombre, &Lista, socket);
			return 0;
		}
		else
			return -1;
		
	}
}
int Registrar(char nombre[20], char contra[20])
{
	char consulta[100];
	strcpy(consulta, "INSERT INTO Jugador(id, nombre, contra, conectado, puntuacionMax ) VALUES(NULL, '");
	strcat(consulta, nombre);
	strcat(consulta, "', '");
	strcat(consulta, contra);
	strcat(consulta, "', 0, 0)");
	int err;
	err=mysql_query (conn, consulta);
	if (err!=0)
	{
		printf ("Error al introducir datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		return -1;
	}		
	else
	{
		return 0;
	}
}
int ObtenerEstadoConexion(char nombre[20])
{
	char consulta[100];
	strcpy(consulta, "SELECT Jugador.conectado FROM Jugador WHERE Jugador.nombre = '");
	strcat(consulta, nombre);
	strcat(consulta, "'");
	int err;
	err=mysql_query (conn, consulta);
	if (err!=0)
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");			
	else
	{
		return atoi(row[0]);
	}
}
void ConectarUsuario(char nombre[20],LConectados *lista,int socket)
{
	strcpy(lista->Conectados[lista->num].Usuario, nombre);
	lista->Conectados[lista->num].socket = socket;
	lista->num ++;
}
void DesconectarUsuario(char *nombre[20],LConectados *lista)
{
	int i = 0;
	while (i < lista->num)
	{
		if (strcmp(lista->Conectados[i].Usuario,nombre)==0)
		{
			lista->num--;
			while (i < lista->num)
			{
				strcpy(lista->Conectados[i].Usuario ,lista->Conectados[i+1].Usuario);
				lista->Conectados[i].socket = lista->Conectados[i+1].socket;
				i++;
			}
		}
		else
		{
			i++;
		}
	}		
}
void DevuelveConectados(char *ListaConectados[500],LConectados *lista) //Devuelve la lista de conectados y en el int, tambi￩n el n￺mero
{
	int i;
	strcpy(ListaConectados,"7/");
	for (i=0; i < lista->num ; i++)
	{
		strcat(ListaConectados, lista->Conectados[i].Usuario);
		strcat(ListaConectados, "/");
	}
}
int PideMaximo()
{
	char consulta[300];
	strcpy (consulta,"SELECT count(Partida.id) FROM Partida WHERE Partida.ganador = (SELECT Jugador.nombre FROM Jugador WHERE Jugador.puntuacionMax = (SELECT MAX(Jugador.puntuacionMax) FROM Jugador));");
	int err;
	err=mysql_query (conn, consulta);
	if (err!=0)
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		return -1;
		printf ("No se han obtenido datos en la consulta\n");
	}
	else
	{
		int NumPartidas = atoi(row[0]);
		return NumPartidas;
	}
}
int PideMinimo()
{
	char consulta[300];
	strcpy (consulta,"SELECT count(Partida.id) FROM Partida WHERE Partida.ganador = (SELECT Jugador.nombre FROM Jugador WHERE Jugador.puntuacionMax = (SELECT MIN(Jugador.puntuacionMax) FROM Jugador));");
	int err;
	err=mysql_query (conn, consulta);
	if (err!=0)
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		return -1;
		printf ("No se han obtenido datos en la consulta\n");
	}
	else
	{
		int NumPartidas = atoi(row[0]);
		return NumPartidas;
	}
}
void ConsultaFecha(char *fecha[11], char *buff2[512])
{
	char consulta[300];
	strcpy (consulta,"SELECT Jugador.nombre FROM Jugador WHERE Jugador.id IN (SELECT Jugador.id FROM Partida, Relacion, Jugador WHERE Jugador.puntuacionMax = (SELECT MAX(Jugador.puntuacionMax) FROM Partida, Relacion, Jugador WHERE Partida.fecha = '");
	strcat (consulta, fecha);
	strcat (consulta,"' AND Partida.id = Relacion.idJugador AND Relacion.idJugador = Jugador.id) AND Jugador.id = Relacion.idJugador AND Relacion.idPartida = Partida.id AND Partida.fecha = '");
	strcat (consulta, fecha);
	strcat (consulta, "');");
	int err;
	err=mysql_query (conn, consulta);
	if (err!=0)
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{
		strcpy(buff2,"5/ERROR: No se han obtenido datos en la consulta");
		printf ("No se han obtenido datos en la consulta\n");
	}
	else
	{
		strcpy(buff2,"5/");
		strcat(buff2,row[0]);
		row = mysql_fetch_row (resultado);
	}
}
int TiempoMedio(char nombre[20])
{
	char consulta[300];
	strcpy (consulta,"SELECT avg(Partida.tiempo) FROM Partida, Jugador, Relacion WHERE Partida.dificultad = 'd' AND Jugador.nombre = '");
	strcat (consulta,nombre);
	strcat (consulta,"' AND Jugador.id = Relacion.idJugador AND Relacion.idPartida = Partida.id;");
	
	int err;
	err=mysql_query (conn, consulta);
	if (err!=0)
	{
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
	{
		return -1;
		printf ("No se han obtenido datos en la consulta\n");
	}
	else
	{
		int tiempo = atoi(row[0]);
		return tiempo;
	}
}

void *AtenderCliente (void *socket)
{
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	//int socket_conn = * (int *) socket;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	
	
	int terminar = 0;
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar == 0)
	{
		// Ahora recibimos la petici?n
		ret=read(sock_conn, peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		
		printf ("Peticion: %s\n",peticion);
		
		// vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		// Ya tenemos el c?digo de la petici?n
		
		
		if (codigo ==0) //petici?n de desconexi?n
		{
			p = strtok( NULL, "/");
			char nombre[20];
			strcpy (nombre, p);
			pthread_mutex_lock(&mutex);
			DesconectarUsuario(&nombre, &Lista);
			pthread_mutex_unlock(&mutex);
			char notificacion[20];
			DevuelveConectados(notificacion, &Lista);
			int j;
			for(j=0;j<i;j++)
			{
				write(sockets[j],notificacion,strlen(notificacion));
			}
			//terminar=1;
		}
		
		if (codigo ==1) //Iniciar Sesi￳n
		{
			p = strtok( NULL, "/");
			char nombre[20];
			strcpy (nombre, p);
			p = strtok( NULL, "/");
			char contra[20];
			pthread_mutex_lock(&mutex);
			strcpy (contra, p);
			printf ("Codigo: %d, Nombre: %s, Contrase\ufff1a:%s\n", codigo, nombre, contra);
			sprintf(buff, "1/%d", (IniciarSesion(nombre, contra,socket)));
			write (sock_conn, buff, strlen(buff));
			pthread_mutex_unlock(&mutex);
			char notificacion[20];
			DevuelveConectados(notificacion, &Lista);
			int j;
			for(j=0;j<i;j++)
			{
				write(sockets[j],notificacion,strlen(notificacion));
			}
		}
		
		if (codigo ==2) //Registrar usuario
		{
			p = strtok( NULL, "/");
			char nombre[20];
			strcpy (nombre, p);
			p = strtok( NULL, "/");
			char contra[20];
			strcpy (contra, p);
			printf ("Codigo: %d, Nombre: %s, Contrase\ufff1a:%s\n", codigo, nombre, contra);
			if (Registrar(nombre, contra)==0)
				strcpy(buff2, "2/El usuario ha sido registrado");
			else
				strcpy(buff2, "2/El usuario no ha sido registrado");
			write (sock_conn, buff2, strlen(buff2));
		}
		
		if (codigo ==3) //Piden maximo
		{
			p = strtok( NULL, "/");
			sprintf(buff2, "3/%d", PideMaximo());
			write (sock_conn,buff2,strlen(buff2));
		}
		if (codigo ==4) //Piden minimo
		{
			p = strtok( NULL, "/");
			sprintf(buff2, "4/%d", PideMinimo());
			write (sock_conn,buff2,strlen(buff2));
		}
		/*		if (codigo ==5) *///Piden codigo miguel dan fecha
		/*		{*/
		/*			p = strtok( NULL, "\0");*/
		/*			char fecha[11];*/
		/*			strcpy(fecha,p);*/
		/*			char respuesta[50];*/
		/*			ConsultaFecha(fecha, respuesta);*/
		/*			printf(respuesta);*/
		/*			strcpy(buff2, respuesta);*/
		/*			write (sock_conn,buff2,strlen(buff2));*/
		/*		}*/
		if (codigo ==5) //Piden codigo miguel dan fecha
		{
			p = strtok( NULL, "\0");
			char fecha[11];
			strcpy(fecha,p);
			ConsultaFecha(&fecha, &buff2);
			write (sock_conn,buff2,strlen(buff2));
		}
		if (codigo ==6) //Piden codigo Uriel dan nombre
		{
			p = strtok( NULL, "\0");
			char nombre[20];
			strcpy(nombre,p);
			sprintf(buff2, "6/%d", TiempoMedio(nombre));
			write (sock_conn,buff2,strlen(buff2));
		}
	}
}



int main(int argc, char *argv[])
{
	conn = mysql_init(NULL);
	if (conn==NULL)
	{
		printf ("Error al crear la conexi\uffc3\uffc2\uffb3n: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "BBDDjuego", 0, NULL, 0);
	if (conn==NULL)
	{
		printf ("Error al inicializar la conexi\uffc3\uffc2\uffb3n: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9050);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 20) < 0)
		printf("Error en el Listen");
	
	pthread_t thread;
	// Bucle para atender a clientes "infinitos" (100 debido al n￯﾿ﾺmero de threads)
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		printf ("%d", sockets[i]);
		i = i+1;
		
	}
}
