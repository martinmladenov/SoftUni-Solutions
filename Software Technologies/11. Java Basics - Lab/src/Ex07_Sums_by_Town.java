import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Ex07_Sums_by_Town {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = Integer.parseInt(scan.nextLine());
        Map<String, Double> towns = new TreeMap<>();
        for (int i = 0; i < n; i++) {
            String[] spl = scan.nextLine().split("\\|");
            String townName = spl[0].trim();
            double income = Double.parseDouble(spl[1].trim());
            if (towns.containsKey(townName))
                towns.put(townName, towns.get(townName) + income);
            else
                towns.put(townName, income);
        }

        for (Map.Entry<String, Double> town : towns.entrySet()) {
            System.out.println(town.getKey() + " -> " + town.getValue());
        }
    }
}
