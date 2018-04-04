namespace UnitTestingExercise.BubbleSort
{
    public static class Bubble
    {
        public static void BubbleSort(int[] arr)
        {
            bool hasSwapped = true;
            while (hasSwapped)
            {
                hasSwapped = false;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int tmp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = tmp;

                        hasSwapped = true;
                    }
                }
            }
        }
    }
}
