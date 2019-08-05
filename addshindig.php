<?php
	$db = mysqli_connect('localhost', 'REDACTED_user', 'REDACTED', 'REDACTED_DB') or die('Connection Failed: ' . mysqli_error());
	
	$username = $_GET['Username'];
	$machine = $_GET['Machine'];
	$shinname = $_GET['ShindigName'];
	$shindesc = $_GET['ShindigDescription'];
	$start = $_GET['StartTime'];
	$end = $_GET['EndTime'];
	$drink = $_GET['Drink'];
	$locid = $_GET['LocationID'];
	$quietdonttellanybody="eT0lxSaSImMQG9an7f3b";
	
	if($username != ""){
		$insertion = "INSERT INTO REDACTED_DB.shindigs (shinname, drink, starttime, endtime, shindesc, shincontributor, shinmachine, shinlocation)VALUES('" . $shinname . "', '" . $drink. "', '" . $start . "', '" . $end . "', '" . $shindesc . "', '" . $username . "', '" . $machine . "', '" . $locid . "')";
		$reg = $db->query($insertion) or die("Submission failed." . mysqli_error($db));
		mysqli_close();
		echo "Event submitted!";
	}
	mysqli_close();
?>