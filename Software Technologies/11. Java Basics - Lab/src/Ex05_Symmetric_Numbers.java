import java.util.Scanner;

public class Ex05_Symmetric_Numbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = scan.nextInt();
        for (int i = 1; i <= n; i++) {
            if (isSymmetric(i))
                System.out.println(i);
        }
    }

    private static boolean isSymmetric(int n) {
        char[] arr = ("" + n).toCharArray();
        for (int i = 0; i < arr.length / 2; i++) {
            if (arr[i] != arr[arr.length - 1 - i])
                return false;
        }
        return true;
    }
}
