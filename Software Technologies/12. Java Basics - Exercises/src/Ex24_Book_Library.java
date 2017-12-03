import java.util.*;
import java.util.stream.Collectors;

public class Ex24_Book_Library {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Book> books = new ArrayList<>();
        int n = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < n; i++)
            books.add(new Book(scanner.nextLine()));

        books.stream()
                .collect(Collectors.groupingBy(Book::getAuthor))
                .entrySet()
                .stream()
                .collect(Collectors.toMap(Map.Entry::getKey,
                        e -> e.getValue()
                                .stream()
                                .mapToDouble(Book::getPrice)
                                .sum()))
                .entrySet()
                .stream()
                .sorted(
                        ((Comparator<Map.Entry<String, Double>>) (o1, o2) ->
                                Double.compare(o2.getValue(), o1.getValue()))
                                .thenComparing(Comparator.comparing(Map.Entry::getKey)))
                .forEach(author -> System.out.printf("%s -> %.2f\r\n", author.getKey(), author.getValue()));

    }

    static class Book {
        private String title, author, publisher, releaseDate, ISBN;
        private double price;

        public Book(String input) {
            String[] split = input.split(" ");
            this.title = split[0];
            this.author = split[1];
            this.publisher = split[2];
            this.releaseDate = split[3];
            this.ISBN = split[4];
            this.price = Double.parseDouble(split[5]);
        }

        public String getTitle() {
            return title;
        }

        public String getAuthor() {
            return author;
        }

        public String getPublisher() {
            return publisher;
        }

        public String getReleaseDate() {
            return releaseDate;
        }

        public String getISBN() {
            return ISBN;
        }

        public double getPrice() {
            return price;
        }
    }
}
