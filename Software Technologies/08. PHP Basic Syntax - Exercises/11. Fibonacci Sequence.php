<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num"/>
    <input type="submit"/>
</form>
<?php
if (isset($_GET["num"])) {
    $num = intval($_GET["num"]);
    $p1 = 0;
    $p2 = 1;
    for ($i = 0; $i < $num; $i++) {
        echo $p2 . " ";
        $tmp = $p1 + $p2;
        $p1 = $p2;
        $p2 = $tmp;
    }
}
?>
</body>
</html>