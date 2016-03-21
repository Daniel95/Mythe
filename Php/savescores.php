<?php
$servername = "127.0.0.1";
$username = "regenboogslang";
$password = "mythenw8woord";
$dbname = "mythen";

$name = $_POST['name'];
$score = $_POST['score'];
$pickups = $_POST['pickups'];
$distance = $_POST['distance'];
$time = $_POST['time'];
$deaths = $_POST['deaths'];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "INSERT INTO `$dbname`.`Scores` (name, score, pickups, distance, time, deaths) VALUES ('$name', '$score', '$pickups', '$distance', '$time,', '$deaths')";

if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>