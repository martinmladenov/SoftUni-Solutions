import java.util.Scanner;

public class Ex05_Integer_to_Hex_and_Binary {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int i = scanner.nextInt();
        System.out.println(Integer.toHexString(i).toUpperCase());
        System.out.println(Integer.toBinaryString(i));
    }
}
