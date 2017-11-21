<?php
if (isset($_GET["person"])) {
    echo "Hello, " . htmlspecialchars($_GET["person"]) . "!";
} else {
    ?>
    <form>
        Name: <input type="text" name="person"/>
        <input type="submit"/>
    </form>
    <?php
}
?>