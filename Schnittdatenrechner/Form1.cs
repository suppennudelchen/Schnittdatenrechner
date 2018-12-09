using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schnittdatenrechner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //hiermit kann man den Berechnen Knopf Ein und ausschalten
        //in den Eigenschaften der Label unter TextChanged die Methode aufrufen
        private void txtEingabe_TextChanged(object sender, EventArgs e)
        {
            if (textBoxVc.Text != "" && textBoxDm.Text != "")
            {
                btnBerechnen.Enabled = true;
            }
            else
            {
                btnBerechnen.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Die Textboxen bei Klicken des Clear Button leeren
            textBoxVc.Text = ("");
            textBoxDm.Text = ("");
            textBoxDrehz.Text = ("");
            lblAusgabe.Text = "";
        }

        private void btnBerechnen_Click(object sender, EventArgs e)
        {
            double schnittGeschwindigkeit;
            double werkzeugDurchmesser;
            double drehzahl;

            // Eingabe mit try catch prüfen
            try
            {
                //wenn ok, dann wird berechnet
                lblAusgabe.Text = "";
                schnittGeschwindigkeit = Convert.ToDouble(textBoxVc.Text);
                werkzeugDurchmesser = Convert.ToDouble(textBoxDm.Text);
                drehzahl = (schnittGeschwindigkeit * 1000) / (werkzeugDurchmesser * 3.141);
                drehzahl = Convert.ToInt32(drehzahl);
                textBoxDrehz.Text = Convert.ToString(drehzahl);
            }
            catch (FormatException)
            {
                lblAusgabe.Text = "Falsches Eingabeformat";
                textBoxVc.Text = ("");
                textBoxDm.Text = ("");
                textBoxDrehz.Text = ("");
            }
            catch (Exception)
            {
                lblAusgabe.Text = "Fehler: Eingaben prüfen";
                textBoxVc.Text = ("");
                textBoxDm.Text = ("");
                textBoxDrehz.Text = ("");
            }
        }
    }
}
