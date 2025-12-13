using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using AnaliseOrdenacaoWPF.Algoritmos;

namespace AnaliseOrdenacaoWPF
{
    public partial class MainWindow : Window
    {
        int[] dados;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSelecionarArquivo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Arquivos de texto (*.txt)|*.txt";

            if (dialog.ShowDialog() == true)
            {
                string[] linhas = File.ReadAllLines(dialog.FileName);
                dados = linhas.Select(int.Parse).ToArray();

                listaDados.ItemsSource = dados;
            }
        }

        private void btnGerarDados_Click(object sender, RoutedEventArgs e)
        {
            Random rd = new Random();
            dados = Enumerable.Range(0, 10000) // 10 mil números
                              .Select(x => rd.Next(0, 100000))
                              .ToArray();

            listaDados.ItemsSource = dados;
        }


        private void btnInserirManual_Click(object sender, RoutedEventArgs e)
        {
            string entrada = Microsoft.VisualBasic.Interaction.InputBox(
                "Digite valores separados por espaço ou vírgula:",
                "Entrada Manual");

            dados = entrada
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            listaDados.ItemsSource = dados;
        }


        private void btnOrdenar_Click(object sender, RoutedEventArgs e)
        {
            if (dados == null || dados.Length == 0)
            {
                MessageBox.Show("Nenhum dado carregado!");
                return;
            }

            Stopwatch sw = new Stopwatch();

            // Bubble Sort
            sw.Restart();
            var bubble = BubbleSort.Ordenar(dados);
            sw.Stop();
            double tempoBubble = sw.Elapsed.TotalMilliseconds;

            // Quick Sort
            sw.Restart();
            var quick = QuickSort.Ordenar(dados);
            sw.Stop();
            double tempoQuick = sw.Elapsed.TotalMilliseconds;

            // Merge Sort
            sw.Restart();
            var merge = MergeSort.Ordenar(dados);
            sw.Stop();
            double tempoMerge = sw.Elapsed.TotalMilliseconds;

            // Mostrar resultado ordenado
            listaOrdenada.ItemsSource = merge;

            // Mostrar tempos
            txtResultado.Text =
                $"Bubble Sort: {tempoBubble:F4} ms\n" +
                $"Quick Sort:  {tempoQuick:F4} ms\n" +
                $"Merge Sort:  {tempoMerge:F4} ms";
        }


    }
}
