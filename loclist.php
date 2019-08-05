<?php
	$db = mysqli_connect('localhost', 'REDACTED_user', 'REDACTED', 'REDACTED_DB') or die('Connection Failed: ' . mysqli_error());
	
	$statement = "SELECT * FROM REDACTED_DB.locations";
	$result = $db->query($statement) or die('Query failed: ' . mysqli_error());
	
	$num_results = mysqli_num_rows($result);
	
	for($i = 0; $i < $num_results; $i++){
		$row = mysqli_fetch_array($result);
		//echo $row['idshindigs'] . "\t" . $row['name'] . "\t" . $row['location'] . "\t" . $row['starttime'] . "\t" . $row['endtime'] . "\t" . $row['description'] . "\n";
		echo $row['locname']."*".$row['latitude']."*".$row['longitude']."*".$row['ldesc']."*".$row['address']."*".$row['website']."*".$row['idlocations']."*".$row['locverified']."**^";		
	}
	//Dummy entry that won't show up, stops errors
	echo "6*6*6*6*6*6*6*6*6*6*^";
?>