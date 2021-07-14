using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMergeSort
{
    class Program
    {

        static void Main(string[] args)
        {
            // ilk olarak sıralanmasını istediğimiz bir dizi giriyoruz.
            // Girilen dizi, farkı görmek için; ilk olarak printArray ile girilen ilk haliyle ekrana yazılmaktadır.
            // Daha sonra girilen dizi sort fonksiyonuna gönderilir. ilk olarak dizi daha sonra dizi elemanlarının sayısını basıyoruz.
            // en sonunda sort algoritması uygulanıp, sıralama yapılır ve ekrana yazılır.
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            Console.WriteLine("Verilen Dizi");
            printArray(arr);
            sort(arr, 0, arr.Length - 1);
            Console.WriteLine("\nSorted Algoritması sonrası");
            printArray(arr);


            Console.ReadKey();
        }

        // Aşağıda dizinin, iki alt dizini birleştiriyoruz.
        // ilk alt dizi l-m şeklinde olup ikinci alt dizi m+1 den r ye kadardır.
        static void merge(int[] arr, int l, int m, int r)
        {
            // iki boyutu bulup birleştirilecek dizileri hazırlıyoruz.
            int n1 = m - l + 1;
            int n2 = r - m;

            // Geçici olarak diziler oluşturuyoruz.Sonrasında kopyalama yapacağız.
            
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Verileri geçici dizilere for döngüsünü kullanarak aktarıyoruz.
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Geçici dizileri birleştiriyoruz. İlk olarak ilk dizi sonrasında ikincil diziden başlıyoruz.
            i = 0;
            j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            //L var ise kalan elemanları kopyalıyoruz.
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            //R var ise kalan elemanları kopyalıyoruz.
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Burası ana fonksiyondur. l-r den birleştirme yaparak sıralar.
        static void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // orta değeri buluyoruz.
                int m = l + (r - l) / 2;

                // Bulduktan sonra sıralıyoruz.
                sort(arr, l, m);
                sort(arr, m + 1, r);

                // Birleştirme işlemini yapıyoruz.
                merge(arr, l, m, r);
            }
        }


        // N boyuttaki dizileri ekrana yazdırmak için yardımcı olan fonksiyonumuz.
        static void printArray(int[] arr)
        {
            // n içerisinde arr içerisinde ki elemanların sayısını at.
            int n = arr.Length;
            // for ile bir o kadar dön ve ekrana yazdır.
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

    }

}
