<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
<?php
for ($row = 0; $row < 9; $row++) {
    if ($row == 0 || $row == 4 || $row == 8)
        for ($col = 0; $col < 5; $col++)
            echo "<button style='background-color:blue'>1</button>";

    if ($row > 0 && $row < 4) {
        echo "<button style='background-color:blue'>1</button>";
        for ($col = 0; $col < 4; $col++)
            echo "<button>0</button>";
    }

    if ($row > 4 && $row < 8) {
        for ($col = 0; $col < 4; $col++)
            echo "<button>0</button>";

        echo "<button style='background-color:blue'>1</button>";
    }
    echo "<br>";
}
?>
</body>
</html>