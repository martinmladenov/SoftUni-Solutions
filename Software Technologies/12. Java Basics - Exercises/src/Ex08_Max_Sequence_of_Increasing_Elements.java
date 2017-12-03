import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class Ex08_Max_Sequence_of_Increasing_Elements {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] arr = Arrays.stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();
        int longestLength = 0;
        int lastInt = 0;
        int lastLength = 0;
        ArrayList<Integer> longestSequence = new ArrayList<>();
        for (int index = 0; index < arr.length; index++) {
            int i = arr[index];
            if (lastInt < i) {
                lastLength++;
            } else {
                lastLength = 1;
            }
            lastInt = i;
            if (lastLength <= longestLength) continue;
            longestLength = lastLength;
            longestSequence.clear();
            for (int j = index - lastLength + 1; j <= index; j++) {
                longestSequence.add(arr[j]);
            }
        }
        for (int i : longestSequence)
            System.out.print(i + " ");
    }
}
