import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class Ex12_Bomb_Numbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        List<Integer> list = new ArrayList<>(Arrays.asList(Arrays.stream(scan.nextLine().split(" "))
                .map(Integer::valueOf)
                .toArray(Integer[]::new)));
        String[] numbers = scan.nextLine().split(" ");
        int bombNumber = Integer.parseInt(numbers[0]);
        int power = Integer.parseInt(numbers[1]);
        for (int i = 0; i < list.size(); i++) {
            if (list.get(i) != bombNumber) continue;
            int startPos = Math.max(i - power, 0);
            List<Integer> oldList = list;
            list = oldList.subList(0, startPos);
            list.addAll(oldList.subList(Math.min(oldList.size(), i + power + 1), oldList.size()));
            i = startPos - 1;
        }
        System.out.println(list.stream().mapToInt(i -> i).sum());
    }
}
