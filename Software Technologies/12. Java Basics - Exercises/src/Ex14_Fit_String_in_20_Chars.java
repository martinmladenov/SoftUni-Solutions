import java.util.Scanner;

public class Ex14_Fit_String_in_20_Chars {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String str = scanner.nextLine();
        char[] arr = new char[20];
        for (int i = 0; i < 20; i++) {
            if (i < str.length())
                arr[i] = (str.charAt(i));
            else
                arr[i] = '*';
        }
        System.out.println(new String(arr));
    }
}
