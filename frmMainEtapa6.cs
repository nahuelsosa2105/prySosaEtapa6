using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySosaEtapa6
{
    public partial class frmMainEtapa6 : Form
    {
        public frmMainEtapa6()
        {
            InitializeComponent();
        }

        clsVehiculo objAuto = new clsVehiculo();
        clsVehiculo objAvion = new clsVehiculo();
        clsVehiculo objBarco = new clsVehiculo();

        List<clsVehiculo> listaVehiculos = new List<clsVehiculo>();

        private void frmMainEtapa6_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                clsVehiculo nuevoVehiculo = new clsVehiculo();

                // Crear un auto en cada iteración del bucle
                nuevoVehiculo.CrearAuto();

                int posicionX, posicionY;
                bool superpuesto;

                do
                {
                    // Generar una posición aleatoria dentro del formulario para el eje X
                    posicionX = random.Next(0, this.ClientSize.Width - nuevoVehiculo.pctAuto.Width);

                    // Generar una posición aleatoria dentro del formulario para el eje Y
                    posicionY = random.Next(0, this.ClientSize.Height - nuevoVehiculo.pctAuto.Height);

                    superpuesto = false;

                    // Verificar si la nueva posición se superpone con las posiciones de los vehículos existentes
                    foreach (clsVehiculo vehiculoExistente in listaVehiculos)
                    {
                        if (Math.Abs(posicionX - vehiculoExistente.pctAuto.Location.X) < nuevoVehiculo.pctAuto.Width &&
                            Math.Abs(posicionY - vehiculoExistente.pctAuto.Location.Y) < nuevoVehiculo.pctAuto.Height)
                        {
                            superpuesto = true;
                            break;
                        }
                    }
                }
                while (superpuesto);

                // Asignar la posición al vehículo y agregarlo a la lista de vehículos
                nuevoVehiculo.pctAuto.Location = new Point(posicionX, posicionY);
                listaVehiculos.Add(nuevoVehiculo);

                // Mostrar el vehículo en el formulario
                Controls.Add(nuevoVehiculo.pctAuto);
            }
        }

        private void btnMover_Click(object sender, EventArgs e)
        {
            tmrMovimiento.Start();
        }

        private void tmrMovimiento_Tick(object sender, EventArgs e)
        {
            Random random = new Random();

            foreach (clsVehiculo vehiculo in listaVehiculos.ToList())
            {
                // Genera un desplazamiento aleatorio en ambas direcciones
                int desplazamientoX = random.Next(-40, 41); 
                int desplazamientoY = random.Next(-40, 41); 

                // Actualiza la posición del vehículo
                int nuevaPosX = vehiculo.pctAuto.Location.X + desplazamientoX;
                int nuevaPosY = vehiculo.pctAuto.Location.Y + desplazamientoY;

                // Verifica si el vehículo está dentro de los límites del formulario
                if (nuevaPosX < 0)
                    nuevaPosX = 0;
                else if (nuevaPosX > this.ClientSize.Width - vehiculo.pctAuto.Width)
                    nuevaPosX = this.ClientSize.Width - vehiculo.pctAuto.Width;

                if (nuevaPosY < 0)
                    nuevaPosY = 0;
                else if (nuevaPosY > this.ClientSize.Height - vehiculo.pctAuto.Height)
                    nuevaPosY = this.ClientSize.Height - vehiculo.pctAuto.Height;

                vehiculo.pctAuto.Location = new Point(nuevaPosX, nuevaPosY);

                // Verifica las colisiones con otros vehículos
                foreach (clsVehiculo otroVehiculo in listaVehiculos.ToList())
                {
                    if (otroVehiculo != vehiculo && vehiculo.pctAuto.Bounds.IntersectsWith(otroVehiculo.pctAuto.Bounds))
                    {
                        // Elimina los vehículos involucrados de la lista y del formulario
                        listaVehiculos.Remove(vehiculo);
                        listaVehiculos.Remove(otroVehiculo);
                        Controls.Remove(vehiculo.pctAuto);
                        Controls.Remove(otroVehiculo.pctAuto);
                        break; // Sal del bucle interior después de eliminar los vehículos
                    }
                }
            }
        }
    }
}
