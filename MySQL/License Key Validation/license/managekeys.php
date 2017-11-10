<?php
		/* Set username and password for the key management */
		$username = "admin";
		$password = "woozhenqiang91";


		$getuser = $_POST["username"];
		$getpass = $_POST["password"];

		$mode = $_GET["mode"];
		$deleteid = $_GET["id"];

		$connectdb = mysql_connect("localhost","mental_dsls","6hZUS5uHmd");
		$selectdb = mysql_selectdb("mental_dsls");

		if(!isset($_COOKIE['keymanagementauth'])) {
		$mode = "login";
		}

		if(isset($_COOKIE['keymanagementauth']) && $mode == "") {
		$mode = "view";
		}

		if($username == $getuser && $password == $getpass && !isset($_COOKIE['keymanagementauth'])) {
		  setcookie('keymanagementauth', 'authed');
		  $mode = "view";
		}

if($mode == "logout") {
	 setcookie ("keymanagementauth", "", time()-60*60*24*100);
	 header('location: managekeys.php');
}

if($mode == "login") {
	echo '		<div id="loginbox"><center>
			<form action="managekeys.php" method="POST">
			Username <input type="text" name="username" /><br>
			Password <input type="password" name="password"><br><br>
			<input type="submit" value="Login" />
			</form></center></div>
	';
}

if ($mode == "delete") {

if(!isset($_COOKIE['keymanagementauth'])){
	header('Location: managekeys.php');
	exit;
}
		
		$connectdb;
		$selectdb;
		$query = 'DELETE FROM `keys` WHERE id=' . $deleteid;
		mysql_query($query);

		header('Location: managekeys.php?mode=view');
}

if ($mode == "search") {

if(!isset($_COOKIE['keymanagementauth'])){
	header('Location: managekeys.php');
	exit;
}

		$s = $_GET["s"];

		$connectdb;
		$selectdb;
		$query = "SELECT * FROM `keys` WHERE `key` LIKE '%" . $s . "%'";
		$result = mysql_query($query);
		$num=mysql_numrows($result);

				echo '<div id="tablewrapper">';
		echo '<table><th>Key</th><th>Delete</th>';
		$i = 0;
		$tablebreaker = 0;

		while ($i < $num) {
			
			if ($tablebreaker == "10") {
				echo "</table><table><th>Key</th><th>Delete</th>";
				$tablebreaker = 0;
			}
			
			$keys = mysql_result($result,$i,"key");
			$id = mysql_result($result,$i,"id");

			echo '<tr class="tablerow"><td>';
			echo $keys;
			echo '</td><td>';
			echo '<a href="?mode=delete&id=' . $id . '">Delete</a>';
			echo '</td></tr>';
			$i++;
			$tablebreaker++;

	
			}
		
		
		echo '</table></div>';
		
		echo '<div id="addkey_wrapper"><div id="addkey_top"></div><div id="addkey_middle"><div id="addkey_content">
			<form action="addkey.php" method="post">
			<input type="text" name="key" />
			<input type="submit" value="Add Key" />
			</form> </div></div><div id="addkey_bottom"></div></div>';

		echo '<div id="addkey_wrapper"><div id="searchkey_top"></div><div id="addkey_middle"><div id="addkey_content">
			<form action="managekeys.php" method="get">
			<input type="text" name="s" />
			<input type="hidden" name="mode" value="search">
			<input type="submit" value="Search Key" />
			</form> </div></div><div id="addkey_bottom"></div></div>';


			echo '<div id="addkey_wrapper" style="width:50px;text-decoration:underline;";><a href="managekeys.php?mode=logout">Logout</a>';

}

if ($mode == "view") {

if(!isset($_COOKIE['keymanagementauth'])){
	header('Location: managekeys.php');
	exit;
}
		$connectdb;
		$selectdb;

		$query = "SELECT * FROM `keys`";
		$result = mysql_query($query);
		$num=mysql_numrows($result);

		echo '<div id="tablewrapper">';
		echo '<table><th>Key</th><th>Delete</th>';
		$i = 0;
		$tablebreaker = 0;

		while ($i < $num) {
			
			if ($tablebreaker == "10") {
				echo "</table><table><th>Key</th><th>Delete</th>";
				$tablebreaker = 0;
			}
			
			$keys = mysql_result($result,$i,"key");
			$id = mysql_result($result,$i,"id");

			echo '<tr class="tablerow"><td>';
			echo $keys;
			echo '</td><td>';
			echo '<a href="?mode=delete&id=' . $id . '">Delete</a>';
			echo '</td></tr>';
			$i++;
			$tablebreaker++;
			
			
		}
		
		echo '</table></div>';
		
		echo '<div id="addkey_wrapper"><div id="addkey_top"></div><div id="addkey_middle"><div id="addkey_content">
			<form action="addkey.php" method="post">
			<input type="text" name="key" />
			<input type="submit" value="Add Key" />
			</form> </div></div><div id="addkey_bottom"></div></div>';

		echo '<div id="addkey_wrapper"><div id="searchkey_top"></div><div id="addkey_middle"><div id="addkey_content">
			<form action="managekeys.php" method="get">
			<input type="text" name="s" />
			<input type="hidden" name="mode" value="search">
			<input type="submit" value="Search Key" />
			</form> </div></div><div id="addkey_bottom"></div></div>';
		
			echo '<div id="addkey_wrapper" style="width:50px;text-decoration:underline;";><a href="managekeys.php?mode=logout">Logout</a>';

}




?>
<link rel="stylesheet" type="text/css" href="stylesheet.css">