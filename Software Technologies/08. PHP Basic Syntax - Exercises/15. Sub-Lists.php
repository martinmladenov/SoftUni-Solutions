<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num1"/>
    M: <input type="text" name="num2"/>
    <input type="submit"/>
</form>
<ul>
    <?php
    if (isset($_GET["num1"]) && isset($_GET["num2"])) {
        $num1 = intval($_GET["num1"]);
        $num2 = intval($_GET["num2"]);
        for ($i1 = 1; $i1 <= $num1; $i1++) {
            echo "<li>List $i1<ul>";
            for ($i2 = 1; $i2 <= $num2; $i2++) {
                echo "<li>Element $i1.$i2</li>";
            }
            echo "</ul></li>";
        }
    }
    ?>
</ul>
</body>
</html>