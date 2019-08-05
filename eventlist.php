<?php
	$db = mysqli_connect('localhost', 'REDACTED_user', 'REDACTED', 'REDACTED_DB') or die('Connection Failed: ' . mysqli_error());
	
	$now = strtotime(gmdate("Y-m-d H:i"));
	//echo $now . "\n";
	
	$statement = "SELECT * FROM REDACTED_DB.shindigs
	JOIN REDACTED_DB.locations
	ON REDACTED_DB.shindigs.shinlocation=REDACTED_DB.locations.idlocations
	ORDER BY REDACTED_DB.shindigs.starttime";
	$result = $db->query($statement) or die('Query failed: ' . mysqli_error());
	
	$num_results = mysqli_num_rows($result);
	
	for($i = 0; $i < $num_results; $i++){
		$row = mysqli_fetch_array($result);
		$temptime = strtotime($row['endtime']);
		if($temptime > $now){
			//echo $row['idshindigs'] . "\t" . $row['name'] . "\t" . $row['location'] . "\t" . $row['starttime'] . "\t" . $row['endtime'] . "\t" . $row['description'] . "\n";
			echo $row['shinname']."*".$row['starttime']."*".$row['endtime']."*".$row['shindesc']."*".$row['locname']."*".$row['latitude']."*".$row['longitude']."*".$row['ldesc']."*".$row['address']."*".$row['website']."*".$row['drink']."*".$row['idshindigs']."*".$row['idlocations']."*".$row['shinverified']."*".$row['locverified']."**^";
		}		
	}
	echo "6*6*6*6*6*6*6*6*6*6*^";
?>