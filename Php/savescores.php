<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "mythen";

$name = $_GET['name'];
$pickups = $_GET['pickups'];
$distance = $_GET['distance'];
$time = $_GET['time'];

$scoreType = $_GET['scoreType'];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$sql = "INSERT INTO scores (name, pickups, distance, time)
VALUES ('$name', '$pickups', '$distance', '$time')";

if ($conn->query($sql) === TRUE) {
    //echo "New record created successfully";
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>