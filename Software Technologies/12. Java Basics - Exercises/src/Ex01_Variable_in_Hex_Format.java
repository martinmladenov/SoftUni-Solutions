import java.util.Scanner;

public class Ex01_Variable_in_Hex_Format {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int num = Integer.parseInt(scanner.nextLine(), 16);
        System.out.println(num);
    }
}
