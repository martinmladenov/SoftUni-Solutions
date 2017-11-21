<form>
    Celsius: <input type="text" name="cel"/>
    <input type="submit" value="Convert">
    <?php
    if (isset($_GET["cel"]))
        echo $_GET["cel"] . "&deg;C = " . ($_GET["cel"] * 1.8 + 32) . "&deg;F";
    ?>
</form>
<form>
    Fahrenheit: <input type="text" name="fah"/>
    <input type="submit" value="Convert">
    <?php
    if (isset($_GET["fah"]))
        echo $_GET["fah"] . "&deg;F = " . (($_GET["fah"] - 32) / 1.8) . "&deg;C";
    ?>
</form>
