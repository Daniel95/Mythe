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
$plays = 1;

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT * FROM Scores WHERE name = '$name'";

if($conn->query($sql)->num_rows > 0) {
    
    echo "Update Score <br>";
    
    $oldScore = $conn->query($sql)->fetch_assoc();
    
    if($oldScore["distance"] > $distance) {
        $distance = $oldScore["distance"];
    }
    
    if($oldScore["pickups"] > $pickups) {
        $pickups = $oldScore["pickups"];
    }
    
    if($oldScore["time"] > $time) {
        $time = $oldScore["time"];
    }
    
    $plays = $oldScore["plays"] + 1;
    
    $sql2 = "UPDATE Scores SET name = '$name', pickups = '$pickups', distance = '$distance', time = '$time', plays = '$plays' WHERE name = '$name'";
        
} else {
    
    echo "TEST Make new Score: " . $result . "<br>" . $conn->error . "<br>";
    
    $sql2 = "INSERT INTO `$dbname`.`Scores` (name, score, pickups, distance, time, plays) VALUES ('$name', '$score', '$pickups', '$distance', '$time', '$plays')";
}


if ($conn->query($sql2)) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
}

$conn->close();
?>
