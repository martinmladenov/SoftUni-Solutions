import java.util.Arrays;
import java.util.Scanner;

public class Ex11_Equal_Sums {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[] arr = Arrays.stream(scanner.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();
        for (int i = 0; i < arr.length; i++) {
            int leftSum = Arrays.stream(arr).limit(i).sum();
            int rightSum = Arrays.stream(arr).skip(i + 1).sum();
            if (leftSum == rightSum) {
                System.out.println(i);
                return;
            }
        }
        System.out.println("no");
    }
}
