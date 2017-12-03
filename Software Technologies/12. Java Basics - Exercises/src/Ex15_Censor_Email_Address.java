import java.util.Arrays;
import java.util.Scanner;

public class Ex15_Censor_Email_Address {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String email = scanner.nextLine();
        String[] emailParts = email.split("@");
        char[] stars = new char[emailParts[0].length()];
        Arrays.fill(stars, '*');
        String censored = new String(stars) + "@" + emailParts[1];
        String text = scanner.nextLine();
        text = text.replaceAll(email, censored);
        System.out.println(text);
    }
}
