using System;

namespace AnaliseOrdenacaoWPF.Algoritmos
{
    public static class BubbleSort
    {
        public static int[] Ordenar(int[] dados)
        {
            int[] arr = (int[])dados.Clone(); // importante! não mexe no array original

            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // troca
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }

            return arr;
        }
    }
}
