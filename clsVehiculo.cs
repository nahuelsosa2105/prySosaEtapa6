using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySosaEtapa6
{
    internal class clsVehiculo
    {
        public PictureBox pctAuto;
        public PictureBox pctAvion;
        public PictureBox pctBarco;
        public string tipoVehiculo;


        public void CrearAuto()
        {
            pctAuto = new PictureBox();
            pctAuto.SizeMode = PictureBoxSizeMode.StretchImage;
            pctAuto.Width = 100;
            pctAuto.Height = 100;
            pctAuto.BackColor = Color.Transparent;
            string rutaImagen = Path.Combine(Application.StartupPath, "..", "..", "Resources", "F1RedBullAnimado.png");
            pctAuto.ImageLocation = rutaImagen;
            tipoVehiculo = "Formula 1";
        }

        public void CrearAvion()
        {
            pctAvion = new PictureBox();
            pctAvion.SizeMode = PictureBoxSizeMode.StretchImage;
            pctAvion.Width = 200;
            pctAvion.Height = 200;
            pctAvion.BackColor = Color.Transparent;
            string rutaImagen = Path.Combine(Application.StartupPath, "..", "..", "Resources", "Avion2daGuerra.png");
            pctAvion.ImageLocation = rutaImagen;
            tipoVehiculo = "Avión";
        }

        public void CrearBarco()
        {
            pctBarco = new PictureBox();
            pctBarco.SizeMode = PictureBoxSizeMode.StretchImage;
            pctBarco.Width = 200;
            pctBarco.Height = 200;
            pctBarco.BackColor = Color.Transparent;
            string rutaImagen = Path.Combine(Application.StartupPath, "..", "..", "Resources", "Holandes errante barco.png");
            pctBarco.ImageLocation = rutaImagen;
            tipoVehiculo = "Holandes Errante";
        }


    }
}
