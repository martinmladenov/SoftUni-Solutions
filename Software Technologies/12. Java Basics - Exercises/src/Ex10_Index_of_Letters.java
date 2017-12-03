import java.util.Scanner;

public class Ex10_Index_of_Letters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String str = scanner.nextLine();
        for (char c : str.toCharArray())
            System.out.printf("%s -> %d\r\n", c, c - 'a');
    }
}
