<ul>
    <?php
    for ($i = 1; $i <= 20; $i++) {
        echo "<li><span style='color:" . ($i % 2 == 0 ? "green" : "blue") . "'>$i</span></li>";
    }
    ?>
</ul>