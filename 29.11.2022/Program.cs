namespace task_5;

public class Task5
{
    public static void Main(string[] args)
    {
        StringHexPositionSort s = new StringHexPositionSort();
        string[] arr = { "AF3", "120", "236", "11A", "23", "5", "FFFFF" };
        try
        {
        s.Sort(arr, 5);
            if (arr[0] == "5"
                && arr[1] == "23"
                && arr[2] == "11A"
                && arr[3] == "120"
                && arr[4] == "236"
                && arr[5] == "AF3"
               )
            {
                Console.WriteLine("Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
        }
        catch
        {
            Console.WriteLine("Test failed");
        }
    }
    //Cwiczenie 1
    //Zaimplementuj klasę do sortowania pozycyjnego liczb szesnastkowych zapisanych w łańcuchach 
    //Przykładowa tablica do posortowania
    //string[] HexNumbers = {"AF3", "12D", "236", "120", "1"};
    //talica po posortowania
    //{"1", "120", "12D", "236", "AF3"}
    //Można założyć, że
    //- w tablicy są poprawne łańcuchy z liczbami szestastkowymi
    //- łańcuchy mają różną długość 
    //Możesz wzorować się na gotowym algorytmie w instrukcji nr 5

    public class StringHexPositionSort
    {
        //Zadeklaruj tablicę kolejek dla każdej cyfry szesnastkowej
        //Każda kolejka jest typu string lub char
        //Wykorzystaj klasę Queue<string> lub Queue<char>
        //Możesz zadeklarować tablicę 16 kolejek Queueu<string>[] lub słownik Dictionary<String, Queue<String>>
        //w którym kluczem jest łańcuch z jednym znakiem - cyfrą szesnastkową.
        private Queue<string>[] _hexNumbers = new Queue<string>[16];
        private void Init()
        {
            //zaimplementuj zainicjowanie tablicy lub słownika kolejek
            for (int i = 0; i < 16; i++)
            {
                if (_hexNumbers[i] == null)
                {
                    _hexNumbers[i] = new Queue<string>();
                }
                else
                {
                    _hexNumbers[i].Clear();
                }
            }
        }

        private void Dequeue(string[] arr)
        {
            //zaimplementuje pobieranie z kolejek łańcuchów hex i umieszczanie ich w tablicy arr
            //kolejki opróżniamy zaczynając od kolejki z cyfrą 0 a kończąc na F 
            int index = 0;
            foreach(var hex in _hexNumbers)
            {
                while (hex.Count > 0)
                {
                    arr[index] = hex.Dequeue();
                    index++;
                }
            }

        }

        //Zaimplementuj metodę pomocniczą, aby zwracała liczbę równą cyfrze szesnastkowej na podanej pozycji (position) w łańcuchu str
        //Pozycja jest numerowana od prawej do lewej
        // np. dla łańcucha "AB12"
        // cyfra na pozycji 0 to 2,
        // cyfra na pozycji 2 to 11,
        // cyfra na pozycji 8 to 0
        //Stosowanie tej metody uprości definicję metody Enqueue
        private int ExtractDigit(string str, uint position)
        {
            if (str.Length <= position - 1)
                return 0;          
            else
                return int.Parse(str[(int)(str.Length - position)] + "", System.Globalization.NumberStyles.HexNumber);


        }

        /// <summary>
        ///Zaimplementuj umieszczanie cyfr łacuchów hex z arr w kolejce odpowiadającej pozycji tej cyfry 
        /// </summary>
        /// <param name="arr">tablica sortowanych łańcuchów hex</param>
        /// <param name="position">pozycja cyfry hex wzlgędem, której sortujemy łańcuchy</param>
        private void Enqueue(string[] arr, uint position)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int digit = ExtractDigit(arr[i], position);
                _hexNumbers[digit].Enqueue(arr[i]);
            }
        }

        //Tej metody nie zmieniaj!!!
        public void Sort(string[] arr, int d)
        {
            Init();
            for (uint position = 0; position < d; position++)
            {
                Enqueue(arr, position);
                Dequeue(arr);
            }
        }
    }
}