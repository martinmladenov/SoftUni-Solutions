import java.util.*;

public class Ex23_Average_Grades {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        List<Student> students = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            String nextLine = scanner.nextLine();
            String[] line = nextLine.split(" ");
            String name = line[0];
            double[] grades =
                    Arrays.stream(line)
                            .skip(1)
                            .mapToDouble(Double::parseDouble)
                            .toArray();
            students.add(new Student(name, grades));
        }
        for (Student s : students.stream()
                .filter(s -> s.getAverage() >= 5)
                .sorted(Comparator.comparing(Student::getName)
                        .thenComparing((s1, s2) -> {
                            if (s1.getAverage() == s2.getAverage()) return 0;
                            return s2.getAverage() > s1.getAverage() ? 1 : -1;
                        }))
                .toArray(Student[]::new)) {
            System.out.printf("%s -> %.2f\r\n", s.getName(), s.getAverage());
        }
    }
}

class Student {
    private double[] grades;
    private String name;

    public Student(String name, double[] grades) {
        this.name = name;
        this.grades = grades;
    }

    public String getName() {
        return name;
    }

    public double getAverage() {
        return Arrays.stream(grades).average().getAsDouble();
    }
}