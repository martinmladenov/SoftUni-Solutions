import java.util.Arrays;
import java.util.Comparator;
import java.util.Scanner;

public class Ex06_Largest_3_Numbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        Integer[] arr = Arrays.stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .boxed()
                .toArray(Integer[]::new);
        Arrays.sort(arr, Comparator.reverseOrder());
        for (int i : Arrays.stream(arr).limit(3).toArray(Integer[]::new))
            System.out.println(i);
    }
}
