import java.util.Arrays;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Ex09_Most_Frequent_Number {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] arr = Arrays.stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();
        LinkedHashMap<Integer, Integer> occurrences = new LinkedHashMap<>();
        for (int i : arr) {
            if (occurrences.containsKey(i))
                occurrences.put(i, occurrences.get(i) + 1);
            else
                occurrences.put(i, 1);
        }
        int maxOccurrences = 0;
        int maxInt = 0;
        for (Map.Entry<Integer, Integer> entry : occurrences.entrySet())
            if (maxOccurrences < entry.getValue()) {
                maxInt = entry.getKey();
                maxOccurrences = entry.getValue();
            }
        System.out.println(maxInt);
    }
}
