import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Scanner;

public class Ex20_Count_Working_Days {
    public static void main(String[] args) throws ParseException {
        Scanner scanner = new Scanner(System.in);
        DateFormat format = new SimpleDateFormat("dd-MM-yyyy");
        Calendar cal = Calendar.getInstance();
        cal.setTime(format.parse(scanner.nextLine()));
        Calendar end = Calendar.getInstance();
        end.setTime(format.parse(scanner.nextLine()));
        end.add(Calendar.DATE, 1);

        int workingDays = 0;
        while (cal.before(end)) {
            if (!isHoliday(cal)) {
                workingDays++;
            }
            cal.add(Calendar.DATE, 1);
        }
        System.out.println(workingDays);
    }

    @SuppressWarnings("MagicConstant")
    private static boolean isHoliday(Calendar cal) {
        return cal.get(Calendar.DAY_OF_WEEK) == Calendar.SATURDAY ||
                cal.get(Calendar.DAY_OF_WEEK) == Calendar.SUNDAY ||
                cal.get(Calendar.DAY_OF_MONTH) == 1 && cal.get(Calendar.MONTH) == 0 ||
                cal.get(Calendar.DAY_OF_MONTH) == 3 && cal.get(Calendar.MONTH) == 2 ||
                cal.get(Calendar.DAY_OF_MONTH) == 1 && cal.get(Calendar.MONTH) == 4 ||
                cal.get(Calendar.DAY_OF_MONTH) == 6 && cal.get(Calendar.MONTH) == 4 ||
                cal.get(Calendar.DAY_OF_MONTH) == 24 && cal.get(Calendar.MONTH) == 4 ||
                cal.get(Calendar.DAY_OF_MONTH) == 6 && cal.get(Calendar.MONTH) == 8 ||
                cal.get(Calendar.DAY_OF_MONTH) == 22 && cal.get(Calendar.MONTH) == 8 ||
                cal.get(Calendar.DAY_OF_MONTH) == 1 && cal.get(Calendar.MONTH) == 10 ||
                cal.get(Calendar.MONTH) == 11 &&
                        (cal.get(Calendar.DAY_OF_MONTH) == 24 ||
                                cal.get(Calendar.DAY_OF_MONTH) == 25 ||
                                cal.get(Calendar.DAY_OF_MONTH) == 26);
    }
}
