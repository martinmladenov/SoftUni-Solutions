import java.util.Scanner;

public class Ex22_Intersection_of_Circles {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Circle c1 = new Circle(scanner.nextDouble(), scanner.nextDouble(), scanner.nextDouble());
        Circle c2 = new Circle(scanner.nextDouble(), scanner.nextDouble(), scanner.nextDouble());
        System.out.println(c1.isIntersecting(c2) ? "Yes" : "No");
    }
}

class Circle {

    private double x, y, radius;

    Circle(double x, double y, double radius) {
        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    public boolean isIntersecting(Circle other) {
        double distance = Math.sqrt(Math.pow(x - other.x, 2) + Math.pow(y - other.y, 2));
        return distance <= other.radius + radius;
    }
}