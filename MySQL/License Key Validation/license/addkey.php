<?php

		if(!isset($_COOKIE['keymanagementauth'])){
		header('Location: managekeys.php');
		exit;
		}

		$addkey = $_POST["key"];

		mysql_connect("localhost","mental_dsls","6hZUS5uHmd");
		mysql_selectdb("mental_dsls");
		$query = "INSERT INTO `keys` VALUES ('','" . $addkey . "')";
		mysql_query($query);

		header('Location: managekeys.php');
?>