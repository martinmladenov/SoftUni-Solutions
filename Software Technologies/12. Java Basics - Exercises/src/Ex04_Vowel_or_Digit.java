import java.util.Scanner;

public class Ex04_Vowel_or_Digit {
    public static void main(String[] args) {
        char c = new Scanner(System.in).nextLine().charAt(0);
        if (c >= '0' && c <= '9')
            System.out.println("digit");
        else if (c == 'a' ||
                c == 'e' ||
                c == 'o' ||
                c == 'u' ||
                c == 'i')
            System.out.println("vowel");
        else
            System.out.println("other");
    }
}
