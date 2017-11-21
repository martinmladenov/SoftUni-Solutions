<?php
$text = "";
if (isset($_GET["text"])) {
    preg_match_all('/\w+/', $_GET["text"], $matches);
    $words = array_filter($matches[0], function ($word) {
        return $word == strtoupper($word);
    });
    $text = implode(", ", $words);
}
?>
<form>
    <textarea rows="10" name="text"><?= $text ?></textarea><br>
    <input type="submit" value="Extract">
</form>
