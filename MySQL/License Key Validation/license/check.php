<?php

	/* Grab the URL variable */
	$key = $_GET["key"];

	/* Connect to database and grab the keys */
	mysql_connect("localhost","mental_dsls","6hZUS5uHmd")
	or die("Couldnt connect to database server");
	mysql_selectdb("mental_dsls")
	or die("Couldnt select database");
	$query = "SELECT `key` FROM `keys`";
	$result = mysql_query($query);
	$num=mysql_numrows($result);

	/* Set up a loop to check if requested key is found in database */
	$i=0;
	while ($i < $num) {

		$validationkey = mysql_result($result,$i,"key");

			if ($validationkey == $key) {
				$validation = "Success";
			}

		$i++;
	}

	/* If a match was found in database, echo "VALID". Else echo "ERROR" */
	if($validation != "") {
		echo 'VALID';
	} else {
		echo 'ERROR';
	}


?>