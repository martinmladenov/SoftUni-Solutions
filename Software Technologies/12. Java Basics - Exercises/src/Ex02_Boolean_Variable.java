import java.util.Scanner;

public class Ex02_Boolean_Variable {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        boolean b = Boolean.parseBoolean(scanner.nextLine());
        System.out.println(b ? "Yes" : "No");
    }
}
