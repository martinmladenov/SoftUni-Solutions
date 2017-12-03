import java.util.Arrays;
import java.util.Scanner;

public class Ex07_Max_Sequence_of_Equal_Elements {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] arr = Arrays.stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();
        int longestInt = 0;
        int longestLength = 0;
        int lastInt = 0;
        int lastLength = 0;
        for (int i : arr) {
            if (lastInt == i) {
                lastLength++;
            } else {
                lastInt = i;
                lastLength = 1;
            }
            if (lastLength <= longestLength) continue;
            longestLength = lastLength;
            longestInt = i;
        }
        for (int i = 0; i < longestLength; i++) {
            System.out.print(longestInt + " ");

        }
    }
}
