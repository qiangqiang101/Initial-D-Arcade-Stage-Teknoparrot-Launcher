<?php
    //Again, fill in your server data here!
    $db = mysql_connect('localhost', 'mental_id', 'Lgq`jyu5') or die('Failed to connect: ' . mysql_error()); 
        mysql_select_db('mental_id') or die('Failed to access database');
 
	//These are our variables.
    //We use real escape string to stop people from injecting. We handle this in Unity too, but it's important we do it here as well in case people extract our url.
    $name = mysql_real_escape_string($_GET['name'], $db); 
    $weather = mysql_real_escape_string($_GET['weather'], $db); 
	$track = mysql_real_escape_string($_GET['track'], $db); 
    $coursetype = mysql_real_escape_string($_GET['coursetype'], $db); 
	$gameversion = mysql_real_escape_string($_GET['gameversion'], $db); 
 
     //This query grabs the top 10 scores, sorting by score and timestamp.
    $query = "SELECT * FROM Scores WHERE gameversion = '$gameversion' AND track = '$track' AND coursetype = '$coursetype' AND weather = '$weather' ORDER by score ASC, ts ASC LIMIT 30";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
 
    //We find our number of rows
    $result_length = mysql_num_rows($result); 
    
    //And now iterate through our results
    for($i = 0; $i < $result_length; $i++)
    {
         $row = mysql_fetch_array($result);
         echo $row['name'] . "," . $row['score'] . "," . $row['car'] . "#"; // And output them
    }
?>