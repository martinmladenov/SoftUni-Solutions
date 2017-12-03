import java.util.Arrays;
import java.util.Scanner;

public class Ex06_Compare_Char_Arrays {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Character[] arr1 = Arrays.stream(scanner.nextLine().split(" "))
                .map(s -> s.charAt(0))
                .toArray(Character[]::new);
        Character[] arr2 = Arrays.stream(scanner.nextLine().split(" "))
                .map(s -> s.charAt(0))
                .toArray(Character[]::new);
        int first = 0;
        for (int i = 0; i < Math.min(arr1.length, arr2.length) && first == 0; i++) {
            if (arr1[i] != arr2[i])
                first = (arr1[i] - arr2[i] < 0 ? 1 : 2);
        }
        if (first == 0) {
            first = (arr1.length - arr2.length < 0 ? 1 : 2);
        }

        if (first == 1) {
            printArray(arr1);
            printArray(arr2);
        }
        if (first == 2) {
            printArray(arr2);
            printArray(arr1);
        }
    }

    private static void printArray(Character[] arr) {
        for (char c : arr)
            System.out.print(c);
        System.out.println();
    }
}
