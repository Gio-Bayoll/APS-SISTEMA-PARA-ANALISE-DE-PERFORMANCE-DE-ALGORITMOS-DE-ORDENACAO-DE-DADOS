using System;

namespace AnaliseOrdenacaoWPF.Algoritmos
{
    public static class QuickSort
    {
        public static int[] Ordenar(int[] dados)
        {
            int[] arr = (int[])dados.Clone();
            Quick(arr, 0, arr.Length - 1);
            return arr;
        }

        private static void Quick(int[] arr, int inicio, int fim)
        {
            if (inicio >= fim) return;

            int p = Particionar(arr, inicio, fim);

            Quick(arr, inicio, p - 1);
            Quick(arr, p + 1, fim);
        }

        private static int Particionar(int[] arr, int inicio, int fim)
        {
            int pivo = arr[fim];
            int i = inicio;

            for (int j = inicio; j < fim; j++)
            {
                if (arr[j] < pivo)
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                    i++;
                }
            }

            (arr[i], arr[fim]) = (arr[fim], arr[i]);
            return i;
        }
    }
}
