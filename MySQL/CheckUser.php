<?php 

    //Again, fill in your server data here!
    $db = mysql_connect('localhost', 'mental_id', 'Lgq`jyu5') or die('Failed to connect: ' . mysql_error()); 
    mysql_select_db('mental_id') or die('Failed to access database');

	//These are our variables.
    //We use real escape string to stop people from injecting. We handle this in Unity too, but it's important we do it here as well in case people extract our url.
    $username = mysql_real_escape_string($_GET['name'], $db); 
	
	$result = mysql_query("SELECT * FROM Scores WHERE name = '$username'");
	$matchFound = mysql_num_rows($result) > 0 ? 'yes' : 'no';
	echo $matchFound;
	
?>