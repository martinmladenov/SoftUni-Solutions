import java.util.Random;
import java.util.Scanner;

public class Ex21_Advertisement_Message {
    public static void main(String[] args) {
        String[] phrases = {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can't live without this product."
        };
        String[] events = {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
        };
        String[] authors = {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
        };
        String[] cities = {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
        };

        Scanner scanner = new Scanner(System.in);
        int count = scanner.nextInt();
        Random rnd = new Random();
        for (int i = 0; i < count; i++) {
            System.out.printf("%s %s %s - %s\r\n",
                    phrases[rnd.nextInt(phrases.length)],
                    events[rnd.nextInt(events.length)],
                    authors[rnd.nextInt(authors.length)],
                    cities[rnd.nextInt(cities.length)]);
        }
    }
}
