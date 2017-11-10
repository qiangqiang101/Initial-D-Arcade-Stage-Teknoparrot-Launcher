<?php

		$addkey = $_REQUEST["txn_id"];

		mysql_connect("localhost","mental_dsls","6hZUS5uHmd");
		mysql_selectdb("mental_dsls");
		$query = "INSERT INTO `keys` VALUES ('','" . $addkey . "')";
		mysql_query($query);

?>