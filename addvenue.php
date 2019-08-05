<?php
	$db = mysqli_connect('localhost', 'REDACTED_user', 'REDACTED', 'REDACTED_DB') or die('Connection Failed: ' . mysqli_error());
	
	$username = $_GET['Username'];
	$machine = $_GET['Machine'];
	$locname = $_GET['LocationName'];
	$address = $_GET['Address'];
	$desc = $_GET['Description'];
	$web = $_GET['Website'];
	$lat = $_GET['Latitude'];
	$long = $_GET['Longitude'];
	$quietdonttellanybody="eT0lxSaSImMQG9an7f3b";
	
	if($username != ""){
		// these work --> echo $username . $password . $city . $province . $prefdevice . $email;
		$insertion = "INSERT INTO REDACTED_DB.locations (locname, address, latitude, longitude, ldesc, website, loccontributor, locmachine)VALUES('" . $locname . "', '" . $address. "', '" . $lat . "', '" . $long . "', '" . $desc . "', '" . $web . "', '" . $username . "', '" . $machine . "')";
		$reg = $db->query($insertion) or die("Submission failed." . mysqli_error($db));
		mysqli_close();
		echo "Venue submitted!";
	}
	mysqli_close();
?>