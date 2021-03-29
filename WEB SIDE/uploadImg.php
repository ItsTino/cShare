<?php

$data = base64_decode($_POST["img64"]);
$picname = $_POST["fname"];
$newfilename = $picname . 'png';

file_put_contents($newfilename, $data);
