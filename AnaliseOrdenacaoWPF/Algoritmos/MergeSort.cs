using System;

namespace AnaliseOrdenacaoWPF.Algoritmos
{
    public static class MergeSort
    {
        public static int[] Ordenar(int[] dados)
        {
            int[] arr = (int[])dados.Clone();
            MergeSortRec(arr, 0, arr.Length - 1);
            return arr;
        }

        private static void MergeSortRec(int[] arr, int inicio, int fim)
        {
            if (inicio >= fim)
                return;

            int meio = (inicio + fim) / 2;

            // divide
            MergeSortRec(arr, inicio, meio);
            MergeSortRec(arr, meio + 1, fim);

            // conquista (merge)
            Merge(arr, inicio, meio, fim);
        }

        private static void Merge(int[] arr, int inicio, int meio, int fim)
        {
            int tamanhoEsq = meio - inicio + 1;
            int tamanhoDir = fim - meio;

            int[] esquerda = new int[tamanhoEsq];
            int[] direita = new int[tamanhoDir];

            Array.Copy(arr, inicio, esquerda, 0, tamanhoEsq);
            Array.Copy(arr, meio + 1, direita, 0, tamanhoDir);

            int i = 0, j = 0, k = inicio;

            // junta ordenado
            while (i < tamanhoEsq && j < tamanhoDir)
            {
                if (esquerda[i] <= direita[j])
                {
                    arr[k++] = esquerda[i++];
                }
                else
                {
                    arr[k++] = direita[j++];
                }
            }

            // copia o que sobrar
            while (i < tamanhoEsq)
                arr[k++] = esquerda[i++];

            while (j < tamanhoDir)
                arr[k++] = direita[j++];
        }
    }
}
