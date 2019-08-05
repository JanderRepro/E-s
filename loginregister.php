<?php
	$db = mysqli_connect('localhost', 'REDACTED_user', 'REDACTED', 'REDACTED_DB') or die('Connection Failed: ' . mysqli_error());
	
	$action = $_GET['Action']; //login or register?
	$username = $_GET['Username'];
	$password = $_GET['Password'];
	$email = $_GET['Email'];
	$city = $_GET['City'];
	$province = $_GET['Province'];
	$prefdevice = $_GET['Prefdevice'];
	$quietdonttellanybody="REDACTED";
	
	if($action == 'login'){
		if(!$username || !$password){
			echo "Fields incomplete.";
		} else{
			$statement = "SELECT * FROM REDACTED_DB.users WHERE username = '" . $username . "'";
			$result = $db->query($statement) or die("Query failed: " . mysqli_error());
			$total = mysqli_num_rows($result);
			if($total){
				$datas = @mysqli_fetch_array($result);
				if(strcmp($username, $datas['username'])){
					echo "Incorrect username.";
				}
				else if(!strcmp($password, $datas['password'])){
					echo "Login successful!";
				} else{
					echo "Password incorrect.";
				}
			} else echo "Incorrect username.";
		}
	}
	
	if($action == 'register'){
		$checkuser = ("SELECT username from REDACTED_DB.users WHERE username='" . $username . "'");
		$cur = $db->query($checkuser) or die("Name-check failed: " . mysqli_error());
		$usernametaken = mysqli_num_rows($cur);
		if($usernametaken > 0){
			echo "Username already registered.";
			unset($username);
			exit();
		} else{
			$insertion = "INSERT INTO REDACTED_DB.users (username, password, city, province, prefdevice, email)VALUES('" . $username . "', '" . $password . "', '" . $city . "', '" . $province . "', '" . $prefdevice . "', '" . $email . "')";
			$reg = $db->query($insertion) or die("Registration failed." . mysqli_error($db));
			mysqli_close();
			echo "Account registered. Welcome to E's!";
		}
	}	
	
	mysqli_close();
?>