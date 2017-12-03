import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Ex19_Phonebook_Upgrade {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        TreeMap<String, String> map = new TreeMap<>();
        String input;
        while (!(input = scan.nextLine()).equals("END")) {
            String[] split = input.split(" ");
            if (split[0].equals("A")) {
                map.put(split[1], split[2]);
            } else if (split[0].equals("S")) {
                if (map.containsKey(split[1]))
                    System.out.printf("%s -> %s\r\n", split[1], map.get(split[1]));
                else
                    System.out.printf("Contact %s does not exist.\r\n", split[1]);
            } else if (split[0].equals("ListAll")) {
                for (Map.Entry<String, String> entry : map.entrySet()) {
                    System.out.printf("%s -> %s\r\n", entry.getKey(), entry.getValue());
                }
            }
        }
    }
}
