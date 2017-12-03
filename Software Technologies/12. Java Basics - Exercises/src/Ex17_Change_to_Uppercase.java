import java.util.Scanner;

public class Ex17_Change_to_Uppercase {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String text = scanner.nextLine();
        while (text.contains("<upcase>")) {
            int start = text.indexOf("<upcase>");
            int end = text.indexOf("</upcase>");
            text = text.substring(0, start)
                    + text.substring(start + 8, end).toUpperCase()
                    + text.substring(end + 9);
        }
        System.out.println(text);
    }
}
