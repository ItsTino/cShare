<?php
$id = htmlentities($_GET['id']);
$image = "<img src=\"/clippr/".$id.".png\">";
$imagePath = "/clippr/".$id.".png";

$imagedata = file_get_contents($imagePath);
$base64 = base64_encode($imagedata);

?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta content="IE=edge,chrome=1" http-equiv="X-UA-Compatible" />
    <title>0x19 Share</title>
    <meta content="0x19" name="description" />
    <meta content="on" http-equiv="cleartype" />
    <meta content="notranslate" name="google" />
    <meta content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=no" id="viewport" name="viewport" />
    <link rel="stylesheet" media="all" href="css.css" />

   
</head>

<body class="en-gb about eu">
    <header id="header">
        <hgroup>
			<p>0x19.XYZ Share</p>
            
        </hgroup>    
    </header>


		<center>
		<?php echo $image ?>
		<?php echo $imagePath ?>
        <?php echo $base64 ?>



		</article></center>

<div id="wrap">
    </div> 
    

   
</body>

</html>
