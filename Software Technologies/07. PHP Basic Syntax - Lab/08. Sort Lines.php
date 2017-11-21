<?php
$sortedLines = "";
if (strlen($_GET["lines"]) > 0) {
    $arr = explode("\n", $_GET["lines"]);
    sort($arr);
    $sortedLines = implode("\n", $arr);
}
?>
<form>
  <textarea rows="10" name="lines"><?= $sortedLines
      ?></textarea> <br>
    <input type="submit" value="Sort">
</form>
