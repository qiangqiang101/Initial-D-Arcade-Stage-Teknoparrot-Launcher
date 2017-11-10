<?php
    //Again, fill in your server data here!
    $db = mysql_connect('localhost', 'mental_id', 'Lgq`jyu5') or die('Failed to connect: ' . mysql_error()); 
        mysql_select_db('mental_id') or die('Failed to access database');
 
     //This query grabs the top 10 scores, sorting by score and timestamp.
    $query = "SELECT * FROM Scores ORDER by score DESC, ts ASC LIMIT 50";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
 
    //We find our number of rows
    $result_length = mysql_num_rows($result); 
    
    //And now iterate through our results
    for($i = 0; $i < $result_length; $i++)
    {
         $row = mysql_fetch_array($result);
         echo $row['name'] . "," . $row['score'] . "#"; // And output them
    }
?>