import java.util.Arrays;
import java.util.Scanner;

public class Ex03_3_Integers_Sum {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] arr = Arrays.stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt).toArray();
        int a = arr[0], b = arr[1], c = arr[2];

        if (a + b == c)
            System.out.println(Math.min(a, b) + " + " +
                    Math.max(a, b) + " = " + c);
        else if (a + c == b)
            System.out.println(Math.min(a, c) + " + " +
                    Math.max(a, c) + " = " + b);
        else if (c + b == a)
            System.out.println(Math.min(c, b) + " + " +
                    Math.max(c, b) + " = " + a);
        else System.out.println("No");
    }
}
