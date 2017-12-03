import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;

public class Ex25_Book_Library_Modification {
    public static void main(String[] args) throws ParseException {
        Scanner scanner = new Scanner(System.in);
        List<Book> books = new ArrayList<>();
        int n = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < n; i++)
            books.add(new Book(scanner.nextLine()));
        Calendar cal = Calendar.getInstance();
        cal.setTime(new SimpleDateFormat("dd.MM.yyyy").parse(scanner.nextLine()));

        books.stream()
                .filter(b -> b.getReleaseDateAsCalendar().after(cal))
                .sorted(Comparator.comparing(Book::getReleaseDateAsCalendar)
                        .thenComparing(Book::getTitle))
                .forEach(book ->
                        System.out.printf("%s -> %s\r\n",
                                book.getTitle(), book.getReleaseDate()));
    }

    static class Book {
        private String title, author, publisher, ISBN, releaseDate;
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

        public Calendar getReleaseDateAsCalendar() {
            Calendar cal = Calendar.getInstance();
            try {
                cal.setTime(new SimpleDateFormat("dd.MM.yyyy").parse(releaseDate));
            } catch (ParseException e) {
                e.printStackTrace();
            }
            return cal;
        }

        public String getISBN() {
            return ISBN;
        }

        public double getPrice() {
            return price;
        }
    }
}

