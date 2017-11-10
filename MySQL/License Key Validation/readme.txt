
--------------------------------
Simple License Validation Script
--------------------------------


How it works?

You can assign a key to a user and then call the script to check if the key is valid or not.
This is done by navigating to your website and then passing the key onto the URL.
You can use this for your bots (if you intend to sell them) and make the bot navigates to the URL first and evaluate the key.
eg: http://mysite.com/license/check.php?key=test123


Installation

1) Create a new mySQL database and user

2) Add the new user to the database

3) Create a table inside the database called "keys"

4) Upload the folder to your website, eg: http://mysite.com

5) Change all the database parameters (DB_USERNAME, DB_PASSWORD, DB_NAME) accordingly in the php files

6) Add your keys in managekeys.php admin panel

7) Remember to change the username and password in managekeys.php, default settings is admin, password

8) On thankyoupage_addkey.php is the code to try to grab the Paypal transaction id (using the PDT function) and then insert into the database automatically
Not tested yet. So not sure if it works.

9) Add the following lines to your robots.txt to prevent search engines indexing the folder

User-agent: *
Disallow: /license/

-----------------------------------------------------------------------------------------------------

Documentation

NOTE: All the scripts require a table inside the database called "keys". The table must have 2 columns:
Column 1: 'id'- must have the AUTO_INCREMENT attribute.
Column 2: 'key'

You can create this table by replacing DB_NAME with your databases name, and using the following SQL statement in the correct database in phpmyadmin:

 CREATE TABLE `DB_NAME`.`keys` (
`id` TINYINT( 10 ) NOT NULL AUTO_INCREMENT ,
`key` VARCHAR( 50 ) NOT NULL ,
PRIMARY KEY ( `id` )
)


1) File: check.php
Functionality: Checks the key assigned to the "?key=" URL variable, compares it to keys assigned to a database, and outputs results depending wether the key variable was found in database or not.

Modifications: 

To change the database being used, you need to modify the following lines
Line 7: mysql_connect("database_address","database_username","database_password")
Line 10: mysql_selectdb("database_name")

To change the output for the script, you need to modify these lines
Line 30: echo 'Text if key found in database';
Line 32: echo 'Text if key not found in database';


2) File: managekeys.php
Functionality: Displays all keys in the database, with the functions to delete, add or search keys. Secured in a cookie-based login system.

Modifications:

To change the username/password for the login, you need to modify the following lines
Line 3: $username = "username";
Line 4: $password = "password";

To change the database being used, you need to modify the following lines
Line 13: $connectdb = mysql_connect("database_address","database_username","database_password");
Line 14: $selectdb = mysql_selectdb("database_name");


3) File: addkey.php
Functionality: A function for adding keys in the managekeys.php file.

Modifications:

To change the database being used, you need to modify the following lines
Line 10 in addkey.php: mysql_connect("database_address","database_username","database_password")
Line 11 in addkey.php: mysql_selectdb("database_name")


4) File: thankyoupage_addkey.php
Functionality: Grabs an URL variable and inserts it into the database as a key.

Modifications:

To change the variable being grabbed, you need to modify the following line
Line 3: $addkey = $_REQUEST["variable_name"];

To change the database being used, you need to modify the following lines
Line 5: mysql_connect("database_address","database_username","database_password")
Line 6: mysql_selectdb("database_name")


That's all. Thank you.. :)
