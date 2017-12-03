import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Ex16_URL_Parser {
    public static void main(String[] args) {
        Pattern pattern = Pattern.compile("^(?:(?<protocol>.+?)://)?(?<server>.+?)(?:/(?<resource>.*))?$");
        Scanner scanner = new Scanner(System.in);
        String url = scanner.nextLine();
        Matcher matcher = pattern.matcher(url);
        matcher.find();
        String protocol = matcher.group("protocol");
        String server = matcher.group("server");
        String resource = matcher.group("resource");
        System.out.printf(
                "[protocol] = \"%s\"\r\n" +
                        "[server] = \"%s\"\r\n" +
                        "[resource] = \"%s\"\r\n",
                protocol == null ? "" : protocol,
                server,
                resource == null ? "" : resource);
    }
}
