<?php
if (isset($_GET["num1"]) && isset($_GET["num1"])) {
    echo $_GET["num1"] . " + " . $_GET["num2"] . " = " . (intval($_GET["num1"]) + intval($_GET["num2"]));
}
?>
<form>
    <div>First Number:</div>
    <input type="number" name="num1"/>
    <div>Second Number:</div>
    <input type="number" name="num2"/>
    <div><input type="submit"/></div>
</form>
