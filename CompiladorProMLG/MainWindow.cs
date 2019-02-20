using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiladorProMLG
{
    public partial class MainWindow : Form
    {
        CompiAAlgorithms CompAlgorithms;
        string StrAnalisis;
        public MainWindow()
        {
            CompAlgorithms = new CompiAAlgorithms();
            InitializeComponent();
        }

        private void EpsilonBtn_Click(object sender, EventArgs e)
        {
            int CaretPos = inputGram.SelectionStart;
            string txt1 = inputGram.Text.Substring(0, inputGram.SelectionStart);
            txt1 += "Ɛ";
            string txt2 = inputGram.Text.Substring(CaretPos, inputGram.Text.Length - CaretPos);
            inputGram.Text = txt1 + txt2;

            inputGram.Select(CaretPos + 1, 0);
            inputGram.ScrollToCaret();
            inputGram.Focus();
        }

        private void PrintDiccionario(Dictionary<string, List<string>> DicImprimir)
        {
            inputResult.Text = "";
            foreach (var iterator in DicImprimir)
            {
                inputResult.Text += iterator.Key + "  ==> { ";
                foreach (var item in iterator.Value)
                {
                    if (item != iterator.Value.Last())
                        inputResult.Text += item + ", ";
                    else
                        inputResult.Text += item + " } \n";
                }
            }
        }
        private void PrintTablaDeEstados(List<List<ElementoLr1>> C, Dictionary<string, Dictionary<int, int>> TablaEdos)
        {
            inputResult.Text = "";
            int counter = 0;
            foreach (var itemC in C)
            {
                inputResult.Text += "[" + counter + "] = { " ;
                foreach (var item in itemC)
                {
                    if (item != itemC.Last())
                        inputResult.Text += item + ", ";
                    else
                        inputResult.Text += item + " } \n";
                }
                counter++;
            }
        }

        private void PrintTablaDeAcciones(Dictionary<int, Dictionary<string, string>> Accion, Dictionary<string, List<string>> DiccioLR, List<string> sg)
        {

        }

        private void AnalizarBtn_Click(object sender, EventArgs e)
        {
            CompAlgorithms.UpdateAnalizador(inputGram.Text);
            PrintDiccionario(CompAlgorithms.DiccioAnalizador);
        }

        private void PrimerosBtn_Click(object sender, EventArgs e)
        {
            CompAlgorithms.UpdateAnalizador(inputGram.Text);
            CompAlgorithms.UpdatePrimero();
            PrintDiccionario(CompAlgorithms.DiccioPrimeros);
        }

        private void SiguienteBtn_Click(object sender, EventArgs e)
        {
            CompAlgorithms.UpdateAnalizador(inputGram.Text);
            CompAlgorithms.UpdatePrimero();
            CompAlgorithms.UpdateSiguiente();
            PrintDiccionario(CompAlgorithms.DiccioSiguiente);
        }

        private void Lr1TablaBtn_Click(object sender, EventArgs e)
        {

            CompAlgorithms.UpdateAnalizador(inputGram.Text);
            CompAlgorithms.UpdatePrimero();
            CompAlgorithms.UpdateSiguiente();
            CompAlgorithms.UpdateLr1Automata();
            PrintTablaDeEstados(CompAlgorithms.C, CompAlgorithms.TablaDeEstados);
        }

        private void Lr1Btn_Click(object sender, EventArgs e)
        {
            CompAlgorithms.UpdateAnalizador(inputGram.Text);
            CompAlgorithms.UpdatePrimero();
            CompAlgorithms.UpdateSiguiente();
            CompAlgorithms.UpdateLr1Automata();
            StrAnalisis = StringAnalisis.Text;
            bool result = CompAlgorithms.GeneraTablaLR1();
            if (!result)
                CompAlgorithms.UpdateAaslr(CompAlgorithms.Accion, StrAnalisis + "$");
            else
            {
                CompAlgorithms.DiccioLR1.Clear();
                CompAlgorithms.DiccioLR1.Add("La gramatica no es LR", new List<string>() { "." });
            }
            PrintTablaDeAcciones(CompAlgorithms.Accion, CompAlgorithms.DiccioLR1, CompAlgorithms.sg); 
        }
        private void LalrTablaBtn_Click(object sender, EventArgs e)
        {
            CompAlgorithms.UpdateAnalizador(inputGram.Text);
            CompAlgorithms.UpdatePrimero();
            CompAlgorithms.UpdateSiguiente();
            CompAlgorithms.UpdateLr1Automata();
            CompAlgorithms.TransformToLALR();
            PrintTablaDeEstados(CompAlgorithms.C, CompAlgorithms.TablaDeEstados);
        }

        private void LalrBtn_Click(object sender, EventArgs e)
        {
            CompAlgorithms.UpdateAnalizador(inputGram.Text);
            CompAlgorithms.UpdatePrimero();
            CompAlgorithms.UpdateSiguiente();
            CompAlgorithms.UpdateLr1Automata();
            CompAlgorithms.TransformToLALR();
            StrAnalisis = StringAnalisis.Text;
            bool result = CompAlgorithms.GeneraTablaLR1();
            if (!result)
                CompAlgorithms.UpdateAaslr(CompAlgorithms.Accion, StrAnalisis + "$");
            else
            {
                CompAlgorithms.DiccioLR1.Clear();
                CompAlgorithms.DiccioLR1.Add("La gramatica no es LR", new List<string>() { "." });
            }
            PrintTablaDeAcciones(CompAlgorithms.Accion, CompAlgorithms.DiccioLR1, CompAlgorithms.sg);
        }
    }
}
