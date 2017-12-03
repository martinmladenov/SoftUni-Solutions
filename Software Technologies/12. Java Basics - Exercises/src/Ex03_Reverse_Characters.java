import java.util.Scanner;

public class Ex03_Reverse_Characters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        char[] arr = new char[3];
        for (int i = 0; i < 3; i++) {
            arr[i] = scanner.nextLine().charAt(0);
        }

        for (int i = 2; i >= 0; i--) {
            System.out.print(arr[i]);
        }
    }
}
