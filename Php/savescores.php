<?php
$servername = "127.0.0.1";
$username = "regenboogslang";
$password = "mythenw8woord";
$dbname = "mythen";

$deviceId = $_POST['deviceId'];
$name = $_POST['name'];
$score = $_POST['score'];
$pickups = $_POST['pickups'];
$distance = $_POST['distance'];
$time = $_POST['time'];
$plays = 0;

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT * FROM Scores WHERE deviceid = '$deviceId'";

if($conn->query($sql)->num_rows > 0) {
    
    echo "Update Score <br>";
    
    $oldScore = $conn->query($sql)->fetch_assoc();
    
    echo "old pickups score =  " . $oldScore["pickups"] . " <br> ";
    
    
    if($oldScore["distance"] > $distance) {
        $distance = intval($oldScore["distance"]);
    }
    
    if($oldScore["pickups"] > $pickups) {
        $pickups = intval($oldScore["pickups"]);
    }
    
    if($oldScore["time"] > $time) {
        $pickups = intval($oldScore["pickups"]);
    }
    
    $plays = $oldScore["plays"] + 1;
    
    
    $sql2 = "UPDATE Scores SET pickups = '$pickups', distance = '$distance', time = '$time', plays = '$plays' WHERE deviceId = '$deviceId'";
        
} else {
    
    echo "TEST Make new Score: " . $result . "<br>" . $conn->error . "<br>";
    
    $sql2 = "INSERT INTO `$dbname`.`Scores` (name, score, pickups, distance, time, deaths, deviceId) VALUES ('$name', '$score', '$pickups', '$distance', '$time,', '$deaths', '$deviceId')";
}


if ($conn->query($sql2)) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
}

$conn->close();
?>
